using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using GraphClass;
using Globalclass;


namespace FileTransactions
{
    public class Filehandlings
    {
        public readonly string SettinsPath = @".\Settings.ini";        

        #region Constructor and destructor

        public Filehandlings()
        {

        }

        #endregion

        #region Graph_handlings

        public int ReadData(Graph.ChartParameters[] chp, int initSeries)
        {
            System.Windows.Forms.OpenFileDialog loaddataDialog;
            loaddataDialog = new System.Windows.Forms.OpenFileDialog();
            loaddataDialog.Filter = "data files (*.dat)|*.dat";
            loaddataDialog.ShowDialog();

            string path = loaddataDialog.FileName;
            StreamReader sw;
            int index;
            int i;
            string str;
            int no_series;
            sw = File.OpenText(path);

            //Read no of series
            str = sw.ReadLine();
            index = str.IndexOf(':');
            no_series = Convert.ToInt32(str.Substring(index + 1, str.Length - index - 1));

            if((initSeries + no_series) >= Graph.MaxSeries)
            {                
                return -1;
            }

            for (int j = 0; j < no_series; j++)
            {
                //Read title
                str = sw.ReadLine();
                index = str.IndexOf(':');
                chp[j + initSeries].title = str.Substring(index + 1, str.Length - index - 1);

                //Read Frequency
                str = sw.ReadLine();
                index = str.IndexOf(':');
                chp[j + initSeries].Freq = str.Substring(index + 1, str.Length - index - 1);

                //Read Polarity
                str = sw.ReadLine();
                index = str.IndexOf(':');
                chp[j + initSeries].Pol = str.Substring(index + 1, str.Length - index - 1);

                //Read Series length
                str = sw.ReadLine();
                index = str.IndexOf(':');
                chp[j + initSeries].noPoints = Convert.ToInt32(str.Substring(index + 1, str.Length - index - 1));

                //Allot memory
                chp[j + initSeries].x = new double[chp[j].noPoints];
                chp[j + initSeries].y = new double[chp[j].noPoints];

                //Read data
                for (i = 0; i < chp[j + initSeries].noPoints; i++)
                {
                    str = sw.ReadLine();
                    index = str.IndexOf(',');
                    
                    chp[j + initSeries].x[i] = Convert.ToDouble(str.Substring(0, index));
                    chp[j + initSeries].y[i] = Convert.ToDouble(str.Substring(index + 1, str.Length - index - 1));
                }

            }
            sw.Close();

            return no_series + initSeries;

        }

#if true
        public void SaveData(Graph.ChartParameters[] chp, int seriescount)
        {
            int k;

            System.Windows.Forms.SaveFileDialog savedataDialog;
            savedataDialog = new System.Windows.Forms.SaveFileDialog();
            savedataDialog.Filter = "data files (*.dat)|*.dat";
            savedataDialog.ShowDialog();
            
            string path = savedataDialog.FileName;
            StreamWriter sw2;
            sw2 = File.CreateText(path);

            //No of Graphs
            sw2.WriteLine("DataSeries Count:" + seriescount.ToString());

            for (int j = 0; j < seriescount; j++)
            {
                //Write title
                sw2.WriteLine("title:"+chp[j].title);

                //Write frequency
                sw2.WriteLine("Frequency:" + chp[j].Freq);

                //Write Pol
                sw2.WriteLine("Polarity:" + chp[j].Pol);

                //Write Series length
                sw2.WriteLine("DataSeries Length:" + chp[j].noPoints.ToString());

                //Write data
                for (int i = 0; i < chp[j].noPoints; i++)
                {
                    sw2.WriteLine(chp[j].x[i].ToString() + "," + chp[j].y[i].ToString());
                }
            }
            sw2.Close();
        }

#endif
#endregion

        #region Settings_handlings
        public void Settings_default()
        {
            StreamWriter sw2;
            sw2 = File.CreateText(SettinsPath);
            sw2.WriteLine("Device IP :192.168.1.1");
            sw2.WriteLine("RBW :3 KHz");
            sw2.WriteLine("VBW :30 Hz");
            sw2.WriteLine("FREQUENCY :416.8 MHz");
            sw2.WriteLine("SPAN :0 Hz");
            sw2.WriteLine("SWEEP TIME :60 s");
            sw2.WriteLine("SWEEP POINTS :501");
            sw2.WriteLine("REF :-10 dBm");
            sw2.Close();
        }

        public void Settings_Read()
        {            
            StreamReader sw;
            int index;
            int index2;
            string str;
            sw = File.OpenText(SettinsPath);
            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.Length-index-1;
            Globals.Devadd = str.Substring(index+1, index2);

            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.IndexOf(' ',index);
            Globals.RBW = str.Substring(index+1,index2-index-1);
            Globals.RBW_unit = str.Substring(index2 + 1, str.Length - index2 - 1);

            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.IndexOf(' ',index);
            Globals.VBW = str.Substring(index+1,index2-index-1);
            Globals.VBW_unit = str.Substring(index2 + 1, str.Length - index2 - 1);

            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.IndexOf(' ',index);
            Globals.Freq = str.Substring(index+1,index2-index-1);
            Globals.Freq_unit = str.Substring(index2 + 1, str.Length - index2 - 1);

            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.IndexOf(' ',index);
            Globals.Span = str.Substring(index+1,index2-index-1);
            Globals.Span_unit = str.Substring(index2 + 1, str.Length - index2 - 1);

            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.IndexOf(' ',index);
            Globals.SWT = str.Substring(index+1,index2-index-1);
            Globals.SWT_unit = str.Substring(index2 + 1, str.Length - index2 - 1);

            str = sw.ReadLine();
            index = str.IndexOf(':');
            Globals.SWP = str.Substring(index + 1, str.Length - index - 1);

            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.IndexOf(' ',index);
            Globals.REF = str.Substring(index+1,index2-index-1);
            Globals.REF_unit = str.Substring(index2 + 1, str.Length - index2 - 1);

            sw.Close();
        }

        public void Settings_write()
        {
            StreamWriter sw;
            sw = File.CreateText(SettinsPath);
            sw.WriteLine("Device IP :" + Globals.Devadd);
            sw.WriteLine("RBW :" + Globals.RBW + " " + Globals.RBW_unit);
            sw.WriteLine("VBW :" + Globals.VBW + " " + Globals.VBW_unit);
            sw.WriteLine("FREQUENCY :" + Globals.Freq + " " + Globals.Freq_unit);
            sw.WriteLine("SPAN :" + Globals.Span + " " + Globals.Span_unit);
            sw.WriteLine("SWEEP TIME :" + Globals.SWT + " " + Globals.SWT_unit);
            sw.WriteLine("SWEEP POINTS :" + Globals.SWP);
            sw.WriteLine("REF :" + Globals.REF + " " + "dBm");
            sw.Close();         

        }

#endregion
    }
}
