using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing.Netpbm_format.PPM_P3_
{
    public class ASCIIReader
    {
        #region
        private char[] ignored = new char[] { ' ', '\t', '\n', '\r' };
        public StreamReader reader;
        private Queue<string> tokens;
        #endregion

        public ASCIIReader(FileStream stream)
        {
            this.reader = new StreamReader(stream, ASCIIEncoding.ASCII);
            this.tokens = new Queue<string>();
        }

        public byte readByte()
        {
            while (true)
            {
                if (tokens.Count > 0)
                {
                    return byte.Parse(tokens.Dequeue().ToString());
                }

                string line = reader.ReadLine();

                string[] imageData = line.Split(ignored);

                foreach (string i in imageData)
                {
                    if (i.Length > 0)
                    {
                        tokens.Enqueue(i);
                    }
                }
            }
            
        }
    }
}
