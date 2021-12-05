using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyetisyenUygulama
{
   public class HastaKayitManager
    {
        //veritabaniyla ilgili islemleri yapabilmek icin nesne olusturuldu
        DiyetisyenVeriTabaniEntities veriTabani = new DiyetisyenVeriTabaniEntities();

        public Boolean HastaEkle(HastaTbl hasta) //Hastanın tc'sine sahip başka bir hasta yoksa hastayı  veritabanına ekler
        {
            if (!HastaTcKontrol(hasta))
            {
                //veritabanına ekler, değişiklikleri kaydedir ve uyarı mesajını ekarana yazdırır.
                veriTabani.HastaTbl.Add(hasta);
                veriTabani.SaveChanges();
                MessageBox.Show("Hasta Eklendi");
                return true;
            }
            else
            {
                //Ayni tc ile kayit varsa hata mesaji gosterilir.
                MessageBox.Show("Farklı Bir TC Giriniz!");
                return false;
            }
        }

        private Boolean HastaTcKontrol(HastaTbl hasta)//Hastanın tc'sini kontrol eder
        {
            //Hasta tablosundan parametre olarak gelen hasta tc'si ile ayni kayit varsa hastalar listelenir.
            var hastalar = from gecici in veriTabani.HastaTbl
                                where gecici.HastaTc == hasta.HastaTc
                                select gecici;

            //aynı tc ye sahip hastanın olup olmadığını boolean olarak geri döndürür.
            if (hastalar.Any() )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
