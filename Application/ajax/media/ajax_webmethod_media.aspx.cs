
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

public partial class Application_ajax_webmethod_media : System.Web.UI.Page
{


    [WebMethod]
    public static void GetMedia(object parameters)
    {
        IDictionary<string, object> data = (IDictionary<string, object>)parameters;
        //string res = (new BaseWebMethodAJax
        //{
        //    success = success,
        //    msg = msg,
        //    IsOnprocess = Isprocess,
        //    PerCentCompleted = PerCent,
        //    Totalrecord = Total


        //}).

        int intCat = int.Parse(data["Tax"].ToString());
        string intType = data["Type"].ToString();

        AppTools.SendResponse(HttpContext.Current.Response, MediaController.GetMediaAll(intCat, intType).ObjectToJSON());
    }


    [WebMethod]
    public static void GetMediaCat(object parameters)
    {
       
        AppTools.SendResponse(HttpContext.Current.Response, MediaController.GetTaxonomyListByRef().ObjectToJSON());
    }



    [WebMethod]
    public static void Delete(MediaModel parameters)
    {

        bool ret = MediaController.DeleteMedia(parameters);
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
    public static void BulkUpdateCat(List<MediaTax> parameters)
    {

        int ret = MediaController.InsertMediaTax(parameters);
        bool success = false;
        string msg = "no";

        if (ret > 0)
        {
            success = true;
            msg = "Update Completed!!";
        }


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);

    }


    [WebMethod]
    public static void BulkDelete(List<MediaModel> parameters)
    {

        bool ret = MediaController.DeleteMedia(parameters);
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
    public static void InsertCat(object parameters)
    {
        IDictionary<string, object> data = (IDictionary<string, object>)parameters;

        string steCatTitle = data["CatVal"].ToString();
        int ret = MediaController.InsertChildTaxonomy(steCatTitle);
        bool success = false;
        string msg = "no";

        if (ret >0)
        {
            success = true;
            msg = "Insert Completed!!";
        }


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);

    }


    [WebMethod]
    public static void UpdateMedia(MediaModel parameters)
    {
        int ret = MediaController.Update(parameters);
        bool success = false;
        string msg = "no";

        if (ret >0)
        {
            success = true;
            msg = "Insert Completed!!";
        }


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);

       
    }


    [WebMethod]
    public static void UpdateBulk(object parameters)
    {

        //string res = (new BaseWebMethodAJax
        //{
        //    success = success,
        //    msg = msg,
        //    IsOnprocess = Isprocess,
        //    PerCentCompleted = PerCent,
        //    Totalrecord = Total


        //}).

        AppTools.SendResponse(HttpContext.Current.Response, MediaController.GetMediaAll().ObjectToJSON());
    }




}