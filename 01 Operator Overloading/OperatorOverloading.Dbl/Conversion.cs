using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Dbl
{
    public class Conversion : IParser
    {
        Parse p = new Parse();
        static string[] seperatedData;

        public double ConvertCurrency(double sourceAmount, string sourceCurrency, string targetCurrency)
        {
            seperatedData = p.Parsing();
            double rate1 = ExchangeFactor(sourceCurrency);
            double rate2 = ExchangeFactor(targetCurrency);

            return (rate2 / rate1) * sourceAmount;
        }
        //---------------Finding Exchange Factor---------------//
        public static double ExchangeFactor(string currency)
        {
            bool check = false;
            if (currency.Equals("USD"))
            {
                return 1;
            }
            int j;
            for (j = 0; j < seperatedData.Length; j++)
            {
                if (seperatedData[j].Contains(currency))
                {
                    check = true;
                    break;
                }
            }
            if (check == false)
            {
                throw new System.Exception(Exception.InvalidCurrency);
            }
            string[] finalSplit = seperatedData[j].Split(':');
            double multiplier = Convert.ToDouble(finalSplit[1]);
            return multiplier;
        }
    }
}
