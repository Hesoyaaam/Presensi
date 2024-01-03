using MySql.Data.MySqlClient;
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
    public partial class Operator : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");
        karyawan_operator karyawan;
        jadwal_operator jadwal;
        presensi_operator presensi;
        public Operator()
        {
            InitializeComponent();
            karyawan = new karyawan_operator();
            jadwal = new jadwal_operator();
            presensi = new presensi_operator();
            ShowDashboard(karyawan);
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
        private void Operator_Load(object sender, EventArgs e)
        {

        }
        private void btnShowKaryawan_Click(object sender, EventArgs e)
        {
            ShowDashboard(karyawan);
        }

        private void btnShowJadwal_Click(object sender, EventArgs e)
        {
            ShowDashboard(jadwal);
        }

        private void btnPresensi_Click(object sender, EventArgs e)
        {
            ShowDashboard(presensi);
        }

        private void btnKeluar_Click_1(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }
    }
}
