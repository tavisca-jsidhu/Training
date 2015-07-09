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

        public string Currency
        {
            private set
            {
                if (string.IsNullOrEmpty(value) || (value.Length != 3))
                {
                    throw new ArgumentException(Messages.WrongFormat);
                }
                else
                {
                    this._currency = value;
                }
            }
            get
            {
                return this._currency;
            }
        }

        public static Money operator +(Money m1, Money m2)
        {
            if (m1.Currency.Equals(m2.Currency, StringComparison.InvariantCultureIgnoreCase))
            {
                double amount = m1._amount + m2._amount;
                string currency = m1._currency;
                if (amount >= double.MaxValue)
                {
                    throw new ArgumentException(Messages.OutOfRange);  // throw exception if amount is negative
                }
                return new Money(amount, currency);
            }
            else
            {
                throw new System.Exception(Messages.NoMatch); //exception for currency
            }
        }
    }
}
