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
    public class ReadPPM
    {
        public string Width, Height;
   
        public Bitmap Read(string Picture)
        {
            Width = "";
            Height = "";
            char Temp;
            var Reader = new BinaryReader(new FileStream(Picture, FileMode.Open));
            if (Reader.ReadChar() != 'P' || Reader.ReadChar() != '6')
            {
                return null;
            }
            Reader.ReadChar();
            while ((Temp = Reader.ReadChar()) != ' ')
            {
                Width += Temp;
            }
            while ((Temp = Reader.ReadChar()) >= '0' && Temp <= '9')
            {
                Height += Temp;
            }
            if ((Reader.ReadChar()) != '2' || (Reader.ReadChar()) != '5' || (Reader.ReadChar()) != '5')
            {
                return null;
            }
            Reader.ReadChar();
            int IWidth = int.Parse(Width);
            int IHeight = int.Parse(Height);
            Bitmap Out = new Bitmap(IWidth, IHeight);

            for (int y = 0; y < IHeight; y++)
            {
                for (int x = 0; x < IWidth; x++)
                {
                    Color color = Out.GetPixel(x, y);
                    Out.SetPixel(x, y, color);
                }
            }
            return Out;
                    
        }
    }
}
