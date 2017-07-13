using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Style
/// </summary>
public  class StyleCore
{
    public static  string[] arrayClass { get; set; }

    public static string bodyClass()
    {
        string ret = string.Empty;
        if(arrayClass != null)
        {
            string keyword = string.Join(" ", arrayClass);
            ret = "class=\"" + keyword + "\"";
        }
       

        return ret;
        
    }
}