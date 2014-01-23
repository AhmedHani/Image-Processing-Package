using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Image_Processing
{
    public class ImageOperations
    {
        // Instead of using Bitmap Class, i used a 1D array to represent the input image
        // byte[] pixelBuffer is the array that holds image's pixels
        // size of this array is the height of the picture multiplied by a Stride function that gets the length 
        // of the Row of pixels rounded to 4 byte-boundry
        // a pixel color will bre represented by an index for byte of color, 3 indices for Red && Green && Blue 

        // Grayscalling an image by iteratring through the array of bytes and multiply each pixel colors by a factor 
        public Bitmap GrayScale(Bitmap Picture)
        {
            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb); // get the bitmap data

            //Stride to get the pixels rounded up to 4 bytes (Color, RED, GREEN, BLUE)
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Picture.UnlockBits(sourceData);
            float color = 0;

            for (int p = 0; p < pixelBuffer.Length; p += 4)
            {
                color = pixelBuffer[p] * 0.20f;
                color += pixelBuffer[p + 1] * 0.50f;
                color += pixelBuffer[p + 2] * 0.3f;

                pixelBuffer[p] = (byte)color;
                pixelBuffer[p + 1] = pixelBuffer[p];
                pixelBuffer[p + 2] = pixelBuffer[p];
                pixelBuffer[p + 3] = 255;
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resData.Scan0, pixelBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }

        //Increasing the photo's brigtness by increasing the colors by the user input 
        public Bitmap Brightness(Bitmap Picture, int Bright)
        {
            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Picture.UnlockBits(sourceData);
            float color = 0;
       
            if (Bright > 255) Bright = 255;
            if (Bright < -255) Bright = 255;

            for (int p = 0; p < pixelBuffer.Length; p += 4)
            {
                color = pixelBuffer[p];
                color += pixelBuffer[p + 1];
                color += pixelBuffer[p + 2];

                int R = pixelBuffer[p] + Bright ;
                int G = pixelBuffer[p + 1] + Bright;
                int B = pixelBuffer[p + 2] + Bright;

                if (R < 0) R = 1;
                if (R > 255) R = 255;

                if (G < 0) G = 1;
                if (G > 255) G = 255;

                if (B < 0) B = 1;
                if (B > 255) B = 255;

                pixelBuffer[p] = (byte)R;
                pixelBuffer[p + 1] = (byte)G;
                pixelBuffer[p + 2] = (byte)B;
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resData.Scan0, pixelBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }

        // Invert the images color
        public Bitmap Invert(Bitmap Picture)
        {
            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Picture.UnlockBits(sourceData);
            float color = 0;

            for (int p = 0; p < pixelBuffer.Length; p += 4)
            {
                color = pixelBuffer[p];
                color += pixelBuffer[p + 1];
                color += pixelBuffer[p + 2];

                pixelBuffer[p] = (byte)(255 - pixelBuffer[p]);
                pixelBuffer[p + 1] = (byte)(255 - pixelBuffer[p + 1]);
                pixelBuffer[p + 2] = (byte)(255 - pixelBuffer[p + 2]);
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resData.Scan0, pixelBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
            
        }

        // Gamma Correction using a helper function to calculate the formula
        public Bitmap Gamma(Bitmap Picture, double Red, double Green, double Blue) 
        {
            byte[] RedGamma = GammaArrays(Red);
            byte[] GreenGamma = GammaArrays(Green);
            byte[] BlueGamma = GammaArrays(Blue);

            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Picture.UnlockBits(sourceData);
            float color = 0;

            for (int p = 0; p < pixelBuffer.Length; p += 4)
            {
                color = pixelBuffer[p];
                color += pixelBuffer[p + 1];
                color += pixelBuffer[p + 2];

                pixelBuffer[p] = (byte)RedGamma[pixelBuffer[p]];
                pixelBuffer[p + 1] = (byte)GreenGamma[pixelBuffer[p + 1]]; 
                pixelBuffer[p + 2] = (byte)BlueGamma[pixelBuffer[p + 2]]; 
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resData.Scan0, pixelBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
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

        // Contrasting photo
        public Bitmap Contrast(Bitmap Picture, double ContrastValue)
        {
            if (ContrastValue > 100) ContrastValue = 100;
            if (ContrastValue < -100) ContrastValue = -100;

            ContrastValue = (ContrastValue + 100.0) / 100.0;
            ContrastValue = ContrastValue * ContrastValue;

            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Picture.UnlockBits(sourceData);
            float color = 0;

            for (int p = 0; p < pixelBuffer.Length; p += 4)
            {
                color = pixelBuffer[p];
                color += pixelBuffer[p + 1];
                color += pixelBuffer[p + 2];
                
                // New Color = (((((OldColor / 255.0) - 0.5) * ContrastValue) + 0.5) + 255.0
                double pixelRed = pixelBuffer[p] / 255.0;
                pixelRed -= 0.5;
                pixelRed *= ContrastValue;
                pixelRed += 0.5;
                pixelRed *= 255;

                if (pixelRed > 255) pixelRed = 255;
                if (pixelRed < 0) pixelRed = 0;

                double pixelGreen = pixelBuffer[p + 1] / 255.0;
                pixelGreen -= 0.5;
                pixelGreen *= ContrastValue;
                pixelGreen += 0.5;
                pixelGreen *= 255;

                if (pixelGreen > 255) pixelGreen = 255;
                if (pixelGreen < 0) pixelGreen = 0;

                double pixelBlue = pixelBuffer[p + 2] / 255.0;
                pixelBlue -= 0.5;
                pixelBlue *= ContrastValue;
                pixelBlue += 0.5;
                pixelBlue *= 255;

                if (pixelBlue > 255) pixelBlue = 255;
                if (pixelBlue < 0) pixelBlue = 0;

                pixelBuffer[p] = (byte)pixelRed;
                pixelBuffer[p + 1] = (byte)pixelGreen;
                pixelBuffer[p + 2] = (byte)pixelBlue;
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resData.Scan0, pixelBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }

        // make the colors tinted
        public Bitmap Tint(Bitmap Picture, float _red, float _green, float _blue)
        {
            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Picture.UnlockBits(sourceData);
            float color = 0;

            for (int p = 0; p < pixelBuffer.Length; p += 4)
            {
                color = pixelBuffer[p];
                color += pixelBuffer[p + 1];
                color += pixelBuffer[p + 2];

                // New Color = OldColor + (255 - OldColor) * ColorTintedValue
                double R = pixelBuffer[p] + (255 - pixelBuffer[p]) * _red;
                double G = pixelBuffer[p + 1] + (255 - pixelBuffer[p + 1]) * _green;
                double B = pixelBuffer[p + 2] + (255 - pixelBuffer[p + 2]) * _blue;

                //if (R < 0) R = 1;
                if (R > 255) R = 255;

                //if (G < 0) G = 1;
                if (G > 255) G = 255;

                //if (B < 0) B = 1;
                if (B > 255) B = 255;

                pixelBuffer[p] = (byte)R;
                pixelBuffer[p + 1] = (byte)G;
                pixelBuffer[p + 2] = (byte)B;
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resData.Scan0, pixelBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }

    }
}
