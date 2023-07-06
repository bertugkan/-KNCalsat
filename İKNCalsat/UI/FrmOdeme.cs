using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İKNCalsat.UI
{
    public partial class FrmOdeme : Form
    {
        public FrmOdeme()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Odeme Odeme { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (nmTutar.Value == 0)
            {
                errorProvider1.SetError(nmTutar, "Lütfen Tutar Giriniz!");
                nmTutar.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(nmTutar, "");

            }

            if (cbTur.SelectedItem == null)
            {
                errorProvider1.SetError(cbTur, "Ödeme Türü Seçin!");
                cbTur.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(cbTur, "");
            }

            if (txtAciklama.Text == "")
            {
                errorProvider1.SetError(txtAciklama, "Eksik veya Hatalı Bilgi!");
                txtAciklama.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtAciklama, "");
            }

            Odeme.Tur = cbTur.SelectedItem.ToString();
            Odeme.Tutar = (double)nmTutar.Value;
            Odeme.Aciklama = txtAciklama.Text;
            Odeme.Tarih = dtTarih.Value;

            DialogResult = DialogResult.OK;
        }
    }
}
