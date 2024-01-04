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

namespace Presensi.user
{
    public partial class presensi_user : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");

        public presensi_user()
        {
            InitializeComponent();
            LoadDataPresensi();
        }

        private void LoadDataPresensi()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT presensi.id_presensi, karyawan.nama_karyawan, jadwal.acara, jadwal.tanggal, presensi.keterangan " +
                                                    "FROM presensi " +
                                                    "LEFT JOIN karyawan ON presensi.id_karyawan = karyawan.id_karyawan " +
                                                    "LEFT JOIN jadwal ON presensi.id_jadwal = jadwal.id_jadwal", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable presensiDataTable = new DataTable();
                adapter.Fill(presensiDataTable);

                conn.Close();
                if(dataGridViewPresensi != null)
                {
                    dataGridViewPresensi.DataSource = presensiDataTable;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message);
            }
        }
        private void presensi_user_Load(object sender, EventArgs e)
        {

        }
    }
}
