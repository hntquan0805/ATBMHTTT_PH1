using OracleUserManager.Models;

namespace atbmcq_02
{
    partial class User_Management
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabManage = new TabPage();
            grpUserRole = new GroupBox();
            radUser = new RadioButton();
            radRole = new RadioButton();
            lblName = new Label();
            txtName = new TextBox();
            lblUserPass = new Label();
            txtUserPass = new TextBox();
            chkExisting = new CheckBox();
            btnCreate = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            tabList = new TabPage();
            cboFilter = new ComboBox();
            lstUsers = new ListView();
            Ten = new ColumnHeader();
            DSLoai = new ColumnHeader();
            TrangThai = new ColumnHeader();
            NgayTao = new ColumnHeader();
            btnRefresh = new Button();
            tabTablespaces = new TabPage();
            grpTablespaces = new GroupBox();
            lblTablespace = new Label();
            txtTablespace = new TextBox();
            lblSize = new Label();
            txtSize = new TextBox();
            btnCreateTS = new Button();
            btnDropTS = new Button();
            btnResizeTS = new Button();
            lstTablespaces = new ListView();
            TBSTen = new ColumnHeader();
            KichThuoc = new ColumnHeader();
            TBSTrangThai = new ColumnHeader();
            TBSTDMR = new ColumnHeader();
            tabAudit = new TabPage();
            grpAudit = new GroupBox();
            lstAudit = new ListView();
            ThoiGian = new ColumnHeader();
            User = new ColumnHeader();
            HanhDong = new ColumnHeader();
            TDDoiTuong = new ColumnHeader();
            TDTrangThai = new ColumnHeader();
            btnRefreshAudit = new Button();
            tabControl.SuspendLayout();
            tabManage.SuspendLayout();
            grpUserRole.SuspendLayout();
            tabList.SuspendLayout();
            tabTablespaces.SuspendLayout();
            grpTablespaces.SuspendLayout();
            tabAudit.SuspendLayout();
            grpAudit.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabManage);
            tabControl.Controls.Add(tabList);
            tabControl.Controls.Add(tabTablespaces);
            tabControl.Controls.Add(tabAudit);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(6, 3, 6, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1592, 535);
            tabControl.TabIndex = 2;
            // 
            // tabManage
            // 
            tabManage.Controls.Add(grpUserRole);
            tabManage.Location = new Point(4, 38);
            tabManage.Margin = new Padding(6, 3, 6, 3);
            tabManage.Name = "tabManage";
            tabManage.Padding = new Padding(6, 3, 6, 3);
            tabManage.Size = new Size(1584, 493);
            tabManage.TabIndex = 0;
            tabManage.Text = "User/Role Management";
            // 
            // grpUserRole
            // 
            grpUserRole.Controls.Add(radUser);
            grpUserRole.Controls.Add(radRole);
            grpUserRole.Controls.Add(lblName);
            grpUserRole.Controls.Add(txtName);
            grpUserRole.Controls.Add(lblUserPass);
            grpUserRole.Controls.Add(txtUserPass);
            grpUserRole.Controls.Add(chkExisting);
            grpUserRole.Controls.Add(btnCreate);
            grpUserRole.Controls.Add(btnDelete);
            grpUserRole.Controls.Add(btnUpdate);
            grpUserRole.Location = new Point(20, 14);
            grpUserRole.Margin = new Padding(6, 3, 6, 3);
            grpUserRole.Name = "grpUserRole";
            grpUserRole.Padding = new Padding(6, 3, 6, 3);
            grpUserRole.Size = new Size(1548, 452);
            grpUserRole.TabIndex = 0;
            grpUserRole.TabStop = false;
            grpUserRole.Text = "User/Role Information";
            // 
            // radUser
            // 
            radUser.AutoSize = true;
            radUser.Checked = true;
            radUser.Location = new Point(41, 94);
            radUser.Margin = new Padding(6, 3, 6, 3);
            radUser.Name = "radUser";
            radUser.Size = new Size(86, 33);
            radUser.TabIndex = 0;
            radUser.TabStop = true;
            radUser.Text = "User";
            // 
            // radRole
            // 
            radRole.AutoSize = true;
            radRole.Location = new Point(309, 94);
            radRole.Margin = new Padding(6, 3, 6, 3);
            radRole.Name = "radRole";
            radRole.Size = new Size(86, 33);
            radRole.TabIndex = 1;
            radRole.Text = "Role";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(41, 155);
            lblName.Margin = new Padding(6, 0, 6, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(184, 29);
            lblName.TabIndex = 2;
            lblName.Text = "User/Role Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(308, 152);
            txtName.Margin = new Padding(6, 3, 6, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(721, 37);
            txtName.TabIndex = 3;
            // 
            // lblUserPass
            // 
            lblUserPass.AutoSize = true;
            lblUserPass.Location = new Point(41, 225);
            lblUserPass.Margin = new Padding(6, 0, 6, 0);
            lblUserPass.Name = "lblUserPass";
            lblUserPass.Size = new Size(119, 29);
            lblUserPass.TabIndex = 4;
            lblUserPass.Text = "Password:";
            // 
            // txtUserPass
            // 
            txtUserPass.Location = new Point(308, 222);
            txtUserPass.Margin = new Padding(6, 3, 6, 3);
            txtUserPass.Name = "txtUserPass";
            txtUserPass.PasswordChar = '*';
            txtUserPass.Size = new Size(721, 37);
            txtUserPass.TabIndex = 5;
            // 
            // chkExisting
            // 
            chkExisting.AutoSize = true;
            chkExisting.Location = new Point(41, 288);
            chkExisting.Margin = new Padding(6, 3, 6, 3);
            chkExisting.Name = "chkExisting";
            chkExisting.Size = new Size(202, 33);
            chkExisting.TabIndex = 6;
            chkExisting.Text = "Existing User?";
            // 
            // btnCreate
            // 
            btnCreate.AutoSize = true;
            btnCreate.Location = new Point(1193, 144);
            btnCreate.Margin = new Padding(6, 3, 6, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(196, 45);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "Create";
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(1193, 213);
            btnDelete.Margin = new Padding(6, 3, 6, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(196, 45);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Location = new Point(1193, 281);
            btnUpdate.Margin = new Padding(6, 3, 6, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(196, 45);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            // 
            // tabList
            // 
            tabList.Controls.Add(cboFilter);
            tabList.Controls.Add(lstUsers);
            tabList.Controls.Add(btnRefresh);
            tabList.Location = new Point(4, 34);
            tabList.Margin = new Padding(6, 3, 6, 3);
            tabList.Name = "tabList";
            tabList.Padding = new Padding(6, 3, 6, 3);
            tabList.Size = new Size(1584, 497);
            tabList.TabIndex = 1;
            tabList.Text = "User/Role List";
            // 
            // cboFilter
            // 
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.FormattingEnabled = true;
            cboFilter.Items.AddRange(new object[] { "Users", "Roles", "All" });
            cboFilter.Location = new Point(20, 14);
            cboFilter.Margin = new Padding(6, 3, 6, 3);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(388, 37);
            cboFilter.TabIndex = 0;
            // 
            // lstUsers
            // 
            lstUsers.Columns.AddRange(new ColumnHeader[] { Ten, DSLoai, TrangThai, NgayTao });
            lstUsers.FullRowSelect = true;
            lstUsers.GridLines = true;
            lstUsers.Location = new Point(20, 80);
            lstUsers.Margin = new Padding(6, 3, 6, 3);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(1211, 375);
            lstUsers.TabIndex = 1;
            lstUsers.UseCompatibleStateImageBehavior = false;
            lstUsers.View = View.Details;
            // 
            // Ten
            // 
            Ten.Text = "Name";
            Ten.Width = 302;
            // 
            // DSLoai
            // 
            DSLoai.Text = "Type";
            DSLoai.Width = 302;
            // 
            // TrangThai
            // 
            TrangThai.Text = "Status";
            TrangThai.Width = 302;
            // 
            // NgayTao
            // 
            NgayTao.Text = "Created Date";
            NgayTao.Width = 304;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.Location = new Point(1254, 84);
            btnRefresh.Margin = new Padding(6, 3, 6, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(321, 56);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh List";
            // 
            // tabTablespaces
            // 
            tabTablespaces.Controls.Add(grpTablespaces);
            tabTablespaces.Location = new Point(4, 34);
            tabTablespaces.Margin = new Padding(6, 3, 6, 3);
            tabTablespaces.Name = "tabTablespaces";
            tabTablespaces.Size = new Size(1584, 497);
            tabTablespaces.TabIndex = 3;
            tabTablespaces.Text = "Tablespace Management";
            // 
            // grpTablespaces
            // 
            grpTablespaces.Controls.Add(lblTablespace);
            grpTablespaces.Controls.Add(txtTablespace);
            grpTablespaces.Controls.Add(lblSize);
            grpTablespaces.Controls.Add(txtSize);
            grpTablespaces.Controls.Add(btnCreateTS);
            grpTablespaces.Controls.Add(btnDropTS);
            grpTablespaces.Controls.Add(btnResizeTS);
            grpTablespaces.Controls.Add(lstTablespaces);
            grpTablespaces.Location = new Point(20, 14);
            grpTablespaces.Margin = new Padding(6, 3, 6, 3);
            grpTablespaces.Name = "grpTablespaces";
            grpTablespaces.Padding = new Padding(6, 3, 6, 3);
            grpTablespaces.Size = new Size(1547, 454);
            grpTablespaces.TabIndex = 0;
            grpTablespaces.TabStop = false;
            grpTablespaces.Text = "Tablespace Management";
            // 
            // lblTablespace
            // 
            lblTablespace.AutoSize = true;
            lblTablespace.Location = new Point(41, 48);
            lblTablespace.Margin = new Padding(6, 0, 6, 0);
            lblTablespace.Name = "lblTablespace";
            lblTablespace.Size = new Size(183, 29);
            lblTablespace.TabIndex = 0;
            lblTablespace.Text = "Tablespace Name:";
            // 
            // txtTablespace
            // 
            txtTablespace.Location = new Point(344, 44);
            txtTablespace.Margin = new Padding(6, 3, 6, 3);
            txtTablespace.Name = "txtTablespace";
            txtTablespace.Size = new Size(388, 37);
            txtTablespace.TabIndex = 1;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(41, 101);
            lblSize.Margin = new Padding(6, 0, 6, 0);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(202, 29);
            lblSize.TabIndex = 2;
            lblSize.Text = "Size (MB):";
            // 
            // txtSize
            // 
            txtSize.Location = new Point(344, 97);
            txtSize.Margin = new Padding(6, 3, 6, 3);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(192, 37);
            txtSize.TabIndex = 3;
            // 
            // btnCreateTS
            // 
            btnCreateTS.AutoSize = true;
            btnCreateTS.Location = new Point(785, 44);
            btnCreateTS.Margin = new Padding(6, 3, 6, 3);
            btnCreateTS.Name = "btnCreateTS";
            btnCreateTS.Size = new Size(196, 45);
            btnCreateTS.TabIndex = 4;
            btnCreateTS.Text = "Create";
            // 
            // btnDropTS
            // 
            btnDropTS.AutoSize = true;
            btnDropTS.Location = new Point(785, 97);
            btnDropTS.Margin = new Padding(6, 3, 6, 3);
            btnDropTS.Name = "btnDropTS";
            btnDropTS.Size = new Size(196, 45);
            btnDropTS.TabIndex = 5;
            btnDropTS.Text = "Drop";
            // 
            // btnResizeTS
            // 
            btnResizeTS.AutoSize = true;
            btnResizeTS.Location = new Point(1037, 48);
            btnResizeTS.Margin = new Padding(6, 3, 6, 3);
            btnResizeTS.Name = "btnResizeTS";
            btnResizeTS.Size = new Size(329, 45);
            btnResizeTS.TabIndex = 6;
            btnResizeTS.Text = "Resize";
            // 
            // lstTablespaces
            // 
            lstTablespaces.Columns.AddRange(new ColumnHeader[] { TBSTen, KichThuoc, TBSTrangThai, TBSTDMR });
            lstTablespaces.Location = new Point(39, 161);
            lstTablespaces.Margin = new Padding(6, 3, 6, 3);
            lstTablespaces.Name = "lstTablespaces";
            lstTablespaces.Size = new Size(1468, 274);
            lstTablespaces.TabIndex = 7;
            lstTablespaces.UseCompatibleStateImageBehavior = false;
            lstTablespaces.View = View.Details;
            // 
            // TBSTen
            // 
            TBSTen.Text = "Name";
            TBSTen.Width = 367;
            // 
            // KichThuoc
            // 
            KichThuoc.Text = "Size (MB)";
            KichThuoc.Width = 367;
            // 
            // TBSTrangThai
            // 
            TBSTrangThai.Text = "Status";
            TBSTrangThai.Width = 367;
            // 
            // TBSTDMR
            // 
            TBSTDMR.Text = "Auto Extend";
            TBSTDMR.Width = 367;
            // 
            // tabAudit
            // 
            tabAudit.Controls.Add(grpAudit);
            tabAudit.Location = new Point(4, 34);
            tabAudit.Margin = new Padding(6, 3, 6, 3);
            tabAudit.Name = "tabAudit";
            tabAudit.Size = new Size(1584, 497);
            tabAudit.TabIndex = 4;
            tabAudit.Text = "Activity Log";
            // 
            // grpAudit
            // 
            grpAudit.Controls.Add(lstAudit);
            grpAudit.Controls.Add(btnRefreshAudit);
            grpAudit.Location = new Point(20, 14);
            grpAudit.Margin = new Padding(6, 3, 6, 3);
            grpAudit.Name = "grpAudit";
            grpAudit.Padding = new Padding(6, 3, 6, 3);
            grpAudit.Size = new Size(1544, 455);
            grpAudit.TabIndex = 0;
            grpAudit.TabStop = false;
            grpAudit.Text = "Activity Log";
            // 
            // lstAudit
            // 
            lstAudit.Columns.AddRange(new ColumnHeader[] { ThoiGian, User, HanhDong, TDDoiTuong, TDTrangThai });
            lstAudit.Location = new Point(39, 41);
            lstAudit.Margin = new Padding(6, 3, 6, 3);
            lstAudit.Name = "lstAudit";
            lstAudit.Size = new Size(1470, 391);
            lstAudit.TabIndex = 0;
            lstAudit.UseCompatibleStateImageBehavior = false;
            lstAudit.View = View.Details;
            // 
            // ThoiGian
            // 
            ThoiGian.Text = "Time";
            ThoiGian.Width = 294;
            // 
            // User
            // 
            User.Text = "User";
            User.Width = 294;
            // 
            // HanhDong
            // 
            HanhDong.Text = "Action";
            HanhDong.Width = 294;
            // 
            // TDDoiTuong
            // 
            TDDoiTuong.Text = "Object";
            TDDoiTuong.Width = 294;
            // 
            // TDTrangThai
            // 
            TDTrangThai.Text = "Status";
            TDTrangThai.Width = 294;
            // 
            // btnRefreshAudit
            // 
            btnRefreshAudit.Location = new Point(1254, 41);
            btnRefreshAudit.Margin = new Padding(6, 3, 6, 3);
            btnRefreshAudit.Name = "btnRefreshAudit";
            btnRefreshAudit.Size = new Size(137, 41);
            btnRefreshAudit.TabIndex = 1;
            btnRefreshAudit.Text = "Refresh";
            btnCreate.Click += CreateUserOrRole;
            btnDelete.Click += DeleteUserOrRole;
            btnUpdate.Click += UpdateUserOrRole;
            btnRefresh.Click += LoadUserList;
            cboFilter.SelectedIndexChanged += LoadUserList;
            //chkExisting.CheckedChanged += txtUserPass.Enabled = !chkExisting.Checked;
            btnCreateTS.Click += CreateTablespace;
            btnDropTS.Click += DropTablespace;
            btnResizeTS.Click += ResizeTablespace;
            // 
            // User_Management
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl);
            Font = new Font("Times New Roman", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "User_Management";
            Size = new Size(1592, 535);
            tabControl.ResumeLayout(false);
            tabManage.ResumeLayout(false);
            grpUserRole.ResumeLayout(false);
            grpUserRole.PerformLayout();
            tabList.ResumeLayout(false);
            tabList.PerformLayout();
            tabTablespaces.ResumeLayout(false);
            grpTablespaces.ResumeLayout(false);
            grpTablespaces.PerformLayout();
            tabAudit.ResumeLayout(false);
            grpAudit.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private OracleDbConnection _connection;
        private TabControl tabControl;
        private TabPage tabManage;
        private GroupBox grpUserRole;
        private RadioButton radUser;
        private RadioButton radRole;
        private Label lblName;
        private TextBox txtName;
        private Label lblUserPass;
        private TextBox txtUserPass;
        private CheckBox chkExisting;
        private Button btnCreate;
        private Button btnDelete;
        private Button btnUpdate;
        private TabPage tabList;
        private ComboBox cboFilter;
        private ListView lstUsers;
        private ColumnHeader Ten;
        private ColumnHeader DSLoai;
        private ColumnHeader TrangThai;
        private ColumnHeader NgayTao;
        private Button btnRefresh;
        private TabPage tabTablespaces;
        private GroupBox grpTablespaces;
        private Label lblTablespace;
        private TextBox txtTablespace;
        private Label lblSize;
        private TextBox txtSize;
        private Button btnCreateTS;
        private Button btnDropTS;
        private Button btnResizeTS;
        private ListView lstTablespaces;
        private ColumnHeader TBSTen;
        private ColumnHeader KichThuoc;
        private ColumnHeader TBSTrangThai;
        private ColumnHeader TBSTDMR;
        private TabPage tabAudit;
        private GroupBox grpAudit;
        private ListView lstAudit;
        private ColumnHeader ThoiGian;
        private ColumnHeader User;
        private ColumnHeader HanhDong;
        private ColumnHeader TDDoiTuong;
        private ColumnHeader TDTrangThai;
        private Button btnRefreshAudit;
    }
}
