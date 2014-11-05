using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing.Image_Operations
{
    public class GeometricOperationsMatrices
    {
        private Matrix transformationMatrix;
        private Bitmap userInput;
        private PointF[,] forwardedPixels;
        private PointF[,] inversedPixels;
        public float width, height;
        private Bitmap newImage;

        public GeometricOperationsMatrices(Bitmap userInput)
        {
            this.transformationMatrix = new Matrix();
            
            this.userInput = userInput;
        }

        public Bitmap rotation(double angle)
        {
            this.transformationMatrix.Rotate((float)angle, MatrixOrder.Append);

            height = userInput.Height;
            width = userInput.Width;

            PointF[] arr = new PointF[] { new PointF(0, 0), new PointF(width, 0), 
                new PointF(0, height), new PointF(width, height) };
        
            transformationMatrix.TransformPoints(arr);

            float minX = Math.Min(Math.Min(arr[0].X, arr[1].X), Math.Min(arr[2].X, arr[3].X));
            float minY = Math.Min(Math.Min(arr[0].Y, arr[1].Y), Math.Min(arr[2].Y, arr[3].Y));
            float maxX = Math.Max(Math.Max(arr[0].X, arr[1].X), Math.Max(arr[2].X, arr[3].X));
            float maxY = Math.Max(Math.Max(arr[0].Y, arr[1].Y), Math.Max(arr[2].Y, arr[3].Y));

            int finalWidth = (int)Math.Ceiling(maxX - minX);
            int finalHeight = (int)Math.Ceiling(maxY - minY);

            transformationMatrix.Translate(-minX, -minY, MatrixOrder.Append);

            newImage = new Bitmap(finalWidth, finalHeight, PixelFormat.Format32bppArgb);

            this.inversedPixels = new PointF[newImage.Width, newImage.Height];
            this.forwardedPixels = new PointF[userInput.Width, userInput.Height];

            #region 
            for (int i = 0; i < userInput.Height; i++)
            {
                for (int j = 0; j < userInput.Width; j++)
                {
                    // Point Transformation
                    PointF[] currentPoint = new PointF[]{new PointF((float)j, (float)i)};
                    transformationMatrix.TransformPoints(currentPoint);
                    forwardedPixels[j, i] = currentPoint[0];
                }
            }
            #endregion

            transformationMatrix.Invert();

            #region
            for (int i = 0; i < newImage.Height; i++)
            {
                for (int j = 0; j < newImage.Width; j++)
                {
                    PointF[] currentPoint = new PointF[] { new PointF((float)j, (float)i) };
                    transformationMatrix.TransformPoints(currentPoint);
                    inversedPixels[j, i] = currentPoint[0];
                }
            }
            #endregion

            return interpolation();

        }

        private Bitmap interpolation()
        {
            BitmapData sourceDataOld = userInput.LockBits(new Rectangle(0, 0, userInput.Width, userInput.Height), ImageLockMode.ReadWrite,
               PixelFormat.Format32bppArgb);

            BitmapData sourceDataNew = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height), ImageLockMode.ReadWrite,
               PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceDataOld.Width * sourceDataOld.Height * 4];
            byte[] resultedBuffer = new byte[sourceDataNew.Width * sourceDataNew.Height * 4];

            Marshal.Copy(sourceDataOld.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Marshal.Copy(sourceDataNew.Scan0, resultedBuffer, 0, resultedBuffer.Length);

            newImage.UnlockBits(sourceDataNew);
            userInput.UnlockBits(sourceDataOld);

            for (int i = 0; i < newImage.Height; i++)
            {
                for (int j = 0; j < newImage.Width; j++)
                {
                    int bufferIndex = ((i * newImage.Width) + j) * 4;

                    if (inversedPixels[j, i].X >= 0 && inversedPixels[j, i].X < userInput.Width &&
                        inversedPixels[j, i].Y >= 0 && inversedPixels[j, i].Y < userInput.Height)
                    {
                        //1-	find 4 adjacent pixels
                        int x1 = Math.Max(0, (int)Math.Floor(inversedPixels[j, i].X));
                        int x2 = Math.Min(x1 + 1, userInput.Width - 1);
                        int y1 = Math.Max(0, (int)Math.Floor(inversedPixels[j, i].Y));
                        int y2 = Math.Min(y1 + 1, userInput.Height - 1);

                        int currentIndex = ((y1 * userInput.Width) + x1) * 4;
                        Color color1 = Color.FromArgb(pixelBuffer[currentIndex], pixelBuffer[currentIndex + 1],
                            pixelBuffer[currentIndex + 2]);

                        currentIndex = ((y1 * userInput.Width) + x2) * 4;
                        Color color2 = Color.FromArgb(pixelBuffer[currentIndex], pixelBuffer[currentIndex + 1],
                            pixelBuffer[currentIndex + 2]);

                        currentIndex = ((y2 * userInput.Width) + x1) * 4;
                        Color color3 = Color.FromArgb(pixelBuffer[currentIndex], pixelBuffer[currentIndex + 1],
                            pixelBuffer[currentIndex + 2]);

                        currentIndex = ((y2 * userInput.Width) + x2) * 4;
                        Color color4 = Color.FromArgb(pixelBuffer[currentIndex], pixelBuffer[currentIndex + 1],
                            pixelBuffer[currentIndex + 2]);

                        //2-	Calculate X, Y fractions

                        float XFraction = inversedPixels[j, i].X - (float)x1;
                        float YFraction = inversedPixels[j, i].Y - (float)y1;

                        float Z1Red = (float)color1.R * (1f - XFraction) + (float)color2.R * XFraction;
                        float Z1Green = (float)color1.G * (1f - XFraction) + (float)color2.G * XFraction;
                        float Z1Blue = (float)color1.B * (1f - XFraction) + (float)color2.B * XFraction;

                        float Z2Red = (float)color3.R * (1f - XFraction) + (float)color4.R * XFraction;
                        float Z2Green = (float)color3.G * (1f - XFraction) + (float)color4.G * XFraction;
                        float Z2Blue = (float)color3.B * (1f - XFraction) + (float)color4.B * XFraction;

                        int newRed = (int)(Z1Red * (1f - YFraction) + Z2Red * YFraction);
                        int newGreen = (int)(Z1Green * (1f - YFraction) + Z2Green * YFraction);
                        int newBlue = (int)(Z1Blue * (1f - YFraction) + Z2Blue * YFraction);

                        Color col = Color.FromArgb(newRed, newGreen, newBlue);

                        resultedBuffer[bufferIndex] = col.R;
                        resultedBuffer[bufferIndex + 1] = col.G;
                        resultedBuffer[bufferIndex + 2] = col.B;
                        resultedBuffer[bufferIndex + 3] = col.A;
                    }

                    else
                    {
                        resultedBuffer[bufferIndex] = 255;
                        resultedBuffer[bufferIndex + 1] = 255;
                        resultedBuffer[bufferIndex + 2] = 255;
                        resultedBuffer[bufferIndex + 3] = 255;
                    }
                }
            }

            Bitmap resBitmap = new Bitmap(newImage.Width, newImage.Height);
            BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            Marshal.Copy(resultedBuffer, 0, resData.Scan0, resultedBuffer.Length);
            resBitmap.UnlockBits(resData);

            return resBitmap;
        }

        public Bitmap scale(double scaleX, double scaleY)
        {
            this.transformationMatrix.Scale((float)scaleY, (float)scaleX);

            height = userInput.Height;
            width = userInput.Width;

            PointF[] arr = new PointF[] { new PointF(0, 0), new PointF(width, 0), 
                new PointF(0, height), new PointF(width, height) };

            transformationMatrix.TransformPoints(arr);

            float minX = Math.Min(Math.Min(arr[0].X, arr[1].X), Math.Min(arr[2].X, arr[3].X));
            float minY = Math.Min(Math.Min(arr[0].Y, arr[1].Y), Math.Min(arr[2].Y, arr[3].Y));
            float maxX = Math.Max(Math.Max(arr[0].X, arr[1].X), Math.Max(arr[2].X, arr[3].X));
            float maxY = Math.Max(Math.Max(arr[0].Y, arr[1].Y), Math.Max(arr[2].Y, arr[3].Y));

            int finalWidth = (int)Math.Ceiling(maxX - minX);
            int finalHeight = (int)Math.Ceiling(maxY - minY);

            transformationMatrix.Translate(-minX, -minY, MatrixOrder.Append);

            newImage = new Bitmap(finalWidth, finalHeight, PixelFormat.Format32bppArgb);

            this.inversedPixels = new PointF[newImage.Width, newImage.Height];
            this.forwardedPixels = new PointF[userInput.Width, userInput.Height];

            #region
            for (int i = 0; i < userInput.Height; i++)
            {
                for (int j = 0; j < userInput.Width; j++)
                {
                    // Point Transformation
                    PointF[] currentPoint = new PointF[] { new PointF((float)j, (float)i) };
                    transformationMatrix.TransformPoints(currentPoint);
                    forwardedPixels[j, i] = currentPoint[0];
                }
            }
            #endregion

            transformationMatrix.Invert();

            #region
            for (int i = 0; i < newImage.Height; i++)
            {
                for (int j = 0; j < newImage.Width; j++)
                {
                    PointF[] currentPoint = new PointF[] { new PointF((float)j, (float)i) };
                    transformationMatrix.TransformPoints(currentPoint);
                    inversedPixels[j, i] = currentPoint[0];
                }
            }
            #endregion

            return interpolation();
        }

        public Bitmap shear(double shearX, double shearY)
        {
            this.transformationMatrix.Shear((float)shearX, (float)shearY);

            height = userInput.Height;
            width = userInput.Width;

            PointF[] arr = new PointF[] { new PointF(0, 0), new PointF(width, 0), 
                new PointF(0, height), new PointF(width, height) };

            transformationMatrix.TransformPoints(arr);

            float minX = Math.Min(Math.Min(arr[0].X, arr[1].X), Math.Min(arr[2].X, arr[3].X));
            float minY = Math.Min(Math.Min(arr[0].Y, arr[1].Y), Math.Min(arr[2].Y, arr[3].Y));
            float maxX = Math.Max(Math.Max(arr[0].X, arr[1].X), Math.Max(arr[2].X, arr[3].X));
            float maxY = Math.Max(Math.Max(arr[0].Y, arr[1].Y), Math.Max(arr[2].Y, arr[3].Y));

            int finalWidth = (int)Math.Ceiling(maxX - minX);
            int finalHeight = (int)Math.Ceiling(maxY - minY);

            transformationMatrix.Translate(-minX, -minY, MatrixOrder.Append);

            newImage = new Bitmap(finalWidth, finalHeight, PixelFormat.Format32bppArgb);

            this.inversedPixels = new PointF[newImage.Width, newImage.Height];
            this.forwardedPixels = new PointF[userInput.Width, userInput.Height];

            // Forward Mapping
            #region
            for (int i = 0; i < userInput.Height; i++)
            {
                for (int j = 0; j < userInput.Width; j++)
                {
                    // Point Transformation
                    PointF[] currentPoint = new PointF[] { new PointF((float)j, (float)i) };
                    transformationMatrix.TransformPoints(currentPoint);
                    forwardedPixels[j, i] = currentPoint[0];
                }
            }
            #endregion

            transformationMatrix.Invert();

            // Inversed Mapping
            #region
            for (int i = 0; i < newImage.Height; i++)
            {
                for (int j = 0; j < newImage.Width; j++)
                {
                    PointF[] currentPoint = new PointF[] { new PointF((float)j, (float)i) };
                    transformationMatrix.TransformPoints(currentPoint);
                    inversedPixels[j, i] = currentPoint[0];
                }
            }
            #endregion

            return interpolation();
        }

        public Bitmap rotateAndScaleAndShear(double angle, double scaleX, double scaleY, double shearX, double shearY)
        {
            this.transformationMatrix.Rotate((float)angle);
            this.transformationMatrix.Scale((float)scaleX, (float)scaleY);
            this.transformationMatrix.Shear((float)shearX, (float)shearY);

            height = userInput.Height;
            width = userInput.Width;

            PointF[] arr = new PointF[] { new PointF(0, 0), new PointF(width, 0), 
                new PointF(0, height), new PointF(width, height) };

            transformationMatrix.TransformPoints(arr);

            float minX = Math.Min(Math.Min(arr[0].X, arr[1].X), Math.Min(arr[2].X, arr[3].X));
            float minY = Math.Min(Math.Min(arr[0].Y, arr[1].Y), Math.Min(arr[2].Y, arr[3].Y));
            float maxX = Math.Max(Math.Max(arr[0].X, arr[1].X), Math.Max(arr[2].X, arr[3].X));
            float maxY = Math.Max(Math.Max(arr[0].Y, arr[1].Y), Math.Max(arr[2].Y, arr[3].Y));

            int finalWidth = (int)Math.Ceiling(maxX - minX);
            int finalHeight = (int)Math.Ceiling(maxY - minY);

            transformationMatrix.Translate(-minX, -minY, MatrixOrder.Append);

            newImage = new Bitmap(finalWidth, finalHeight, PixelFormat.Format32bppArgb);

            this.inversedPixels = new PointF[newImage.Width, newImage.Height];
            this.forwardedPixels = new PointF[userInput.Width, userInput.Height];

            
            #region Forward Mapping
            for (int i = 0; i < userInput.Height; i++)
            {
                for (int j = 0; j < userInput.Width; j++)
                {
                    // Point Transformation
                    PointF[] currentPoint = new PointF[] { new PointF((float)j, (float)i) };
                    transformationMatrix.TransformPoints(currentPoint);
                    forwardedPixels[j, i] = currentPoint[0];
                }
            }
            #endregion

            transformationMatrix.Invert();

            #region Inversed Mapping
            for (int i = 0; i < newImage.Height; i++)
            {
                for (int j = 0; j < newImage.Width; j++)
                {
                    PointF[] currentPoint = new PointF[] { new PointF((float)j, (float)i) };
                    transformationMatrix.TransformPoints(currentPoint);
                    inversedPixels[j, i] = currentPoint[0];
                }
            }
            #endregion

            return interpolation();
        }
    }
}
