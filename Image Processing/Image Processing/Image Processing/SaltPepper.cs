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
    public partial class SaltPepper : Form
    {
        public SaltPepper()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public int SizeValue
        {
            get { return (Convert.ToInt32(SizeTextBox.Text)); }
            set { SizeTextBox.Text = value.ToString(); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            
        }

        private void PepperBar_Scroll(object sender, EventArgs e)
        {

        }

        private void SaltPepper_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {

        }

        private void SaltBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void PepperBox_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
