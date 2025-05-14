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
using OracleUserManager.Models;
using Oracle.ManagedDataAccess.Client;
using System.Text.Json;
using System.IO;

namespace atbmcq_02
{
    public partial class Connection : Form
    {
        private OracleDbConnection _connection;

        public Connection()
        {
            InitializeComponent();
            _connection = new OracleDbConnection();
            
            // Set default values
            cboAuthType.SelectedIndex = 0;
            cboRole.SelectedIndex = 0;
            cboConnType.SelectedIndex = 0;
            txtUsername.Text = "C##ADMIN";
            // Initial radio button state
            txtSID.Enabled = radSID.Checked;
            txtServiceName.Enabled = radServiceName.Checked;

            // Add event handlers for buttons
            btnTest.Click += BtnTest_Click;
            btnConnect.Click += orclConnect;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnTest_Click(object? sender, EventArgs e)
        {
            try
            {
                // Get connection details
                _connection.Hostname = cboHostname.Text;
                _connection.Port = int.Parse(txtPort.Text);
                _connection.Username = txtUsername.Text;
                _connection.Password = txtPassword.Text;
                _connection.Role = cboRole.SelectedItem?.ToString() ?? "default";

                if (radSID.Checked)
                {
                    _connection.SID = txtSID.Text;
                    _connection.ServiceName = string.Empty;
                }
                else
                {
                    _connection.ServiceName = txtServiceName.Text;
                    _connection.SID = string.Empty;
                }

                // Test the connection
                if (_connection.TestConnection())
                {
                    MessageBox.Show("Connection test successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Add new hostname to the list if it doesn't exist
                    if (!string.IsNullOrEmpty(cboHostname.Text) && !cboHostname.Items.Contains(cboHostname.Text))
                    {
                        cboHostname.Items.Add(cboHostname.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Connection test failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error testing connection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private void orclConnect(object? sender, EventArgs e)
        {
            try
            {
                this._connection.Hostname = cboHostname.Text;
                this._connection.Port = int.Parse(txtPort.Text);
                
                if (radSID.Checked)
                {
                    this._connection.SID = txtSID.Text;
                    this._connection.ServiceName = string.Empty;
                }
                else
                {
                    this._connection.ServiceName = txtServiceName.Text;
                    this._connection.SID = string.Empty;
                }
                
                this._connection.Username = txtUsername.Text;
                this._connection.Password = txtPassword.Text;
                this._connection.Role = cboRole.SelectedItem?.ToString() ?? "default";

                if (_connection.TestConnection())
                {
                    // Add new hostname to the list if it doesn't exist
                    if (!string.IsNullOrEmpty(cboHostname.Text) && !cboHostname.Items.Contains(cboHostname.Text))
                    {
                        cboHostname.Items.Add(cboHostname.Text);
                    }

                    MessageBox.Show("Connection successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadMainForm();
                }
                else
                {
                    MessageBox.Show("Connection failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadMainForm()
        {
            this.Hide();
            Home home = new Home(_connection);
            home.ShowDialog();
            this.Close();
        }
    }
}
