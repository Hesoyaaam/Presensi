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

namespace Presensi
{
    public partial class Admin : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");

        public Admin()
        {
            InitializeComponent();
            LoadData();
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
            ComboBoxStatus.Items.AddRange(new string[] { "Hadir", "Tidak Hadir", "Sakit", "Cuti" });
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
        private void LoadData()
        {
            LoadDataKaryawan();
            LoadDataPresensi();
            LoadDataJadwal();
        }
        private void LoadDataKaryawan()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT id_karyawan, nama_karyawan, jabatan FROM karyawan", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable karyawanDataTable = new DataTable();
                adapter.Fill(karyawanDataTable);

                karyawanDataTable.Columns.Add("username", typeof(string));
                karyawanDataTable.Columns.Add("password", typeof(string));

                foreach (DataRow row in karyawanDataTable.Rows)
                {
                    int karyawanId = Convert.ToInt32(row["id_karyawan"]);
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
                conn.Close();
                dataGridViewKaryawan.DataSource = karyawanDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from the 'karyawan' table: " + ex.Message);
            }
        }
        private void LoadDataPresensi()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT presensi.id_presensi, karyawan.nama_karyawan, jadwal.acara, presensi.keterangan " +
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
        //KARYAWAN
        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand insertKaryawanCmd = new MySqlCommand("INSERT INTO karyawan (nama_karyawan, jabatan) VALUES (@nama, @jabatan); SELECT LAST_INSERT_ID();", conn, transaction);
                        insertKaryawanCmd.Parameters.AddWithValue("@nama", txtNamaKaryawan.Text);
                        insertKaryawanCmd.Parameters.AddWithValue("@jabatan", txtJabatan.Text);

                        int karyawanId = Convert.ToInt32(insertKaryawanCmd.ExecuteScalar());

                        string username = txtUsername.Text;
                        string password = txtPassword.Text;

                        MySqlCommand insertLoginCmd = new MySqlCommand("INSERT INTO login (username, password, `level`, id_karyawan) VALUES (@username, @password, @level, @id_karyawan);", conn, transaction);
                        insertLoginCmd.Parameters.AddWithValue("@username", username);
                        insertLoginCmd.Parameters.AddWithValue("@password", password);
                        insertLoginCmd.Parameters.AddWithValue("@level", GetLevelFromJabatan(txtJabatan.Text));
                        insertLoginCmd.Parameters.AddWithValue("@id_karyawan", karyawanId);
                        insertLoginCmd.ExecuteNonQuery();

                        transaction.Commit();

                        conn.Close();
                        LoadDataKaryawan();
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
                MessageBox.Show("Error adding employee: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand updateKaryawanCmd = new MySqlCommand("UPDATE karyawan SET nama_karyawan = @nama, jabatan = @jabatan WHERE id_karyawan = @id", conn, transaction);
                        updateKaryawanCmd.Parameters.AddWithValue("@nama", txtNamaKaryawan.Text);
                        updateKaryawanCmd.Parameters.AddWithValue("@jabatan", txtJabatan.Text);
                        updateKaryawanCmd.Parameters.AddWithValue("@id", GetSelectedKaryawanId()); 
                        updateKaryawanCmd.ExecuteNonQuery();

                        MySqlCommand updateLoginCmd = new MySqlCommand("UPDATE login SET `level` = @level WHERE id_karyawan = @id_karyawan", conn, transaction);
                        updateLoginCmd.Parameters.AddWithValue("@level", GetLevelFromJabatan(txtJabatan.Text));
                        updateLoginCmd.Parameters.AddWithValue("@id_karyawan", GetSelectedKaryawanId()); 
                        updateLoginCmd.ExecuteNonQuery();

                        transaction.Commit();
                        conn.Close();
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
                MessageBox.Show("Error updating employee: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                LoadDataKaryawan();
            }
        }
        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int selectedKaryawanId = GetSelectedKaryawanId();

                        if (selectedKaryawanId != -1)
                        {
                            MySqlCommand deleteLoginCmd = new MySqlCommand("DELETE FROM login WHERE id_karyawan = @id_karyawan", conn, transaction);
                            deleteLoginCmd.Parameters.AddWithValue("@id_karyawan", selectedKaryawanId);
                            deleteLoginCmd.ExecuteNonQuery();

                            MySqlCommand deleteKaryawanCmd = new MySqlCommand("DELETE FROM karyawan WHERE id_karyawan = @id", conn, transaction);
                            deleteKaryawanCmd.Parameters.AddWithValue("@id", selectedKaryawanId);
                            deleteKaryawanCmd.ExecuteNonQuery();

                            transaction.Commit();
                            conn.Close();
                            LoadData();
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
                MessageBox.Show("Error deleting employee: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                LoadDataKaryawan();
            }
        }
        private string GetLevelFromJabatan(string jabatan)
        {
            if (jabatan.ToLower() == "admin")
            {
                return "admin";
            }
            else if (jabatan.ToLower() == "operator")
            {
                return "operator";
            }
            else
            {
                return "user";
            }
        }
        private int GetSelectedKaryawanId()
        {
            if (dataGridViewKaryawan.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridViewKaryawan.SelectedRows[0].Cells["id_karyawan"].Value);
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
                return -1;
            }
        }
        //JADWAL
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
        //PRESENSI
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
                        string selectedAcara = ComboBoxNamaAcara.SelectedItem?.ToString(); // Menambahkan pemilihan acara

                        if (!string.IsNullOrEmpty(selectedKaryawanNama) && !string.IsNullOrEmpty(status) && !string.IsNullOrEmpty(selectedAcara))
                        {
                            // Check if the selected employee's name exists in the 'karyawan' table
                            MySqlCommand checkKaryawanCmd = new MySqlCommand("SELECT id_karyawan FROM karyawan WHERE nama_karyawan = @nama_karyawan", conn, transaction);
                            checkKaryawanCmd.Parameters.AddWithValue("@nama_karyawan", selectedKaryawanNama);

                            object result = checkKaryawanCmd.ExecuteScalar();

                            if (result != null)
                            {
                                int selectedKaryawanId = Convert.ToInt32(result);

                                // Check if the selected event name exists in the 'jadwal' table
                                MySqlCommand checkEventCmd = new MySqlCommand("SELECT id_jadwal FROM jadwal WHERE acara = @acara", conn, transaction);
                                checkEventCmd.Parameters.AddWithValue("@acara", selectedAcara);

                                result = checkEventCmd.ExecuteScalar();

                                if (result != null)
                                {
                                    int selectedJadwalId = Convert.ToInt32(result);

                                    // Insert attendance record into the 'presensi' table
                                    MySqlCommand tambahPresensiCmd = new MySqlCommand("INSERT INTO presensi (id_karyawan, id_jadwal, keterangan) VALUES (@id_karyawan, @id_jadwal, @keterangan)", conn, transaction);
                                    tambahPresensiCmd.Parameters.AddWithValue("@id_karyawan", selectedKaryawanId);
                                    tambahPresensiCmd.Parameters.AddWithValue("@id_jadwal", selectedJadwalId);
                                    tambahPresensiCmd.Parameters.AddWithValue("@keterangan", status);
                                    tambahPresensiCmd.ExecuteNonQuery();

                                    transaction.Commit();

                                    MessageBox.Show("Presensi berhasil ditambahkan");
                                }
                                else
                                {
                                    MessageBox.Show("Nama acara tidak ditemukan");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nama karyawan tidak ditemukan");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pilih karyawan, status presensi, dan acara terlebih dahulu");
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
                        int selectedPresensiId = GetSelectedPresensiId(); // Get the selected attendance ID

                        if (selectedPresensiId != -1)
                        {
                            string selectedKaryawanNama = ComboBoxPresensiKaryawan.SelectedItem?.ToString();
                            string status = ComboBoxStatus.SelectedItem?.ToString();
                            string selectedAcara = ComboBoxNamaAcara.SelectedItem?.ToString(); // Menambahkan pemilihan acara

                            if (!string.IsNullOrEmpty(selectedKaryawanNama) && !string.IsNullOrEmpty(status) && !string.IsNullOrEmpty(selectedAcara))
                            {
                                // Check if the selected employee's name exists in the 'karyawan' table
                                MySqlCommand checkKaryawanCmd = new MySqlCommand("SELECT id_karyawan FROM karyawan WHERE nama_karyawan = @nama_karyawan", conn, transaction);
                                checkKaryawanCmd.Parameters.AddWithValue("@nama_karyawan", selectedKaryawanNama);

                                object result = checkKaryawanCmd.ExecuteScalar();

                                if (result != null)
                                {
                                    int selectedKaryawanId = Convert.ToInt32(result);

                                    // Check if the selected event name exists in the 'jadwal' table
                                    MySqlCommand checkEventCmd = new MySqlCommand("SELECT id_jadwal FROM jadwal WHERE acara = @acara", conn, transaction);
                                    checkEventCmd.Parameters.AddWithValue("@acara", selectedAcara);

                                    result = checkEventCmd.ExecuteScalar();

                                    if (result != null)
                                    {
                                        int selectedJadwalId = Convert.ToInt32(result);

                                        // Update the selected attendance record in the 'presensi' table
                                        MySqlCommand updatePresensiCmd = new MySqlCommand("UPDATE presensi SET id_karyawan = @id_karyawan, id_jadwal = @id_jadwal, keterangan = @keterangan WHERE id_presensi = @id_presensi", conn, transaction);
                                        updatePresensiCmd.Parameters.AddWithValue("@id_karyawan", selectedKaryawanId);
                                        updatePresensiCmd.Parameters.AddWithValue("@id_jadwal", selectedJadwalId);
                                        updatePresensiCmd.Parameters.AddWithValue("@keterangan", status);
                                        updatePresensiCmd.Parameters.AddWithValue("@id_presensi", selectedPresensiId);
                                        updatePresensiCmd.ExecuteNonQuery();

                                        transaction.Commit();

                                        MessageBox.Show("Presensi berhasil diubah");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Nama acara tidak ditemukan");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Nama karyawan tidak ditemukan");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Pilih karyawan, status presensi, dan acara terlebih dahulu");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pilih presensi terlebih dahulu");
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
                        int selectedPresensiId = GetSelectedPresensiId(); // Get the selected attendance ID

                        if (selectedPresensiId != -1)
                        {
                            // Delete the selected attendance record from the 'presensi' table
                            MySqlCommand deletePresensiCmd = new MySqlCommand("DELETE FROM presensi WHERE id_presensi = @id_presensi", conn, transaction);
                            deletePresensiCmd.Parameters.AddWithValue("@id_presensi", selectedPresensiId);
                            deletePresensiCmd.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Presensi berhasil dihapus");
                        }
                        else
                        {
                            MessageBox.Show("Pilih presensi terlebih dahulu");
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
        private void btnCetak_Click(object sender, EventArgs e)
        {
            try
            {
                // Display a SaveFileDialog to choose the location to save the CSV file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Save CSV File";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    // Open a StreamWriter to write data to the chosen CSV file
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Write header row for each DataGridView
                        WriteCsvHeader(dataGridViewKaryawan, sw);
                        WriteCsvHeader(dataGridViewPresensi, sw);
                        WriteCsvHeader(dataGridViewJadwal, sw);

                        // Write data rows for each DataGridView
                        WriteCsvData(dataGridViewKaryawan, sw);
                        WriteCsvData(dataGridViewPresensi, sw);
                        WriteCsvData(dataGridViewJadwal, sw);
                    }

                    MessageBox.Show("CSV file successfully saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to CSV: " + ex.Message);
            }
        }
        private void WriteCsvHeader(DataGridView dataGridView, StreamWriter sw)
        {
            // Write header row
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                sw.Write(column.HeaderText + ",");
            }
            sw.WriteLine();
        }
        private void WriteCsvData(DataGridView dataGridView, StreamWriter sw)
        {
            // Write data rows
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Check for null values before accessing cell.Value
                    if (cell.Value != null)
                    {
                        sw.Write(cell.Value.ToString() + ",");
                    }
                    else
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();
            }
        }
        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }
    }
}