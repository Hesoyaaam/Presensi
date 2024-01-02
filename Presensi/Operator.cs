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
        public Operator()
        {
            InitializeComponent();
            LoadDataKaryawan(); 
            LoadDataPresensi();
            LoadDataJadwal();
        }
        private void LoadDataKaryawan()
        {
            try
            {
                conn.Open();

                // Select only necessary columns from 'karyawan'
                MySqlCommand cmd = new MySqlCommand("SELECT id_karyawan, nama_karyawan, jabatan FROM karyawan", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable karyawanDataTable = new DataTable();
                adapter.Fill(karyawanDataTable);

                // Add columns for username and password
                karyawanDataTable.Columns.Add("username", typeof(string));
                karyawanDataTable.Columns.Add("password", typeof(string));

                foreach (DataRow row in karyawanDataTable.Rows)
                {
                    int karyawanId = Convert.ToInt32(row["id_karyawan"]);

                    // Select username and password from 'login'
                    MySqlCommand loginCmd = new MySqlCommand("SELECT username, password FROM login WHERE id_karyawan = @id_karyawan", conn);
                    loginCmd.Parameters.AddWithValue("@id_karyawan", karyawanId);

                    using (MySqlDataReader reader = loginCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            row["username"] = reader["username"].ToString();
                            row["password"] = reader["password"].ToString();
                        }
                    }
                }

                // Bind DataGridView to DataTable
                dataGridViewKaryawan.DataSource = karyawanDataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from the 'karyawan' table: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void LoadDataPresensi()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT presensi.id_presensi, karyawan.nama_karyawan, presensi.waktu_presensi FROM presensi JOIN karyawan ON presensi.id_karyawan = karyawan.id_karyawan", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable presensiDataTable = new DataTable();
                adapter.Fill(presensiDataTable);

                dataGridViewPresensi.DataSource = presensiDataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message);
            }
        }
        private void LoadDataJadwal()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT id_jadwal, tanggal, jam_masuk, jam_selesai, keterangan, id_karyawan FROM jadwal", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable jadwalDataTable = new DataTable();
                adapter.Fill(jadwalDataTable);

                // Add additional logic if needed

                dataGridViewPresensi.DataSource = jadwalDataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading event data: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void Operator_Load(object sender, EventArgs e)
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
