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
    public class NoiseReduction
    {
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
                    color = pixelBuffer[p] * 0.3f;
                    color += pixelBuffer[p + 1] * 0.3f;
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
    }
}
