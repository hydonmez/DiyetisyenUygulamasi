using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyetisyenUygulama
{
    public class ReportManager //Builder Tasarım Deseni - Client sadece bu sınıfı tanır. 
    {
        //Abstract sınıf olan ReportBuilderBase sınıfından bir özellik oluşturuyoruz.
        private ReportBuilderBase _reportBuilder; 
        
        public ReportManager(ReportBuilderBase report) //Kurucu metodu ReportBuilderBase tipinde bir parametre alır
        {
            _reportBuilder = report;//gelen parametre _reportBuilder'a atanır.
        }
        public void HtmlHastaDiyetFormati(string Tc)//İlk önce Hasta Bilgileri daha sonra Diyet Bilgileri html formatında getirilir.
        {
           _reportBuilder.HastaBilgisiniYarat(Tc);//_reportBuilder'dan dönen diyet bilgisi rapora eklenir.
           _reportBuilder.DiyetBilgisiniYarat(Tc);
        }
        public void HtmlDiyetHastaFormati(string Tc)//İlk önce Diyet Bilgileri daha sonra Hasta Bilgileri html formatında getirilir.
        {
           _reportBuilder.DiyetBilgisiniYarat(Tc);
          _reportBuilder.HastaBilgisiniYarat(Tc);
        }
        public void JsonHastaDiyetFormati(string Tc)//İlk önce Hasta Bilgileri daha sonra Diyet Bilgileri json formatında getirilir.
        {
            _reportBuilder.HastaBilgisiniYarat(Tc);
            _reportBuilder.DiyetBilgisiniYarat(Tc);
        }
        public void JsonDiyetHastaFormati(string Tc)//İlk önce Diyet Bilgileri daha sonra Diyet Hasta json formatında getirilir.
        {
            _reportBuilder.DiyetBilgisiniYarat(Tc);
            _reportBuilder.HastaBilgisiniYarat(Tc);
        }
        public void RaporAl()
        {
            //Soyut sınıfta bulunan (ReportBuilderBase) RaporKaydet() metoduna erişilir ve uygun formatta Rapor alınır
            _reportBuilder.RaporKaydet(); 
        }
    }
}
