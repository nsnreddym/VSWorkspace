using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using FileTransactions;
using Globalclass;

namespace GraphClass
{
    //Test for git
    public class Graph
    {
        #region constants        
        public const int MaxSeries = 6;        
        #endregion

        #region datatypes
        public enum ChartType
        {
            Polar,
            Rectangle
        }

        public enum GraphErrors
        {
            NOERROR = 0,
            EXCEED_MAXSERIES = -1
        }

        public struct ChartParameters
        {
            public double[] x;
            public double[] y;
            public string title;
            public int noPoints;
            public string Freq;
            public string Pol;
            public Color color;
        }

        public struct AnalysisData
        {
            public string Freq;
            public string Pol;
            public string Max;
            public string Min;
            public string BW3dB;
            public Color color;

        }
        #endregion

        #region Properties
        public ChartType chartType;
        public GraphErrors graphErrors;
        public ChartParameters[] chartParameters = new ChartParameters[MaxSeries];
        public int chartNoSeries;

        private Chart chart;
        private Series[] datapoints = new Series[MaxSeries];
        private int seriesCount;
        //private int currentseriesIndex;
        private readonly Color[] ChartColors = new Color[MaxSeries];
        #endregion

        #region Constructor and destructor
        public Graph(Chart chart1)
        {
            chart = chart1;
            chartType = ChartType.Polar;
            seriesCount = 0;

            //Chart area
            ChartArea ca = chart.ChartAreas[0];
            Axis ax = ca.AxisX;
            Axis ay = ca.AxisY;

            ax.Minimum = -180;
            ax.Maximum = 180;
            ax.Interval = 15;   // 15° interval
            ax.Crossing = 0;    // start the segments at the top!

            ay.Minimum = -100;
            ay.Maximum = -20;

            //Defining colors
            int k;
            for (int i = 0; i < MaxSeries; i++)
            {
                k = i + 1;
                ChartColors[i] = Color.FromArgb(((k / 4) % 2) * 255, ((k / 2) % 2) * 255, (k % 2) * 255);
                chartParameters[i].color = ChartColors[i];
            }

        }
        #endregion

        #region Graph Methods
        private GraphErrors Addaxis(string Charttitle)
        {
            if (seriesCount < MaxSeries)
            {
                //Add new series to chart
                chart.Series.Add(Charttitle);

                //Allot data
                datapoints[seriesCount] = chart.Series[seriesCount];
                datapoints[seriesCount].BorderWidth = 2;
                if (chartType == ChartType.Polar)
                {
                    datapoints[seriesCount].ChartType = SeriesChartType.Polar;
                }
                else
                {
                    datapoints[seriesCount].ChartType = SeriesChartType.Line;
                }

                seriesCount++;
                return GraphErrors.NOERROR;
            }
            return GraphErrors.EXCEED_MAXSERIES;
        }

        public void ResetGraph()
        {
            chart.Series.Clear();
            //chartType = ChartType.Polar;
            seriesCount = 0;
        }        

        public void Update_y_Axis(double Min, double Max, double Interval)
        {
            ChartArea ca = chart.ChartAreas[0];
            Axis ay = ca.AxisY;

            ay.Minimum = Min;
            ay.Maximum = Max;
            ay.Interval = Interval;
        }

        public void ChangeGraphType()
        {
            //
            chart.SuspendLayout();

            if (seriesCount != 0)
            {
                if (chartType == ChartType.Rectangle)
                {
                    chartType = ChartType.Polar;
                }
                else
                {
                    chartType = ChartType.Rectangle;
                }

                for (int i = 0; i < seriesCount; i++)
                {
                    if (chartType == ChartType.Rectangle)
                    {
                        datapoints[i].ChartType = SeriesChartType.Line;
                    }
                    else
                    {
                        datapoints[i].ChartType = SeriesChartType.Polar;
                    }
                }

            }

            if (chartNoSeries > 0)
            {
                //Reset all graphs
                ResetGraph();

                //Create Graph
                CreateGraphFromData(chartNoSeries);
            }

            chart.ResumeLayout();
        }

        public GraphErrors CreateGraphFromData(int noseries)
        {
            GraphErrors return_val;

            return_val = GraphErrors.NOERROR;

            for (int j = 0; j < noseries; j++)
            {
                //Add new data series
                return_val = Addaxis(chartParameters[j].title);

                //Color                
                datapoints[j].Color = chartParameters[j].color;

                if (return_val == GraphErrors.NOERROR)
                {
                    for (int i = 0; i < chartParameters[j].noPoints; i++)
                    {
                        if (chartType == ChartType.Rectangle)
                        {
                            datapoints[j].Points.AddXY(chartParameters[j].x[i] + chart.ChartAreas[0].AxisX.Minimum, chartParameters[j].y[i]);
                        }
                        else
                        {
                            datapoints[j].Points.AddXY(chartParameters[j].x[i], chartParameters[j].y[i]);

                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return return_val;

        }

        public void UpdateGraphFromData()
        {
            datapoints[0].Points.Clear();

            datapoints[0].Color = chartParameters[0].color;

            for (int i = 0; i < chartParameters[0].noPoints; i++)
            {
                if (chartType == ChartType.Rectangle)
                {
                    datapoints[0].Points.AddXY(chartParameters[0].x[i] + chart.ChartAreas[0].AxisX.Minimum, chartParameters[0].y[i]);
                }
                else
                {
                    datapoints[0].Points.AddXY(chartParameters[0].x[i], chartParameters[0].y[i]);

                }
                
            }
        
        }

        #endregion

        #region Data Methods
        public void Resetusrdata()
        {
            ResetGraph();
            chartNoSeries = 0;
        }

        public void StartGraph(string title)
        {
            //Reset all graphs
            ResetGraph();

            //Add axis
            Addaxis(title);

            //Ready data points
            chartParameters[0].title = title;
            chartParameters[0].Freq = Globals.Freq;
            chartParameters[0].Pol = Globals.POL;
            chartParameters[0].noPoints = Convert.ToInt32(Globals.SWP);
            chartParameters[0].x = new double[chartParameters[0].noPoints];
            chartParameters[0].y = new double[chartParameters[0].noPoints];

            seriesCount = 1;
        }

        public GraphErrors LoadGraph()
        {
            GraphErrors return_val;
            int noseries;

            Filehandlings loadfile = new Filehandlings();

            //Read Data
            noseries = loadfile.ReadData(chartParameters, chartNoSeries);
            chartNoSeries = noseries;

            if (noseries == -1)
            {
                return GraphErrors.EXCEED_MAXSERIES;
            }

            //Reset all graphs
            ResetGraph();

            //Create Graph
            return_val = CreateGraphFromData(chartNoSeries);

            return return_val;

        }
        
        public void SaveGraph()
        {
            Filehandlings savefile = new Filehandlings();

            savefile.SaveData(chartParameters, seriesCount);
        }

        public void RefreshGraph(string data)
        {
            double x;
            double vx;
            ChartArea ca = chart.ChartAreas[0];
            Axis ax = ca.AxisX;

            int points;
            double[] digits = new double[Convert.ToInt32(Globals.SWP)];
            chartNoSeries = 0;

            digits = data.Split(',').Select(r => Convert.ToDouble(r)).ToArray();

            points = chartParameters[0].noPoints;

            for (int i = 0; i < points; i++)
            {
                //Calc step
                vx = i * 360 / (points);

                chartParameters[0].x[i] = vx;
                chartParameters[0].y[i] = digits[i];
            }

            //Update Graph
            //CreateGraphFromData(1);
            chartParameters[0].color = ChartColors[0];
            chartNoSeries = 1;
            UpdateGraphFromData();
        }

        private int FindMax(double[] ydata, int points)
        {
            int i;
            double max;
            int indx1;
            max = ydata[0];
            indx1 = 0;

            //Finding Max
            for (i = 0; i < points - 1; i++)
            {
                if (ydata[i] > max)
                {
                    max = ydata[i];
                    indx1 = i;
                }
            }

            return indx1;
        }

        private double Find3dB(double[] ydata, int points, double Max, int Maxindx)
        {
            int i;
            double angle;
            int PdB3Indx;
            int NdB3Indx;
            int indx1;

            indx1 = Maxindx;
            PdB3Indx = indx1;
            angle = 0;

            //Finding 3dB point +ve side
            for (i = 0; i < points; i++)
            {
                if (ydata[indx1] <= (Max - 3))
                {
                    PdB3Indx = indx1;
                    break;
                }
                else
                {
                    indx1++;
                    angle = angle + 1;
                    if (indx1 >= points)
                    {
                        indx1 = 0;
                    }
                }
            }
            if (i == points)
            {
                angle = 3600;
            }

            indx1 = Maxindx;
            NdB3Indx = indx1;

            //Finding 3dB point -ve side
            for (i = 0; i < points; i++)
            {
                if (ydata[indx1] <= (Max - 3))
                {
                    NdB3Indx = indx1;
                    break;
                }
                else
                {
                    indx1--;
                    angle = angle + 1;
                    if (indx1 < 0)
                    {
                        indx1 = points - 1;
                    }
                }
            }
            if (i == points)
            {
                angle = 3600;
            }

            return angle;
        }

        public void AnalyzeGraph(AnalysisData[] analysisdata)
        {
            double MaxValue;
            int MaxValIndx;
            double dB3angle;

            for (int i = 0; i < chartNoSeries; i++)
            {                                
                analysisdata[i].Freq = chartParameters[i].Freq;
                analysisdata[i].Pol = chartParameters[i].Pol;
                analysisdata[i].color = chartParameters[i].color;

                MaxValIndx = FindMax(chartParameters[i].y, chartParameters[i].noPoints);
                MaxValue = chartParameters[i].y[MaxValIndx];
                dB3angle = Find3dB(chartParameters[i].y, chartParameters[i].noPoints, MaxValue, MaxValIndx);
                dB3angle = dB3angle * 360.0 / (chartParameters[i].noPoints);

                analysisdata[i].Max = MaxValue.ToString();
                analysisdata[i].BW3dB = dB3angle.ToString();

            }
        }

        #endregion

    }
}
