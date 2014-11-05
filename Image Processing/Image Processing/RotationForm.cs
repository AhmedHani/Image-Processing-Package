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
    public partial class RotationForm : Form
    {
        public RotationForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public double AngleValue
        {
            get { return (Convert.ToDouble(Angle.Text)); }
            set { Angle.Text = value.ToString(); }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }

        private void RotationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
