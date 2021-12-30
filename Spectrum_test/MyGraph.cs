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
        private int currentseriesIndex;
        private readonly Color[] ChartColors = new Color[MaxSeries];
        #endregion

        #region Constructor and destructor
        public Graph(Chart chart1)
        {
            chart = chart1;
            chartType = ChartType.Polar;
            seriesCount = 0;
            currentseriesIndex = -1;

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
                datapoints[seriesCount].Color = ChartColors[seriesCount];
                if (chartType == ChartType.Polar)
                {
                    datapoints[seriesCount].ChartType = SeriesChartType.Polar;
                }
                else
                {
                    datapoints[seriesCount].ChartType = SeriesChartType.Line;
                }

                seriesCount++;
                currentseriesIndex = seriesCount - 1;
                return GraphErrors.NOERROR;
            }
            return GraphErrors.EXCEED_MAXSERIES;
        }

        public void ResetGraph()
        {
            chart.Series.Clear();
            //chartType = ChartType.Polar;
            seriesCount = 0;
            currentseriesIndex = -1;
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

                if (return_val == GraphErrors.NOERROR)
                {
                    for (int i = 0; i < chartParameters[j].noPoints; i++)
                    {
                        if (chartType == ChartType.Rectangle)
                        {
                            datapoints[currentseriesIndex].Points.AddXY(chartParameters[j].x[i] + chart.ChartAreas[0].AxisX.Minimum, chartParameters[j].y[i]);
                        }
                        else
                        {
                            datapoints[currentseriesIndex].Points.AddXY(chartParameters[j].x[i], chartParameters[j].y[i]);

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

        public void UpdateGraphFromData(int indx)
        {
            datapoints[currentseriesIndex].Points.Clear();

            for (int i = 0; i < chartParameters[indx].noPoints; i++)
            {
                if (chartType == ChartType.Rectangle)
                {
                    datapoints[currentseriesIndex].Points.AddXY(chartParameters[indx].x[i] + chart.ChartAreas[0].AxisX.Minimum, chartParameters[indx].y[i]);
                }
                else
                {
                    datapoints[currentseriesIndex].Points.AddXY(chartParameters[indx].x[i], chartParameters[indx].y[i]);

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
            currentseriesIndex = 0;
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
            chartNoSeries = 1;
            UpdateGraphFromData(currentseriesIndex);
        }

        #endregion

    }
}
