namespace visualization
{
    partial class IPUSetting
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Realtime_Mode = new System.Windows.Forms.RadioButton();
            this.Demo_Mode = new System.Windows.Forms.RadioButton();
            this.Picture_Size = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Client_IP_Port = new System.Windows.Forms.TextBox();
            this.Model_Detect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Model_Recognize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Picture_Path = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Service_IP_Port = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Service_IP_Address = new System.Windows.Forms.ComboBox();
            this.Client_IP_Address = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Realtime_Mode);
            this.groupBox1.Controls.Add(this.Demo_Mode);
            this.groupBox1.Location = new System.Drawing.Point(81, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模式选择";
            // 
            // Realtime_Mode
            // 
            this.Realtime_Mode.AutoSize = true;
            this.Realtime_Mode.Location = new System.Drawing.Point(145, 20);
            this.Realtime_Mode.Name = "Realtime_Mode";
            this.Realtime_Mode.Size = new System.Drawing.Size(71, 16);
            this.Realtime_Mode.TabIndex = 1;
            this.Realtime_Mode.TabStop = true;
            this.Realtime_Mode.Text = "实时模式";
            this.Realtime_Mode.UseVisualStyleBackColor = true;
            this.Realtime_Mode.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Demo_Mode
            // 
            this.Demo_Mode.AutoSize = true;
            this.Demo_Mode.Location = new System.Drawing.Point(7, 21);
            this.Demo_Mode.Name = "Demo_Mode";
            this.Demo_Mode.Size = new System.Drawing.Size(71, 16);
            this.Demo_Mode.TabIndex = 0;
            this.Demo_Mode.TabStop = true;
            this.Demo_Mode.Text = "演示模式";
            this.Demo_Mode.UseVisualStyleBackColor = true;
            // 
            // Picture_Size
            // 
            this.Picture_Size.FormattingEnabled = true;
            this.Picture_Size.Location = new System.Drawing.Point(7, 90);
            this.Picture_Size.Name = "Picture_Size";
            this.Picture_Size.Size = new System.Drawing.Size(121, 20);
            this.Picture_Size.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图像大小选择";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "（板卡）IP地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "端口号";
            // 
            // Client_IP_Port
            // 
            this.Client_IP_Port.Location = new System.Drawing.Point(346, 71);
            this.Client_IP_Port.Name = "Client_IP_Port";
            this.Client_IP_Port.Size = new System.Drawing.Size(45, 21);
            this.Client_IP_Port.TabIndex = 4;
            this.Client_IP_Port.Text = "22";
            this.Client_IP_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Model_Detect
            // 
            this.Model_Detect.FormattingEnabled = true;
            this.Model_Detect.Items.AddRange(new object[] {
            "SSD",
            "YOLO_V1",
            "YOLO_V2",
            "YOLO_V3"});
            this.Model_Detect.Location = new System.Drawing.Point(81, 200);
            this.Model_Detect.Name = "Model_Detect";
            this.Model_Detect.Size = new System.Drawing.Size(121, 20);
            this.Model_Detect.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "检测模型选择";
            // 
            // Model_Recognize
            // 
            this.Model_Recognize.FormattingEnabled = true;
            this.Model_Recognize.Items.AddRange(new object[] {
            "VGG16",
            "VGG19",
            "ResNet50",
            "ResNet100"});
            this.Model_Recognize.Location = new System.Drawing.Point(226, 200);
            this.Model_Recognize.Name = "Model_Recognize";
            this.Model_Recognize.Size = new System.Drawing.Size(121, 20);
            this.Model_Recognize.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "识别模型选择";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Picture_Path);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Picture_Size);
            this.panel1.Location = new System.Drawing.Point(72, 232);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 122);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Picture_Path
            // 
            this.Picture_Path.Location = new System.Drawing.Point(7, 29);
            this.Picture_Path.Name = "Picture_Path";
            this.Picture_Path.Size = new System.Drawing.Size(231, 21);
            this.Picture_Path.TabIndex = 3;
            this.Picture_Path.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "图像文件路径";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Service_IP_Port
            // 
            this.Service_IP_Port.Location = new System.Drawing.Point(346, 32);
            this.Service_IP_Port.Name = "Service_IP_Port";
            this.Service_IP_Port.Size = new System.Drawing.Size(45, 21);
            this.Service_IP_Port.TabIndex = 4;
            this.Service_IP_Port.Text = "22";
            this.Service_IP_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "（主机）IP地址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "端口号";
            // 
            // Service_IP_Address
            // 
            this.Service_IP_Address.FormattingEnabled = true;
            this.Service_IP_Address.Location = new System.Drawing.Point(172, 32);
            this.Service_IP_Address.Name = "Service_IP_Address";
            this.Service_IP_Address.Size = new System.Drawing.Size(121, 20);
            this.Service_IP_Address.TabIndex = 7;
            // 
            // Client_IP_Address
            // 
            this.Client_IP_Address.FormattingEnabled = true;
            this.Client_IP_Address.Location = new System.Drawing.Point(172, 71);
            this.Client_IP_Address.Name = "Client_IP_Address";
            this.Client_IP_Address.Size = new System.Drawing.Size(121, 20);
            this.Client_IP_Address.TabIndex = 7;
            // 
            // IPUSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.Client_IP_Address);
            this.Controls.Add(this.Service_IP_Address);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Service_IP_Port);
            this.Controls.Add(this.Client_IP_Port);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Model_Recognize);
            this.Controls.Add(this.Model_Detect);
            this.Controls.Add(this.groupBox1);
            this.Name = "IPUSetting";
            this.Size = new System.Drawing.Size(560, 360);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton Realtime_Mode;
        public System.Windows.Forms.RadioButton Demo_Mode;
        public System.Windows.Forms.ComboBox Picture_Size;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox Client_IP_Port;
        public System.Windows.Forms.ComboBox Model_Detect;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox Model_Recognize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox Picture_Path;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox Service_IP_Port;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox Service_IP_Address;
        public System.Windows.Forms.ComboBox Client_IP_Address;
    }
}
