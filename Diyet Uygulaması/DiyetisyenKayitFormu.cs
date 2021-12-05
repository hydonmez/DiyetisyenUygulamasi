using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyetisyenUygulama
{
    public partial class DiyetisyenKayitFormu : Form
    {
        public DiyetisyenKayitFormu()
        {
            InitializeComponent();
        }

        private void formuKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formuKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Diyetisyen ilgili islemleri yapmak icin DiyetisyenManager sınıfindan bir nesne yaratildi
        DiyetisyenManager diyetisyenManager = new DiyetisyenManager();
       

        private void Kontrol(Boolean eklendiMi) //Veritabanina diyetisyen eklendiyse textlerin icini bosaltir.
        {
            if (eklendiMi)
            {
                txtAd.Text = "";
                txtSoyad.Text = "";
                txtDiyetisyenKullaniciAdi.Text = "";
                txtDiyetisyenTc.Text = "";
                txtDiyetisyenSifre.Text = "";

            }
        }
        private Boolean BosGecildiMi() //Alanlarin bos gecilip gecilmedigi bilgisini dondurur.
        {
            if (txtAd.Text == "" || txtDiyetisyenKullaniciAdi.Text == "" || txtSoyad.Text == "" ||
            txtDiyetisyenTc.Text == "" || txtDiyetisyenSifre.Text == "")
            {
                MessageBox.Show("Hic bir alan boş gecilemez");
                return true;
            }
            else
            {
                return false; //bos gelcilmediyse ekleme islemi icin izin ver
            }
        }

        private void btnKayitOl_Click_1(object sender, EventArgs e)
        {
            if (!BosGecildiMi()) //Hicbir alan bos gecilmediyse diyetisyeni ekler.
            {
                DiyetisyenTbl diyetisyen = new DiyetisyenTbl
                {
                    DiyetisyenAd = txtAd.Text,
                    DiyetisyenKullaniciAdi = txtDiyetisyenKullaniciAdi.Text,
                    DiyetisyenSoyad = txtSoyad.Text,
                    DiyetisyenTc = txtDiyetisyenTc.Text,
                    DiyetisyenSifre = txtDiyetisyenSifre.Text,

                };

                /*DiyetisyenTbl sinifindan nesne olusturulur ve olusan nesne DiyetisyenManager sinifinin diyetisyen ekle metotuna 
                 *parametre olarak gönderilir Diyetisyenin veritabanina eklenip eklenmedigi bilgisi getirilir.*/
                Kontrol(diyetisyenManager.DiyetisyenEkle(diyetisyen)); 
            }
        }
    }
}
