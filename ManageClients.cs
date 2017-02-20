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
using Gallio;
using Admin_Portal_Test_Suite.Objects;

namespace Admin_Portal_Test_Suite
{
    [TestFixture(Order = 7)]
    public class ManageClients
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = Utils.GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test(Order = 1)]
        public void EntryMCVerifyAddNew()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            ManageClientsPage manageClients = new ManageClientsPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            AddAClient addClient = new AddAClient(driver);
            loginPage.NavigateTo();
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            manageClients.NavigateTo();
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[3]/a/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.CssSelector("h2.l")).Text.Equals("Manage Clients"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("th")).Text.Equals("Client Name"));
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/thead/tr/th[2]")).Text.Equals("Enabled Users"));
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/thead/tr/th[3]")).Text.Equals("Total Users"));
            Assert.IsTrue(driver.FindElement(By.Id("clientList")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr/td")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr/td[2]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr/td[3]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr/td[4]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.LinkText(Utils.clientWithLongName)).Displayed);
            driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr[2]/td[4]")).Text.Equals("Enabled");
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            Assert.IsTrue(driver.FindElement(By.CssSelector("A.mainbutton.inline-block.r")).Displayed);
            addClient.NavigateTo();
            addClient.ClientName(Utils.qaClient);
            addClient.Create();
            Assert.AreEqual("The client name already exists", driver.FindElement(By.CssSelector("li")).Text);
            addClient.Cancel();
            Assert.AreEqual("Manage Clients", driver.FindElement(By.CssSelector("h2.l")).Text);
            Assert.AreEqual("Client Name", driver.FindElement(By.CssSelector("th")).Text);
            Assert.IsTrue(driver.FindElement(By.CssSelector("A.mainbutton.inline-block.r")).Displayed);
            addClient.NavigateTo();
            addClient.ClientName(Utils.GenerateUsername());
            addClient.Create();
        }

        [Test(Order = 2)]
        public void EntryMCChangeClientName()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            ManageClientsPage manageClients = new ManageClientsPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            AddAClient addClient = new AddAClient(driver);
            loginPage.NavigateTo();
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            manageClients.NavigateTo();
            manageClients.SelectClient(Utils.clientWithLongName);
            Assert.AreEqual("Manage Clients", driver.FindElement(By.CssSelector("h2.l")).Text);
            Assert.IsTrue(driver.FindElement(By.ClassName("r")).Displayed);
            Assert.AreEqual(Utils.clientWithLongName, driver.FindElement(By.CssSelector("div.leftcolumn.l > h2.l")).Text);
            Assert.AreEqual("Group Name", driver.FindElement(By.CssSelector("th")).Text);
            Assert.AreEqual("Note", driver.FindElement(By.CssSelector("thead > tr > th")).Text);
            Assert.AreEqual("Written By", driver.FindElement(By.XPath("//table[@id='clientList']/thead/tr/th[2]")).Text);
            Assert.AreEqual("Last Updated", driver.FindElement(By.XPath("//table[@id='clientList']/thead/tr/th[3]")).Text);
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.rightbutton.margin-bottom > a.mainbutton.inline-block > strong > em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[3]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[4]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("footer")).Displayed);
            changeName.NavigateTo();
            changeName.updateClientName("new_" + Utils.clientWithLongName);
            Assert.AreEqual("Client name:", driver.FindElement(By.CssSelector("label")).Text);
            Assert.IsTrue(driver.FindElement(By.Id("Name")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/div/table/tbody/tr[2]/td[2]/a/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/div/table/tbody/tr[2]/td[2]/a[2]/strong/em")).Displayed);
            changeName.SubmitNameChange();
            Assert.AreEqual("Manage Clients", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            changeName.NavigateTo();
            changeName.updateClientName("Cancel Update");
            changeName.CancelNameChange();
            Assert.AreEqual("new_" + Utils.clientWithLongName, driver.FindElement(By.CssSelector("div.leftcolumn.l > h2.l")).Text);
        }

        [Test(Order = 3)]
        public void EntryMCDisableEnable()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            ManageClientsPage manageClients = new ManageClientsPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            AddAClient addClient = new AddAClient(driver);
            loginPage.NavigateTo();
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            manageClients.NavigateTo();
            manageClients.SelectClient("new_" + Utils.clientWithLongName);
            disableEnableClient.NavigateToDisable();
            Assert.AreEqual("Disable Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.box")).Text.Equals("Are you sure you want to disable the client \"new_" + Utils.clientWithLongName + "\"?"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("form > a.mainbutton.inline-block > strong > em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/a[2]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            Assert.AreEqual("Proprietary and confidential. ©2012 Stayhealthy. All rights reserved", driver.FindElement(By.Id("footer")).Text);
            disableEnableClient.Accept();
            Assert.AreEqual("Enable Client", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Text);
            Assert.AreEqual("Enable Client", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Text);
            disableEnableClient.NavigateToEnable();
            Assert.AreEqual("Enable Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.box")).Text.Equals("Are you sure you want to enable the client \"new_" + Utils.clientWithLongName + "\"?"));
            Assert.AreEqual("Yes", driver.FindElement(By.CssSelector("form > a.mainbutton.inline-block > strong > em")).Text);
            Assert.AreEqual("No", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/a[2]/strong/em")).Text);
            disableEnableClient.Decline();
            Assert.AreEqual("Enable Client", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Text);
            disableEnableClient.NavigateToEnable();
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.box")).Text.Equals("Are you sure you want to enable the client \"new_" + Utils.clientWithLongName + "\"?"));
            disableEnableClient.Accept();
            Assert.AreEqual("Disable Client", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[3]/strong/em")).Text);
        }

        [Test(Order = 4)]
        public void EntryMCAddNote()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            ManageClientsPage manageClients = new ManageClientsPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            AddAClient addClient = new AddAClient(driver);
            loginPage.NavigateTo();
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            manageClients.NavigateTo();
            manageClients.SelectClient("new_" + Utils.clientWithLongName);
            addClientNote.NavigateTo();
            Assert.AreEqual("Create Note For new_" + Utils.clientWithLongName, driver.FindElement(By.CssSelector("h2")).Text);
            Assert.AreEqual("Note:", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("4,000 characters left", driver.FindElement(By.Id("wordCount")).Text);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[3]/form/p[3]/a/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[3]/form/p[3]/a[2]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("Comment")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("footer")).Displayed);
            addClientNote.Comment("This is a note added by our Automation Suite!");
            addClientNote.Cancel();
            addClientNote.NavigateTo();
            Assert.IsTrue(driver.FindElement(By.Id("Comment")).Displayed);
            addClientNote.Comment("This is a note added by our Automation Suite!");
            Assert.AreEqual("3955 characters left", driver.FindElement(By.Id("wordCount")).Text);
            addClientNote.Create();
            Assert.AreEqual("This is a note added by our Automation Suite!", driver.FindElement(By.CssSelector("#clientList > tbody > tr > td")).Text);
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr/td[2]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr/td[3]")).Displayed);
            manageClients.NavigateTo();
        }

        [Test(Order = 5)]
        public void EntryMCRevertName()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            ManageClientsPage manageClients = new ManageClientsPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            AddAClient addClient = new AddAClient(driver);
            loginPage.NavigateTo();
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            manageClients.NavigateTo();
            manageClients.SelectClient("new_" + Utils.clientWithLongName);
            Assert.AreEqual("new_" + Utils.clientWithLongName, driver.FindElement(By.CssSelector("div.leftcolumn.l > h2.l")).Text);
            changeName.NavigateTo();
            Assert.AreEqual("Edit Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.AreEqual("Client name:", driver.FindElement(By.CssSelector("label")).Text);
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).SendKeys(Utils.clientWithLongName);
            changeName.SubmitNameChange();
            Assert.AreEqual(Utils.clientWithLongName, driver.FindElement(By.CssSelector("div.leftcolumn.l > h2.l")).Text);
            manageClients.Help();
        }

        [Test(Order = 6)]
        public void EntryMainAddNewClient()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            MainPage mainTab = new MainPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            AddAClient addClient = new AddAClient(driver);
            loginPage.NavigateTo();
            Utils.TimeOut(driver);
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            mainTab.AddNewClient();
            Assert.AreEqual("Create Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.AreEqual("Enter a name for the client:", driver.FindElement(By.CssSelector("th")).Text);
            Assert.IsTrue(driver.FindElement(By.Id("Name")).Displayed);
            addClient.ClientName(Utils.qaClient);
            addClient.Create();
            Assert.AreEqual("The client name already exists", driver.FindElement(By.CssSelector("li")).Text);
            addClient.Cancel();
            Assert.AreEqual("Manage Clients", driver.FindElement(By.CssSelector("h2.l")).Text);
            Assert.AreEqual("Client Name", driver.FindElement(By.CssSelector("th")).Text);
            Assert.IsTrue(driver.FindElement(By.CssSelector("A.mainbutton.inline-block.r")).Displayed);
            mainTab.NavigateTo();
            mainTab.AddNewClient();
            Assert.AreEqual("Create Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.AreEqual("Enter a name for the client:", driver.FindElement(By.CssSelector("th")).Text);
            Assert.IsTrue(driver.FindElement(By.Id("Name")).Displayed);
            addClient.ClientName(Utils.GenerateUsername());
            addClient.Create();

        }

        [Test(Order = 7)]
        public void EntryMainUpdateName()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            MainPage mainTab = new MainPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            loginPage.NavigateTo();
            Utils.TimeOut(driver);
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            mainTab.NavigateTo();
            Assert.AreEqual("Add New Clients", driver.FindElement(By.LinkText("Add New Clients")).Text);
            mainTab.AddNewClient();
            Assert.AreEqual("Create Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.AreEqual("Enter a name for the client:", driver.FindElement(By.CssSelector("th")).Text);
            Assert.IsTrue(driver.FindElement(By.Id("Name")).Displayed);
            mainTab.NavigateTo();
            Assert.AreEqual("Update a Client", driver.FindElement(By.LinkText("Update a Client")).Text);         
            mainTab.UpdateAClient();
            Assert.AreEqual("Select a Client", driver.FindElement(By.CssSelector("#divclients > fieldset > legend")).Text);
            Assert.AreEqual("Clients", driver.FindElement(By.CssSelector("legend")).Text);
            mainTab.ClickClient(Utils.qaClient);
            Assert.AreEqual("Manage Clients", driver.FindElement(By.CssSelector("h2.l")).Text);
            Assert.IsTrue(driver.FindElement(By.ClassName("r")).Displayed);
            Assert.AreEqual(Utils.qaClient, driver.FindElement(By.CssSelector("div.leftcolumn.l > h2.l")).Text);
            Assert.AreEqual("Group Name", driver.FindElement(By.CssSelector("th")).Text);
            Assert.AreEqual("Note", driver.FindElement(By.CssSelector("thead > tr > th")).Text);
            Assert.AreEqual("Written By", driver.FindElement(By.XPath("//table[@id='clientList']/thead/tr/th[2]")).Text);
            Assert.AreEqual("Last Updated", driver.FindElement(By.XPath("//table[@id='clientList']/thead/tr/th[3]")).Text);
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.rightbutton.margin-bottom > a.mainbutton.inline-block > strong > em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[3]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[4]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("footer")).Displayed);
            changeName.NavigateTo();
            changeName.updateClientName("new_" + Utils.qaClient);
            Assert.AreEqual("Client name:", driver.FindElement(By.CssSelector("label")).Text);
            Assert.IsTrue(driver.FindElement(By.Id("Name")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/div/table/tbody/tr[2]/td[2]/a/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/div/table/tbody/tr[2]/td[2]/a[2]/strong/em")).Displayed);
            Assert.AreEqual("Edit Client", driver.FindElement(By.CssSelector("h2")).Text);
            changeName.SubmitNameChange();
            Thread.Sleep(2000);
            Assert.AreEqual("Manage Clients", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            changeName.NavigateTo();
            Assert.IsTrue(driver.FindElement(By.Id("Name")).Displayed);
            changeName.updateClientName("Cancel Update");
            changeName.CancelNameChange();
            Assert.AreEqual("new_" + Utils.qaClient, driver.FindElement(By.CssSelector("div.leftcolumn.l > h2.l")).Text); 

        }

        [Test(Order = 8)]
        public void EntryMainDisableEnable()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            MainPage mainTab = new MainPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            loginPage.NavigateTo();
            Utils.TimeOut(driver);
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            mainTab.UpdateAClient();
            Assert.AreEqual("Select a Client", driver.FindElement(By.CssSelector("#divclients > fieldset > legend")).Text);
            Assert.AreEqual("Clients", driver.FindElement(By.CssSelector("legend")).Text);
            mainTab.ClickClient("new_" + Utils.qaClient);
            disableEnableClient.NavigateToDisable();
            Assert.AreEqual("Disable Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.box")).Text.Equals("Are you sure you want to disable the client \"new_" + Utils.qaClient + "\"?"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("form > a.mainbutton.inline-block > strong > em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/a[2]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            Assert.AreEqual("Proprietary and confidential. ©2012 Stayhealthy. All rights reserved", driver.FindElement(By.Id("footer")).Text);
            disableEnableClient.Accept();
            Assert.AreEqual("Enable Client", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Text);
            Assert.AreEqual("Enable Client", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Text);
            disableEnableClient.NavigateToEnable();
            Assert.AreEqual("Enable Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.box")).Text.Equals("Are you sure you want to enable the client \"new_" + Utils.qaClient + "\"?"));
            Assert.AreEqual("Yes", driver.FindElement(By.CssSelector("form > a.mainbutton.inline-block > strong > em")).Text);
            Assert.AreEqual("No", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/form/a[2]/strong/em")).Text);
            disableEnableClient.Decline();
            Assert.AreEqual("Enable Client", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[2]/strong/em")).Text);
            disableEnableClient.NavigateToEnable();
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.box")).Text.Equals("Are you sure you want to enable the client \"new_" + Utils.qaClient + "\"?"));
            disableEnableClient.Accept();
            Assert.AreEqual("Disable Client", driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[6]/div/a[3]/strong/em")).Text);

        }

        [Test(Order = 9)]
        public void EntryMainAddNote()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            MainPage mainTab = new MainPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            loginPage.NavigateTo();
            Utils.TimeOut(driver);
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            mainTab.UpdateAClient();
            Assert.AreEqual("Select a Client", driver.FindElement(By.CssSelector("#divclients > fieldset > legend")).Text);
            Assert.AreEqual("Clients", driver.FindElement(By.CssSelector("legend")).Text);
            mainTab.ClickClient("new_" + Utils.qaClient);
            addClientNote.NavigateTo();
            Assert.AreEqual("Create Note For new_" + Utils.qaClient, driver.FindElement(By.CssSelector("h2")).Text);
            Assert.AreEqual("Note:", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("4,000 characters left", driver.FindElement(By.Id("wordCount")).Text);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[3]/form/p[3]/a/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='wrapper']/div/table/tbody/tr/td[2]/div[2]/div[3]/form/p[3]/a[2]/strong/em")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("help")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("Comment")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("footer")).Displayed);
            addClientNote.Comment("This is a note added by our Automation Suite!");
            addClientNote.Cancel();
            addClientNote.NavigateTo();
            Assert.IsTrue(driver.FindElement(By.Id("Comment")).Displayed);
            addClientNote.Comment("This is a note added by our Automation Suite!");
            Assert.AreEqual("3955 characters left", driver.FindElement(By.Id("wordCount")).Text);
            addClientNote.Create();
            Assert.AreEqual("This is a note added by our Automation Suite!", driver.FindElement(By.CssSelector("#clientList > tbody > tr > td")).Text);
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr/td[2]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='clientList']/tbody/tr/td[3]")).Displayed);
        }

        [Test(Order = 10)]
        public void EntryMainRevertName()
        {
            Utils.TimeOut(driver);
            AdminLoginPage loginPage = new AdminLoginPage(driver);
            MainPage mainTab = new MainPage(driver);
            ChangeClientName changeName = new ChangeClientName(driver);
            DisableEnableClient disableEnableClient = new DisableEnableClient(driver);
            AddClientNote addClientNote = new AddClientNote(driver);
            loginPage.NavigateTo();
            Utils.TimeOut(driver);
            loginPage.Login(Utils.partnerUserName, Utils.genericPassword);
            Assert.IsTrue(driver.FindElement(By.LinkText("Log Off")).Text.Equals("Log Off"));

            mainTab.UpdateAClient();
            Assert.AreEqual("Select a Client", driver.FindElement(By.CssSelector("#divclients > fieldset > legend")).Text);
            Assert.AreEqual("Clients", driver.FindElement(By.CssSelector("legend")).Text);
            mainTab.ClickClient("new_" + Utils.qaClient);
            Assert.AreEqual("new_" + Utils.qaClient, driver.FindElement(By.CssSelector("div.leftcolumn.l > h2.l")).Text);
            changeName.NavigateTo();
            Assert.AreEqual("Edit Client", driver.FindElement(By.CssSelector("h2")).Text);
            Assert.AreEqual("Client name:", driver.FindElement(By.CssSelector("label")).Text);
            changeName.updateClientName(Utils.qaClient);
            changeName.SubmitNameChange();
            Assert.AreEqual(Utils.qaClient, driver.FindElement(By.CssSelector("div.leftcolumn.l > h2.l")).Text);
        }
    }
}