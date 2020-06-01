using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace VMaxDemo
{
    [TestClass]
    public class Vmax
    {
        public static WindowsDriver<WindowsElement> Session;
    
        public void CreateSession()
        {
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", @"C:\Program Files\VMAX Technologies, Inc\VMAX Editor x64\bin\VmEditor2.exe");
            appOptions.AddAdditionalCapability("appWorkingDir", @"C:\Program Files\VMAX Technologies, Inc\VMAX Editor x64");
            appOptions.AddAdditionalCapability("ms:waitForAppLaunch", "25");

            Session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);
        }
        [TestMethod]
        public void OpenVCO()
        {
            Actions action = new Actions(Session);
            action.SendKeys(Keys.Control + "o" + Keys.Control).Build().Perform();

            Thread.Sleep(1000);

            try
            {
                Session.FindElementByName("No").Click();
            }
            catch { }

            action.SendKeys(Keys.Alt + "n" + Keys.Alt).SendKeys(Keys.Backspace).Build().Perform();

            Thread.Sleep(1000);

            action.SendKeys("UHD3.vco").Build().Perform();

            Session.FindElementByName("Open").Click();

            Thread.Sleep(3000);
            Assert.IsTrue(Session.Title.Contains("UHD3"));
            Debug.WriteLine(".VCO file is opened successfully.");
            Debug.WriteLine($"Application Title: {Session.Title}");
        }

        [TestMethod]
        public void OpenVMAX()
        {
            Actions action = new Actions(Session);
            action.SendKeys(Keys.Control + "o" + Keys.Control).Build().Perform();

            Thread.Sleep(1000);

            try
            {
                Session.FindElementByName("No").Click();
            }
            catch { }

            action.SendKeys(Keys.Alt + "n" + Keys.Alt).SendKeys(Keys.Backspace).Build().Perform();

            Thread.Sleep(1000);

            action.SendKeys("VMAX_Editor_Tutorial2_sdk2.vmax").Build().Perform();

            Session.FindElementByName("Open").Click();

            Thread.Sleep(3000);
            Assert.IsTrue(Session.Title.Contains("VMAX_Editor_Tutorial2_sdk2"));
            Debug.WriteLine(".VMAX file is opened successfully.");
            Debug.WriteLine($"Application Title: {Session.Title}");
        }

        public void TearDown()
        {
            //Debug.WriteLine("Windows Driver tear down in progress.");
            if (Session != null)
            {
                Session.FindElementByName("System").Click();
                Thread.Sleep(3000);
                Session.FindElementByName("Close").Click();
                Thread.Sleep(1000);
                Session.FindElementByName("No").Click();
            }

            Console.WriteLine("BaseClass:TearDown - Application is closed");
            Session.Close();
            Session = null;

        }
        [TestInitialize]
        public void TestInitialize()
        {
            CreateSession();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TearDown();
        }
    }
}
