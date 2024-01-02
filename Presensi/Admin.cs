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
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void LoadDataJadwal()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT id_jadwal, tanggal, jam_masuk, jam_selesai, keterangan FROM jadwal", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable jadwalDataTable = new DataTable();
                adapter.Fill(jadwalDataTable);

                dataGridViewJadwal.DataSource = jadwalDataTable;

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
        //KARYAWAN
        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
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
        //PRESENSI
        private void btnTambahPresensi_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedKaryawanId = GetSelectedKaryawanId();

                if (selectedKaryawanId != -1)
                {
                    conn.Open();

                    MySqlCommand tambahPresensiCmd = new MySqlCommand("INSERT INTO presensi (id_karyawan) VALUES (@id_karyawan)", conn);
                    tambahPresensiCmd.Parameters.AddWithValue("@id_karyawan", selectedKaryawanId);

                    tambahPresensiCmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Presesnsi berhasil ditambahkan");
                    LoadDataPresensi();
                }
                else
                {
                    MessageBox.Show("Pilih karyawan terlebih dahulu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mebambahkan presesni" + ex.Message);
            }
        }

        private void btnUbahPresensi_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedPresensiId = GetSelectedPresensiId();

                if (selectedPresensiId != -1)
                {
                    conn.Open();

                    MySqlCommand updatePresensiCmd = new MySqlCommand("UPDATE presensi SET waktu_presensi = @waktu_presensi WHERE id_presensi = @id_presensi", conn);
                    updatePresensiCmd.Parameters.AddWithValue("@waktu_presensi", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Update with your desired logic for updating time
                    updatePresensiCmd.Parameters.AddWithValue("@id_presensi", selectedPresensiId);

                    updatePresensiCmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Presensi berhasil diubah.");
                    LoadDataPresensi(); 
                }
                else
                {
                    MessageBox.Show("Pilih presensi terlebih dahulu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mengubah presensi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnHapusPresensi_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedPresensiId = GetSelectedPresensiId();

                if (selectedPresensiId != -1)
                {
                    conn.Open();

                    MySqlCommand hapusPresensiCmd = new MySqlCommand("DELETE FROM presensi WHERE id_presensi = @id", conn);
                    hapusPresensiCmd.Parameters.AddWithValue("@id", selectedPresensiId);

                    hapusPresensiCmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Presensi berhasil dihapus.");
                    LoadDataPresensi(); 
                }
                else
                {
                    MessageBox.Show("Pilih presensi terlebih dahulu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error menghapus presensi: " + ex.Message);
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

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }
        //JADWAL
        private void btnTambahJadwal_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                MySqlCommand tambahJadwalCmd = new MySqlCommand("INSERT INTO jadwal (tanggal, jam_masuk, jam_selesai, keterangan) VALUES (@tanggal, @jam_masuk, @jam_selesai, @keterangan)", conn);
                tambahJadwalCmd.Parameters.AddWithValue("@tanggal", dateTimePickerTanggal.Value.ToString("yyyy-MM-dd"));
                tambahJadwalCmd.Parameters.AddWithValue("@jam_masuk", txtJamMasuk.Text);
                tambahJadwalCmd.Parameters.AddWithValue("@jam_selesai", txtJamSelesai.Text);
                tambahJadwalCmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text);

                tambahJadwalCmd.ExecuteNonQuery();

                MessageBox.Show("Jadwal acara berhasil ditambahkan");
                LoadDataJadwal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error menambahkan jadwal acara: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void btnUbahJadwal_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                MySqlCommand updateJadwalCmd = new MySqlCommand("UPDATE jadwal SET tanggal = @tanggal, jam_masuk = @jam_masuk, jam_selesai = @jam_selesai, keterangan = @keterangan WHERE id_jadwal = @id_jadwal", conn);
                updateJadwalCmd.Parameters.AddWithValue("@tanggal", dateTimePickerTanggal.Value.ToString("yyyy-MM-dd"));
                updateJadwalCmd.Parameters.AddWithValue("@jam_masuk", txtJamMasuk);
                updateJadwalCmd.Parameters.AddWithValue("@jam_selesai", txtJamSelesai);
                updateJadwalCmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text);
                updateJadwalCmd.Parameters.AddWithValue("@id_jadwal", GetSelectedJadwalId());

                updateJadwalCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Jadwal acara berhasil diubah");
                LoadDataJadwal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mengubah jadwal acara: " + ex.Message);
            }
            conn.Close();
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
                    LoadDataJadwal();
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

    }
}