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
            this.dataGridViewPresensi = new System.Windows.Forms.DataGridView();
            this.btnHapusPresensi = new System.Windows.Forms.Button();
            this.btnUbahPresensi = new System.Windows.Forms.Button();
            this.btnTambahPresensi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNamaKaryawan = new System.Windows.Forms.TextBox();
            this.txtJabatan = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.dataGridViewJadwal = new System.Windows.Forms.DataGridView();
            this.btnHapusJadwal = new System.Windows.Forms.Button();
            this.btnUbahJadwal = new System.Windows.Forms.Button();
            this.btnTambahJadwal = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
            this.txtJamMasuk = new System.Windows.Forms.TextBox();
            this.txtJamSelesai = new System.Windows.Forms.TextBox();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCetak = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKaryawan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(346, 223);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 10;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(265, 223);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Ubah";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(184, 223);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 8;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.Location = new System.Drawing.Point(1059, 12);
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
            this.dataGridViewKaryawan.Location = new System.Drawing.Point(183, 64);
            this.dataGridViewKaryawan.Name = "dataGridViewKaryawan";
            this.dataGridViewKaryawan.RowHeadersWidth = 51;
            this.dataGridViewKaryawan.RowTemplate.Height = 24;
            this.dataGridViewKaryawan.Size = new System.Drawing.Size(473, 153);
            this.dataGridViewKaryawan.TabIndex = 12;
            // 
            // dataGridViewPresensi
            // 
            this.dataGridViewPresensi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresensi.Location = new System.Drawing.Point(662, 64);
            this.dataGridViewPresensi.Name = "dataGridViewPresensi";
            this.dataGridViewPresensi.RowHeadersWidth = 51;
            this.dataGridViewPresensi.RowTemplate.Height = 24;
            this.dataGridViewPresensi.Size = new System.Drawing.Size(472, 153);
            this.dataGridViewPresensi.TabIndex = 19;
            // 
            // btnHapusPresensi
            // 
            this.btnHapusPresensi.Location = new System.Drawing.Point(824, 223);
            this.btnHapusPresensi.Name = "btnHapusPresensi";
            this.btnHapusPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnHapusPresensi.TabIndex = 22;
            this.btnHapusPresensi.Text = "Hapus";
            this.btnHapusPresensi.UseVisualStyleBackColor = true;
            this.btnHapusPresensi.Click += new System.EventHandler(this.btnHapusPresensi_Click);
            // 
            // btnUbahPresensi
            // 
            this.btnUbahPresensi.Location = new System.Drawing.Point(743, 223);
            this.btnUbahPresensi.Name = "btnUbahPresensi";
            this.btnUbahPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnUbahPresensi.TabIndex = 21;
            this.btnUbahPresensi.Text = "Ubah";
            this.btnUbahPresensi.UseVisualStyleBackColor = true;
            this.btnUbahPresensi.Click += new System.EventHandler(this.btnUbahPresensi_Click);
            // 
            // btnTambahPresensi
            // 
            this.btnTambahPresensi.Location = new System.Drawing.Point(662, 223);
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
            this.label4.Location = new System.Drawing.Point(181, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Data Karyawan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(659, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Data Presensi";
            // 
            // txtNamaKaryawan
            // 
            this.txtNamaKaryawan.Location = new System.Drawing.Point(9, 64);
            this.txtNamaKaryawan.Name = "txtNamaKaryawan";
            this.txtNamaKaryawan.Size = new System.Drawing.Size(168, 22);
            this.txtNamaKaryawan.TabIndex = 29;
            // 
            // txtJabatan
            // 
            this.txtJabatan.Location = new System.Drawing.Point(9, 108);
            this.txtJabatan.Name = "txtJabatan";
            this.txtJabatan.Size = new System.Drawing.Size(168, 22);
            this.txtJabatan.TabIndex = 30;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(9, 152);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(168, 22);
            this.txtUsername.TabIndex = 31;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(9, 195);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(168, 22);
            this.txtPassword.TabIndex = 32;
            // 
            // dataGridViewJadwal
            // 
            this.dataGridViewJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJadwal.Location = new System.Drawing.Point(184, 289);
            this.dataGridViewJadwal.Name = "dataGridViewJadwal";
            this.dataGridViewJadwal.RowHeadersWidth = 51;
            this.dataGridViewJadwal.RowTemplate.Height = 24;
            this.dataGridViewJadwal.Size = new System.Drawing.Size(958, 162);
            this.dataGridViewJadwal.TabIndex = 33;
            // 
            // btnHapusJadwal
            // 
            this.btnHapusJadwal.Location = new System.Drawing.Point(346, 457);
            this.btnHapusJadwal.Name = "btnHapusJadwal";
            this.btnHapusJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnHapusJadwal.TabIndex = 36;
            this.btnHapusJadwal.Text = "Hapus";
            this.btnHapusJadwal.UseVisualStyleBackColor = true;
            this.btnHapusJadwal.Click += new System.EventHandler(this.btnHapusJadwal_Click);
            // 
            // btnUbahJadwal
            // 
            this.btnUbahJadwal.Location = new System.Drawing.Point(265, 457);
            this.btnUbahJadwal.Name = "btnUbahJadwal";
            this.btnUbahJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnUbahJadwal.TabIndex = 35;
            this.btnUbahJadwal.Text = "Ubah";
            this.btnUbahJadwal.UseVisualStyleBackColor = true;
            this.btnUbahJadwal.Click += new System.EventHandler(this.btnUbahJadwal_Click);
            // 
            // btnTambahJadwal
            // 
            this.btnTambahJadwal.Location = new System.Drawing.Point(184, 457);
            this.btnTambahJadwal.Name = "btnTambahJadwal";
            this.btnTambahJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnTambahJadwal.TabIndex = 34;
            this.btnTambahJadwal.Text = "Tambah";
            this.btnTambahJadwal.UseVisualStyleBackColor = true;
            this.btnTambahJadwal.Click += new System.EventHandler(this.btnTambahJadwal_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "Tanggal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 42;
            this.label8.Text = "Jam Masuk";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 43;
            this.label9.Text = "Jam Keluar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 44;
            this.label10.Text = "Keterangan";
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(9, 289);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(168, 22);
            this.dateTimePickerTanggal.TabIndex = 45;
            // 
            // txtJamMasuk
            // 
            this.txtJamMasuk.Location = new System.Drawing.Point(9, 339);
            this.txtJamMasuk.Name = "txtJamMasuk";
            this.txtJamMasuk.Size = new System.Drawing.Size(168, 22);
            this.txtJamMasuk.TabIndex = 46;
            // 
            // txtJamSelesai
            // 
            this.txtJamSelesai.Location = new System.Drawing.Point(9, 385);
            this.txtJamSelesai.Name = "txtJamSelesai";
            this.txtJamSelesai.Size = new System.Drawing.Size(168, 22);
            this.txtJamSelesai.TabIndex = 47;
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(9, 429);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(168, 22);
            this.txtKeterangan.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "Nama Karyawan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "Jabatan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 51;
            this.label3.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 52;
            this.label6.Text = "Username";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(181, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 16);
            this.label11.TabIndex = 53;
            this.label11.Text = "Jadwal";
            // 
            // btnCetak
            // 
            this.btnCetak.Location = new System.Drawing.Point(1067, 457);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(75, 23);
            this.btnCetak.TabIndex = 54;
            this.btnCetak.Text = "Export";
            this.btnCetak.UseVisualStyleBackColor = true;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1221, 504);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.txtJamSelesai);
            this.Controls.Add(this.txtJamMasuk);
            this.Controls.Add(this.dateTimePickerTanggal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnHapusJadwal);
            this.Controls.Add(this.btnUbahJadwal);
            this.Controls.Add(this.btnTambahJadwal);
            this.Controls.Add(this.dataGridViewJadwal);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtJabatan);
            this.Controls.Add(this.txtNamaKaryawan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHapusPresensi);
            this.Controls.Add(this.btnUbahPresensi);
            this.Controls.Add(this.btnTambahPresensi);
            this.Controls.Add(this.dataGridViewPresensi);
            this.Controls.Add(this.dataGridViewKaryawan);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnKeluar);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
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
        private System.Windows.Forms.DataGridView dataGridViewPresensi;
        private System.Windows.Forms.Button btnHapusPresensi;
        private System.Windows.Forms.Button btnUbahPresensi;
        private System.Windows.Forms.Button btnTambahPresensi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNamaKaryawan;
        private System.Windows.Forms.TextBox txtJabatan;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.DataGridView dataGridViewJadwal;
        private System.Windows.Forms.Button btnHapusJadwal;
        private System.Windows.Forms.Button btnUbahJadwal;
        private System.Windows.Forms.Button btnTambahJadwal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
        private System.Windows.Forms.TextBox txtJamMasuk;
        private System.Windows.Forms.TextBox txtJamSelesai;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCetak;
    }
}