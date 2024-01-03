namespace Presensi
{
    partial class User
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
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewJadwal = new System.Windows.Forms.DataGridView();
            this.dataGridViewPresensi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 83;
            this.label1.Text = "Presensi";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 16);
            this.label11.TabIndex = 82;
            this.label11.Text = "Jadwal";
            // 
            // dataGridViewJadwal
            // 
            this.dataGridViewJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJadwal.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewJadwal.Name = "dataGridViewJadwal";
            this.dataGridViewJadwal.RowHeadersWidth = 51;
            this.dataGridViewJadwal.RowTemplate.Height = 24;
            this.dataGridViewJadwal.Size = new System.Drawing.Size(472, 162);
            this.dataGridViewJadwal.TabIndex = 81;
            // 
            // dataGridViewPresensi
            // 
            this.dataGridViewPresensi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresensi.Location = new System.Drawing.Point(12, 232);
            this.dataGridViewPresensi.Name = "dataGridViewPresensi";
            this.dataGridViewPresensi.RowHeadersWidth = 51;
            this.dataGridViewPresensi.RowTemplate.Height = 24;
            this.dataGridViewPresensi.Size = new System.Drawing.Size(734, 162);
            this.dataGridViewPresensi.TabIndex = 80;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridViewJadwal);
            this.Controls.Add(this.dataGridViewPresensi);
            this.Name = "User";
            this.Text = "User";
            this.Load += new System.EventHandler(this.User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJadwal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewJadwal;
        private System.Windows.Forms.DataGridView dataGridViewPresensi;
    }
}