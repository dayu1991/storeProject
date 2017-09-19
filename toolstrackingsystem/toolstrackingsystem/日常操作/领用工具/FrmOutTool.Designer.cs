namespace toolstrackingsystem
{
    partial class FrmOutTool
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
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtiSelect = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnAddTool = new DevComponents.DotNetBar.ButtonX();
            this.btnOutContinue = new DevComponents.DotNetBar.ButtonX();
            this.tbEditoutdescribes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbEditCodeOut = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOut = new DevComponents.DotNetBar.ButtonX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.cbEditOutTime = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tbTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbChildTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCheckTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtiSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dtiSelect);
            this.groupPanel2.Controls.Add(this.btnAddTool);
            this.groupPanel2.Controls.Add(this.btnOutContinue);
            this.groupPanel2.Controls.Add(this.tbEditoutdescribes);
            this.groupPanel2.Controls.Add(this.tbEditCodeOut);
            this.groupPanel2.Controls.Add(this.btnOut);
            this.groupPanel2.Controls.Add(this.labelX11);
            this.groupPanel2.Controls.Add(this.labelX10);
            this.groupPanel2.Controls.Add(this.cbEditOutTime);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(6, 582);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1471, 111);
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
            this.groupPanel2.TabIndex = 3;
            // 
            // dtiSelect
            // 
            // 
            // 
            // 
            this.dtiSelect.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiSelect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiSelect.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiSelect.ButtonDropDown.Visible = true;
            this.dtiSelect.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dtiSelect.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiSelect.IsPopupCalendarOpen = false;
            this.dtiSelect.Location = new System.Drawing.Point(767, 13);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtiSelect.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiSelect.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiSelect.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiSelect.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiSelect.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiSelect.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiSelect.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiSelect.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiSelect.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiSelect.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiSelect.MonthCalendar.DisplayMonth = new System.DateTime(2017, 7, 1, 0, 0, 0, 0);
            this.dtiSelect.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtiSelect.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiSelect.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiSelect.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiSelect.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiSelect.MonthCalendar.TodayButtonVisible = true;
            this.dtiSelect.Name = "dtiSelect";
            this.dtiSelect.Size = new System.Drawing.Size(179, 21);
            this.dtiSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiSelect.TabIndex = 34;
            this.dtiSelect.Visible = false;
            // 
            // btnAddTool
            // 
            this.btnAddTool.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddTool.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddTool.Location = new System.Drawing.Point(444, 14);
            this.btnAddTool.Name = "btnAddTool";
            this.btnAddTool.Size = new System.Drawing.Size(40, 23);
            this.btnAddTool.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddTool.TabIndex = 33;
            this.btnAddTool.Text = "增加";
            this.btnAddTool.Click += new System.EventHandler(this.btnAddTool_Click);
            // 
            // btnOutContinue
            // 
            this.btnOutContinue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOutContinue.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOutContinue.Location = new System.Drawing.Point(1118, 13);
            this.btnOutContinue.Name = "btnOutContinue";
            this.btnOutContinue.Size = new System.Drawing.Size(83, 74);
            this.btnOutContinue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOutContinue.TabIndex = 32;
            this.btnOutContinue.Text = "继续领用";
            this.btnOutContinue.Click += new System.EventHandler(this.btnOutContinue_Click);
            // 
            // tbEditoutdescribes
            // 
            // 
            // 
            // 
            this.tbEditoutdescribes.Border.Class = "TextBoxBorder";
            this.tbEditoutdescribes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditoutdescribes.Location = new System.Drawing.Point(141, 64);
            this.tbEditoutdescribes.Name = "tbEditoutdescribes";
            this.tbEditoutdescribes.PreventEnterBeep = true;
            this.tbEditoutdescribes.Size = new System.Drawing.Size(805, 21);
            this.tbEditoutdescribes.TabIndex = 19;
            // 
            // tbEditCodeOut
            // 
            // 
            // 
            // 
            this.tbEditCodeOut.Border.Class = "TextBoxBorder";
            this.tbEditCodeOut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditCodeOut.Location = new System.Drawing.Point(141, 14);
            this.tbEditCodeOut.Name = "tbEditCodeOut";
            this.tbEditCodeOut.PreventEnterBeep = true;
            this.tbEditCodeOut.Size = new System.Drawing.Size(297, 21);
            this.tbEditCodeOut.TabIndex = 1;
            this.tbEditCodeOut.TextChanged += new System.EventHandler(this.tbEditCode_TextChanged);
            // 
            // btnOut
            // 
            this.btnOut.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOut.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOut.Location = new System.Drawing.Point(995, 13);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(81, 74);
            this.btnOut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOut.TabIndex = 21;
            this.btnOut.Text = "确认领用";
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(52, 13);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(123, 23);
            this.labelX11.TabIndex = 27;
            this.labelX11.Text = "工具/包编码：";
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(52, 64);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(83, 23);
            this.labelX10.TabIndex = 18;
            this.labelX10.Text = "领用说明：";
            // 
            // cbEditOutTime
            // 
            this.cbEditOutTime.DisplayMember = "Text";
            this.cbEditOutTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEditOutTime.FormattingEnabled = true;
            this.cbEditOutTime.ItemHeight = 15;
            this.cbEditOutTime.Location = new System.Drawing.Point(603, 13);
            this.cbEditOutTime.Name = "cbEditOutTime";
            this.cbEditOutTime.Size = new System.Drawing.Size(158, 21);
            this.cbEditOutTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEditOutTime.TabIndex = 7;
            this.cbEditOutTime.SelectedIndexChanged += new System.EventHandler(this.cbEditOutTime_SelectedIndexChanged);
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(514, 14);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(85, 23);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "使用时间：";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbTypeName,
            this.tbChildTypeName,
            this.tbPackNo,
            this.tbPackName,
            this.tbToolCode,
            this.tbToolName,
            this.tbModel,
            this.tbPosition,
            this.tbRemarks,
            this.tbCheckTime});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(6, 13);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1471, 563);
            this.dataGridViewX1.TabIndex = 4;
            // 
            // tbTypeName
            // 
            this.tbTypeName.DataPropertyName = "TypeName";
            this.tbTypeName.HeaderText = "工具配属";
            this.tbTypeName.Name = "tbTypeName";
            this.tbTypeName.ReadOnly = true;
            // 
            // tbChildTypeName
            // 
            this.tbChildTypeName.DataPropertyName = "ChildTypeName";
            this.tbChildTypeName.HeaderText = "工具类别";
            this.tbChildTypeName.Name = "tbChildTypeName";
            this.tbChildTypeName.ReadOnly = true;
            // 
            // tbPackNo
            // 
            this.tbPackNo.DataPropertyName = "PackCode";
            this.tbPackNo.HeaderText = "包编号";
            this.tbPackNo.Name = "tbPackNo";
            this.tbPackNo.ReadOnly = true;
            // 
            // tbPackName
            // 
            this.tbPackName.DataPropertyName = "PackName";
            this.tbPackName.HeaderText = "包名称";
            this.tbPackName.Name = "tbPackName";
            this.tbPackName.ReadOnly = true;
            this.tbPackName.Width = 150;
            // 
            // tbToolCode
            // 
            this.tbToolCode.DataPropertyName = "ToolCode";
            this.tbToolCode.HeaderText = "编号";
            this.tbToolCode.Name = "tbToolCode";
            this.tbToolCode.ReadOnly = true;
            this.tbToolCode.Width = 150;
            // 
            // tbToolName
            // 
            this.tbToolName.DataPropertyName = "ToolName";
            this.tbToolName.HeaderText = "名称";
            this.tbToolName.Name = "tbToolName";
            this.tbToolName.ReadOnly = true;
            this.tbToolName.Width = 150;
            // 
            // tbModel
            // 
            this.tbModel.DataPropertyName = "Models";
            this.tbModel.HeaderText = "型号";
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            this.tbModel.Width = 150;
            // 
            // tbPosition
            // 
            this.tbPosition.DataPropertyName = "Location";
            this.tbPosition.HeaderText = "位置";
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.ReadOnly = true;
            this.tbPosition.Width = 150;
            // 
            // tbRemarks
            // 
            this.tbRemarks.DataPropertyName = "Remarks";
            this.tbRemarks.HeaderText = "备注";
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.ReadOnly = true;
            this.tbRemarks.Width = 200;
            // 
            // tbCheckTime
            // 
            this.tbCheckTime.DataPropertyName = "OptionPerson";
            this.tbCheckTime.HeaderText = "操作人员";
            this.tbCheckTime.Name = "tbCheckTime";
            this.tbCheckTime.ReadOnly = true;
            this.tbCheckTime.Width = 150;
            // 
            // FrmOutTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 698);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.groupPanel2);
            this.Name = "FrmOutTool";
            this.Text = "FrmOutTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOutTool_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmOutTool_FormClosed);
            this.Load += new System.EventHandler(this.FrmOutTool_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOutTool_KeyDown);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtiSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditCodeOut;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.ButtonX btnOut;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditoutdescribes;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbEditOutTime;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonX btnOutContinue;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnAddTool;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbChildTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbCheckTime;
    }
}