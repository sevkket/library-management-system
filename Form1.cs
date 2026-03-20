using System;
using System.Drawing;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    public partial class Form1 : Form
    {
        Label lblUsername, lblPassword, lblMessage;
        TextBox txtUsername, txtPassword;
        Button btnLogin;

        public Form1()
        {
            InitializeComponent();
            InitializeMyComponents();
        }

        private void InitializeMyComponents()
        {
            this.Text = "Giriş Ekranı";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            lblUsername = new Label()
            {
                Text = "Kullanıcı Adı:",
                Location = new Point(50, 50),
                AutoSize = true
            };
            txtUsername = new TextBox()
            {
                Location = new Point(150, 45),
                Width = 180
            };

            lblPassword = new Label()
            {
                Text = "Şifre:",
                Location = new Point(50, 100),
                AutoSize = true
            };
            txtPassword = new TextBox()
            {
                Location = new Point(150, 95),
                Width = 180,
                UseSystemPasswordChar = true
            };

            btnLogin = new Button()
            {
                Text = "Giriş Yap",
                Location = new Point(150, 140),
                Width = 180,
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnLogin.Click += BtnLogin_Click;

            lblMessage = new Label()
            {
                Location = new Point(50, 180),
                Width = 280,
                ForeColor = Color.Red,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.AddRange(new Control[] {
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                btnLogin, lblMessage
            });
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // Basit demo giriş sistemi (VERİTABANI YOK)
            if (user == "admin" && pass == "1234")
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else if (user == "user" && pass == "1234")
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