
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

public partial class Application_ajax_webmethod_campaign : System.Web.UI.Page
{


    [WebMethod]
    public static void InsertNewCampaign(Model_Campaign parameters)
    {
        Model_Campaign ret = CampaignController.InsertTemplate(parameters);
       

        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }


    [WebMethod]
    public static void GetAll(Model_Campaign parameters)
    { 
        IList<Model_Campaign> ret = CampaignController.GetAllCampaign(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetAll_checkprocess(Model_Campaign parameters)
    {
        IList<Model_Campaign> ret = CampaignController.GetAllCampaignCP(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetItemById(Model_Campaign parameters)
    {
        Model_Campaign ret = CampaignController.GetItemById(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }
    [WebMethod]
    public static void UpdateCampaign(Model_Campaign parameters)
    {
        Model_Campaign ret = CampaignController.Update(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void Cancel(object parameters)
    {
        // bool ret = TemplateController.Delete(parameters);
        bool ret = CampaignController.Updatestatus(parameters,6);
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
    public static void Trash(object parameters)
    {

        bool ret = CampaignController.Updatestatus(parameters,5);
      
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
    public static void CheckStatus()
    {

        bool success = true;
        string msg = "no";
        bool Isprocess = false;
        string Total = "0";
        string PerCent = "0";

        SubScriberImportController.Lock.AcquireReaderLock(Timeout.Infinite);
        Isprocess = SubScriberImportController.Onprocess;
        PerCent = SubScriberImportController.PercentCompleted.ToString("0");
        Total = SubScriberImportController.TotalCompleted.ToString();

        SubScriberImportController.Lock.ReleaseReaderLock();


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg,
            IsOnprocess = Isprocess,
            PerCentCompleted = PerCent,
            Totalrecord = Total


        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }

}