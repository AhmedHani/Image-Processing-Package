namespace Image_Processing
{
    partial class Main
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pPMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pP3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pP6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.britnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitSlicingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSegmentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageAlgebraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.substractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilinearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saltAndPepperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reduceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramCheck = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.equalizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.imageSegmentationToolStripMenuItem,
            this.imageAlgebraToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.noiseToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pPMToolStripMenuItem,
            this.generalToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // pPMToolStripMenuItem
            // 
            this.pPMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pP3ToolStripMenuItem,
            this.pP6ToolStripMenuItem});
            this.pPMToolStripMenuItem.Name = "pPMToolStripMenuItem";
            this.pPMToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.pPMToolStripMenuItem.Text = "PPM";
            // 
            // pP3ToolStripMenuItem
            // 
            this.pP3ToolStripMenuItem.Name = "pP3ToolStripMenuItem";
            this.pP3ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.pP3ToolStripMenuItem.Text = "PP3";
            this.pP3ToolStripMenuItem.Click += new System.EventHandler(this.pP3ToolStripMenuItem_Click);
            // 
            // pP6ToolStripMenuItem
            // 
            this.pP6ToolStripMenuItem.Name = "pP6ToolStripMenuItem";
            this.pP6ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.pP6ToolStripMenuItem.Text = "PP6";
            this.pP6ToolStripMenuItem.Click += new System.EventHandler(this.pP6ToolStripMenuItem_Click);
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.generalToolStripMenuItem.Text = "General";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateToolStripMenuItem,
            this.cropToolStripMenuItem,
            this.shearToolStripMenuItem1,
            this.allToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.editToolStripMenuItem.Text = "Image Transformation";
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // cropToolStripMenuItem
            // 
            this.cropToolStripMenuItem.Name = "cropToolStripMenuItem";
            this.cropToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.cropToolStripMenuItem.Text = "Scale";
            this.cropToolStripMenuItem.Click += new System.EventHandler(this.cropToolStripMenuItem_Click);
            // 
            // shearToolStripMenuItem1
            // 
            this.shearToolStripMenuItem1.Name = "shearToolStripMenuItem1";
            this.shearToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.shearToolStripMenuItem1.Text = "Shear";
            this.shearToolStripMenuItem1.Click += new System.EventHandler(this.shearToolStripMenuItem1_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayScaleToolStripMenuItem,
            this.britnessToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.gammaToolStripMenuItem,
            this.contrastToolStripMenuItem,
            this.tintToolStripMenuItem,
            this.bitSlicingToolStripMenuItem,
            this.equalizationToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.grayScaleToolStripMenuItem.Text = "GrayScale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.grayScaleToolStripMenuItem_Click);
            // 
            // britnessToolStripMenuItem
            // 
            this.britnessToolStripMenuItem.Name = "britnessToolStripMenuItem";
            this.britnessToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.britnessToolStripMenuItem.Text = "Brightness";
            this.britnessToolStripMenuItem.Click += new System.EventHandler(this.britnessToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // gammaToolStripMenuItem
            // 
            this.gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            this.gammaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gammaToolStripMenuItem.Text = "Gamma";
            this.gammaToolStripMenuItem.Click += new System.EventHandler(this.gammaToolStripMenuItem_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.contrastToolStripMenuItem.Text = "Contrast";
            this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
            // 
            // tintToolStripMenuItem
            // 
            this.tintToolStripMenuItem.Name = "tintToolStripMenuItem";
            this.tintToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tintToolStripMenuItem.Text = "Tint";
            this.tintToolStripMenuItem.Click += new System.EventHandler(this.tintToolStripMenuItem_Click);
            // 
            // bitSlicingToolStripMenuItem
            // 
            this.bitSlicingToolStripMenuItem.Name = "bitSlicingToolStripMenuItem";
            this.bitSlicingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bitSlicingToolStripMenuItem.Text = "Bit-Slicing";
            this.bitSlicingToolStripMenuItem.Click += new System.EventHandler(this.bitSlicingToolStripMenuItem_Click);
            // 
            // imageSegmentationToolStripMenuItem
            // 
            this.imageSegmentationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdingToolStripMenuItem,
            this.edgeDetectionToolStripMenuItem});
            this.imageSegmentationToolStripMenuItem.Name = "imageSegmentationToolStripMenuItem";
            this.imageSegmentationToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.imageSegmentationToolStripMenuItem.Text = "Image Segmentation";
            // 
            // thresholdingToolStripMenuItem
            // 
            this.thresholdingToolStripMenuItem.Name = "thresholdingToolStripMenuItem";
            this.thresholdingToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.thresholdingToolStripMenuItem.Text = "Thresholding";
            // 
            // edgeDetectionToolStripMenuItem
            // 
            this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
            this.edgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.edgeDetectionToolStripMenuItem.Text = "Edge Detection";
            // 
            // imageAlgebraToolStripMenuItem
            // 
            this.imageAlgebraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.substractToolStripMenuItem,
            this.nOTToolStripMenuItem});
            this.imageAlgebraToolStripMenuItem.Name = "imageAlgebraToolStripMenuItem";
            this.imageAlgebraToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.imageAlgebraToolStripMenuItem.Text = "Image Algebra";
            this.imageAlgebraToolStripMenuItem.Click += new System.EventHandler(this.imageAlgebraToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // substractToolStripMenuItem
            // 
            this.substractToolStripMenuItem.Name = "substractToolStripMenuItem";
            this.substractToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.substractToolStripMenuItem.Text = "Substract";
            this.substractToolStripMenuItem.Click += new System.EventHandler(this.substractToolStripMenuItem_Click);
            // 
            // nOTToolStripMenuItem
            // 
            this.nOTToolStripMenuItem.Name = "nOTToolStripMenuItem";
            this.nOTToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.nOTToolStripMenuItem.Text = "NOT";
            this.nOTToolStripMenuItem.Click += new System.EventHandler(this.nOTToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bilinearToolStripMenuItem1});
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.resizeToolStripMenuItem.Text = "Resize";
            // 
            // bilinearToolStripMenuItem1
            // 
            this.bilinearToolStripMenuItem1.Name = "bilinearToolStripMenuItem1";
            this.bilinearToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.bilinearToolStripMenuItem1.Text = "Bilinear";
            this.bilinearToolStripMenuItem1.Click += new System.EventHandler(this.bilinearToolStripMenuItem1_Click);
            // 
            // noiseToolStripMenuItem
            // 
            this.noiseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.reduceToolStripMenuItem});
            this.noiseToolStripMenuItem.Name = "noiseToolStripMenuItem";
            this.noiseToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.noiseToolStripMenuItem.Text = "Noise";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saltAndPepperToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            // 
            // saltAndPepperToolStripMenuItem
            // 
            this.saltAndPepperToolStripMenuItem.Name = "saltAndPepperToolStripMenuItem";
            this.saltAndPepperToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saltAndPepperToolStripMenuItem.Text = "Salt and Pepper";
            this.saltAndPepperToolStripMenuItem.Click += new System.EventHandler(this.saltAndPepperToolStripMenuItem_Click);
            // 
            // reduceToolStripMenuItem
            // 
            this.reduceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.medianToolStripMenuItem});
            this.reduceToolStripMenuItem.Name = "reduceToolStripMenuItem";
            this.reduceToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.reduceToolStripMenuItem.Text = "Reduce";
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "25%";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "50%";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "75%";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "100%";
            // 
            // histogramCheck
            // 
            this.histogramCheck.AutoSize = true;
            this.histogramCheck.Location = new System.Drawing.Point(16, 429);
            this.histogramCheck.Name = "histogramCheck";
            this.histogramCheck.Size = new System.Drawing.Size(73, 17);
            this.histogramCheck.TabIndex = 4;
            this.histogramCheck.Text = "Histogram";
            this.histogramCheck.UseVisualStyleBackColor = true;
            this.histogramCheck.CheckedChanged += new System.EventHandler(this.histogramCheck_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(13, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(614, 376);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_2);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // equalizationToolStripMenuItem
            // 
            this.equalizationToolStripMenuItem.Name = "equalizationToolStripMenuItem";
            this.equalizationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.equalizationToolStripMenuItem.Text = "Equalization";
            this.equalizationToolStripMenuItem.Click += new System.EventHandler(this.equalizationToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 468);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.histogramCheck);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem britnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem imageAlgebraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem substractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pPMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pP3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pP6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilinearToolStripMenuItem1;
        private System.Windows.Forms.CheckBox histogramCheck;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem tintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nOTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saltAndPepperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reduceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem bitSlicingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSegmentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizationToolStripMenuItem;
    }
}