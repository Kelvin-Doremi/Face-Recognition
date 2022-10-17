using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Xml.Linq;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using System.Runtime.InteropServices;

public struct Box
{
    public int classes;
    public Rectangle rect;
}

public struct PictureMsg
{
    public int id;
    public Mat mat;
    public int box_num;
    public Box[] box;
}

public struct CameraConfig
{
    public int camera_id;
    public string capture_path;
};

public struct IPUConfig
{
    public string service_ip_address;
    public int service_ip_port;
    public string client_ip_address;
    public int client_ip_port;
    public enum Mode { demo=1, realtime };
    public Mode mode;
    public string ModelSelect;
    public string ModelRecognize;
    public string picture_path;
    public string picture_size;
};

namespace visualization
{
    public partial class MainForm : Form
    {
        ///-----------------------声明全局引用-----------------------///
        //线程
        Socket TcpSocket;
        Thread sendThread;
        bool sendThreadStop;
        Thread recvThread;
        bool recvThreadStop;
        Thread dispThread;
        bool dispThreadStop;

        bool stop_manual;

        //...
        public static Rectangle rect = new Rectangle(0, 0, 0, 0);
        public static CameraConfig cameraConfig;
        public static IPUConfig ipuConfig;
        public static Queue MsgQueue = new Queue();
        public static Queue SyncMsgQueue = Queue.Synchronized(MsgQueue);

        //...
        bool receiveConsult = false;
        bool pictureReady = false;
        bool captureOn = false;
        VideoCapture capture; //create a camera captue
        public static Mat mat = new Mat();
        Mat mat_local;
        string fileName = "../FaceId/";

        //本地处理
        CascadeClassifier faceDetector = new CascadeClassifier("../data/haarcascades/haarcascade_frontalface_default.xml");
        FaceRecognizer faceRecognizer = new FisherFaceRecognizer();

        //TCP
        int action = 0;
        short imgnum = 0;
        byte[] buffer = new byte[11000000];

        string[] obj_class = { "person", "bicycle", "car", "motorbike", "aeroplane", "bus", "train", "truck", "boat", "traffic_light", "fire_hydrant", "stop_sign", "parking_meter", "bench", "bird", "cat", "dog", "horse", "sheep", "cow", "elephant", "bear", "zebra", "giraffe", "backpack", "umbrella", "handbag", "tie", "suitcase", "frisbee", "skis", "snowboard", "sports_ball", "kite", "baseball_bat", "baseball_glove", "skateboard", "surfboard", "tennis_racket", "bottle", "wine_glass", "cup", "fork", "knife", "spoon", "bowl", "banana", "apple", "sandwich", "orange", "broccoli", "carrot", "hot_dog", "pizza", "donut", "cake", "chair", "sofa", "pottedplant", "bed", "diningtable", "toilet", "tvmonitor", "laptop", "mouse", "remote", "keyboard", "cell_phone", "microwave", "oven", "toaster", "sink", "refrigerator", "book", "clock", "vase", "scissors", "teddy_bear", "hair_drier", "toothbrush" };
        string[] face_class = { "wu zhi hong", "others" };
        ///----------------------------------------------------------///

        ///主函数
        public MainForm()
        {
            InitializeComponent();
            try
            {
                InitializeConfig();
            }
            catch
            { }
            stopProcessingToolStripMenuItem.Enabled = false;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dispThread = new Thread(new ThreadStart(disp_thread));
            dispThreadStop = false;
            dispThread.Start();

            //本地检测
            Mat[] trainMat = new Mat[4];
            int[] lable = new int[4];
            for (int i = 0; i < 4; i++)
            {
                trainMat[i] = new Mat(fileName + i.ToString() + ".jpg", ImreadModes.Grayscale);
                lable[i] = 1;
            }
            lable[0] = 0;
            lable[1] = 0;
            lable[2] = 0;
            faceRecognizer.Train(trainMat, lable);

            textBox1.BringToFront();
            pictureBox1.SendToBack();
        }

        ///xml
        public static string xmlpath
        {
            get
            {
                string path = string.Format("../data.xml");
                return path;
            }
        }

        ///设置初始化
        private void InitializeConfig()
        {
            XElement xmlDoc = XElement.Load(xmlpath);
            cameraConfig.camera_id = Convert.ToInt32(xmlDoc.Element("cameraConfig").Element("camera_id").Value);
            ipuConfig.service_ip_address = xmlDoc.Element("ipuConfig").Element("service_ip_address").Value;
            ipuConfig.service_ip_port = Convert.ToInt32(xmlDoc.Element("ipuConfig").Element("service_ip_port").Value);
            ipuConfig.client_ip_address = xmlDoc.Element("ipuConfig").Element("client_ip_address").Value;
            ipuConfig.client_ip_port = Convert.ToInt32(xmlDoc.Element("ipuConfig").Element("client_ip_port").Value);
            if (xmlDoc.Element("ipuConfig").Element("mode").Value == "realtime")
            {
                ipuConfig.mode = IPUConfig.Mode.realtime;
                Realtime_Mode.Enabled = true;
                Demo_Mode.Enabled = false;
            }
            else
            {
                ipuConfig.mode = IPUConfig.Mode.demo;
                Demo_Mode.Enabled = true;
                Realtime_Mode.Enabled = false;
            }
            ipuConfig.ModelSelect = xmlDoc.Element("ipuConfig").Element("ModelSelect").Value;
            ipuConfig.picture_path = xmlDoc.Element("ipuConfig").Element("picture_path").Value;
            ipuConfig.picture_size = xmlDoc.Element("ipuConfig").Element("picture_size").Value;

            Model_Select.Text = ipuConfig.ModelSelect;
        }

        ///更改设置
        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.cameraSetting.camera_id.Text = cameraConfig.camera_id.ToString();
            options.ipuSetting.Service_IP_Address.Text = ipuConfig.service_ip_address;
            options.ipuSetting.Service_IP_Port.Text = ipuConfig.service_ip_port.ToString();
            options.ipuSetting.Client_IP_Address.Text = ipuConfig.client_ip_address;
            options.ipuSetting.Client_IP_Port.Text = ipuConfig.client_ip_port.ToString();
            {
                string localname = Dns.GetHostName();
                IPAddress[] local_ip = Dns.GetHostAddresses(localname);
                foreach (IPAddress ip in local_ip)
                {
                    options.ipuSetting.Service_IP_Address.Items.Add(ip);
                }
            }
            if (ipuConfig.mode == IPUConfig.Mode.realtime)
                options.ipuSetting.Realtime_Mode.Enabled = true;
            else
                options.ipuSetting.Demo_Mode.Enabled = true;
            options.ipuSetting.Model_Detect.Text = ipuConfig.ModelSelect;
            options.ipuSetting.Model_Recognize.Text = ipuConfig.ModelRecognize;
            options.ipuSetting.Picture_Path.Text = ipuConfig.picture_path;
            options.ipuSetting.Picture_Size.Text = ipuConfig.picture_size;
            options.Show();
        }

        ///连接按钮事件
        private void Connect_Click(object sender, EventArgs e)
        {
            if (Connect.Text == "连接板卡")
            {
                stop_manual = false;
                start_connect();
            }
            else
            {
                stop_manual = true;
                stop_connect();
            }
        }

        private void start_connect()
        {
            Connect.Enabled = false;
            try
            {
                //实例化一个Socket对象，并连接到服务端
                IPEndPoint Point;
                Point = new IPEndPoint(IPAddress.Parse(ipuConfig.client_ip_address), ipuConfig.client_ip_port);
                TcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                TcpSocket.Connect(Point);

                Connect.Text = "停止连接";
                Connect.Enabled = true;

                //-----------------------测试-----------------------//
                //实例化一个线程，用于接收远程数据
                //recvThread = new Thread(new ThreadStart(RecvData));
                //recvThreadStop = false;
                //recvThread.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("连接超时", "提示!"); //弹出提示框
                Connect.Enabled = true;
            }
        }

        ///停止连接
        private void stop_connect()
        {
            Connect.Invoke(new MethodInvoker(delegate
            {
                Connect.Enabled = false;
            }));

            stop_transfer();
            TcpSocket.Close();
            //清空队列

            Connect.Invoke(new MethodInvoker(delegate
            {
                Connect.Text = "连接板卡";
                Connect.Enabled = true;
            }));
        }

        ///传输按钮事件
        private void Transfer_Click(object sender, EventArgs e)
        {
            if (Transfer.Text == "开始传输")
            {
                panel2.Enabled = false;

                stop_manual = false;
                start_transfer();
            }
            else
            {
                panel2.Enabled = true;

                stop_manual = true;
                stop_transfer();
            }
        }

        ///开始传输
        private void start_transfer()
        {
            Transfer.Enabled = false;

            //实例化一个线程，向服务端发送数据
            sendThread = new Thread(new ThreadStart(SendData));
            sendThreadStop = false;
            sendThread.Start();
            timer3.Start(); //定时发送

            //实例化一个线程，用于接收远程数据
            recvThread = new Thread(new ThreadStart(RecvData));
            recvThreadStop = false;
            recvThread.Start();

            Transfer.Text = "停止传输";
            Transfer.Enabled = true;

            pictureBox1.BringToFront();
        }

        ///停止传输
        private void stop_transfer()
        {
            Transfer.Invoke(new MethodInvoker(delegate
            {
                Transfer.Enabled = false;
            }));

            sendThreadStop = true;
            recvThreadStop = true;
            //清空队列

            Transfer.Invoke(new MethodInvoker(delegate
            {
                Transfer.Text = "开始传输";
                Transfer.Enabled = true;
            }));

            pictureBox1.SendToBack();
        }

        ///传输计时
        private void timer3_Tick(object sender, EventArgs e)
        {
            action++;
        }

        ///发送进程
        private void SendData()
        {
            while (!sendThreadStop)
            {
                if (action >= Convert.ToInt32(interval.Text) / 10) //200ms一次
                {
                    //发送
                    short h = (short)mat.Size.Height;
                    short w = (short)mat.Size.Width;
                    short c = (short)mat.ElementSize;
                    byte[] sendData = new byte[h * w * c];
                    mat.GetRawData().CopyTo(sendData, 0);

                    try
                    {
                        TcpSocket.Send(sendData);
                    }
                    catch
                    {
                        break;
                    }

                    action = 0;
                }
            }
        }
        /* 协议版
        private void SendData()
        {
            while (!sendThreadStop)
            {
                if (action >= 5) //10ms一次
                {
                    //发送
                    short h = (short)mat.Size.Height;
                    short w = (short)mat.Size.Width;
                    short c = (short)mat.ElementSize;
                    byte[] sendData = new byte[h * w * c + 8];
                    BitConverter.GetBytes(h).CopyTo(sendData, 0);
                    BitConverter.GetBytes(w).CopyTo(sendData, 2);
                    BitConverter.GetBytes(c).CopyTo(sendData, 4);
                    BitConverter.GetBytes(++imgnum).CopyTo(sendData, 6);
                    mat.GetRawData().CopyTo(sendData, 8);

                    try
                    {
                        TcpSocket.Send(sendData);
                    }
                    catch
                    {
                        break;
                    }

                    //入队
                    PictureMsg pictureMsg0 = new PictureMsg();
                    pictureMsg0.id = imgnum;
                    pictureMsg0.mat = mat;
                    SyncMsgQueue.Enqueue(pictureMsg0);

                    action = 0;
                }
            }
        }
        */

        ///TCP接收函数封装
        private int recv_size(Socket socket, byte[] data, int length)
        {
            int one_recv, sum_recv = 0;
            while (sum_recv < length)
            {
                if (recvThreadStop) return -1;
                try
                {
                    if (!socket.Poll(10, SelectMode.SelectRead)) continue;
                    one_recv = socket.Receive(data, sum_recv, length - sum_recv, 0);
                    sum_recv += one_recv;
                }
                catch
                {
                    if (!stop_manual)
                    {
                        stop_connect();
                        MessageBox.Show("对方已关闭连接", "提示!"); //弹出提示框
                    }
                    return -1;
                }
            }
            return sum_recv;
        }

        ///接收进程
        private void RecvData()
        {
            while (!recvThreadStop)
            {
                //接收
                int recv_state;
                byte[] buff = new byte[921600];
                //TcpSocket.Receive(buff, 0, 921600, 0);
                recv_state = recv_size(TcpSocket, buff, 921600);
                if (recv_state == -1) break; //应关闭线程

                //显示图片
                int w = 640;
                int h = 480;
                IntPtr newptr = Marshal.AllocHGlobal(w * h * 3);
                Marshal.Copy(buff, 0, newptr, w * h * 3);
                Mat remat = new Mat(h, w, DepthType.Cv8U, 3, newptr, 0);
                //CvInvoke.Imshow("test", remat);
                pictureBox1.Image = remat.Bitmap;
            }
        }

        /* 协议版
        private void RecvData()
        {
            while (!recvThreadStop)
            {
                int recv_state;
                //接收0:head
                byte[] buff_head = new byte[4];
                recv_state = recv_size(TcpSocket, buff_head, 4);
                if (recv_state == -1) break; //应关闭线程
                //解析0:head
                int pic_id = buff_head[0] + (buff_head[1] << 8);
                int box_num = buff_head[2] + (buff_head[3] << 8);
                //接收1:body
                byte[] buff = new byte[10 * box_num];
                recv_state = recv_size(TcpSocket, buff, 10 * box_num);
                if (recv_state == -1) break; //应关闭线程
                //解析1:body
                Box[] box = new Box[box_num];
                for (int i = 0; i < box_num; i++)
                {
                    box[i].classes = buff[10 * i] + (buff[10 * i + 1] << 8);
                    box[i].rect = Rectangle.FromLTRB(
                        buff[10 * i + 2] + (buff[10 * i + 3] << 8),
                        buff[10 * i + 4] + (buff[10 * i + 5] << 8),
                        buff[10 * i + 6] + (buff[10 * i + 7] << 8),
                        buff[10 * i + 8] + (buff[10 * i + 9] << 8));
                }

                //显示文字
                textBox1.Invoke(new MethodInvoker(delegate
                {
                    textBox1.AppendText($"第{pic_id}张照片共{box_num}个结果，分别是\r\n");
                }));
                for (int i = 0; i < box_num; i++)
                {
                    textBox1.Invoke(new MethodInvoker(delegate
                    {
                        textBox1.AppendText($"第{i}个框: C={box[i].classes}, L={box[i].rect.Left}, T={box[i].rect.Top}, R={box[i].rect.Right}, B={box[i].rect.Bottom}\r\n");
                    }));
                }

                //出队
                PictureMsg pictureMsg1;
                pictureMsg1 = (PictureMsg)SyncMsgQueue.Dequeue();
                if (pictureMsg1.id == (short)pic_id)
                {
                    pictureMsg1.box_num = box_num;
                    pictureMsg1.box = box;
                }

                //显示图片
                for (int i = 0; i < pictureMsg1.box_num; i++)
                {
                    CvInvoke.PutText(pictureMsg1.mat, obj_class[pictureMsg1.box[i].classes], pictureMsg1.box[i].rect.Location, FontFace.HersheyComplex, 2, new MCvScalar(0, 0, 255), 2);
                    CvInvoke.Rectangle(pictureMsg1.mat, pictureMsg1.box[i].rect, new MCvScalar(0, 0, 255), 4);
                }
                Image<Bgr, byte> image = pictureMsg1.mat.ToImage<Bgr, byte>();
                pictureBox.Image = image.Bitmap;
            }
        }
        */

        private void SaveConfig()
        {
            if (Realtime_Mode.Enabled == true)
                ipuConfig.mode = IPUConfig.Mode.realtime;
            else
                ipuConfig.mode = IPUConfig.Mode.demo;

            ipuConfig.ModelSelect = Model_Select.Text;
        }

        ///发送配置
        private void SendConfig_Click(object sender, EventArgs e)
        {
            SaveConfig();

        }

        ///开始显示&停止显示
        private void ConnectCam_Click(object sender, EventArgs e)
        {
            if (ConnectCam.Text == "打开摄像头")
            {
                ConnectCam.Text = "关闭摄像头";
                switch (ipuConfig.picture_size)
                {
                    case "256 × 256":
                        mat_local = CvInvoke.Imread("../PictureSet/256x256.jpg");
                        break;
                    case "1024 × 1024":
                        mat_local = CvInvoke.Imread("../PictureSet/1024x1024.bmp");
                        break;
                    case "1280 × 1280":
                        mat_local = CvInvoke.Imread("../PictureSet/1280x1280.bmp");
                        break;
                    case "2048 × 5120":
                        mat_local = CvInvoke.Imread("../PictureSet/2048x5120.jpg");
                        break;
                    default:
                        captureOn = true;
                        capture = new VideoCapture(cameraConfig.camera_id, VideoCapture.API.DShow);
                        break;
                }
                timer1.Start();
            }
            else
            {
                ConnectCam.Text = "打开摄像头";
                timer1.Stop();
                captureOn = false;
                try
                {
                    capture.Dispose();
                }
                catch { }
            }
        }

        ///保存图片
        private void CaptureImg_Click(object sender, EventArgs e)
        {
            SavePicture();
            //byte[] sendData = new byte[h * w * c + 8];
            //BitConverter.GetBytes().CopyTo(sendData, 0);
            //BitConverter.GetBytes().CopyTo(sendData, 2);
            //BitConverter.GetBytes().CopyTo(sendData, 4);
            //BitConverter.GetBytes(++imgnum).CopyTo(sendData, 6);
            //mat.GetRawData().CopyTo(sendData, 8);

            //try
            //{
            //    TcpSocket.Send(sendData);
            //}
            //catch
            //{
            //}
        }

        ///获取摄像头图片
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (captureOn)
                //mat = capture.QuerySmallFrame();
                mat = capture.QueryFrame();
            else
                mat = mat_local;
            pictureReady = true;
            pictureSizeStatusStrip.Text = $"图片尺寸：{mat.Size.Width} × {mat.Size.Height}";
        }

        ///本地检测模拟
        private void timer2_Tick(object sender, EventArgs e)
        {
            Mat temp_mat = new Mat();
            CvInvoke.CvtColor(mat, temp_mat, ColorConversion.Bgr2Gray);
            var result = faceRecognizer.Predict(temp_mat);
            int num = result.Label;
            Rectangle[] temp_rect = faceDetector.DetectMultiScale(mat);
            for (int i = 0; i < temp_rect.Length; i++)
            {
                CvInvoke.Rectangle(mat, temp_rect[i], new MCvScalar(0, 0, 255), 4);
            }
            if (temp_rect.Length > 0)
            {
                CvInvoke.PutText(mat, face_class[num], temp_rect[0].Location, FontFace.HersheyComplex, 1, new MCvScalar(0, 0, 255), 2);
            }
            Image<Bgr, byte> image = mat.ToImage<Bgr, byte>();
            pictureBox.Image = image.Bitmap;
        }

        ///保存图片
        private void SavePicture()
        {
            //if (options.cameraSetting.textBox3.Text != "")
            //    fileName = options.cameraSetting.textBox3.Text + "\\";
            try
            {
                if (Transfer.Text == "停止传输")
                    pictureBox1.Image.Save("../Savepic/" + imgnum + ".jpg");
                else
                    pictureBox.Image.Save("../Savepic/" + imgnum + ".jpg");
                textBox1.AppendText($"图像\"{imgnum}.jpg\"保存成功！\r\n");
                imgnum++;
            }
            catch
            {
                textBox1.AppendText("保存失败！\r\n");
            }
        }

        ///保存设置
        public static void SavingConfig()
        {
            XDocument xmlDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("root",
                    new XElement("cameraConfig",
                        new XElement("camera_id", $"{cameraConfig.camera_id}")),
                    new XElement("ipuConfig",
                        new XElement("service_ip_address", $"{ipuConfig.service_ip_address}"),
                        new XElement("service_ip_port", $"{ipuConfig.service_ip_port}"),
                        new XElement("client_ip_address", $"{ipuConfig.client_ip_address}"),
                        new XElement("client_ip_port", $"{ipuConfig.client_ip_port}"),
                        new XElement("mode", $"{ipuConfig.mode}"),
                        new XElement("ModelSelect", $"{ipuConfig.ModelSelect}"),
                        new XElement("picture_path", $"{ipuConfig.picture_path}"),
                        new XElement("picture_size", $"{ipuConfig.picture_size}"))));
            try
            {
                xmlDoc.Save(xmlpath);
            }
            catch (Exception e)
            {
                //显示错误信息
                MessageBox.Show(e.Message);
            }
        }

        ///显示进程
        private void disp_thread()
        {
            while (!dispThreadStop)
            {
                if (receiveConsult == true)
                {

                }
                else if (pictureReady)
                //表示没有正在处理，所以没有处理的话返回原图像
                {
                    pictureBox.Image = mat.Bitmap;
                    pictureReady = false;
                }
            }
        }

        ///关闭程序
        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定要关闭吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                SavingConfig();
                try
                {
                    TcpSocket.Dispose();
                    capture.Dispose();
                }
                catch { }
                e.Cancel = false;//点击OK
                dispThreadStop = true;
                Environment.Exit(Environment.ExitCode);
            }
            else
            {
                e.Cancel = true;
            }
        }

        ///开始检测
        private void startProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startProcessingToolStripMenuItem.Enabled = false;
            timer2.Start();
            receiveConsult = true;
            stopProcessingToolStripMenuItem.Enabled = true;
        }

        ///停止检测
        private void stopProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopProcessingToolStripMenuItem.Enabled = false;
            timer2.Stop();
            receiveConsult = false;
            startProcessingToolStripMenuItem.Enabled = true;
        }
    }
}
