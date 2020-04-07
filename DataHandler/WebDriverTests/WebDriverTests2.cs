using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DataHandler.WebDriverTests
{
    [TestFixture]
    class WebDriverTests2
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Start()
        {
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", "E:/Selenium-3.6/geckodriver-v0.26.0-win64/geckodriver.exe");
            FirefoxOptions _firefoxOpts = new FirefoxOptions();
            

            driver = new FirefoxDriver(_firefoxOpts);
            driver.Navigate().GoToUrl("https://www.yahoo.com/");


        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.Id("fakebox-input")).SendKeys("RestSharp");
            
        }

        [OneTimeTearDown]
        public void close()
        {
            driver.Close();
        }

    }
}
