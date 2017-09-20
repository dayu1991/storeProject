namespace toolstrackingsystem
{
    partial class FrmRepairScrapQuery
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Print_button = new DevComponents.DotNetBar.ButtonX();
            this.to_dateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.from_dateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.Search_buttonX = new DevComponents.DotNetBar.ButtonX();
            this.tbSearchName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbSearchCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbSearchcategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbSearchBlong = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tbTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbChildTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToRepairedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbReceiveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbHandleTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbComplete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPullTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbToolStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbOperate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagerControl1 = new toolstrackingsystem.PageControl.PagerControl();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.to_dateTimeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_dateTimeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Print_button);
            this.groupPanel1.Controls.Add(this.to_dateTimeInput);
            this.groupPanel1.Controls.Add(this.from_dateTimeInput);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX6);
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
            this.groupPanel1.Location = new System.Drawing.Point(4, 4);
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
            this.groupPanel1.TabIndex = 2;
            // 
            // Print_button
            // 
            this.Print_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Print_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Print_button.Location = new System.Drawing.Point(1221, 31);
            this.Print_button.Name = "Print_button";
            this.Print_button.Size = new System.Drawing.Size(75, 23);
            this.Print_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Print_button.TabIndex = 29;
            this.Print_button.Text = "打印";
            // 
            // to_dateTimeInput
            // 
            // 
            // 
            // 
            this.to_dateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.to_dateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.to_dateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.to_dateTimeInput.ButtonDropDown.Visible = true;
            this.to_dateTimeInput.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.to_dateTimeInput.IsPopupCalendarOpen = false;
            this.to_dateTimeInput.Location = new System.Drawing.Point(943, 33);
            // 
            // 
            // 
            // 
            // 
            // 
            this.to_dateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.to_dateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.to_dateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.to_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.to_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.to_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.to_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.to_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.to_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.to_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.to_dateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2017, 8, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.to_dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.to_dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.to_dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.to_dateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.to_dateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.to_dateTimeInput.Name = "to_dateTimeInput";
            this.to_dateTimeInput.Size = new System.Drawing.Size(174, 21);
            this.to_dateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.to_dateTimeInput.TabIndex = 28;
            // 
            // from_dateTimeInput
            // 
            // 
            // 
            // 
            this.from_dateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.from_dateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.from_dateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.from_dateTimeInput.ButtonDropDown.Visible = true;
            this.from_dateTimeInput.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.from_dateTimeInput.IsPopupCalendarOpen = false;
            this.from_dateTimeInput.Location = new System.Drawing.Point(764, 33);
            // 
            // 
            // 
            // 
            // 
            // 
            this.from_dateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.from_dateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.from_dateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.from_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.from_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.from_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.from_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.from_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.from_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.from_dateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.from_dateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2017, 8, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.from_dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.from_dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.from_dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.from_dateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.from_dateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.from_dateTimeInput.Name = "from_dateTimeInput";
            this.from_dateTimeInput.Size = new System.Drawing.Size(166, 21);
            this.from_dateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.from_dateTimeInput.TabIndex = 25;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(704, 31);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(72, 23);
            this.labelX5.TabIndex = 26;
            this.labelX5.Text = "送修日期";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(928, 32);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(24, 23);
            this.labelX6.TabIndex = 27;
            this.labelX6.Text = "--";
            // 
            // Search_buttonX
            // 
            this.Search_buttonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Search_buttonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Search_buttonX.Location = new System.Drawing.Point(1126, 31);
            this.Search_buttonX.Name = "Search_buttonX";
            this.Search_buttonX.Size = new System.Drawing.Size(75, 23);
            this.Search_buttonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Search_buttonX.TabIndex = 21;
            this.Search_buttonX.Text = "查找";
            this.Search_buttonX.Click += new System.EventHandler(this.Search_buttonX_Click_1);
            // 
            // tbSearchName
            // 
            // 
            // 
            // 
            this.tbSearchName.Border.Class = "TextBoxBorder";
            this.tbSearchName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSearchName.Location = new System.Drawing.Point(588, 31);
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
            this.labelX4.Location = new System.Drawing.Point(522, 31);
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
            this.tbSearchCode.Location = new System.Drawing.Point(409, 31);
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
            this.labelX3.Location = new System.Drawing.Point(346, 31);
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
            this.cbSearchcategory.Location = new System.Drawing.Point(214, 30);
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
            this.cbSearchBlong.Location = new System.Drawing.Point(49, 30);
            this.cbSearchBlong.Name = "cbSearchBlong";
            this.cbSearchBlong.Size = new System.Drawing.Size(121, 21);
            this.cbSearchBlong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbSearchBlong.TabIndex = 15;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(176, 30);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(57, 23);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "类别：";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(10, 30);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(57, 23);
            this.labelX1.TabIndex = 13;
            this.labelX1.Text = "配属：";
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
            this.tbToRepairedTime,
            this.tbReceiveTime,
            this.tbHandleTime,
            this.tbComplete,
            this.tbPullTime,
            this.tbToolStatus,
            this.tbOperate});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(4, 105);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1480, 533);
            this.dataGridViewX1.TabIndex = 5;
            this.dataGridViewX1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewX1_RowStateChanged);
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
            // 
            // tbToolName
            // 
            this.tbToolName.DataPropertyName = "ToolName";
            this.tbToolName.HeaderText = "名称";
            this.tbToolName.Name = "tbToolName";
            this.tbToolName.ReadOnly = true;
            this.tbToolName.Width = 150;
            // 
            // tbToRepairedTime
            // 
            this.tbToRepairedTime.DataPropertyName = "ToRepairedTime";
            this.tbToRepairedTime.HeaderText = "送修时间";
            this.tbToRepairedTime.Name = "tbToRepairedTime";
            this.tbToRepairedTime.ReadOnly = true;
            // 
            // tbReceiveTime
            // 
            this.tbReceiveTime.DataPropertyName = "ReceiveTime";
            this.tbReceiveTime.HeaderText = "接收时间";
            this.tbReceiveTime.Name = "tbReceiveTime";
            this.tbReceiveTime.ReadOnly = true;
            // 
            // tbHandleTime
            // 
            this.tbHandleTime.DataPropertyName = "HandleTime";
            this.tbHandleTime.HeaderText = "报废时间";
            this.tbHandleTime.Name = "tbHandleTime";
            this.tbHandleTime.ReadOnly = true;
            this.tbHandleTime.Width = 150;
            // 
            // tbComplete
            // 
            this.tbComplete.DataPropertyName = "CompleteTime";
            this.tbComplete.HeaderText = "维修时间";
            this.tbComplete.Name = "tbComplete";
            this.tbComplete.ReadOnly = true;
            // 
            // tbPullTime
            // 
            this.tbPullTime.DataPropertyName = "PullTime";
            this.tbPullTime.HeaderText = "领回时间";
            this.tbPullTime.Name = "tbPullTime";
            this.tbPullTime.ReadOnly = true;
            this.tbPullTime.Width = 90;
            // 
            // tbToolStatus
            // 
            this.tbToolStatus.DataPropertyName = "StatusStr";
            this.tbToolStatus.HeaderText = "状态";
            this.tbToolStatus.Name = "tbToolStatus";
            this.tbToolStatus.ReadOnly = true;
            this.tbToolStatus.Width = 90;
            // 
            // tbOperate
            // 
            this.tbOperate.DataPropertyName = "ScrapMemo";
            this.tbOperate.HeaderText = "备注";
            this.tbOperate.Name = "tbOperate";
            this.tbOperate.ReadOnly = true;
            this.tbOperate.Width = 150;
            // 
            // pagerControl1
            // 
            this.pagerControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(4, 644);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 50;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(1480, 51);
            this.pagerControl1.TabIndex = 4;
            // 
            // FrmRepairScrapQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 699);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.pagerControl1);
            this.Controls.Add(this.groupPanel1);
            this.Name = "FrmRepairScrapQuery";
            this.Text = "FrmRepairScrapQuery";
            this.Load += new System.EventHandler(this.FrmRepairScrapQuery_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.to_dateTimeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_dateTimeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX Search_buttonX;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSearchName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSearchCode;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSearchcategory;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSearchBlong;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private PageControl.PagerControl pagerControl1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput to_dateTimeInput;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput from_dateTimeInput;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonX Print_button;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbChildTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToRepairedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbReceiveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbHandleTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPullTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbToolStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbOperate;
    }
}