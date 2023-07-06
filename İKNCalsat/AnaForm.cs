using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using İKNCalsat.BL;
using İKNCalsat.Uİ;
using İKNCalsat.UI;

namespace İKNCalsat
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btnMüşteriEkle_Click(object sender, EventArgs e)
        {
            FrmMusteri frmMusteri = new FrmMusteri()
            {
                Text = "Müşteri Ekle",
                Musteri = new Musteri() { ID = Guid.NewGuid() },
            };

            var sonuc = frmMusteri.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.MüşteriEkle(frmMusteri.Musteri);
                if (b)
                {
                    DataSet ds = BLogic.MüşteriGetir("");
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void btnMüşteriDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            FrmMusteri frmMusteri = new FrmMusteri()
            {
                Text = "Müşteri Güncelle",
                Güncelleme = true,
                Musteri = new Musteri()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Soyad = row.Cells[2].Value.ToString(),
                    Telefon = row.Cells[3].Value.ToString(),
                    Mail = row.Cells[4].Value.ToString(),
                    Adres = row.Cells[5].Value.ToString(),
                },
            };


            var sonuc = frmMusteri.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.MüşteriGüncelle(frmMusteri.Musteri);
                if (b)
                {
                    row.Cells[1].Value = frmMusteri.Musteri.Ad;
                    row.Cells[2].Value = frmMusteri.Musteri.Soyad;
                    row.Cells[3].Value = frmMusteri.Musteri.Telefon;
                    row.Cells[4].Value = frmMusteri.Musteri.Mail;
                    row.Cells[5].Value = frmMusteri.Musteri.Adres;

                }
            }


        }

        private void btnMüşteriBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.MüşteriGetir(toolStripTextBox1.Text);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            DataSet ds1 = BLogic.MüşteriGetir("");
            dataGridView1.DataSource = ds1.Tables[0];

            DataSet ds2 = BLogic.UrunGetir("");
            dataGridView2.DataSource = ds2.Tables[0];

        }

        private void btnMüşteriSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili Öğe Silinsin Mi?", "Silmeyi Onayla", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.MüşteriSil(ID);
                if (b)
                {
                    if (b)
                    {
                        DataSet ds = BLogic.MüşteriGetir("");
                        dataGridView1.DataSource = ds.Tables[0];
                    }

                }
            }

        }

        private void btnÜrünEkle_Click(object sender, EventArgs e)
        {
            FrmUrun frm = new FrmUrun()
            {
                Text = "Ürün Ekle",
                Urun = new Urun() { ID = Guid.NewGuid() },
            };

        tekrar:
            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunEkle(frm.Urun);
                if (b)
                {
                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;
            }

        }

        private void btnÜrünBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.UrunGetir(toolStripTextBox2.Text);
            dataGridView2.DataSource = ds.Tables[0];

        }

        private void btnÜrünDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            FrmUrun frm = new FrmUrun()
            {
                Text = "Ürün Güncelle",
                Güncelleme = true,
                Urun = new Urun()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Kategori = row.Cells[2].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                    Stok = double.Parse(row.Cells[4].Value.ToString()),
                    Birim = row.Cells[5].Value.ToString(),
                    Detay = row.Cells[6].Value.ToString(),
                },
            };


            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunGüncelle(frm.Urun);
                if (b)
                {
                    row.Cells[1].Value = frm.Urun.Ad;
                    row.Cells[2].Value = frm.Urun.Kategori;
                    row.Cells[3].Value = frm.Urun.Fiyat;
                    row.Cells[4].Value = frm.Urun.Stok;
                    row.Cells[5].Value = frm.Urun.Birim;
                    row.Cells[6].Value = frm.Urun.Detay;

                }
            }

        }

        private void btnÜrünSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili Öğe Silinsin Mi?", "Silmeyi Onayla", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunSil(ID);
                if (b)
                {
                    if (b)
                    {
                        DataSet ds = BLogic.UrunGetir("");
                        dataGridView2.DataSource = ds.Tables[0];
                    }

                }

            }
        }
    }
}
        
