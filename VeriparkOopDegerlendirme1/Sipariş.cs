using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriparkOopDegerlendirme1
{
    public abstract class Sipariş
    {

        public double SiparisTutari;
        public string SecilenMalzemeler { get; set; }

        private int adet;

        public int Adet
        {
            get { return adet; }

            set
            {
                if (value > 0)
                {
                    adet = value;
                }
                else
                {
                    MessageBox.Show("Adet Sayisi Sifirdan Buyuk Olmali");
                }
            }
        }

        

        public abstract double EbatCarpani(string Ebat);
        public abstract double TutarHesapla();

        public double ToplamTutarHesapla(int adet)
        {
            return TutarHesapla() * adet;
        }
  
        
        
        
        
        
        
        
        
        
        
        
        
        
        /* public Pizza PizzaTuru { get; set; }
        public string Ebat { get; set; }
        public string Kenar { get; set; }*/


        /* public Sipariş(Pizza pizzaTuru, string ebat, string kenar, int adet,string secilenMalzemeler)
         {
             PizzaTuru = pizzaTuru;
             Ebat = ebat;
             Kenar = kenar;
             Adet = adet;
             SiparisTutari = 0;
             SecilenMalzemeler = secilenMalzemeler;
         }*/


     
       /* public double tutarHesapla()
        {

            if (Kenar == "Kalin")
            {
                return PizzaTuru.Fiyat * ebatCarpani(Ebat)+2;
            }
            else
            {
                return PizzaTuru.Fiyat * ebatCarpani(Ebat);
            } 
            
        }*/

        
       


        /*public override string ToString()
        {
            return Ebat+", "+PizzaTuru.PizzaTuru+", "+ Kenar+" Kenar, "+ SecilenMalzemeler+"" + tutarHesapla() +"x"+Adet+"= "+tutarHesapla()*Adet;
        }*/
    }

    
}
