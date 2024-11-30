using System;
using System.Windows.Forms;

namespace UserApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Logout Button
            this.btnLogout.Location = new System.Drawing.Point(150, 100);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.btnLogout);
            this.Name = "MainForm";
            this.Text = "Main Application";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnLogout;

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Log out and return to login form
            this.Hide(); // Hide the MainForm
            Form1 loginForm = new Form1();
            loginForm.Show();
        }
    }
}
