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
                Console.WriteLine("Enter 1st Amount : ");

                Money m1 = new Money(Console.ReadLine());

                Console.WriteLine("Enter 2nd Amount : ");

                Money m2 = new Money(Console.ReadLine());

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
