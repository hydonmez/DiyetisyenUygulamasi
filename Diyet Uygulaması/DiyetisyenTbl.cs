//------------------------------------------------------------------------------
// <auto-generated>
//    Bu kod bir şablondan oluşturuldu.
//
//    Bu dosyada el ile yapılan değişiklikler uygulamanızda beklenmedik davranışa neden olabilir.
//    Kod yeniden oluşturulursa, bu dosyada el ile yapılan değişikliklerin üzerine yazılacak.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiyetisyenUygulama
{
    using System;
    using System.Collections.Generic;
    
    public partial class DiyetisyenTbl
    {
        public DiyetisyenTbl()
        {
            this.HastaTbl = new HashSet<HastaTbl>();
        }
    
        public int DiyetisyenId { get; set; }
        public string DiyetisyenAd { get; set; }
        public string DiyetisyenSoyad { get; set; }
        public string DiyetisyenTc { get; set; }
        public string DiyetisyenKullaniciAdi { get; set; }
        public string DiyetisyenSifre { get; set; }
    
        public virtual ICollection<HastaTbl> HastaTbl { get; set; }
    }
}
