using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;
using OperatorOverloading.Dbl;

namespace OperatorOverloading.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Format : 100 USD");

                Console.WriteLine("\nEnter Amount : "); // Enter Amount in Format '100 USD'
                var m1 = new Money(Console.ReadLine());

                Console.WriteLine("\nEnter target Currency : "); // Enter target currency
                string target = Console.ReadLine();
                Console.WriteLine("\nExchanged Amount : ");

                double exchangedRate = m1.ExchangeValue(m1.Amount, m1.Currency, target);
                Console.WriteLine("{0} {1}", exchangedRate, target.ToUpper());
            }

            catch (ArgumentException a)
            {
                Console.WriteLine(a.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
