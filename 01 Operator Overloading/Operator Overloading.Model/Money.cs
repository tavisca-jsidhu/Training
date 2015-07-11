using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Dbl;

namespace OperatorOverloading.Model
{
    public class Money
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
        //---------------Currency Property-------------//
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

        //------------------Convert Currency Function--------------------//    
        string[] seperatedData;
        public Money ConvertCurrency(string targetCurrency)
        {
            Parse parseObject = new Parse();
            double sourceAmount = this.Amount;
            string sourceCurrency = this.Currency;
            seperatedData = parseObject.Parsing();
            double rate1 = CurrencyExchangeFactor(sourceCurrency);
            double rate2 = CurrencyExchangeFactor(targetCurrency);
            if (rate2 / rate1 == 0)
            {
                throw new Exception("Divide by zero error.");
            }
            double amount = (rate2 / rate1) * sourceAmount;
            Money moneyObject = new Money(amount, targetCurrency);
            return moneyObject;

        }
        //---------------Finding Exchange Factor---------------//
        public double CurrencyExchangeFactor(string currency)
        {
            bool isPresent = false;
            int iterate;
            for (iterate = 0; iterate < seperatedData.Length; iterate++)
            {
                if (seperatedData[iterate].Contains(currency))
                {
                    isPresent = true;
                    break; 
                }
            }
            if (isPresent == false)
            {
                throw new System.Exception(Messages.CurrencyNotPresent);
            }
            string[] finalSplit = seperatedData[iterate].Split(':');
            double multiplier;
            Double.TryParse(finalSplit[1], out multiplier);
            return multiplier;
        }
    }
}
