using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DiyetisyenUygulama
{
    class RaporHtml : ReportBuilderBase //Builder Tasarım Deseni
    {
        //Diyet ile ilgili tüm bilgiler oluşturulur ve parametre olarak hasta TC'si alınır
        public override void DiyetBilgisiniYarat(string Tc) //Diyet bilgileri yaratılır.
        {
            sb.Append("<h3>DİYET BİLGİLERİ </h3>"); //Tablonun başlığı yazıldı
            //Tablo görünümü ayarlandı.
            sb.Append("<table class=\"display\" id=\"dt\" style=\"align: left; width: 99%;\" ");
            sb.Append("rules=\"all\" border=\"1px\" ");
            sb.Append("cellspacing=\"0px\" cellpadding=\"4px\">");

            sb.Append("<thead>");
            sb.Append("<tr></tr>");
            sb.Append("<tr style=\"background-color: Silver; color: #212121; ");
            sb.Append("font-weight: bold\">");
           

            sb.Append("<tr> <th>DİYET YÖNTEMİ</th><th>PAZARTESİ</th><th>SALI</th><th>ÇARŞAMBA</th><th>PERŞEMBE" +
                "</th><th>CUMA</th><th>CUMARTESİ</th><th>PAZAR</th></tr>"); //Tablonun sütun isimleri yazıldı
            
            //Eşleşen kayıt getirildi ve DiyetId için join yapıldı.
            var rows2 = from diyetbilgi in veriTabani.DiyetListesiTbl
                        join hastabilgi in veriTabani.HastaTbl on diyetbilgi.DiyetId equals hastabilgi.DiyetYontemId
            
            //Eşleşen kayıt ile ilgili bilgiler tabloya getirildi
           let row = "</td><td>" + diyetbilgi.DiyetAdi + "</td><td>"

           + "<b>Sabah: </b>" + diyetbilgi.Pazartesi_Sabah + "</br>" + "<b>Öğlen: </b>" + diyetbilgi.Pazartesi_Oglen + "</br>" + "<b>Akşam: </b>" + diyetbilgi.Pazartesi_Aksam + "</td><td>"
           + "<b>Sabah: </b>" + diyetbilgi.Salı_Sabah + "</br>" + "<b>Öğlen: </b>" + diyetbilgi.Salı_Oglen + "</br>" + "<b>Akşam: </b>" + diyetbilgi.Salı_Aksam + "</td><td>"
           + "<b>Sabah: </b>" + diyetbilgi.Carsamba_Sabah + "</br>" + "<b>Öğlen: </b>" + diyetbilgi.Carsamba_Oglen + "</br>" + "<b>Akşam: </b>" + diyetbilgi.Carsamba_Aksam + "</td><td>"
           + "<b>Sabah: </b>" + diyetbilgi.Persembe_Sabah + "</br>" + "<b>Öğlen: </b>" + diyetbilgi.Persembe_Oglen + "</br>" + "<b>Akşam: </b>" + diyetbilgi.Persembe_Aksam + "</td><td>"
           + "<b>Sabah: </b>" + diyetbilgi.Cuma_Sabah + "</br>" + "<b>Öğlen: </b>" + diyetbilgi.Cuma_Oglen + "</br>" + "<b>Akşam: </b>" + diyetbilgi.Cuma_Aksam + "</td><td>"
           + "<b>Sabah: </b>" + diyetbilgi.Cumartesi_Sabah + "</br>" + "<b>Öğlen: </b>" + diyetbilgi.Cumartesi_Oglen + "</br>" + "<b>Akşam: </b>" + diyetbilgi.Cumartesi_Aksam + "</td><td>"
           + "<b>Sabah: </b>" + diyetbilgi.Pazar_Sabah + "</br>" + "<b>Öğlen: </b>" + diyetbilgi.Pazar_Oglen + "</br>" + "<b>Akşam: </b>" + diyetbilgi.Pazar_Aksam
           where hastabilgi.HastaTc == Tc 
           select row;

            //Kayıtlar tabloya aktarıldı
            rows2.ToList().ForEach(row => sb.Append("<tr>" + row + "</tr>"));
            sb.Append("</table>");//Tablo kapatıldı
        }

        public override void HastaBilgisiniYarat(string Tc)//Hasta bilgileri yaratıldı
        {

            sb.Append("<h3>HASTA BİLGİLERİ </h3>");//Tablonun başlığı yazıldı
            //Tablo görünümü ayarlandı.
            sb.Append("<table class=\"display\" id=\"dt\" style=\"align: left; width: 99%;\" ");
            sb.Append("rules=\"all\" border=\"1px\" ");
            sb.Append("cellspacing=\"0px\" cellpadding=\"4px\">");

            sb.Append("<thead>");
            sb.Append("<tr></tr>");
            sb.Append("<tr style=\"background-color: Silver; color: #212121; ");
            sb.Append("font-weight: bold\">");
       

            sb.Append("<tr><th> ADI </th><th> SOYADI  </th><th>TC</th> <th> HASTALIK ADI </th>"); //Sutun isimleri yazıldı
            //Eşleşen kayıt için ilgili bilgiler tabloya getirildi
            var rows = from gecici in veriTabani.HastaTbl
                       let row = "<td>" + gecici.HastaAd + "</td><td>" + gecici.HastaSoyad + "</td><td>" + gecici.HastaTc
                       + "</td><td>" + gecici.Hastalik
                       where gecici.HastaTc == Tc
                       select row;

            //getirilen liste ilgili alanlarda tabloya yazıldı.
            rows.ToList().ForEach(row => sb.Append("<tr>" + row + "</tr>"));
            sb.Append("</table>"); //Tablo kapatıldı        
        }

        public override void RaporKaydet()
        {
            //Dosyaya tüm bilgileri yazılır ve dosya Rapor.html formatında oluşturulur.
            System.IO.File.WriteAllText(@"Rapor.html", sb.ToString()); //Dosya çalışma konuma kayıt edilir.
            //Uyarı mesajı yazdırılır.
            MessageBox.Show("Rapor Oluşturuldu Dosyanızı Kontrol Ediniz!");
        }
    }
}
