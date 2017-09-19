﻿using System;
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
using System.Runtime.Caching;
using common.toolstrackingsystem;
using ViewEntity.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using dbentity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmlPullRepairedTool : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(ToolRepairManageNew));
        public IToolRepairRecordService _toolRepairRecordService;
        public IToolInfoService _toolInfoService;
        public string dataBase = MemoryCache.Default.Get("clientName") != null ? MemoryCache.Default.Get("clientName").ToString() : CommonHelper.GetConfigValue("defaultDataBase");
        List<RepairedToolForReceiveEntity> resultList = new List<RepairedToolForReceiveEntity>();
        public event TransfDelegate transfDelegate;
        public FrmlPullRepairedTool()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmlPullRepairedTool_Load(object sender, EventArgs e)
        {
            _toolInfoService = Program.container.Resolve<IToolInfoService>();
            _toolRepairRecordService = Program.container.Resolve<ToolRepairRecordService>();
            #region 初始化配属，类别combox
            var categorys = _toolInfoService.GetCategoryByClassify(0);
            var categoryBlongs = categorys.Where(v => v.classification == 1).Any() ? categorys.Where(v => v.classification == 1).ToList() : new List<t_ToolType>();
            var blongs = new List<t_ToolType>();
            blongs.Add(new t_ToolType
            {
                TypeName = "全部"

            });
            blongs.AddRange(categoryBlongs);
            var categoryCategory = categorys.Where(v => v.classification == 2).Any() ? categorys.Where(v => v.classification == 2).ToList() : new List<t_ToolType>();
            var cates = new List<t_ToolType>();
            cates.Add(new t_ToolType
            {

                TypeName = "全部"

            });
            cates.AddRange(categoryCategory);
            this.cbSearchBlong.DataSource = blongs;
            this.cbSearchBlong.DisplayMember = "TypeName";
            this.cbSearchBlong.ValueMember = "TypeName";

            this.cbSearchcategory.DataSource = cates;
            this.cbSearchcategory.DisplayMember = "TypeName";
            this.cbSearchcategory.ValueMember = "TypeName";
            #endregion

            #region 初始化supertab默认选择的数据库
            foreach (SuperTabItem tab in superTabStrip1.Tabs)
            {
                if (tab.Name == dataBase)
                {
                    superTabStrip1.SelectedTab = tab;
                }
            }
            #endregion
        }

        private void tool_RepairdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewColumn column = tool_RepairdataGridView.Columns[e.ColumnIndex];
                    if (column is DataGridViewButtonColumn)
                    {
                        string toolCode = tool_RepairdataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();

                        t_ToolRepairRecord repairInfo = new t_ToolRepairRecord();
                        repairInfo = _toolRepairRecordService.GetToolRepairByToolCodeAndStatus(toolCode, 3);
                        if (repairInfo != null)
                        {
                            t_ToolInfo toolInfo = new t_ToolInfo();
                            toolInfo = _toolInfoService.GetToolByCode(toolCode);
                            if (toolInfo == null)
                            {
                                MessageBox.Show("工具信息不存在，请重新选择工具");
                                return;
                            }
                            toolInfo.IsRepaired = 0;

                            repairInfo.ToolStatus = 4;
                            repairInfo.PullPerCode = LoginHelper.UserCode;
                            repairInfo.PullPerName = LoginHelper.UserName;
                            repairInfo.PullTime = DateTime.Now;

                            if (_toolRepairRecordService.UpdateToolReceiveStatus(repairInfo)&&_toolInfoService.UpdateTool(toolInfo))
                            {
                                
                                MessageBox.Show("状态设置成功");
                                Search_buttonX_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("状态设置失败");
                            }
                        }
                        else
                        {
                            MessageBox.Show("该工具送修记录不存在，请重新选择");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FrmlPullRepairedTool--tool_RepairdataGridView_CellContentClick", ex.Message, ex.StackTrace, ex.Source);
            }
        }

        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            try
            {
                if (tool_RepairdataGridView.Columns.Count >= 8)
                {
                    tool_RepairdataGridView.Columns.RemoveAt(7);
                }
                t_ToolRepairRecord repairInfo = new t_ToolRepairRecord();
                repairInfo.TypeName = cbSearchBlong.SelectedValue.ToString() != "全部" ? cbSearchBlong.SelectedValue.ToString() : "";
                repairInfo.ChildTypeName = cbSearchcategory.SelectedValue.ToString() != "全部" ? cbSearchcategory.SelectedValue.ToString() : "";
                repairInfo.ToolCode = tbSearchCode.Text;
                repairInfo.ToolName = tbSearchName.Text;
                repairInfo.ToolStatus = 3;
                resultList = _toolRepairRecordService.GetRepairedToolForReceive(repairInfo);
                for (int i = 0; i < tool_RepairdataGridView.Columns.Count; i++)
                {
                    tool_RepairdataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                //tool_RepairdataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                tool_RepairdataGridView.DataSource = resultList;
                tool_RepairdataGridView.Columns[0].HeaderText = "配属";
                tool_RepairdataGridView.Columns[1].HeaderText = "类别";
                tool_RepairdataGridView.Columns[2].HeaderText = "工具编码";
                tool_RepairdataGridView.Columns[3].HeaderText = "工具名称";
                tool_RepairdataGridView.Columns[4].HeaderText = "送修时间";
                tool_RepairdataGridView.Columns[5].HeaderText = "送修人员";
                tool_RepairdataGridView.Columns[6].HeaderText = "备注";
                DataGridViewButtonColumn PullButton = new DataGridViewButtonColumn();
                PullButton.HeaderText = "操作";
                PullButton.Text = "领取";
                PullButton.Name = "PullButton";
                PullButton.UseColumnTextForButtonValue = true;
                tool_RepairdataGridView.Columns.AddRange(PullButton);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("具体位置={0},重要参数Message={1},StackTrace={2},Source={3}", "FrmlPullRepairedTool--Search_buttonX_Click", ex.Message, ex.StackTrace, ex.Source);
            }

        }

        private void superTabStrip1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            string name = e.NewValue.Name;
            if (MemoryCacheHelper.SetMemoryCache(name))
            {
                //1.刷新datagridview页面
                Search_buttonX_Click(sender, e);
                //2.更新显示数据库名称
                transfDelegate();
            }
        }

        private void tool_RepairdataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1); 
        }
    }
}
