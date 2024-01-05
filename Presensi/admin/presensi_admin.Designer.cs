namespace Presensi.admin
{
    partial class presensi_admin
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
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 86;
            this.label12.Text = "Event";
            // 
            // ComboBoxNamaAcara
            // 
            this.ComboBoxNamaAcara.FormattingEnabled = true;
            this.ComboBoxNamaAcara.Location = new System.Drawing.Point(124, 132);
            this.ComboBoxNamaAcara.Name = "ComboBoxNamaAcara";
            this.ComboBoxNamaAcara.Size = new System.Drawing.Size(168, 24);
            this.ComboBoxNamaAcara.TabIndex = 85;
            this.ComboBoxNamaAcara.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNamaAcara_SelectedIndexChanged);
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(124, 86);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(168, 24);
            this.ComboBoxStatus.TabIndex = 84;
            this.ComboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // ComboBoxPresensiKaryawan
            // 
            this.ComboBoxPresensiKaryawan.FormattingEnabled = true;
            this.ComboBoxPresensiKaryawan.Location = new System.Drawing.Point(124, 40);
            this.ComboBoxPresensiKaryawan.Name = "ComboBoxPresensiKaryawan";
            this.ComboBoxPresensiKaryawan.Size = new System.Drawing.Size(168, 24);
            this.ComboBoxPresensiKaryawan.TabIndex = 83;
            this.ComboBoxPresensiKaryawan.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPresensiKaryawan_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 82;
            this.label9.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "Name";
            // 
            // btnHapusPresensi
            // 
            this.btnHapusPresensi.Location = new System.Drawing.Point(320, 132);
            this.btnHapusPresensi.Name = "btnHapusPresensi";
            this.btnHapusPresensi.Size = new System.Drawing.Size(80, 30);
            this.btnHapusPresensi.TabIndex = 79;
            this.btnHapusPresensi.Text = "DELETE";
            this.btnHapusPresensi.UseVisualStyleBackColor = true;
            this.btnHapusPresensi.Click += new System.EventHandler(this.btnHapusPresensi_Click);
            // 
            // btnUbahPresensi
            // 
            this.btnUbahPresensi.Location = new System.Drawing.Point(320, 87);
            this.btnUbahPresensi.Name = "btnUbahPresensi";
            this.btnUbahPresensi.Size = new System.Drawing.Size(80, 30);
            this.btnUbahPresensi.TabIndex = 78;
            this.btnUbahPresensi.Text = "EDIT";
            this.btnUbahPresensi.UseVisualStyleBackColor = true;
            this.btnUbahPresensi.Click += new System.EventHandler(this.btnUbahPresensi_Click);
            // 
            // btnTambahPresensi
            // 
            this.btnTambahPresensi.Location = new System.Drawing.Point(320, 42);
            this.btnTambahPresensi.Name = "btnTambahPresensi";
            this.btnTambahPresensi.Size = new System.Drawing.Size(80, 30);
            this.btnTambahPresensi.TabIndex = 77;
            this.btnTambahPresensi.Text = "ADD";
            this.btnTambahPresensi.UseVisualStyleBackColor = true;
            this.btnTambahPresensi.Click += new System.EventHandler(this.btnTambahPresensi_Click);
            // 
            // dataGridViewPresensi
            // 
            this.dataGridViewPresensi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewPresensi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresensi.Location = new System.Drawing.Point(0, 170);
            this.dataGridViewPresensi.Name = "dataGridViewPresensi";
            this.dataGridViewPresensi.RowHeadersWidth = 51;
            this.dataGridViewPresensi.RowTemplate.Height = 24;
            this.dataGridViewPresensi.Size = new System.Drawing.Size(802, 284);
            this.dataGridViewPresensi.TabIndex = 76;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(492, 128);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 30);
            this.btnExport.TabIndex = 88;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(406, 132);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.TabIndex = 89;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // presensi_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExport);
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
            this.Name = "presensi_admin";
            this.Text = "presensi_admin";
            this.Load += new System.EventHandler(this.presensi_admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).EndInit();
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
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClear;
    }
}