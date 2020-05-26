using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace VMaxDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateSession()
        {
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", @"C:\Program Files\VMAX Technologies, Inc\VMAX Editor x64\bin\VmEditor2.exe");
            appOptions.AddAdditionalCapability("appWorkingDir", @"C:\Program Files\VMAX Technologies, Inc\VMAX Editor x64\");
            appOptions.AddAdditionalCapability("ms:waitForAppLaunch", "25");

            WindowsDriver<WindowsElement> Session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);
        }
    }
}
