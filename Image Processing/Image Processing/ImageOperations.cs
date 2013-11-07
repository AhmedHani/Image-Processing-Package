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
    public class ImageOperations
    {
        public Bitmap GrayScale(Bitmap Picture)
        {
            Color Col = new Color();

            for (int x = 0; x < Picture.Width; x++)
            {
                for (int y = 0; y < Picture.Height; y++)
                {
                    Col = Picture.GetPixel(x, y);
                    byte Gray = (byte)(0.290 * Col.R + 0.590 * Col.G + 0.110 * Col.B);
                    Picture.SetPixel(x, y, Color.FromArgb(Gray, Gray, Gray));
                }
            }
            return Picture;
        }

        public Bitmap Brightness(Bitmap Picture, int Bright)
        {
            Color Col = new Color();
            if (Bright > 255) Bright = 255;
            if (Bright < -255) Bright = 255;

            for (int x = 0; x < Picture.Width; x++)
            {
                for (int y = 0; y < Picture.Height; y++)
                {
                    Col = Picture.GetPixel(x, y);
                    int ColorR = Col.R + Bright;
                    int ColorG = Col.G + Bright;
                    int ColorB = Col.B + Bright;

                    if (ColorR < 0) ColorR = 1;
                    if (ColorR > 255) ColorR = 255;

                    if (ColorG < 0) ColorG = 1;
                    if (ColorG > 255) ColorG = 255;

                    if (ColorB < 0) ColorB = 1;
                    if (ColorB > 255) ColorB = 255;

                    Picture.SetPixel(x, y, Color.FromArgb((byte)ColorR, (byte)ColorG, (byte)ColorB));
                }
            }
            return Picture; 
        }

        public Bitmap Invert(Bitmap Picture)
        {
            Color Col = new Color();

            for (int x = 0; x < Picture.Width; x++)
            {
                for (int y = 0; y < Picture.Height; y++)
                {
                    Col = Picture.GetPixel(x, y);
                    Picture.SetPixel(x, y, Color.FromArgb(255 - Col.R, 255 - Col.G, 255 - Col.B));
                }
            }
            return Picture;
        }

        public Bitmap Gamma(Bitmap Picture, double Red, double Green, double Blue) 
        {
            byte[] RedGamma = GammaArrays(Red);
            byte[] GreenGamma = GammaArrays(Green);
            byte[] BlueGamma = GammaArrays(Blue);
            Color Col = new Color();

            for (int x = 0; x < Picture.Width; x++)
            {
                for (int y = 0; y < Picture.Height; y++)
                {
                    Col = Picture.GetPixel(x, y);
                    Picture.SetPixel(x, y, Color.FromArgb(RedGamma[Col.R], GreenGamma[Col.G], BlueGamma[Col.B]));
                }
            }
            return Picture;
        }

        private byte[] GammaArrays(double Col)
        {
            byte[] Arr = new byte[255 + 1];

            for (int i = 0; i < 255 + 1; i++)
            {
                Arr[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / Col)) + 0.5));
            }
            return Arr;
        }

        public Bitmap Contrast(Bitmap Picture, double ContrastValue)
        {
            Color Col = new Color();

            if (ContrastValue > 100) ContrastValue = 100;
            if (ContrastValue < -100) ContrastValue = -100;

            ContrastValue = (ContrastValue + 100.0) / 100.0;
            ContrastValue = ContrastValue * ContrastValue;

            for (int x = 0; x < Picture.Width; x++)
            {
                for (int y = 0; y < Picture.Height; y++)
                {
                    Col = Picture.GetPixel(x, y);
                    double PixelRed = Col.R / 255.0;
                    PixelRed -= 0.5;
                    PixelRed *= ContrastValue;
                    PixelRed += 0.5;
                    PixelRed *= 255;

                    if (PixelRed > 255) PixelRed = 255;
                    if (PixelRed < 0) PixelRed = 0;

                    double PixelGreen = Col.G / 255.0;
                    PixelGreen -= 0.5;
                    PixelGreen *= ContrastValue;
                    PixelGreen += 0.5;
                    PixelGreen *= 255;

                    if (PixelGreen > 255) PixelGreen = 255;
                    if (PixelGreen < 0) PixelGreen = 0;

                    double PixelBlue = Col.B / 255.0;
                    PixelBlue -= 0.5;
                    PixelBlue *= ContrastValue;
                    PixelBlue += 0.5;
                    PixelBlue *= 255;

                    if (PixelBlue > 255) PixelBlue = 255;
                    if (PixelBlue < 0) PixelBlue = 0;

                    Picture.SetPixel(x, y, Color.FromArgb((byte)PixelRed, (byte)PixelGreen, (byte)PixelBlue));
                }
            }
            return Picture;
        }
    }
}
