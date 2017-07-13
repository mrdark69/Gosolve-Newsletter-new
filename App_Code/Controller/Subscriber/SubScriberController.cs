using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.Web.UI;

/// <summary>
/// Summary description for SubScriberController
/// </summary>
public class SubScriberController
{
    public SubScriberController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static object GetGroupList_DatatbleView(DTParameters param)
    {
        Model_Subscriber cSG = new Model_Subscriber();
        
        return cSG.getSubscriberAll_DataTable(param); 
    }

    public static IList<Model_SubscriberGroup> GetAllGroup ()
    {
        Model_SubscriberGroup cSG = new Model_SubscriberGroup();

        return cSG.getSubscriberAll();
    }



    public static Model_Subscriber GetSubProfileDetail()
    {
        Model_Subscriber cSG = new Model_Subscriber();

        return cSG.GetSubProfile();
    }


    public static bool UpDateSub(int sid)
    {
        Model_Subscriber sub = new Model_Subscriber();
        return sub.UpdateUnSub(sid);
    }

    public static int InsertGroup(Model_Subscriber param)
    {
        Model_Subscriber cSG = new Model_Subscriber();

        
        return cSG.model_InsertSubscriber(param);

        //return 1;
    }
    public static bool UpdateGroup(List<Model_Subscriber> param)
    {
        Model_Subscriber cSG = new Model_Subscriber();


        return cSG.modeol_UpdateSubcriberGroup(param);

        //return 1;
    }
    public static int DeleteGroup(List<Model_Subscriber> param)
    {
        Model_Subscriber cSG = new Model_Subscriber();


        return cSG.model_DeleteSubscriber(param);

        //return 1;
    }



    public static List<Model_Subscriber> GetUnverifyList()
    {
        Model_Subscriber cSG = new Model_Subscriber();

        return cSG.GetUnverify();
    }

    public static bool UpdateVerify(Model_Subscriber ms)
    {
        return ms.UpdateVerify(ms);
    }
}