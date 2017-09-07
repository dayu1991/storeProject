namespace toolstrackingsystem
{
    partial class FrmEditAddress
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.macAddress_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.jiami_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.IsActive_checkBox = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.save_button = new DevComponents.DotNetBar.ButtonX();
            this.cancel_button = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cancel_button);
            this.groupPanel1.Controls.Add(this.save_button);
            this.groupPanel1.Controls.Add(this.IsActive_checkBox);
            this.groupPanel1.Controls.Add(this.jiami_textBox);
            this.groupPanel1.Controls.Add(this.macAddress_textBox);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(284, 262);
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
            this.groupPanel1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 31);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "MAC地址:";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(23, 77);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "加密地址:";
            // 
            // macAddress_textBox
            // 
            // 
            // 
            // 
            this.macAddress_textBox.Border.Class = "TextBoxBorder";
            this.macAddress_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.macAddress_textBox.Location = new System.Drawing.Point(86, 31);
            this.macAddress_textBox.Name = "macAddress_textBox";
            this.macAddress_textBox.PreventEnterBeep = true;
            this.macAddress_textBox.ReadOnly = true;
            this.macAddress_textBox.Size = new System.Drawing.Size(174, 21);
            this.macAddress_textBox.TabIndex = 2;
            // 
            // jiami_textBox
            // 
            // 
            // 
            // 
            this.jiami_textBox.Border.Class = "TextBoxBorder";
            this.jiami_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.jiami_textBox.Location = new System.Drawing.Point(86, 81);
            this.jiami_textBox.Name = "jiami_textBox";
            this.jiami_textBox.PreventEnterBeep = true;
            this.jiami_textBox.Size = new System.Drawing.Size(174, 21);
            this.jiami_textBox.TabIndex = 3;
            // 
            // IsActive_checkBox
            // 
            this.IsActive_checkBox.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.IsActive_checkBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.IsActive_checkBox.Location = new System.Drawing.Point(86, 131);
            this.IsActive_checkBox.Name = "IsActive_checkBox";
            this.IsActive_checkBox.Size = new System.Drawing.Size(100, 23);
            this.IsActive_checkBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.IsActive_checkBox.TabIndex = 5;
            this.IsActive_checkBox.Text = "是否有效";
            // 
            // save_button
            // 
            this.save_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.save_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.save_button.Location = new System.Drawing.Point(42, 183);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.save_button.TabIndex = 6;
            this.save_button.Text = "保存";
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancel_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancel_button.Location = new System.Drawing.Point(142, 183);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancel_button.TabIndex = 7;
            this.cancel_button.Text = "取消";
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // FrmEditAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.Name = "FrmEditAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑地址";
            this.Load += new System.EventHandler(this.FrmEditAddress_Load);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX cancel_button;
        private DevComponents.DotNetBar.ButtonX save_button;
        private DevComponents.DotNetBar.Controls.CheckBoxX IsActive_checkBox;
        private DevComponents.DotNetBar.Controls.TextBoxX jiami_textBox;
        private DevComponents.DotNetBar.Controls.TextBoxX macAddress_textBox;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}