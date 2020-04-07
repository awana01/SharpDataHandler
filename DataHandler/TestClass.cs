// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
//using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using System.IO;
using System.Collections;

namespace DataHandler
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");

            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string excelPath = actualPath + @"ExcelData";//projectPath + @"\ExcelData\";

            Console.WriteLine(pth);
            Console.WriteLine(actualPath);
            Console.WriteLine(projectPath);
            Console.WriteLine(projectPath);
            Console.WriteLine(excelPath);



        }


        [Test ,TestCaseSource(typeof(ExcelDataParser), "BudgetData"), Category("1")]
        public void AchterBudget(string min, string max)
        {
        }

        [Test, TestCaseSource("LocationTestData")]
        public void RetrieveDataFor_ShouldYield(string countryCode, string zipCode, string expectedPlaceName)
        {
            Console.WriteLine("{0},{1},{2}",countryCode,zipCode,expectedPlaceName);

        }

        private static IEnumerable<TestCaseData> LocationTestData()
        {
            yield return new TestCaseData("us", "90210", "Beverly Hills").SetName("Check that US zipcode 90210 yields Beverly Hills");
            yield return new TestCaseData("us", "12345", "Schenectady").SetName("Check that US zipcode 12345 yields Schenectady");
            yield return new TestCaseData("ca", "Y1A", "Whitehorse").SetName("Check that CA zipcode Y1A yields Whitehorse");
        }

        //[Test, TestCaseSource("testData")]
        //public void performActionsByWorksheet(string excelFilePath, string worksheetName)
        //{
        //    Console.WriteLine("excel filePath: {0}", excelFilePath);
        //    Console.WriteLine("worksheet Name: {0}", worksheetName);
        //}

        //static object[] testData()
        //{
        //    var reader = new StreamReader(File.OpenRead(@"TestCases.csv"));
        //    List<object[]> rows = new List<object[]>();

        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(',');
        //        rows.Add(values);
        //    }
        //    //return rows.ToArray<object[]>();
        //    return rows.ToArray<object[]>();
        //}

        //[TestCaseSource("GetDataFromCSV2")]
        //public int TestDataFromCSV2(int num1, int num2)
        //{
        //    return num1 + num2;
        //}

        //private IEnumerable GetDataFromCSV2()
        //{
        //    CsvReader reader = new CsvReader(path);
        //    while (reader.Next())
        //    {
        //        int column1 = int.Parse(reader[0]);
        //        int column2 = int.Parse(reader[1]);
        //        int column3 = int.Parse(reader[2]);
        //        yield return new TestCaseData(column1, column2).Returns(column3);
        //    }
        //}






    }
}
