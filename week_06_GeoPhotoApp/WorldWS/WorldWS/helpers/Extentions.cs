using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldWS.helpers
{
    public static class Extentions
    {
        public static int? ToNInt(this String tekst)
        {
            int i = 0;
            int? ni;
            if (!int.TryParse(tekst, out i))
                ni = new int?();
            else
                ni = i;
            return ni;
        }
        public static double? ToNDouble(this String tekst)
        {
            double d = 0;
            double? nd;
            if (!double.TryParse(tekst, out d))
                nd = new double?();
            else
                nd = d;
            return nd;
        }
    }
}
