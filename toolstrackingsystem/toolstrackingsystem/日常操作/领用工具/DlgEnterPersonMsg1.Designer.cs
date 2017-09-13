namespace toolstrackingsystem
{
    partial class DlgEnterPersonMsg1
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
            this.tbEditPersonName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.tbEditPersonCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.Cancel_button = new DevComponents.DotNetBar.ButtonX();
            this.Save_Edit_button = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // tbEditPersonName
            // 
            // 
            // 
            // 
            this.tbEditPersonName.Border.Class = "TextBoxBorder";
            this.tbEditPersonName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditPersonName.Location = new System.Drawing.Point(101, 124);
            this.tbEditPersonName.Name = "tbEditPersonName";
            this.tbEditPersonName.PreventEnterBeep = true;
            this.tbEditPersonName.Size = new System.Drawing.Size(188, 21);
            this.tbEditPersonName.TabIndex = 18;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(29, 124);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(66, 23);
            this.labelX9.TabIndex = 17;
            this.labelX9.Text = "人员名称：";
            // 
            // tbEditPersonCode
            // 
            // 
            // 
            // 
            this.tbEditPersonCode.Border.Class = "TextBoxBorder";
            this.tbEditPersonCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditPersonCode.Location = new System.Drawing.Point(101, 58);
            this.tbEditPersonCode.Name = "tbEditPersonCode";
            this.tbEditPersonCode.PreventEnterBeep = true;
            this.tbEditPersonCode.Size = new System.Drawing.Size(188, 21);
            this.tbEditPersonCode.TabIndex = 15;
            this.tbEditPersonCode.TextChanged += new System.EventHandler(this.tbEditPersonCode_TextChanged);
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(29, 58);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(83, 23);
            this.labelX8.TabIndex = 16;
            this.labelX8.Text = "人员编码：";
            // 
            // Cancel_button
            // 
            this.Cancel_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Cancel_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Cancel_button.Location = new System.Drawing.Point(199, 179);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 52);
            this.Cancel_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cancel_button.TabIndex = 20;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Save_Edit_button
            // 
            this.Save_Edit_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save_Edit_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save_Edit_button.Location = new System.Drawing.Point(52, 179);
            this.Save_Edit_button.Name = "Save_Edit_button";
            this.Save_Edit_button.Size = new System.Drawing.Size(75, 52);
            this.Save_Edit_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Save_Edit_button.TabIndex = 19;
            this.Save_Edit_button.Text = "确定";
            this.Save_Edit_button.Click += new System.EventHandler(this.Save_Edit_button_Click);
            // 
            // DlgEnterPersonMsg1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 284);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Save_Edit_button);
            this.Controls.Add(this.tbEditPersonName);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.tbEditPersonCode);
            this.Controls.Add(this.labelX8);
            this.DoubleBuffered = true;
            this.Name = "DlgEnterPersonMsg1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员录入";
            this.Load += new System.EventHandler(this.DlgEnterPersonMsg1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX tbEditPersonName;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditPersonCode;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.ButtonX Cancel_button;
        private DevComponents.DotNetBar.ButtonX Save_Edit_button;
    }
}