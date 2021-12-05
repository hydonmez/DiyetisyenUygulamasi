using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyetisyenUygulama
{
   public class DiyetisyenGirisIslemleriManager
    {
        /*giris yapan diyetisyen ilgili islemleri yapabilmek icin sisteme giren diyetisyen id'si girisId'de
        statik ve her yerden ulasilabilir olacak sekilde tanmlandi*/
        public static int girisId;

        //veritabaniyla ilgili islemleri yapabilmek icin nesne olusturuldu
        DiyetisyenVeriTabaniEntities veriTabani = new DiyetisyenVeriTabaniEntities();

        public void GirisYap(DiyetisyenTbl diyetisyen)//giris yapan diyetisyen bilgileri parametre olarak alınır
        {
            //Diyetisyen kullanıcı adı ve şifresini bulduğunda sonuc'ta tutar
            var sonuc = from gecici in veriTabani.DiyetisyenTbl
                        where gecici.DiyetisyenKullaniciAdi == diyetisyen.DiyetisyenKullaniciAdi
                        && gecici.DiyetisyenSifre == diyetisyen.DiyetisyenSifre
                        select gecici;

            //Giriş yapan diyetisyenin girisId'ye atanir.
            foreach (var diyetisyenBilgileri in sonuc)
            {
                girisId = diyetisyenBilgileri.DiyetisyenId;
            }
            if (sonuc.Any())//sonuc listesinde bir kayıt varsa true döner
            {
                
                    DiyetisyenIslemleriMenuForm diyetisyenIslemleriMenuForm = new DiyetisyenIslemleriMenuForm();
                    diyetisyenIslemleriMenuForm.Show();
                




            }
            else //eşleşen bir diyetisyen kaydi yoksa ekranda hata mesaji gosterir.
            {

                MessageBox.Show("Hatali Giris Yaptiniz!");
               
            }
        }

    }
}
