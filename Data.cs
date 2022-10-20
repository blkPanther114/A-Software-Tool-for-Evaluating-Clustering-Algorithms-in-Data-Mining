using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clustering
{
    public class Data
    {
        public readonly int Num_points;
        public readonly int Dim;
        //public readonly int Iter_max;
        public readonly bool Has_name;
        public readonly Dictionary<string, string> Params = new Dictionary<string, string>();
        public readonly double[,] Points;
        public readonly List<TimeSpan> timeSpan = new List<TimeSpan>();
        public Form_cmp formCmp = new Form_cmp();
        private DateTime beforDT = System.DateTime.Now;
        private DateTime afterDT = System.DateTime.Now;
        public Data(int num_points, int dim,/* int iter_max,*/ bool has_name, double[,] points/*, Dictionary<string, double> param*/) {
            Num_points = num_points;//no of rows
            Dim = dim;//no of column
            //Iter_max = iter_max;
            Has_name = has_name;
            //Params = param;
            Points = points;
        }
        public Data()
        {
            Num_points = 0;
            Dim = 0;
            //Iter_max = iter_max;
            Has_name = false;
            //Params = param;
        }
        public void t0()
        {
            //record start time
            beforDT = System.DateTime.Now;
            
        }
        public TimeSpan t1()
        {
            //record end time
            afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);
            timeSpan.Add(ts);
            return ts;
        }
        public Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
         
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            //  random colour
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }
    }
}