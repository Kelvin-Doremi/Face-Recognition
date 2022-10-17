using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualization
{
    public partial class Options : Form
    {
        public CameraSetting cameraSetting = new CameraSetting();
        public IPUSetting ipuSetting = new IPUSetting();
        public ModelUpdate modelUpdate = new ModelUpdate();
        UserManagement userManagement = new UserManagement();
        bool handleclose = false;
        public Options()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            groupBox.Controls.Clear();
            groupBox.Controls.Add(cameraSetting);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            groupBox.Controls.Clear();
            groupBox.Controls.Add(ipuSetting);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            groupBox.Controls.Clear();
            groupBox.Controls.Add(modelUpdate);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            groupBox.Controls.Clear();
            groupBox.Controls.Add(userManagement);
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            SaveConfig();
            handleclose = true;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            handleclose = true;
            Close();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            SaveConfig();
            Apply.Enabled = false;
        }

        private void OptionsClosing(object sender, FormClosingEventArgs e)
        {
            if (handleclose == false)
            {
                DialogResult result = MessageBox.Show("你确定要关闭吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                    e.Cancel = false;  //点击OK   
                else
                    e.Cancel = true;
            }
        }

        private void SaveConfig()
        {
            MainForm.cameraConfig.camera_id = Convert.ToInt32(cameraSetting.camera_id.Text);
            MainForm.ipuConfig.service_ip_address = ipuSetting.Service_IP_Address.Text;
            MainForm.ipuConfig.service_ip_port = Convert.ToInt32(ipuSetting.Service_IP_Port.Text);
            MainForm.ipuConfig.client_ip_address = ipuSetting.Client_IP_Address.Text;
            MainForm.ipuConfig.client_ip_port = Convert.ToInt32(ipuSetting.Client_IP_Port.Text);
            if (ipuSetting.Realtime_Mode.Enabled == true)
                MainForm.ipuConfig.mode = IPUConfig.Mode.realtime;
            else
                MainForm.ipuConfig.mode = IPUConfig.Mode.demo;
            MainForm.ipuConfig.ModelSelect = ipuSetting.Model_Detect.Text;
            MainForm.ipuConfig.picture_path = ipuSetting.Picture_Path.Text;
            MainForm.ipuConfig.picture_size = ipuSetting.Picture_Size.Text;
        }
    }
}
