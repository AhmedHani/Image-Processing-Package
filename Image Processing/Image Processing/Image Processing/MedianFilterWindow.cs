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
    public partial class MedianFilterWindow : Form
    {
        public MedianFilterWindow()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
            GrayScaleCheckBox.Checked = false;
        }

        public int SizeValue
        {
            get { return (Convert.ToInt32(SizeTextBox.Text)); }
            set { SizeTextBox.Text = value.ToString(); }
        }

        public bool GrayCheck
        {
            get { return GrayScaleCheckBox.Checked; }
            set { GrayScaleCheckBox.Checked = value; }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }

        private void GrayScaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //GrayScaleCheckBox.Checked = true;
        }
    }
}
