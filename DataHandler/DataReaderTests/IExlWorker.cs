using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DataHandler.DataReader
{
    public interface IExlWorker
    {
        ISheet GetSheetObject();
        int CountExlRows();
        int CountExlColumns();
        List<string> GetValuesUsingHeaderName(string headerName);

        int GetColumnsOfSpecifiedRows(int row_num);

        void letsPrint(int x);



    }

    public class XlReader : IExlWorker
    {
        public string ExlFile;
        public string sheetName;

        public XlReader(string ExlFile,string sheetName)
        {
            this.ExlFile = ExlFile;
            this.sheetName = sheetName;
        }

        public ISheet GetSheetObject()
        {
            IWorkbook book;
            ISheet sheet=null;
            FileStream fs = new FileStream(ExlFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            try
            {
                book = new XSSFWorkbook(fs);
                //book = new HSSFWorkbook(fs);
                sheet = book.GetSheet(sheetName); //.CreateSheet("Sheet1");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("undefined sheet name: "+ex.Message);
            }
            return sheet;
        }


        public int CountExlRows()
        {
            ISheet sheet = GetSheetObject();
            int _TotalRows = sheet.GetRow(0).Cells.Count();
            return _TotalRows;
        }
        public int CountExlColumns()
        {
            ISheet sheet = GetSheetObject();
            int _TotalColumns = sheet.GetRow(0).LastCellNum;
            return _TotalColumns;
            
        }
        public List<string> GetValuesUsingHeaderName(string headerName)
        {
            List<string> xl = new List<string>();
            for (int i = 0; i < CountExlRows(); i++)
            {
                for (int j = 0; j < CountExlColumns(); j++)
                {
                    Console.WriteLine("row {0}, {1}", i, GetSheetObject().GetRow(j).Cells[i].StringCellValue);      //row.GetCell(i).StringCellValue);
                    xl.Add(GetSheetObject().GetRow(j).Cells[i].StringCellValue);
                }
                Console.WriteLine("========");
            }
            return xl;
        }

        public int GetColumnsOfSpecifiedRows(int row_num)
        {
            int _TotalColumns=0;
            
            try
            {
                ISheet sheet = GetSheetObject();
                //_TotalColumns = sheet.GetRow(row_num).LastCellNum;
                _TotalColumns = sheet.GetRow(row_num).Cells.Count;
                int c = sheet.GetRow(2).Cells.Count;

                for (int i = 0; i < CountExlRows(); i++)
                {
                    for (int j = 0; j < CountExlColumns(); j++)
                    {
                        Console.WriteLine("row {0}, {1}", i, GetSheetObject().GetRow(j).Cells[1]);      //row.GetCell(i).StringCellValue);
                        
                    }
                    //Console.WriteLine("||");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _TotalColumns;
        }


        public void letsPrint(int x)
        {
               
        }

        public void consolePrinter()
        {
            //int _TotalColumns = 0;

            ISheet sheet = GetSheetObject();
            int noOfColumns = sheet.GetRow(2).PhysicalNumberOfCells;


            Console.WriteLine("=====");
            Console.WriteLine(sheet.GetRow(0).GetCell(0));
            Console.WriteLine(sheet.GetRow(1).GetCell(0));
            Console.WriteLine(sheet.GetRow(2).GetCell(0));
            Console.WriteLine(sheet.GetRow(3).GetCell(0));
            Console.WriteLine("=====");


            Console.WriteLine("=====");

            Console.WriteLine(sheet.GetRow(1).PhysicalNumberOfCells);//.GetRow(0).LastCellNum);
            Console.WriteLine(sheet.GetRow(2).PhysicalNumberOfCells);
            Console.WriteLine(sheet.LastRowNum);
            
            Console.WriteLine("=====");


            for (int j = 0; j < CountExlColumns(); j++)
            {
                Console.WriteLine("row {0}", GetSheetObject().GetRow(j).Cells[2]);

            }
        }
        
        public void RowIter()
        {
           

        }




    }//end class

}//end namespace
