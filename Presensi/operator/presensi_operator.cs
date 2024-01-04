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
    public partial class presensi_operator : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");
        public presensi_operator()
        {
            InitializeComponent();
            LoadDataPresensi();
            LoadComboBoxData();
            LoadComboBoxStatusData();
            LoadComboBoxNamaAcara();
        }
        private void LoadComboBoxData()
        {
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
        private void LoadComboBoxNamaAcara()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT acara FROM jadwal", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string namaAcara = reader["acara"].ToString();

                    // Menambahkan item ke ComboBoxNamaAcara
                    ComboBoxNamaAcara.Items.Add(namaAcara);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading event names: " + ex.Message);
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
                            // Check if the selected employee's name exists in the 'karyawan' table
                            MySqlCommand checkKaryawanCmd = new MySqlCommand("SELECT id_karyawan FROM karyawan WHERE nama_karyawan = @nama_karyawan", conn, transaction);
                            checkKaryawanCmd.Parameters.AddWithValue("@nama_karyawan", selectedKaryawanNama);

                            object result = checkKaryawanCmd.ExecuteScalar();

                            if (result != null)
                            {
                                int selectedKaryawanId = Convert.ToInt32(result);

                                MySqlCommand checkEventCmd = new MySqlCommand("SELECT id_jadwal FROM jadwal WHERE acara = @acara", conn, transaction);
                                checkEventCmd.Parameters.AddWithValue("@acara", selectedAcara);

                                result = checkEventCmd.ExecuteScalar();

                                if (result != null)
                                {
                                    int selectedJadwalId = Convert.ToInt32(result);

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
                                    MessageBox.Show("Event name not found");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Employee name not found");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select employees, attendance status, and events first");
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
                                MySqlCommand checkKaryawanCmd = new MySqlCommand("SELECT id_karyawan FROM karyawan WHERE nama_karyawan = @nama_karyawan", conn, transaction);
                                checkKaryawanCmd.Parameters.AddWithValue("@nama_karyawan", selectedKaryawanNama);

                                object result = checkKaryawanCmd.ExecuteScalar();

                                if (result != null)
                                {
                                    int selectedKaryawanId = Convert.ToInt32(result);
                                    MySqlCommand checkEventCmd = new MySqlCommand("SELECT id_jadwal FROM jadwal WHERE acara = @acara", conn, transaction);
                                    checkEventCmd.Parameters.AddWithValue("@acara", selectedAcara);

                                    result = checkEventCmd.ExecuteScalar();

                                    if (result != null)
                                    {
                                        int selectedJadwalId = Convert.ToInt32(result);
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
                                        MessageBox.Show("Event name not found");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Employee name not found");
                                }
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
                        throw;
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
                        int selectedPresensiId = GetSelectedPresensiId(); 

                        if (selectedPresensiId != -1)
                        {
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
                MessageBox.Show("Select the presence row first.");
                return -1;
            }
        }

        private void presensi_operator_Load(object sender, EventArgs e)
        {

        }
    }
}
