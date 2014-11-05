using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image_Processing;
using Image_Processing.Image_Operations;
using Image_Processing.Netpbm_format;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Image_Processing
{

    public partial class Main : Form
    {
        #region Class Variables
        Bitmap UserPicture;

        NeighborOperations neighbourOperation;
        PixelOperations pixelOperation;
        GeometricOperationsNaive geometricOperationNaive;
        GeometricOperationsMatrices geometricOperationMatrices;

        NoiseGeneration noiseGeneration;
        NoiseReduction noiseReduction;

        ImageAlgebra imageAlgebra;

        PPM openPPMFiles;
       
        #endregion

        public Main()
        {
            InitializeComponent();
           

            this.pixelOperation = new PixelOperations();
            this.geometricOperationNaive = new GeometricOperationsNaive();
            this.neighbourOperation = new NeighborOperations();
            this.noiseGeneration = new NoiseGeneration();
            this.noiseReduction = new NoiseReduction();
            this.imageAlgebra = new ImageAlgebra();

            this.CenterToScreen();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        Bitmap PicEditBox(Bitmap Picture)
        {
            int H, W;
            if (Picture.Height < Picture.Width)
            {
                W = 500;
                H = (int)(700 * ((float)Picture.Height / (float)Picture.Width));
            }
            else
            {
                H = 500;
                W = (int)(500 * ((float)Picture.Height / (float)Picture.Width));
            }
            return CustomeResize(Picture, 0, 0, W, H);
        }

        private static Bitmap CustomeResize(Bitmap SourcePicture, int Start, int End, int width, int height)
        {
            Bitmap Result = new Bitmap(width, height);
            using (Graphics G = Graphics.FromImage(Result))
            {
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.InterpolationMode = InterpolationMode.HighQualityBilinear;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.DrawImage(SourcePicture, Start, End, height, width);
            }
            return Result;
        }

        public static Bitmap BilinearResize(Bitmap Picture, int Width, int Height, bool BilinearCheck)
        {
            if (BilinearCheck == true)
            {
                double YScale, XScale;
                Color Up, Down, Left, Right;
                Up = new Color();
                Down = new Color();
                Left = new Color();
                Right = new Color();
                byte RED, GREEN, BLUE;
                byte First, Second;
                Bitmap Temp = (Bitmap)Picture.Clone();
                Picture = new Bitmap(Width, Height, Temp.PixelFormat);
                double XFactor = (double)Temp.Width / (double)Width;
                double YFactor = (double)Temp.Height / (double)Height;

                for (int x = 0; x < Picture.Width; x++)
                {
                    for (int y = 0; y < Picture.Height; y++)
                    {
                        int XFloor = (int)Math.Floor(x * XFactor);
                        int XCeil = XFloor + 1;
                        int YFloor = (int)Math.Floor(y * YFactor);
                        int YCeil = YFloor + 1;

                        if (XCeil >= Picture.Width) XCeil = XFloor;
                        if (YCeil >= Picture.Height) YCeil = YFloor;

                        XScale = x * XFactor - XFloor;
                        YScale = y * YFactor - YFloor;

                        double XSubs1 = 1.0 - XScale;
                        double YSub1 = 1.0 - YScale;

                        Up = Temp.GetPixel(XCeil, YCeil);
                        Down = Temp.GetPixel(XFloor, YFloor);
                        Left = Temp.GetPixel(XFloor, YCeil);
                        Right = Temp.GetPixel(XCeil, YFloor);

                        // RED
                        First = (byte)(XSubs1 * Down.R + XScale * Right.R);
                        Second = (byte)(XSubs1 * Left.R + XScale * Up.R);
                        RED = (byte)(YSub1 * (double)(First) + YScale * (double)(Second));

                        // BLUE
                        First = (byte)(XSubs1 * Down.B + XScale * Right.B);
                        Second = (byte)(XSubs1 * Left.B + XScale * Up.B);
                        BLUE = (byte)(YSub1 * (double)(First) + YScale * (double)(Second));

                        //GREEN
                        First = (byte)(XSubs1 * Down.G + XScale * Right.G);
                        Second = (byte)(XSubs1 * Left.G + XScale * Up.G);
                        GREEN = (byte)(YSub1 * (double)(First) + YScale * (double)(Second));

                        Picture.SetPixel(x, y, Color.FromArgb(255, RED, GREEN, BLUE));
                    }
                }
                return Picture;
            }
            else
            {
                return Picture;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bilinearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Temp = pixelOperation.GrayScale(UserPicture);
            Bitmap Result = new Bitmap(Temp);
            pictureBox1.Image = new Bitmap(Result);
            UserPicture = Result;
        }

        private void britnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrightnessForm pop = new BrightnessForm();

            if (DialogResult.OK == pop.ShowDialog())
            {
                Bitmap Temp = pixelOperation.Brightness(UserPicture, pop.Value);
                Bitmap Result = new Bitmap(Temp);
                pictureBox1.Image = new Bitmap(Result);
                this.Invalidate();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Temp = pixelOperation.Invert(UserPicture);
            Bitmap Result = new Bitmap(Temp);
            pictureBox1.Image = new Bitmap(Result);
            this.Invalidate();
        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GammaForm Input = new GammaForm();
            Input.Red = Input.Green = Input.Blue = 1.0;

            if (DialogResult.OK == Input.ShowDialog())
            {
                Bitmap Temp = pixelOperation.Gamma(UserPicture, Input.Red, Input.Green, Input.Blue);
                Bitmap Result = new Bitmap(Temp);
                pictureBox1.Image = new Bitmap(Result);

                this.Invalidate();
            }
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContrastForm Input = new ContrastForm();
            Input.Value = 1.0;

            if (DialogResult.OK == Input.ShowDialog())
            {
                Bitmap Temp = pixelOperation.Contrast(UserPicture, Input.Value);
                Bitmap Result = new Bitmap(Temp);
                pictureBox1.Image = new Bitmap(Result);
                this.Invalidate();
            }
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotationForm rotate = new RotationForm();
            this.geometricOperationMatrices = new GeometricOperationsMatrices(UserPicture);
            rotate.AngleValue = 0.0;

            if (DialogResult.OK == rotate.ShowDialog())
            {
                Bitmap result = geometricOperationMatrices.rotation(rotate.AngleValue);
                pictureBox1.Image = result;
                //pictureBox1.Width = result.Width;
               // pictureBox1.Height = result.Height;
                ;

                this.Invalidate();
            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = @"C:\My Documents\My Pictures";
            openFileDialog2.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF|" +
   "All files (*.*)|*.*";
            openFileDialog2.Multiselect = true;
            openFileDialog2.FilterIndex = 1;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Bitmap imageInput = new Bitmap(openFileDialog2.FileName);
                
                AddForm af = new AddForm();
                af.FractionValue = 0.0;

                if (DialogResult.OK == af.ShowDialog())
                {
                    pictureBox1.Image = imageAlgebra.add(UserPicture, imageInput, (float)af.FractionValue);
                }
                
            }
            
        }

        private void imageAlgebraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = @"C:\My Documents\My Pictures";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF|" +
   "All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);

                this.openPPMFiles = new PPM(fs);
                UserPicture = this.openPPMFiles.ReadPPM3();

                pictureBox1.Height = UserPicture.Height;
                pictureBox1.Width = UserPicture.Width;

                //this.Size = new Size(UserPicture.Width, UserPicture.Height);
                pictureBox1.Image = new Bitmap(UserPicture);
            }
        }

        private void pP6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\My Documents\My Pictures";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF|" +
   "All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);

                this.openPPMFiles = new PPM(fs);
                UserPicture = this.openPPMFiles.ReadPPM6();

                pictureBox1.Height = UserPicture.Height;
                pictureBox1.Width = UserPicture.Width;

                //this.Size = new Size(UserPicture.Width, UserPicture.Height);
                pictureBox1.Image = new Bitmap(UserPicture);
            }
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\My Documents\My Pictures";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF|" +
   "All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap imageInput = new Bitmap(openFileDialog1.FileName);
                UserPicture = new Bitmap(imageInput);

                //pictureBox1.Height = UserPicture.Height;
                //pictureBox1.Width = UserPicture.Width;

                //this.Size = new Size(UserPicture.Width, UserPicture.Height);
                pictureBox1.Image = new Bitmap(UserPicture);
            }

        }

        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScaleForm scale = new ScaleForm();
            scale.ScaleXValue = scale.ScaleYValue = 0.0;
            this.geometricOperationMatrices = new GeometricOperationsMatrices(UserPicture);

            if (DialogResult.OK == scale.ShowDialog())
            {
                Bitmap result = geometricOperationMatrices.scale(scale.ScaleXValue, scale.ScaleYValue);
               // pictureBox1.Width = result.Width;
                //pictureBox1.Height = result.Height;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox1.Image = result;
                MessageBox.Show(result.Width + " " + result.Height);

                this.Invalidate();
            }
        }

        private void shearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShearForm shear = new ShearForm();
            shear.ShearXValue = shear.ShearYValue = 0.0;

            if (DialogResult.OK == shear.ShowDialog())
            {
                Bitmap result = geometricOperationNaive.shear(UserPicture, shear.ShearXValue, shear.ShearYValue);
                pictureBox1.Image = result;
                this.Invalidate();
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSS rss = new RSS();

            rss.ScaleX = rss.ScaleY = 1f;
            rss.Angle = 0f;
            rss.ShearX = rss.ShearY = 1f;

            this.geometricOperationMatrices = new GeometricOperationsMatrices(UserPicture);

            if (DialogResult.OK == rss.ShowDialog())
            {
                Bitmap result = geometricOperationMatrices.rotateAndScaleAndShear(rss.Angle, rss.ScaleX, rss.ScaleY, rss.ShearX, rss.ShearY);
                pictureBox1.Width = result.Width;
                pictureBox1.Height = result.Height;
                pictureBox1.Image = result;

                this.Invalidate();
            }
        }

        private void bilinearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Resize Result = new Resize();
            Result.Width = UserPicture.Width;
            Result.Height = UserPicture.Height;
            Result.BilinearCheck = true;
            if (DialogResult.OK == Result.ShowDialog())
            {
                UserPicture = BilinearResize(UserPicture, Result.Width, Result.Height, Result.BilinearCheck);
                pictureBox1.Image = new Bitmap(UserPicture);
                this.Invalidate();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap savedImage = new Bitmap(pictureBox1.Image);
                savedImage.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
            }
        }

        private void tintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TintForm tf = new TintForm();
            tf.Red = tf.Green = tf.Blue = 0.0;

            if (DialogResult.OK == tf.ShowDialog())
            {
                Bitmap result = pixelOperation.Tint(UserPicture, (float)tf.Red, (float)tf.Green, (float)tf.Blue);
                pictureBox1.Image = result;
                this.Invalidate();
            }


        }

        private void saltAndPepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaltAndPepperForm sp = new SaltAndPepperForm();
            sp.Size = 0;

            if (DialogResult.OK == sp.ShowDialog())
            {
                Bitmap res = noiseGeneration.NoiseGenerate(UserPicture, sp.Size);
                pictureBox1.Image = res;
                this.Invalidate();
            }
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedianFilterForm mdf = new MedianFilterForm();
            mdf.WindowSize = 3;
            mdf.GrayScale = false;

            if (DialogResult.OK == mdf.ShowDialog())
            {
                Bitmap res = noiseReduction.Median(UserPicture, mdf.WindowSize, mdf.GrayScale);
                pictureBox1.Image = res;
                this.Invalidate();
            }
        }

        private void nOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap temp = imageAlgebra.negateImage(UserPicture);
            pictureBox1.Image = new Bitmap(temp);
            this.Invalidate();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void substractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = @"C:\My Documents\My Pictures";
            openFileDialog2.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF|" +
   "All files (*.*)|*.*";
            openFileDialog2.Multiselect = true;
            openFileDialog2.FilterIndex = 1;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Bitmap imageInput = new Bitmap(openFileDialog2.FileName);

                pictureBox1.Image = imageAlgebra.subtract(UserPicture, imageInput);
            }
        }

        private void bitSlicingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BitSlicing bs = new BitSlicing();
            bs.MaskValue = 0;
            bs.GrayScale = false;

            if (DialogResult.OK == bs.ShowDialog())
            {
                Bitmap Temp = pixelOperation.bitSlicing(UserPicture, bs.MaskValue, bs.GrayScale);
                Bitmap Result = new Bitmap(Temp);
                pictureBox1.Image = new Bitmap(Result);
                UserPicture = Result;
                this.Invalidate();
            }
        }

        private void histogramCheck_CheckedChanged(object sender, EventArgs e)
        {
            Histogram h = new Histogram();
            //List<int> red, green, blue;
            int[] red = new int[256];
            int[] green = new int[256];
            int[] blue = new int[256];
            
            this.getRGB(ref red, ref green, ref blue);

            h.setData(red, green, blue);
            h.drawHistogram();

            h.Show();
        }

        private void getRGB(ref int[] red, ref int[] green, ref int[] blue)
        {
            BitmapData sourceData = UserPicture.LockBits(new Rectangle(0, 0, UserPicture.Width, UserPicture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            UserPicture.UnlockBits(sourceData);
            float color = 0;

            for (int p = 0; p < pixelBuffer.Length; p += 4)
            {
                red[pixelBuffer[p]]++;
                green[pixelBuffer[p + 1]]++;
                blue[pixelBuffer[p + 2]]++;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void equalizationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
