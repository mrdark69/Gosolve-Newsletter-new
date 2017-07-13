using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;

/// <summary>
/// Summary description for Model_Subscriber
/// </summary>
public class Model_SubscriberParamImport : BaseModel<Model_Subscriber>
{

    public string Key { get; set; }
    public string Total { get; set; }
    public string Group { get; set; }
   

    public Model_SubscriberParamImport()
    {
        //
        // TODO: Add constructor logic here
        //

    }


   
}