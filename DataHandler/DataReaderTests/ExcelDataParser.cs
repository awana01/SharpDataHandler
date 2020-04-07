using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    class ExcelDataParser
    {
        static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        static string projectPath = new Uri(actualPath).LocalPath;
        //static string excelPath = actualPath + @"ExcelData";//projectPath + @"\ExcelData\"
        static string excelPath = @"E:\C#-Projects\SeleniumProjects\DataHandler\DataHandler\ExcelData\";
        public static IEnumerable<TestCaseData> BudgetData
        {
            get
            {
                List<TestCaseData> testCaseDataList = new ExcelReader().ReadExcelData(excelPath + "A.xlsx");

                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in testCaseDataList)
                        yield return testCaseData;
            }
        }
    }
}
