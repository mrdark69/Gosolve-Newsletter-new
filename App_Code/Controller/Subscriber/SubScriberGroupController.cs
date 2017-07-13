using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.Web.UI;

/// <summary>
/// Summary description for SubScriberGroupController
/// </summary>
public class SubScriberGroupController
{
    public SubScriberGroupController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static IList<Model_SubscriberGroup> GetGroupList(DTParameters param)
    {
        Model_SubscriberGroup cSG = new Model_SubscriberGroup();

        return cSG.getSubscriberAll();
    }

    public static object GetGroupList_DatatbleView(DTParameters param)
    {
        Model_SubscriberGroup cSG = new Model_SubscriberGroup();
        
        return cSG.getSubscriberGroupAll_DataTable(param); 
    }

    public static int InsertGroup(Model_SubscriberGroup param)
    {
        Model_SubscriberGroup cSG = new Model_SubscriberGroup();

        
        return cSG.model_InsertSubscriberGroup(param);

        //return 1;
    }
    public static bool UpdateGroup(List<Model_SubscriberGroup> param)
    {
        Model_SubscriberGroup cSG = new Model_SubscriberGroup();


        return cSG.modeol_UpdateSubcriberGroup(param);

        //return 1;
    }
    public static int DeleteGroup(List<Model_SubscriberGroup> param)
    {
        Model_SubscriberGroup cSG = new Model_SubscriberGroup();


        return cSG.model_DeleteSubscriberGroup(param);

        //return 1;
    }
}