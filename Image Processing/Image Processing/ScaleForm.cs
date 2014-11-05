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
    public partial class ScaleForm : Form
    {
        public ScaleForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public double ScaleXValue
        {
            get { return (Convert.ToDouble(scaleXText.Text)); }
            set { scaleXText.Text = value.ToString(); }
        }

        public double ScaleYValue
        {
            get { return (Convert.ToDouble(scaleYText.Text)); }
            set { scaleYText.Text = value.ToString(); }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
