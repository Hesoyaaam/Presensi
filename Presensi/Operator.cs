using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presensi
{
    public partial class Operator : Form
    {
        public Operator()
        {
            InitializeComponent();
        }

        private void Operator_Load(object sender, EventArgs e)
        {

        }
        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }
    }
}
