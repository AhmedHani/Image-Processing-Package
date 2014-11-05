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
    public partial class SaltAndPepperForm : Form
    {
        public SaltAndPepperForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public int Size
        {
            get { return (Convert.ToInt32(sizeBox.Text)); }
            set { sizeBox.Text = value.ToString(); }
        }

        private void SaltAndPepperForm_Load(object sender, EventArgs e)
        {

        }
    }
}
