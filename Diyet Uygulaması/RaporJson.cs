using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;


namespace DiyetisyenUygulama
{
    class RaporJson : ReportBuilderBase //Builder Tasarım Deseni
    {
        //Üst sınıfta bulanan metot ezilerek Diyet Bilgisi yaratılarak json için hazırlandı
        public override void DiyetBilgisiniYarat(string Tc) 
        {
            int diyetId; //istenilen diyet yönteminin Id'sinin tutulası için tanımlandı

            //Metotdan gelen hasta tc'si ile veritabanında bulanan hasta getirilir
            var hasta = from hastabilgisi in veriTabani.HastaTbl where hastabilgisi.HastaTc == Tc select hastabilgisi;
            DiyetBilgisi diyetBilgisi = new DiyetBilgisi(); //DiyetBilgisi sınıfından bir nesne üretildi json için
            
            foreach (var item in hasta)//eşleşen tc bilgisine ait hastanın diyet bilgilerine erişilir.
            {
                diyetId = item.DiyetYontemId;
                
                //İlgili diyet bilgileri sonuc'a aktarılır.
                var sonuc = from gecici in veriTabani.DiyetListesiTbl where gecici.DiyetId == diyetId select gecici;
                
                foreach (var item2 in sonuc)//sonuc listesi üzerinden dönülerek diyet bilgileri diyetBilgisi nesnesine aktarılır.
                {
                    diyetBilgisi.DiyetAdi = item2.DiyetAdi;
                    diyetBilgisi.DiyetId = item2.DiyetId;

                    diyetBilgisi.Pazartesi_Sabah = item2.Pazartesi_Sabah;
                    diyetBilgisi.Pazartesi_Oglen = item2.Pazartesi_Oglen;
                    diyetBilgisi.Pazartesi_Aksam = item2.Pazartesi_Aksam;

                    diyetBilgisi.Salı_Sabah = item2.Salı_Sabah;
                    diyetBilgisi.Salı_Oglen = item2.Salı_Oglen;
                    diyetBilgisi.Salı_Aksam = item2.Salı_Aksam;

                    diyetBilgisi.Carsamba_Sabah = item2.Carsamba_Sabah;
                    diyetBilgisi.Carsamba_Oglen = item2.Carsamba_Oglen;
                    diyetBilgisi.Carsamba_Aksam = item2.Carsamba_Aksam;

                    diyetBilgisi.Persembe_Sabah = item2.Persembe_Sabah;
                    diyetBilgisi.Persembe_Oglen = item2.Persembe_Oglen;
                    diyetBilgisi.Persembe_Aksam = item2.Persembe_Aksam;

                    diyetBilgisi.Cuma_Sabah = item2.Cuma_Sabah;
                    diyetBilgisi.Cuma_Oglen = item2.Cuma_Oglen;
                    diyetBilgisi.Cuma_Aksam = item2.Cuma_Aksam;

                    diyetBilgisi.Cumartesi_Sabah = item2.Cumartesi_Sabah;
                    diyetBilgisi.Cumartesi_Oglen = item2.Cumartesi_Oglen;
                    diyetBilgisi.Cumartesi_Aksam = item2.Cumartesi_Aksam;

                    diyetBilgisi.Pazar_Sabah = item2.Pazar_Sabah;
                    diyetBilgisi.Pazar_Oglen = item2.Pazar_Oglen;
                    diyetBilgisi.Pazar_Aksam = item2.Pazar_Aksam;
                }
            }
            sb.Append(JsonConvert.SerializeObject(diyetBilgisi));//diyetBilgisi'ni json yazma formatına çevirir
        }

        public override void HastaBilgisiniYarat(string Tc)//Hastalık ile ilgili bilgiler yaratılarak json formatına getirilir
        {
         HastaBilgisi hastaBilgisi = new HastaBilgisi();/*HastaTbl'de bulanan özellikler HastaBilgisi sınıfına yazıldı sınıfın
                                                        nesnesi oluşturuldu ve HastaTbl'de bulanan özellikler json için bu nesneye atandı */
         
         //Metotdan gelen tc ile eşleşen hasta tc'si getirildi
         var sorgu = from gecici in veriTabani.HastaTbl where gecici.HastaTc == Tc select gecici;

            foreach (var item in sorgu) //Hasta bilgileri alındı
            {
                hastaBilgisi.HastaId=item.HastaId;
                hastaBilgisi.Hastalik = item.Hastalik;
                hastaBilgisi.DiyetYontemi = item.DiyetYontemId;
                hastaBilgisi.Ad = item.HastaAd;
                hastaBilgisi.Soyad = item.HastaSoyad;
                hastaBilgisi.Tc = item.HastaTc;               
            }

          sb.Append ( JsonConvert.SerializeObject(hastaBilgisi));//hastaBilgisi'ni json yazma formatına çevirir           
        }

        public override void RaporKaydet()//Rapor kaydedilir.
        {
            //Bilgiler Rapor.json dosyasına yazılır
            File.WriteAllText(@"Rapor.json", sb.ToString());//Dosya çalışma konuma kayıt edilir.
            //Uyarı mesajı yazdırılır.
            MessageBox.Show("Rapor Oluşturuldu Dosyanızı Kontrol Ediniz!");
        }

        class HastaBilgisi //Hasta bilgilerini json'a yazmak için oluşturuldu
        {     
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Tc { get; set; }
            public string Hastalik { get; set; }
            public int DiyetYontemi { get; set; }
            public int HastaId { get; set; }
        }
        class DiyetBilgisi //Diyet bilgilerini json'a yazmak için oluşturuldu
        {
            public int DiyetId { get; set; }
            public string DiyetAdi { get; set; }
            public string Pazartesi_Sabah { get; set; }
            public string Pazartesi_Oglen { get; set; }
            public string Pazartesi_Aksam { get; set; }
            public string Salı_Sabah { get; set; }
            public string Salı_Oglen { get; set; }
            public string Salı_Aksam { get; set; }
            public string Carsamba_Sabah { get; set; }
            public string Carsamba_Oglen { get; set; }
            public string Carsamba_Aksam { get; set; }
            public string Persembe_Sabah { get; set; }
            public string Persembe_Oglen { get; set; }
            public string Persembe_Aksam { get; set; }
            public string Cuma_Sabah { get; set; }
            public string Cuma_Oglen { get; set; }
            public string Cuma_Aksam { get; set; }
            public string Cumartesi_Sabah { get; set; }
            public string Cumartesi_Oglen { get; set; }
            public string Cumartesi_Aksam { get; set; }
            public string Pazar_Sabah { get; set; }
            public string Pazar_Oglen { get; set; }
            public string Pazar_Aksam { get; set; }
        }       
    }
}
