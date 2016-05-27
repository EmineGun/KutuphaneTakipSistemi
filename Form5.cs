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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            var context = new kutuphaneEntities();
            IEnumerable<kitaplar> kitapListe = context.kitaplars;
            ArrayList ls = new ArrayList();
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
                ls.Add(kt);
            }

            dataGridView1.DataSource = ls;
            
        }
    }
}
