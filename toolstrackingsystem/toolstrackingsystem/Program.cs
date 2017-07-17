using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toolstrackingsystem
{
    static class Program
    {
        public static UnityContainer container;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //独立的log4net.config
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region 声明unity注入全局变量
            container = new UnityContainer();
            UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName)
as UnityConfigurationSection;
            configuration.Configure(container, "defaultContainer");
            #endregion
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            //DialogResult就是用来判断是否返回父窗体的
            if (formLogin.DialogResult == DialogResult.OK)
            {
                //在线程中打开主窗体
                FormMain formtest = new FormMain();
                formtest.Tag = formLogin.Tag;
                Application.Run(formtest);
            }
        }
    }
}
