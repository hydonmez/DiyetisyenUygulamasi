using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
    class Seker : IHastalik //Fabrika Tasarım Deseni
    {
        private string hastalikAdi;
        public Seker()
        {
            hastalikAdi = "Seker Hastaligi";//Kurucu metodunda hastalikAdina atama yaptık
        }
        public string HastalikBilgisiniGetir()
        {
            return hastalikAdi; //Üst sınıfta bulunan metodu ezerek ilgili sınıftaki hastalık adı geri döndürülür.
        }
    }
}
