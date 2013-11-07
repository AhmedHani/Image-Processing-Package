using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Image_Processing
{
    class WritePPM
    {
        public static void WriteBitMapToPPM(string File, Bitmap Picture)
        {
            var Writer = new StreamWriter(File);
            Writer.Write("P6" + Environment.NewLine);
            Writer.Write(Picture.Width + " " + Picture.Height + Environment.NewLine);
            Writer.Write("255" + Environment.NewLine);
            Writer.Close();

            var BinaryWrite = new BinaryWriter(new FileStream(File, FileMode.Open));

            for (int x = 0; x < Picture.Height; x++)
            {
                for (int y = 0; y < Picture.Width; y++)
                {
                    Color col = Picture.GetPixel(y, x);
                    BinaryWrite.Write(col.R);
                    BinaryWrite.Write(col.G);
                    BinaryWrite.Write(col.B);
                }
            }
            BinaryWrite.Close();
        }
    }
}
