using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clustering
{
    public class Writer
    {
        public void write_data(Data data, int[] clusters, string path="")
        {
            // use SaveFileDialog，let user choose path
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "text file|*.txt";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                // create file, save waht is in textbox1 to the file
                // saveDlg.FileName is the user defined file'spath
                FileStream fs = File.Open(saveDlg.FileName,
                    FileMode.Create,
                    FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                // save all the rows from textbox1
                for (var i = 0; i < data.Num_points; i++)
                {
                    StringBuilder line = new StringBuilder();
                    for (var j = 0; j < data.Dim; j++)
                        line.AppendFormat("{0}\t", data.Points[i, j]);
                    line.AppendFormat("{0}", clusters[i]);
                    sw.WriteLine(line);
                }
                //close file
                sw.Flush();
                sw.Close();
                fs.Close();
               
                MessageBox.Show("File has successfully saved to" + saveDlg.FileName);
            }
        }
        public void write_data(Data data, List<List<Point>> clusters, string path = "")
        {
           
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "text file|*.txt";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
               
                FileStream fs = File.Open(saveDlg.FileName,
                    FileMode.Create,
                    FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                
                for (var i = 0; i < clusters.Count; i++)
                {
                    StringBuilder line = new StringBuilder();
                    line.AppendFormat("cluster {0} :\n", i + 1);
                    for (var j = 0; j < clusters[i].Count; j++)
                        line.AppendFormat("{0}\n", clusters[i][j]);
                    sw.WriteLine(line);
                }
               
                sw.Flush();
                sw.Close();
                fs.Close();
                
                MessageBox.Show("File has successfully saved to" + saveDlg.FileName);
            }
        }


    }
        
    }
