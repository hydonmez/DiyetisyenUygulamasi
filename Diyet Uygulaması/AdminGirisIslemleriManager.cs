using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyetisyenUygulama
{
   public class AdminGirisIslemleriManager
    {
        //veritabaniyla ilgili islemleri yapabilmek icin nesne olusturuldu
        DiyetisyenVeriTabaniEntities veriTabani = new DiyetisyenVeriTabaniEntities();
        public void GirisYap(AdminTbl admin)//Parametre olarak admin nesnesi aliyoruz. 
        {
            //Parametre olarak gelen nesne ile veritabaninda bulunan AdminTbl deki eşleşen veriyi sonuca atar.
            var sonuc = from gecici in veriTabani.AdminTbl
                        where gecici.AdminKullaniciAdi == admin.AdminKullaniciAdi
                        && gecici.AdminSifre == admin.AdminSifre
                        select gecici;

            //Liste boş değilse yani admin bulunduysa diyetisyen kayit formu açılır
            if (sonuc.Any()) 
            {
                //Formunu acmak icin DiyetisyenKayitFormu sinifinin nesnesini yarattık
                DiyetisyenKayitFormu kayitFormu = new DiyetisyenKayitFormu(); 
                kayitFormu.Show();
            }
            else
            {
                //Eğer veri tabanında eşleşen admin yoksa uyarı mesajı yazdırılır
                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }

    }
}
