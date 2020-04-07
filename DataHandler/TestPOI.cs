using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using DataHandler.DataReader;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DataHandler
{
 
    
   
    class POI
    {

        public static int ReadWorkbook(string path)
        {
            IWorkbook book;

            int _TotalHeaders = 0;
            int _FirstRowNum;
            int _totalColumns;
            int _lastRowNum;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // Try to read workbook as XLSX:
            try
            {
                IRow row = null;
                ICell cell = null;

                book = new XSSFWorkbook(fs);
                ISheet sheet = book.GetSheet("Sheet1"); //.CreateSheet("Sheet1");
                //row = sheet.LastRowNum; //.GetRow(0).PhysicalNumberOfCells; //.Cells.Count();
                //row = sheet.GetRow(0).PhysicalNumberOfCells; //.Cells.Count();
                _TotalHeaders  = sheet.GetRow(0).Cells.Count();
                _FirstRowNum = sheet.FirstRowNum;
                _lastRowNum = sheet.LastRowNum;                

                _totalColumns = sheet.GetRow(0).LastCellNum;
               
                Console.WriteLine("Headers " + sheet.Header);
                Console.WriteLine("Total Rows: "+_TotalHeaders);
                Console.WriteLine("First Row Num: " + _FirstRowNum);
                Console.WriteLine("First columns Num: "+_totalColumns);
                Console.WriteLine("Last Row Num: " + _lastRowNum);
                //Console.WriteLine("Physcial num of cells: " + row.PhysicalNumberOfCells);

                for(int i=0;i< _TotalHeaders; i++)
                {
                    Console.WriteLine("Header {0} Name {1}: ",i,sheet.GetRow(0).Cells[i].StringCellValue);
                }

                //for (int j = 0; j < _lastRowNum; j++)
                //{
                //    Console.WriteLine("row {0}, {1}", j, sheet.GetRow(j).Cells[0].StringCellValue);      //row.GetCell(i).StringCellValue);
                //}


                for (int i = 0; i < _TotalHeaders; i++)
                {
                    for (int j = 0; j < _lastRowNum; j++)
                    {
                        Console.WriteLine("row {0}, {1}", i, sheet.GetRow(j).Cells[i].StringCellValue);      //row.GetCell(i).StringCellValue);
                    }
                    Console.WriteLine("========");
                }

                
            }
            catch(Exception ex)
            {
                book = null;
                /*ex.StackTrace*/;
                Console.WriteLine("Exception: "+ex.StackTrace);
                //MessageBox.Show(ex.StackTrace, "Excel read error");

            }
            return _TotalHeaders;
            }
        }



    

    public class TestPOI
    {
        [Test]
        public void TestPOI_1()
        {
            var x =POI.ReadWorkbook(@"E:\C#-Projects\SeleniumProjects\DataHandler\DataHandler\ExcelData\A.xlsx");
            Console.WriteLine(x);
        }

        [Test]
        public void TestXlInterface1()
        {
            XlReader xl = new XlReader(@"E:\C#-Projects\DataFiles\ExlData.xlsx","Sheet1");
            Console.WriteLine(xl.CountExlRows());
            Console.WriteLine(xl.CountExlColumns());

            xl.GetValuesUsingHeaderName("");

        }

        [Test]
        public void TestXlInterface2()
        {
            XlReader xl = new XlReader(@"E:\C#-Projects\DataFiles\ExlData.xlsx", "Sheet5");
            Console.WriteLine(xl.GetColumnsOfSpecifiedRows(0));
         
            Console.WriteLine(xl.CountExlRows());
            Console.WriteLine(xl.CountExlColumns());

            xl.consolePrinter();
           

        }



    }




}
