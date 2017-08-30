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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.packCode_textBox = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.Set_Instead_button = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pagerControl1 = new toolstrackingsystem.PageControl.PagerControl();
            this.ScrapTool_dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.Scrap_ToolInfoCode_Detail_textBox = new System.Windows.Forms.TextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.Search_Scraptool_button = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrapTool_dataGridViewX2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.packCode_textBox);
            this.groupPanel3.Controls.Add(this.labelX1);
            this.groupPanel3.Controls.Add(this.Set_Instead_button);
            this.groupPanel3.Controls.Add(this.groupPanel4);
            this.groupPanel3.Controls.Add(this.buttonX2);
            this.groupPanel3.Controls.Add(this.Scrap_ToolInfoCode_Detail_textBox);
            this.groupPanel3.Controls.Add(this.labelX3);
            this.groupPanel3.Controls.Add(this.Search_Scraptool_button);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(17, 8);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(906, 522);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 11;
            // 
            // packCode_textBox
            // 
            this.packCode_textBox.Location = new System.Drawing.Point(94, 22);
            this.packCode_textBox.Name = "packCode_textBox";
            this.packCode_textBox.Size = new System.Drawing.Size(125, 21);
            this.packCode_textBox.TabIndex = 24;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(33, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(66, 23);
            this.labelX1.TabIndex = 23;
            this.labelX1.Text = "包编码:";
            // 
            // Set_Instead_button
            // 
            this.Set_Instead_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Set_Instead_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Set_Instead_button.Location = new System.Drawing.Point(578, 22);
            this.Set_Instead_button.Name = "Set_Instead_button";
            this.Set_Instead_button.Size = new System.Drawing.Size(75, 23);
            this.Set_Instead_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Set_Instead_button.TabIndex = 22;
            this.Set_Instead_button.Text = "设为已补充";
            this.Set_Instead_button.Click += new System.EventHandler(this.Set_Instead_button_Click);
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.pagerControl1);
            this.groupPanel4.Controls.Add(this.ScrapTool_dataGridViewX2);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(5, 65);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(890, 447);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 21;
            // 
            // pagerControl1
            // 
            this.pagerControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(0, 394);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 50;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(882, 44);
            this.pagerControl1.TabIndex = 2;
            this.pagerControl1.OnPageChanged += new System.EventHandler(this.pagerControl1_OnPageChanged);
            // 
            // ScrapTool_dataGridViewX2
            // 
            this.ScrapTool_dataGridViewX2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScrapTool_dataGridViewX2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ScrapTool_dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ScrapTool_dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle2;
            this.ScrapTool_dataGridViewX2.EnableHeadersVisualStyles = false;
            this.ScrapTool_dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.ScrapTool_dataGridViewX2.Location = new System.Drawing.Point(0, 0);
            this.ScrapTool_dataGridViewX2.Name = "ScrapTool_dataGridViewX2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScrapTool_dataGridViewX2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ScrapTool_dataGridViewX2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ScrapTool_dataGridViewX2.RowTemplate.Height = 23;
            this.ScrapTool_dataGridViewX2.Size = new System.Drawing.Size(882, 393);
            this.ScrapTool_dataGridViewX2.TabIndex = 1;
            this.ScrapTool_dataGridViewX2.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.ScrapTool_dataGridViewX2_RowStateChanged);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(672, 22);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 20;
            this.buttonX2.Text = "导出";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // Scrap_ToolInfoCode_Detail_textBox
            // 
            this.Scrap_ToolInfoCode_Detail_textBox.Location = new System.Drawing.Point(301, 22);
            this.Scrap_ToolInfoCode_Detail_textBox.Name = "Scrap_ToolInfoCode_Detail_textBox";
            this.Scrap_ToolInfoCode_Detail_textBox.Size = new System.Drawing.Size(125, 21);
            this.Scrap_ToolInfoCode_Detail_textBox.TabIndex = 4;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(240, 22);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(66, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "工具编码:";
            // 
            // Search_Scraptool_button
            // 
            this.Search_Scraptool_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Search_Scraptool_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Search_Scraptool_button.Location = new System.Drawing.Point(475, 22);
            this.Search_Scraptool_button.Name = "Search_Scraptool_button";
            this.Search_Scraptool_button.Size = new System.Drawing.Size(75, 23);
            this.Search_Scraptool_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Search_Scraptool_button.TabIndex = 0;
            this.Search_Scraptool_button.Text = "查询";
            this.Search_Scraptool_button.Click += new System.EventHandler(this.Search_Scraptool_button_Click);
            // 
            // FrmScrapToolManageDescribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 612);
            this.Controls.Add(this.groupPanel3);
            this.Name = "FrmScrapToolManageDescribe";
            this.Text = "FrmScrapToolManage";
            this.Load += new System.EventHandler(this.FrmScrapToolManage_Load);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScrapTool_dataGridViewX2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.DataGridViewX ScrapTool_dataGridViewX2;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.TextBox Scrap_ToolInfoCode_Detail_textBox;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX Search_Scraptool_button;
        private DevComponents.DotNetBar.ButtonX Set_Instead_button;
        private PageControl.PagerControl pagerControl1;
        private System.Windows.Forms.TextBox packCode_textBox;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}