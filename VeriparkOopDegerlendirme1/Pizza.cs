using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriparkOopDegerlendirme1
{
    public class Pizza
    {
        
        private string pizzaTuru;
        private int fiyat;



        public string PizzaTuru
        {
            get { return pizzaTuru; }

            set
            {
                if (pizzaTuru != null || pizzaTuru != "")
                {
                    pizzaTuru = value;
                }
                else
                {
                    Console.WriteLine("Pizza Türü Boş Olamaz"); 
                }
            }
        }

        public int Fiyat
        {
            get { return fiyat; }

            set
            {
                if (fiyat != null || fiyat != 0)
                {
                    fiyat = value;
                }
                else
                {
                    Console.WriteLine("Pizza Fiyatı Boş Olamaz");
                }
            }
        }

         public Pizza(string pizzaTuru, int pizzaFiyat)
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
