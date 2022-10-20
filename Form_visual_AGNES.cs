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
    public partial class Form_visual_AGNES : Form
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
        public Form_visual_AGNES()
        {
            //this.writer = w;
            //this.data = d;
            //this.result = r;
            InitializeComponent();
        }
        public void plot_clusters(double[,] points, int[] clusters, int num_clusters, int num_points, double q, double bc, double wc)
        {
            var series = new Series[num_clusters];
            for (var i = 0; i < num_clusters; i++)
            {
                series[i] = plot.Series.Add("Cluster" + i.ToString());
                series[i].ChartType = SeriesChartType.Point;
                series[i].Color = colors[i];

                //plot centroids
                //var s = plot.Series.Add((i + num_clusters).ToString());
                //s.Points.AddXY(result.Means[i, 0], result.Means[i, 1]);
                //s.ChartType = SeriesChartType.Point;
                //s.Color = colors[i];
                //s.MarkerSize = 30;
                //s.MarkerStyle = MarkerStyle.Cross;
                //s.IsVisibleInLegend = false;

                //double temp = result.SSE;
                //string sse = Convert.ToString(q);
                sse_label.Text = Convert.ToString(q);
                BC_label.Text = Convert.ToString(bc);
                WC_label.Text = Convert.ToString(wc);

            }
            // plot clusters
            for (var i = 0; i < num_points; i++)
                series[clusters[i]].Points.AddXY(points[i,0], points[i,1]);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BC_label_Click(object sender, EventArgs e)
        {

        }
    }
}
