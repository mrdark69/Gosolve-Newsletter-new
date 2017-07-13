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


/// <summary>
/// Summary description for SubScriberController
/// </summary>
public class SubScriberVerifytController
{
    public static ReaderWriterLock Lock = new ReaderWriterLock();
    public static int TotalCompleted { get; set; }

    public static bool Onprocess { get; set; }

    public static decimal PercentCompleted { get; set; }


    public SubScriberVerifytController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static int VerifyNow()
    {
        int ret = 0;

        List<Model_Subscriber> ms = SubScriberController.GetUnverifyList();

        int intTotal = ms.Count;
        if (intTotal > 0)
        {
            try
            {
                Lock.AcquireWriterLock(Timeout.Infinite);
                SubScriberVerifytController.TotalCompleted = 0;
                SubScriberVerifytController.PercentCompleted = 0.0M;
                SubScriberVerifytController.Onprocess = true;
                Lock.ReleaseWriterLock();

                int tNum = 20;
                int Size = (int)Math.Ceiling((decimal)(intTotal / tNum));

                if (intTotal < tNum)
                {
                    tNum = 1;
                    Size = intTotal;
                }
                    




                int pageSize = Size;
                for (int i = 0; i < tNum; i++)
                {

                    int start = ((i * pageSize) + 1);
                    int end = ((i * pageSize) + pageSize);
                    List<Model_Subscriber> msfilter = ms.Where(r => r.RowNum >= start && r.RowNum <= end).ToList();
                    API_ThreadPool cpool = new API_ThreadPool();
                    object[] parameters = new object[] { msfilter  , intTotal };
                    cpool.QueueWork(parameters, VerifySubscriber);
                }

               

                ret = 1;
            }
            catch { }
            
        }

     
        return ret;
    }


    public static void VerifySubscriber(object param)
    {
        object[] parameters = (object[])param;
        List<Model_Subscriber> ms = (List<Model_Subscriber>)parameters[0];
        int Total  = (int)parameters[1];
        //int Total = ms.Count;
        Codicode.EmailValidator Ev = new Codicode.EmailValidator();
        //We create our Mail Validator Object
        //Codicode.Emailvalidator Ev = new Codicode.Emailvalidator();
        //  Sender email (for smtp identification)
        Ev.Mail_From = "info@gosolve.net";

        //  Sender email (for smtp identification)
        //bool Valid_Email = Ev.Check_MailBox(txtemail.Text.Trim());

       

        foreach (Model_Subscriber m in ms)
        {
            string err = Ev.Check_MailBox_Error(m.Email.Trim());
            string ret = "";
            if (err == "")
            {
                ret = "mail ok";
                m.Detail = string.Empty;
            }
            else
            {
                ret = err;
                m.Sbin = false;
                m.Detail = err;
            }

            SubScriberController.UpdateVerify(m);
            Ev.Dispose();

            Lock.AcquireWriterLock(Timeout.Infinite);
            SubScriberVerifytController.TotalCompleted += 1;
            SubScriberVerifytController.PercentCompleted =
                 (decimal)SubScriberVerifytController.TotalCompleted * 100 / Total;
            Lock.ReleaseWriterLock();
        }

        Lock.AcquireWriterLock(Timeout.Infinite);
        SubScriberVerifytController.Onprocess = false;
        Lock.ReleaseWriterLock();


    }



}