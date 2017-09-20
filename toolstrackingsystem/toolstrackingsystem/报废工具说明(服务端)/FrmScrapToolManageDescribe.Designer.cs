namespace toolstrackingsystem
{
    partial class FrmScrapToolManageDescribe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ShiJiaZhuang = new DevComponents.DotNetBar.SuperTabItem();
            this.Search_buttonX = new DevComponents.DotNetBar.ButtonX();
            this.tbSearchName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbSearchCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbSearchcategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbSearchBlong = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.DongSuo = new DevComponents.DotNetBar.SuperTabItem();
            this.NanSuo = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabStrip1 = new DevComponents.DotNetBar.SuperTabStrip();
            this.XiSuo = new DevComponents.DotNetBar.SuperTabItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tool_RepairdataGridView = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.superTabStrip1)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tool_RepairdataGridView)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShiJiaZhuang
            // 
            this.ShiJiaZhuang.FixedTabSize = new System.Drawing.Size(100, 0);
            this.ShiJiaZhuang.GlobalItem = false;
            this.ShiJiaZhuang.Name = "ShiJiaZhuang";
            this.ShiJiaZhuang.Text = "石所";
            // 
            // Search_buttonX
            // 
            this.Search_buttonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Search_buttonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Search_buttonX.Location = new System.Drawing.Point(778, 32);
            this.Search_buttonX.Name = "Search_buttonX";
            this.Search_buttonX.Size = new System.Drawing.Size(75, 23);
            this.Search_buttonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Search_buttonX.TabIndex = 21;
            this.Search_buttonX.Text = "查找";
            this.Search_buttonX.Click += new System.EventHandler(this.Search_buttonX_Click);
            // 
            // tbSearchName
            // 
            // 
            // 
            // 
            this.tbSearchName.Border.Class = "TextBoxBorder";
            this.tbSearchName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSearchName.Location = new System.Drawing.Point(643, 30);
            this.tbSearchName.Name = "tbSearchName";
            this.tbSearchName.PreventEnterBeep = true;
            this.tbSearchName.Size = new System.Drawing.Size(100, 21);
            this.tbSearchName.TabIndex = 20;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(577, 30);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 19;
            this.labelX4.Text = "工具名称：";
            // 
            // tbSearchCode
            // 
            // 
            // 
            // 
            this.tbSearchCode.Border.Class = "TextBoxBorder";
            this.tbSearchCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSearchCode.Location = new System.Drawing.Point(450, 30);
            this.tbSearchCode.Name = "tbSearchCode";
            this.tbSearchCode.PreventEnterBeep = true;
            this.tbSearchCode.Size = new System.Drawing.Size(107, 21);
            this.tbSearchCode.TabIndex = 18;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(387, 30);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(77, 23);
            this.labelX3.TabIndex = 17;
            this.labelX3.Text = "工具编号：";
            // 
            // cbSearchcategory
            // 
            this.cbSearchcategory.DisplayMember = "Text";
            this.cbSearchcategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSearchcategory.FormattingEnabled = true;
            this.cbSearchcategory.ItemHeight = 15;
            this.cbSearchcategory.Location = new System.Drawing.Point(254, 30);
            this.cbSearchcategory.Name = "cbSearchcategory";
            this.cbSearchcategory.Size = new System.Drawing.Size(121, 21);
            this.cbSearchcategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbSearchcategory.TabIndex = 16;
            // 
            // cbSearchBlong
            // 
            this.cbSearchBlong.DisplayMember = "Text";
            this.cbSearchBlong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSearchBlong.FormattingEnabled = true;
            this.cbSearchBlong.ItemHeight = 15;
            this.cbSearchBlong.Location = new System.Drawing.Point(78, 30);
            this.cbSearchBlong.Name = "cbSearchBlong";
            this.cbSearchBlong.Size = new System.Drawing.Size(121, 21);
            this.cbSearchBlong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbSearchBlong.TabIndex = 15;
            // 
            // DongSuo
            // 
            this.DongSuo.FixedTabSize = new System.Drawing.Size(100, 0);
            this.DongSuo.GlobalItem = false;
            this.DongSuo.Name = "DongSuo";
            this.DongSuo.Text = "东所";
            // 
            // NanSuo
            // 
            this.NanSuo.FixedTabSize = new System.Drawing.Size(100, 0);
            this.NanSuo.GlobalItem = false;
            this.NanSuo.Name = "NanSuo";
            this.NanSuo.Text = "南所";
            // 
            // superTabStrip1
            // 
            this.superTabStrip1.AutoSelectAttachedControl = false;
            // 
            // 
            // 
            this.superTabStrip1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.superTabStrip1.ContainerControlProcessDialogKey = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabStrip1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabStrip1.ControlBox.MenuBox.Name = "";
            this.superTabStrip1.ControlBox.Name = "";
            this.superTabStrip1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabStrip1.ControlBox.MenuBox,
            this.superTabStrip1.ControlBox.CloseBox});
            this.superTabStrip1.Location = new System.Drawing.Point(-2, 3);
            this.superTabStrip1.Name = "superTabStrip1";
            this.superTabStrip1.ReorderTabsEnabled = true;
            this.superTabStrip1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabStrip1.SelectedTabIndex = 0;
            this.superTabStrip1.Size = new System.Drawing.Size(1480, 28);
            this.superTabStrip1.TabCloseButtonHot = null;
            this.superTabStrip1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabStrip1.TabIndex = 0;
            this.superTabStrip1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.NanSuo,
            this.DongSuo,
            this.XiSuo,
            this.ShiJiaZhuang});
            this.superTabStrip1.Text = "superTabStrip1";
            this.superTabStrip1.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.superTabStrip1_SelectedTabChanged);
            // 
            // XiSuo
            // 
            this.XiSuo.FixedTabSize = new System.Drawing.Size(100, 0);
            this.XiSuo.GlobalItem = false;
            this.XiSuo.Name = "XiSuo";
            this.XiSuo.Text = "西所";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(216, 30);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(57, 23);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "类别：";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.tool_RepairdataGridView);
            this.groupPanel2.Controls.Add(this.superTabStrip1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(4, 103);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1481, 595);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 4;
            // 
            // tool_RepairdataGridView
            // 
            this.tool_RepairdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tool_RepairdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tool_RepairdataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.tool_RepairdataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.tool_RepairdataGridView.Location = new System.Drawing.Point(3, 37);
            this.tool_RepairdataGridView.Name = "tool_RepairdataGridView";
            this.tool_RepairdataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tool_RepairdataGridView.RowTemplate.Height = 23;
            this.tool_RepairdataGridView.Size = new System.Drawing.Size(1475, 549);
            this.tool_RepairdataGridView.TabIndex = 1;
            this.tool_RepairdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tool_RepairdataGridView_CellContentClick);
            this.tool_RepairdataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tool_RepairdataGridView_CellContentDoubleClick);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(39, 30);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(57, 23);
            this.labelX1.TabIndex = 13;
            this.labelX1.Text = "配属：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Search_buttonX);
            this.groupPanel1.Controls.Add(this.tbSearchName);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.tbSearchCode);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.cbSearchcategory);
            this.groupPanel1.Controls.Add(this.cbSearchBlong);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(5, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1480, 95);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 3;
            // 
            // FrmScrapToolManageDescribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 705);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "FrmScrapToolManageDescribe";
            this.Text = "FrmScrapToolManage";
            this.Load += new System.EventHandler(this.FrmScrapToolManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabStrip1)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tool_RepairdataGridView)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabItem ShiJiaZhuang;
        private DevComponents.DotNetBar.ButtonX Search_buttonX;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSearchName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSearchCode;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSearchcategory;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSearchBlong;
        private DevComponents.DotNetBar.SuperTabItem DongSuo;
        private DevComponents.DotNetBar.SuperTabItem NanSuo;
        public DevComponents.DotNetBar.SuperTabStrip superTabStrip1;
        private DevComponents.DotNetBar.SuperTabItem XiSuo;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX tool_RepairdataGridView;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;


    }
}