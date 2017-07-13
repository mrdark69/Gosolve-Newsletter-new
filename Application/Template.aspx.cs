using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        string[] dd = { "fixed-sidebar", "no-skin-config", "full-height-layout" };
        //StyleCore dd = new StyleCore();
        StyleCore.arrayClass = dd;



    }
}