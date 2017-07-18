using DevComponents.DotNetBar;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toolstrackingsystem
{
    public class FormBase : Office2007RibbonForm
    {
        private Bar bar1;
        protected UnityContainer container = new UnityContainer();
        public FormBase()
        {
            UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName)
            as UnityConfigurationSection;
            configuration.Configure(container, "defaultContainer");
        }

        private void InitializeComponent()
        {
            this.bar1 = new DevComponents.DotNetBar.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Location = new System.Drawing.Point(77, 55);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(124, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar2";
            this.bar1.ItemClick += new System.EventHandler(this.bar1_ItemClick);
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.bar1);
            this.Name = "FormBase";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
