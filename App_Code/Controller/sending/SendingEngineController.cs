using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Interface_API.Threadings;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Text;


/// <summary>
/// Summary description for SendingEngineController
/// </summary>
public class SendingEngineController
{
    public SendingEngineController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static ReaderWriterLock Lock = new ReaderWriterLock();

   public static API_ThreadPool cpool = new API_ThreadPool();

    public static bool Onprocess { get; set; }


    public static List<Model_SendingJob> SendResponse {get;set;}

    public static int TaskSendingNow()
    {
        Model_SendingJobItem ci = new Model_SendingJobItem();
        Model_SendingJob c = new Model_SendingJob();
        Model_Setting s = new Model_Setting();
        s = s.GetSetting();


        IList<Model_SendingJob> cl = c.GetSendingJob();
        
        Lock.AcquireWriterLock(Timeout.Infinite);
       
        SendingEngineController.Onprocess = true;
        //SendingEngineController.SendResponse = job;
        Lock.ReleaseWriterLock();

       
        //if (cpool.IsBusy)
        //    cpool.Shutdown();

        foreach(Model_SendingJob i in cl)
        {
            IList<Model_SendingJobItem> cil = ci.GetSendingJob(i.SDID);
            object[] parameters = new object[] { cil, s ,i , HttpContext.Current};
            SendingEngineController.cpool.QueueWork(parameters, Sendnow);
           // Sendnow(parameters);
        }
        
        


        //Sendnow(parameters);
        return 1;
    }

    public static void Sendnow(object param)
    {
        object[] parameters = (object[])param;
        List<Model_SendingJobItem> cli = (List<Model_SendingJobItem>)parameters[0];
        Model_Setting s = (Model_Setting)parameters[1];

        Model_SendingJob ms = (Model_SendingJob)parameters[2];

        HttpContext context = (HttpContext)parameters[3];
        //Model_SendingJob ms = new Model_SendingJob();

        //var groupCampaignCID = cli.Where(cam => cam.CType == 1).GroupBy(c => c.CID);
        //var groupMailboxCID = cli.Where(cam => cam.CType == 2).GroupBy(c => c.CID);

        //StringBuilder strCam = new StringBuilder();
        //StringBuilder strMailBox = new StringBuilder();
        //foreach (var ss in groupCampaignCID)
        //{
        //    int propertyIntOfClassA = ss.Key;
        //    strCam.Append(propertyIntOfClassA + ",");
        //}
        //strCam.Append("0");
        //foreach (var ss in groupMailboxCID)
        //{
        //    int propertyIntOfClassA = ss.Key;
        //    strMailBox.Append(propertyIntOfClassA + ",");
        //}
        //strMailBox.Append("0");


        IList<Model_Campaign> mdc = CampaignController.GetCampaign(ms.CID.ToString());
        IList<Model_Mailbox> mdm = MailboxController.GetMailbox(ms.CID.ToString());

        MailSenderOption option = new MailSenderOption
        {
            MailSetting = s,
             context = context
        };
        EmailEelements e = new EmailEelements();

        // _el = (EModel)e.model_GetElementBYID(this.EID).Eelement.JsonToObject(new EModel());
        int count = 1;
        foreach (Model_SendingJobItem c in cli)
        {
            if(c.CType == 1)
            {
                Model_Campaign cam = mdc.SingleOrDefault(r => r.CID == c.CID);
                EModel el = (EModel)cam.ELRaw.JsonToObject(new EModel());
                option.Subject = cam.Subject;

                string bodymail = el.html;
                if (cam.Unsub)
                    bodymail = bodymail.Replace("</body>", appendSubscription(c.SID));

                option.Mailbody = bodymail;

                if (!string.IsNullOrEmpty(cam.FileMail))
                {
                    option.Attachment = GetFileMail(cam.FileMail);
                }
            }
            else
            {
                Model_Mailbox cam = mdm.SingleOrDefault(r => r.CID == c.CID);
                EModel el = (EModel)cam.ELRaw.JsonToObject(new EModel());
                option.Subject = cam.Subject;

                string bodymail = appendHtmlforMailbox(el.html);
                if (cam.Unsub && c.SID != 0)
                    bodymail = bodymail.Replace("</body>", appendSubscription(c.SID));

                option.Mailbody = bodymail;

                if (!string.IsNullOrEmpty(cam.FileMail))
                {
                    option.Attachment = GetFileMail(cam.FileMail);
                }
            }
            option.mailTo = c.Email;
           
            //"info@gosolve.net", "Gosolve", c.Email, "Thread Sending", "", "Thread Sending Thread Sending"
           if(MAilSender.SendMailEngine(option))
            {
                c.UpdateStatus(c.SDIID, true);
               
            }




            // Lock.AcquireWriterLock(Timeout.Infinite);

            //SendingEngineController.SendResponse.SingleOrDefault(ii => ii.CID == c.CID).TotalSent += 1;
            // Lock.ReleaseWriterLock();



            ms.UpdateTotalSentAndISDone(c.SDID);
            count = count + 1;
        }

        Lock.AcquireWriterLock(Timeout.Infinite);
        SendingEngineController.Onprocess = false;
        Lock.ReleaseWriterLock();

    }


    private static string appendHtmlforMailbox(string content)
    {
        return "<html><head></head><body>"+ content + "</body></html>";
    }

    private static string appendSubscription(int sid)
    {
        StringBuilder ret = new StringBuilder();
        ret.Append("<table width=\"100%;margin-top:60px;\"><tr><td style=\"text-align: center;padding-top:90px;\">If you'd like to unsubscribe and stop receiving these emails <a href=\"http://dev.newsletter.com/Application/Unsubscribe?sid=" + sid+"\" >click here.</a><br/>" +
            "หากทานต้องการยกเลิกการรับอีเมล์ <a href=\"http://dev.newsletter.com/Application/Unsubscribe?sid=" + sid + "\" >กรุณากดที่นี่ </a>" +
            "</td></tr></table></body>");

        return ret.ToString();
    }

    private static List<MailSenderFileAtt> GetFileMail(string FileMail)
    {
       // IDictionary<string, string> idicAttachment = new Dictionary<string, string>();
        List<MailSenderFileAtt> lfile = new List<MailSenderFileAtt>();

        // [{"Path":"/Application/MediaLibrary/2017/04","FileName":"53PM.pdf"}]
            dynamic file = JsonHelper.JsonTODynamic(FileMail);

            object[] arrgile = (object[])file;

            foreach (object i in arrgile)
            {

                
                Dictionary<string, object> dici = (Dictionary<string, object>)i;
                if (dici.ContainsKey("Path") && dici.ContainsKey("FileName"))
                {

                    lfile.Add(new MailSenderFileAtt
                    {
                        Path = dici["Path"].ToString(),
                        FileName = dici["FileName"].ToString()
                    });
                   

                }

               
            }
           
        

        return lfile;
    }


}