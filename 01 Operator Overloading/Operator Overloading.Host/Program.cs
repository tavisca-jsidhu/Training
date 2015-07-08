using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double amountVal;
                string currencyVal;

                Console.WriteLine("Enter 1st Amount : ");
                double.TryParse(Console.ReadLine(),out amountVal);

                Console.WriteLine("Enter Currency : ");
                currencyVal = Console.ReadLine();

                Money m1 = new Money(amountVal, currencyVal);

                Console.WriteLine("Enter 1st Amount : ");
                double.TryParse(Console.ReadLine(), out amountVal);

                Console.WriteLine("Enter Currency : ");
                currencyVal = Console.ReadLine();

                Money m2 = new Money(amountVal, currencyVal);

                Money m3 = m1 + m2;
                Console.WriteLine("\n" + m3.Amount);
                Console.WriteLine(m3.Currency);
            }

            catch (ArgumentException a)
            {
                Console.WriteLine(a);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
