using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            txtAdSoyad.Text=Form6.ad+""+Form6.soyad;
            txtKitapAdi.Text = Form6.kitapAdi;
            cmbHasarDurumu.Items.Add("Hasarlı");
            cmbHasarDurumu.Items.Add("Hasarsız");
            cmbHasarDurumu.Items.Add("Kayıp");
        }

        private void btnTmm_Click(object sender, EventArgs e)
        {

            try
            {
                var context = new kutuphaneEntities();




               context.teslim(
                            txtAdSoyad.Text, txtKitapAdi.Text, Convert.ToDateTime(dtpTeslimTarihi.Text), cmbHasarDurumu.Text);

                context.SaveChanges();
                MessageBox.Show("Kayıt Başarılı");
                int sonuc = context.teslimAlmaEmanetAzaltma(Form6.ad, Form6.kitapAdi
                           );

                context.SaveChanges();
                if (sonuc!=-1)
                {
                    MessageBox.Show("Emanet Kitap Listesinden Kalktı");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Başarız");
            }
            
               
        }
    }
}
