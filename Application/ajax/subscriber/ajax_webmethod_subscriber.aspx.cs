
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVCDatatableApp;

public partial class Application_ajax_subscriber_ajax_webmethod_subscriber : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    Response.Write("sss");
    //    Response.End();
    //}
    [WebMethod]
    public static void DataAll(DTParameters parameters)
    {
      
        SendResponse(HttpContext.Current.Response, SubScriberGroupController.GetGroupList_DatatbleView(parameters));
    }

    [WebMethod]
    public static void GetAll(DTParameters parameters)
    {
        AppTools.SendResponse(HttpContext.Current.Response, SubScriberGroupController.GetGroupList(parameters).ObjectToJSON());
        
    }

    [WebMethod]
    public static void InsertGroup(Model_SubscriberGroup parameters)
    {
        int ret = SubScriberGroupController.InsertGroup(parameters);
        bool success = false;
        string msg = "no";
       
        if (ret > 0)
        {
            success = true;
            msg = "Insert Completed!!";
        }
    
        //IList<IDictionary<string, object>> obj = new List<IDictionary<string, object>>();
        IDictionary<string, object> idic = new Dictionary<string, object>();
        idic.Add("success", success);
        idic.Add("msg", msg);
        
        SendResponse(HttpContext.Current.Response, idic);
    }

    [WebMethod]
    public static void Update(List<Model_SubscriberGroup> parameters)
    {
        bool ret = SubScriberGroupController.UpdateGroup(parameters);


        bool success = false;
        string msg = "no";

        if (ret)
        {
            success = true;
            msg = "Update Completed!!";
        }

        //IList<IDictionary<string, object>> obj = new List<IDictionary<string, object>>();
        IDictionary<string, object> idic = new Dictionary<string, object>();
        idic.Add("success", success);
        idic.Add("msg", msg);

        SendResponse(HttpContext.Current.Response, idic);
    }

    [WebMethod]
    public static void Delete(List<Model_SubscriberGroup> parameters)
    {
        int ret = SubScriberGroupController.DeleteGroup(parameters);


        bool success = false;
        string msg = "no";

        if (ret > 0)
        {
            success = true;
            msg = "Delete Completed!!";
        }

        //IList<IDictionary<string, object>> obj = new List<IDictionary<string, object>>();
        IDictionary<string, object> idic = new Dictionary<string, object>();
        idic.Add("success", success);
        idic.Add("msg", msg);

        SendResponse(HttpContext.Current.Response, idic);
    }

    //SendResponse(HttpContext.Current.Response, resultSet);
    private static void SendResponse(HttpResponse response, object result)
    {
        response.Clear();
        response.Headers.Add("X-Content-Type-Options", "nosniff");
        response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
        response.ContentType = "application/json; charset=utf-8";
        response.Write(result.ObjectToJSON());
        response.Flush();
        response.End();
    }
}