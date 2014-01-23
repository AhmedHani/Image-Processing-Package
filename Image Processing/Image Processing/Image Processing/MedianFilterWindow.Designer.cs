namespace Image_Processing
{
    partial class MedianFilterWindow
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
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.GrayScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Location = new System.Drawing.Point(140, 66);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.SizeTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(161, 137);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(61, 136);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // GrayScaleCheckBox
            // 
            this.GrayScaleCheckBox.AutoSize = true;
            this.GrayScaleCheckBox.Location = new System.Drawing.Point(161, 93);
            this.GrayScaleCheckBox.Name = "GrayScaleCheckBox";
            this.GrayScaleCheckBox.Size = new System.Drawing.Size(75, 17);
            this.GrayScaleCheckBox.TabIndex = 4;
            this.GrayScaleCheckBox.Text = "GrayScale";
            this.GrayScaleCheckBox.UseVisualStyleBackColor = true;
            this.GrayScaleCheckBox.CheckedChanged += new System.EventHandler(this.GrayScaleCheckBox_CheckedChanged);
            // 
            // MedianFilterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 169);
            this.Controls.Add(this.GrayScaleCheckBox);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SizeTextBox);
            this.Name = "MedianFilterWindow";
            this.Text = "MedianFilterWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.CheckBox GrayScaleCheckBox;
    }
}