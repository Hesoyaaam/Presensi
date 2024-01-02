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
            this.btnKeluar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHapusPresensi = new System.Windows.Forms.Button();
            this.btnUbahPresensi = new System.Windows.Forms.Button();
            this.btnTambahPresensi = new System.Windows.Forms.Button();
            this.dataGridViewPresensi = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewKaryawan = new System.Windows.Forms.DataGridView();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKaryawan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKeluar
            // 
            this.btnKeluar.Location = new System.Drawing.Point(713, 415);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(75, 23);
            this.btnKeluar.TabIndex = 7;
            this.btnKeluar.Text = "Keluar";
            this.btnKeluar.UseVisualStyleBackColor = true;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Data Presensi";
            // 
            // btnHapusPresensi
            // 
            this.btnHapusPresensi.Location = new System.Drawing.Point(501, 318);
            this.btnHapusPresensi.Name = "btnHapusPresensi";
            this.btnHapusPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnHapusPresensi.TabIndex = 28;
            this.btnHapusPresensi.Text = "Hapus";
            this.btnHapusPresensi.UseVisualStyleBackColor = true;
            // 
            // btnUbahPresensi
            // 
            this.btnUbahPresensi.Location = new System.Drawing.Point(501, 289);
            this.btnUbahPresensi.Name = "btnUbahPresensi";
            this.btnUbahPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnUbahPresensi.TabIndex = 27;
            this.btnUbahPresensi.Text = "Ubah";
            this.btnUbahPresensi.UseVisualStyleBackColor = true;
            // 
            // btnTambahPresensi
            // 
            this.btnTambahPresensi.Location = new System.Drawing.Point(501, 260);
            this.btnTambahPresensi.Name = "btnTambahPresensi";
            this.btnTambahPresensi.Size = new System.Drawing.Size(75, 23);
            this.btnTambahPresensi.TabIndex = 26;
            this.btnTambahPresensi.Text = "Tambah";
            this.btnTambahPresensi.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPresensi
            // 
            this.dataGridViewPresensi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresensi.Location = new System.Drawing.Point(12, 260);
            this.dataGridViewPresensi.Name = "dataGridViewPresensi";
            this.dataGridViewPresensi.RowHeadersWidth = 51;
            this.dataGridViewPresensi.RowTemplate.Height = 24;
            this.dataGridViewPresensi.Size = new System.Drawing.Size(473, 153);
            this.dataGridViewPresensi.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Data Karyawan";
            // 
            // dataGridViewKaryawan
            // 
            this.dataGridViewKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKaryawan.Location = new System.Drawing.Point(12, 47);
            this.dataGridViewKaryawan.Name = "dataGridViewKaryawan";
            this.dataGridViewKaryawan.RowHeadersWidth = 51;
            this.dataGridViewKaryawan.RowTemplate.Height = 24;
            this.dataGridViewKaryawan.Size = new System.Drawing.Size(473, 153);
            this.dataGridViewKaryawan.TabIndex = 33;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(501, 105);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 32;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(501, 76);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.Text = "Ubah";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(501, 47);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 30;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            // 
            // Operator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewKaryawan);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHapusPresensi);
            this.Controls.Add(this.btnUbahPresensi);
            this.Controls.Add(this.btnTambahPresensi);
            this.Controls.Add(this.dataGridViewPresensi);
            this.Controls.Add(this.btnKeluar);
            this.Name = "Operator";
            this.Text = "Operator";
            this.Load += new System.EventHandler(this.Operator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKaryawan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHapusPresensi;
        private System.Windows.Forms.Button btnUbahPresensi;
        private System.Windows.Forms.Button btnTambahPresensi;
        private System.Windows.Forms.DataGridView dataGridViewPresensi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewKaryawan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnTambah;
    }
}