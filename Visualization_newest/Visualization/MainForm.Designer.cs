namespace visualization
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.interval = new System.Windows.Forms.TextBox();
            this.Connect = new System.Windows.Forms.Button();
            this.Transfer = new System.Windows.Forms.Button();
            this.CaptureImg = new System.Windows.Forms.Button();
            this.ConnectCam = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.pictureSizeStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Picture_Path = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Picture_Size = new System.Windows.Forms.ComboBox();
            this.SendConfig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Realtime_Mode = new System.Windows.Forms.RadioButton();
            this.Demo_Mode = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.Model_Select = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startProcessingToolStripMenuItem,
            this.stopProcessingToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ToolsToolStripMenuItem.Text = "工具(T)";
            // 
            // startProcessingToolStripMenuItem
            // 
            this.startProcessingToolStripMenuItem.Name = "startProcessingToolStripMenuItem";
            this.startProcessingToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.startProcessingToolStripMenuItem.Text = "Start Processing";
            this.startProcessingToolStripMenuItem.Click += new System.EventHandler(this.startProcessingToolStripMenuItem_Click);
            // 
            // stopProcessingToolStripMenuItem
            // 
            this.stopProcessingToolStripMenuItem.Name = "stopProcessingToolStripMenuItem";
            this.stopProcessingToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.stopProcessingToolStripMenuItem.Text = "Stop Processing";
            this.stopProcessingToolStripMenuItem.Click += new System.EventHandler(this.stopProcessingToolStripMenuItem_Click);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.OptionsToolStripMenuItem.Text = "选项(O)";
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsToolStripMenuItem,
            this.OptionsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.interval);
            this.panel1.Controls.Add(this.Connect);
            this.panel1.Controls.Add(this.Transfer);
            this.panel1.Controls.Add(this.CaptureImg);
            this.panel1.Controls.Add(this.ConnectCam);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 69);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "传输间隔";
            // 
            // interval
            // 
            this.interval.Location = new System.Drawing.Point(165, 35);
            this.interval.Name = "interval";
            this.interval.Size = new System.Drawing.Size(56, 20);
            this.interval.TabIndex = 4;
            this.interval.Text = "600";
            this.interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(84, 3);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 25);
            this.Connect.TabIndex = 3;
            this.Connect.Text = "连接板卡";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Transfer
            // 
            this.Transfer.Location = new System.Drawing.Point(3, 35);
            this.Transfer.Name = "Transfer";
            this.Transfer.Size = new System.Drawing.Size(75, 25);
            this.Transfer.TabIndex = 2;
            this.Transfer.Text = "开始传输";
            this.Transfer.UseVisualStyleBackColor = true;
            this.Transfer.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // CaptureImg
            // 
            this.CaptureImg.Location = new System.Drawing.Point(165, 3);
            this.CaptureImg.Name = "CaptureImg";
            this.CaptureImg.Size = new System.Drawing.Size(75, 25);
            this.CaptureImg.TabIndex = 1;
            this.CaptureImg.Text = "图像捕捉";
            this.CaptureImg.UseVisualStyleBackColor = true;
            this.CaptureImg.Click += new System.EventHandler(this.CaptureImg_Click);
            // 
            // ConnectCam
            // 
            this.ConnectCam.Location = new System.Drawing.Point(3, 3);
            this.ConnectCam.Name = "ConnectCam";
            this.ConnectCam.Size = new System.Drawing.Size(75, 25);
            this.ConnectCam.TabIndex = 0;
            this.ConnectCam.Text = "打开摄像头";
            this.ConnectCam.UseVisualStyleBackColor = true;
            this.ConnectCam.Click += new System.EventHandler(this.ConnectCam_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 456);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(259, 190);
            this.textBox1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(302, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1048, 698);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pictureSizeStatusStrip});
            this.statusStrip.Location = new System.Drawing.Point(0, 727);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // pictureSizeStatusStrip
            // 
            this.pictureSizeStatusStrip.Name = "pictureSizeStatusStrip";
            this.pictureSizeStatusStrip.Size = new System.Drawing.Size(72, 17);
            this.pictureSizeStatusStrip.Text = "无图片输入";
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.SendConfig);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Model_Select);
            this.panel2.Location = new System.Drawing.Point(12, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 339);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.Picture_Path);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.Picture_Size);
            this.panel3.Location = new System.Drawing.Point(8, 181);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 132);
            this.panel3.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Picture_Path
            // 
            this.Picture_Path.Location = new System.Drawing.Point(7, 31);
            this.Picture_Path.Name = "Picture_Path";
            this.Picture_Path.Size = new System.Drawing.Size(121, 20);
            this.Picture_Path.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "图像文件路径";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "图像大小选择";
            // 
            // Picture_Size
            // 
            this.Picture_Size.FormattingEnabled = true;
            this.Picture_Size.Location = new System.Drawing.Point(7, 98);
            this.Picture_Size.Name = "Picture_Size";
            this.Picture_Size.Size = new System.Drawing.Size(121, 21);
            this.Picture_Size.TabIndex = 1;
            // 
            // SendConfig
            // 
            this.SendConfig.Location = new System.Drawing.Point(3, 3);
            this.SendConfig.Name = "SendConfig";
            this.SendConfig.Size = new System.Drawing.Size(75, 25);
            this.SendConfig.TabIndex = 0;
            this.SendConfig.Text = "更改设置";
            this.SendConfig.UseVisualStyleBackColor = true;
            this.SendConfig.Click += new System.EventHandler(this.SendConfig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Realtime_Mode);
            this.groupBox1.Controls.Add(this.Demo_Mode);
            this.groupBox1.Location = new System.Drawing.Point(8, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 59);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模式选择";
            // 
            // Realtime_Mode
            // 
            this.Realtime_Mode.AutoSize = true;
            this.Realtime_Mode.Location = new System.Drawing.Point(118, 22);
            this.Realtime_Mode.Name = "Realtime_Mode";
            this.Realtime_Mode.Size = new System.Drawing.Size(73, 17);
            this.Realtime_Mode.TabIndex = 1;
            this.Realtime_Mode.TabStop = true;
            this.Realtime_Mode.Text = "实时模式";
            this.Realtime_Mode.UseVisualStyleBackColor = true;
            // 
            // Demo_Mode
            // 
            this.Demo_Mode.AutoSize = true;
            this.Demo_Mode.Location = new System.Drawing.Point(7, 23);
            this.Demo_Mode.Name = "Demo_Mode";
            this.Demo_Mode.Size = new System.Drawing.Size(73, 17);
            this.Demo_Mode.TabIndex = 0;
            this.Demo_Mode.TabStop = true;
            this.Demo_Mode.Text = "演示模式";
            this.Demo_Mode.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "模型选择";
            // 
            // Model_Select
            // 
            this.Model_Select.FormattingEnabled = true;
            this.Model_Select.Items.AddRange(new object[] {
            "SSD",
            "YOLO_V1",
            "YOLO_V2",
            "YOLO_V3"});
            this.Model_Select.Location = new System.Drawing.Point(13, 142);
            this.Model_Select.Name = "Model_Select";
            this.Model_Select.Size = new System.Drawing.Size(121, 21);
            this.Model_Select.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(302, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1048, 698);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 749);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能可视化系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CaptureImg;
        private System.Windows.Forms.Button ConnectCam;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Transfer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem startProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopProcessingToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel pictureSizeStatusStrip;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SendConfig;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox Picture_Path;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox Picture_Size;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton Realtime_Mode;
        public System.Windows.Forms.RadioButton Demo_Mode;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox Model_Select;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox interval;
    }
}

