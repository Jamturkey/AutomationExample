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
    public class ChangeClientName
    {
        private IWebDriver driver;

        public ChangeClientName(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo()
        {
            driver.FindElement(By.CssSelector("div.rightbutton.margin-bottom > a.mainbutton.inline-block > strong > em")).Click();
        }

        public void updateClientName(string clientname)
        {
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).SendKeys(clientname);
        }
        
        public void SubmitNameChange()
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/div/table/tbody/tr[2]/td[2]/a/strong/em")).Click();
        }

        public void CancelNameChange()
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/div/table/tbody/tr[2]/td[2]/a[2]/strong/em")).Click();
        }

        public void revertNameChange(string clientname)
        {
            
        }
    }
}
