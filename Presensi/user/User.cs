using MySql.Data.MySqlClient;
using Presensi.user;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presensi
{
    public partial class User : Form
    {
        jadwal_user jadwal_user;
        presensi_user presensi_user;
        public User()
        {
            InitializeComponent();
            jadwal_user = new jadwal_user();
            presensi_user = new presensi_user();
            ShowDashboard(jadwal_user);
        }

        private void ShowDashboard(Form dashboard)
        {
            dashboard.TopLevel = false;
            dashboard.FormBorderStyle = FormBorderStyle.None;
            dashboard.Dock = DockStyle.Fill;
            panelDashboard.Controls.Clear();
            panelDashboard.Controls.Add(dashboard);
            dashboard.Show();
        }

        private void btnShowJadwal_Click(object sender, EventArgs e)
        {
            ShowDashboard(jadwal_user);
        }
        private void btnPresensi_Click(object sender, EventArgs e)
        {
            ShowDashboard(presensi_user);
        }
        private void User_Load(object sender, EventArgs e)
        {

        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }
    }
}
