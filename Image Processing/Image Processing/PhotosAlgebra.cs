using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class PhotosAlgebra : Form
    {
        Bitmap FirstPicture, SecondPicture;

        public PhotosAlgebra()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        private void Open2_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = @"C:\My Documents\My Pictures";
            openFileDialog2.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF|" +
   "All files (*.*)|*.*";
            openFileDialog2.Multiselect = true;
            openFileDialog2.FilterIndex = 1;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                FirstPicture = new Bitmap(openFileDialog2.FileName);
                pictureBox2.BackgroundImage = new Bitmap(FirstPicture);
            }
        }

        private void Open3_Click(object sender, EventArgs e)
        {
            openFileDialog3.InitialDirectory = @"C:\My Documents\My Pictures";
            openFileDialog3.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF|" +
   "All files (*.*)|*.*";
            openFileDialog3.Multiselect = true;
            openFileDialog3.FilterIndex = 1;

            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                SecondPicture = new Bitmap(openFileDialog3.FileName);
                pictureBox3.BackgroundImage = new Bitmap(SecondPicture);
            }
        }

        public Bitmap AddPictures(Bitmap First, Bitmap Second)
        {
            Bitmap Result = new Bitmap(First);
            Color Col1 = new Color();
            Color Col2 = new Color();
            int Width, Height;

            //if (First.Width > Second.Width) Width = First.Width;
            //else Width = Second.Width;

            //if (First.Height > Second.Height) Height = First.Height;
            //else Height = Second.Height;

            for (int x = 0; x < First.Width; x++)
            {
                for (int y = 0; y < First.Height; y++)
                {
                    Col1 = First.GetPixel(x, y);
                    Col2 = Second.GetPixel(x, y);

                    Result.SetPixel(x, y, Color.FromArgb(Math.Abs(Col1.R - Col2.R), 
                        Math.Abs(Col1.G - Col2.G), Math.Abs(Col1.B - Col2.B)));
                }
            }
            return Result;
        }

        private void PhotosAlgebra_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            Bitmap Result = AddPictures(FirstPicture, SecondPicture);
            pictureBox2.BackgroundImage = new Bitmap(Result);
        }
    }
}
