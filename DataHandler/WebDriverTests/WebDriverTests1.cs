using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataHandler.WebDriverTests
{
    [TestFixture]
    class WebDriverTests1
    {
        IWebDriver driver;

        [OneTimeSetUp]
       public void Start()
        {
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "E:/Selenium-3.6/chrome-80/chromedriver.exe");
            ChromeOptions _chromeOpts = new ChromeOptions();

            driver = new ChromeDriver(_chromeOpts);
            driver.Navigate().GoToUrl("https://www.google.com/");

            
        }
    
        [Test]
        public void Test1()
        {
            driver.FindElement(By.Name("q")).SendKeys("RestSharp");
        }
    
        [OneTimeTearDown]
        public void close()
        {
            driver.Close();
        }
    
    }
}
