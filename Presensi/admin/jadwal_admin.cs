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

namespace Presensi.admin
{
    public partial class jadwal_admin : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");
        public jadwal_admin()
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

                conn.Close();
                dataGridViewJadwal.DataSource = jadwalDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading event data: " + ex.Message);
            }
        }
        private void btnTambahJadwal_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                MySqlCommand tambahJadwalCmd = new MySqlCommand("INSERT INTO jadwal (acara, tanggal, keterangan) VALUES (@acara, @tanggal, @keterangan)", conn);
                tambahJadwalCmd.Parameters.AddWithValue("@acara", txtAcara.Text);
                tambahJadwalCmd.Parameters.AddWithValue("@tanggal", dateTimePickerTanggal.Value.ToString("yyyy-MM-dd"));
                tambahJadwalCmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text);
                tambahJadwalCmd.ExecuteNonQuery();

                MessageBox.Show("Jadwal acara berhasil ditambahkan");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error menambahkan jadwal acara: " + ex.Message);
            }
            conn.Close();
            LoadDataJadwal();
        }
        private void btnUbahJadwal_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                MySqlCommand updateJadwalCmd = new MySqlCommand("UPDATE jadwal SET acara = @acara ,tanggal = @tanggal, keterangan = @keterangan WHERE id_jadwal = @id_jadwal", conn);
                updateJadwalCmd.Parameters.AddWithValue("@acara", txtAcara.Text);
                updateJadwalCmd.Parameters.AddWithValue("@tanggal", dateTimePickerTanggal.Value.ToString("yyyy-MM-dd"));
                updateJadwalCmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text);
                updateJadwalCmd.Parameters.AddWithValue("@id_jadwal", GetSelectedJadwalId());
                updateJadwalCmd.ExecuteNonQuery();

                MessageBox.Show("Jadwal acara berhasil diubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mengubah jadwal acara: " + ex.Message);
            }
            conn.Close();
            LoadDataJadwal();
        }

        private void btnHapusJadwal_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                int selectedJadwalId = GetSelectedJadwalId();

                if (selectedJadwalId != -1)
                {
                    MySqlCommand hapusJadwalCmd = new MySqlCommand("DELETE FROM jadwal WHERE id_jadwal = @id_jadwal", conn);
                    hapusJadwalCmd.Parameters.AddWithValue("@id_jadwal", selectedJadwalId);

                    hapusJadwalCmd.ExecuteNonQuery();

                    MessageBox.Show("Jadwal acara berhasil dihapus");

                }
                else
                {
                    MessageBox.Show("Pilih jadwal acara terlebih dahulu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error menghapus jadwal acara: " + ex.Message);
            }
            conn.Close();
            LoadDataJadwal();
        }
        private int GetSelectedJadwalId()
        {
            if (dataGridViewJadwal.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridViewJadwal.SelectedRows[0].Cells["id_jadwal"].Value);
            }
            else
            {
                MessageBox.Show("Pilih baris jadwal acara terlebih dahulu");
                return -1;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
