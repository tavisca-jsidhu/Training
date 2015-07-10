using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntergrationTest;
using OperatorOverloading.Model;

namespace IntergrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOperatorOverloadingTest1()
        {
            var m1 = new Money("100 USD");
            double exchangedRate = m1.ExchangeValue(m1.Amount, m1.Currency, "INR");

            Assert.IsTrue(exchangedRate == 6342.5449);
        }

        [TestMethod]
        public void AddOperatorOverloadingTest2()
        {
            var m1 = new Money("100 usD");
            double exchangedRate = m1.ExchangeValue(m1.Amount, m1.Currency, "INr");

            Assert.IsTrue(exchangedRate == 6342.5449);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void AddOperatorOverloadingTest3()
        {
            var m1 = new Money("100 HKD");
            double exchangedRate = m1.ExchangeValue(m1.Amount, m1.Currency, "40");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void AddOperatorOverloadingTest4()
        {
            var m1 = new Money("100USD");
            double exchangedRate = m1.ExchangeValue(m1.Amount, m1.Currency, "INR");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void AddOperatorOverloadingTest5()
        {
            var m1 = new Money("100 USD");
            double exchangedRate = m1.ExchangeValue(m1.Amount, m1.Currency, null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void AddOperatorOverloadingTest6()
        {
            var m1 = new Money("100 IR");
            double exchangedRate = m1.ExchangeValue(m1.Amount, m1.Currency, "USD");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void AddOperatorOverloadingTest7()
        {
            var m1 = new Money(null);
            double exchangedRate = m1.ExchangeValue(m1.Amount, m1.Currency, "INR");
        }
    }
}
