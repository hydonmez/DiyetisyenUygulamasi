using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
    public class Akdeniz : DiyetYontemiImplementor
    {           
        public Akdeniz()
        {
            //Sınıfın kurucu metodunda DiyetId'ye değer atıyoruz. DiyetListesiTbl'de Akdeniz Diyeti 1 numaralı Id'de tutuluyor 
            DiyetId = 1;       
        }

        //Üst sınıftaki DiyetIdGetir() metodunu ezdik ve Akdeniz diyetinin DiyetId'si return edildi
        public override int DiyetIdGetir()
        {
            return DiyetId;
        }
    }
}
