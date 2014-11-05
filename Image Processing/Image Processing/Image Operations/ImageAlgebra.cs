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
    public class ImageAlgebra
    {
        GeometricOperationsMatrices geoOperation;

        public ImageAlgebra()
        {

        }

        public Bitmap subtract(Bitmap first, Bitmap second)
        {
            this.geoOperation = new GeometricOperationsMatrices(second);

            float widthFactor = (float)first.Width / second.Width;
            float heightFactor = (float)first.Height / second.Height;

            Bitmap newSecond = this.geoOperation.scale((float)widthFactor, (float)heightFactor);

            BitmapData sourceData1 = first.LockBits(new Rectangle(0, 0, first.Width, first.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer1 = new byte[sourceData1.Stride * sourceData1.Height];

            Marshal.Copy(sourceData1.Scan0, pixelBuffer1, 0, pixelBuffer1.Length);
            first.UnlockBits(sourceData1);

            BitmapData sourceData2 = newSecond.LockBits(new Rectangle(0, 0, newSecond.Width, newSecond.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer2 = new byte[sourceData2.Stride * sourceData2.Height];

            Marshal.Copy(sourceData2.Scan0, pixelBuffer2, 0, pixelBuffer2.Length);
            newSecond.UnlockBits(sourceData2);

            byte[] resultedBuffer = new byte[sourceData2.Stride * sourceData2.Height];

            float color = 0;

            for (int p = 0; p < pixelBuffer1.Length; p += 4)
            {
                color = pixelBuffer1[p] - pixelBuffer2[p];
                resultedBuffer[p] = (byte)color;

                color = pixelBuffer1[p + 1] - pixelBuffer2[p + 1];
                resultedBuffer[p + 1] = (byte)color;

                color = pixelBuffer1[p + 2] - pixelBuffer2[p + 2];

                resultedBuffer[p + 2] = (byte)color;

                resultedBuffer[p + 3] = 255;
            }

            Bitmap resBitmap = new Bitmap(first.Width, first.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(resultedBuffer, 0, resData.Scan0, resultedBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
            
        }

        public Bitmap add(Bitmap first, Bitmap second, float fraction)
        {
            this.geoOperation = new GeometricOperationsMatrices(second);

            float widthFactor = (float)first.Width / second.Width;
            float heightFactor = (float)first.Height / second.Height;

            Bitmap newSecond = this.geoOperation.scale((float)widthFactor, (float)heightFactor);

            BitmapData sourceData1 = first.LockBits(new Rectangle(0, 0, first.Width, first.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer1 = new byte[sourceData1.Stride * sourceData1.Height];

            Marshal.Copy(sourceData1.Scan0, pixelBuffer1, 0, pixelBuffer1.Length);
            first.UnlockBits(sourceData1);

            BitmapData sourceData2 = newSecond.LockBits(new Rectangle(0, 0, newSecond.Width, newSecond.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer2 = new byte[sourceData2.Stride * sourceData2.Height];

            Marshal.Copy(sourceData2.Scan0, pixelBuffer2, 0, pixelBuffer2.Length);
            newSecond.UnlockBits(sourceData2);

            byte[] resultedBuffer = new byte[sourceData2.Stride * sourceData2.Height];

            float color = 0;

            for (int p = 0; p < pixelBuffer1.Length; p += 4)
            {
                color = pixelBuffer1[p] * fraction + pixelBuffer2[p] * (1 - fraction);
                resultedBuffer[p] = (byte)color;

                color = pixelBuffer1[p + 1] * fraction + pixelBuffer2[p + 1] * (1 - fraction);
                resultedBuffer[p + 1] = (byte)color;

                color = pixelBuffer1[p + 2] * fraction + pixelBuffer2[p + 2] * (1 - fraction);

                resultedBuffer[p + 2] = (byte)color;

                resultedBuffer[p + 3] = 255;
            }

            Bitmap resBitmap = new Bitmap(first.Width, first.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(resultedBuffer, 0, resData.Scan0, resultedBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;

        }

        public Bitmap negateImage(Bitmap image)
        {
            BitmapData sourceData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            image.UnlockBits(sourceData);

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

            Bitmap resBitmap = new Bitmap(image.Width, image.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resData.Scan0, pixelBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }

    }
}
