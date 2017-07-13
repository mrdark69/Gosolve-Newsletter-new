using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Template
/// </summary>
public class CampaignController
{



    public CampaignController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static Model_Campaign InsertTemplate(Model_Campaign param)
    {
        Model_Campaign cm = null;
        param.CreatedBy = HttpContext.Current.User.Identity.GetUserId();
        cm = param.model_InsertCampaign(param);


        //Model_Template cm =  param.model_InsertEmailEelement(param);
        // cm = cm.model_InsertEmailEelement(param);

        if (!string.IsNullOrEmpty(cm.EID))
        {
            EmailEelements el = new EmailEelements
            {
                EID = cm.EID,
                Eelement = cm.EL.ObjectToJSON()
            };
            el.model_InsertEmailEelement(el);

        }

        SendingController.SendQue();
       
        return cm;



    }


    public static IList<Model_Campaign> GetAllCampaign(Model_Campaign param)
    {
        Model_SendingJob mj = new Model_SendingJob();

        mj.UpdateStatusMailProcess();
        return param.model_getCampaign(param);
    }

    public static IList<Model_Campaign> GetAllCampaignCP(Model_Campaign param)
    {
        Model_SendingJob mj = new Model_SendingJob();

        mj.UpdateStatusMailProcess();
        return param.model_getCampaign(param);
    }

    public static IList<Model_Campaign> GetCampaign(string param)
    {
        Model_Campaign c = new Model_Campaign(HttpContext.Current);
        return c.model_Que(param);
    }


    public static bool Updatestatus(object param, byte CSID)
    {
        Model_Campaign c = new Model_Campaign();

        object[] arr = (object[])param;

        for (int i = 0; i < arr.Length; i++)
        {
            c.model_updatestatus(int.Parse( (string)arr[i]), CSID);
        }


        SendingController.SendQue();

        return true;
    }


    public static Model_Campaign GetItemById(Model_Campaign param)
    {
        EmailEelements e = new EmailEelements();
        Model_Campaign c = param.model_getCampaignByID(param); 
        c.EL = (EModel)e.model_GetElementBYID(c.EID).Eelement.JsonToObject(new EModel());

        return c;
    }

    public static Model_Campaign Update(Model_Campaign param)
    {
        Model_Campaign cm = null;

        cm = param.model_Update(param);

        if (!string.IsNullOrEmpty(cm.EID))
        {
            EmailEelements el = new EmailEelements
            {
                EID = cm.EID,
                Eelement = cm.EL.ObjectToJSON()
            };
            el.model_InsertEmailEelement(el);

        }

        SendingController.SendQue();

        return cm;
    }

}