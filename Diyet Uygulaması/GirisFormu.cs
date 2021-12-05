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
    public partial class GirisFormu : Form
    {
        public GirisFormu()
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
        //Admin islemleri icin AdminGirisIslemleriManager sınıfından bir nesne yaratılır
        AdminGirisIslemleriManager adminIslemleri = new AdminGirisIslemleriManager();
        //Diyetisyen islemleri icin DiyetisyenGirisIslemleriManager sınıfından bir nesne yaratılır
        DiyetisyenGirisIslemleriManager diyetisyenIslemleri = new DiyetisyenGirisIslemleriManager();
       
        private void btnAdminGiris_Click(object sender, EventArgs e)
        {

            AdminTbl admin = new AdminTbl();

            //Text'lerdeki bilgiler alınır ve oluşturulan admin nesnesine aktarılır.
            admin.AdminKullaniciAdi = txtAdminKullaniciAdi.Text;
            admin.AdminSifre = txtAdminSifre.Text;
            adminIslemleri.GirisYap(admin);//GirisYap() metoduna admin nesnesi gonderilir
        }

        private void btnDiyetisyenGiris_Click(object sender, EventArgs e)
        {
            DiyetisyenTbl diyetisyen = new DiyetisyenTbl();

            //Text'lerdeki bilgiler alınır ve oluşturulan diyetisyen nesnesine aktarılır.
            diyetisyen.DiyetisyenKullaniciAdi = txtDKullaniciAdi.Text;
            diyetisyen.DiyetisyenSifre = txtDSifre.Text;
            diyetisyenIslemleri.GirisYap(diyetisyen);//GirisYap() metoduna diyetisyen nesnesi gonderilir

        }
    }
}
