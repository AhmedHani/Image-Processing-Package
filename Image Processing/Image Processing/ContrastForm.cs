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
    public partial class ContrastForm : Form
    {
        public double Value
        {
            get { return (Convert.ToDouble(ContrastTextBox.Text)); }
            set { ContrastTextBox.Text = value.ToString(); }
        }

        public ContrastForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        private void ContrastForm_Load(object sender, EventArgs e)
        {

        }
    }
}
