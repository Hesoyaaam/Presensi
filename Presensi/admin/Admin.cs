using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.IO;
using Presensi.admin;

namespace Presensi
{
    public partial class Admin : Form
    {
        karyawan_admin  karyawan_admin;
        jadwal_admin jadwal_admin;
        presensi_admin presensi_admin;
        public Admin()
        {
            InitializeComponent();
            karyawan_admin = new karyawan_admin();
            jadwal_admin = new jadwal_admin();
            presensi_admin = new presensi_admin();
            ShowDashboard(karyawan_admin);

            karyawan_admin.KaryawanDataChanged += KaryawanDataChangedHandler;
            jadwal_admin.JadwalDataChanged += JadwalDataChangedHandler;
        }
        private void KaryawanDataChangedHandler(object sender, EventArgs e)
        {
            presensi_admin.LoadComboBoxNamaKaryawan();
        }
        private void JadwalDataChangedHandler(object sender, EventArgs e)
        {
            presensi_admin.LoadComboBoxNamaAcara();
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

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }

        private void btnShowKaryawan_Click(object sender, EventArgs e)
        {
            ShowDashboard(karyawan_admin);
        }

        private void btnShowJadwal_Click(object sender, EventArgs e)
        {
            ShowDashboard(jadwal_admin);
        }

        private void btnPresensi_Click(object sender, EventArgs e)
        {
            ShowDashboard(presensi_admin);
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}