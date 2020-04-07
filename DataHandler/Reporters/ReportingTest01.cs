using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace DataHandler.Reporters
{
    [TestFixture]
    class ReportingTest01 : BaseReporter
    {


       [Test]
       public void ReportingTest01_Test01()
       {
            _test = _extent.CreateTest("Test01", "ReportTest 01");
            Console.WriteLine("ReportingTest01 Executing {0}",testName);
            _test.Log(Status.Pass, "Test Executed ReportingTest01 Executing " + testName);
        }

    }
}
