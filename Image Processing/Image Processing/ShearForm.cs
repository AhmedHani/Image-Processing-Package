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
    public partial class ShearForm : Form
    {
        public ShearForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public double ShearXValue
        {
            get { return (Convert.ToDouble(ShearX.Text)); }
            set { ShearX.Text = value.ToString(); }
        }

        public double ShearYValue
        {
            get { return (Convert.ToDouble(ShearY.Text)); }
            set { ShearY.Text = value.ToString(); }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }

        private void ShearForm_Load(object sender, EventArgs e)
        {

        }
    }
}
