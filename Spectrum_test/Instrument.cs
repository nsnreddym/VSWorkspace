using System;
using VISA2_2;

namespace Equipment
{
	/// <summary>
	/// The base class for all test equipment.
	/// Provides basic communication functionality.
	/// </summary>
	public class Instrument
	{
		protected uint defRM = new uint(), vi = new uint();

		//public bool ConnState;
		
		#region Constructor and Destructor
		public Instrument()
		{
			vi = 0;
			//ConnState = false;
		}

		~Instrument()
		{
			if(vi != 0)
			{
				VISA.viClose(vi);
				vi = 0;
				VISA.viClose(defRM);
			}
		}
	#endregion	
		
		#region Properties
		/// <summary>
		/// The address property uses resuorce identifier
		///	strings such as "GPIB0::07::INSTR"
		/// </summary>
		public virtual string Address
		{
			get
			{
				string addr = new String(' ', 255);
				
				VISA.viGetAttribute(this.vi, VISA.VI_ATTR_RSRC_NAME, ref addr);
				addr.Trim();
				return addr;
			}
			set
			{
				if(this.vi != 0)
				{
					VISA.viClose(this.vi);
					vi = 0;
					VISA.viClose(defRM);
					defRM = 0;
				}
				VISA.viOpenDefaultRM(ref defRM);
				VISA.viOpen(defRM, value, VISA.VI_NULL, 2000, ref this.vi);
				this.Timeout = 2000;
			}
		}
		
		/// <summary>
		/// Timeout accepts the timeout value in milliseconds.
		/// </summary>
		public virtual int Timeout
		{
			get
			{
				uint val = new uint();
				VISA.viGetAttribute(this.vi, VISA.VI_ATTR_TMO_VALUE, ref val);
				return (int)val;
			}
			set
			{
				VISA.viSetAttribute(this.vi, VISA.VI_ATTR_TMO_VALUE, value);
			}
		}
		#endregion
		
		#region Methods	
		/// <summary>
		/// Set the instrument to the factory default.
		/// </summary>
		public virtual void Reset()
		{
			uint retcnt = new uint();
			VISA.viWrite(vi, "*RST\n", 5, ref retcnt);
		}
		

		public virtual void release()
        {
			if (this.vi != 0)
			{
				VISA.viClose(this.vi);
				vi = 0;
				VISA.viClose(defRM);
				defRM = 0;
			}
		}
		
		/// <summary>
		/// Write uses the viWrite function and adds the '\n' to the cmd
		/// </summary>
		/// <param name="cmd"></param>
		public virtual void Write(string cmd)
		{
			uint retcnt = new uint();
			VISA.viWrite(this.vi, cmd + '\n', (uint)(cmd.Length + 1), ref retcnt);
		}
		

		/// <summary>
		/// Query uses the viWrite funtion followed by viRead not viQueryf.
		/// Query appends the '\n' to the written string
		/// Query trims the returned string to 1 less than retcnt.
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns></returns>
		public virtual string Query(string cmd)
		{
			uint retcnt = new uint(), cnt = new uint();
			cnt = 1024 * 64;
			string retstr = new string(' ', (int)cnt);
			
			VISA.viWrite(this.vi, cmd + '\n', (uint)(cmd.Length + 1), ref retcnt);
			retcnt = 0;
			try
			{
				VISA.viRead(this.vi, ref retstr, cnt, ref retcnt);
			}
			catch
			{
				retcnt = 0;
			}
			
			if(retcnt > 0)
				return retstr.Substring(0, (int)(retcnt - 1));
			else
				return "";
		}
		#endregion
	
	};
}
