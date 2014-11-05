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
    public partial class RSS : Form
    {
        public RSS()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public double ScaleX
        {
            get { return (Convert.ToDouble(scaleX.Text)); }
            set { scaleX.Text = value.ToString(); }
        }

        public double ScaleY
        {
            get { return (Convert.ToDouble(scaleY.Text)); }
            set { scaleY.Text = value.ToString(); }
        }

        public double Angle
        {
            get { return (Convert.ToDouble(angle.Text)); }
            set { angle.Text = value.ToString(); }
        }

        public double ShearX
        {
            get { return (Convert.ToDouble(shearX.Text)); }
            set { shearX.Text = value.ToString(); }
        }

        public double ShearY
        {
            get { return (Convert.ToDouble(shearY.Text)); }
            set { shearY.Text = value.ToString(); }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
