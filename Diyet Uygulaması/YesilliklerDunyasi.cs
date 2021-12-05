using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
    public class YesilliklerDunyasi : DiyetYontemiImplementor
    {       
        public YesilliklerDunyasi()
        {
        //Sınıfın kurucu metodunda DiyetId'ye değer atıyoruz. DiyetListesiTbl'de Yesillikler Dunyası Diyeti 4 numaralı Id'de tutuluyor
            DiyetId = 4;
        }

        //Üst sınıftaki DiyetIdGetir() metodunu ezdik ve Yesillikler Dünyası Diyetinin DiyetId'si return edildi
        public override int DiyetIdGetir()
        {
            return DiyetId;
        }
    }
}
