﻿using System;
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
                var m2 = new Money(0, Console.ReadLine()); 

                var exchangedRate = m1.Convert(m2.Currency);
                Console.WriteLine("\nExchanged Amount : {0} {1} ", exchangedRate.Amount, exchangedRate.Currency);
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
