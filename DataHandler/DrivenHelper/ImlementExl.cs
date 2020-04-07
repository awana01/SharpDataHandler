using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataHandler.DrivenHelper
{
    class ImlementExl
    {
    }



    /// <summary>
    /// DataDriven methods for NUnit test framework
    /// </summary>
    public static class TestData
    {

        public static IEnumerable CredentialsExcel
        {
            //ReadXlsxDataDriveFile(string path, string sheetName, [Optional] string[] diffParam, [Optional] string testName)
            //get { return DataDrivenHelper.ReadXlsxDataDriveFile(ProjectBaseConfiguration.DataDrivenFileXlsx, "credential", new[] { "user", "password" }, "credentialExcel"); }
            get { return DataDrivenHelper.ReadXlsxDataDriveFile("E:/C#-Projects/SeleniumProjects/DataHandler/DataHandler/ExcelData/B.xlsx", "Sheet1", new[] { "Name", "Email" }, "credentialExcel"); }
        }

        //public static IEnumerable LinksExcel
        //{
        //    get { return DataDrivenHelper.ReadXlsxDataDriveFile(ProjectBaseConfiguration.DataDrivenFileXlsx, "links"); }
        //}
    }

    public class TestExcelDataClass
    {
        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsExcel")]
        public void FormAuthenticationPageExcelTest(IDictionary<string, string> parameters)
        {
            Console.WriteLine(parameters["Name"]);

        }
    }
}