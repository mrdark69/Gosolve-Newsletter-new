using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Template
/// </summary>
public class MailboxController
{



    public MailboxController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static Model_Mailbox InsertTemplate(Model_Mailbox param)
    {
        Model_Mailbox cm = null;

        param.CreatedBy = HttpContext.Current.User.Identity.GetUserId();
        cm = param.model_InsertMailbox(param);


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

    public static IList<Model_Mailbox> GetMailbox(string param)
    {
        Model_Mailbox c = new Model_Mailbox(HttpContext.Current);
        return c.model_Que(param);
    }

    public static IList<Model_Mailbox> GetAllMailbox(Model_Mailbox param)
    {

        Model_SendingJob mj = new Model_SendingJob();

        mj.UpdateStatusMailProcess();
        return param.model_getMailbox(param);
    }
    public static IList<Model_Mailbox> GetAllMailboxCP(Model_Mailbox param)
    {

        Model_SendingJob mj = new Model_SendingJob();

        mj.UpdateStatusMailProcess();
        return param.model_getMailbox_checkProcess(param);
    }

    public static bool Updatestatus(object param, byte CSID)
    {
        Model_Mailbox c = new Model_Mailbox();

        object[] arr = (object[])param;

        for (int i = 0; i < arr.Length; i++)
        {
            c.model_updatestatus(int.Parse( (string)arr[i]), CSID);
        }


        SendingController.SendQue();

        return true;
    }


    public static Model_Mailbox GetItemById(Model_Mailbox param)
    {
        EmailEelements e = new EmailEelements();
        Model_Mailbox c = param.model_getMailboxByID(param); 
        c.EL = (EModel)e.model_GetElementBYID(c.EID).Eelement.JsonToObject(new EModel());

        return c;
    }

    public static Model_Mailbox Update(Model_Mailbox param)
    {
        Model_Mailbox cm = null;

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