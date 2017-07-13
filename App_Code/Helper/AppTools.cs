using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppTool
/// </summary>
public static class AppTools
{
    public static string ImportPath()
    {
        return ConfigurationManager.AppSettings["ImportPath"];
    }

    public static string UploadMediaPath()
    {
        return ConfigurationManager.AppSettings["UploadMediaPath"];
    }

    public static string TemplateMockPath()
    {
        return ConfigurationManager.AppSettings["TemplateMockPath"];
    }

    


    public static void SendResponse(HttpResponse response, object result)
    {
        response.Clear();
        response.Headers.Add("X-Content-Type-Options", "nosniff");
        response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
        response.ContentType = "application/json; charset=utf-8";
        response.Write(result);
        response.Flush();
        response.End();
    }
}