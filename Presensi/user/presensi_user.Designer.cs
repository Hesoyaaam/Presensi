namespace Presensi.user
{
    partial class presensi_user
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
            this.dataGridViewPresensi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPresensi
            // 
            this.dataGridViewPresensi.ColumnHeadersHeight = 29;
            this.dataGridViewPresensi.Location = new System.Drawing.Point(0, 70);
            this.dataGridViewPresensi.Name = "dataGridViewPresensi";
            this.dataGridViewPresensi.RowHeadersWidth = 51;
            this.dataGridViewPresensi.RowTemplate.Height = 24;
            this.dataGridViewPresensi.Size = new System.Drawing.Size(801, 381);
            this.dataGridViewPresensi.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 16);
            this.label1.TabIndex = 77;
            this.label1.Text = "ATTENDANCE DATA";
            // 
            // presensi_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPresensi);
            this.Name = "presensi_user";
            this.Text = "presensi_user";
            this.Load += new System.EventHandler(this.presensi_user_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewPresensi;
        private System.Windows.Forms.Label label1;
    }
}