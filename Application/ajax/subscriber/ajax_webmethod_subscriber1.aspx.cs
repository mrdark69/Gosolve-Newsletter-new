
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

public partial class Application_ajax_subscriber_ajax_webmethod_subscriber1 : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    Response.Write("sss");
    //    Response.End();
    //}
    [WebMethod]
    public static void DataAll(DTParameters parameters)
    {

        AppTools.SendResponse(HttpContext.Current.Response, SubScriberController.GetGroupList_DatatbleView(parameters).ObjectToJSON());
    }


    [System.Web.Services.WebMethod]
    public static void SaveImage(string Based64BinaryString)
    {
        string userId = HttpContext.Current.User.Identity.GetUserId();
        string strFileName = string.Empty;
        string strPath = string.Empty;
        int totalCount = 0;

        Base64BinarySrtingToFile save = new Base64BinarySrtingToFile
        {
            FilePrefix = userId
        };
        save.SaveFile(Based64BinaryString);
        bool issave = false;

        if (save.IsSaved)
        {
            issave = true;
            strFileName = save.FileName;
            strPath = save.Path;

            switch (save.Format)
            {
                case "csv":
                    totalCount = new GsCsvReader(strPath, strFileName).ResultDataTable.Rows.Count;
                    break;
                case "excel":
                    totalCount = new ExcelReader(strPath, strFileName).GetDataSetCreatecolumn().Tables[0].Rows.Count;
                    break;
            }

            Model_SubscriberImportTemp temp = new Model_SubscriberImportTemp
            {
                FileName = save.FileName,
                Path = save.Path,
                TotalRecord = totalCount

            };
            SubScriberImportController.ImportTemp(temp);
        }




        string res = (new BaseWebMethodAJax
        {
            success = issave,
            msg = "formet:" +  save.Format + "  filename:" +  save.FileName + save.Error + save.ErrorDetail,
            Totalrecord = totalCount.ToString(),
            KeyID = userId

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
        //return result;
    }
    [WebMethod]
    public static void CheckStatusVerify()
    {

        bool success = true;
        string msg = "no";
        bool Isprocess = false;
        string Total = "0";
        string PerCent = "0";

        SubScriberVerifytController.Lock.AcquireReaderLock(Timeout.Infinite);
        Isprocess = SubScriberVerifytController.Onprocess;
        PerCent = SubScriberVerifytController.PercentCompleted.ToString("0");
        Total = SubScriberVerifytController.TotalCompleted.ToString();

        SubScriberVerifytController.Lock.ReleaseReaderLock();


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
    [WebMethod]
    public static void CheckStatusImport()
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

    [WebMethod]
    public static void UploadNow(Model_SubscriberParamImport parameters)
    {
        int ret = SubScriberImportController.ImportNow(parameters);
        bool success = false;
        string msg = "no";

        if (ret > 0)
        {
            success = true;
            msg = "Import Completed!!";
        }

        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }

    [WebMethod]
    public static void VerifyNow()
    {
        int ret = SubScriberVerifytController.VerifyNow();
        bool success = false;
        string msg = "no";

        if (ret > 0)
        {
            success = true;
            msg = "Import Completed!!";
        }

        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }

    [WebMethod]
    public static void InsertGroup(Model_Subscriber parameters)
    {
        int ret = SubScriberController.InsertGroup(parameters);
        bool success = false;
        string msg = "no";
       
        if (ret > 0)
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
    public static void Update(List<Model_Subscriber> parameters)
    {
        bool ret = SubScriberController.UpdateGroup(parameters);


        bool success = false;
        string msg = "no";

        if (ret)
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
    public static void Delete(List<Model_Subscriber> parameters)
    {
        int ret = SubScriberController.DeleteGroup(parameters);


        bool success = false;
        string msg = "no";

        if (ret > 0)
        {
            success = true;
            msg = "Delete Completed!!";
        }


        string res = ( new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

       

       

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }

    //SendResponse(HttpContext.Current.Response, resultSet);


    [WebMethod]
    public static void GetTotal(Model_Mailbox parameters)
    {
        Model_Subscriber ret = SubScriberController.GetSubProfileDetail();


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    



}