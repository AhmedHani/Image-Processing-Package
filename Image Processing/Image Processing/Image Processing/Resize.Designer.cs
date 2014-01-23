namespace Image_Processing
{
    partial class Resize
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
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Bilinear = new System.Windows.Forms.CheckBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(64, 23);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(50, 20);
            this.WidthTextBox.TabIndex = 0;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(64, 49);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(50, 20);
            this.HeightTextBox.TabIndex = 2;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // Bilinear
            // 
            this.Bilinear.AutoSize = true;
            this.Bilinear.Location = new System.Drawing.Point(34, 103);
            this.Bilinear.Name = "Bilinear";
            this.Bilinear.Size = new System.Drawing.Size(95, 17);
            this.Bilinear.TabIndex = 5;
            this.Bilinear.Text = "Bilinear Resize";
            this.Bilinear.UseVisualStyleBackColor = true;
            this.Bilinear.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(87, 138);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(51, 22);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(15, 138);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(49, 22);
            this.OK.TabIndex = 7;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.button2_Click);
            // 
            // Resize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 181);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Bilinear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WidthTextBox);
            this.Name = "Resize";
            this.Text = "Resize";
            this.Load += new System.EventHandler(this.Resize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Bilinear;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
    }
}