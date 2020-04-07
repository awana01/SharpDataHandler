using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler.Reporters
{
    public class Reporter
    {
        protected static ExtentReports _extent;
        protected static ExtentTest _test;
        public static String path = @"E:\C#-Projects\SeleniumProjects\APITesting";
        public static void CreateTestReport()
        {
            
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            Console.WriteLine(dir);
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
            var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");

            _extent = new ExtentReports();
            _extent.AddSystemInfo("Environment", "Journey of Quality");
            _extent.AddSystemInfo("User Name", "Rajeev Singh");
            _extent.AttachReporter(htmlReporter);
            //return _extent;
        }

        public static ExtentTest CreateTestCase(String TestName)
        {
            _test = _extent.CreateTest(TestName);
            return _test;
        }

        //public static void LogToTest(String Message)
        //{
        //    _extentTest.Log(Status.Info, "");
        //}

        public static void FinalizeReport()
        {
            _extent.Flush();
           
        }
    }
}
