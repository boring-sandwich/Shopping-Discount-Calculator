using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Discount_Calculator
{
    static class DiscountCalculations
    {
        public static double PaidToOriginal(double dblPaid, int intValue)
        {
            double dblAns = 100 - intValue;
            dblAns = dblPaid / dblAns;
            dblAns = dblAns * 100;
            return dblAns;
        }

        public static double AddTax(double dblPaid, double dblTax)
        {
            double dblAns = (dblPaid / 100) * dblTax;
            dblAns = dblAns + dblPaid;
            return dblAns;

        }

        public static double YouSave(double dblPrice, int intValue)
        {
            double dblAns = (dblPrice / 100) * intValue;
            return dblAns;
        }

        public static double DiscountPrice(double dblPrice, int intValue)
        {
            double dblAns = (dblPrice / 100) * intValue;
            dblAns = dblPrice - dblAns;
            return dblAns;
        }
    }
}
