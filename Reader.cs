using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clustering
{
    class Reader
    {
        public Data Get_data(string path)
        {
            try
            {
                //handle exceptions: ArgumentNullException, DirectoryNotFoundException, FileNotFoundException, IOException, NotSupportedException
                var lines = File.ReadAllLines(path);
                var num_points_temp = lines.Length;
                var dim = 2;
                var points = new double[num_points_temp, dim];
                //array of rows and columns;
                var num_points = 0;
                for (var i = 0; i < num_points_temp; i++)//go through each row
                {
                    if ((lines[i] == "") | (lines[i] == "\t") | (lines[i] == "\n")) continue;
                    var coordinates = lines[i].Split('\t');
                    //Console.WriteLine("exp{1}: {0}", Convert.ToDouble(tp[0]), 0);
                    for (var j = 0; j < dim; j++)
                        //go through each column
                        points[num_points, j] = Convert.ToDouble(coordinates[j]);
                    num_points++;
                }
                return new Data(num_points, dim, true, points);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please upload a file!");
                return null;
            }
        }
    }
}