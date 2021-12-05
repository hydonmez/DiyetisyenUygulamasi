using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
   public abstract class DiyetYontemiImplementor
    {
        protected int DiyetId { get; set; } //Alt sınıflarda her diyet yontemi DiyetId özelliği ile ezilerek atama yapılması için kullanılır.
        public abstract int DiyetIdGetir();/*DiyetYontemiManager sınıfında bulunan DiyetIdGetir() metodunun içerisinde çağırıldı.
                                           Ayrıca bu metodumuz alt sınıflarında ezilerek Id'lerine ulaşıldı.*/
    }
}

