using Oracle.ManagedDataAccess.Client;
using OracleUserManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atbmcq_02
{
    public partial class Grant_Privileges : UserControl
    {
        private OracleDbConnection _connection;

        public Grant_Privileges(OracleDbConnection _connect)
        {
            InitializeComponent();
            _connection = _connect;
            LoadPrivileges(null, null);
        }

        private void GrantPrivilege(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGrantee.Text) || (chkSelect.Checked == false && chkInsert.Checked == false && chkDelete.Checked == false && chkUpdate.Checked == false) || string.IsNullOrWhiteSpace(txtObject.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using var conn = new OracleConnection(_connection.GetConnectionString());
                conn.Open();

                string grantee = txtGrantee.Text.Trim();
                string tableName = txtObject.Text.Trim();
                if (!tableName.Contains("."))
                {
                    tableName = _connection.Username.ToUpper() + "." + tableName;
                }
                bool grantInsert = chkInsert.Checked;
                bool grantSelect = chkSelect.Checked;
                bool grantUpdate = chkUpdate.Checked;
                bool grantDelete = chkDelete.Checked;
                string grantCols = string.IsNullOrWhiteSpace(txtColumn.Text) ? null : txtColumn.Text.Trim();
                string selectCols = null;
                string updateCols = null;

                if (grantSelect)
                {
                    selectCols = grantCols;
                }

                if (grantUpdate)
                {
                    updateCols = grantCols;
                }

                using var cmd = new OracleCommand("grant_privilege_proc", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee;
                cmd.Parameters.Add("p_table_name", OracleDbType.Varchar2).Value = tableName;
                cmd.Parameters.Add("p_select_cols", OracleDbType.Varchar2).Value = (object)selectCols ?? DBNull.Value;
                cmd.Parameters.Add("p_update_cols", OracleDbType.Varchar2).Value = (object)updateCols ?? DBNull.Value;
                cmd.Parameters.Add("p_grant_select", OracleDbType.Boolean).Value = grantSelect;
                cmd.Parameters.Add("p_grant_insert", OracleDbType.Boolean).Value = grantInsert;
                cmd.Parameters.Add("p_grant_delete", OracleDbType.Boolean).Value = grantDelete;
                cmd.Parameters.Add("p_grant_update", OracleDbType.Boolean).Value = grantUpdate;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cấp quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPrivileges(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RevokePrivilege(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGrantee.Text) || (chkSelect.Checked == false && chkInsert.Checked == false && chkDelete.Checked == false && chkUpdate.Checked == false) || string.IsNullOrWhiteSpace(txtObject.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using var conn = new OracleConnection(_connection.GetConnectionString());
                conn.Open();

                string grantee = txtGrantee.Text.Trim();
                string tableName = txtObject.Text.Trim();
                if (!tableName.Contains("."))
                {
                    tableName = _connection.Username.ToUpper() + "." + tableName;
                }
                bool grantInsert = chkInsert.Checked;
                bool grantSelect = chkSelect.Checked;
                bool grantUpdate = chkUpdate.Checked;
                bool grantDelete = chkDelete.Checked;

                using var cmd = new OracleCommand("revoke_privilege_proc", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_grant_select", OracleDbType.Boolean).Value = grantSelect;
                cmd.Parameters.Add("p_grant_insert", OracleDbType.Boolean).Value = grantInsert;
                cmd.Parameters.Add("p_grant_delete", OracleDbType.Boolean).Value = grantDelete;
                cmd.Parameters.Add("p_grant_update", OracleDbType.Boolean).Value = grantUpdate;
                cmd.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee;
                cmd.Parameters.Add("p_object_name", OracleDbType.Varchar2).Value = tableName;

                cmd.ExecuteNonQuery();
                
                // Clear selection and checkboxes
                txtGrantee.Clear();
                txtObject.Clear();
                chkSelect.Checked = false;
                chkInsert.Checked = false;
                chkDelete.Checked = false;
                chkUpdate.Checked = false;
                
                // Refresh the list
                lstPrivileges.Items.Clear();
                LoadPrivileges(sender, e);
                
                MessageBox.Show("Thu hồi quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPrivileges(object sender, EventArgs e)
        {
            try
            {
                using var conn = new OracleConnection(_connection.GetConnectionString());
                conn.Open();

                using var cmd = new OracleCommand("get_privileges_list", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                lstPrivileges.Items.Clear();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var item = new ListViewItem(reader["grantee"].ToString());
                    item.SubItems.Add(reader["privilege"].ToString());
                    item.SubItems.Add(reader["table_name"].ToString());
                    item.SubItems.Add(reader["grantable"].ToString());
                    lstPrivileges.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked || chkUpdate.Checked)
            {
                pnlColumn.Visible = true;
            }
            else
            {
                pnlColumn.Visible = false;
            }
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked)
            {
                chkInsert.ForeColor = Color.Gray;
                chkDelete.ForeColor = Color.Gray;
                chkUpdate.ForeColor = Color.Gray;
                chkInsert.Enabled = false;
                chkDelete.Enabled = false;
                chkUpdate.Enabled = false;
            }
            else
            {
                chkInsert.ForeColor = SystemColors.ControlText;
                chkDelete.ForeColor = SystemColors.ControlText;
                chkUpdate.ForeColor = SystemColors.ControlText;
                chkInsert.Enabled = true;
                chkDelete.Enabled = true;
                chkUpdate.Enabled = true;
            }
        }

        private void chkInsert_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInsert.Checked)
            {
                chkSelect.ForeColor = Color.Gray;
                chkDelete.ForeColor = Color.Gray;
                chkUpdate.ForeColor = Color.Gray;
                chkSelect.Enabled = false;
                chkDelete.Enabled = false;
                chkUpdate.Enabled = false;
            }
            else
            {
                chkSelect.ForeColor = SystemColors.ControlText;
                chkDelete.ForeColor = SystemColors.ControlText;
                chkUpdate.ForeColor = SystemColors.ControlText;
                chkSelect.Enabled = true;
                chkDelete.Enabled = true;
                chkUpdate.Enabled = true;
            }
        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDelete.Checked)
            {
                chkInsert.ForeColor = Color.Gray;
                chkSelect.ForeColor = Color.Gray;
                chkUpdate.ForeColor = Color.Gray;
                chkInsert.Enabled = false;
                chkSelect.Enabled = false;
                chkUpdate.Enabled = false;
            }
            else
            {
                chkInsert.ForeColor = SystemColors.ControlText;
                chkSelect.ForeColor = SystemColors.ControlText;
                chkUpdate.ForeColor = SystemColors.ControlText;
                chkInsert.Enabled = true;
                chkSelect.Enabled = true;
                chkUpdate.Enabled = true;
            }
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdate.Checked)
            {
                chkInsert.ForeColor = Color.Gray;
                chkDelete.ForeColor = Color.Gray;
                chkSelect.ForeColor = Color.Gray;
                chkInsert.Enabled = false;
                chkDelete.Enabled = false;
                chkSelect.Enabled = false;
            }
            else
            {
                chkInsert.ForeColor = SystemColors.ControlText;
                chkDelete.ForeColor = SystemColors.ControlText;
                chkSelect.ForeColor = SystemColors.ControlText;
                chkInsert.Enabled = true;
                chkDelete.Enabled = true;
                chkSelect.Enabled = true;
            }
        }

        private void LstPrivileges_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                ListViewItem item = e.Item;
                txtGrantee.Text = item.SubItems[0].Text;
                using (var conn = new OracleConnection(_connection.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("SELECT table_name FROM user_tables WHERE table_name = 'AUDIT_LOG'", conn))
                    {
                        var tableName = cmd.ExecuteScalar()?.ToString();
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            txtObject.Text = tableName;
                        }
                    }
                }

                chkSelect.Checked = false;
                chkInsert.Checked = false;
                chkDelete.Checked = false;
                chkUpdate.Checked = false;

                string privilege = item.SubItems[1].Text.ToUpper();
                switch (privilege)
                {
                    case "SELECT":
                        chkSelect.Checked = true;
                        break;
                    case "INSERT":
                        chkInsert.Checked = true;
                        break;
                    case "DELETE":
                        chkDelete.Checked = true;
                        break;
                    case "UPDATE":
                        chkUpdate.Checked = true;
                        break;
                }
            }
        }
    }
}
