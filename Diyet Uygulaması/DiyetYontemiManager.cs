using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
    class DiyetYontemiManager : DiyetYontemiAbstraction
    {
        public override int DiyetIdGetir()  
        {
            /*DiyetYontemiAbstraction sınıfında bulunan DiyetIdGetir()  metodu burada ezildi. */

           /*DiyetImplementor 'a Client sınıfta yaratılan nesne olduğu için hangi diyet sınıfından nesne türetilmişse o diyet 
            sınıfının metodunu çağırır ve sonucu geri döndürür*/
            return _diyetYontemiImplementor.DiyetIdGetir(); 
        }
    }
}

