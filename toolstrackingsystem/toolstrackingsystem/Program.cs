using common.toolstrackingsystem;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toolstrackingsystem
{
    static class Program
    {
        public static UnityContainer container;
        public static Socket SocketClient;
        public static string ScanIpAddress = CommonHelper.GetConfigValue("scanAddress");
        public static string ScanPort = CommonHelper.GetConfigValue("scanPort");


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            ILog logger = log4net.LogManager.GetLogger(typeof(Program)); Application.EnableVisualStyles();
            //访问sqlserver数据库，使用扩展时，必须取消注释下面这两行语句，访问数据库是，自动根据数据库类型，生成对应风格的sql语句
            DapperExtensionsConfiguration deconfig = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new SqlServerDialect());
            DapperExtensions.DapperExtensions.Configure(deconfig);//配置全局的sqlserver数据库使用到的专业用语（dialect n.	方言，土语; 语调; [语] 语支; 专业用语;
            logger.Info("程序开始启动");
            Application.SetCompatibleTextRenderingDefault(false);

            #region 声明unity注入全局变量
            container = new UnityContainer();
            UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName)
as UnityConfigurationSection;
            configuration.Configure(container, "defaultContainer");
            #endregion

            //ToolInfoManage formLogin = new ToolInfoManage();
            //formLogin.ShowDialog();

            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            //DialogResult就是用来判断是否返回父窗体的
            if (formLogin.DialogResult == DialogResult.OK)
            {
                //启动智能相机监听程序
                StartScanListion(logger);


                //在线程中打开主窗体
                FormMain formtest = new FormMain();
                formtest.Tag = formLogin.Tag;
                Application.Run(formtest);
            }
        }

        private static void StartScanListion(ILog logger)
        {
            if (string.IsNullOrWhiteSpace(ScanIpAddress) || string.IsNullOrWhiteSpace(ScanPort))
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1}", "program--StartScanListion", "您必须完善您的智能相机配置!");
                return;
            }
            try
            {

                Thread threadClient = new Thread(new ParameterizedThreadStart(ConnectTo)); //链接重试

                //将窗体线程设置为与后台同步
                threadClient.IsBackground = true;

                //启动线程
                threadClient.Start(logger);

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "program--StartScanListion", ex.Message, ex.StackTrace, ex.Source);

            }
        }
        private static void ConnectTo(object loggerObj)
        {
            var logger = loggerObj as ILog;


            while (!(SocketClient != null && SocketClient.Connected))
            {
                try
                {
                    SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    IPAddress ipaddressObj = IPAddress.Parse(ScanIpAddress);
                    //将获取的ip地址和端口号绑定到网络节点endpoint上
                    IPEndPoint endpoint = new IPEndPoint(ipaddressObj, int.Parse(ScanPort));

                    //这里客户端套接字连接到网络节点(服务端)用的方法是Connect 而不是Bind
                    SocketClient.Connect(endpoint);
                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "program--StartScanListion", ex.Message, ex.StackTrace, ex.Source);
                    Thread.Sleep(10000);
                }
            }


        }

    }

}