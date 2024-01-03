namespace Presensi
{
    partial class Operator
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
            this.label12 = new System.Windows.Forms.Label();
            this.ComboBoxNamaAcara = new System.Windows.Forms.ComboBox();
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.ComboBoxPresensiKaryawan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHapusPresensi = new System.Windows.Forms.Button();
            this.btnUbahPresensi = new System.Windows.Forms.Button();
            this.btnTambahPresensi = new System.Windows.Forms.Button();
            this.dataGridViewPresensi = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewJadwal = new System.Windows.Forms.DataGridView();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(497, 336);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 16);
            this.label12.TabIndex = 75;
            this.label12.Text = "Acara";
            // 
            // ComboBoxNamaAcara
            // 
            this.ComboBoxNamaAcara.FormattingEnabled = true;
            this.ComboBoxNamaAcara.Location = new System.Drawing.Point(500, 355);
            this.ComboBoxNamaAcara.Name = "ComboBoxNamaAcara";
            this.ComboBoxNamaAcara.Size = new System.Drawing.Size(168, 24);
            this.ComboBoxNamaAcara.TabIndex = 74;
            this.ComboBoxNamaAcara.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNamaAcara_SelectedIndexChanged);
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(499, 309);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(168, 24);
            this.ComboBoxStatus.TabIndex = 73;
            this.ComboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // ComboBoxPresensiKaryawan
            // 
            this.ComboBoxPresensiKaryawan.FormattingEnabled = true;
            this.ComboBoxPresensiKaryawan.Location = new System.Drawing.Point(499, 265);
            this.ComboBoxPresensiKaryawan.Name = "ComboBoxPresensiKaryawan";
            this.ComboBoxPresensiKaryawan.Size = new System.Drawing.Size(168, 24);
            this.ComboBoxPresensiKaryawan.TabIndex = 72;
            this.ComboBoxPresensiKaryawan.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPresensiKaryawan_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(496, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 71;
            this.label9.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 69;
            this.label5.Text = "Nama Karyawan";
            // 
            // btnHapusPresensi
            // 
            this.btnHapusPresensi.Location = new System.Drawing.Point(662, 385);
            this.btnHapusPresensi.Name = "btnHapusPresensi";
            this.btnHapusPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnHapusPresensi.TabIndex = 68;
            this.btnHapusPresensi.Text = "Hapus";
            this.btnHapusPresensi.UseVisualStyleBackColor = true;
            this.btnHapusPresensi.Click += new System.EventHandler(this.btnHapusPresensi_Click);
            // 
            // btnUbahPresensi
            // 
            this.btnUbahPresensi.Location = new System.Drawing.Point(581, 385);
            this.btnUbahPresensi.Name = "btnUbahPresensi";
            this.btnUbahPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnUbahPresensi.TabIndex = 67;
            this.btnUbahPresensi.Text = "Ubah";
            this.btnUbahPresensi.UseVisualStyleBackColor = true;
            this.btnUbahPresensi.Click += new System.EventHandler(this.btnUbahPresensi_Click);
            // 
            // btnTambahPresensi
            // 
            this.btnTambahPresensi.Location = new System.Drawing.Point(500, 385);
            this.btnTambahPresensi.Name = "btnTambahPresensi";
            this.btnTambahPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnTambahPresensi.TabIndex = 66;
            this.btnTambahPresensi.Text = "Tambah";
            this.btnTambahPresensi.UseVisualStyleBackColor = true;
            this.btnTambahPresensi.Click += new System.EventHandler(this.btnTambahPresensi_Click);
            // 
            // dataGridViewPresensi
            // 
            this.dataGridViewPresensi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresensi.Location = new System.Drawing.Point(12, 239);
            this.dataGridViewPresensi.Name = "dataGridViewPresensi";
            this.dataGridViewPresensi.RowHeadersWidth = 51;
            this.dataGridViewPresensi.RowTemplate.Height = 24;
            this.dataGridViewPresensi.Size = new System.Drawing.Size(472, 162);
            this.dataGridViewPresensi.TabIndex = 65;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 16);
            this.label11.TabIndex = 77;
            this.label11.Text = "Jadwal";
            // 
            // dataGridViewJadwal
            // 
            this.dataGridViewJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJadwal.Location = new System.Drawing.Point(12, 35);
            this.dataGridViewJadwal.Name = "dataGridViewJadwal";
            this.dataGridViewJadwal.RowHeadersWidth = 51;
            this.dataGridViewJadwal.RowTemplate.Height = 24;
            this.dataGridViewJadwal.Size = new System.Drawing.Size(472, 162);
            this.dataGridViewJadwal.TabIndex = 76;
            // 
            // btnKeluar
            // 
            this.btnKeluar.Location = new System.Drawing.Point(662, 16);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(75, 23);
            this.btnKeluar.TabIndex = 78;
            this.btnKeluar.Text = "Keluar";
            this.btnKeluar.UseVisualStyleBackColor = true;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 79;
            this.label1.Text = "Presensi";
            // 
            // Operator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(835, 438);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridViewJadwal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ComboBoxNamaAcara);
            this.Controls.Add(this.ComboBoxStatus);
            this.Controls.Add(this.ComboBoxPresensiKaryawan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHapusPresensi);
            this.Controls.Add(this.btnUbahPresensi);
            this.Controls.Add(this.btnTambahPresensi);
            this.Controls.Add(this.dataGridViewPresensi);
            this.Name = "Operator";
            this.Text = "Operator";
            this.Load += new System.EventHandler(this.Operator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ComboBoxNamaAcara;
        private System.Windows.Forms.ComboBox ComboBoxStatus;
        private System.Windows.Forms.ComboBox ComboBoxPresensiKaryawan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHapusPresensi;
        private System.Windows.Forms.Button btnUbahPresensi;
        private System.Windows.Forms.Button btnTambahPresensi;
        private System.Windows.Forms.DataGridView dataGridViewPresensi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewJadwal;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Label label1;
    }
}