using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumStudy
{
    class AlertActionsAutoSuggestive
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            // implicit wait 5sec can be declare globaly
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]
        public void TestFrames()
        {
            // scroll
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);
            // id, name, index
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
        }

        [Test]
        public void TestAlert()
        {
            String name = "Rahul";
            driver.FindElement(By.Id("name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();
            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            //driver.SwitchTo().Alert().Dismiss();
            //driver.SwitchTo().Alert().SendKeys("hello");

            StringAssert.Contains(name, alertText);
        }

        [Test]
        public void TestAutoSuggestionDropDowns()
        {
            driver.FindElement(By.Id("Autocomplete")).SendKeys("ind");
            Thread.Sleep(3000);
            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }

            }
        }
        
        [Test]
        public void TestActions()
        {
            //driver.Url = "https://rahulshettyacademy.com";
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class = 'dropdown-menu']/li[1]/a"))).Click().Perform();

            driver.Url = "https://demoqa.com/droppable/";
            a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();
        }
        
        
    }
}