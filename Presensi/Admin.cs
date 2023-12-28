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
                        // Insert into 'karyawan' table
                        MySqlCommand insertKaryawanCmd = new MySqlCommand("INSERT INTO karyawan (nama_karyawan, jabatan) VALUES (@nama, @jabatan); SELECT LAST_INSERT_ID();", conn, transaction);
                        insertKaryawanCmd.Parameters.AddWithValue("@nama", txtNamaKaryawan.Text);
                        insertKaryawanCmd.Parameters.AddWithValue("@jabatan", txtJabatan.Text);

                        int karyawanId = Convert.ToInt32(insertKaryawanCmd.ExecuteScalar());

                        // Use values from txtUsername and txtPassword
                        string username = txtUsername.Text;
                        string password = txtPassword.Text;

                        // Insert into 'login' table with provided username and password
                        MySqlCommand insertLoginCmd = new MySqlCommand("INSERT INTO login (username, password, `level`, id_karyawan) VALUES (@username, @password, @level, @id_karyawan);", conn, transaction);
                        insertLoginCmd.Parameters.AddWithValue("@username", username);
                        insertLoginCmd.Parameters.AddWithValue("@password", password);
                        insertLoginCmd.Parameters.AddWithValue("@level", GetLevelFromJabatan(txtJabatan.Text));
                        insertLoginCmd.Parameters.AddWithValue("@id_karyawan", karyawanId);
                        insertLoginCmd.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();

                        // Close the database connection
                        conn.Close();

                        // Refresh the data in the DataGridView
                        LoadDataKaryawan();
                    }
                    catch (Exception ex)
                    {
                        // An error occurred, rollback the transaction
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
                // Always close the database connection in a finally block
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
                        updateKaryawanCmd.Parameters.AddWithValue("@id", GetSelectedKaryawanId()); // You need to implement this method
                        updateKaryawanCmd.ExecuteNonQuery();

                        MySqlCommand updateLoginCmd = new MySqlCommand("UPDATE login SET `level` = @level WHERE id_karyawan = @id_karyawan", conn, transaction);
                        updateLoginCmd.Parameters.AddWithValue("@level", GetLevelFromJabatan(txtJabatan.Text));
                        updateLoginCmd.Parameters.AddWithValue("@id_karyawan", GetSelectedKaryawanId()); // You need to implement this method
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
                            deleteLoginCmd.Parameters.AddWithValue("@karyawanId", selectedKaryawanId);
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

                if(selectedKaryawanId != -1){
                    conn.Open();

                    MySqlCommand tambahPresensiCmd =  new MySqlCommand("INSERT INTO presensi (id_karyawan) VALUES (@id_karyawan)", conn);
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
            catch(Exception ex)
            {
                MessageBox.Show("Error mebambahkan presesni" + ex.Message);
            }
        }

        private void btnUbahPresensi_Click(object sender, EventArgs e)
        {

        }

        private void btnHapusPresensi_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedPresensiId = GetSelectedPresensiId(); // Anda perlu mengimplementasikan metode ini

                if (selectedPresensiId != -1)
                {
                    conn.Open();

                    MySqlCommand hapusPresensiCmd = new MySqlCommand("DELETE FROM presensi WHERE id_presensi = @id", conn);
                    hapusPresensiCmd.Parameters.AddWithValue("@id", selectedPresensiId);

                    hapusPresensiCmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Presensi berhasil dihapus.");
                    LoadDataPresensi(); // Refresh data presensi setelah penghapusan
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

        private void btnTambahJadwal_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                int selectedKaryawanId = GetSelectedKaryawanId();

                if (selectedKaryawanId != -1)
                {
                    MySqlCommand tambahJadwalCmd = new MySqlCommand("INSERT INTO jadwal (tanggal, jam_masuk, jam_selesai, keterangan, id_karyawan) VALUES (@tanggal, @jam_masuk, @jam_selesai, @keterangan, @id_karyawan)", conn);
                    tambahJadwalCmd.Parameters.AddWithValue("@tanggal", dateTimePickerTanggal.Value.ToString("yyyy-MM-dd"));
                    tambahJadwalCmd.Parameters.AddWithValue("@jam_masuk", dateTimePickerJamMasuk.Value.ToString("HH:mm:ss"));
                    tambahJadwalCmd.Parameters.AddWithValue("@jam_selesai", dateTimePickerJamSelesai.Value.ToString("HH:mm:ss"));
                    tambahJadwalCmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text);
                    tambahJadwalCmd.Parameters.AddWithValue("@id_karyawan", selectedKaryawanId);

                    tambahJadwalCmd.ExecuteNonQuery();

                    MessageBox.Show("Jadwal acara berhasil ditambahkan");
                    LoadDataJadwal();
                }
                else
                {
                    MessageBox.Show("Pilih karyawan terlebih dahulu");
                }
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

                MySqlCommand updateJadwalCmd = new MySqlCommand("UPDATE jadwal SET tanggal = @tanggal, jam_masuk = @jam_masuk, jam_selesai = @jam_selesai, keterangan = @keterangan, id_karyawan = @id_karyawan WHERE id_jadwal = @id_jadwal", conn);
                updateJadwalCmd.Parameters.AddWithValue("@tanggal", dateTimePickerTanggal.Value.ToString("yyyy-MM-dd"));
                updateJadwalCmd.Parameters.AddWithValue("@jam_masuk", dateTimePickerJamMasuk.Value.ToString("HH:mm:ss"));
                updateJadwalCmd.Parameters.AddWithValue("@jam_selesai", dateTimePickerJamSelesai.Value.ToString("HH:mm:ss"));
                updateJadwalCmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text);
                updateJadwalCmd.Parameters.AddWithValue("@id_karyawan", GetSelectedKaryawanId()); // You need to implement this method
                updateJadwalCmd.Parameters.AddWithValue("@id_jadwal", GetSelectedJadwalId()); // You need to implement this method

                updateJadwalCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Jadwal acara berhasil diubah");
                LoadDataJadwal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mengubah jadwal acara: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnHapusJadwal_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                int selectedJadwalId = GetSelectedJadwalId(); // You need to implement this method

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
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
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
    }
}