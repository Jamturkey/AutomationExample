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
    public class AdminLoginPage
    {
        private IWebDriver driver;

        public AdminLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo()
        {
            driver.Navigate().GoToUrl(Utils.BaseURL());
        }

        public MainPage Login(string username, string password)
        {
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.CssSelector("td > a.mainbutton.inline-block > strong > em")).Click();
            return new MainPage(driver);
        }

        public void LogOff()
        {
            driver.FindElement(By.LinkText("Log Off")).Click();
        }
    }
}
