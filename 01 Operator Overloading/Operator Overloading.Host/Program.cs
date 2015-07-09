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
                Money m1;
                Money m2;

                Console.WriteLine("Format : 'Amount currency(3 letters)'\n");

                Console.WriteLine("Enter 1st Amount : ");

                input = Console.ReadLine();

                string[] words = input.Split(' ');
                double.TryParse(words[0], out amountVal);
                currencyVal = words[1];

                m1 = new Money(amountVal, currencyVal);

                Console.WriteLine("Enter 2nd Amount : ");

                input = Console.ReadLine();

                string[] words2 = input.Split(' ');
                double.TryParse(words2[0], out amountVal);
                currencyVal = words2[1];

                m2 = new Money(amountVal, currencyVal);

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
