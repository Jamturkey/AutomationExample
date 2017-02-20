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
    public class DisableEnableClient
    {
        private IWebDriver driver;

        public DisableEnableClient(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToDisable()
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[3]/strong/em")).Click();
        }

        public void Accept()
        {
            driver.FindElement(By.CssSelector("form > a.mainbutton.inline-block > strong > em")).Click();
        }

        public void Decline()
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/a[2]/strong/em")).Click();
        }

        public void NavigateToEnable()
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Click();
        }
    }
}
