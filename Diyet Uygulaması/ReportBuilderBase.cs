using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
    public abstract class ReportBuilderBase //Builder Tasarım Deseni
    {
        //veritabanına erişebilmek için veritabanından bir nesne yaratıldı
        protected DiyetisyenVeriTabaniEntities veriTabani = new DiyetisyenVeriTabaniEntities();
        //StringBuilder kütüphanesinden bir nesne yaratıldı oluşan rapor bilgilerini bir arada tutmak için yaratıldı
        protected StringBuilder sb = new StringBuilder(); 
        
        /*ReportManager sınıfında bu üç metoda erişilir
        Alt sınıflarda ezilerek diyet bilgisi ve hasta bilgisi yaratılır tc parametre olarak alınır*/
        public abstract void  HastaBilgisiniYarat(string Tc); 
        public abstract void  DiyetBilgisiniYarat(string Tc);
        public abstract void RaporKaydet(); //Raporu kaydetmek için gerekli işlemleri yapar
    }
}
