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
    public partial class BrightnessForm : Form
    {
        public int Value
        {
            get { return (Convert.ToInt32(BrightnessBox.Text, 10)); }
            set { BrightnessValue.Text = value.ToString(); }
        }
        public BrightnessForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        private void BrightnessBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PopWindow_Load(object sender, EventArgs e)
        {

        }

        private void BrightnessValue_Click(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
