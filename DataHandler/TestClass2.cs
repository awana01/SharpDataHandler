using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;

namespace DataHandler
{
    [TestFixture]
    class TestClass2
    {
    
         [Test]
         public void TestCsvReaderCode1()
         {

            using (CsvReader csv = new CsvReader(new StreamReader(@"E:\C#-Projects\SeleniumProjects\DataHandler\DataHandler\ExcelData\data1.csv"), true))
            {
                int fieldCount = csv.FieldCount;

                string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    for (int i = 0; i < fieldCount; i++)
                        Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));
                    Console.WriteLine();
                }
            }
        }


        [Test]
        public void TestCsvReaderCode2()
        {

            bool isheader = true;
            var reader = new StreamReader(File.OpenRead(@"E:\C#-Projects\SeleniumProjects\DataHandler\DataHandler\ExcelData\data1.csv"));
            List<string> headers = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (isheader)
                {
                    isheader = false;
                    headers = values.ToList();
                }
                else
                {
                    int i = 0;
                    for (i = 0; i <=values.Length-1; i++)
                    //for (i = 0; i <=2; i++)
                    {
                        Console.Write(string.Format("{0} = {1};", headers[i], values[i]));

                    }
                    Console.WriteLine();

                }
            }
        }


    }
}







