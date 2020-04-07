using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace DataHandler.Reporters
{
    [TestFixture]
    class BaseReporter
    {
        public string testName;
        public static ExtentReports _extent;
        public static ExtentTest _test;
        public static String path = @"E:\C#-Projects\SeleniumProjects\APITesting";

       [OneTimeSetUp]
       public void StartTest()
       {
            _extent = new ExtentReports();
            
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            Console.WriteLine(dir);
            
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
            var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
            
            _extent.AddSystemInfo("Environment", "Journey of Quality");
            _extent.AddSystemInfo("User Name", "Rajeev Singh");
            _extent.AttachReporter(htmlReporter);
            
            
            testName = TestContext.CurrentContext.Test.FullName;
            Console.WriteLine("==== Intialize Test ====");
              //Reporter.CreateTestCase(testName);
       }


       [OneTimeTearDown]
       public void FinsihTest()
       {
         Console.WriteLine("==== Finish Test ====");
            _extent.Flush();
        }

    }
}

