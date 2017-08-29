namespace toolstrackingsystem
{
    partial class FrmQueryReturn
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pagerControl1 = new toolstrackingsystem.PageControl.PagerControl();
            this.ToolList_dataGridViewX = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dateTime_from_Input1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTime_to_Input = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.Print_button = new DevComponents.DotNetBar.ButtonX();
            this.ToolCode_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.Export_button = new DevComponents.DotNetBar.ButtonX();
            this.Search_buttonX = new DevComponents.DotNetBar.ButtonX();
            this.PersonCode_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolList_dataGridViewX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime_from_Input1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime_to_Input)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.White;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.pagerControl1);
            this.groupPanel2.Controls.Add(this.ToolList_dataGridViewX);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(8, 84);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(896, 433);
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
            this.groupPanel2.TabIndex = 17;
            // 
            // pagerControl1
            // 
            this.pagerControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(5, 366);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 50;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(882, 44);
            this.pagerControl1.TabIndex = 1;
            this.pagerControl1.OnPageChanged += new System.EventHandler(this.pagerControl1_OnPageChanged);
            // 
            // ToolList_dataGridViewX
            // 
            this.ToolList_dataGridViewX.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolList_dataGridViewX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ToolList_dataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ToolList_dataGridViewX.DefaultCellStyle = dataGridViewCellStyle2;
            this.ToolList_dataGridViewX.EnableHeadersVisualStyles = false;
            this.ToolList_dataGridViewX.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.ToolList_dataGridViewX.Location = new System.Drawing.Point(5, 3);
            this.ToolList_dataGridViewX.MultiSelect = false;
            this.ToolList_dataGridViewX.Name = "ToolList_dataGridViewX";
            this.ToolList_dataGridViewX.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolList_dataGridViewX.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ToolList_dataGridViewX.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.ToolList_dataGridViewX.RowTemplate.Height = 23;
            this.ToolList_dataGridViewX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ToolList_dataGridViewX.Size = new System.Drawing.Size(882, 361);
            this.ToolList_dataGridViewX.TabIndex = 0;
            this.ToolList_dataGridViewX.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.ToolList_dataGridViewX_RowStateChanged);
            // 
            // dateTime_from_Input1
            // 
            // 
            // 
            // 
            this.dateTime_from_Input1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTime_from_Input1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTime_from_Input1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTime_from_Input1.ButtonDropDown.Visible = true;
            this.dateTime_from_Input1.IsPopupCalendarOpen = false;
            this.dateTime_from_Input1.Location = new System.Drawing.Point(40, 18);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTime_from_Input1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTime_from_Input1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTime_from_Input1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTime_from_Input1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTime_from_Input1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTime_from_Input1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTime_from_Input1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTime_from_Input1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTime_from_Input1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTime_from_Input1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTime_from_Input1.MonthCalendar.DisplayMonth = new System.DateTime(2017, 7, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTime_from_Input1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTime_from_Input1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTime_from_Input1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTime_from_Input1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTime_from_Input1.MonthCalendar.TodayButtonVisible = true;
            this.dateTime_from_Input1.Name = "dateTime_from_Input1";
            this.dateTime_from_Input1.Size = new System.Drawing.Size(106, 21);
            this.dateTime_from_Input1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTime_from_Input1.TabIndex = 23;
            // 
            // dateTime_to_Input
            // 
            // 
            // 
            // 
            this.dateTime_to_Input.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTime_to_Input.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTime_to_Input.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTime_to_Input.ButtonDropDown.Visible = true;
            this.dateTime_to_Input.IsPopupCalendarOpen = false;
            this.dateTime_to_Input.Location = new System.Drawing.Point(157, 18);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTime_to_Input.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTime_to_Input.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTime_to_Input.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTime_to_Input.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTime_to_Input.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTime_to_Input.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTime_to_Input.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTime_to_Input.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTime_to_Input.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTime_to_Input.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTime_to_Input.MonthCalendar.DisplayMonth = new System.DateTime(2017, 7, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTime_to_Input.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTime_to_Input.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTime_to_Input.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTime_to_Input.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTime_to_Input.MonthCalendar.TodayButtonVisible = true;
            this.dateTime_to_Input.Name = "dateTime_to_Input";
            this.dateTime_to_Input.Size = new System.Drawing.Size(106, 21);
            this.dateTime_to_Input.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTime_to_Input.TabIndex = 22;
            // 
            // Print_button
            // 
            this.Print_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Print_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Print_button.Location = new System.Drawing.Point(804, 18);
            this.Print_button.Name = "Print_button";
            this.Print_button.Size = new System.Drawing.Size(75, 23);
            this.Print_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Print_button.TabIndex = 21;
            this.Print_button.Text = "打印";
            this.Print_button.Click += new System.EventHandler(this.Print_button_Click);
            // 
            // ToolCode_textBox
            // 
            this.ToolCode_textBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ToolCode_textBox.Border.Class = "TextBoxBorder";
            this.ToolCode_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ToolCode_textBox.DisabledBackColor = System.Drawing.Color.White;
            this.ToolCode_textBox.ForeColor = System.Drawing.Color.Black;
            this.ToolCode_textBox.Location = new System.Drawing.Point(331, 18);
            this.ToolCode_textBox.Name = "ToolCode_textBox";
            this.ToolCode_textBox.PreventEnterBeep = true;
            this.ToolCode_textBox.Size = new System.Drawing.Size(105, 21);
            this.ToolCode_textBox.TabIndex = 20;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(270, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "工具编码:";
            // 
            // Export_button
            // 
            this.Export_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Export_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Export_button.Location = new System.Drawing.Point(715, 18);
            this.Export_button.Name = "Export_button";
            this.Export_button.Size = new System.Drawing.Size(75, 23);
            this.Export_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Export_button.TabIndex = 16;
            this.Export_button.Text = "导出Excel";
            this.Export_button.Click += new System.EventHandler(this.Export_button_Click);
            // 
            // Search_buttonX
            // 
            this.Search_buttonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Search_buttonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Search_buttonX.Location = new System.Drawing.Point(621, 18);
            this.Search_buttonX.Name = "Search_buttonX";
            this.Search_buttonX.Size = new System.Drawing.Size(75, 23);
            this.Search_buttonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Search_buttonX.TabIndex = 4;
            this.Search_buttonX.Text = "查找";
            this.Search_buttonX.Click += new System.EventHandler(this.Search_buttonX_Click);
            // 
            // PersonCode_textBox
            // 
            this.PersonCode_textBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.PersonCode_textBox.Border.Class = "TextBoxBorder";
            this.PersonCode_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PersonCode_textBox.DisabledBackColor = System.Drawing.Color.White;
            this.PersonCode_textBox.ForeColor = System.Drawing.Color.Black;
            this.PersonCode_textBox.Location = new System.Drawing.Point(501, 18);
            this.PersonCode_textBox.Name = "PersonCode_textBox";
            this.PersonCode_textBox.PreventEnterBeep = true;
            this.PersonCode_textBox.Size = new System.Drawing.Size(105, 21);
            this.PersonCode_textBox.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(440, 18);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(67, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "人员编码:";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(9, 18);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 24;
            this.labelX3.Text = "时间:";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(142, 18);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 25;
            this.labelX4.Text = "---";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dateTime_from_Input1);
            this.groupPanel1.Controls.Add(this.dateTime_to_Input);
            this.groupPanel1.Controls.Add(this.Print_button);
            this.groupPanel1.Controls.Add(this.ToolCode_textBox);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.Export_button);
            this.groupPanel1.Controls.Add(this.Search_buttonX);
            this.groupPanel1.Controls.Add(this.PersonCode_textBox);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(8, 8);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(896, 70);
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
            this.groupPanel1.TabIndex = 16;
            // 
            // FrmQueryReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 568);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "FrmQueryReturn";
            this.Text = "归还查询";
            this.Load += new System.EventHandler(this.FrmQueryReturn_Load);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolList_dataGridViewX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime_from_Input1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime_to_Input)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PageControl.PagerControl pagerControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX ToolList_dataGridViewX;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTime_from_Input1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTime_to_Input;
        private DevComponents.DotNetBar.ButtonX Print_button;
        private DevComponents.DotNetBar.Controls.TextBoxX ToolCode_textBox;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX Export_button;
        private DevComponents.DotNetBar.ButtonX Search_buttonX;
        private DevComponents.DotNetBar.Controls.TextBoxX PersonCode_textBox;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}