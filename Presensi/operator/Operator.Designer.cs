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
            this.btnShowKaryawan = new System.Windows.Forms.Button();
            this.btnPresensi = new System.Windows.Forms.Button();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.btnShowJadwal = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowKaryawan
            // 
            this.btnShowKaryawan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowKaryawan.Location = new System.Drawing.Point(0, 170);
            this.btnShowKaryawan.Name = "btnShowKaryawan";
            this.btnShowKaryawan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnShowKaryawan.Size = new System.Drawing.Size(130, 30);
            this.btnShowKaryawan.TabIndex = 71;
            this.btnShowKaryawan.Text = "EMOLOYEE";
            this.btnShowKaryawan.UseVisualStyleBackColor = true;
            this.btnShowKaryawan.Click += new System.EventHandler(this.btnShowKaryawan_Click);
            // 
            // btnPresensi
            // 
            this.btnPresensi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresensi.Location = new System.Drawing.Point(0, 270);
            this.btnPresensi.Name = "btnPresensi";
            this.btnPresensi.Size = new System.Drawing.Size(130, 30);
            this.btnPresensi.TabIndex = 73;
            this.btnPresensi.Text = "ATTENDENCE";
            this.btnPresensi.UseVisualStyleBackColor = true;
            this.btnPresensi.Click += new System.EventHandler(this.btnPresensi_Click);
            // 
            // panelDashboard
            // 
            this.panelDashboard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDashboard.Location = new System.Drawing.Point(130, 0);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(774, 507);
            this.panelDashboard.TabIndex = 74;
            // 
            // btnShowJadwal
            // 
            this.btnShowJadwal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowJadwal.Location = new System.Drawing.Point(0, 220);
            this.btnShowJadwal.Name = "btnShowJadwal";
            this.btnShowJadwal.Size = new System.Drawing.Size(130, 30);
            this.btnShowJadwal.TabIndex = 72;
            this.btnShowJadwal.Text = "SCHEDULE";
            this.btnShowJadwal.UseVisualStyleBackColor = true;
            this.btnShowJadwal.Click += new System.EventHandler(this.btnShowJadwal_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.White;
            this.btnKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(-2, 451);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(130, 30);
            this.btnKeluar.TabIndex = 70;
            this.btnKeluar.Text = "LOG OUT";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presensi.Properties.Resources.login2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // Operator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(904, 507);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnShowKaryawan);
            this.Controls.Add(this.btnPresensi);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.btnShowJadwal);
            this.Controls.Add(this.btnKeluar);
            this.Name = "Operator";
            this.Text = "Operator";
            this.Load += new System.EventHandler(this.Operator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnShowKaryawan;
        private System.Windows.Forms.Button btnPresensi;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Button btnShowJadwal;
        private System.Windows.Forms.Button btnKeluar;
    }
}