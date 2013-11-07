using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class Main : Form 
    {
        Bitmap UserPicture, First, Second;
        DialogResult DR;
        ReadPPM PPM;
        ImageOperations Process;
 
        public Main()
        {
            InitializeComponent();
            PPM = new ReadPPM();
            Process = new ImageOperations();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\My Documents\My Pictures";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF|" +
   "All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                UserPicture = new Bitmap(openFileDialog1.FileName);
                pictureBox1.BackgroundImage = new Bitmap(UserPicture);
            }

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
            using(Graphics G = Graphics.FromImage(Result)) 
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
            Resize Result = new Resize();
            Result.Width = UserPicture.Width;
            Result.Height = UserPicture.Height;
            Result.BilinearCheck = true;
            if (DialogResult.OK == Result.ShowDialog())
            {
                UserPicture = BilinearResize(UserPicture, Result.Width, Result.Height, Result.BilinearCheck);
                pictureBox1.BackgroundImage = new Bitmap(UserPicture);
                this.Invalidate();
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Temp = Process.GrayScale(UserPicture);
            Bitmap Result = new Bitmap(Temp);
            pictureBox1.BackgroundImage = new Bitmap(Result);
        }

        private void britnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopWindow pop = new PopWindow();

            if (DialogResult.OK == pop.ShowDialog())
            {
                Bitmap Temp = Process.Brightness(UserPicture, pop.Value);
                Bitmap Result = new Bitmap(Temp);
                pictureBox1.BackgroundImage = new Bitmap(Result);
                this.Invalidate();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Temp = Process.Invert(UserPicture);
            Bitmap Result = new Bitmap(Temp);
            pictureBox1.BackgroundImage = new Bitmap(Result);
            this.Invalidate();
        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GammaForm Input = new GammaForm();
            Input.Red = Input.Green = Input.Blue = 1.0;

            if (DialogResult.OK == Input.ShowDialog())
            {
                Bitmap Temp = Process.Gamma(UserPicture, Input.Red, Input.Green, Input.Blue);
                Bitmap Result = new Bitmap(Temp);
                pictureBox1.BackgroundImage = new Bitmap(Result);
                this.Invalidate();
            }
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContrastForm Input = new ContrastForm();
            Input.Value = 1.0;

            if (DialogResult.OK == Input.ShowDialog())
            {
                Bitmap Temp = Process.Contrast(UserPicture, Input.Value);
                Bitmap Result = new Bitmap(Temp);
                pictureBox1.BackgroundImage = new Bitmap(Result);
                this.Invalidate();
            }
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhotosAlgebra Add = new PhotosAlgebra();
            Add.ShowDialog();
        }
    }
}
