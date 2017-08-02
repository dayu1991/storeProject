namespace toolstrackingsystem
{
    partial class DlgEditTool
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
            this.Save_Edit_button = new DevComponents.DotNetBar.ButtonX();
            this.Cancel_button = new DevComponents.DotNetBar.ButtonX();
            this.tbEditLocation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tbEditToolName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cbEditCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cbEditBlong = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dtiCheckTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.tbEditMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbEditModel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cbEditCheckTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dtiCheckTime)).BeginInit();
            this.SuspendLayout();
            // 
            // Save_Edit_button
            // 
            this.Save_Edit_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save_Edit_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save_Edit_button.Location = new System.Drawing.Point(146, 260);
            this.Save_Edit_button.Name = "Save_Edit_button";
            this.Save_Edit_button.Size = new System.Drawing.Size(75, 23);
            this.Save_Edit_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Save_Edit_button.TabIndex = 9;
            this.Save_Edit_button.Text = "保存";
            this.Save_Edit_button.Click += new System.EventHandler(this.Save_Edit_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Cancel_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Cancel_button.Location = new System.Drawing.Point(270, 260);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cancel_button.TabIndex = 10;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // tbEditLocation
            // 
            // 
            // 
            // 
            this.tbEditLocation.Border.Class = "TextBoxBorder";
            this.tbEditLocation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditLocation.Location = new System.Drawing.Point(147, 114);
            this.tbEditLocation.Name = "tbEditLocation";
            this.tbEditLocation.PreventEnterBeep = true;
            this.tbEditLocation.Size = new System.Drawing.Size(232, 21);
            this.tbEditLocation.TabIndex = 20;
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(100, 114);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(57, 23);
            this.labelX8.TabIndex = 19;
            this.labelX8.Text = "位置：";
            // 
            // tbEditToolName
            // 
            // 
            // 
            // 
            this.tbEditToolName.Border.Class = "TextBoxBorder";
            this.tbEditToolName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditToolName.Location = new System.Drawing.Point(147, 85);
            this.tbEditToolName.Name = "tbEditToolName";
            this.tbEditToolName.PreventEnterBeep = true;
            this.tbEditToolName.Size = new System.Drawing.Size(232, 21);
            this.tbEditToolName.TabIndex = 18;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(100, 85);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(57, 23);
            this.labelX7.TabIndex = 17;
            this.labelX7.Text = "名称：";
            // 
            // cbEditCategory
            // 
            this.cbEditCategory.DisplayMember = "Text";
            this.cbEditCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEditCategory.FormattingEnabled = true;
            this.cbEditCategory.ItemHeight = 15;
            this.cbEditCategory.Location = new System.Drawing.Point(149, 56);
            this.cbEditCategory.Name = "cbEditCategory";
            this.cbEditCategory.Size = new System.Drawing.Size(230, 21);
            this.cbEditCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEditCategory.TabIndex = 16;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(102, 56);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(57, 23);
            this.labelX6.TabIndex = 15;
            this.labelX6.Text = "类别：";
            // 
            // cbEditBlong
            // 
            this.cbEditBlong.DisplayMember = "Text";
            this.cbEditBlong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEditBlong.FormattingEnabled = true;
            this.cbEditBlong.ItemHeight = 15;
            this.cbEditBlong.Location = new System.Drawing.Point(149, 27);
            this.cbEditBlong.Name = "cbEditBlong";
            this.cbEditBlong.Size = new System.Drawing.Size(230, 21);
            this.cbEditBlong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEditBlong.TabIndex = 14;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(102, 27);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(57, 23);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "配属：";
            // 
            // dtiCheckTime
            // 
            // 
            // 
            // 
            this.dtiCheckTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiCheckTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiCheckTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiCheckTime.ButtonDropDown.Visible = true;
            this.dtiCheckTime.IsPopupCalendarOpen = false;
            this.dtiCheckTime.Location = new System.Drawing.Point(146, 145);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtiCheckTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiCheckTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiCheckTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiCheckTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiCheckTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiCheckTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiCheckTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiCheckTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiCheckTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiCheckTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiCheckTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 7, 1, 0, 0, 0, 0);
            this.dtiCheckTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtiCheckTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiCheckTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiCheckTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiCheckTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiCheckTime.MonthCalendar.TodayButtonVisible = true;
            this.dtiCheckTime.Name = "dtiCheckTime";
            this.dtiCheckTime.Size = new System.Drawing.Size(232, 21);
            this.dtiCheckTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiCheckTime.TabIndex = 27;
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(100, 201);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(57, 23);
            this.labelX10.TabIndex = 28;
            this.labelX10.Text = "备注：";
            // 
            // tbEditMemo
            // 
            // 
            // 
            // 
            this.tbEditMemo.Border.Class = "TextBoxBorder";
            this.tbEditMemo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditMemo.Location = new System.Drawing.Point(147, 205);
            this.tbEditMemo.Name = "tbEditMemo";
            this.tbEditMemo.PreventEnterBeep = true;
            this.tbEditMemo.Size = new System.Drawing.Size(232, 21);
            this.tbEditMemo.TabIndex = 29;
            // 
            // tbEditModel
            // 
            // 
            // 
            // 
            this.tbEditModel.Border.Class = "TextBoxBorder";
            this.tbEditModel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditModel.Location = new System.Drawing.Point(147, 172);
            this.tbEditModel.Name = "tbEditModel";
            this.tbEditModel.PreventEnterBeep = true;
            this.tbEditModel.Size = new System.Drawing.Size(232, 21);
            this.tbEditModel.TabIndex = 31;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(100, 172);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(57, 23);
            this.labelX9.TabIndex = 30;
            this.labelX9.Text = "型号：";
            // 
            // cbEditCheckTime
            // 
            // 
            // 
            // 
            this.cbEditCheckTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbEditCheckTime.Location = new System.Drawing.Point(36, 143);
            this.cbEditCheckTime.Name = "cbEditCheckTime";
            this.cbEditCheckTime.Size = new System.Drawing.Size(112, 23);
            this.cbEditCheckTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEditCheckTime.TabIndex = 32;
            this.cbEditCheckTime.Text = "下次检测时间:";
            // 
            // DlgEditTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 336);
            this.Controls.Add(this.cbEditCheckTime);
            this.Controls.Add(this.tbEditModel);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.tbEditMemo);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.dtiCheckTime);
            this.Controls.Add(this.tbEditLocation);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.tbEditToolName);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.cbEditCategory);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.cbEditBlong);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Save_Edit_button);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgEditTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改";
            this.Load += new System.EventHandler(this.DlgEditTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtiCheckTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX Save_Edit_button;
        private DevComponents.DotNetBar.ButtonX Cancel_button;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditLocation;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditToolName;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbEditCategory;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbEditBlong;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiCheckTime;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditMemo;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditModel;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbEditCheckTime;
    }
}