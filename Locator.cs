using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumStudy
{
    class Locator
    {
        // Xpath, Css, id, classname, tagname
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {           
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            // implicit wait 5sec can be declare globally
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
        }
        [Test]
        public void LocatorIdentication()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");

            //CSS : .text-info span:nth-child(1) input
            // Xpath - //label[@class = 'text-info']/span/input
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            //xpath  ==> //tagname[@attribure = 'value']
            //css selector ==> tagname[attribure = 'value']
            driver.FindElement(By.XPath("//input[@value = 'Sign In']")).Click();

            //Thread.Sleep(8000);
            // Explicit wait 8sec apply to signIn btn(webObject)
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));

            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttribute = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/#/documents-request";
            Assert.AreEqual(expectedUrl, hrefAttribute);

            // validate url of the link text

            driver.FindElement(By.CssSelector("#terms")).Click();
        }
    }
}
