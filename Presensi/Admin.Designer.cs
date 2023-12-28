namespace Presensi
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.dataGridViewKaryawan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewPresensi = new System.Windows.Forms.DataGridView();
            this.btnHapusPresensi = new System.Windows.Forms.Button();
            this.btnUbahPresensi = new System.Windows.Forms.Button();
            this.btnTambahPresensi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNamaKaryawan = new System.Windows.Forms.TextBox();
            this.txtJabatan = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.dataGridViewJadwal = new System.Windows.Forms.DataGridView();
            this.btnHapusJadwal = new System.Windows.Forms.Button();
            this.btnUbahJadwal = new System.Windows.Forms.Button();
            this.btnTambahJadwal = new System.Windows.Forms.Button();
            this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerJamMasuk = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerJamSelesai = new System.Windows.Forms.DateTimePicker();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKaryawan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(384, 218);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 10;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(303, 218);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Ubah";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(222, 218);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 8;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.Location = new System.Drawing.Point(1134, 12);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(75, 23);
            this.btnKeluar.TabIndex = 6;
            this.btnKeluar.Text = "Keluar";
            this.btnKeluar.UseVisualStyleBackColor = true;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // dataGridViewKaryawan
            // 
            this.dataGridViewKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKaryawan.Location = new System.Drawing.Point(221, 59);
            this.dataGridViewKaryawan.Name = "dataGridViewKaryawan";
            this.dataGridViewKaryawan.RowHeadersWidth = 51;
            this.dataGridViewKaryawan.RowTemplate.Height = 24;
            this.dataGridViewKaryawan.Size = new System.Drawing.Size(473, 153);
            this.dataGridViewKaryawan.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nama Karyawan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Jabatan";
            // 
            // dataGridViewPresensi
            // 
            this.dataGridViewPresensi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresensi.Location = new System.Drawing.Point(707, 59);
            this.dataGridViewPresensi.Name = "dataGridViewPresensi";
            this.dataGridViewPresensi.RowHeadersWidth = 51;
            this.dataGridViewPresensi.RowTemplate.Height = 24;
            this.dataGridViewPresensi.Size = new System.Drawing.Size(473, 153);
            this.dataGridViewPresensi.TabIndex = 19;
            // 
            // btnHapusPresensi
            // 
            this.btnHapusPresensi.Location = new System.Drawing.Point(869, 218);
            this.btnHapusPresensi.Name = "btnHapusPresensi";
            this.btnHapusPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnHapusPresensi.TabIndex = 22;
            this.btnHapusPresensi.Text = "Hapus";
            this.btnHapusPresensi.UseVisualStyleBackColor = true;
            this.btnHapusPresensi.Click += new System.EventHandler(this.btnHapusPresensi_Click);
            // 
            // btnUbahPresensi
            // 
            this.btnUbahPresensi.Location = new System.Drawing.Point(788, 218);
            this.btnUbahPresensi.Name = "btnUbahPresensi";
            this.btnUbahPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnUbahPresensi.TabIndex = 21;
            this.btnUbahPresensi.Text = "Ubah";
            this.btnUbahPresensi.UseVisualStyleBackColor = true;
            this.btnUbahPresensi.Click += new System.EventHandler(this.btnUbahPresensi_Click);
            // 
            // btnTambahPresensi
            // 
            this.btnTambahPresensi.Location = new System.Drawing.Point(707, 218);
            this.btnTambahPresensi.Name = "btnTambahPresensi";
            this.btnTambahPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnTambahPresensi.TabIndex = 20;
            this.btnTambahPresensi.Text = "Tambah";
            this.btnTambahPresensi.UseVisualStyleBackColor = true;
            this.btnTambahPresensi.Click += new System.EventHandler(this.btnTambahPresensi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Data Karyawan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(704, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Data Presensi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Password";
            // 
            // txtNamaKaryawan
            // 
            this.txtNamaKaryawan.Location = new System.Drawing.Point(6, 59);
            this.txtNamaKaryawan.Name = "txtNamaKaryawan";
            this.txtNamaKaryawan.Size = new System.Drawing.Size(209, 22);
            this.txtNamaKaryawan.TabIndex = 29;
            // 
            // txtJabatan
            // 
            this.txtJabatan.Location = new System.Drawing.Point(6, 103);
            this.txtJabatan.Name = "txtJabatan";
            this.txtJabatan.Size = new System.Drawing.Size(209, 22);
            this.txtJabatan.TabIndex = 30;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(6, 147);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(209, 22);
            this.txtUsername.TabIndex = 31;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(209, 22);
            this.txtPassword.TabIndex = 32;
            // 
            // dataGridViewJadwal
            // 
            this.dataGridViewJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJadwal.Location = new System.Drawing.Point(221, 271);
            this.dataGridViewJadwal.Name = "dataGridViewJadwal";
            this.dataGridViewJadwal.RowHeadersWidth = 51;
            this.dataGridViewJadwal.RowTemplate.Height = 24;
            this.dataGridViewJadwal.Size = new System.Drawing.Size(473, 153);
            this.dataGridViewJadwal.TabIndex = 33;
            // 
            // btnHapusJadwal
            // 
            this.btnHapusJadwal.Location = new System.Drawing.Point(384, 430);
            this.btnHapusJadwal.Name = "btnHapusJadwal";
            this.btnHapusJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnHapusJadwal.TabIndex = 36;
            this.btnHapusJadwal.Text = "Hapus";
            this.btnHapusJadwal.UseVisualStyleBackColor = true;
            this.btnHapusJadwal.Click += new System.EventHandler(this.btnHapusJadwal_Click);
            // 
            // btnUbahJadwal
            // 
            this.btnUbahJadwal.Location = new System.Drawing.Point(303, 430);
            this.btnUbahJadwal.Name = "btnUbahJadwal";
            this.btnUbahJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnUbahJadwal.TabIndex = 35;
            this.btnUbahJadwal.Text = "Ubah";
            this.btnUbahJadwal.UseVisualStyleBackColor = true;
            this.btnUbahJadwal.Click += new System.EventHandler(this.btnUbahJadwal_Click);
            // 
            // btnTambahJadwal
            // 
            this.btnTambahJadwal.Location = new System.Drawing.Point(222, 430);
            this.btnTambahJadwal.Name = "btnTambahJadwal";
            this.btnTambahJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnTambahJadwal.TabIndex = 34;
            this.btnTambahJadwal.Text = "Tambah";
            this.btnTambahJadwal.UseVisualStyleBackColor = true;
            this.btnTambahJadwal.Click += new System.EventHandler(this.btnTambahJadwal_Click);
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(6, 271);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(209, 22);
            this.dateTimePickerTanggal.TabIndex = 37;
            // 
            // dateTimePickerJamMasuk
            // 
            this.dateTimePickerJamMasuk.Location = new System.Drawing.Point(6, 320);
            this.dateTimePickerJamMasuk.Name = "dateTimePickerJamMasuk";
            this.dateTimePickerJamMasuk.Size = new System.Drawing.Size(209, 22);
            this.dateTimePickerJamMasuk.TabIndex = 38;
            // 
            // dateTimePickerJamSelesai
            // 
            this.dateTimePickerJamSelesai.Location = new System.Drawing.Point(6, 367);
            this.dateTimePickerJamSelesai.Name = "dateTimePickerJamSelesai";
            this.dateTimePickerJamSelesai.Size = new System.Drawing.Size(209, 22);
            this.dateTimePickerJamSelesai.TabIndex = 39;
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(6, 413);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(210, 22);
            this.txtKeterangan.TabIndex = 40;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 504);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.dateTimePickerJamSelesai);
            this.Controls.Add(this.dateTimePickerJamMasuk);
            this.Controls.Add(this.dateTimePickerTanggal);
            this.Controls.Add(this.btnHapusJadwal);
            this.Controls.Add(this.btnUbahJadwal);
            this.Controls.Add(this.btnTambahJadwal);
            this.Controls.Add(this.dataGridViewJadwal);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtJabatan);
            this.Controls.Add(this.txtNamaKaryawan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHapusPresensi);
            this.Controls.Add(this.btnUbahPresensi);
            this.Controls.Add(this.btnTambahPresensi);
            this.Controls.Add(this.dataGridViewPresensi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewKaryawan);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnKeluar);
            this.Name = "Admin";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKaryawan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.DataGridView dataGridViewKaryawan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewPresensi;
        private System.Windows.Forms.Button btnHapusPresensi;
        private System.Windows.Forms.Button btnUbahPresensi;
        private System.Windows.Forms.Button btnTambahPresensi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNamaKaryawan;
        private System.Windows.Forms.TextBox txtJabatan;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.DataGridView dataGridViewJadwal;
        private System.Windows.Forms.Button btnHapusJadwal;
        private System.Windows.Forms.Button btnUbahJadwal;
        private System.Windows.Forms.Button btnTambahJadwal;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
        private System.Windows.Forms.DateTimePicker dateTimePickerJamMasuk;
        private System.Windows.Forms.DateTimePicker dateTimePickerJamSelesai;
        private System.Windows.Forms.TextBox txtKeterangan;
    }
}