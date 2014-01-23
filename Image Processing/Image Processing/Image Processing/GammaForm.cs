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
    public partial class GammaForm : Form
    {
        public double Red
        {
            get { return (Convert.ToDouble(RedTextBox.Text)); }
            set { RedTextBox.Text = value.ToString(); }
        }

        public double Green
        {
            get { return (Convert.ToDouble(GreenTextBox.Text)); }
            set { GreenTextBox.Text = value.ToString(); }
        }

        public double Blue
        {
            get { return (Convert.ToDouble(BlueTextBox.Text)); }
            set { BlueTextBox.Text = value.ToString(); }
        }

        public GammaForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        private void GammaForm_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {

        }

        private void RedTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
