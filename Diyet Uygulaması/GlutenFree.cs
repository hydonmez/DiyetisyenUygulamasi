using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
    public class GlutenFree : DiyetYontemiImplementor
    {    
        public GlutenFree()
        {
           //Sınıfın kurucu metodunda DiyetId'ye değer atıyoruz. DiyetListesiTbl'de Gluten Free Diyeti 2 numaralı Id'de tutuluyor 
            DiyetId = 2;
        }

        //Üst sınıftaki DiyetIdGetir() metodunu ezdik ve Gluten Free Diyetinin DiyetId'si return edildi.
        public override int DiyetIdGetir()
        {
            return DiyetId;
        }
    }
}
