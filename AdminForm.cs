using System;
using System.Drawing;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    public class AdminForm : Form
    {
        string connectionString = "server=localhost;database=kutuphane1;uid=root;pwd=;SslMode=none;";

        DataGridView dgvBooks;
        TextBox txtKitapAdi, txtYazar, txtYayinEvi, txtBasimYili, txtSayfaSayisi, txtStokAdedi;
        Button btnAdd, btnUpdate, btnDelete;

        public AdminForm()
        {
            this.Text = "Admin Paneli";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.DarkRed;

            Label lblTitle = new Label()
            {
                Text = "Admin Paneli - Kitap Yönetimi",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            dgvBooks = new DataGridView()
            {
                Location = new Point(10, 50),
                Size = new Size(760, 250),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvBooks);

            dgvBooks.Columns.Add("KitapId", "Kitap ID");
            dgvBooks.Columns.Add("KitapAdi", "Kitap Adı");
            dgvBooks.Columns.Add("Yazar", "Yazar");
            dgvBooks.Columns.Add("YayinEvi", "Yayın Evi");
            dgvBooks.Columns.Add("BasimYili", "Basım Yılı");
            dgvBooks.Columns.Add("SayfaSayisi", "Sayfa Sayısı");
            dgvBooks.Columns.Add("StokAdedi", "Stok Adedi");

            Label lblKitapAdi = new Label() { Text = "Kitap Adı:", ForeColor = Color.White, Location = new Point(10, 320), AutoSize = true };
            txtKitapAdi = new TextBox() { Location = new Point(100, 315), Width = 150 };

            Label lblYazar = new Label() { Text = "Yazar:", ForeColor = Color.White, Location = new Point(270, 320), AutoSize = true };
            txtYazar = new TextBox() { Location = new Point(320, 315), Width = 150 };

            Label lblYayinEvi = new Label() { Text = "Yayın Evi:", ForeColor = Color.White, Location = new Point(490, 320), AutoSize = true };
            txtYayinEvi = new TextBox() { Location = new Point(570, 315), Width = 150 };

            Label lblBasimYili = new Label() { Text = "Basım Yılı:", ForeColor = Color.White, Location = new Point(10, 360), AutoSize = true };
            txtBasimYili = new TextBox() { Location = new Point(100, 355), Width = 150 };

            Label lblSayfaSayisi = new Label() { Text = "Sayfa Sayısı:", ForeColor = Color.White, Location = new Point(270, 360), AutoSize = true };
            txtSayfaSayisi = new TextBox() { Location = new Point(360, 355), Width = 110 };

            Label lblStokAdedi = new Label() { Text = "Stok Adedi:", ForeColor = Color.White, Location = new Point(490, 360), AutoSize = true };
            txtStokAdedi = new TextBox() { Location = new Point(570, 355), Width = 150 };

            this.Controls.AddRange(new Control[] {
                lblKitapAdi, txtKitapAdi,
                lblYazar, txtYazar,
                lblYayinEvi, txtYayinEvi,
                lblBasimYili, txtBasimYili,
                lblSayfaSayisi, txtSayfaSayisi,
                lblStokAdedi, txtStokAdedi
            });

            btnAdd = new Button() { Text = "Ekle", Location = new Point(200, 400), Size = new Size(100, 30), BackColor = Color.White, ForeColor = Color.DarkRed };
            btnUpdate = new Button() { Text = "Güncelle", Location = new Point(320, 400), Size = new Size(100, 30), BackColor = Color.White, ForeColor = Color.DarkRed };
            btnDelete = new Button() { Text = "Sil", Location = new Point(440, 400), Size = new Size(100, 30), BackColor = Color.White, ForeColor = Color.DarkRed };

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;

            this.Controls.AddRange(new Control[] { btnAdd, btnUpdate, btnDelete });

            // Örnek veri
            dgvBooks.Rows.Add("1", "Suç ve Ceza", "Dostoyevski", "Can Yayınları", "1866", "430", "5");
            dgvBooks.Rows.Add("2", "Sefiller", "Victor Hugo", "İthaki", "1862", "1200", "3");
            dgvBooks.Rows.Add("3", "1984", "George Orwell", "Penguin", "1949", "328", "7");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dgvBooks.Rows.Add(
                (dgvBooks.Rows.Count + 1).ToString(),
                txtKitapAdi.Text,
                txtYazar.Text,
                txtYayinEvi.Text,
                txtBasimYili.Text,
                txtSayfaSayisi.Text,
                txtStokAdedi.Text
            );
            Temizle();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvBooks.SelectedRows[0];
                row.Cells["KitapAdi"].Value = txtKitapAdi.Text;
                row.Cells["Yazar"].Value = txtYazar.Text;
                row.Cells["YayinEvi"].Value = txtYayinEvi.Text;
                row.Cells["BasimYili"].Value = txtBasimYili.Text;
                row.Cells["SayfaSayisi"].Value = txtSayfaSayisi.Text;
                row.Cells["StokAdedi"].Value = txtStokAdedi.Text;
                Temizle();
            }
            else
            {
                MessageBox.Show("Güncellemek için bir satır seçiniz.");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                dgvBooks.Rows.Remove(dgvBooks.SelectedRows[0]);
                Temizle();
            }
            else
            {
                MessageBox.Show("Silmek için bir satır seçiniz.");
            }
        }

        private void Temizle()
        {
            txtKitapAdi.Text = "";
            txtYazar.Text = "";
            txtYayinEvi.Text = "";
            txtBasimYili.Text = "";
            txtSayfaSayisi.Text = "";
            txtStokAdedi.Text = "";
        }
    }
}
