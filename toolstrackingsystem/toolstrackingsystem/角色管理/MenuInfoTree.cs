using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using log4net;
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ViewEntity.toolstrackingsystem;
using dbentity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class MenuInfoTree : Office2007Form
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IMenuManageService _menuManageService;
        private IRoleManageService _roleManageService;
        private Sys_User_Role userRole;
        public MenuInfoTree()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        private void MenuInfoTree_Load(object sender, EventArgs e)
        {
            _menuManageService = Program.container.Resolve<IMenuManageService>() as MenuManageService;
            _roleManageService = Program.container.Resolve<IRoleManageService>() as RoleManageService;
            userRole = this.Tag as Sys_User_Role;
            try
            {
                List<MenuInfoEntity> resultEntity = _menuManageService.GetMenuTreeInfoList();
                //MenuInfo_treeView.Nodes.Add("权限列表");
                for (int i = 0; i < resultEntity.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = resultEntity[i].ParentMenuInfo.MenuName;
                    node.Tag = resultEntity[i].ParentMenuInfo;
                    MenuInfo_treeView.Nodes.Add(node);

                    for (int j = 0; j < resultEntity[i].ChildMenuInfoList.Count; j++)
                    {
                        TreeNode childnode = new TreeNode();
                        childnode.Text = resultEntity[i].ChildMenuInfoList[j].MenuName;
                        childnode.Tag = resultEntity[i].ChildMenuInfoList[j];
                        node.Nodes.Add(childnode);
                    }
                }
            }
            catch (Exception ex)
            { 
                
            }
        }
        //选中节点之后，选中节点的所有子节点
        private void setChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
            {
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    setChildNodeCheckedState(tn, state);
                }
            }
        }
        //取消节点选中状态之后，取消所有父节点的选中状态
        private void setParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                setParentNodeCheckedState(currNode.Parent, state);
            }
        }

        private void MenuInfo_treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Checked == true)
                {
                    //选中节点之后，选中该节点所有的子节点
                    setChildNodeCheckedState(e.Node, true);
                }
                else if (e.Node.Checked == false)
                {
                    //取消节点选中状态之后，取消该节点所有子节点选中状态
                    setChildNodeCheckedState(e.Node, false);
                    //如果节点存在父节点，取消父节点的选中状态
                    if (e.Node.Parent != null)
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
            }
        }

        private void AddRole_button_Click(object sender, EventArgs e)
        {
            string MenuID = "";
            for (int i = 0; i < MenuInfo_treeView.Nodes.Count; i++)
            {
                var item = MenuInfo_treeView.Nodes[i];
                for (int j = 0; j < item.Nodes.Count; j++)
                {
                    var childNode = item.Nodes[j];
                    if (childNode.Checked)
                    {
                        Sys_Menu_Info roleInfo = childNode.Tag as Sys_Menu_Info;
                        MenuID += roleInfo.FileName+",";
                    }
                }
            }

            Sys_User_Role role = new Sys_User_Role();
            role.RoleCode = userRole.RoleCode;
            role.RoleName = userRole.RoleName;
            role.MenuID = MenuID.Substring(0, MenuID.Length - 1);
            userRole.MenuID = MenuID.Substring(0,MenuID.Length-1);
            if (_roleManageService.InserUserRole(userRole))
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("添加成功");
                this.Dispose();
            }
        }
    }
}
