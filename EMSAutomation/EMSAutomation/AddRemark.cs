using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EMSAutomation
{
    [TestClass]
    public class AddRemarkTest
    {
        [TestMethod]
        public void AddRemarkTestMethodSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUN")).SendKeys("akash");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qwerty");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_AddRemark")).Click();

            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_DropDownList1")).SendKeys("jassi");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_TextArea1")).SendKeys("remark no. 123");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_ButtonAddRemark")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_Success")).Displayed;
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void AddRemarkTestMethodFailure()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUN")).SendKeys("akash");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qwerty");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_AddRemark")).Click();

            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_DropDownList1")).SendKeys("qwerty");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_TextArea1")).SendKeys("remark no. 123");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_ButtonAddRemark")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_Failure")).Displayed;
            Assert.IsTrue(status);
        }
    }
}
