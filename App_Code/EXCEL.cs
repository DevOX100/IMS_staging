using System;
using Spire.Xls;


public class EXCEL : db
{
    public static void excelopen(string[] args)
    {
        string FileName = "Dummy";
        string FullFileName = FileName + ".xlsx";
        //Get Excel File
        Workbook workbook = new Workbook();
        workbook.LoadFromFile("");

        //Initailize worksheet
        Worksheet sheet = workbook.Worksheets[0];

        //Protect cells
        /// sheet.Protect(“LockCells”);

        //Set Unlocked Cell
        // sheet.Range[“A1”].Style.Locked = false;

        //Protect Workbook
        workbook.Protect("123");

        //Save and Launch
        workbook.SaveToFile(FullFileName, ExcelVersion.Version2010);
        System.Diagnostics.Process.Start(workbook.FileName);
    }
}