using System;

namespace clustering
{
    partial class Form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        //test
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.manhattan_btn = new System.Windows.Forms.RadioButton();
            this.cosine_btn = new System.Windows.Forms.RadioButton();
            this.Euclidean_btn = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.agnes_cb = new System.Windows.Forms.CheckBox();
            this.kmeans_cb = new System.Windows.Forms.CheckBox();
            this.DBSan_cb = new System.Windows.Forms.CheckBox();
            this.gmm_cb = new System.Windows.Forms.CheckBox();
            this.run_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.clear_file_btn = new System.Windows.Forms.Button();
            this.path_textbox = new System.Windows.Forms.TextBox();
            this.open_file_btn = new System.Windows.Forms.Button();
            this.Load_file_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.enterK_label = new System.Windows.Forms.Label();
            this.num_cluster_txtbox = new System.Windows.Forms.TextBox();
            this.EnterEps_label = new System.Windows.Forms.Label();
            this.EpsValue_textBox = new System.Windows.Forms.TextBox();
            this.enter_min_label = new System.Windows.Forms.Label();
            this.enterMin_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // manhattan_btn
            // 
            this.manhattan_btn.AutoSize = true;
            this.manhattan_btn.Location = new System.Drawing.Point(162, 250);
            this.manhattan_btn.Name = "manhattan_btn";
            this.manhattan_btn.Size = new System.Drawing.Size(119, 17);
            this.manhattan_btn.TabIndex = 42;
            this.manhattan_btn.TabStop = true;
            this.manhattan_btn.Text = "Manhattan distance";
            this.manhattan_btn.UseVisualStyleBackColor = true;
            // 
            // cosine_btn
            // 
            this.cosine_btn.AutoSize = true;
            this.cosine_btn.Location = new System.Drawing.Point(162, 227);
            this.cosine_btn.Name = "cosine_btn";
            this.cosine_btn.Size = new System.Drawing.Size(98, 17);
            this.cosine_btn.TabIndex = 41;
            this.cosine_btn.TabStop = true;
            this.cosine_btn.Text = "Cosine similarity";
            this.cosine_btn.UseVisualStyleBackColor = true;
            // 
            // Euclidean_btn
            // 
            this.Euclidean_btn.AutoSize = true;
            this.Euclidean_btn.Location = new System.Drawing.Point(162, 204);
            this.Euclidean_btn.Name = "Euclidean_btn";
            this.Euclidean_btn.Size = new System.Drawing.Size(115, 17);
            this.Euclidean_btn.TabIndex = 40;
            this.Euclidean_btn.TabStop = true;
            this.Euclidean_btn.Text = "Euclidean distance";
            this.Euclidean_btn.UseVisualStyleBackColor = true;
            this.Euclidean_btn.CheckedChanged += new System.EventHandler(this.Euclidean_btn_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(167, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Similarity measure:";
            // 
            // agnes_cb
            // 
            this.agnes_cb.AutoSize = true;
            this.agnes_cb.Location = new System.Drawing.Point(47, 251);
            this.agnes_cb.Name = "agnes_cb";
            this.agnes_cb.Size = new System.Drawing.Size(93, 17);
            this.agnes_cb.TabIndex = 38;
            this.agnes_cb.Text = "Agglomerative";
            this.agnes_cb.UseVisualStyleBackColor = true;
            this.agnes_cb.CheckedChanged += new System.EventHandler(this.agnes_cb_CheckedChanged);
            // 
            // kmeans_cb
            // 
            this.kmeans_cb.AutoSize = true;
            this.kmeans_cb.Location = new System.Drawing.Point(47, 205);
            this.kmeans_cb.Name = "kmeans_cb";
            this.kmeans_cb.Size = new System.Drawing.Size(67, 17);
            this.kmeans_cb.TabIndex = 34;
            this.kmeans_cb.Text = "K means";
            this.kmeans_cb.UseVisualStyleBackColor = true;
            this.kmeans_cb.CheckedChanged += new System.EventHandler(this.Kmeans_cb_CheckedChanged);
            // 
            // DBSan_cb
            // 
            this.DBSan_cb.AutoSize = true;
            this.DBSan_cb.Location = new System.Drawing.Point(47, 228);
            this.DBSan_cb.Name = "DBSan_cb";
            this.DBSan_cb.Size = new System.Drawing.Size(70, 17);
            this.DBSan_cb.TabIndex = 35;
            this.DBSan_cb.Text = "DBSCAN";
            this.DBSan_cb.UseVisualStyleBackColor = true;
            this.DBSan_cb.CheckedChanged += new System.EventHandler(this.DBSan_cb_CheckedChanged);
            // 
            // gmm_cb
            // 
            this.gmm_cb.AutoSize = true;
            this.gmm_cb.Location = new System.Drawing.Point(47, 274);
            this.gmm_cb.Name = "gmm_cb";
            this.gmm_cb.Size = new System.Drawing.Size(73, 17);
            this.gmm_cb.TabIndex = 36;
            this.gmm_cb.Text = "GMM/EM";
            this.gmm_cb.UseVisualStyleBackColor = true;
            this.gmm_cb.CheckedChanged += new System.EventHandler(this.gmm_cb_CheckedChanged);
            // 
            // run_btn
            // 
            this.run_btn.BackColor = System.Drawing.SystemColors.Control;
            this.run_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.run_btn.Location = new System.Drawing.Point(380, 292);
            this.run_btn.Name = "run_btn";
            this.run_btn.Size = new System.Drawing.Size(75, 23);
            this.run_btn.TabIndex = 37;
            this.run_btn.Text = "Run";
            this.run_btn.UseVisualStyleBackColor = false;
            this.run_btn.Click += new System.EventHandler(this.run_btn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(44, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Select an algorithm:\r\n";
            // 
            // clear_file_btn
            // 
            this.clear_file_btn.Location = new System.Drawing.Point(162, 109);
            this.clear_file_btn.Name = "clear_file_btn";
            this.clear_file_btn.Size = new System.Drawing.Size(75, 23);
            this.clear_file_btn.TabIndex = 28;
            this.clear_file_btn.Text = "Clear file";
            this.clear_file_btn.UseVisualStyleBackColor = true;
            this.clear_file_btn.Click += new System.EventHandler(this.clear_file_btn_Click);
            // 
            // path_textbox
            // 
            this.path_textbox.Enabled = false;
            this.path_textbox.Location = new System.Drawing.Point(157, 70);
            this.path_textbox.Name = "path_textbox";
            this.path_textbox.Size = new System.Drawing.Size(393, 20);
            this.path_textbox.TabIndex = 32;
            // 
            // open_file_btn
            // 
            this.open_file_btn.Location = new System.Drawing.Point(47, 68);
            this.open_file_btn.Name = "open_file_btn";
            this.open_file_btn.Size = new System.Drawing.Size(75, 23);
            this.open_file_btn.TabIndex = 31;
            this.open_file_btn.Text = "Choose file";
            this.open_file_btn.UseVisualStyleBackColor = true;
            this.open_file_btn.Click += new System.EventHandler(this.open_file_btn_Click);
            // 
            // Load_file_btn
            // 
            this.Load_file_btn.Location = new System.Drawing.Point(47, 109);
            this.Load_file_btn.Name = "Load_file_btn";
            this.Load_file_btn.Size = new System.Drawing.Size(75, 23);
            this.Load_file_btn.TabIndex = 30;
            this.Load_file_btn.Text = "Load file";
            this.Load_file_btn.UseVisualStyleBackColor = true;
            this.Load_file_btn.Click += new System.EventHandler(this.Load_file_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(44, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Please upload a file";
            // 
            // enterK_label
            // 
            this.enterK_label.AutoSize = true;
            this.enterK_label.BackColor = System.Drawing.SystemColors.Info;
            this.enterK_label.Location = new System.Drawing.Point(310, 172);
            this.enterK_label.Name = "enterK_label";
            this.enterK_label.Size = new System.Drawing.Size(84, 13);
            this.enterK_label.TabIndex = 43;
            this.enterK_label.Text = "Num of Clusters:";
            this.enterK_label.Click += new System.EventHandler(this.enterK_label_Click_1);
            // 
            // num_cluster_txtbox
            // 
            this.num_cluster_txtbox.Location = new System.Drawing.Point(313, 188);
            this.num_cluster_txtbox.Name = "num_cluster_txtbox";
            this.num_cluster_txtbox.Size = new System.Drawing.Size(100, 20);
            this.num_cluster_txtbox.TabIndex = 44;
            this.num_cluster_txtbox.TextChanged += new System.EventHandler(this.num_cluster_txtbox_TextChanged);
            // 
            // EnterEps_label
            // 
            this.EnterEps_label.AutoSize = true;
            this.EnterEps_label.BackColor = System.Drawing.SystemColors.Info;
            this.EnterEps_label.Location = new System.Drawing.Point(313, 227);
            this.EnterEps_label.Name = "EnterEps_label";
            this.EnterEps_label.Size = new System.Drawing.Size(85, 13);
            this.EnterEps_label.TabIndex = 45;
            this.EnterEps_label.Text = "Enter Eps value:";
            this.EnterEps_label.Click += new System.EventHandler(this.EnterEps_label_Click);
            // 
            // EpsValue_textBox
            // 
            this.EpsValue_textBox.Location = new System.Drawing.Point(313, 243);
            this.EpsValue_textBox.Name = "EpsValue_textBox";
            this.EpsValue_textBox.Size = new System.Drawing.Size(100, 20);
            this.EpsValue_textBox.TabIndex = 46;
            this.EpsValue_textBox.TextChanged += new System.EventHandler(this.EpsValue_textBox_TextChanged);
            // 
            // enter_min_label
            // 
            this.enter_min_label.AutoSize = true;
            this.enter_min_label.BackColor = System.Drawing.SystemColors.Info;
            this.enter_min_label.Location = new System.Drawing.Point(448, 227);
            this.enter_min_label.Name = "enter_min_label";
            this.enter_min_label.Size = new System.Drawing.Size(85, 13);
            this.enter_min_label.TabIndex = 47;
            this.enter_min_label.Text = "Enter min points:";
            // 
            // enterMin_textBox
            // 
            this.enterMin_textBox.Location = new System.Drawing.Point(451, 243);
            this.enterMin_textBox.Name = "enterMin_textBox";
            this.enterMin_textBox.Size = new System.Drawing.Size(100, 20);
            this.enterMin_textBox.TabIndex = 48;
            this.enterMin_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterMin_textBox_KeyPress);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 351);
            this.Controls.Add(this.enterMin_textBox);
            this.Controls.Add(this.enter_min_label);
            this.Controls.Add(this.EpsValue_textBox);
            this.Controls.Add(this.EnterEps_label);
            this.Controls.Add(this.num_cluster_txtbox);
            this.Controls.Add(this.enterK_label);
            this.Controls.Add(this.manhattan_btn);
            this.Controls.Add(this.cosine_btn);
            this.Controls.Add(this.Euclidean_btn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.agnes_cb);
            this.Controls.Add(this.kmeans_cb);
            this.Controls.Add(this.DBSan_cb);
            this.Controls.Add(this.gmm_cb);
            this.Controls.Add(this.run_btn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.clear_file_btn);
            this.Controls.Add(this.path_textbox);
            this.Controls.Add(this.open_file_btn);
            this.Controls.Add(this.Load_file_btn);
            this.Controls.Add(this.label2);
            this.Name = "Form_main";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.RadioButton manhattan_btn;
        private System.Windows.Forms.RadioButton cosine_btn;
        private System.Windows.Forms.RadioButton Euclidean_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox agnes_cb;
        private System.Windows.Forms.CheckBox kmeans_cb;
        private System.Windows.Forms.CheckBox DBSan_cb;
        private System.Windows.Forms.CheckBox gmm_cb;
        private System.Windows.Forms.Button run_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button clear_file_btn;
        private System.Windows.Forms.TextBox path_textbox;
        private System.Windows.Forms.Button open_file_btn;
        private System.Windows.Forms.Button Load_file_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label enterK_label;
        private System.Windows.Forms.TextBox num_cluster_txtbox;
        private System.Windows.Forms.Label EnterEps_label;
        private System.Windows.Forms.TextBox EpsValue_textBox;
        private System.Windows.Forms.Label enter_min_label;
        private System.Windows.Forms.TextBox enterMin_textBox;
    }
}

