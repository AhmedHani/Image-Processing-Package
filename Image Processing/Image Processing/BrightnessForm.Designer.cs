namespace Image_Processing
{
    partial class BrightnessForm
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
            this.BrightnessValue = new System.Windows.Forms.Label();
            this.BrightnessBox = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BrightnessValue
            // 
            this.BrightnessValue.AutoSize = true;
            this.BrightnessValue.Location = new System.Drawing.Point(28, 13);
            this.BrightnessValue.Name = "BrightnessValue";
            this.BrightnessValue.Size = new System.Drawing.Size(83, 13);
            this.BrightnessValue.TabIndex = 0;
            this.BrightnessValue.Text = "BrightnessValue";
            this.BrightnessValue.Click += new System.EventHandler(this.BrightnessValue_Click);
            // 
            // BrightnessBox
            // 
            this.BrightnessBox.Location = new System.Drawing.Point(131, 13);
            this.BrightnessBox.Name = "BrightnessBox";
            this.BrightnessBox.Size = new System.Drawing.Size(100, 20);
            this.BrightnessBox.TabIndex = 1;
            this.BrightnessBox.TextChanged += new System.EventHandler(this.BrightnessBox_TextChanged);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(146, 40);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(31, 40);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // BrightnessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 66);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.BrightnessBox);
            this.Controls.Add(this.BrightnessValue);
            this.Name = "BrightnessForm";
            this.Text = "Brightness Form";
            this.Load += new System.EventHandler(this.PopWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BrightnessValue;
        private System.Windows.Forms.TextBox BrightnessBox;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
    }
}