namespace toolstrackingsystem
{
    partial class DlgAddCategory
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
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbEditName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Cancel_button = new DevComponents.DotNetBar.ButtonX();
            this.Save_Edit_button = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(25, 92);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(92, 23);
            this.labelX5.TabIndex = 15;
            this.labelX5.Text = "分类名称：";
            // 
            // tbEditName
            // 
            // 
            // 
            // 
            this.tbEditName.Border.Class = "TextBoxBorder";
            this.tbEditName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEditName.Location = new System.Drawing.Point(123, 92);
            this.tbEditName.Name = "tbEditName";
            this.tbEditName.PreventEnterBeep = true;
            this.tbEditName.Size = new System.Drawing.Size(100, 21);
            this.tbEditName.TabIndex = 19;
            // 
            // Cancel_button
            // 
            this.Cancel_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Cancel_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Cancel_button.Location = new System.Drawing.Point(159, 202);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cancel_button.TabIndex = 21;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Save_Edit_button
            // 
            this.Save_Edit_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save_Edit_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save_Edit_button.Location = new System.Drawing.Point(42, 202);
            this.Save_Edit_button.Name = "Save_Edit_button";
            this.Save_Edit_button.Size = new System.Drawing.Size(75, 23);
            this.Save_Edit_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Save_Edit_button.TabIndex = 20;
            this.Save_Edit_button.Text = "保存";
            this.Save_Edit_button.Click += new System.EventHandler(this.Save_Edit_button_Click);
            // 
            // DlgAddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Save_Edit_button);
            this.Controls.Add(this.tbEditName);
            this.Controls.Add(this.labelX5);
            this.DoubleBuffered = true;
            this.Name = "DlgAddCategory";
            this.Text = "DlgAddCategory";
            this.Load += new System.EventHandler(this.DlgAddCategory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEditName;
        private DevComponents.DotNetBar.ButtonX Cancel_button;
        private DevComponents.DotNetBar.ButtonX Save_Edit_button;
    }
}