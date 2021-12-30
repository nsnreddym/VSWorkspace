using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace DataRadio_configurator
{
    class Comm
    {
		public byte[] sof = new byte[2];
		public byte packlen;
		public byte cmd;
		public byte[] secadd = new byte[3];
		public byte[] data = new byte[4];
		public byte[] crc = new byte[4];

		
		byte[] TxBuf = new byte[15];
		byte[] RxBuf = new byte[15];

		const byte READ_CMD = 0x01;
		const byte WRITE_CMD = 0x02;
		const byte ERASE_CMD = 0x03;
		const byte SUCCESS_CMD = 0x05;
		const byte FAIL_CMD = 0x06;
		const byte REPLY_CMD = 0x07;
		const byte SEL_CH = 0x08;
		const byte PWR_DWN = 0x09;
		const byte PWR_ON = 0x0A;
		const byte RX_OFF = 0x0C;
		const byte RX_ON = 0x0D;

		public Comm()
		{
		}

		private void SendDataPacket(SerialPort sport)
		{
			sport.Write(TxBuf, 0, 15);

			while (sport.BytesToWrite != 0) ;

		}

		private void ReadResponse(SerialPort sport)
		{
			bool loop;
			int byte_rcvd;
			UInt32 hdr;
			bool hdrok;
			int byteindx;

			loop = true;
			hdr = 0;
			hdrok = false;
			byteindx = 0;
			while (loop)
			{
				byte_rcvd = sport.ReadByte();
				if (hdrok == true)
				{
					RxBuf[byteindx] = (byte)byte_rcvd;
					byteindx = byteindx + 1;

					if (byteindx == 15)
					{
						loop = false;
					}
				}
				else
				{
					hdr = hdr << 8;
					hdr = hdr | (UInt32)byte_rcvd;
					hdr = hdr & 0x0000FFFF;
					if (hdr == 0x0000A5C3)
					{
						hdrok = true;
						RxBuf[0] = 0xA5;
						RxBuf[1] = 0xC3;
						byteindx = 2;
					}
				}

			}

		}

		private void Prepare_packet(byte cmd, byte[] addr, byte[] data)
        {
			//sof
			TxBuf[0] = 0xA5;
			TxBuf[1] = 0xC3;

			//packlen
			TxBuf[2] = 0x0F;

			//cmd
			TxBuf[3] = cmd;

			//sec add
			TxBuf[4] = addr[2];
			TxBuf[5] = addr[1];
			TxBuf[6] = addr[0];

			//data
			TxBuf[7] = data[0];
			TxBuf[8] = data[1];
			TxBuf[9] = data[2];
			TxBuf[10] = data[3];

			//crc
			TxBuf[11] = 0xAA;
			TxBuf[12] = 0xAA;
			TxBuf[13] = 0xAA;
			TxBuf[14] = 0xAA;
		}

		public int selch(byte chno)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);

			byte[] addr = new byte[4];
			byte[] data = new byte[4];

			addr[2] = chno;
			Prepare_packet(SEL_CH, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] == 0x05)
			{
				sport.Close();
				return 1;

			}
			else
            {
				sport.Close(); 
				return 0;
            }
		}
		public int RxEnable(bool Rxstate)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] addr = new byte[4];
			byte[] data = new byte[4];

			if (Rxstate == true)
			{
				Prepare_packet(RX_ON, addr, data);
			}
			else
			{
				Prepare_packet(RX_OFF, addr, data);
			}

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] == 0x05)
			{
				sport.Close();
				return 1;

			}
			else
            {
				sport.Close(); 
				return 0;
            }
		}
		public int TxEnable(bool Txstate)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] addr = new byte[4];
			byte[] data = new byte[4];

			if (Txstate == true)
			{
				Prepare_packet(PWR_ON, addr, data);
			}
			else
			{
				Prepare_packet(PWR_DWN, addr, data);
			}

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] == 0x05)
			{
				sport.Close();
				return 1;

			}
			else
            {
				sport.Close(); 
				return 0;
            }
		}

		public int Read_bytes(int chno_add, ref byte[] replybytes)
        {
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			
			byte[] addr = new byte[4];

			bool loop;
			int indx;
			int addr_indx;
			int maxindx;


			loop = true;
			sport.Open();
			addr_indx = chno_add;
			indx = 0;
			maxindx = 10;

			while (loop)
			{
				addr = BitConverter.GetBytes(addr_indx);

				//sof
				TxBuf[0] = 0xA5;
				TxBuf[1] = 0xC3;

				//packlen
				TxBuf[2] = 0x0F;

				//cmd
				TxBuf[3] = READ_CMD;

				//sec add
				TxBuf[4] = addr[2];
				TxBuf[5] = addr[1];
				TxBuf[6] = addr[0];

				//data
				TxBuf[7] = 0x00;
				TxBuf[8] = 0x00;
				TxBuf[9] = 0x00;
				TxBuf[10] = 0x00;

				//crc
				TxBuf[11] = 0xAA;
				TxBuf[12] = 0xAA;
				TxBuf[13] = 0xAA;
				TxBuf[14] = 0xAA;

				/* send serial data */
				SendDataPacket(sport);

				/* Read reply */
				ReadResponse(sport);				

				if (RxBuf[3] == 0x07)
				{
					replybytes[indx + 0] = RxBuf[7];
					replybytes[indx + 1] = RxBuf[8];
					replybytes[indx + 2] = RxBuf[9];
					replybytes[indx + 3] = RxBuf[10];
					if(indx == 0)
                    {
						if (RxBuf[10] > 44)
						{
							loop = false;
							indx = 0;
							addr_indx = chno_add;
						}
						else
						{
							maxindx = RxBuf[10];
							maxindx = maxindx * 4;
						}
					}
					if(indx >= maxindx)
                    {
						loop = false;
                    }
					addr_indx = addr_indx + 4;
					indx = indx + 4;
				}
			}

			sport.Close();
			return addr_indx;

		}

		public int EraseFlash(int addr)
        {
			byte[] bytedata = new byte[4];

			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			bytedata = BitConverter.GetBytes(addr);

			//sof
			TxBuf[0] = 0xA5;
			TxBuf[1] = 0xC3;

			//packlen
			TxBuf[2] = 0x0F;

			//cmd
			TxBuf[3] = ERASE_CMD;

			//sec add
			TxBuf[4] = bytedata[2];
			TxBuf[5] = 0x00;
			TxBuf[6] = 0x00;

			//data
			TxBuf[7] = 0x00;
			TxBuf[8] = 0x00;
			TxBuf[9] = 0x00;
			TxBuf[10] = 0x00;

			//crc
			TxBuf[11] = 0xAA;
			TxBuf[12] = 0xAA;
			TxBuf[13] = 0xAA;
			TxBuf[14] = 0xAA;

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] == 0x05)
			{
				sport.Close();
				return 1;

			}
			else
			{
				sport.Close();
				return 0;
			}

		}

		public int ProgDefault(int addr_indx, SYNTH_REG_t synth_reg, int length)
        {
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] replybytes = new byte[1000];
			byte[] addr = new byte[4];
			byte[] data = new byte[4];

			bool loop;
			int reg_indx;

			addr = BitConverter.GetBytes(addr_indx);

			data[0] = 0xAA;
			data[1] = 0xAA;
			data[2] = 0x00;
			data[3] = 0x2C;

			/* Send header */
			Prepare_packet(WRITE_CMD,addr,data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] != 0x05)
			{
				return 0;
			}

			loop = true;
			addr_indx = addr_indx + 4;
			reg_indx = 0;

			while (loop)
			{
				addr = BitConverter.GetBytes(addr_indx);

				addr[2] = 0;
				data[0] = 0x00;
				data[1] = synth_reg.RegAddr[reg_indx];
				data[2] = synth_reg.RegData_hi[reg_indx];
				data[3] = synth_reg.RegData_low[reg_indx];

				Prepare_packet(WRITE_CMD, addr, data);
				
				/* send serial data */
				SendDataPacket(sport);

				/* Read reply */
				ReadResponse(sport);

				if (RxBuf[3] == 0x05)
				{
					reg_indx = reg_indx + 1;
					if (reg_indx >= length)
					{
						loop = false;
					}
					addr_indx = addr_indx + 4;					
				}
			}

			sport.Close();
			return addr_indx;
		}
		
		public int ProgChannel(int addr_indx, SYNTH_REG_t synth_reg, int length)
        {
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] replybytes = new byte[1000];
			byte[] addr = new byte[4];
			byte[] data = new byte[4];
			byte[] temp = new byte[4];

			bool loop;
			int reg_indx;

			addr = BitConverter.GetBytes(addr_indx);

			temp = BitConverter.GetBytes(length);

			data[0] = 0xAA;
			data[1] = 0xAA;
			data[2] = 0x00;
			data[3] = temp[0];

			/* Send header */
			Prepare_packet(WRITE_CMD,addr,data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] != 0x05)
			{
				return 0;
			}

			loop = true;
			addr_indx = addr_indx + 4;
			reg_indx = 0;

			while (loop)
			{
				addr = BitConverter.GetBytes(addr_indx);
				
				data[0] = 0x00;
				data[1] = synth_reg.RegAddr[reg_indx];
				data[2] = synth_reg.RegData_hi[reg_indx];
				data[3] = synth_reg.RegData_low[reg_indx];

				Prepare_packet(WRITE_CMD, addr, data);
				
				/* send serial data */
				SendDataPacket(sport);

				/* Read reply */
				ReadResponse(sport);

				if (RxBuf[3] == 0x05)
				{
					reg_indx = reg_indx + 1;
					if (reg_indx >= length)
					{
						loop = false;
					}
					addr_indx = addr_indx + 4;					
				}
			}

			sport.Close();
			return addr_indx;
		}
	}
}


