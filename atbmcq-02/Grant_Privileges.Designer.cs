using OracleUserManager.Models;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace atbmcq_02
{
    partial class Grant_Privileges
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
            grpPrivileges = new GroupBox();
            chkUpdate = new CheckBox();
            chkDelete = new CheckBox();
            chkInsert = new CheckBox();
            chkSelect = new CheckBox();
            pnlColumn = new Panel();
            txtColumn = new TextBox();
            lblColumn = new Label();
            lblGrantee = new Label();
            txtGrantee = new TextBox();
            lblObject = new Label();
            txtObject = new TextBox();
            btnGrant = new Button();
            btnRevoke = new Button();
            lstPrivileges = new ListView();
            UserOrRole = new ColumnHeader();
            Privilege = new ColumnHeader();
            Target = new ColumnHeader();
            PType = new ColumnHeader();
            grpPrivileges.SuspendLayout();
            pnlColumn.SuspendLayout();
            SuspendLayout();
            // 
            // grpPrivileges
            // 
            grpPrivileges.Controls.Add(chkUpdate);
            grpPrivileges.Controls.Add(chkDelete);
            grpPrivileges.Controls.Add(chkInsert);
            grpPrivileges.Controls.Add(chkSelect);
            grpPrivileges.Controls.Add(pnlColumn);
            grpPrivileges.Controls.Add(lblGrantee);
            grpPrivileges.Controls.Add(txtGrantee);
            grpPrivileges.Controls.Add(lblObject);
            grpPrivileges.Controls.Add(txtObject);
            grpPrivileges.Controls.Add(btnGrant);
            grpPrivileges.Controls.Add(btnRevoke);
            grpPrivileges.Controls.Add(lstPrivileges);
            grpPrivileges.Dock = DockStyle.Fill;
            grpPrivileges.Location = new Point(0, 0);
            grpPrivileges.Margin = new Padding(8, 3, 8, 3);
            grpPrivileges.Name = "grpPrivileges";
            grpPrivileges.Padding = new Padding(8, 3, 8, 3);
            grpPrivileges.Size = new Size(1592, 535);
            grpPrivileges.TabIndex = 0;
            grpPrivileges.TabStop = false;
            grpPrivileges.Text = "Privilege Management";
            // 
            // chkUpdate
            // 
            chkUpdate.AutoSize = true;
            chkUpdate.Location = new Point(595, 180);
            chkUpdate.Margin = new Padding(4, 3, 4, 3);
            chkUpdate.Name = "chkUpdate";
            chkUpdate.Size = new Size(113, 33);
            chkUpdate.TabIndex = 20;
            chkUpdate.Text = "Update";
            chkUpdate.UseVisualStyleBackColor = true;
            chkUpdate.CheckedChanged += chkUpdate_CheckedChanged;
            chkUpdate.CheckedChanged += panel_CheckedChanged;
            // 
            // chkDelete
            // 
            chkDelete.AutoSize = true;
            chkDelete.Location = new Point(406, 180);
            chkDelete.Margin = new Padding(4, 3, 4, 3);
            chkDelete.Name = "chkDelete";
            chkDelete.Size = new Size(107, 33);
            chkDelete.TabIndex = 19;
            chkDelete.Text = "Delete";
            chkDelete.UseVisualStyleBackColor = true;
            chkDelete.CheckedChanged += chkDelete_CheckedChanged;
            // 
            // chkInsert
            // 
            chkInsert.AutoSize = true;
            chkInsert.Location = new Point(229, 180);
            chkInsert.Margin = new Padding(4, 3, 4, 3);
            chkInsert.Name = "chkInsert";
            chkInsert.Size = new Size(98, 33);
            chkInsert.TabIndex = 18;
            chkInsert.Text = "Insert";
            chkInsert.UseVisualStyleBackColor = true;
            chkInsert.CheckedChanged += chkInsert_CheckedChanged;
            // 
            // chkSelect
            // 
            chkSelect.AutoSize = true;
            chkSelect.Location = new Point(55, 180);
            chkSelect.Margin = new Padding(4, 3, 4, 3);
            chkSelect.Name = "chkSelect";
            chkSelect.Size = new Size(102, 33);
            chkSelect.TabIndex = 17;
            chkSelect.Text = "Select";
            chkSelect.UseVisualStyleBackColor = true;
            chkSelect.CheckedChanged += chkSelect_CheckedChanged;
            chkSelect.CheckedChanged += panel_CheckedChanged;
            // 
            // pnlColumn
            // 
            pnlColumn.Controls.Add(txtColumn);
            pnlColumn.Controls.Add(lblColumn);
            pnlColumn.Location = new Point(822, 36);
            pnlColumn.Margin = new Padding(4, 3, 4, 3);
            pnlColumn.Name = "pnlColumn";
            pnlColumn.Size = new Size(572, 70);
            pnlColumn.TabIndex = 12;
            pnlColumn.Visible = false;
            // 
            // txtColumn
            // 
            txtColumn.Location = new Point(190, 14);
            txtColumn.Margin = new Padding(4, 3, 4, 3);
            txtColumn.Name = "txtColumn";
            txtColumn.Size = new Size(365, 37);
            txtColumn.TabIndex = 2;
            // 
            // lblColumn
            // 
            lblColumn.AutoSize = true;
            lblColumn.Location = new Point(47, 17);
            lblColumn.Margin = new Padding(4, 0, 4, 0);
            lblColumn.Name = "lblColumn";
            lblColumn.Size = new Size(95, 29);
            lblColumn.TabIndex = 0;
            lblColumn.Text = "Column";
            // 
            // lblGrantee
            // 
            lblGrantee.AutoSize = true;
            lblGrantee.Location = new Point(55, 51);
            lblGrantee.Margin = new Padding(8, 0, 8, 0);
            lblGrantee.Name = "lblGrantee";
            lblGrantee.Size = new Size(122, 29);
            lblGrantee.TabIndex = 0;
            lblGrantee.Text = "User/Role:";
            // 
            // txtGrantee
            // 
            txtGrantee.Location = new Point(343, 48);
            txtGrantee.Margin = new Padding(8, 3, 8, 3);
            txtGrantee.Name = "txtGrantee";
            txtGrantee.Size = new Size(365, 37);
            txtGrantee.TabIndex = 1;
            // 
            // lblObject
            // 
            lblObject.AutoSize = true;
            lblObject.Location = new Point(55, 113);
            lblObject.Margin = new Padding(8, 0, 8, 0);
            lblObject.Name = "lblObject";
            lblObject.Size = new Size(88, 29);
            lblObject.TabIndex = 4;
            lblObject.Text = "Object:";
            // 
            // txtObject
            // 
            txtObject.Location = new Point(343, 109);
            txtObject.Margin = new Padding(8, 3, 8, 3);
            txtObject.Name = "txtObject";
            txtObject.Size = new Size(365, 37);
            txtObject.TabIndex = 5;
            // 
            // btnGrant
            // 
            btnGrant.Location = new Point(822, 160);
            btnGrant.Margin = new Padding(8, 3, 8, 3);
            btnGrant.Name = "btnGrant";
            btnGrant.Size = new Size(215, 53);
            btnGrant.TabIndex = 6;
            btnGrant.Text = "Grant";
            btnGrant.Click += GrantPrivilege;
            // 
            // btnRevoke
            // 
            btnRevoke.AutoSize = true;
            btnRevoke.Location = new Point(1179, 160);
            btnRevoke.Margin = new Padding(8, 3, 8, 3);
            btnRevoke.Name = "btnRevoke";
            btnRevoke.Size = new Size(215, 53);
            btnRevoke.TabIndex = 7;
            btnRevoke.Text = "Revoke";
            btnRevoke.Click += RevokePrivilege;
            // 
            // lstPrivileges
            // 
            lstPrivileges.Columns.AddRange(new ColumnHeader[] { UserOrRole, Privilege, Target, PType });
            lstPrivileges.Location = new Point(55, 241);
            lstPrivileges.Margin = new Padding(8, 3, 8, 3);
            lstPrivileges.Name = "lstPrivileges";
            lstPrivileges.Size = new Size(1480, 279);
            lstPrivileges.TabIndex = 8;
            lstPrivileges.UseCompatibleStateImageBehavior = false;
            lstPrivileges.View = View.Details;
            lstPrivileges.ItemSelectionChanged += LstPrivileges_ItemSelectionChanged;
            // 
            // UserOrRole
            // 
            UserOrRole.Text = "User/Role";
            UserOrRole.Width = 370;
            // 
            // Privilege
            // 
            Privilege.Text = "Privilege";
            Privilege.Width = 370;
            // 
            // Target
            // 
            Target.Text = "Object";
            Target.Width = 370;
            // 
            // PType
            // 
            PType.Text = "Type";
            PType.Width = 370;
            // 
            // Grant_Privileges
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grpPrivileges);
            Font = new Font("Times New Roman", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Grant_Privileges";
            Size = new Size(1592, 535);
            grpPrivileges.ResumeLayout(false);
            grpPrivileges.PerformLayout();
            pnlColumn.ResumeLayout(false);
            pnlColumn.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpPrivileges;
        private CheckBox chkUpdate;
        private CheckBox chkDelete;
        private CheckBox chkInsert;
        private CheckBox chkSelect;
        private Panel pnlColumn;
        private TextBox txtColumn;
        private Label lblColumn;
        private Label lblGrantee;
        private TextBox txtGrantee;
        private Label lblObject;
        private TextBox txtObject;
        private Button btnGrant;
        private Button btnRevoke;
        private ListView lstPrivileges;
        private ColumnHeader UserOrRole;
        private ColumnHeader Privilege;
        private ColumnHeader Target;
        private ColumnHeader PType;
    }
}
