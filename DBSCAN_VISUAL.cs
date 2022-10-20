using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace clustering
{
    public partial class DBSCAN_visual : Form
    {
        private Writer writer ;
        private Data data;
        private List<List<Point>> result;

        Color[] colors = {
            Color.Black,Color.Red, Color.Blue,Color.Purple, Color.Orange,Color.Gray, Color.Green, Color.Pink,Color.Brown,Color.Yellow,
            Color.HotPink,Color.DarkGoldenrod,Color.Aqua,Color.Fuchsia,Color.DarkBlue,Color.Bisque,Color.DarkRed,
            Color.DarkOrange, Color.Coral,Color.DarkCyan,  Color.Honeydew, Color.Salmon,Color.YellowGreen,Color.DarkTurquoise,
            Color.Beige,Color.Chocolate, Color.Cyan,Color.DimGray,Color.DarkOliveGreen,Color.MistyRose,Color.Navy,Color.Plum,Color.Violet,
            Color.Teal,Color.LawnGreen,Color.LemonChiffon,Color.Lavender,Color.Gold,Color.CornflowerBlue,Color.Firebrick,Color.ForestGreen,
            Color.DodgerBlue,Color.BurlyWood,Color.Chartreuse,Color.AliceBlue,Color.BlanchedAlmond,Color.Crimson,Color.SaddleBrown,
            Color.DarkMagenta,Color.DarkGray,Color.Cornsilk,

            Color.AliceBlue

 ,Color.LightSalmon


,Color.AntiqueWhite

 ,Color.LightSeaGreen

,Color.Aqua

 ,Color.LightSkyBlue

,Color.Aquamarine

 ,Color.LightSlateGray

,Color.Azure

 ,Color.LightSteelBlue

,Color.Beige

 ,Color.LightYellow

,Color.Bisque

 ,Color.Lime

,Color.Black

 ,Color.LimeGreen

,Color.BlanchedAlmond

 ,Color.Linen

,Color.Blue

 ,Color.Magenta

,Color.BlueViolet

 ,Color.Maroon

,Color.Brown

 ,Color.MediumAquamarine

,Color.BurlyWood

 ,Color.MediumBlue

,Color.CadetBlue

 ,Color.MediumOrchid

,Color.Chartreuse

 ,Color.MediumPurple

,Color.Chocolate

 ,Color.MediumSeaGreen

,Color.Coral

 ,Color.MediumSlateBlue

,Color.CornflowerBlue

 ,Color.MediumSpringGreen

,Color.Cornsilk

 ,Color.MediumTurquoise

,Color.Crimson

 ,Color.MediumVioletRed

,Color.Cyan
 ,Color.MidnightBlue

,Color.DarkBlue

 ,Color.MintCream

,Color.DarkCyan

 ,Color.MistyRose

,Color.DarkGoldenrod

 ,Color.Moccasin

,Color.DarkGray

 ,Color.NavajoWhite

,Color.DarkGreen

 ,Color.Navy

,Color.DarkKhaki

 ,Color.OldLace

 ,Color.Olive

,Color.DarkOliveGreen

 ,Color.OliveDrab

,Color.DarkOrange

 ,Color.Orange

,Color.DarkOrchid

 ,Color.OrangeRed

,Color.DarkRed

 ,Color.Orchid

,Color.DarkSalmon

 ,Color.PaleGoldenrod

,Color.DarkSeaGreen

 ,Color.PaleGreen

,Color.DarkSlateBlue

 ,Color.PaleTurquoise

,Color.DarkSlateGray

 ,Color.PaleVioletRed

,Color.DarkTurquoise

 ,Color.PapayaWhip

,Color.DarkViolet

 ,Color.PeachPuff

,Color.DeepPink

 ,Color.Peru

,Color.DeepSkyBlue

 ,Color.Pink

,Color.DimGray

 ,Color.Plum

,Color.DodgerBlue

 ,Color.PowderBlue

,Color.Firebrick

 ,Color.Purple

,Color.FloralWhite

 ,Color.Red

,Color.ForestGreen

 ,Color.RosyBrown

 ,Color.RoyalBlue

,Color.Gainsboro

 ,Color.SaddleBrown

,Color.GhostWhite

 ,Color.Salmon

,Color.Gold

 ,Color.SandyBrown

,Color.Goldenrod

 ,Color.SeaGreen

,Color.Gray

,Color.Green

 ,Color.Sienna

,Color.GreenYellow

 ,Color.Silver

,Color.Honeydew

 ,Color.SkyBlue

,Color.HotPink

 ,Color.SlateBlue

,Color.IndianRed

 ,Color.SlateGray

,Color.Indigo

 ,Color.Snow

,Color.Ivory

 ,Color.SpringGreen

,Color.Khaki

 ,Color.SteelBlue

,Color.Lavender

 ,Color.Tan

,Color.LavenderBlush

 ,Color.Teal

,Color.LawnGreen

 ,Color.Thistle

,Color.LemonChiffon

 ,Color.Tomato

,Color.LightBlue

 ,Color.Turquoise

,Color.LightCoral

 ,Color.Violet

,Color.LightCyan

 ,Color.Wheat

,Color.LightGoldenrodYellow

 ,Color.White

,Color.LightGreen

 ,Color.WhiteSmoke

,Color.LightGray

 ,Color.Yellow

,Color.LightPink,Color.YellowGreen,Color.MediumVioletRed,Color.Maroon

 
            //190 colours in total 
        };

        MarkerStyle[] markerStyle = {
        MarkerStyle.Circle,
        MarkerStyle.Square,      
        MarkerStyle.Cross,
        MarkerStyle.Diamond,
        MarkerStyle.Triangle,
        MarkerStyle.Star10,
        MarkerStyle.Star4,
        MarkerStyle.Star5,
        MarkerStyle.Star6
        
        };
        public DBSCAN_visual(Data d, List<List<Point>> r, Writer w)
        {
            this.writer = w;
            this.data = d;
            this.result = r;

            InitializeComponent();
        }

        private void DBSCAN_visual_Load(object sender, EventArgs e)
        {
            this.Text = "Clustering result for DBSCAN algorithm:";
            if (data.Params.ContainsKey("name"))
            {
                data.Params["name"] = this.Text;

            }
            else
            {
                data.Params.Add("name", this.Text);
            }
        }

 
        public void plot_dbscan()
        {
            int totalPlot = 0;
            int resultCount = result.Count;
            for (int resultNum = 0; resultNum < resultCount; resultNum++)
            {
                Random random = new Random();
                int f_iMarkerStyle = random.Next(1, 9);
                //Color f_color = data.GetRandomColor();

                var num_clusters = result[resultNum].Count;
                var series = new Series[resultCount];
                for (var i = 0; i < num_clusters; i++)
                {
                    totalPlot++;

                    // DBSCAN_chart centroids
                    var s = DBSCAN_chart.Series.Add(totalPlot.ToString());
                    s.Points.AddXY(result[resultNum][i].X, result[resultNum][i].Y);
                    s.ChartType = SeriesChartType.Point;
                    //s.Color = f_color;
                    s.Color = colors[resultNum];
                    s.MarkerSize = 6;
                    s.MarkerStyle = markerStyle[f_iMarkerStyle];// MarkerStyle.Circle;
                    s.IsVisibleInLegend = false;

                }
                //if(resultNum== num_clusters-1)
                //    series[resultNum] = DBSCAN_chart.Series.Add("Noise:" + num_clusters.ToString() + "points");
                //else
                    series[resultNum] = DBSCAN_chart.Series.Add("Cluster" + resultNum.ToString()+ ":" + " "+num_clusters.ToString()+"points");
                
                series[resultNum].ChartType = SeriesChartType.Point;
               
                series[resultNum].Color = colors[resultNum];


            }
        }


        private void SaveResult_Click(object sender, EventArgs e)
        {
        }
        
        private void DBSCAN_chart_Click(object sender, EventArgs e)
        {

        }

        private void PlotTimeComplexity_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            writer.write_data(data, result);
        }

        private void poltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(data.formCmp.IsDisposed)
            {
                data.formCmp = new Form_cmp();
            }
            data.formCmp.Show();
            data.formCmp.updateChart(data);
        }

        private void DBSCAN_chart_Click_1(object sender, EventArgs e)
        {

        }
    }
}

            
        



//       
