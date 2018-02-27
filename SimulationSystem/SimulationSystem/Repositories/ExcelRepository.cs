using Microsoft.Office.Interop.Excel;
using SimulationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;


namespace SimulationSystem.Repositories
{
    public class ExcelRepository
    {
        public ExcelRepository()
        {

        }
        public List<Address> readExcel()
        {
            string root = AppDomain.CurrentDomain.BaseDirectory;
            string fname = root + @"\Resources\adressen_be.xls";
            List<Address> addresses = new List<Address>();

            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
                Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = 1; i <= rowCount; i++)
                {
                    string street = xlRange.Cells[i, 1].Value2.ToString();
                    string number = xlRange.Cells[i, 2].Value2.ToString();
                    string zip = xlRange.Cells[i, 3].Value2.ToString();
                    string city = xlRange.Cells[i, 4].Value2.ToString();
                    Address a = new Address(street, number, zip, city);
                    addresses.Add(a);
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception e)
            {

            }

            return addresses;
        }
    }
}