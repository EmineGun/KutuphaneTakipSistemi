using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();

        }

        private void btnOkuyucuKayit_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();

        }

        private void btnOkuyucuListe_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();

        }

        private void btnKitapListe_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();

        }

        private void btnEmanetKitap_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();

        }

        private void btnGecikenKitap_Click(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.Show();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var context = new kutuphaneEntities();
            IEnumerable<kisiler> kisilerliste = context.kisilers;
            ArrayList ls = new ArrayList();

            foreach (kisiler item in kisilerliste)
            {
                kisiler ks = new kisiler();
                ks.ID = item.ID;
                ks.TC = item.TC;
                ks.ad = item.ad;
                ks.soyad = item.soyad;
                ks.sinif = item.sinif;
                ks.okul_no = item.okul_no;
                ks.dogum_tarihi = item.dogum_tarihi;
                ks.dogum_yeri = item.dogum_yeri;
                ks.telefon = item.telefon;
                ks.eposta = item.eposta;
                ks.uyelik_tarihi = item.uyelik_tarihi;
                ks.cinsiyet = item.cinsiyet;
                ks.adres = item.adres;
                ks.resim_yolu = item.resim_yolu;

                ls.Add(ks);

            }
            dataGridView1.DataSource = ls;



            var context2 = new kutuphaneEntities();
            IEnumerable<kitaplar> kitapListe = context2.kitaplars;
            ArrayList ls2 = new ArrayList();
            foreach (kitaplar item in kitapListe)
            {
                kitaplar kt = new kitaplar();
                kt.ID = item.ID;
                kt.barkod_no = item.barkod_no;
                kt.kitap_adi = item.kitap_adi;
                kt.yazar_adi = item.yazar_adi;

                kt.yayin_evi = item.yayin_evi;
                kt.kitap_turu = item.kitap_turu;
                kt.temin_bicimi = item.temin_bicimi;
                kt.temin_tarihi = item.temin_tarihi;
                kt.stok_sayisi = item.stok_sayisi;
                kt.dosyayolu = item.dosyayolu;
                ls2.Add(kt);
            }

            dataGridView2.DataSource = ls2;


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {



        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            var context = new kutuphaneEntities();

            List<arama_Result> empList = context.arama(txtAd.Text, txtSoyad.Text, txtSinif.Text).ToList();

            dataGridView1.DataSource = empList;
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            var context = new kutuphaneEntities();

            List<aramaKitap_Result> empList = context.aramaKitap(txtBarkodNo.Text, txtKitapAdi.Text, txtKitapYazari.Text, txtYayinEvi.Text).ToList();

            dataGridView2.DataSource = empList;
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            try
            {

                txtAd.Text = "";
                txtSoyad.Text = "";
                txtSinif.Text = "";
                txtOkulNo.Text = "";


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected != true)
                    {


                        txtOkuyucuAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtBarkodNo.Text = "";
               txtKAdi.Text = "";
                txtKitapYazari.Text = "";
                txtYayinEvi.Text = "";


                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected != true)
                    {


                       txtKAdi.Text  = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();


                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex);
            }
        }

        private void btnEmanetKayit_Click(object sender, EventArgs e)
        {
            var context = new kutuphaneEntities();

            if (!string.IsNullOrEmpty(txtKAdi.Text) &&
                !string.IsNullOrEmpty(txtOkuyucuAdi.Text) &&

                !string.IsNullOrEmpty(dtpKitapTeslimTarihi.Text) &&
               
               
                !string.IsNullOrEmpty(txtOkuduguKitapSayisi.Text) &&
                !string.IsNullOrEmpty(txtEmanetKitapSayisi.Text)

                )
            {


                int sonuc = context.emanetkitapEkleme(
                      txtOkuyucuAdi.Text, txtKAdi.Text, 
                      DateTime.Now, 
                      Convert.ToDateTime(dtpKitapTeslimTarihi.Text), 
                      Convert.ToInt32(txtOkuduguKitapSayisi.Text), 
                      Convert.ToInt32(txtEmanetKitapSayisi.Text)
                        );
                context.SaveChanges();
                if (sonuc == 1)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    txtOkuyucuAdi.Text = "";
                    txtKitapAdi.Text = "";

                    txtOkuduguKitapSayisi.Text = "";
                    txtEmanetKitapSayisi.Text = "";
                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız ");
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
