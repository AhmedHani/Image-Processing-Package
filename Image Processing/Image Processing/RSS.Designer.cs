namespace Image_Processing
{
    partial class RSS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scaleX = new System.Windows.Forms.TextBox();
            this.scaleY = new System.Windows.Forms.TextBox();
            this.angle = new System.Windows.Forms.TextBox();
            this.shearX = new System.Windows.Forms.TextBox();
            this.shearY = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ScaleX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ScaleY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Angle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ShearX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ShearY";
            // 
            // scaleX
            // 
            this.scaleX.Location = new System.Drawing.Point(71, 13);
            this.scaleX.Name = "scaleX";
            this.scaleX.Size = new System.Drawing.Size(201, 20);
            this.scaleX.TabIndex = 5;
            // 
            // scaleY
            // 
            this.scaleY.Location = new System.Drawing.Point(71, 44);
            this.scaleY.Name = "scaleY";
            this.scaleY.Size = new System.Drawing.Size(201, 20);
            this.scaleY.TabIndex = 6;
            // 
            // angle
            // 
            this.angle.Location = new System.Drawing.Point(71, 75);
            this.angle.Name = "angle";
            this.angle.Size = new System.Drawing.Size(201, 20);
            this.angle.TabIndex = 7;
            // 
            // shearX
            // 
            this.shearX.Location = new System.Drawing.Point(71, 106);
            this.shearX.Name = "shearX";
            this.shearX.Size = new System.Drawing.Size(201, 20);
            this.shearX.TabIndex = 8;
            // 
            // shearY
            // 
            this.shearY.Location = new System.Drawing.Point(71, 137);
            this.shearY.Name = "shearY";
            this.shearY.Size = new System.Drawing.Size(201, 20);
            this.shearY.TabIndex = 9;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(16, 186);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 10;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(197, 186);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // RSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 221);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.shearY);
            this.Controls.Add(this.shearX);
            this.Controls.Add(this.angle);
            this.Controls.Add(this.scaleY);
            this.Controls.Add(this.scaleX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RSS";
            this.Text = "RSS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox scaleX;
        private System.Windows.Forms.TextBox scaleY;
        private System.Windows.Forms.TextBox angle;
        private System.Windows.Forms.TextBox shearX;
        private System.Windows.Forms.TextBox shearY;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}