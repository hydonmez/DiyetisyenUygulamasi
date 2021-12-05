using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
  public  class DenizUrunleri: DiyetYontemiImplementor
    {      
        public DenizUrunleri()
        {           
            //Sınıfın kurucu metodunda DiyetId'ye değer atıyoruz. DiyetListesiTbl'de Deniz Ürünleri Diyeti 3 numaralı Id'de tutuluyor       
            DiyetId = 3; 
        }

        //Üst sınıftaki DiyetIdGetir() metodunu ezdik ve Deniz Urunleri Diyetinin DiyetId'si return edildi 
        public override int DiyetIdGetir()
        {
            return DiyetId;
        } 
    }
}
