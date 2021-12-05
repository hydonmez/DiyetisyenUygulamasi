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
    public partial class RaporFormu : Form
    {
        private ReportBuilderBase builder; //ReportBuilder sınıfından bir özellik tanımlandı
        private ReportManager rapor; //ReportManager sınıfından bir özellik tanımlandı
        public RaporFormu()
        {
            InitializeComponent();
        }

        private void formuKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formuKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//formu asagi atar 
        }

        private void btnRaporAl_Click(object sender, EventArgs e)
        {
            if (KontrolEt())//Alanlar boş değilse  
            {
                if (TcKontrol(txtTc.Text)) //Girilen Tc'ye sahip bir hasta varsa raporu alınır
                {
                    rapor.RaporAl();//yaratilan nesnenin raporAl fonksiyonuna erisilir
                }
                else
                {   
                    //Girilen Tc'ye sahip bir hasta yoksa uyarı mesajı yazdırır
                    MessageBox.Show("Girilen TC ile Eşleşen Bir Kayıt Bulunmadı");
                }

            }
            else
            {
                MessageBox.Show("Hiçbir Alan Boş Geçilemez!");
            }
        }
        private Boolean KontrolEt() //Alanlar boş mu diye kontrol eder
        {
            if (cmbRaporTipi.SelectedItem == null || txtTc.Text == "")
            {
               
                return false; //alanlar boşsa false degeri dönderilir
            }
            else
            {   
                //Hiçbir alan boş değilse true döner.
                return true;
            }
        }

        private Boolean TcKontrol(string hastaTc)//Rapor alınmak istenen hastanın Tc'si veritabanında var mı diye kontrol eder.
        {
            DiyetisyenVeriTabaniEntities veriTabani = new DiyetisyenVeriTabaniEntities();
            var sorgu = from gecici in veriTabani.HastaTbl where gecici.HastaTc == hastaTc select gecici;

            if (sorgu.Any())//sorgu bos degilse true dondurulur hasta var anlamına gelir 
            {
                return true;
            }
            else
            {
                cmbRaporTipi.SelectedItem = null;
                txtTc.Text = "";
              
                return false;
            }
        }
        private void cmbRaporTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //İstenilen rapor formatına göre nesne yaratılır ve ilgili nesnesinin istenilen kombinasyonu fonksiyonu çağırılır.
            if (cmbRaporTipi.SelectedItem == null)
            {
                return; //nullsa geriye donderilirir
            }

            if (cmbRaporTipi.SelectedItem.ToString() == "HTML Hasta Bilgisi Diyet Bilgisi")
            {
                builder = new RaporHtml();       //html formatında isteniliyorsa ilk once html nesnesi yaratılır ve buildera atanır
                rapor = new ReportManager(builder);//rapor manager nesnesinin kurucu metoduna builder nesnesi gonderilir

                rapor.HtmlHastaDiyetFormati(txtTc.Text);//rapor nesnesinin htmlhastadiyet sıralaması şekklinde rapor veren formatı cagrılır
            }
            else if (cmbRaporTipi.SelectedItem.ToString() == "HTML Diyet Bilgisi Hasta Bilgisi")
            {
                builder = new RaporHtml();
                rapor = new ReportManager(builder);

                rapor.HtmlDiyetHastaFormati(txtTc.Text);
            }
            else if (cmbRaporTipi.SelectedItem.ToString() == "JSON Diyet Bilgisiİ Hasta Bilgisi")
            {
                builder = new RaporJson();
                rapor = new ReportManager(builder);
                rapor.JsonDiyetHastaFormati(txtTc.Text);
            }
            else if (cmbRaporTipi.SelectedItem.ToString() == "JSON Hasta Bilgisi Diyet Bilgisi")
            {
                builder = new RaporJson();
                rapor = new ReportManager(builder);
                rapor.JsonHastaDiyetFormati(txtTc.Text);
            }
        }


    }
}
