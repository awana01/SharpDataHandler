using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHandler.DataReader;
using NUnit.Framework;

namespace DataHandler
{   
    [TestFixture]
    class TestClass3
    {

        private static string FILENAME = "A.xlsx";

        public static IEnumerable<TestCaseData> RegisrtrationData()
        {
            return ExcelReader1.ReadFromExcel(FILENAME, "BudgetData");
        }



        [TestCaseSource("RegisrtrationData")]
        public void CheckName_Validations(string min, string max)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(min);
                
            });
        }




    }
}
