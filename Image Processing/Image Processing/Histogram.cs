using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class Histogram : Form
    {
        private int[] red;
        private int[] blue;
        private int[] green;

        public Histogram()
        {
            InitializeComponent();
            
            this.chart1.ChartAreas[0].AxisX.Minimum = 0.0;
            this.chart1.ChartAreas[0].AxisX.Maximum = 255.0;
            this.chart1.ChartAreas[0].AxisX.Interval = 5.0;
            this.chart1.ChartAreas[0].AxisY.Minimum = 0.0;
        }

        public void setData(int[] red, int[] green, int[] blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public void drawHistogram()
        {
            for (int i = 0; i < 256; i++)
            {
                this.chart1.Series["red"].Points.AddXY(i, red[i]);
                this.chart1.Series["green"].Points.AddXY(i, green[i]);
                this.chart1.Series["blue"].Points.AddXY(i, blue[i]);
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Histogram_Load(object sender, EventArgs e)
        {

        }

        private void redBox_CheckedChanged(object sender, EventArgs e)
        {
            this.chart1.Series["red"].Enabled = !this.chart1.Series["red"].Enabled;
        }

        private void greenBox_CheckedChanged(object sender, EventArgs e)
        {
            this.chart1.Series["green"].Enabled = !this.chart1.Series["green"].Enabled;
        }

        private void blueBox_CheckedChanged(object sender, EventArgs e)
        {
            this.chart1.Series["blue"].Enabled = !this.chart1.Series["blue"].Enabled;
        }


    }
}
