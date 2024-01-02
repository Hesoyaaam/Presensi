using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Presensi
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=presensi;User Id=your_username;Password=your_password;");

        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password harus diisi.");
                return;
            }
            try
            {
                conn.Open();

                string query = "SELECT * FROM login WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                DataTable dtabel = new DataTable();
                sda.Fill(dtabel);

                if (dtabel.Rows.Count > 0)
                {
                    string userLevel = dtabel.Rows[0]["level"].ToString();

                    switch (userLevel.ToLower())
                    {
                        case "admin":
                            Admin adminForm = new Admin();
                            adminForm.Show();
                            this.Hide();
                            break;

                        case "operator":
                            Operator operatorForm = new Operator();
                            operatorForm.Show();
                            this.Hide();
                            break;

                        case "user":
                            User userForm = new User();
                            userForm.Show();
                            this.Hide();
                            break;

                        default:
                            MessageBox.Show("Peran pengguna tidak valid.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Kombinasi username dan password tidak valid.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
