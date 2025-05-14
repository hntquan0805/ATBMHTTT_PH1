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
    public partial class Home : Form
    {
        public Home(OracleDbConnection _connect)
        {
            InitializeComponent();
            _connection = _connect;
            LoadUserManage();
        }

        private void userManage_Click(object sender, EventArgs e)
        {
            LoadUserManage();
        }

        private void LoadUserManage()
        {
            panelContent.Controls.Clear();
            var uc = new User_Management(_connection);
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void grantPrivileges_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            var uc = new Grant_Privileges(_connection);
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }
    }
}
