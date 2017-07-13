using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_Unsubscribe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            string sid = Request.QueryString["sid"];

            if (!string.IsNullOrEmpty(sid))
            {
                SubScriberController.UpDateSub(int.Parse(sid));
            }
        }
    }
}