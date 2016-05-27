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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmbDogumYeri.Items.Add("Ankara");
            cmbDogumYeri.Items.Add("İstanbul");
            cmbDogumYeri.Items.Add("İzmir");
            cmbDogumYeri.Items.Add("Mardin");
            cmbCinsiyet.Items.Add("Bay");
            cmbCinsiyet.Items.Add("Bayan");
        }

        String dosyaAdi;
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
                
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var context = new kutuphaneEntities();

            if (!string.IsNullOrEmpty(txtTc.Text) &&
                !string.IsNullOrEmpty(txtAd.Text) &&
                !string.IsNullOrEmpty(txtOkulNo.Text) &&
                !string.IsNullOrEmpty(txtSinif.Text) &&
                !string.IsNullOrEmpty(cmbDogumYeri.Text) &&
                !string.IsNullOrEmpty(txtTel.Text) &&
                !string.IsNullOrEmpty(txtePosta.Text) &&
                 !string.IsNullOrEmpty(cmbCinsiyet.Text) &&
                 !string.IsNullOrEmpty(txtAdres.Text))
            {


                int sonuc = context.kisiekleme(
                    Convert.ToInt32(txtTc.Text),
                    txtAd.Text,
                    txtSoyad.Text,
                    Convert.ToInt32(txtOkulNo.Text),
                    txtSinif.Text,
                    dtpDogumTarihi.Value,
                    cmbDogumYeri.Text,
                    txtTel.Text,
                    txtePosta.Text,
                    dtpUyelikTarihi.Value,
                    cmbCinsiyet.Text,
                    txtAdres.Text,
                    dosyaAdi);
               
                context.SaveChanges();
                if (sonuc != -1)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    txtTc.Text = "";
                    txtAd.Text = "";
                    txtSoyad.Text = "";
                    txtOkulNo.Text = "";
                    txtSinif.Text = "";
                    cmbDogumYeri.Text = "";
                    txtTel.Text = "";

                    txtePosta.Text = "";
                    cmbCinsiyet.Text = "";
                    txtAdres.Text = "";

                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız TC No Bulunuyor");
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
