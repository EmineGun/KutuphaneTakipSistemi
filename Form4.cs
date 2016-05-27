using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneTakipSistemi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
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

        }

        private void btnAra_Click(object sender, EventArgs e)
        {

        }
        public static int id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtTc.Text = "";
                txtAdSoyad.Text = "";
                txtSinif.Text = "";
                txtOkulNo.Text = "";
                txtDogumTarihi.Text = "";
                txtDogumYeri.Text = "";
                txtTel.Text = "";
                txtePosta.Text = "";
                txtUyelikTarihi.Text = "";
                txtCinsiyet.Text = "";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected != true)
                    {

                        txtTc.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtAdSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "  " + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtSinif.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txtOkulNo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        txtDogumTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtDogumYeri.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                        txtTel.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                        txtePosta.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                        txtUyelikTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                        txtCinsiyet.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                        var co = new kutuphaneEntities();
                        id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        pictureBox1.ImageLocation = co.resimGetir(id).ToString();



                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex);
            }
        }

    }
}
