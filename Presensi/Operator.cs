﻿using MySql.Data.MySqlClient;
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
            LoadDataPresensi();
            LoadDataJadwal();
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
                        int selectedPresensiId = GetSelectedPresensiId();

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
        private void Operator_Load(object sender, EventArgs e)
        {

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
        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }
    }
}
