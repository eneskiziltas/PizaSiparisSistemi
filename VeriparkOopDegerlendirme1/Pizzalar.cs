using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriparkOopDegerlendirme1
{
    public class Pizzalar
    {

        public string PizzaTuru { get; set; }
        public int Fiyat { get; set; }
        public Pizzalar(string pizzaTuru, int pizzaFiyat)
        {
            PizzaTuru = pizzaTuru;
            Fiyat = pizzaFiyat;
        }


        public override string ToString()
        {
            return PizzaTuru;
        }

    }

   

   
}
