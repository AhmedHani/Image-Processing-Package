using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing.Image_Operations
{
    public class GeometricOperationsNaive
    {
        
        private Point shearFormula(Point currentPoint, double shearX, double shearY)
        {
            Point resultedPoint = new Point();

            resultedPoint.X = (int)(Math.Round(currentPoint.X + shearX * currentPoint.Y));
            resultedPoint.Y = (int)(Math.Round(currentPoint.Y + shearY * currentPoint.X));

            return resultedPoint;
        }

        public Bitmap shear(Bitmap Picture, double shearX, double shearY)
        {
            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultedBuffer = new byte[sourceData.Stride * sourceData.Height];

            Point currentPoint = new Point();
            Point resultedPoint = new Point();

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Picture.UnlockBits(sourceData);
            float color = 0;

            Rectangle imageArea = new Rectangle(0, 0, Picture.Width, Picture.Height);

            for (int i = 0; i < Picture.Height; i++)
            {
                for (int j = 0; j < Picture.Width; j++)
                {
                    int currentSourceData = i * sourceData.Stride + j * 4;

                    currentPoint.X = i;
                    currentPoint.Y = j;

                    if (currentSourceData >= 0 && currentSourceData + 3 < pixelBuffer.Length)
                    {
                        resultedPoint = shearFormula(currentPoint, shearX, shearY);
                        int currentResultedPointData = resultedPoint.Y * sourceData.Stride + resultedPoint.X * 4;

                        if (imageArea.Contains(resultedPoint) && currentResultedPointData >= 0)
                        {
                            if (currentResultedPointData + 3 < resultedBuffer.Length)
                            {
                                resultedBuffer[currentResultedPointData] = pixelBuffer[currentSourceData];
                                resultedBuffer[currentResultedPointData + 1] = pixelBuffer[currentSourceData + 1];
                                resultedBuffer[currentResultedPointData + 2] = pixelBuffer[currentSourceData + 2];
                                resultedBuffer[currentResultedPointData + 3] = 255; // 
                            }

                            if (currentResultedPointData - 3 >= 0)
                            {
                                resultedBuffer[currentResultedPointData - 4] = pixelBuffer[currentSourceData];
                                resultedBuffer[currentResultedPointData - 3] = pixelBuffer[currentSourceData + 1];
                                resultedBuffer[currentResultedPointData - 2] = pixelBuffer[currentSourceData + 2];
                                resultedBuffer[currentResultedPointData - 1] = 255; // 
                            }
                        }
                    }
                }
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(resultedBuffer, 0, resData.Scan0, resultedBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }

        private Point rotationFormula(Point currentPoint, double angle)
        {
            Point resultedPoint = new Point();

            resultedPoint.X = (int)(Math.Round(currentPoint.X * Math.Cos(angle) + Math.Sin(angle) * currentPoint.Y));
            resultedPoint.Y = (int)(Math.Round(-1 * (currentPoint.X * Math.Sin(angle)) + Math.Cos(angle) * currentPoint.Y));

            return resultedPoint;
        }

        public Bitmap rotation(Bitmap Picture, double angle)
        {
            BitmapData sourceData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultedBuffer = new byte[sourceData.Stride * sourceData.Height];

            Point currentPoint = new Point();
            Point resultedPoint = new Point();

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Picture.UnlockBits(sourceData);
            float color = 0;

            Rectangle imageArea = new Rectangle(0, 0, Picture.Width, Picture.Height);

            for (int i = 0; i < Picture.Height; i++)
            {
                for (int j = 0; j < Picture.Width; j++)
                {
                    int currentSourceData = i * sourceData.Stride + j * 4;

                    currentPoint.X = i;
                    currentPoint.Y = j;

                    if (currentSourceData >= 0 && currentSourceData + 3 < pixelBuffer.Length)
                    {
                        resultedPoint = rotationFormula(currentPoint, angle);
                        int currentResultedPointData = resultedPoint.Y * sourceData.Stride + resultedPoint.X * 4;

                        if (imageArea.Contains(resultedPoint) && currentResultedPointData >= 0)
                        {
                            if (currentResultedPointData + 3 < resultedBuffer.Length)
                            {
                                resultedBuffer[currentResultedPointData] = pixelBuffer[currentSourceData];
                                resultedBuffer[currentResultedPointData + 1] = pixelBuffer[currentSourceData + 1];
                                resultedBuffer[currentResultedPointData + 2] = pixelBuffer[currentSourceData + 2];
                                resultedBuffer[currentResultedPointData + 3] = 255; // Alpha
                            }

                            if (currentResultedPointData - 3 >= 0)
                            {
                                resultedBuffer[currentResultedPointData - 4] = pixelBuffer[currentSourceData];
                                resultedBuffer[currentResultedPointData - 3] = pixelBuffer[currentSourceData + 1];
                                resultedBuffer[currentResultedPointData - 2] = pixelBuffer[currentSourceData + 2];
                                resultedBuffer[currentResultedPointData - 1] = 255; // Alpha
                            }
                        }
                    }
                }
            }

            Bitmap resBitmap = new Bitmap(Picture.Width, Picture.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(resultedBuffer, 0, resData.Scan0, resultedBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }


    }
}
