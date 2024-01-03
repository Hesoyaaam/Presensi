namespace Presensi
{
    partial class karyawan_operator
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
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewKaryawan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKaryawan)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Data Karyawan";
            // 
            // dataGridViewKaryawan
            // 
            this.dataGridViewKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKaryawan.Location = new System.Drawing.Point(0, 70);
            this.dataGridViewKaryawan.Name = "dataGridViewKaryawan";
            this.dataGridViewKaryawan.RowHeadersWidth = 51;
            this.dataGridViewKaryawan.RowTemplate.Height = 24;
            this.dataGridViewKaryawan.Size = new System.Drawing.Size(804, 383);
            this.dataGridViewKaryawan.TabIndex = 56;
            // 
            // karyawan_operator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewKaryawan);
            this.Name = "karyawan_operator";
            this.Text = "karyawan";
            this.Load += new System.EventHandler(this.karyawan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKaryawan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewKaryawan;
    }
}