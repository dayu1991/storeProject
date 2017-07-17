using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tcpTest
{
    public partial class Form1 : Form
    {
        private Socket socketClient;
        private Thread threadClient;

        //代理用来设置text的值 （实现另一个线程操作主线程的对象）
        private delegate void SetTextCallback(string text);

        public Form1()
        {
            InitializeComponent();

            this.textBox1.Text = "192.168.0.100";
            this.textBox2.Text = "5025";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ipAddress = this.textBox1.Text;
            var port = this.textBox2.Text;
            if (string.IsNullOrWhiteSpace(ipAddress) || string.IsNullOrWhiteSpace(port))
            {
                MessageBox.Show("ip和端口号必须填写");
                return;
            }
            try
            {
                //定义一个套字节监听  包含3个参数(IP4寻址协议,流式连接,TCP协议)
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //需要获取文本框中的IP地址
                IPAddress ipaddressObj = IPAddress.Parse(ipAddress);
                //将获取的ip地址和端口号绑定到网络节点endpoint上
                IPEndPoint endpoint = new IPEndPoint(ipaddressObj, int.Parse(port));

                //这里客户端套接字连接到网络节点(服务端)用的方法是Connect 而不是Bind
                socketClient.Connect(endpoint);
                //创建一个线程 用于监听服务端发来的消息
                threadClient = new Thread(RecMsg);

                //将窗体线程设置为与后台同步
                threadClient.IsBackground = true;

                //启动线程
                threadClient.Start();
                this.button1.Enabled = false;
                this.button2.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("链接服务端失败");
                this.button1.Enabled = true;
                this.button2.Enabled = false;
                return;                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (socketClient != null && socketClient.Connected)
                {
                    //关闭Socket之前，首选需要把双方的Socket Shutdown掉
                    socketClient.Shutdown(SocketShutdown.Both);

                    //Shutdown掉Socket后主线程停止10ms，保证Socket的Shutdown完成
                    System.Threading.Thread.Sleep(10);

                    //关闭客户端Socket,清理资源
                    socketClient.Close();
                    this.button1.Enabled = true;
                    this.button2.Enabled = false;
                }
                //在点击按钮前socket已经被关闭  可能是服务端操作的断开
                else {
                    this.button1.Enabled = true;
                    this.button2.Enabled = false;
                }
                
               
                
            }
            catch (Exception)
            {

                MessageBox.Show("断开链接失败");
                this.button1.Enabled = false;
                this.button2.Enabled = true;
                return;     
            }
           
        }

        //在给textBox1.text赋值的地方调用以下方法即可
        private void SetText(string text)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.Text = this.richTextBox1.Text + text;
            }
        }

     
        #region 接收服务端发来信息的方法
        private void RecMsg()
        {
            while (true) //持续监听服务端发来的消息
            {
                if (socketClient != null && socketClient.Connected&& socketClient.Available > 0)
                {
                    //定义一个1024*200的内存缓冲区 用于临时性存储接收到的信息
                    byte[] arrRecMsg = new byte[1024 * 200];

                    //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                    int length = socketClient.Receive(arrRecMsg);

                    string strData = Encoding.Default.GetString(arrRecMsg, 0, length);
                   var totalText =   strData;
                   SetText(totalText);
                }
            }
        }

        #endregion
    }
}
