namespace clustering
{
    partial class Form_visual_AGNES
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.plot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sse_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.BC_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WC_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.plot)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plot
            // 
            this.plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plot.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.plot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.plot.Legends.Add(legend1);
            this.plot.Location = new System.Drawing.Point(-2, 78);
            this.plot.Margin = new System.Windows.Forms.Padding(2);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(583, 346);
            this.plot.TabIndex = 0;
            this.plot.Text = "chart1";
            // 
            // sse_label
            // 
            this.sse_label.AutoSize = true;
            this.sse_label.Location = new System.Drawing.Point(263, 63);
            this.sse_label.Name = "sse_label";
            this.sse_label.Size = new System.Drawing.Size(35, 13);
            this.sse_label.TabIndex = 6;
            this.sse_label.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(176, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Overall Quality=";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveResultToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // saveResultToolStripMenuItem
            // 
            this.saveResultToolStripMenuItem.Name = "saveResultToolStripMenuItem";
            this.saveResultToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveResultToolStripMenuItem.Text = "Save result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Separation(BC)=";
            // 
            // BC_label
            // 
            this.BC_label.AutoSize = true;
            this.BC_label.Location = new System.Drawing.Point(93, 35);
            this.BC_label.Name = "BC_label";
            this.BC_label.Size = new System.Drawing.Size(35, 13);
            this.BC_label.TabIndex = 9;
            this.BC_label.Text = "label1";
            this.BC_label.Click += new System.EventHandler(this.BC_label_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(302, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cohesion(WC)=";
            // 
            // WC_label
            // 
            this.WC_label.AutoSize = true;
            this.WC_label.Location = new System.Drawing.Point(389, 35);
            this.WC_label.Name = "WC_label";
            this.WC_label.Size = new System.Drawing.Size(35, 13);
            this.WC_label.TabIndex = 11;
            this.WC_label.Text = "label1";
            this.WC_label.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form_visual_AGNES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 424);
            this.Controls.Add(this.WC_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BC_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.sse_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plot);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_visual_AGNES";
            this.Text = "Clustering result for Agglomerative Hierarchical algorithm:";
            ((System.ComponentModel.ISupportInitialize)(this.plot)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart plot;
        private System.Windows.Forms.Label sse_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BC_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label WC_label;
    }
}