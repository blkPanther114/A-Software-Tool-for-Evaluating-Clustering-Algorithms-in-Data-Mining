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
    public partial class Form_visual_kmeans : Form
    {
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


        private Writer writer;
        private Data data;
        private Result result;

        public Form_visual_kmeans(Data d, Result r, Writer w)
        {
            this.writer = w;
            this.data = d;
            this.result = r;

            InitializeComponent();
        }

        public void plot_clusters(double[,] points, Result result, double q, double bc, double wc)

        { 
                var num_clusters = result.Means.GetLength(0);
            
            var series = new Series[num_clusters];
            for (var i = 0; i < num_clusters; i++)
            {
                //var points_in_each_cluster = result.Clusters[i].GetLength(0);
                series[i] = plot.Series.Add("Cluster" + i.ToString() /*+ ":" + " " points_in_each_cluster.ToString() + "points"*/);

                    //series[i] = plot.Series.Add(i.ToString());
                series[i].ChartType = SeriesChartType.Point;
                series[i].Color = colors[i];
                
                // plot centroids
                var s = plot.Series.Add((i + num_clusters).ToString());
                s.Points.AddXY(result.Means[i, 0], result.Means[i, 1]);
                
                s.ChartType = SeriesChartType.Point;
                s.Color = colors[i];
                s.MarkerSize = 30;
                s.MarkerStyle = MarkerStyle.Cross;
                s.IsVisibleInLegend = false;

                //double temp = result.SSE;
                //string sse = Convert.ToString(temp);
                //sse_label.Text = sse;

                sse_label.Text = Convert.ToString(q);
                BC_label.Text = Convert.ToString(bc);
                WC_label.Text = Convert.ToString(wc);

            }

            // plot clusters
            var num_points = this.data.Num_points;
            for (var i = 0; i < num_points; i++)
                series[result.Clusters[i]].Points.AddXY(points[i, 0], points[i, 1]);

        }


        private void sse_label_Click(object sender, EventArgs e)
        {

        }
        
        private void saveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            writer.write_data(data, result.Clusters);
        }

        private void plotTimeComplexityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.formCmp == null)
            {
                data.formCmp = new Form_cmp();
            }
            data.formCmp.Show();
            data.formCmp.updateChart(data);
        }

        private void plot_Click(object sender, EventArgs e)
        {

        }

        private void sse_label_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}