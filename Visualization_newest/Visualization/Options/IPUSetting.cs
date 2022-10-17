using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualization
{
    public partial class IPUSetting : UserControl
    {
        public IPUSetting()
        {
            InitializeComponent();
            Demo_Mode.Checked = true;
            Picture_Size.Items.Add("256 × 256");
            Picture_Size.Items.Add("1024 × 1024");
            Picture_Size.Items.Add("1280 × 1280");
            Picture_Size.Items.Add("2048 × 5120");
            Picture_Size.Items.Add("640 × 480");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Picture_Path.Text = openFileDialog.SelectedPath;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(Realtime_Mode.Checked == true)
            {
                panel1.Enabled = false;
            }
            else
            {
                panel1.Enabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
