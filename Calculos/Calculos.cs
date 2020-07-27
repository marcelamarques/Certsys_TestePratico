using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos
{
    public class Calculos
    {
        private double CalcDistMax(double max, double total)
        {
            double qnt = Math.Ceiling(total / max);

            return total / qnt;
        }

        private int CalcPilarReforco(double distPilar, double distReforco)
        {
            return (int) Math.Floor(distReforco / distPilar);
        }

        public double TestCalcDistMax(double one, double two)
        {
            return CalcDistMax(one, two);
        }

        public int TestCalcPilarReforco(double distone, double disttwo)
        {
            return CalcPilarReforco(distone, disttwo);
        }
    }
}
