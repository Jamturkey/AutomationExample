using System;
using System.Collections.Generic;
using System.Configuration;
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
    public static class Utils
    {
        public static string partnerUserName = "testadmin";
        public static string clientAdmin = "clientadmin";
        public static string partnerClient = "Stayhealthy Production";
        public static string qaClient = "QAs Client";
        public static string clientWithLongName = "This is a Client with a long name that's maxed";
        public static string genericPassword = "test";

        public static string GenerateUsername()
        {
            return DateTime.Now.ToString("MMddyyhhmmss");
        }

        public static readonly Random rng = new Random();
        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@_-.";

        public static string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = chars[rng.Next(chars.Length)];
            }
            return new string(buffer);
        }

        public static String YYYYMMDD()
        {
            return DateTime.Now.ToString("yyyy-MM-dd ");
        }

        public static void TimeOut(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 2, 0));
        }

        public static string BaseURL()
        {
            string URL = "http://admin.stayhealthyadmintest.com";

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Domain"]) && (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Site"]) || ConfigurationManager.AppSettings["Domain"].ToUpper() == "TEST"))
            {
                switch (ConfigurationManager.AppSettings["Domain"].ToUpper())
                {
                    case "DEV":
                        URL = "http://admin.stayhealthyadmindev.com";
                        break;
                    case "TEST":
                        URL = "http://admin.stayhealthyadmintest.com";
                        break;
                    case "UAT":
                        URL = "http://admin.stayhealthyadminuat.com";
                        break;
                    case "PROD":
                        URL = "http://admin.stayhealthyadmin.com";
                        break;
                }
            }

            return URL;
        }

        public static IWebDriver GetDriver()
        {
            //driver = new FirefoxDriver();
            //driver = new ChromeDriver(@"C:\Users\tjdamtorki\Dropbox\Stayhealthy Automated Suites\BrowserDrivers");
            IWebDriver driver = null;

            //FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox13.0\firefox.exe");
            //FirefoxProfile profile = new FirefoxProfile();

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Browser"]) && (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DriverLocation"]) || ConfigurationManager.AppSettings["Browser"].ToUpper() == "FIREFOX"))
            {
                switch (ConfigurationManager.AppSettings["Browser"].ToUpper())
                {
                    case "FIREFOX":
                        //string path = @"C:\Users\tjdamtorki\AppData\Local\Mozilla\Firefox\Profiles\5mk1d0pv.FireFox 13.0";
                        //driver = new FirefoxDriver(binary, profile);
                        driver = new FirefoxDriver();
                        break;
                    case "CHROME":
                        driver = new ChromeDriver(ConfigurationManager.AppSettings["DriverLocation"]);
                        break;
                    case "IE":
                        driver = new InternetExplorerDriver(ConfigurationManager.AppSettings["DriverLocation"]);
                        break;
                }
            }
            else
            {
                driver = new FirefoxDriver();
            }

            return driver;
        }
    }
}
