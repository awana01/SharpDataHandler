using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    class MegaTests
    {
        //    [Test, TestCaseSource("GetTestData")]
        //    public void MyExample_Test(int data1, int data2, int expectedOutput)
        //    {
        //        var methodOutput = MethodUnderTest(data2, data1);
        //        Assert.AreEqual(expectedOutput, methodOutput);//, string.Format("Method failed for data1: {0}, data2: {1}", data1, data2));
        //    }

        //    private int MethodUnderTest(int data2, int data1)
        //    {
        //        Console.WriteLine(data1);
        //        return 42; //todo: real implementation
        //    }

        //    private static IEnumerable<int[]> GetTestData()
        //    {
        //        using (var csv = new CsvReader(new StreamReader(@"E:\C#-Projects\SeleniumProjects\DataHandler\DataHandler\ExcelData\data.csv"), true))
        //        {
        //            while (csv.ReadNextRecord())
        //            {
        //                int data1 = int.Parse(csv[0]);
        //                int data2 = int.Parse(csv[1]);
        //                int expectedOutput = int.Parse(csv[2]);
        //                Console.WriteLine(data1);
        //                yield return new[] { data1, data2, expectedOutput };
        //            }
        //        }
        //    }

    [TestCaseSource("GetDataFromCSV")]
    public void TestDataFromCSV(string num1, string num2)//,string num3)
    {
            Console.WriteLine("{0}=={1}", num1, num2);//,num3);
    }

    private static IEnumerable<string[]> GetDataFromCSV()
    {
        CsvReader reader = new CsvReader(@"E:\C#-Projects\SeleniumProjects\DataHandler\DataHandler\ExcelData\data1.csv");
        while (reader.Next())
        {
            var column1 = reader[0]; // int.Parse(reader[0]);
            var column2 = reader[1];
                //var column3 = reader[2]; // int.Parse(reader[2]);
                yield return new string[] { column1, column2 }; //, column3 };
        }
    }


    public class CsvReader : IDisposable
    {
        private string path;
        private string[] currentData;
        private StreamReader reader;

        public CsvReader(string path)
        {
            if (!File.Exists(path)) throw new InvalidOperationException("path does not exist");
            this.path = path;
            Initialize();
        }

        private void Initialize()
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
        }

        public bool Next()
        {
            string current = null;
            if ((current = reader.ReadLine()) == null) return false;
            currentData = current.Split(',');
            return true;
        }

        public string this[int index]
        {
            get { return currentData[index]; }
        }


        public void Dispose()
        {
            reader.Close();
        }
    }

   }
}
