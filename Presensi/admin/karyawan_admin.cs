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
    public partial class karyawan_admin : Form
    {
        readonly MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");
        private ComboBox ComboBoxPresensiKaryawan;
        public event EventHandler KaryawanDataChanged;
        public karyawan_admin()
        {
            InitializeComponent();
            LoadDataKaryawan();

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
                KaryawanDataChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from the 'karyawan' table: " + ex.Message);
            }
        }
        private void btnTambahKaryawan_Click(object sender, EventArgs e)
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
                        MessageBox.Show("Employee data added successfully");
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
        private void btnUbahKaryawan_Click(object sender, EventArgs e)
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
                            MySqlCommand updateKaryawanCmd = new MySqlCommand("UPDATE karyawan SET nama_karyawan = @nama, jabatan = @jabatan WHERE id_karyawan = @id", conn, transaction);
                            updateKaryawanCmd.Parameters.AddWithValue("@nama", txtNamaKaryawan.Text);
                            updateKaryawanCmd.Parameters.AddWithValue("@jabatan", txtJabatan.Text);
                            updateKaryawanCmd.Parameters.AddWithValue("@id", selectedKaryawanId);
                            updateKaryawanCmd.ExecuteNonQuery();

                            MySqlCommand updateLoginCmd = new MySqlCommand("UPDATE login SET username = @username, password = @password, `level` = @level WHERE id_karyawan = @id_karyawan", conn, transaction);
                            updateLoginCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            updateLoginCmd.Parameters.AddWithValue("@password", txtPassword.Text);
                            updateLoginCmd.Parameters.AddWithValue("@level", GetLevelFromJabatan(txtJabatan.Text));
                            updateLoginCmd.Parameters.AddWithValue("@id_karyawan", selectedKaryawanId);
                            updateLoginCmd.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Employee data has been successfully changed");
                            conn.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating employee: " + ex.Message);
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

        private void btnHapusKaryawan_Click(object sender, EventArgs e)
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
                            MessageBox.Show("Employee data has been successfully deleted");
                            conn.Close();
                            LoadDataKaryawan();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Export Data to CSV",
                    FileName = "karyawan_export.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    StringBuilder csvContent = new StringBuilder();
                    foreach (DataGridViewColumn column in dataGridViewKaryawan.Columns)
                    {
                        csvContent.Append(column.HeaderText + ",");
                    }
                    csvContent.AppendLine();
                    foreach (DataGridViewRow row in dataGridViewKaryawan.Rows)
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

        private void karyawan_admin_Load(object sender, EventArgs e)
        {

        }
    }
}
