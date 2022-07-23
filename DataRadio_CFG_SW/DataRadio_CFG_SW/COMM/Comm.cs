using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

using DataRadio_CFG_SW.Memory;

namespace DataRadio_CFG_SW.COMM
{
	public enum COMM_STATES
	{
		IDLE = 0,
		BUSY = 1,
		OK = 2,
		FAIL = 3
	};

    class Comm
    {
		

		public byte[] sof = new byte[2];
		public byte packlen;
		public byte cmd;
		public byte[] secadd = new byte[3];
		public byte[] data = new byte[4];
		public byte[] crc = new byte[4];

		
		byte[] TxBuf = new byte[15];
		byte[] RxBuf = new byte[24];

		const byte READ_CMD = 0x01;
		const byte WRITE_CMD = 0x02;
		const byte ERASE_CMD = 0x03;
		const byte HLT_CMD = 0x04;
		const byte SUCCESS_CMD = 0x05;
		const byte FAIL_CMD = 0x06;
		const byte REPLY_CMD = 0x07;
		const byte SEL_CH = 0x08;
		const byte PWR_DWN = 0x09;
		const byte PWR_ON = 0x0A;
		const byte RX_OFF = 0x0C;
		const byte RX_ON = 0x0D;
		const byte LATCH_STATE = 0x0E;
		const byte FSK_STATE_CHG = 0x0F;

		public Comm()
		{
        }

		#region Low level functions --------------------------------
		private void SendDataPacket(SerialPort sport)
		{
			sport.Write(TxBuf, 0, 15);

			while (sport.BytesToWrite != 0) ;

		}

		private bool ReadResponse(SerialPort sport)
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
			sport.ReadTimeout = 500;

			int buflen = 0;

			try
			{
				while (loop)
				{
					byte_rcvd = sport.ReadByte();
					if (hdrok == true)
					{
						RxBuf[byteindx] = (byte)byte_rcvd;
						byteindx = byteindx + 1;

						if (byteindx > 3)
						{
							buflen = RxBuf[2];
							if (byteindx >= buflen)
							{
								loop = false;
							}
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

				return true;
			}
			catch (Exception ex)
            {
				return false;
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
		#endregion

		#region Commands --------------------------------

		public bool FSKStateChg(bool state)
        {
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);

			byte[] addr = new byte[4];
			byte[] data = new byte[4];

			addr[2] = Convert.ToByte(state);
			Prepare_packet(FSK_STATE_CHG, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] == SUCCESS_CMD)
			{
				sport.Close();
				return true;

			}
			else
			{
				sport.Close();
				return false;
			}			
        }

		public bool HltReq(ref byte[] status)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			
			byte[] addr = new byte[4];
			byte[] data = new byte[4];
			

			addr[2] = 0;
			Prepare_packet(HLT_CMD, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			if(false == ReadResponse(sport))
            {
				sport.Close();
				return false;
            }
			else if (RxBuf[3] == SUCCESS_CMD)
			{
				for (int i = 0; i < RxBuf[2]-8; i++)
                {
					status[i] = RxBuf[i+4];
				}				
				
				sport.Close();
				return true;

			}
			else
            {
				sport.Close(); 
				return false;
            }
		}

		public bool selch(byte chno)
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

			if (RxBuf[3] == SUCCESS_CMD)
			{
				sport.Close();
				return true;

			}
			else
			{
				sport.Close();
				return false;
			}
		}

		public bool TxEnable(bool Txstate, int bit)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] addr = new byte[4];
			byte[] data = new byte[4];

			if (bit == 0)
			{
				data[0] = 0;
			}
			else
			{
				data[0] = 1;
			}

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

			if (RxBuf[3] == SUCCESS_CMD)
			{
				sport.Close();
				return true;

			}
			else
			{
				sport.Close();
				return false;
			}
		}

		public bool SendLatchState(bool LatchState)
        {
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] addr = new byte[4];
			byte[] data = new byte[4];

			if (LatchState == false)
			{
				addr[2] = 0;
			}
			else
			{
				addr[2] = 1;
			}
			
			Prepare_packet(LATCH_STATE, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] == SUCCESS_CMD)
			{
				sport.Close();
				return true;

			}
			else
			{
				sport.Close();
				return false;
			}
		}
        #endregion




        #region Flash_Handlers -------------------------------------------
        public bool Read_bytes(int chno_add, ref byte[] replybytes)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);

			byte[] addr = new byte[4];			

			sport.Open();
			
			addr = BitConverter.GetBytes(chno_add);

			Prepare_packet(READ_CMD, addr, data);

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			if (false == ReadResponse(sport))
			{
				DateTime dateTime2 = DateTime.Now;
				sport.Close();
				return false;
			}
			else if (RxBuf[3] == REPLY_CMD)
			{
				replybytes[0] = RxBuf[7];
				replybytes[1] = RxBuf[8];
				replybytes[2] = RxBuf[9];
				replybytes[3] = RxBuf[10];
				
				sport.Close();
				return true;

			}
			else
			{
				sport.Close();
				return false;
			}

		}

		public bool EraseFlash(int addr_indx)
		{
			byte[] addr = new byte[4];

			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			addr = BitConverter.GetBytes(addr_indx);

			Prepare_packet(ERASE_CMD, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			if (false == ReadResponse(sport))
			{
				sport.Close();
				return false;
			}
			else if (RxBuf[3] == SUCCESS_CMD)
			{
				sport.Close();
				return true;

			}
			else
			{
				sport.Close();
				return false;
			}

		}

		public bool ProgFlash(ref int addr_indx, SYNTH_REG_t synth_reg, int length)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] replybytes = new byte[1000];
			byte[] addr = new byte[4];
			byte[] len = new byte[4];
			byte[] data = new byte[4];

			bool loop;
			int reg_indx;

			addr = BitConverter.GetBytes(addr_indx);
			len = BitConverter.GetBytes(length);

			data[0] = 0xAA;
			data[1] = 0xAA;
			data[2] = len[1];
			data[3] = len[0];

			/* Send header */
			Prepare_packet(WRITE_CMD, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			if ((false == ReadResponse(sport)) || (RxBuf[3] != SUCCESS_CMD))
			{
				sport.Close();
				return false;
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
				if (false == ReadResponse(sport))
				{
					sport.Close();
					return false;

				}
				else if (RxBuf[3] == SUCCESS_CMD)
				{
					reg_indx++;
					if (reg_indx >= length)
					{
						loop = false;
					}
					addr_indx += 4;
				}
			}

			sport.Close();
			return true;
		}

		public bool ProgBauddata(ref int addr_indx, byte[] bytedata, int length)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] replybytes = new byte[1000];
			byte[] addr = new byte[4];
			byte[] len = new byte[4];
			byte[] data = new byte[4];

			bool loop;
			int byte_indx;

			addr = BitConverter.GetBytes(addr_indx);
			len = BitConverter.GetBytes(length);

			data[0] = 0xAA;
			data[1] = 0xAA;
			data[2] = len[1];
			data[3] = len[0];

			/* Send header */
			Prepare_packet(WRITE_CMD, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			if ((false == ReadResponse(sport)) || (RxBuf[3] != SUCCESS_CMD))
			{
				sport.Close();
				return false;
			}

			loop = true;
			addr_indx = addr_indx + 4;
			byte_indx = 0;

			while (loop)
			{
				addr = BitConverter.GetBytes(addr_indx);

				data[0] = bytedata[byte_indx++];
				data[1] = bytedata[byte_indx++];
				data[2] = bytedata[byte_indx++];
				data[3] = bytedata[byte_indx++];

				Prepare_packet(WRITE_CMD, addr, data);

				/* send serial data */
				SendDataPacket(sport);

				/* Read reply */
				if (false == ReadResponse(sport))
				{
					sport.Close();
					return false;

				}
				else if (RxBuf[3] == SUCCESS_CMD)
				{				
					if (byte_indx >= length)
					{
						loop = false;
					}
					addr_indx += 4;
				}
			}

			sport.Close();
			return true;
		}

		#endregion

#if false
		#region ff
		public bool EraseFlash(int addr_indx)
		{
			byte[] addr = new byte[4];

			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			addr = BitConverter.GetBytes(addr_indx);

			Prepare_packet(ERASE_CMD, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			if (false == ReadResponse(sport))
			{
				sport.Close();
				return false;
			}
			else if(RxBuf[3] == SUCCESS_CMD)
			{
				sport.Close();
				return true;

			}
			else
			{
				sport.Close();
				return false;
			}

		}

		public bool ProgFlash(ref int addr_indx, SYNTH_REG_t synth_reg, int length)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] replybytes = new byte[1000];
			byte[] addr = new byte[4];
			byte[] len = new byte[4];
			byte[] data = new byte[4];

			bool loop;
			int reg_indx;

			addr = BitConverter.GetBytes(addr_indx);
			len = BitConverter.GetBytes(length);

			data[0] = 0xAA;
			data[1] = 0xAA;
			data[2] = len[1];
			data[3] = len[0];

			/* Send header */
			Prepare_packet(WRITE_CMD, addr, data);

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			if((false == ReadResponse(sport)) || (RxBuf[3] != SUCCESS_CMD))
			{
				sport.Close();
				return false;
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
				if(false == ReadResponse(sport))
                {
					sport.Close();
					return false;

                }
				else if (RxBuf[3] == SUCCESS_CMD)
				{
					reg_indx++;
					if (reg_indx >= length)
					{
						loop = false;
					}
					addr_indx += 4;
				}
			}

			sport.Close();
			return true;
		}


		#endregion






        

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

			if (RxBuf[3] == SUCCESS_CMD)
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

		


		public int TstMode(bool Tststate)
		{
			SerialPort sport = new SerialPort(Global.PortName, Global.Baudrate);
			byte[] addr = new byte[4];
			byte[] data = new byte[4];

			if (Tststate == true)
			{
				Prepare_packet(TSTMODE_ON, addr, data);
			}
			else
			{
				Prepare_packet(TSTMODE_OFF, addr, data);
			}

			sport.Open();

			/* send serial data */
			SendDataPacket(sport);

			/* Read reply */
			ReadResponse(sport);

			if (RxBuf[3] == SUCCESS_CMD)
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

			if (RxBuf[3] != SUCCESS_CMD)
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

				if (RxBuf[3] == SUCCESS_CMD)
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
#endif
	}
}


