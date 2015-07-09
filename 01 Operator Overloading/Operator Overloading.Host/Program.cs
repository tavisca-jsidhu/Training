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
                string input;

                Console.WriteLine("Enter 1st Amount : ");
                //double.TryParse(Console.ReadLine(),out amountVal);

                input = Console.ReadLine();

                //Console.WriteLine("Enter Currency : ");
                //currencyVal = Console.ReadLine();

                string[] words = input.Split(' ');
                double.TryParse(string[0],out amountVal);
                currencyVal = string[1];

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
            catch (Exception e)    // exception catched
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
