using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace clustering
{
    public partial class Form_cmp : Form
    {
        public Form_cmp()
        {
            InitializeComponent();
        }
        /// <summary>
       
        /// </summary>
        private void InitChart(int iSeriesNum, Data data)
        {
            
            this.chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.chart1.ChartAreas.Add(chartArea1);
            
            this.chart1.Series.Clear();
            for (int i = 0; i < iSeriesNum; i++)
            {
                Series series1 = new Series(i.ToString());
                series1.ChartArea = "C1";
                this.chart1.Series.Add(series1);
                this.chart1.Series[i].Color = data.GetRandomColor();
                this.chart1.Series[i].ChartType = SeriesChartType.FastLine;
            }

            
            this.chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            this.chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            this.chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            
            this.chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
           
            this.chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            this.chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = double.NaN;
            this.chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 20;
            int cowNum = data.timeSpan.Count;
            if (cowNum < 1)
                cowNum = 100;
            this.chart1.ChartAreas[this.chart1.ChartAreas.Count - 1].AxisX.Minimum = (double)0;
            this.chart1.ChartAreas[this.chart1.ChartAreas.Count - 1].AxisX.Maximum = (double)(cowNum + 100);
            this.chart1.ChartAreas[this.chart1.ChartAreas.Count - 1].AxisY.Minimum = (double)0;
            this.chart1.ChartAreas[this.chart1.ChartAreas.Count - 1].AxisY.Maximum = (double)(cowNum + 100);
            this.chart1.ChartAreas[this.chart1.ChartAreas.Count - 1].AxisX.Title = "polt";
            this.chart1.ChartAreas[this.chart1.ChartAreas.Count - 1].AxisY.Title = "time";
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
           
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("S01");
            this.chart1.Titles[0].Text = "plot time complexity";
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

        }


        public void updateChart(Data data)
        {
            int seriesNum = 6;
            InitChart(seriesNum, data);

            for (int i = 0; i < data.timeSpan.Count; i++)
            {
                this.chart1.Series[this.chart1.Series.Count - seriesNum].Points.AddXY(i, i);
                this.chart1.Series[this.chart1.Series.Count - seriesNum + 1].Points.AddXY(i, getN2(i));
                this.chart1.Series[this.chart1.Series.Count - seriesNum + 2].Points.AddXY(i, getN3(i));
                this.chart1.Series[this.chart1.Series.Count - seriesNum + 3].Points.AddXY(i, 1);
                
            }


        }
        public double getln(double x)
        {
            return (double)Math.Log(x);
        }

        public double getSqrt(double x)
        {
            return (double)Math.Sqrt(x);
        }

        /// <summary>
        /// y = x^2
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public float getN2(float x)
        {
            return x * x;
        }

        /// <summary>
        /// y = x^3
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public float getN3(float x)
        {
            return x * x * x;
        }
    }
}