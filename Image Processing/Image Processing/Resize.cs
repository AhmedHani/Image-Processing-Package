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
    public partial class Resize : Form
    {
        public int Width
        {
            get { return (Convert.ToInt32(WidthTextBox.Text, 10)); }
            set { WidthTextBox.Text = value.ToString(); }
        }

        public int Height
        {
            get { return (Convert.ToInt32(HeightTextBox.Text, 10)); }
            set { HeightTextBox.Text = value.ToString(); }
        }

        public bool BilinearCheck
        {
            get { return Bilinear.Checked; }
            set { Bilinear.Checked = value; }
        }

        public Resize()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Resize_Load(object sender, EventArgs e)
        {

        }
    }
}
