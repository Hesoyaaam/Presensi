using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presensi
{
    public partial class Admin : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=siubet;Initial Catalog=absensi;Integrated Security=True");
        public Admin()
        {
            InitializeComponent();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

        }
    }
}
