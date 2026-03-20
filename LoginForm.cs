using System;
using System.Drawing;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    public class LoginForm : Form
    {
        TextBox txtUsername, txtPassword;
        Button btnLogin;
        Label lblMessage;

        public LoginForm()
        {
            this.Text = "Giriş Ekranı";
            this.BackColor = Color.Firebrick;
            this.Size = new Size(350, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label()
            {
                Text = "Kütüphane Otomasyon Girişi",
                ForeColor = Color.White,
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50,
            };
            this.Controls.Add(lblTitle);

            Label lblUser = new Label()
            {
                Text = "Kullanıcı Adı:",
                ForeColor = Color.White,
                Location = new Point(30, 70),
                AutoSize = true
            };
            this.Controls.Add(lblUser);

            txtUsername = new TextBox()
            {
                Location = new Point(130, 67),
                Width = 150
            };
            this.Controls.Add(txtUsername);

            Label lblPass = new Label()
            {
                Text = "Şifre:",
                ForeColor = Color.White,
                Location = new Point(30, 110),
                AutoSize = true
            };
            this.Controls.Add(lblPass);

            txtPassword = new TextBox()
            {
                Location = new Point(130, 107),
                Width = 150,
                UseSystemPasswordChar = true
            };
            this.Controls.Add(txtPassword);

            btnLogin = new Button()
            {
                Text = "Giriş Yap",
                Location = new Point(130, 150),
                Width = 150,
                BackColor = Color.White,
                ForeColor = Color.Firebrick,
                FlatStyle = FlatStyle.Flat,
            };
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);

            lblMessage = new Label()
            {
                ForeColor = Color.Yellow,
                Location = new Point(30, 190),
                Width = 250,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };
            this.Controls.Add(lblMessage);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // ADMIN
            if (user == "admin" && pass == "1234")
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            // USER
            else if (user == "user" && pass == "1111")
            {
                UserForm userForm = new UserForm();
                userForm.Show();
                this.Hide();
            }
            else
            {
                lblMessage.Text = "Kullanıcı adı veya şifre yanlış!";
            }
        }
    }
}