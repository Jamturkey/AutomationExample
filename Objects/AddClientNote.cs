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
    public class AddClientNote
    {
        private IWebDriver driver;

        public AddClientNote(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo()
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[4]/strong/em")).Click();
        }

        public void Comment(string note)
        {
            driver.FindElement(By.Id("Comment")).Click();
            driver.FindElement(By.Id("Comment")).Clear();
            driver.FindElement(By.Id("Comment")).SendKeys(note);
        }

        public void Cancel()
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[3]/form/p[3]/a[2]/strong/em")).Click();
        }

        public void Create()
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[3]/form/p[3]/a/strong/em")).Click();
        }
    }
}
