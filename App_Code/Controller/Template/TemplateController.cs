using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Template
/// </summary>
public class TemplateController
{



    public TemplateController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static bool Delete(Model_Template param)
    {

        bool ret = false;
        EmailEelements el = new EmailEelements();
        if (param.model_DeleteTemplate(param))
          ret =  el.model_RemoveElement(param.EID);



        return ret;



    }

    public static Model_Template Update(Model_Template param)
    {
        Model_Template cm = null;

        cm = param.model_UpdateEmailElement(param);


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

        return cm;



    }
    public static Model_Template InsertTemplate(Model_Template param)
    {
        Model_Template cm = null;
       
        cm = param.model_InsertEmailEelement(param);
       

        //Model_Template cm =  param.model_InsertEmailEelement(param);
       // cm = cm.model_InsertEmailEelement(param);

        if(!string.IsNullOrEmpty(cm.EID))
        {
            EmailEelements el = new EmailEelements
            {
                EID = cm.EID,
                Eelement = cm.EL.ObjectToJSON()
            };
            el.model_InsertEmailEelement(el);

        }

        return cm;

    
       
    }

    public static IList<Model_Template> GetTemplate(object param)
    {
        Model_Template cm = new Model_Template();

        return cm.model_GetElementList();
        

    }


}