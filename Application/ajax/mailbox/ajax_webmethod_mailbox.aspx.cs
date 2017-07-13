
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

public partial class Application_ajax_webmethod_mailbox : System.Web.UI.Page
{


    [WebMethod]
    public static void InsertNewMailbox(Model_Mailbox parameters)
    {
        Model_Mailbox ret = MailboxController.InsertTemplate(parameters);
       

        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }


    [WebMethod]
    public static void GetAll(Model_Mailbox parameters)
    { 
        IList<Model_Mailbox> ret = MailboxController.GetAllMailbox(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetAll_checkprocess(Model_Mailbox parameters)
    {
        IList<Model_Mailbox> ret = MailboxController.GetAllMailboxCP(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }


    [WebMethod]
    public static void GetItemById(Model_Mailbox parameters)
    {
        Model_Mailbox ret = MailboxController.GetItemById(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }
    [WebMethod]
    public static void UpdateCampaign(Model_Mailbox parameters)
    {
        Model_Mailbox ret = MailboxController.Update(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void Cancel(object parameters)
    {
        // bool ret = TemplateController.Delete(parameters);
        bool ret = MailboxController.Updatestatus(parameters,6);
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

        bool ret = MailboxController.Updatestatus(parameters,5);
      
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
        //string Total = "0";
        //string PerCent = "0";
      

        SendingEngineController.Lock.AcquireReaderLock(Timeout.Infinite);
        Isprocess = SendingEngineController.Onprocess;

        //sendprocess = SendingEngineController.SendResponse;
        SendingEngineController.Lock.ReleaseReaderLock();


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg,
            IsOnprocess = Isprocess,
            Sendprocess = SendingController.GetProcessSendingAndUpdateStatus()


        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }

}