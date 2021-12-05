using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
   abstract class DiyetYontemiAbstraction
    {
        /*DiyetYontemiImplementor soyut sınıfının bir referansı yazıldı ve bu özellik sayesinde diğer
        sınıflarla iletişim kuruldu.(Bridge Tasarım Deseni)*/
        public DiyetYontemiImplementor _diyetYontemiImplementor { get; set; }
        //Alt sınıflarda kullanılarak ve veritabanındaki DiyetListesiTbl tablosundaki Id'sini getirmek için DiyetIdGetir() metodu yazıldı.
        public abstract int  DiyetIdGetir();

    }
}
