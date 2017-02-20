using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Resources;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using MbUnit.Framework;
using Admin_Portal_Test_Suite;

namespace Admin_Portal_Test_Suite.Objects
{
    public class AddAClient
    {
        private IWebDriver driver;

        public AddAClient(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo()
        {
            driver.FindElement(By.CssSelector("A.mainbutton.inline-block.r")).Click();
        }

        public void ClientName(string clientname)
        {
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys(clientname);
        }

        public void Create()
        {
            driver.FindElement(By.XPath("//td[2]/a/strong/em")).Click();
        }

        public void Cancel()
        {
            driver.FindElement(By.XPath("//a[2]/strong/em")).Click();
        }
    }
}
