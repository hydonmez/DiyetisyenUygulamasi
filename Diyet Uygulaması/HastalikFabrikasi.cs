using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
    public class HastalikFabrikasi //Fabrika Tasarım Deseni
    {
        public IHastalik HastalikNesnesiOlustur(string hastalikAdi) //Gelen hastalık adına göre ilgili hastalığın nesnesini oluşturur
        {
          //İlgili nesneyi return eder.
            if(hastalikAdi == "Colyak Hastaligi")
            {
                return new Colyak();
            }
            else if (hastalikAdi == "Seker Hastaligi")
            {
                return new Seker();
            }
            else 
            {
                return new  Obez();
            }

        }
    }
}
