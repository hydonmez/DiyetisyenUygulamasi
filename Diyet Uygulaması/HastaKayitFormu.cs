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
    public partial class HastaKayitFormu : Form
    {
        //bridge tasarım deseni icin DiyetYontemiManagerdan sınıfından bir nesne yaratılır
        DiyetYontemiAbstraction diyet = new DiyetYontemiManager(); 

        //hastalık bilgisini almak ve fabrika desenini kullanmak icin HastalıkFabrikasi'ndan bir nesne yaratılır
        HastalikFabrikasi hastalikFabrikasi = new HastalikFabrikasi();

        IHastalik hastalik;//Hastalık fabrikası deseninde hastalıklara ulasabilmek icin Ihastalik interfaceden bir özellik yaratılır
        public HastaKayitFormu()
        {
            InitializeComponent();
        }
        private void Kontrol(Boolean eklendiMi) //Veritabanina kullanici eklendiyse textlerin icini bosaltir.
        {
            if (eklendiMi)
            {
                txtAd.Text = "";
                txtSoyad.Text = "";
                txtTc.Text = "";
                cmbHastalik.SelectedItem = null;
                cmbDiyetYontemi.SelectedItem = null;
            }
        }
        private Boolean BosGecildiMi() //Alanlarin bos gecilip gecilmedigi bilgisini dondurur.
        {
            if (txtAd.Text == "" || txtSoyad.Text == "" ||
            txtTc.Text == "" || cmbDiyetYontemi.SelectedItem == null || cmbHastalik.SelectedItem == null)
            {
                MessageBox.Show("Hiçbir Alan Boş Geçilemez");
                return true;
            }
            else
            {
                return false; //bos gelcilmediyse ekleme islemi icin izin ver
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            HastaKayitManager hastaKayitManager = new HastaKayitManager();//hasta islemlerinin yapıldıgı sınıftan bir nesne yaratılır
            if (!BosGecildiMi()) //Hicbir alan bos gecilmediyse hastayi ekler.
            {
                //cmbden secilen hastaliga gore hastalik nesnesi olusturulur ve hastaliga atanir            
                hastalik = hastalikFabrikasi.HastalikNesnesiOlustur(cmbHastalik.Text);
                HastaTbl hasta = new HastaTbl //hasta sınıfından bir hasta nesnesi yaratılır
                {
                    HastaAd = txtAd.Text,
                    HastaSoyad = txtSoyad.Text,
                    HastaTc = txtTc.Text,

                    //57 satırda olusan hastaligin hastalikbilgisi getir metodu cagrılarak hastaligin ismi alınır
                    Hastalik = hastalik.HastalikBilgisiniGetir(), 
                    HastaninDiyetisyeni = DiyetisyenGirisIslemleriManager.girisId,
                    DiyetYontemId = diyet.DiyetIdGetir() //secilen diyete gore o diyetin id'si gelecek               
                };

                //hasta kayit edilme islemi başarılı ise true geri donderilir ve kontrol metodu cagrılır
                Kontrol(hastaKayitManager.HastaEkle(hasta));
            }
        }
        private void formuKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formuKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbDiyetYontemi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDiyetYontemi.SelectedItem == null)
            {
                return;
            }

            if (cmbDiyetYontemi.SelectedItem.ToString() == "Akdeniz")
            {

                diyet._diyetYontemiImplementor = new Akdeniz(); //diyetimplementor Akdeniz sınıfından bir nesne olarak tanımlanır

            }
            else if (cmbDiyetYontemi.SelectedItem.ToString() == "Gluten Free")
            {
                diyet._diyetYontemiImplementor = new GlutenFree();
            }

            else if (cmbDiyetYontemi.SelectedItem.ToString() == "Yesillikler Dunyasi")
            {
                diyet._diyetYontemiImplementor = new YesilliklerDunyasi();
            }
            else if (cmbDiyetYontemi.SelectedItem.ToString() == "Deniz Urunleri")
            {
                diyet._diyetYontemiImplementor = new DenizUrunleri();
            }
        }
    }
}
