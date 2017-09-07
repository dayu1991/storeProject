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
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using dbentity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmEditRole : Office2007Form
    {
        private IMenuManageService _menuManageService;
        private IRoleManageService _roleManageService;
        public FrmEditRole()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmEditRole_Load(object sender, EventArgs e)
        {
            _menuManageService = Program.container.Resolve<IMenuManageService>() as MenuManageService;
            _roleManageService = Program.container.Resolve<IRoleManageService>() as RoleManageService;

            try
            {
                #region 初始化角色代码和名称
                string roleCode = this.Tag.ToString();
                Sys_User_Role roleInfo = _roleManageService.GetRoleInfo(roleCode);
                if (roleInfo != null)
                {
                    rolecode_textBox.Text = roleInfo.RoleCode;
                    rolename_textBox.Text = roleInfo.RoleName;
                    string[] FileName = roleInfo.MenuID.Split(',');
                    List<MenuInfoEntity> resultEntity = _menuManageService.GetMenuTreeInfoList();
                    //初始化权限列表
                    for (int i = 0; i < resultEntity.Count; i++)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = resultEntity[i].ParentMenuInfo.MenuName;
                        node.Tag = resultEntity[i].ParentMenuInfo;
                        menuinfo_treeView.Nodes.Add(node);
                        int m = 0;
                        for (int j = 0; j < resultEntity[i].ChildMenuInfoList.Count; j++)
                        {
                            TreeNode childnode = new TreeNode();
                            childnode.Text = resultEntity[i].ChildMenuInfoList[j].MenuName;
                            childnode.Tag = resultEntity[i].ChildMenuInfoList[j];
                            if (FileName.Contains(resultEntity[i].ChildMenuInfoList[j].FileName))
                            {
                                childnode.Checked = true;
                                m++;
                            }
                            node.Nodes.Add(childnode);
                            
                        }
                        if (m == resultEntity[i].ChildMenuInfoList.Count)
                        {
                            node.Checked = true;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

            }

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
        private void save_button_Click(object sender, EventArgs e)
        {
            Sys_User_Role userRole = new Sys_User_Role();
            userRole.RoleCode = rolecode_textBox.Text;
            userRole.RoleName = rolename_textBox.Text;
            string MenuID = "";
            for (int i = 0; i < menuinfo_treeView.Nodes.Count; i++)
            {
                var item = menuinfo_treeView.Nodes[i];
                for (int j = 0; j < item.Nodes.Count; j++)
                {
                    var childNode = item.Nodes[j];
                    if (childNode.Checked)
                    {
                        Sys_Menu_Info roleInfo = childNode.Tag as Sys_Menu_Info;
                        MenuID += roleInfo.FileName + ",";
                    }
                }
            }
            userRole.MenuID = MenuID.Substring(0, MenuID.Length - 1);
            if (_roleManageService.UpdateRoleInfo(userRole))
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("修改成功");
                this.Dispose();
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

        private void menuinfo_treeView_AfterCheck(object sender, TreeViewEventArgs e)
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

    }
}
