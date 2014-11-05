using Image_Processing.Netpbm_format.PPM_P3_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing.Netpbm_format.PPM_P6_
{
    public class ReadPPM6
    {

        private FileStream file;
        private ASCIIReader ASCIIreader;
        private BinaryParser binaryReader;

        public ReadPPM6(FileStream file)
        {
            this.file = file;
            this.ASCIIreader = new ASCIIReader(file);
            this.binaryReader = new BinaryParser(file);
        }


        public Bitmap openPPM6()
        {
            int width, height, maxValue;

            string line = ((char)file.ReadByte()).ToString() + ((char)file.ReadByte()).ToString();
            file.ReadByte();
            this.ASCIIreader = new ASCIIReader(file);
            this.binaryReader = new BinaryParser(file);

            char currentChar = ' ';

            do
            {
                line = binaryReader.ReadLine();

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
                line = binaryReader.ReadLine();

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
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    byte r = binaryReader.br.ReadByte();
                    byte g = binaryReader.br.ReadByte();

                    byte b = binaryReader.br.ReadByte();
                    image.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }

            return image;

        }


    }
}
