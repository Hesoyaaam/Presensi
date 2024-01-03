namespace Presensi.admin
{
    partial class jadwal_admin
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.txtAcara = new System.Windows.Forms.TextBox();
            this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHapusJadwal = new System.Windows.Forms.Button();
            this.btnUbahJadwal = new System.Windows.Forms.Button();
            this.btnTambahJadwal = new System.Windows.Forms.Button();
            this.dataGridViewJadwal = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 16);
            this.label8.TabIndex = 77;
            this.label8.Text = "Acara";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(87, 137);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(168, 22);
            this.txtKeterangan.TabIndex = 76;
            // 
            // txtAcara
            // 
            this.txtAcara.Location = new System.Drawing.Point(87, 48);
            this.txtAcara.Name = "txtAcara";
            this.txtAcara.Size = new System.Drawing.Size(168, 22);
            this.txtAcara.TabIndex = 75;
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(87, 95);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(168, 22);
            this.dateTimePickerTanggal.TabIndex = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 73;
            this.label10.Text = "Keterangan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 72;
            this.label7.Text = "Tanggal";
            // 
            // btnHapusJadwal
            // 
            this.btnHapusJadwal.Location = new System.Drawing.Point(277, 105);
            this.btnHapusJadwal.Name = "btnHapusJadwal";
            this.btnHapusJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnHapusJadwal.TabIndex = 71;
            this.btnHapusJadwal.Text = "Hapus";
            this.btnHapusJadwal.UseVisualStyleBackColor = true;
            this.btnHapusJadwal.Click += new System.EventHandler(this.btnHapusJadwal_Click);
            // 
            // btnUbahJadwal
            // 
            this.btnUbahJadwal.Location = new System.Drawing.Point(277, 76);
            this.btnUbahJadwal.Name = "btnUbahJadwal";
            this.btnUbahJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnUbahJadwal.TabIndex = 70;
            this.btnUbahJadwal.Text = "Ubah";
            this.btnUbahJadwal.UseVisualStyleBackColor = true;
            this.btnUbahJadwal.Click += new System.EventHandler(this.btnUbahJadwal_Click);
            // 
            // btnTambahJadwal
            // 
            this.btnTambahJadwal.Location = new System.Drawing.Point(277, 47);
            this.btnTambahJadwal.Name = "btnTambahJadwal";
            this.btnTambahJadwal.Size = new System.Drawing.Size(75, 23);
            this.btnTambahJadwal.TabIndex = 69;
            this.btnTambahJadwal.Text = "Tambah";
            this.btnTambahJadwal.UseVisualStyleBackColor = true;
            this.btnTambahJadwal.Click += new System.EventHandler(this.btnTambahJadwal_Click);
            // 
            // dataGridViewJadwal
            // 
            this.dataGridViewJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJadwal.Location = new System.Drawing.Point(0, 170);
            this.dataGridViewJadwal.Name = "dataGridViewJadwal";
            this.dataGridViewJadwal.RowHeadersWidth = 51;
            this.dataGridViewJadwal.RowTemplate.Height = 24;
            this.dataGridViewJadwal.Size = new System.Drawing.Size(800, 283);
            this.dataGridViewJadwal.TabIndex = 68;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(277, 134);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 78;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // jadwal_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.txtAcara);
            this.Controls.Add(this.dateTimePickerTanggal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnHapusJadwal);
            this.Controls.Add(this.btnUbahJadwal);
            this.Controls.Add(this.btnTambahJadwal);
            this.Controls.Add(this.dataGridViewJadwal);
            this.Name = "jadwal_admin";
            this.Text = "jadwal_admin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.TextBox txtAcara;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHapusJadwal;
        private System.Windows.Forms.Button btnUbahJadwal;
        private System.Windows.Forms.Button btnTambahJadwal;
        private System.Windows.Forms.DataGridView dataGridViewJadwal;
        private System.Windows.Forms.Button btnExport;
    }
}