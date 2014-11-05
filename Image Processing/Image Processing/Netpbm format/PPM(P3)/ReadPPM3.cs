using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing.Netpbm_format.PPM_P3_
{
    public class ReadPPM3
    {
        private FileStream file;
        private ASCIIReader ASCIIreader;

        public ReadPPM3(FileStream file)
        {
            this.file = file;
        }

        public Bitmap openPPM3()
        {
            int width, height, maxValue;

            string line = ((char)file.ReadByte()).ToString() + ((char)file.ReadByte()).ToString();
            file.ReadByte();
            this.ASCIIreader = new ASCIIReader(file);

            char currentChar = ' ';

            do
            {
                line = ASCIIreader.reader.ReadLine();

                if (line.Length == 0)
                {
                    currentChar = '#';
                }
                else
                {
                    currentChar = line.Substring(0, 1).ToCharArray(0, 1)[0];
                }

            } while (currentChar == '#');

            string[] heightWidth = line.Split(new char[] { ' ' });

            width = int.Parse(heightWidth[0]);
            height = int.Parse(heightWidth[1]);

            do
            {
                line = ASCIIreader.reader.ReadLine();

                if (line.Length == 0)
                {
                    currentChar = '#';
                }
                else
                {
                    currentChar = line.Substring(0, 1).ToCharArray(0, 1)[0];
                }

            } while (currentChar == '#');

            maxValue = int.Parse(line); // 255

            Bitmap image = new Bitmap(width, height);

            //BitmapData sourceData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
            //   PixelFormat.Format24bppRgb);

            //byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            //for (int p = 0; p < pixelBuffer.Length; p += 4)
            //{
            //    byte r = ASCIIreader.readByte();
            //    byte g = ASCIIreader.readByte();
            //    byte b = ASCIIreader.readByte();
            //   // int currentSourceData = i * sourceData.Stride + j * 4;
            //    pixelBuffer[p] = r;
            //    pixelBuffer[p + 1] = g;
            //    pixelBuffer[p + 2] = b;
            //    pixelBuffer[p + 3] = 255;
            //}
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    byte r = ASCIIreader.readByte();
                    byte g = ASCIIreader.readByte();
                    byte b = ASCIIreader.readByte();
                    
                    image.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }
            //Bitmap resBitmap = new Bitmap(width, height);
            //BitmapData resData = resBitmap.LockBits(new Rectangle(0, 0, resBitmap.Width, resBitmap.Height), ImageLockMode.WriteOnly,
            //    PixelFormat.Format24bppRgb);
            //Marshal.Copy(pixelBuffer, 0, resData.Scan0, pixelBuffer.Length);
            //resBitmap.UnlockBits(resData);

           // return resBitmap;
            return image;
        }
    }
}
