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
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using SharpCluster;


namespace clustering
{
    public partial class Form_main : Form
    {
        private Reader reader = new Reader();
        private Writer writer = new Writer();
        private Data data;

        public Form_main()
        {
            InitializeComponent();
        }


        private void open_file_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "./datasets";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path_textbox.Text = openFileDialog.FileName;
                    data = reader.Get_data(path_textbox.Text);
                }
            }
        }

        private void clear_file_btn_Click(object sender, EventArgs e)
        {
            path_textbox.Text = "";
            //unload
        }

        private void Load_file_btn_Click(object sender, EventArgs e)
        {
            data = reader.Get_data(path_textbox.Text);
        }

        private void run_btn_Click(object sender, EventArgs e)
        {

            if (data == null)
            {
                MessageBox.Show("Please choose a dataset!");
                return;
            }

            if (manhattan_btn.Checked == false && cosine_btn.Checked == false)
            {
                Euclidean_btn.Checked = true;
            }

            if (kmeans_cb.Checked == false && gmm_cb.Checked == false && agnes_cb.Checked == false && DBSan_cb.Checked == false)
            {
                MessageBox.Show("Please choose an algorithm!");
                return;
            }
            

            if (kmeans_cb.Checked)
            {
                if (num_cluster_txtbox.Text == "" )
                {
                    MessageBox.Show("Please set a number of clusters as integer!");
                    return;
                }
                var num_clusters = Int32.Parse(num_cluster_txtbox.Text);

                var kmeans = new Kmeans(data, num_clusters);
                var result = kmeans.Get_clusters();
                var clusters = result.Clusters;
                //var Y = result.Item2;
                var Q = new QualityMeasurement(data, num_clusters,clusters);
                double q = Q.GetQ();
                double wc = Q.getWC();
                double bc = Q.getBC();
                visualise_kmeans(data.Points, result,q,bc,wc);
            }
            if (gmm_cb.Checked)
            {
                if (num_cluster_txtbox.Text == "")
                {
                    MessageBox.Show("Please set a number of clusters as integer!");
                    return;
                }
                var num_clusters = Int32.Parse(num_cluster_txtbox.Text);
                var gmm = new GMM(data, num_clusters);
                var result = gmm.Get_clusters();
                var clusters = result.Item1;
                var X = result.Item2;              
                var Q = new QualityMeasurement(data, num_clusters, clusters);
                double q = Q.GetQ();
                double wc = Q.getWC();
                double bc = Q.getBC();
                visualise_GMM(X, clusters, num_clusters, q,wc,bc);            
            }
            if (agnes_cb.Checked)
            {
                if (num_cluster_txtbox.Text == "")
                {
                    MessageBox.Show("Please set a number of clusters as integer!");
                    return;
                }
                var num_clusters = Int32.Parse(num_cluster_txtbox.Text);
                var agnes = new Agnes(data);
                int[] clusters = agnes.Get_clusters(num_clusters);
                var Q = new QualityMeasurement(data, num_clusters, clusters);
                //var Q = new QualityMeasurement(data, num_clusters);
                double q = Q.GetQ();
                double wc = Q.getWC();
                double bc = Q.getBC();
               visualise_AGNES(data.Points, clusters, num_clusters, q,bc,wc);

                
            }
            if (DBSan_cb.Checked)
            {
                if (EpsValue_textBox.Text == "")
                {
                    MessageBox.Show("Please input eps and minpts!");
                    return;
                }
                if (enterMin_textBox.Text == "")
                {
                    MessageBox.Show("Please input eps and minpts!");
                    return;
                }
                if (data.Params.ContainsKey("eps"))
                {
                    data.Params["eps"] = EpsValue_textBox.Text;

                }
                else
                {
                    data.Params.Add("eps", EpsValue_textBox.Text);
                }

                if (data.Params.ContainsKey("minPts"))
                {
                    data.Params["minPts"] = enterMin_textBox.Text;

                }
                else
                {
                    data.Params.Add("minPts", enterMin_textBox.Text);
                }


                
               

                var dbscan = new DBSCAN(data, double.Parse(data.Params["eps"]), Int32.Parse(data.Params["minPts"]));
                var result = dbscan.Get_clusters();
                visualise_Dbscan(data, result, writer);
            }
        }

        private void visualise_kmeans(double[,] points, Result result,double q, double bc,double wc)
        {
            // plot clusters in a new form
            var form_vis = new Form_visual_kmeans(data, result, writer);
            form_vis.plot_clusters(points, result,q,bc,wc);
            form_vis.Show();
        }
        private void visualise_Dbscan(Data data, List<List<Point>> result, Writer writer)
        {
            // plot clusters in a new form
            var form_vis = new DBSCAN_visual(data, result, writer);
            form_vis.plot_dbscan();
            form_vis.Show();
        }
        private void visualise_GMM(double[][] points, int[] clusters, int num_clusters, double q,double wc,double bc)
        {
            // plot clusters in a new form
           var form_vis = new Form_visual_GMM();
            //var form_vis = new Form_visual_GMM(data,result,writer);
            form_vis.plot_clusters(points, clusters, num_clusters, q,wc,bc);
            form_vis.Show();
        }
        private void visualise_AGNES(double[,] points, int[] clusters, int num_clusters, double q,double bc,double wc)
        {
            // plot clusters in a new form
            var form_vis = new Form_visual_AGNES();
            form_vis.plot_clusters(points, clusters, num_clusters, data.Num_points, q,bc,wc);
            form_vis.Show();
        }

        private void EnterEps_label_Click(object sender, EventArgs e)
        {
            
        }

        private void Kmeans_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (kmeans_cb.Checked)
            {
                enterK_label.Enabled = true;
                num_cluster_txtbox.Enabled = true;
                EnterEps_label.Enabled = false;
                EpsValue_textBox.Enabled = false;
                Euclidean_btn.Checked = true;
                enter_min_label.Enabled = false;
                enterMin_textBox.Enabled = false;
            }
        }

        private void enterK_label_Click_1(object sender, EventArgs e)
        {

        }

        private void DBSan_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (DBSan_cb.Checked)
            {
                EnterEps_label.Enabled = true;
                EpsValue_textBox.Enabled = true;
                enter_min_label.Enabled = true;
                enterMin_textBox.Enabled = true;
                enterK_label.Enabled = false;
                num_cluster_txtbox.Enabled = false;

            }
        }

        private void enterMin_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '-' && ((TextBox)sender).Text.Length > 1)
            {
                e.Handled = true;
            }
        }

        private void Euclidean_btn_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void gmm_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (gmm_cb.Checked)
            {
                enterK_label.Enabled = true;
                num_cluster_txtbox.Enabled = true;
                EnterEps_label.Enabled = false;
                EpsValue_textBox.Enabled = false;
                Euclidean_btn.Checked = false;
                enter_min_label.Enabled = false;
                enterMin_textBox.Enabled = false;
            }
        }

        private void agnes_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (agnes_cb.Checked)
            {
                enterK_label.Enabled = true;
                num_cluster_txtbox.Enabled = true;
                EnterEps_label.Enabled = false;
                EpsValue_textBox.Enabled = false;
                Euclidean_btn.Checked = false;
                enter_min_label.Enabled = false;
                enterMin_textBox.Enabled = false;
            }
        }

        private void num_cluster_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            //{
            //    e.Handled = true;
            //}
            //else if (e.KeyChar == '-' && ((TextBox)sender).Text.Length > 1)
            //{
            //    e.Handled = true;
            //}
        }

        private void num_cluster_txtbox_TextChanged(object sender, EventArgs e)
        {
            int distance;
            if (int.TryParse(num_cluster_txtbox.Text, out distance)==false)
            {
                MessageBox.Show("Please enter an integer!");
                return;
            }
        }

        private void EpsValue_textBox_TextChanged(object sender, EventArgs e)
        { 
                if (float.TryParse(EpsValue_textBox.Text, out var outParse) == false)
            {
                MessageBox.Show("Please enter a number!");
                return;
            }
        }
    }
}