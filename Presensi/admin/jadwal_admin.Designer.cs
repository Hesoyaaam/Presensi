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
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 77;
            this.label8.Text = "Acara";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(109, 137);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(168, 22);
            this.txtKeterangan.TabIndex = 76;
            // 
            // txtAcara
            // 
            this.txtAcara.Location = new System.Drawing.Point(109, 40);
            this.txtAcara.Name = "txtAcara";
            this.txtAcara.Size = new System.Drawing.Size(168, 22);
            this.txtAcara.TabIndex = 75;
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(109, 89);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(168, 22);
            this.dateTimePickerTanggal.TabIndex = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 16);
            this.label10.TabIndex = 73;
            this.label10.Text = "Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 72;
            this.label7.Text = "Date";
            // 
            // btnHapusJadwal
            // 
            this.btnHapusJadwal.Location = new System.Drawing.Point(320, 134);
            this.btnHapusJadwal.Name = "btnHapusJadwal";
            this.btnHapusJadwal.Size = new System.Drawing.Size(80, 30);
            this.btnHapusJadwal.TabIndex = 71;
            this.btnHapusJadwal.Text = "DELETE";
            this.btnHapusJadwal.UseVisualStyleBackColor = true;
            this.btnHapusJadwal.Click += new System.EventHandler(this.btnHapusJadwal_Click);
            // 
            // btnUbahJadwal
            // 
            this.btnUbahJadwal.Location = new System.Drawing.Point(320, 88);
            this.btnUbahJadwal.Name = "btnUbahJadwal";
            this.btnUbahJadwal.Size = new System.Drawing.Size(80, 30);
            this.btnUbahJadwal.TabIndex = 70;
            this.btnUbahJadwal.Text = "EDIT";
            this.btnUbahJadwal.UseVisualStyleBackColor = true;
            this.btnUbahJadwal.Click += new System.EventHandler(this.btnUbahJadwal_Click);
            // 
            // btnTambahJadwal
            // 
            this.btnTambahJadwal.Location = new System.Drawing.Point(320, 42);
            this.btnTambahJadwal.Name = "btnTambahJadwal";
            this.btnTambahJadwal.Size = new System.Drawing.Size(80, 30);
            this.btnTambahJadwal.TabIndex = 69;
            this.btnTambahJadwal.Text = "ADD";
            this.btnTambahJadwal.UseVisualStyleBackColor = true;
            this.btnTambahJadwal.Click += new System.EventHandler(this.btnTambahJadwal_Click);
            // 
            // dataGridViewJadwal
            // 
            this.dataGridViewJadwal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnExport.Location = new System.Drawing.Point(492, 134);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 30);
            this.btnExport.TabIndex = 78;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(406, 134);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.TabIndex = 79;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // jadwal_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
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
            this.Load += new System.EventHandler(this.jadwal_admin_Load);
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
        private System.Windows.Forms.Button btnClear;
    }
}