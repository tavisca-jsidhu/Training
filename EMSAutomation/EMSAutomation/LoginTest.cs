using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EMSAutomation
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void LoginTestMethodSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUN")).SendKeys("akash");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qwerty");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();
            driver.Url.Equals("http://localhost:52792/HRPage.aspx");
        }

        [TestMethod]
        public void LoginTestMethodFailure()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUN")).SendKeys("akash");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qwe");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_LoginUser_response")).Displayed;
            Assert.IsFalse(!status);
        }
    }
}
