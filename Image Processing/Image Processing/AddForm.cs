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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public double FractionValue
        {
            get { return (Convert.ToDouble(fractionBox.Text)); }
            set { fractionBox.Text = value.ToString(); }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
