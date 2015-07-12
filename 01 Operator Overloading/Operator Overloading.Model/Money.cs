using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Dbl;

namespace OperatorOverloading.Model
{
    public class Money : ICurrencyConverter
    {
        private double _amount;
        private string _currency;

        //---------------Single Parameter Constructer--------------//
        public Money(string inputAmount)  //Input Format <100 USD>
        {
            if (string.IsNullOrWhiteSpace(inputAmount))
            {
                throw new Exception(Messages.InvalidInput);
            }
            var amountArr = inputAmount.Split(' ');
            double amount;
            if (amountArr.Length != 2)
            {
                throw new Exception(Messages.InvalidInput);
            }
            if (double.TryParse(amountArr[0], out amount))
            {
                Amount = amount;
            }
            else
            {
                throw new Exception(Messages.InvalidInput);
            }
            Currency = amountArr[1];
        }

        //----------------Constructor-------------//
        public Money(double amount, string currency)  // constructor
        {
            Amount = amount;
            Currency = currency;
        }

        //---------------Amount Property-------------//
        public double Amount
        {
            get
            {
                return this._amount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();  // throw exception if amount is negative
                }
                else if (double.IsPositiveInfinity(value))
                {
                    throw new ArgumentException(Messages.OutOfRange);
                }
                else
                {
                    this._amount = value;
                }
            }
        }
        //----------------Currency Property----------------//
        public string Currency
        {
            get
            {
                return this._currency;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || (value.Length != 3))
                {
                    throw new ArgumentException(Messages.WrongFormat);
                }
                else
                {
                    this._currency = value.ToUpper();
                }
            }
        }
        //----------------Operator Overloading---------------//
        public static Money operator +(Money m1, Money m2)
        {
            if (m1 == null || m2 == null)
            {
                throw new Exception(Messages.NullObject);
            }
            else
            {
                if (m1.Currency.Equals(m2.Currency, StringComparison.InvariantCultureIgnoreCase))
                {
                    double amount = m1._amount + m2._amount;
                    if (amount >= double.MaxValue)
                    {
                        throw new ArgumentException(Messages.OutOfRange);  // throw exception if amount is negative
                    }
                    return new Money(amount, m1._currency);
                }
                else
                {
                    throw new System.Exception(Messages.NoMatch); //exception for currency
                }
            }
        }

        //------------------Convert Function--------------------// 
        public Money Convert(string targetCurrency) // function called by Main()
        {
            double amount = CurrencyConverter(this.Currency, targetCurrency) * this.Amount;
            return new Money(amount, targetCurrency);
        }

        //-----------------CurrencyConverter Function------------------//
        public double CurrencyConverter(string fromCurrency, string toCurrency)
        {
            Parse parseObject = new Parse();
            double rate1 = parseObject.CurrencyRate(fromCurrency); // getting rate of source currency with respect to reference currency
            double rate2 = parseObject.CurrencyRate(toCurrency);  // getting rate of target currency with respect to reference currency
            if (rate1 == 0)
            {
                throw new Exception(Messages.DivideByZero);
            }
            return (rate2 / rate1); // returning rate of target currency with respect to source currency
        }
    }
}
