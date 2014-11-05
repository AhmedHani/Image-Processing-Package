namespace Image_Processing
{
    partial class Histogram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.redBox = new System.Windows.Forms.CheckBox();
            this.greenBox = new System.Windows.Forms.CheckBox();
            this.blueBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(13, 36);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.Red;
            series7.Legend = "Legend1";
            series7.Name = "red";
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.Green;
            series8.Legend = "Legend1";
            series8.Name = "green";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "blue";
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(642, 404);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // redBox
            // 
            this.redBox.AutoSize = true;
            this.redBox.Checked = true;
            this.redBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.redBox.Location = new System.Drawing.Point(23, 12);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(46, 17);
            this.redBox.TabIndex = 1;
            this.redBox.Text = "Red";
            this.redBox.UseVisualStyleBackColor = true;
            this.redBox.CheckedChanged += new System.EventHandler(this.redBox_CheckedChanged);
            // 
            // greenBox
            // 
            this.greenBox.AutoSize = true;
            this.greenBox.Checked = true;
            this.greenBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.greenBox.Location = new System.Drawing.Point(195, 13);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(55, 17);
            this.greenBox.TabIndex = 2;
            this.greenBox.Text = "Green";
            this.greenBox.UseVisualStyleBackColor = true;
            this.greenBox.CheckedChanged += new System.EventHandler(this.greenBox_CheckedChanged);
            // 
            // blueBox
            // 
            this.blueBox.AutoSize = true;
            this.blueBox.Checked = true;
            this.blueBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blueBox.Location = new System.Drawing.Point(395, 12);
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(47, 17);
            this.blueBox.TabIndex = 3;
            this.blueBox.Text = "Blue";
            this.blueBox.UseVisualStyleBackColor = true;
            this.blueBox.CheckedChanged += new System.EventHandler(this.blueBox_CheckedChanged);
            // 
            // Histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 452);
            this.Controls.Add(this.blueBox);
            this.Controls.Add(this.greenBox);
            this.Controls.Add(this.redBox);
            this.Controls.Add(this.chart1);
            this.Name = "Histogram";
            this.Text = "Histogram";
            this.Load += new System.EventHandler(this.Histogram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox redBox;
        private System.Windows.Forms.CheckBox greenBox;
        private System.Windows.Forms.CheckBox blueBox;
    }
}