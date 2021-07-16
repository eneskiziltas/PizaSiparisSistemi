using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriparkOopDegerlendirme1
{
    class Sipariş
    {
        public Pizzalar PizzaTuru { get; set; }
        public string Ebat { get; set; }
        public string Kenar { get; set; }
        public int Adet { get; set; }
        public double SiparisTutari { get; set; }
        public string SecilenMalzemeler { get; set; }

        public Sipariş(Pizzalar pizzaTuru, string ebat, string kenar, int adet,string secilenMalzemeler)
        {
            PizzaTuru = pizzaTuru;
            Ebat = ebat;
            Kenar = kenar;
            Adet = adet;
            SiparisTutari = 0;
            SecilenMalzemeler = secilenMalzemeler;
        }
        

        public double ebatCarpani(string Ebat)
        {
            if (Ebat == "Küçük")
            {
                return 1;
            }
            else if(Ebat == "Orta")
            {
                return 1.25;
            }
            else if(Ebat == "Büyük")
            {
                return 1.75;
            }
            else if(Ebat == "Maxi")
            {
                return 2;
            }
            else
            {
                return 00000;
            }
            
        }




        public double tutarHesapla()
        {

            if (Kenar == "Kalin")
            {
                return PizzaTuru.Fiyat * ebatCarpani(Ebat)+2;
            }
            else
            {
                return PizzaTuru.Fiyat * ebatCarpani(Ebat);
            } 
            
        }

        public double toplamTutarHesapla()
        {
            return tutarHesapla() * Adet;
        }


        public override string ToString()
        {
            return Ebat+", "+PizzaTuru.PizzaTuru+", "+ Kenar+" Kenar, "+ SecilenMalzemeler+"" + tutarHesapla() +"x"+Adet+"= "+tutarHesapla()*Adet;
        }
    }
}
