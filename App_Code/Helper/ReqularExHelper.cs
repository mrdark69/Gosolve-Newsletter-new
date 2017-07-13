using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


/// <summary>
/// Summary description for ReqularExHelper
/// </summary>
/// 
namespace Interface_API
{
    public static class ReqularExHelper
    {
        public static string RegMiniJson(this string myJSON)
        {
            return Regex.Replace(myJSON, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
        }
    }

   
    
}
  