namespace toolstrackingsystem
{
    partial class FrmSelectClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectClient));
            this.Clients_comboBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.confirm__button = new DevComponents.DotNetBar.ButtonX();
            this.cancel_button = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Clients_comboBox
            // 
            this.Clients_comboBox.DisplayMember = "Text";
            this.Clients_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Clients_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Clients_comboBox.FormattingEnabled = true;
            this.Clients_comboBox.ItemHeight = 15;
            this.Clients_comboBox.Location = new System.Drawing.Point(117, 38);
            this.Clients_comboBox.Name = "Clients_comboBox";
            this.Clients_comboBox.Size = new System.Drawing.Size(121, 21);
            this.Clients_comboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Clients_comboBox.TabIndex = 0;
            // 
            // confirm__button
            // 
            this.confirm__button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.confirm__button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.confirm__button.Location = new System.Drawing.Point(54, 88);
            this.confirm__button.Name = "confirm__button";
            this.confirm__button.Size = new System.Drawing.Size(75, 23);
            this.confirm__button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.confirm__button.TabIndex = 2;
            this.confirm__button.Text = "确定";
            this.confirm__button.Click += new System.EventHandler(this.confirm__button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancel_button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancel_button.Location = new System.Drawing.Point(147, 88);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "取消";
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(284, 162);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户端名称:";
            // 
            // FrmSelectClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.confirm__button);
            this.Controls.Add(this.Clients_comboBox);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSelectClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择客户端";
            this.Load += new System.EventHandler(this.FrmSelectClient_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx Clients_comboBox;
        private DevComponents.DotNetBar.ButtonX confirm__button;
        private DevComponents.DotNetBar.ButtonX cancel_button;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Label label1;
    }
}