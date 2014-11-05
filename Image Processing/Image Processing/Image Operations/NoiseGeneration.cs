using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing.Image_Operations
{
    public class NoiseGeneration
    {
        public Bitmap NoiseGenerate(Bitmap Picture, int Size)
        {
            Random rnd = new Random();
            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] PixelOut = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            Picture.UnlockBits(sourceData);
            float color = 0;

            for (int p = 0; p < pixelBuffer.Length; p += 4)
            {
                color = pixelBuffer[p];
                color += pixelBuffer[p + 1];
                color += pixelBuffer[p + 2];

                int R = pixelBuffer[p] - rnd.Next(-Size, Size + 1);
                int G = pixelBuffer[p + 1] - rnd.Next(-Size, Size + 1);
                int B = pixelBuffer[p + 2] - rnd.Next(-Size, Size + 1); ;

                if (R > 255) R = 255;
                if (R < 0) R = 0;

                if (G > 255) G = 255;
                if (G < 0) G = 0;

                if (B > 255) B = 255;
                if (B < 0) B = 0;

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
