using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenUygulama
{
    public interface IHastalik //Fabrika Tasarım Deseni
    {     
        string HastalikBilgisiniGetir();//Hastalık adına ulaşabilmek için interfacede bir metod tanımladık.
    }
}
