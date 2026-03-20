using System;
using System.Drawing;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    public class UserForm : Form
    {
        DataGridView dgvAvailableBooks;
        TextBox txtBorrowBookId;
        Button btnBorrow;
        Label lblBorrowStatus;

        public UserForm()
        {
            this.Text = "Kullanıcı Paneli";
            this.Size = new Size(700, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.RoyalBlue;

            Label lblTitle = new Label()
            {
                Text = "Kullanıcı Paneli",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            dgvAvailableBooks = new DataGridView()
            {
                Location = new Point(10, 50),
                Size = new Size(660, 220),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvAvailableBooks);

            dgvAvailableBooks.Columns.Add("KitapId", "Kitap ID");
            dgvAvailableBooks.Columns.Add("KitapAdi", "Kitap Adı");
            dgvAvailableBooks.Columns.Add("Yazar", "Yazar");
            dgvAvailableBooks.Columns.Add("YayinEvi", "Yayın Evi");
            dgvAvailableBooks.Columns.Add("StokAdedi", "Stok Adedi");

            Label lblBorrow = new Label()
            {
                Text = "Ödünç Almak İstediğiniz Kitap ID:",
                ForeColor = Color.White,
                Location = new Point(10, 290),
                AutoSize = true
            };
            this.Controls.Add(lblBorrow);

            txtBorrowBookId = new TextBox()
            {
                Location = new Point(230, 285),
                Width = 100
            };
            this.Controls.Add(txtBorrowBookId);

            btnBorrow = new Button()
            {
                Text = "Kitap Ödünç Al",
                Location = new Point(350, 283),
                Size = new Size(120, 28),
                BackColor = Color.White,
                ForeColor = Color.RoyalBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnBorrow.Click += BtnBorrow_Click;
            this.Controls.Add(btnBorrow);

            lblBorrowStatus = new Label()
            {
                Location = new Point(10, 320),
                Size = new Size(660, 30),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblBorrowStatus);

            // Örnek kitaplar
            dgvAvailableBooks.Rows.Add("1", "Suç ve Ceza", "Dostoyevski", "Can Yayınları", "5");
            dgvAvailableBooks.Rows.Add("2", "Sefiller", "Victor Hugo", "İthaki", "3");
            dgvAvailableBooks.Rows.Add("3", "1984", "George Orwell", "Penguin", "7");
        }

        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            string id = txtBorrowBookId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                lblBorrowStatus.Text = "Lütfen bir kitap ID'si girin.";
                return;
            }

            foreach (DataGridViewRow row in dgvAvailableBooks.Rows)
            {
                if (row.Cells["KitapId"].Value?.ToString() == id)
                {
                    if (int.TryParse(row.Cells["StokAdedi"].Value.ToString(), out int stok))
                    {
                        if (stok > 0)
                        {
                            stok--;
                            row.Cells["StokAdedi"].Value = stok.ToString();
                            lblBorrowStatus.Text = $"Kitap ID {id} ödünç alındı.";
                        }
                        else
                        {
                            lblBorrowStatus.Text = "Bu kitap stokta yok.";
                        }
                    }
                    else
                    {
                        lblBorrowStatus.Text = "Stok bilgisi geçersiz.";
                    }
                    return;
                }
            }

            lblBorrowStatus.Text = "Kitap ID bulunamadı.";
        }
    }
}
