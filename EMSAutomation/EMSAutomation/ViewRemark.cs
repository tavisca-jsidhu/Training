using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EMSAutomation
{
    [TestClass]
    public class ViewRemark
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void ViewRemarkTestMethodSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUN")).SendKeys("jas");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("jas");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();

            driver.FindElement(By.Id("FeaturedContent_EmpViewRemark_GridView1")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_EmpViewRemark_Failure")).Displayed;
        }

        [TestMethod]
        public void ViewRemarkTestMethodFailure()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUN")).SendKeys("jas");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qw");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();

            driver.FindElement(By.Id("FeaturedContent_EmpViewRemark_GridView1")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_EmpViewRemark_Failure")).Displayed;
            Assert.IsTrue(status);
        }
    }
}
