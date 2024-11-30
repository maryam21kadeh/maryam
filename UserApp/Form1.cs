
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace UserApp
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=DESKTOP-KRCOE9P\SQLEXPRESS02;Database=UserDatabase;Trusted_Connection=True;";


        public Form1()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void btnLogin_Click(object sender, EventArgs e)
{
    string username = txtUsername.Text.Trim();
    string password = txtPassword.Text;

    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
    {
        MessageBox.Show("Please enter both username and password.");
        return;
    }

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    string role = result.ToString();
                    MessageBox.Show($"Login successful! Welcome, {username}. Role: {role}");

                    // Navigate to MainForm
                    this.Hide(); // Hide the Login form
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}");
        }
    }
}

    }
}
