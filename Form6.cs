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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {

           

        }

        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtKitapAdi_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtOkulNo_TextChanged(object sender, EventArgs e)
        {
                       
        }

      public static string ad;
      public static string soyad;
      public static string kitapAdi;
      public static string yazarAdi;
        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtOkulNo.Text))
                {
                    using (var ct = new kutuphaneEntities())
                    {
                        int sayi = Convert.ToInt32(txtOkulNo.Text);

                        ArrayList ls = new ArrayList();

                        foreach (tumTablolarGetir_Result2 item in ct.tumTablolarGetir(sayi))
                        {
                            tumTablolarGetir_Result2 ks = new tumTablolarGetir_Result2();
                            ks.ad = item.ad;
                            ks.soyad = item.soyad;
                            ks.okul_no = item.okul_no;
                            ks.kitap_adi = item.kitap_adi;
                            ks.yazar_adi = item.yazar_adi;
                            kitapAdi = ks.kitap_adi;

                            yazarAdi = ks.yazar_adi;
                            ad = ks.ad;
                            yazarAdi = ks.yazar_adi;
                            ls.Add(ks);
                        }
                        dataGridView1.DataSource = ls;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen alanları doldurun");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
