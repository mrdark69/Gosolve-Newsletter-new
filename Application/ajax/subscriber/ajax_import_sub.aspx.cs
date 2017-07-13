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


public partial class Application_ajax_import_sub : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        string userId = HttpContext.Current.User.Identity.GetUserId();
        string strFileName = string.Empty;
        string strPath = string.Empty;
        int totalCount = 0;

        Base64BinarySrtingToFile save = new Base64BinarySrtingToFile
        {
            FilePrefix = userId
        };
        save.SaveFileNew("FileUpload");


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
            msg = "formet:" + save.Format + "  filename:" + save.FileName + save.Error + save.ErrorDetail,
            Totalrecord = totalCount.ToString(),
            KeyID = userId

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);




       
    }







}