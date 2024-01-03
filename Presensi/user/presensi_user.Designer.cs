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
            // presensi_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewPresensi);
            this.Name = "presensi_user";
            this.Text = "presensi_user";
            this.Load += new System.EventHandler(this.presensi_user_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresensi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewPresensi;
    }
}