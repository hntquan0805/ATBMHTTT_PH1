using OracleUserManager.Models;
using System.Text.Json;
using System.Windows.Forms;

namespace atbmcq_02
{
    partial class Connection
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
            components = new System.ComponentModel.Container();
            tabControl = new TabControl();
            tabDetails = new TabPage();
            lblAuthType = new Label();
            cboAuthType = new ComboBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConnType = new Label();
            cboConnType = new ComboBox();
            lblHostname = new Label();
            cboHostname = new ComboBox();
            lblPort = new Label();
            txtPort = new TextBox();
            radSID = new RadioButton();
            radServiceName = new RadioButton();
            txtSID = new TextBox();
            txtServiceName = new TextBox();
            btnConnect = new Button();
            btnTest = new Button();
            btnCancel = new Button();
            bottomPanel = new Panel();
            tabControl.SuspendLayout();
            tabDetails.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabDetails);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1166, 522);
            tabControl.TabIndex = 0;
            // 
            // tabDetails
            // 
            tabDetails.Controls.Add(lblAuthType);
            tabDetails.Controls.Add(cboAuthType);
            tabDetails.Controls.Add(lblUsername);
            tabDetails.Controls.Add(txtUsername);
            tabDetails.Controls.Add(lblRole);
            tabDetails.Controls.Add(cboRole);
            tabDetails.Controls.Add(lblPassword);
            tabDetails.Controls.Add(txtPassword);
            tabDetails.Controls.Add(lblConnType);
            tabDetails.Controls.Add(cboConnType);
            tabDetails.Controls.Add(lblHostname);
            tabDetails.Controls.Add(cboHostname);
            tabDetails.Controls.Add(lblPort);
            tabDetails.Controls.Add(txtPort);
            tabDetails.Controls.Add(radSID);
            tabDetails.Controls.Add(radServiceName);
            tabDetails.Controls.Add(txtSID);
            tabDetails.Controls.Add(txtServiceName);
            tabDetails.Location = new Point(4, 38);
            tabDetails.Margin = new Padding(4, 3, 4, 3);
            tabDetails.Name = "tabDetails";
            tabDetails.Size = new Size(1158, 480);
            tabDetails.TabIndex = 0;
            tabDetails.Text = "Details";
            // 
            // lblAuthType
            // 
            lblAuthType.AutoSize = true;
            lblAuthType.Location = new Point(28, 23);
            lblAuthType.Margin = new Padding(4, 0, 4, 0);
            lblAuthType.Name = "lblAuthType";
            lblAuthType.Size = new Size(224, 29);
            lblAuthType.TabIndex = 0;
            lblAuthType.Text = "Authentication Type";
            // 
            // cboAuthType
            // 
            cboAuthType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAuthType.FormattingEnabled = true;
            cboAuthType.Items.AddRange(new object[] { "Default" });
            cboAuthType.Location = new Point(280, 23);
            cboAuthType.Margin = new Padding(4, 3, 4, 3);
            cboAuthType.Name = "cboAuthType";
            cboAuthType.Size = new Size(306, 37);
            cboAuthType.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(28, 81);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(124, 29);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(280, 81);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(390, 37);
            txtUsername.TabIndex = 3;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(700, 81);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(67, 29);
            lblRole.TabIndex = 4;
            lblRole.Text = "Role:";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "default" });
            cboRole.Location = new Point(784, 81);
            cboRole.Margin = new Padding(4, 3, 4, 3);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(278, 37);
            cboRole.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(28, 139);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(120, 29);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(280, 139);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(390, 37);
            txtPassword.TabIndex = 7;
            // 
            // lblConnType
            // 
            lblConnType.AutoSize = true;
            lblConnType.Location = new Point(28, 197);
            lblConnType.Margin = new Padding(4, 0, 4, 0);
            lblConnType.Name = "lblConnType";
            lblConnType.Size = new Size(197, 29);
            lblConnType.TabIndex = 9;
            lblConnType.Text = "Connection Type:";
            // 
            // cboConnType
            // 
            cboConnType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConnType.FormattingEnabled = true;
            cboConnType.Items.AddRange(new object[] { "Basic" });
            cboConnType.Location = new Point(280, 197);
            cboConnType.Margin = new Padding(4, 3, 4, 3);
            cboConnType.Name = "cboConnType";
            cboConnType.Size = new Size(250, 37);
            cboConnType.TabIndex = 10;
            // 
            // lblHostname
            // 
            lblHostname.AutoSize = true;
            lblHostname.Location = new Point(28, 255);
            lblHostname.Margin = new Padding(4, 0, 4, 0);
            lblHostname.Name = "lblHostname";
            lblHostname.Size = new Size(125, 29);
            lblHostname.TabIndex = 11;
            lblHostname.Text = "Hostname:";
            // 
            // cboHostname
            // 
            cboHostname.FormattingEnabled = true;
            cboHostname.Items.AddRange(new object[] { "localhost", "127.0.0.1" });
            cboHostname.Location = new Point(280, 255);
            cboHostname.Margin = new Padding(4, 3, 4, 3);
            cboHostname.Name = "cboHostname";
            cboHostname.Size = new Size(782, 37);
            cboHostname.TabIndex = 12;
            cboHostname.Text = "localhost";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(28, 313);
            lblPort.Margin = new Padding(4, 0, 4, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(63, 29);
            lblPort.TabIndex = 13;
            lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(280, 313);
            txtPort.Margin = new Padding(4, 3, 4, 3);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(782, 37);
            txtPort.TabIndex = 14;
            txtPort.Text = "1521";
            // 
            // radSID
            // 
            radSID.AutoSize = true;
            radSID.Checked = true;
            radSID.Location = new Point(28, 371);
            radSID.Margin = new Padding(4, 3, 4, 3);
            radSID.Name = "radSID";
            radSID.Size = new Size(79, 33);
            radSID.TabIndex = 15;
            radSID.TabStop = true;
            radSID.Text = "SID";
            radSID.CheckedChanged += OnConnectionTypeChanged;
            // 
            // radServiceName
            // 
            radServiceName.AutoSize = true;
            radServiceName.Location = new Point(28, 418);
            radServiceName.Margin = new Padding(4, 3, 4, 3);
            radServiceName.Name = "radServiceName";
            radServiceName.Size = new Size(178, 33);
            radServiceName.TabIndex = 16;
            radServiceName.Text = "Service name";
            radServiceName.CheckedChanged += OnConnectionTypeChanged;
            // 
            // txtSID
            // 
            txtSID.Location = new Point(280, 371);
            txtSID.Margin = new Padding(4, 3, 4, 3);
            txtSID.Name = "txtSID";
            txtSID.Size = new Size(782, 37);
            txtSID.TabIndex = 17;
            txtSID.Text = "xe";
            // 
            // txtServiceName
            // 
            txtServiceName.Enabled = false;
            txtServiceName.Location = new Point(280, 418);
            txtServiceName.Margin = new Padding(4, 3, 4, 3);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(782, 37);
            txtServiceName.TabIndex = 18;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(621, 17);
            btnConnect.Margin = new Padding(4, 3, 4, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(140, 41);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            // 
            // btnTest
            // 
            btnTest.Location = new Point(341, 17);
            btnTest.Margin = new Padding(4, 3, 4, 3);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(140, 41);
            btnTest.TabIndex = 1;
            btnTest.Text = "Test";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(901, 17);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 41);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(btnTest);
            bottomPanel.Controls.Add(btnConnect);
            bottomPanel.Controls.Add(btnCancel);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 556);
            bottomPanel.Margin = new Padding(4, 3, 4, 3);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(1662, 70);
            bottomPanel.TabIndex = 1;
            // 
            // Connection
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1662, 626);
            Controls.Add(tabControl);
            Controls.Add(bottomPanel);
            Font = new Font("Times New Roman", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Connection";
            Text = "Connection";
            tabControl.ResumeLayout(false);
            tabDetails.ResumeLayout(false);
            tabDetails.PerformLayout();
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void OnConnectionTypeChanged(object sender, EventArgs e)
        {
            txtSID.Enabled = radSID.Checked;
            txtServiceName.Enabled = radServiceName.Checked;
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabDetails;
        private Label lblAuthType;
        private ComboBox cboAuthType;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblRole;
        private ComboBox cboRole;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConnType;
        private ComboBox cboConnType;
        private Label lblHostname;
        private ComboBox cboHostname;
        private Label lblPort;
        private TextBox txtPort;
        private RadioButton radSID;
        private RadioButton radServiceName;
        private TextBox txtSID;
        private TextBox txtServiceName;
        private Button btnConnect;
        private Button btnTest;
        private Button btnCancel;
        private Panel bottomPanel;
    }
}