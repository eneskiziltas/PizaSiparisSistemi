using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriparkOopDegerlendirme1
{
    public static class Util
    {

        public static bool SayiMi(string str)
        {
            return !Int32.TryParse(str, out int sayi);
        }

    }
}
