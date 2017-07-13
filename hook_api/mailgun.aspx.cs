using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hook_api_mailgun : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["my-custom-data"]))
        {
            string ret = Request.Form["event"] + ":::";
            ret = ret + "::" + Request.Form["my-custom-data"] + Request.Form["recipient"];


            try
            {
                dynamic jsn = JsonHelper.JsonTODynamic(Request.Form["my-custom-data"]);


                MailGunClass cMailGun = new MailGunClass
                {
                    BookingId = int.Parse(jsn["booking_id"]),
                    email = Request.Form["recipient"],
                    email_sendto = jsn["email_sento"],
                    email_type_id = jsn["email_type_id"],
                    email_type_title = jsn["email_type_title"],
                    EventMethod = Request.Form["event"],
                    MainSite = 2,
                    TimeStamp = Request.Form["timestamp"]

                };

                cMailGun.InsertDataTracking(cMailGun);
            }
            catch (Exception ex)
            {
                ret = ret + ex.Message + "--- " + ex.StackTrace;
            }

           // Hotels2thailand.Hotels2LogWriter.WriteFile("admin/logfile/email-tracking.html", ret + "\\r\\n");


        }
    }
}