using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumStudy
{
    class SeleniumFirst
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            // DriverManager will download the Chromedriver.exe needed for our version of Chrome Browser
           // new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //driver = new ChromeDriver();
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test1 ()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
            TestContext.Progress.WriteLine("title: " + driver.Title);
            TestContext.Progress.WriteLine("title: " + driver.Url);
            // driver.PageSource to see the code source of our page
            driver.Close(); // 1 window
            //drvier.Quit(); 2 windows
        }
    }
}
