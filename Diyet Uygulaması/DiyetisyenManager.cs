using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DiyetisyenUygulama
{
    public class DiyetisyenManager
    {
        //veritabaniyla ilgili islemleri yapabilmek icin nesne olusturuldu
        DiyetisyenVeriTabaniEntities veriTabani = new DiyetisyenVeriTabaniEntities();
        public Boolean DiyetisyenEkle(DiyetisyenTbl diyetisyen)
        {
            if (!DiyetisyenAdKontrol(diyetisyen))//Diyetisyen kullanıcı adına sahip başka bir diyetisyen yoksa diyetisyeni ekler
            {
                //veritabanına ekler, değişiklikleri kaydedir ve uyarı mesajını ekarana yazdırır.
                veriTabani.DiyetisyenTbl.Add(diyetisyen);
                veriTabani.SaveChanges();
                MessageBox.Show("Diyetisyen Eklendi");
                return true;
            }
            else
            {
                //Ayni kullanici adi ile DiyetisyenTbl'de kayit varsa hata mesaji gosterilir.
                MessageBox.Show("Bu Kullanıcı Adında Bir Diyetisyen Mevcut Yeni Bir Kullanıcı Adı Giriniz!");
                return false;
            }
        }
        
        // Ayni kullanici adina sahip diyetisyenin olup olmadığı kontrol edilir.
        private Boolean DiyetisyenAdKontrol(DiyetisyenTbl diyetisyen) 
        {
            //Diyetisyen tablosundan parametre olarak gelen diyetisyen kullanici adi ile ayni kayit varsa diyetisyenler listelenir.
            var diyetisyenler = from gecici in veriTabani.DiyetisyenTbl 
                                where gecici.DiyetisyenKullaniciAdi == diyetisyen.DiyetisyenKullaniciAdi select gecici;

            //aynı diyetisyen kullanici adina sahip birinin olup olmadığını boolean olarak geri döndürür.
            if (diyetisyenler.Any())
            {
                return true;//aynı kullanıcı adına sahip başka bir diyetisyen yoksa true olarak döner
            }
            else
            {
                return false;//aksi durumda false döner ve diyetisyen için yeni kullanıcı adı istenir.
            }
        }
    }
}
