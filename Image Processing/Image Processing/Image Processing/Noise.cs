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
    public class Noise
    {
        // Noise Generation by randomly spread the salt and pepper 
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

                int R = pixelBuffer[p] - rnd.Next(-Size, Size + 1); ;
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

        // Median Filter tp remove the noise, with an option yo user to gray scale image 
        // the algorithm is worrking as follow:
        // get the matrix size, the matrix size represents a region in the photo
        // for example 3 x 3 .. represents 3 x 3 matrix that i am working to it to set the color of the median pixel
        public Bitmap Median(Bitmap Picture, int matrixSize, bool grayScale = false)
        {
            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] PixelOut = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            Picture.UnlockBits(sourceData);

            if (grayScale == true)
            {
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
            }

            byte[] midPixel;
            int filterMedian = (matrixSize - 1) / 2;
            List<int> adjcent = new List<int>();

            for (int newY = filterMedian; newY < Picture.Height - filterMedian; newY++)
            {
                for (int newX = filterMedian; newX < Picture.Width - filterMedian; newX++)
                {
                    int newByte = newY * sourceData.Stride + newX * 4;
                    adjcent.Clear();

                    for (int filterY = -filterMedian; filterY <= filterMedian; filterY++)
                    {
                        for (int filterX = -filterMedian; filterX <= filterMedian; filterX++)
                        {
                            int calculateAll = newByte + (filterX * 4) + (filterY * sourceData.Stride);
                            adjcent.Add(BitConverter.ToInt32(pixelBuffer, calculateAll));
                        }
                    }
                    adjcent.Sort();
                    midPixel = BitConverter.GetBytes(adjcent[filterMedian]);

                    PixelOut[newByte] = midPixel[0];
                    PixelOut[newByte + 1] = midPixel[1];
                    PixelOut[newByte + 2] = midPixel[2];
                    PixelOut[newByte + 3] = midPixel[3];
                }
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(PixelOut, 0, resData.Scan0, pixelBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }

        public void QSort(ref List<int> Arr, int LHS, int RHS)
        {
            int i = LHS;
            int j = RHS;
            int Pivot = Arr[(LHS + RHS) / 2];

            while (i <= j)
            {
                while (Arr[i] < Pivot) i++;
                while (Arr[j] > Pivot) j--;

                if (i <= j)
                {
                    int Tmp = Arr[i];
                    Arr[i] = Arr[j];
                    Arr[j] = Tmp;
                    i++;
                    j--;
                }
            }
            if (LHS < j) QSort(ref Arr, LHS, j);
            if (RHS > i) QSort(ref Arr, i, RHS);
        }
    }

}
