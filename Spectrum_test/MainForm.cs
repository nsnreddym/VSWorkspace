using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using Equipment;
using FileTransactions;
using Globalclass;
using GraphClass;

namespace Spectrum_test
{
    public partial class MainForm : Form
    {
        #region Properties
        Graph graph;
        int strtindx;


        Instrument Spectrum;
        bool Connectstate;

        bool strtstate;

        #endregion

        #region Constructor and Destructor
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods
        private void ProgramDevice()
        {
            Spectrum.Address = "TCPIP0::" + Globals.Devadd + "::inst0::INSTR";

            Spectrum.Reset();
        }

        private void Update_config()
        {
            Filehandlings sf = new Filehandlings();
            string path = @".\Settings.ini";
            if (!File.Exists(path))
            {
                sf.Settings_default();
            }
            sf.Settings_Read();           

            ConfigDevice();
        }

        private void ConfigDevice()
        {
            Spectrum.Write("*CLS");

            //SeGlobals. frequency
            Spectrum.Write("FREQUENCY:CENTER " + Globals.Freq + Globals.Freq_unit);

            Spectrum.Write("FREQUENCY:SPAN " + Globals.Span + Globals.Span_unit);

            //RBW
            Spectrum.Write("BAND:RES " + Globals.RBW + Globals.RBW_unit);
            Spectrum.Write("BAND:VID:AUTO OFF");

            Spectrum.Write("BAND:VID " + Globals.VBW + Globals.VBW_unit);
            //Spectrum.Write("BAND:VID:RAT " + tVBW);


            //Sweep time
            Spectrum.Write("SWE:TIME " + Globals.SWT + Globals.SWT_unit);
            //MyConsole = Spectrum.Query("SYST:ERR?");

            Spectrum.Write("DISP:TRAC:Y:RLEV " + Globals.REF_unit + "dBm");

            Spectrum.Write("SWE:POIN " + Globals.SWP);
            //MyConsole = Spectrum.Query("SYST:ERR?");

            Spectrum.Write("INIT:CONT OFF");
        }
        #endregion

        #region Events        

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //Read settings
            Filehandlings sf = new Filehandlings();
            string path = @".\Settings.ini";
            if (!File.Exists(sf.SettinsPath))
            {
                sf.Settings_default();
            }
            sf.Settings_Read();
            Globals.POL = "H/H";

            //Initialize Graph
            graph = new Graph(chart1);
            strtindx = 0;

            //Initialize axis
            Globals.YAxismin = -100;
            Globals.YAxismax = -20;
            Globals.YAxisInterval = 10;

            //Connection
            Connectstate = false;
            tsConnect.Text = "Connect";
            tsConnect.Image = global::Spectrum_test.Properties.Resources.connect_icon;
            ssConnect.Text = "Status : DisConnected";
            ssConnect.Image = global::Spectrum_test.Properties.Resources.ButtonRed;

            //Start
            tsStart_Stop.Enabled = false;
            tsStart_Stop.Text = "Start";
            tsStart_Stop.Image = global::Spectrum_test.Properties.Resources.start;
            strtstate = false;

            //cbFreq
            cbFreq.SelectedIndex = 0;
            cbPol.SelectedIndex = 0;
        }

        private void tsAnalyze_Click(object sender, EventArgs e)
        {
        }

        private void tsChart_Click(object sender, EventArgs e)
        {
            graph.ChangeGraphType();

            if (graph.chartType == Graph.ChartType.Polar)
            {
                tsChart.Image = global::Spectrum_test.Properties.Resources.chart;
                tsChart.Text = "Rectangle";
            }
            else
            {
                tsChart.Image = global::Spectrum_test.Properties.Resources.Polar;
                tsChart.Text = "Polar";
            }

            //Graph.RefreshGraph(digits, strtindx, points);
        }

        private void tsUpload_Click(object sender, EventArgs e)
        {
            Graph.GraphErrors status;

            status = graph.LoadGraph();

            if (status != Graph.GraphErrors.NOERROR)
            {
                MessageBox.Show("Unable to Add graph" + Environment.NewLine + "Message: " + status.ToString());
            }
        }

        private void tsAxis_Click(object sender, EventArgs e)
        {
            Axis axis = new Axis();
            axis.ShowDialog();
            graph.Update_y_Axis(Globals.YAxismin, Globals.YAxismax, Globals.YAxisInterval);
        }

        private void tsSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();

            settings.ShowDialog();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            graph.SaveGraph();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            graph.Resetusrdata();
        }

        private void tsConnect_Click(object sender, EventArgs e)
        {
            //Check for Connection state
            if (Connectstate == false)
            {
                Spectrum = new Instrument();

                tsConnect.Text = "DisConnect";
                tsConnect.Image = global::Spectrum_test.Properties.Resources.disconnect_icon;
                ssConnect.Text = "Status : Connected";
                ssConnect.Image = global::Spectrum_test.Properties.Resources.ButtonGreen;
                ProgramDevice();
                Update_config();
                Connectstate = true;
                tsSettings.Enabled = false;
                tsStart_Stop.Enabled = true;
                tsStart_Stop.Text = "Start";
                tsStart_Stop.Image = global::Spectrum_test.Properties.Resources.start;
                strtstate = false;
            }
            else
            {
                timer1.Enabled = false;
                Spectrum.release();
                tsConnect.Text = "Connect";
                tsConnect.Image = global::Spectrum_test.Properties.Resources.connect_icon;
                ssConnect.Text = "Status : DisConnected";
                ssConnect.Image = global::Spectrum_test.Properties.Resources.ButtonRed;
                Connectstate = false;
                tsSettings.Enabled = true;
                tsStart_Stop.Enabled = false;
                tsStart_Stop.Text = "Start";
                tsStart_Stop.Image = global::Spectrum_test.Properties.Resources.start;
                strtstate = false;
            }
        }

        private void tsStart_Stop_Click(object sender, EventArgs e)
        {
            if (strtstate == false)
            {
                //Interlock
                tsAnalyze.Enabled = false;
                tsUpload.Enabled = false;
                tsSave.Enabled = false;
                tsPrint.Enabled = false;
                Fbox.Enabled = false;

                //Start Graph
                graph.StartGraph(Globals.Freq + " " + Globals.Freq_unit + "(" + Globals.POL + ")");

                //Start button as Pause
                tsStart_Stop.Text = "Stop";
                tsStart_Stop.Image = global::Spectrum_test.Properties.Resources.Pause;
                strtstate = true;

                //Set frequency
                Spectrum.Write("FREQUENCY:CENTER " + Globals.Freq + Globals.Freq_unit);


                //Single sweep mode
                Spectrum.Write("INIT:CONT OFF");
                Spectrum.Write("INIT");

                //Start timer
                timer1.Enabled = true;
            }
            else
            {
                //Stop timer
                timer1.Enabled = false;

                //Start button as start
                tsStart_Stop.Text = "Start";
                tsStart_Stop.Image = global::Spectrum_test.Properties.Resources.start;
                strtstate = false;

                //Stop single sweep mode
                Spectrum.Write("INIT:CONT OFF");
                
                //Interlock
                tsAnalyze.Enabled = true;
                tsUpload.Enabled = true;
                tsSave.Enabled = true;
                tsPrint.Enabled = true;
                Fbox.Enabled = true;
            }
        }

        private void timer_routine(object sender, EventArgs e)
        {
            string data;

            //Get data from device
            data = Spectrum.Query("TRAC? TRACE1");

            //Load in graph
            graph.RefreshGraph(data);         

        }

        private void bFLoad_Click(object sender, EventArgs e)
        {
            Globals.Freq = tFreq.Text;
            Globals.Freq_unit = cbFreq.Text;
            Globals.POL = cbPol.Text;
        }
        
        private void tsPrint_Click(object sender, EventArgs e)
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            

            if (MyPrintDialog.ShowDialog() == DialogResult.OK)
            {
                MyPrintDialog.Document = MyPrintDocument;
                PrinterSettings ps = new PrinterSettings();

                MyPrintDocument.PrinterSettings = ps;
                IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
                PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4);

                MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintPage);
                MyPrintDocument.DefaultPageSettings.Landscape = true;                
                MyPrintDocument.DefaultPageSettings.PaperSize = sizeA4;
                System.Drawing.Printing.Margins margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);

                MyPrintDocument.Print();
            }

            MyPrintDocument.Dispose();
        }

        private void PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Get page size
            PaperSize ps = new PaperSize();
            ps = e.PageSettings.PaperSize;

            //Create Bitmap
            Bitmap MyChartPanel = new Bitmap(UserArea.Panel1.Width, UserArea.Panel1.Height);
            UserArea.Panel1.DrawToBitmap(MyChartPanel, new Rectangle(0, 0, UserArea.Panel1.Width, UserArea.Panel1.Height));

            //Adjust bitmap size
            System.Drawing.Rectangle m = e.MarginBounds;
            m.X = 0;
            m.Y = 0;
            m.Width = ps.Height;
            m.Height = (int)((double)ps.Height * ((double)UserArea.Panel1.Height/ UserArea.Panel1.Width));

            //resize bitmap
            Bitmap MyChartPanel2 = new Bitmap(MyChartPanel, new Size(m.Width, m.Height));
            
            e.Graphics.DrawImage(MyChartPanel2, m);
            MyChartPanel.Dispose();
        }

        #endregion
    }
}

