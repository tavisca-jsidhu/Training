 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Dbl
{
    public interface ICurrencyConverter
    {
        double CurrencyConverter(string fromCurrency, string toCurrency);
    }
}

