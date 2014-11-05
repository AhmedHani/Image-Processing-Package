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
    public partial class MedianFilterForm : Form
    {
        public MedianFilterForm()
        {
            InitializeComponent();

            Dictionary<string, int> list = new Dictionary<string, int>();
            list.Add("3x3", 3);
            list.Add("4x4", 4);
            list.Add("5x5", 5);
            list.Add("6x6", 6);

            this.comboBox1.DataSource = new BindingSource(list, null);
            this.comboBox1.DisplayMember = "Key";
            this.comboBox1.ValueMember = "Value";

            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }

        public int WindowSize
        {
            get { return ((KeyValuePair<string, int>)this.comboBox1.SelectedItem).Value; }
            set { this.comboBox1.Text = value.ToString(); }
        }

        public bool GrayScale
        {
            get { return (this.grayCheck.Checked); }
            set { this.grayCheck.Checked = value; }
        }

        private void MedianFilterForm_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
