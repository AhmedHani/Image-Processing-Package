using Image_Processing.Netpbm_format.PPM_P3_;
using Image_Processing.Netpbm_format.PPM_P6_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Image_Processing.Netpbm_format
{
    public class PPM
    {
        private ReadPPM3 readPPM3;
        private WritePPM3 writePPM3;

        private ReadPPM6 readPPM6;
        private WritePPM6 writePPM6;

        private string picturePath, pictureData;

        public PPM(FileStream file)
        {
           // this.pictureData = pictureData;
            //this.picturePath = picturePath;

            //this.readPPM6 = new ReadPPM6(picturePath, pictureData);
            this.readPPM3 = new ReadPPM3(file);
            this.readPPM6 = new ReadPPM6(file);

        }

        public Bitmap ReadPPM6()
        {
            return this.readPPM6.openPPM6();
        }

        public Bitmap ReadPPM3()
        {
            return this.readPPM3.openPPM3();
        }

    }
}
