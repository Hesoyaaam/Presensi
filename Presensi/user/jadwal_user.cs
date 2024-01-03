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
    public partial class jadwal_user : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");
        public jadwal_user()
        {
            InitializeComponent();
            LoadDataJadwal();
        }
        private void LoadDataJadwal()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT id_jadwal, acara, tanggal, keterangan FROM jadwal", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable jadwalDataTable = new DataTable();
                adapter.Fill(jadwalDataTable);

                // Letakkan breakpoint atau pesan log di sini
                Console.WriteLine("Data Loaded Successfully!");

                conn.Close();
                if (dataGridViewJadwal != null)
                {
                    dataGridViewJadwal.DataSource = jadwalDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading event data: " + ex.Message);
            }
        }


        private void jadwal_user_Load(object sender, EventArgs e)
        {

        }
    }
}
