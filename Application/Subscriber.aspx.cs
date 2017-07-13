using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Subscriber : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void input_btn_save_Click(object sender, EventArgs e)
    {

    }

    public static string GetGroup()
    {
        IList<Model_SubscriberGroup> grouplist = SubScriberController.GetAllGroup();

        StringBuilder ret = new StringBuilder();

        int count = 0;

        foreach(Model_SubscriberGroup i in grouplist)
        {
            if(count == 0)
                ret.Append("<option selected=\"selected\" value=\"" + i.SGID + "\">" + i.SGName + "</option>");
            else
                ret.Append("<option  value=\"" + i.SGID + "\">" + i.SGName + "</option>");

            count++;
        }
        return ret.ToString();
    }

    //protected void btn_import_Click(object sender, EventArgs e)
    //{

    //}
}