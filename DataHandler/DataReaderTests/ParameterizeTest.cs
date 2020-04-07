using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHandler.Utils;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;

namespace DataHandler.DataReaderTests
{
    /// <summary>
    /// https://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader
    /// </summary>
    [TestFixture]
    class ParameterizeTest
    {
        public string _CsvDir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\ExcelData");
        public string dir;
        public void csvFileDir(string dir) {
            this.dir = dir;
        }
        public string csvFileDir()
        {
            return dir;
        }
        


     

        [TestCaseSource("GetDataFromCSV")]
        public void ReadColumnsTest(string name, string email)
        {
           string csvFile = _CsvDir + "csv_data1.csv";
           //CsvReader reader = new CsvReader(new StreamReader(csvFile), true);
            Console.WriteLine("{0} == {1}", name, email);

        }

          

        private static IEnumerable<string[]> GetDataFromCSV()
        {
            
            string _dataDirFile = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\ExcelData");
            CsvReaders reader = new CsvReaders(@"E:\C#-Projects\SeleniumProjects\DataHandler\DataHandler\ExcelData\csv_data1.csv");
           //(new StreamReader(@"E:\C#-Projects\SeleniumProjects\DataHandler\DataHandler\ExcelData\csv_data1.csv"), true);

            while (reader.Next())
            {
                var name = reader[0]; 
                var email = reader[1];
                //var column3 = reader[2]; // int.Parse(reader[2]);
                yield return new string[] { name, email }; //, column3 };
            }
        }


        [TestCaseSource("CsvTestData")]
        public void Test(string name,string email)
        {
            Console.WriteLine($"Name: {name} Email: {email}");
        }


        private static IEnumerable<string[]> CsvTestData()
        {
            //string csvFile = 
            //Console.WriteLine(csvFile);

            using (CsvReader csv = new CsvReader(new StreamReader(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\ExcelData")+"csv_data1.csv"), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
                Console.WriteLine($"columns in csv: {csv.Columns.Count}");
                Console.WriteLine($"Total FieldCount {fieldCount} Total Headers {headers.Length}");

                while (csv.ReadNextRecord())
                {
                    //for (int i = 0; i < fieldCount; i++)
                    //    Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));
                    //Console.WriteLine();
                    var name = csv[0];
                    var email = csv[1];
                    yield return new string[]{name,email };


                }
            }
        }

    }//end class


    [TestFixture]
    class SimpleParameterizeTests
    {
        [TestCase(1, 2, 3)]
        [Test, Description("A simple test with parameterized numeric inputs")]
        public void TestNumeric(int a, int b, int c)
        {
            Assert.AreEqual(c, a + b);
        }

        [TestCase("My String")]
        [Test, Description("A simple test with parameterized string input")]
        public void TestSingleString(string a)
        {
            Assert.AreEqual("My String", a);
        }
        [TestCase("String1", "String2")]
        [Test, Description("A simple test with parameterized numeric inputs")]
        public void TestTwoStrings(string a, string b)
        {
            Assert.AreEqual("String1", a);
        }
    }






}
