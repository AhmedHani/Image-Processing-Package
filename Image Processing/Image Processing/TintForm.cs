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
    public partial class TintForm : Form
    {
        public TintForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public double Red
        {
            get { return (Convert.ToDouble(redBox.Text)); }
            set { redBox.Text = value.ToString(); }
        }

        public double Green
        {
            get { return (Convert.ToDouble(greenBox.Text)); }
            set { greenBox.Text = value.ToString(); }
        }

        public double Blue
        {
            get { return (Convert.ToDouble(blueBox.Text)); }
            set { blueBox.Text = value.ToString(); }
        }


        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
