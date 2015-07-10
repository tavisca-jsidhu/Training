 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Dbl
{
    public interface IParser
    {
        double ConvertCurrency(double amount, string source, string target);
    }
}

