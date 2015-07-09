using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double _amount;
        private string _currency;

        public Money(double amountVal, string currencyVal)  // constructor
        {
            Amount = amountVal;
            Currency = currencyVal;
        }

        public Money(string str)
        {
            double amt;
            string[] words = str.Split(' ');
            double.TryParse(string[0],out amt);
            Amount = amt;
            Currency = string[1];
        }

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
                    throw new ArgumentException(Messages.NegativeVal);  // throw exception if amount is negative
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

        public string Currency
        {
            get
            {
                return this._currency;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Messages.NullVal);
                }
                else
                {
                    this._currency = value;
                }
            }
        }

        public static Money operator +(Money m1, Money m2)
        {
            if (m1.Currency.Equals(m2.Currency, StringComparison.InvariantCultureIgnoreCase))
                {
                    Money m3 = new Money(0," ");

                    m3._amount = m1._amount + m2._amount;
                    m3._currency = m1._currency;
                    if (m3.Amount >= double.MaxValue)
                    {
                        throw new ArgumentException(Messages.OutOfRange);  // throw exception if amount is negative
                    }
                    return m3;
                }
                else
                {
                    throw new System.Exception(Messages.NoMatch); //exception for currency
                }
        }
    }
}
