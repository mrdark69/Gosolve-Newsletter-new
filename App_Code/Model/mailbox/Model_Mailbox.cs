using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;
using Microsoft.AspNet.Identity;
using gs_newsletter;
using System.Web.Providers.Entities;

/// <summary>
/// Summary description for Model_Mailbox
/// </summary>
public class Model_Mailbox : BaseModel<Model_Mailbox>
{

    public int CID { get; set; }
    public string EID { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DatetimeHelper._UTCNow();
    public string Detail { get; set; } = string.Empty;
    public string CreatedBy { get; set; }
    public bool IsSchedule { get; set; }
    public DateTime DateTimePublish { get; set; } = DatetimeHelper._UTCNow();
    public bool IsBin { get; set; }
    public bool Status { get; set; }
    public byte CSID { get; set; } = 0;
    public bool Unsub { get; set; }
    public string SG { get; set; }
    public string FileMail { get; set; } = string.Empty;
    public string CSIDTitle { get; set; }

    public string Mailaddress { get; set; }
    public bool IsinJob { get; set; }


    public bool Isdone { get; set; }
    public int TotalSend { get; set; }
    public int TotalSent{ get; set; }
    public int StatusID { get; set; }

    public int TotalRows { get; set; }
    public int RowNum { get; set; }

    public string[] SGarr { get; set; } = new string[] { };

    public int Start { get; set; }
    public int Size { get; set; } = 20;

    //private EModel _el;

    //public EModel EL
    //{
    //    get
    //    {
    //        if (_el == null)
    //        {
    //            EmailEelements e = new EmailEelements();

    //            _el = (EModel)e.model_GetElementBYID(this.EID).Eelement.JsonToObject(new EModel());
    //        }
    //        return _el;
    //    }
    //    set { _el = value; }
    //}

    public EModel EL { get; set; }

    public string ELRaw { get; set; }

    public DateTime CreateDateLocal
    {
        get {
            DateTime local = this.CreatedDate.ToZone();
            return local;

        }

    }
    
    public string Author
    {
        get
        {
            UserManager manager = new UserManager();
            if(this.CreatedBy != null)
            {
                var user = manager.FindById(this.CreatedBy);
                return user.FirstName;
            }
            else
            {
                return string.Empty;
            }

            
        }
    }

    //INSERT INTO CampaignStatus(CSID, Title)VALUES(1,'New');
    //INSERT INTO CampaignStatus(CSID, Title)VALUES(2,'Waiting Send');
    //INSERT INTO CampaignStatus(CSID, Title)VALUES(3,'Sending');
    //INSERT INTO CampaignStatus(CSID, Title)VALUES(4,'Completed');
    //INSERT INTO CampaignStatus(CSID, Title)VALUES(5,'Trash');
    //INSERT INTO CampaignStatus (CSID,Title)VALUES(6,'Cancel');
    public Model_Mailbox()
    {
       //this.CreatedBy  = HttpContext.Current.User.Identity.GetUserId();
        //
        // TODO: Add constructor logic here
        //
    }
    public Model_Mailbox(HttpContext c)
    {
        //this.CreatedBy = c.User.Identity.GetUserId();
        //
        // TODO: Add constructor logic here
        //
    }

    public IList<Model_Mailbox> model_Que()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Mailbox WHERE Status = 1 AND IsBin = 1 AND CSID = 1 AND IsinJob =0", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public IList<Model_Mailbox> model_Que(string strCID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT c.*,el.Element AS ELRaw  FROM Mailbox c 
            INNER JOIN EmailElement el  ON el.EID = c.EID WHERE c.CID IN (" + strCID + ")", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool model_UpdateToJob(int CID, bool IsinJob)
    {

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();

            StringBuilder q = new StringBuilder();
            q.Append("UPDATE Mailbox SET IsinJob =@IsinJob WHERE CID =@CID");

            cmd.Connection = cn;
            cmd.CommandText = q.ToString();
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = CID;
            cmd.Parameters.Add("@IsinJob", SqlDbType.TinyInt).Value = IsinJob;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    public IList<Model_Mailbox> model_getMailbox_checkProcess(Model_Mailbox param)
    {


        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            string strcmd = @";WITH Mailbox_cte AS (
                                SELECT c.*,cs.Title As CSIDTitle,sd.Isdone,sd.TotalSend,sd.TotalSent,sd.StatusID
                                FROM dbo.Mailbox c
                                INNER JOIN dbo.CampaignStatus cs ON cs.CSID = c.CSID
                                LEFT JOIN dbo.SendingJob sd ON sd.CID=c.CID AND sd.Ctype=2
	                            WHERE c.IsBin = 1  AND c.Status = 1  " + (CSID > 0 ? "AND c.CSID = " + CSID : "") + ")" +

                            @"SELECT 
                                db.*,
                                tCountOrders.CountOrders AS TotalRows
                            FROM Mailbox_cte db
                                CROSS JOIN (SELECT Count(*) AS CountOrders FROM Mailbox_cte) AS tCountOrders
                            ORDER BY CSID ASC ,CreatedDate DESC,CID
                            OFFSET @Start ROWS
                            FETCH NEXT @Size ROWS ONLY;";
            SqlCommand cmd = new SqlCommand(strcmd, cn);

            cmd.Parameters.Add("@Start", SqlDbType.Int).Value = param.Start;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = param.Size;



            cn.Open();


            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));


        }

    }
    public IList<Model_Mailbox> model_getMailbox(Model_Mailbox param)
    {


        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            
            string strcmd = @";WITH Mailbox_cte AS (
                                SELECT c.*,cs.Title As CSIDTitle,sd.Isdone,sd.TotalSend,sd.TotalSent,sd.StatusID
                                FROM dbo.Mailbox c
                                INNER JOIN dbo.CampaignStatus cs ON cs.CSID = c.CSID
                                LEFT JOIN dbo.SendingJob sd ON sd.CID=c.CID AND sd.Ctype=2
	                            WHERE c.IsBin = 1  AND c.Status = 1 " + (CSID>0 ? "AND c.CSID = " + CSID : "") +")" +

                            @"SELECT 
                                db.*,
                                tCountOrders.CountOrders AS TotalRows
                            FROM Mailbox_cte db
                                CROSS JOIN (SELECT Count(*) AS CountOrders FROM Mailbox_cte) AS tCountOrders
                            ORDER BY CSID ASC ,CreatedDate DESC,CID
                            OFFSET @Start ROWS
                            FETCH NEXT @Size ROWS ONLY;";
            SqlCommand cmd = new SqlCommand(strcmd, cn);

            cmd.Parameters.Add("@Start", SqlDbType.Int).Value = param.Start;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = param.Size;



            cn.Open();


            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

            
        }

    }
    public Model_Mailbox model_Update(Model_Mailbox el)
    {
        //int ret = 0;
        string sg = string.Empty;
        if (el.SGarr != null)
             sg = (el.SGarr.Length > 0 ? string.Join(",", el.SGarr) : "");
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@" UPDATE Mailbox SET Title=@Title,Detail=@Detail,IsSchedule=@IsSchedule, DateTimePublish=@DateTimePublish,
                            Subject=@Subject, Unsub=@Unsub, FileMail=@FileMail,SG=@SG ,Mailaddress=@Mailaddress WHERE CID=@CID", cn);
           
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = el.Title;
            cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = el.Detail;
            cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = (string.IsNullOrEmpty(el.Subject) ? el.Title : el.Subject);
            cmd.Parameters.Add("@DateTimePublish", SqlDbType.SmallDateTime).Value = el.DateTimePublish;
            cmd.Parameters.Add("@IsSchedule", SqlDbType.Bit).Value = el.IsSchedule;
            cmd.Parameters.Add("@SG", SqlDbType.NVarChar).Value = sg;
            cmd.Parameters.Add("@FileMail", SqlDbType.NVarChar).Value = el.FileMail;
            cmd.Parameters.Add("@Mailaddress", SqlDbType.NVarChar).Value = el.Mailaddress;
            cmd.Parameters.Add("@Unsub", SqlDbType.Bit).Value = el.Unsub;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = el.CID;
            cn.Open();
            ExecuteNonQuery(cmd);
        }

        return el;
    }


    public Model_Mailbox model_getMailboxByID(Model_Mailbox param)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT c.* FROM Mailbox c WHERE CID=@CID", cn);

            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = param.CID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public bool model_updatestatus(int el, byte CSID )
    {
     
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();

            StringBuilder q = new StringBuilder();
            q.Append("UPDATE Mailbox SET CSID =@CSID WHERE CID =@CID");
            
           cmd.Connection = cn;
            cmd.CommandText = q.ToString();
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = el;
            cmd.Parameters.Add("@CSID", SqlDbType.TinyInt).Value = CSID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public Model_Mailbox model_InsertMailbox(Model_Mailbox el)
    {
        int ret = 0;
        string sg = string.Empty;
        if (el.SGarr != null)
            sg = (el.SGarr.Length > 0 ? string.Join(",", el.SGarr) : "");


        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Mailbox (EID,Title,CreatedDate,Detail,CreatedBy,IsSchedule,DateTimePublish,CSID,Subject,SG,Unsub,FileMail,Mailaddress)
                        VALUES(@EID,@Title,@CreatedDate,@Detail,@CreatedBy,@IsSchedule,@DateTimePublish,@CSID,@Subject,@SG,@Unsub,@FileMail,@Mailaddress) ; SET @CID = SCOPE_IDENTITY(); ", cn);
            cmd.Parameters.Add("@EID", SqlDbType.NVarChar).Value = el.EID;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = el.CreatedDate;
            
            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = el.CreatedBy;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = el.Title;
            cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = el.Detail;
            cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = (string.IsNullOrEmpty(el.Subject) ? el.Title : el.Subject);
            cmd.Parameters.Add("@DateTimePublish", SqlDbType.SmallDateTime).Value = el.DateTimePublish;
            cmd.Parameters.Add("@IsSchedule", SqlDbType.Bit).Value = el.IsSchedule;
            cmd.Parameters.Add("@CSID", SqlDbType.TinyInt).Value = el.CSID;
            cmd.Parameters.Add("@SG", SqlDbType.NVarChar).Value = sg;
            cmd.Parameters.Add("@FileMail", SqlDbType.NVarChar).Value = el.FileMail;
            cmd.Parameters.Add("@Mailaddress", SqlDbType.NVarChar).Value = el.Mailaddress;
            cmd.Parameters.Add("@Unsub", SqlDbType.Bit).Value = el.Unsub;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();


            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@CID"].Value;
              
            }

            el.SG = sg;
            el.CID = ret;
        }

        return el;
    }
}