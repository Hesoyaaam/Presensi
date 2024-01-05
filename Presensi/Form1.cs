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
using System.Security.Cryptography;

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
            string password = HashPassword(txtPassword.Text); 

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and Password must be filled in.");
                return;
            }

            try
            {
                conn.Open();

                string query = "SELECT * FROM login WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["password"].ToString();

                        if (password == storedPassword)
                        {
                            string userLevel = reader["level"].ToString();

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
                                    MessageBox.Show("Invalid user");
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username and password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username not found");
                    }
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
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
