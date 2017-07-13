
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVCDatatableApp;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNet.Identity;
using Excel;
using System.Data;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using System.Threading;

public partial class Application_ajax_webmethod_template : System.Web.UI.Page
{


    [WebMethod]
    public static void InsertNewTemplate(Model_Template parameters)
    {
        Model_Template ret = TemplateController.InsertTemplate(parameters);
       

        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void DeleteTemplate(Model_Template parameters)
    {
       
        bool ret = TemplateController.Delete(parameters);
        bool success = false;
        string msg = "no";

        if (ret)
        {
            success = true;
            msg = "Delete Completed!!";
        }


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }

    [WebMethod]
    public static void UpdateTemplate(Model_Template parameters)
    {
        Model_Template ret = TemplateController.Update(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetAll(object parameters)
    {


        IList<Model_Template> ret = TemplateController.GetTemplate(parameters);

       AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }


}