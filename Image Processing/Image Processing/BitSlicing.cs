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
    public partial class BitSlicing : Form
    {
        public BitSlicing()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public byte MaskValue
        {
            get
            {
                byte x = Convert.ToByte(maskBox.Text, 2);
                //byte temp = Convert.ToByte(x);
                return (x); }
            set { maskBox.Text = value.ToString(); }
        }

        public bool GrayScale
        {
            get { return (this.grayCheck.Checked); }
            set { this.grayCheck.Checked = value; }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
