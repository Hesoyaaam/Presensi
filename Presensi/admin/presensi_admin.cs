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
    public partial class presensi_admin : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");
        public presensi_admin()
        {
            InitializeComponent();
            LoadDataPresensi();
            LoadComboBoxNamaKaryawan();
            LoadComboBoxNamaAcara();
            LoadComboBoxStatusData();
        }
        public void LoadComboBoxNamaKaryawan()
        {
            ComboBoxPresensiKaryawan.Items.Clear();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT nama_karyawan FROM karyawan", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboBoxPresensiKaryawan.Items.Add(reader["nama_karyawan"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee names: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void LoadComboBoxStatusData()
        {
            ComboBoxStatus.Items.AddRange(new string[] { "Hadir", "Tidak Hadir", "Sakit", "Izin" });
        }
        public void LoadComboBoxNamaAcara()
        {
            ComboBoxNamaAcara.Items.Clear();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT acara FROM jadwal", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string namaAcara = reader["acara"].ToString();
                    ComboBoxNamaAcara.Items.Add(namaAcara);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading event names: " + ex.Message);
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

                MySqlCommand cmd = new MySqlCommand("SELECT presensi.id_presensi, karyawan.nama_karyawan, jadwal.acara, jadwal.tanggal, presensi.keterangan " +
                                                    "FROM presensi " +
                                                    "LEFT JOIN karyawan ON presensi.id_karyawan = karyawan.id_karyawan " +
                                                    "LEFT JOIN jadwal ON presensi.id_jadwal = jadwal.id_jadwal", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable presensiDataTable = new DataTable();
                adapter.Fill(presensiDataTable);

                conn.Close();

                dataGridViewPresensi.DataSource = presensiDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message);
            }
        }
        private void btnTambahPresensi_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string selectedKaryawanNama = ComboBoxPresensiKaryawan.SelectedItem?.ToString();
                        string status = ComboBoxStatus.SelectedItem?.ToString();
                        string selectedAcara = ComboBoxNamaAcara.SelectedItem?.ToString();

                        if (!string.IsNullOrEmpty(selectedKaryawanNama) && !string.IsNullOrEmpty(status) && !string.IsNullOrEmpty(selectedAcara))
                        {
                            MySqlCommand getKaryawanIdCmd = new MySqlCommand("SELECT id_karyawan FROM karyawan WHERE nama_karyawan = @nama_karyawan", conn, transaction);
                            getKaryawanIdCmd.Parameters.AddWithValue("@nama_karyawan", selectedKaryawanNama);
                            int selectedKaryawanId = Convert.ToInt32(getKaryawanIdCmd.ExecuteScalar());

                            MySqlCommand getJadwalIdCmd = new MySqlCommand("SELECT id_jadwal FROM jadwal WHERE acara = @acara", conn, transaction);
                            getJadwalIdCmd.Parameters.AddWithValue("@acara", selectedAcara);
                            int selectedJadwalId = Convert.ToInt32(getJadwalIdCmd.ExecuteScalar());

                            MySqlCommand tambahPresensiCmd = new MySqlCommand("INSERT INTO presensi (id_karyawan, id_jadwal, keterangan) VALUES (@id_karyawan, @id_jadwal, @keterangan)", conn, transaction);
                            tambahPresensiCmd.Parameters.AddWithValue("@id_karyawan", selectedKaryawanId);
                            tambahPresensiCmd.Parameters.AddWithValue("@id_jadwal", selectedJadwalId);
                            tambahPresensiCmd.Parameters.AddWithValue("@keterangan", status);
                            tambahPresensiCmd.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Presence added successfully");
                        }
                        else
                        {
                            MessageBox.Show("Select employees, attendance status, and events first");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error adding attendance: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding attendance: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                LoadDataPresensi();
            }
        }

        private void btnUbahPresensi_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int selectedPresensiId = GetSelectedPresensiId();

                        if (selectedPresensiId != -1)
                        {
                            string selectedKaryawanNama = ComboBoxPresensiKaryawan.SelectedItem?.ToString();
                            string status = ComboBoxStatus.SelectedItem?.ToString();
                            string selectedAcara = ComboBoxNamaAcara.SelectedItem?.ToString();

                            if (!string.IsNullOrEmpty(selectedKaryawanNama) && !string.IsNullOrEmpty(status) && !string.IsNullOrEmpty(selectedAcara))
                            {
                                MySqlCommand getKaryawanIdCmd = new MySqlCommand("SELECT id_karyawan FROM karyawan WHERE nama_karyawan = @nama_karyawan", conn, transaction);
                                getKaryawanIdCmd.Parameters.AddWithValue("@nama_karyawan", selectedKaryawanNama);
                                int selectedKaryawanId = Convert.ToInt32(getKaryawanIdCmd.ExecuteScalar());

                                MySqlCommand getJadwalIdCmd = new MySqlCommand("SELECT id_jadwal FROM jadwal WHERE acara = @acara", conn, transaction);
                                getJadwalIdCmd.Parameters.AddWithValue("@acara", selectedAcara);
                                int selectedJadwalId = Convert.ToInt32(getJadwalIdCmd.ExecuteScalar());

                                MySqlCommand updatePresensiCmd = new MySqlCommand("UPDATE presensi SET id_karyawan = @id_karyawan, id_jadwal = @id_jadwal, keterangan = @keterangan WHERE id_presensi = @id_presensi", conn, transaction);
                                updatePresensiCmd.Parameters.AddWithValue("@id_karyawan", selectedKaryawanId);
                                updatePresensiCmd.Parameters.AddWithValue("@id_jadwal", selectedJadwalId);
                                updatePresensiCmd.Parameters.AddWithValue("@keterangan", status);
                                updatePresensiCmd.Parameters.AddWithValue("@id_presensi", selectedPresensiId);
                                updatePresensiCmd.ExecuteNonQuery();

                                transaction.Commit();

                                MessageBox.Show("Presence changed successfully");
                            }
                            else
                            {
                                MessageBox.Show("Select employees, attendance status, and events first");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select presence first");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating attendance: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating attendance: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                LoadDataPresensi();
            }
        }
        private void btnHapusPresensi_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int selectedPresensiId = GetSelectedPresensiId(); // Get the selected attendance ID

                        if (selectedPresensiId != -1)
                        {
                            // Delete the selected attendance record from the 'presensi' table
                            MySqlCommand deletePresensiCmd = new MySqlCommand("DELETE FROM presensi WHERE id_presensi = @id_presensi", conn, transaction);
                            deletePresensiCmd.Parameters.AddWithValue("@id_presensi", selectedPresensiId);
                            deletePresensiCmd.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Presence successfully deleted");
                        }
                        else
                        {
                            MessageBox.Show("Select presence first");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting attendance: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                LoadDataPresensi();
            }
        }
        private int GetSelectedPresensiId()
        {
            if (dataGridViewPresensi.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridViewPresensi.SelectedRows[0].Cells["id_presensi"].Value);
            }
            else
            {
                MessageBox.Show("Pilih baris presensi terlebih dahulu.");
                return -1;
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Export Data to CSV",
                    FileName = "presensi_export.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    StringBuilder csvContent = new StringBuilder();
                    foreach (DataGridViewColumn column in dataGridViewPresensi.Columns)
                    {
                        csvContent.Append(column.HeaderText + ",");
                    }
                    csvContent.AppendLine(); 
                    foreach (DataGridViewRow row in dataGridViewPresensi.Rows)
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
        private void presensi_admin_Load(object sender, EventArgs e)
        {
            LoadComboBoxNamaKaryawan();
        }

        private void ComboBoxPresensiKaryawan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxNamaAcara_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
