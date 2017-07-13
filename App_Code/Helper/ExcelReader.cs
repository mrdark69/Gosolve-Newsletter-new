using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExcelReader
/// </summary>
public class ExcelReader
{
    public string Path { get; set; }
    public string FileName { get; set; }
   
    public ExcelReader(string strPath, string strFilename)
    {
        this.Path = strPath;
        this.FileName = strFilename;
        //

       // this.excelReader = CoreReader();
        // TODO: Add constructor logic here
        //
    }

    private IExcelDataReader CoreReader()
    {
       string appPath =  HttpContext.Current.Server.MapPath(this.Path);
        FileStream stream = File.Open(appPath + this.FileName, FileMode.Open, FileAccess.Read);

        //Choose one of either 1 or 2
        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
        // IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

        //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
       
        return excelReader;
    }
    public int TotalDataRecord()
    {
        int count = 0;
        using (IExcelDataReader excelReader = CoreReader())
        {
            while (excelReader.Read())
            {
                count = count + 1;
                //excelReader.GetInt32(0);
            }

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
        }


        return count;
    }
    /// <summary>
    /// DataSet - The result of each spreadsheet will be created in the result.Tables
    /// </summary>
    /// <returns></returns>
    public DataSet GetDataSetspreadsheet()
    {
        DataSet result = null;
        using (IExcelDataReader excelReader = CoreReader())
        {
            //Choose one of either 3, 4, or 5
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
           result = excelReader.AsDataSet();
            excelReader.Close();
        }

        return result;
    }

    /// <summary>
    /// DataSet - Create column names from first row
    /// </summary>
    /// <returns></returns>
    public DataSet GetDataSetCreatecolumn()
    {

        DataSet result = null;
        using (IExcelDataReader excelReader = CoreReader())
        {
            //Choose one of either 3, 4, or 5
            ////4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            result = excelReader.AsDataSet();
            excelReader.Close();
        }
        
       
        return result;
    }

}