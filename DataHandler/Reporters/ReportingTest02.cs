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
    class ReportingTest02 : BaseReporter
    {


        [Test]
        public void ReportingTest02_Test01()
        {
            _test = _extent.CreateTest("Test01", "ReportTest 02");
            Console.WriteLine("ReportingTest02 Executing {0}", testName);
            _test.Log(Status.Pass,"Test Executed ReportingTest02 Executing " + testName);
        }

    }
}
