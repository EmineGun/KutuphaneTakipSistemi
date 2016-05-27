using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KutuphaneTakipSistemi
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        string dosyaAdi;

        private void btnResimSec_Click(object sender, EventArgs e)
        {



            var co = new kutuphaneEntities();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (String item in openFileDialog1.FileName.Split('\\'))
                {
                    if (item.Contains(".png"))
                    {
                        dosyaAdi = item;
                    }
                }

                File.WriteAllBytes(dosyaAdi, File.ReadAllBytes(openFileDialog1.FileName));

                pictureBox1.Image = Image.FromFile(dosyaAdi);
                Form2_Load(null, null);
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            var context = new kutuphaneEntities();

            if (!string.IsNullOrEmpty(txtBarkodNo.Text) &&
                !string.IsNullOrEmpty(txtKitapAdi.Text) &&
                !string.IsNullOrEmpty(txtYazarAdi.Text) &&
                !string.IsNullOrEmpty(txtYayinEvi.Text) &&
                !string.IsNullOrEmpty(txtKitapTuru.Text) &&
                !string.IsNullOrEmpty(txtTeminBicimi.Text) &&
                !string.IsNullOrEmpty(txtStokSayisi.Text)

                )
            {


                int sonuc = context.kitapekleme(
                        txtBarkodNo.Text,
                        txtKitapAdi.Text,

                        txtYazarAdi.Text,
                        txtYayinEvi.Text,
                        txtKitapTuru.Text,
                        txtTeminBicimi.Text,
                       dtpTeminTarihi.Value,
                        Convert.ToInt32(txtStokSayisi.Text), dosyaAdi);
                Form2_Load(null, null);
                context.SaveChanges();
                if (sonuc == 1)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    txtBarkodNo.Text = "";
                    txtKitapAdi.Text = "";

                    txtYazarAdi.Text = "";
                    txtYayinEvi.Text = "";
                    txtKitapTuru.Text = "";
                    txtTeminBicimi.Text = "";
                  
                    txtStokSayisi.Text = "";

                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız Barkod No Bulunuyor");
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
