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
        protected UnityContainer container = new UnityContainer();
        public FormBase()
        {
            UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName)
            as UnityConfigurationSection;
            configuration.Configure(container, "defaultContainer");
        }
    }
}
