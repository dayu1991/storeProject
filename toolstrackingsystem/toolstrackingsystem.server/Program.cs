using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toolstrackingsystem.server
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
                //在线程中打开主窗体
                FormMain formtest = new FormMain();
                formtest.Tag = formLogin.Tag;
                Application.Run(formtest);
            }

        }
    }
}
