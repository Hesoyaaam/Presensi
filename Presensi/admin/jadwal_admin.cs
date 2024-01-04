using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presensi.admin
{
    public partial class jadwal_admin : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");
        public event EventHandler JadwalDataChanged;
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
                JadwalDataChanged?.Invoke(this, EventArgs.Empty);
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

                MessageBox.Show("Event schedule added successfully");

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

                MessageBox.Show("The event schedule has been successfully changed");
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

                    MessageBox.Show("The event schedule has been successfully deleted");

                }
                else
                {
                    MessageBox.Show("Select the event schedule first");
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
                MessageBox.Show("Select the event schedule row first");
                return -1;
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a SaveFileDialog to specify the target CSV file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Export Data to CSV",
                    FileName = "jadwal_export.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    StringBuilder csvContent = new StringBuilder();
                    foreach (DataGridViewColumn column in dataGridViewJadwal.Columns)
                    {
                        csvContent.Append(column.HeaderText + ",");
                    }
                    csvContent.AppendLine();

                    foreach (DataGridViewRow row in dataGridViewJadwal.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            csvContent.Append(cell.Value + ",");
                        }
                        csvContent.AppendLine();
                    }
                    File.WriteAllText(filePath, csvContent.ToString());

                    MessageBox.Show("Data exported successfully to: " + filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message);
            }
        }

        private void jadwal_admin_Load(object sender, EventArgs e)
        {

        }
    }
}
