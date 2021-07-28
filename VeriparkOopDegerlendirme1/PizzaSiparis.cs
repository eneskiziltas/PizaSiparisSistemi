using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriparkOopDegerlendirme1
{
    public class PizzaSiparis : Sipariş
    {
        public Pizza Pizza;
        public string Ebat;
        public string Kenar;



        public PizzaSiparis(Pizza pizza, string ebat, string kenar, int adet)
        {
            Pizza = pizza;
            Ebat = ebat;
            Kenar = kenar;
            Adet = adet;
            SiparisTutari = 0;
        }


        public override double EbatCarpani(string Ebat)
        {
            if (Ebat == "Küçük")
            {
                return 1;
            }
            else if (Ebat == "Orta")
            {
                return 1.25;
            }
            else if (Ebat == "Büyük")
            {
                return 1.75;
            }
            else if (Ebat == "Maxi")
            {
                return 2;
            }
            else
            {
                MessageBox.Show("Gecersiz Ebat Girdiniz!");
                return 0;
            }
        }

        public override double TutarHesapla()
        {
            if (Kenar == "Kalin")
            {
                return Pizza.Fiyat * EbatCarpani(Ebat) + 2;
            }
            else
            {
                return Pizza.Fiyat * EbatCarpani(Ebat);
            }
        }

    


        public override string ToString()
        {
            return Ebat + ", " + Pizza.PizzaTuru + ", " + Kenar + " Kenar, " + SecilenMalzemeler + "" + TutarHesapla() + "x" + Adet + "= " + TutarHesapla() * Adet;
        }


    }
}
