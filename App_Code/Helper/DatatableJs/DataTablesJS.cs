using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.Reflection;
/// <summary>
/// Summary description for DataTablesJS
/// </summary>
public class DataTablesJS<T>
{
    public DataTablesJS()
    {
        
    }
    public static List<String> getcolumnSearch(DTParameters param)
    {
        List<String> columnSearch = new List<string>();

        foreach (var col in param.Columns)
        {
            columnSearch.Add(col.Search.Value);
        }

        return columnSearch;
    }
    public static object ResponeDataTable(DTParameters param,IList<T> data,int intCount)
    {
        try
        {
            
            //List<Customer> data = new ResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, dtsource, columnSearch);
            // int count = new ResultSet().Count(param.Search.Value, dtsource, columnSearch);


            DTResult <T> result = new DTResult<T>
            {
                draw = param.Draw,
                data = data,
                recordsFiltered = intCount,
                recordsTotal = intCount
            };
            //SendResponse(HttpContext.Current.Response, result);

            return result;

        }
        catch (Exception ex)
        {
            //SendResponse(HttpContext.Current.Response, new { error = ex.Message });

            return new { error = ex.Message };
        }

      
    }

   
}