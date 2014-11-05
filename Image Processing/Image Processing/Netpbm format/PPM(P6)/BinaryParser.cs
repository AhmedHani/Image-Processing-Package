using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing.Netpbm_format.PPM_P6_
{
    public class BinaryParser
    {
        public BinaryReader br; 

        public BinaryParser(FileStream file)
		{
            this.br = new BinaryReader(file);
		}

		public string ReadLine()
		{
			StringBuilder sb = new StringBuilder();

            byte currentChar = (byte)br.ReadByte();

            while (currentChar != '\n')
			{
                sb.Append(((char)currentChar).ToString());
                currentChar = br.ReadByte();
			}

			return sb.ToString();
		}

    }
}
