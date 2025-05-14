using OracleUserManager.Models;

namespace atbmcq_02
{
    partial class Home
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
            panelMenu = new Panel();
            grantPrivileges = new Button();
            userManage = new Button();
            panelContent = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(grantPrivileges);
            panelMenu.Controls.Add(userManage);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4, 3, 4, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(243, 606);
            panelMenu.TabIndex = 0;
            // 
            // grantPrivileges
            // 
            grantPrivileges.AutoSize = true;
            grantPrivileges.Location = new Point(13, 97);
            grantPrivileges.Margin = new Padding(4, 3, 4, 3);
            grantPrivileges.Name = "grantPrivileges";
            grantPrivileges.Size = new Size(216, 39);
            grantPrivileges.TabIndex = 1;
            grantPrivileges.Text = "Grant Privileges";
            grantPrivileges.UseVisualStyleBackColor = true;
            grantPrivileges.Click += grantPrivileges_Click;
            // 
            // userManage
            // 
            userManage.AutoSize = true;
            userManage.Location = new Point(13, 34);
            userManage.Margin = new Padding(4, 3, 4, 3);
            userManage.Name = "userManage";
            userManage.Size = new Size(216, 41);
            userManage.TabIndex = 0;
            userManage.Text = "User Management";
            userManage.UseVisualStyleBackColor = true;
            userManage.Click += userManage_Click;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(243, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1587, 606);
            panelContent.TabIndex = 1;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1830, 606);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Font = new Font("Times New Roman", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Home";
            Text = "Home";
            FormClosed += Home_FormClosed;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private OracleDbConnection _connection;
        private Panel panelMenu;
        private Button grantPrivileges;
        private Button userManage;
        private Panel panelContent;
    }
}