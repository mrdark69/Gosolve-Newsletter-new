using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SendingController
/// </summary>
public class SendingController
{
    public SendingController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static int SendQue()
    {
        Model_Campaign c = new Model_Campaign();
         Model_Mailbox m = new Model_Mailbox();
      
        IList<Model_Campaign> cl = c.model_Que();
        IList<Model_Mailbox> ml = m.model_Que();


        //SendingJob sj = new SendingJob();
        //SendingJobItem st = new SendingJobItem();

        

        foreach(Model_Campaign i in cl)
        {

            byte mailStatus = 3;
            byte jobstatus = 1;
            Model_SendingJob sd = new Model_SendingJob();

            try
            {
                bool IsinTime = QueIsinTime(i.DateTimePublish);
                IList<Model_Subscriber> sl = allSubscriber(i.SG);
                var sl_filter = sl.Where(e => MAilSender.IsMatchEmail(e.Email)).GroupBy(j => j.Email);

                int TotalSubscriber = sl_filter.Count();


                sd = QueAddJob(sd,i.IsSchedule, i.CID, TotalSubscriber, IsinTime, 1);


                //Sending
              
                if (sd.SDID > 0)
                {
                   

                    QueAddJobItem(sd, sl_filter);
                }
            }
            catch
            {

            }

            sd.UpdateJobStatus(sd.SDID, jobstatus);
            i.model_updatestatus(i.CID, mailStatus);
            i.model_UpdateToJob(i.CID, true);
        }

        foreach (Model_Mailbox i in ml)
        {
            byte mailStatus = 3;
            byte jobstatus = 1;
            Model_SendingJob sd = new Model_SendingJob();
            try
            {
                bool IsinTime = QueIsinTime(i.DateTimePublish);
                IList<Model_Subscriber> sl = allSubscriber(i.SG);
                var sl_filter = sl.Where(e => MAilSender.IsMatchEmail(e.Email)).GroupBy(j => j.Email);

                string[] mailboxreciever = MailAddress(i.Mailaddress);


                int TotalSubscriber = sl_filter.Count();
                int Totalmailbox = mailboxreciever.Count();

                sd = QueAddJob(sd,i.IsSchedule, i.CID, TotalSubscriber + Totalmailbox, IsinTime, 2);

              
                if (sd.SDID > 0)
                {
                  
                    QueAddJobItem(sd, sl_filter, mailboxreciever);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message + ex.StackTrace;
            }

            sd.UpdateJobStatus(sd.SDID, jobstatus);
            i.model_updatestatus(i.CID, mailStatus);

            i.model_UpdateToJob(i.CID, true);


        }

        

        return SendNow();
    }

    public static IList<Model_SendingJob> GetProcessSendingAndUpdateStatus()
    {
        Model_SendingJob mj = new Model_SendingJob();

        mj.UpdateStatusMailProcess();

       return mj.GetSendingJob();
    }

    public static int SendNow()
    {
        return SendingEngineController.TaskSendingNow();
    }

    private static void QueAddJobItem(Model_SendingJob rs, IEnumerable<IGrouping<string, Model_Subscriber>> sl_filter, string[] MailAddress  = null)
    {
        if (rs.SDID > 0)
        {


            if(MailAddress!=null && MailAddress.Length > 0)
            {
                int count1 = 1;
                foreach (string m in MailAddress)
                {
                    if (!string.IsNullOrEmpty(m))
                    {
                        Model_SendingJobItem st = new Model_SendingJobItem();
                        st.SDID = rs.SDID;
                        st.Que = count1;
                        st.Status = true;
                        st.IsSent = false;
                        st.Email = m;
                       
                        st.AddJobItem(st);
                    }
                    count1 = count1 + 1;
                }
            }

            //JobItem


            int count = 1;
            foreach (var group in sl_filter)
            {
                string Email = group.Key;
                if (!string.IsNullOrEmpty(Email))
                {
                    Model_SendingJobItem st = new Model_SendingJobItem();
                    st.SDID = rs.SDID;
                    st.Que = count;
                    st.Status = true;
                    st.IsSent = false;
                    st.Email = Email;
                    st.SID = group.FirstOrDefault().SID;
                    st.AddJobItem(st);
                }



                count = count + 1;
            }



        }
    }

    private static Model_SendingJob QueAddJob(Model_SendingJob sj,bool IsSch ,int CID ,int total_reciever, bool IsinTime, byte CType)
    {
       
        //mainJob
        sj.CID = CID;
        sj.StatusID = 1;
        //Ctype 1 for Campaign
        sj.CType = CType;
        sj.Isdone = false;
        sj.TotalSend = total_reciever;
        
        return sj.AddJob(sj);
    }

    private static bool QueIsinTime(DateTime dDatePublish)
    {
        //check time sendind  thailand zone
        DateTime dlocal = DateTime.UtcNow.ToZone();
        // Isscheduler  1 = sendnow; 0 =send later (if checktime)
       
        //DateTime dDatePublish = i.DateTimePublish;
        TimeSpan diff = dlocal.Subtract(dDatePublish);
        bool IsinTime = diff.Days < 0 || diff.Hours < 0 || diff.Minutes < 0;

        return IsinTime;
    }


    private static string[] MailAddress(string mailadddress)
    {
        string[] arrS = { };
        if (!string.IsNullOrEmpty(mailadddress) )
        {
            arrS = Array.FindAll(mailadddress.Split(';'), e => MAilSender.IsMatchEmail(e));


        }
        return arrS; 
    }

    private static IList<Model_Subscriber> allSubscriber(string SG)
    {
        Model_Subscriber s = new Model_Subscriber();
        List<Model_Subscriber> sl = new List<Model_Subscriber>();

        
        if (!string.IsNullOrEmpty(SG))
        {
            string[] arrS = SG.Split(',');
            int cou = 0;
            foreach (string g in arrS)
            {
                if (cou == 0)
                    sl = s.model_getSubbyGroup(int.Parse(g));
                else
                    sl.AddRange(s.model_getSubbyGroup(int.Parse(g)));
               
                cou = cou + 1;
            }

        }


        return sl;
    }

   
}