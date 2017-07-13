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
/// Summary description for SendingJobItem
/// </summary>
public class Model_SendingJobItem:BaseModel<Model_SendingJobItem>
{

    public int SDIID { get; set; }
    public int SDID { get; set; }
    public string Email { get; set; }
    public int Que { get; set; }
    public bool Status { get; set; }
    public bool IsSent { get; set; }
    public int SID { get; set; } = 0;

    public bool Lock { get; set; }

    public byte CType { get; set; }
    public int CID { get; set; }
    public int TotalSend { get; set; }



    public Model_SendingJobItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool AddJobItem(Model_SendingJobItem e)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO SendingJobItem (SDID,Email,Que,Status,IsSent,SID) 
            VALUES(@SDID,@Email,@Que,@Status,@IsSent,@SID)", cn);

            //cmd.Parameters.Add("@SDIID", SqlDbType.Int).Value = e.SDIID;
            cmd.Parameters.Add("@SDID", SqlDbType.Int).Value = e.SDID;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = e.Email;
            cmd.Parameters.Add("@Que", SqlDbType.Int).Value = e.Que;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = e.Status;
            cmd.Parameters.Add("@IsSent", SqlDbType.Bit).Value = e.IsSent;
            cmd.Parameters.Add("@SID", SqlDbType.Int).Value = e.SID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
           
        }
    }

    public IList<Model_SendingJobItem> GetSendingJob()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            //SqlCommand cmdlock = new SqlCommand(@"UPDATE SendingJobItem SET Lock = 1 WHERE SDIID IN (
            //    SELECT si.SDIID FROM SendingJobItem si
            //    WHERE si.Status=1 AND si.IsSent=0 AND si.Lock = 0
            //)", cn);

            cn.Open();
            //ExecuteNonQuery(cmdlock);
          
            SqlCommand cmd = new SqlCommand(@"SELECT si.*,sj.CType,sj.CID,sj.TotalSend FROM SendingJobItem  si
                        INNER JOIN SendingJob sj ON si.SDID = sj.SDID
                        WHERE si.Status=1 AND si.IsSent=0  ORDER BY Que ASC", cn);

            //cmd.Parameters.Add("@SDIID", SqlDbType.Int).Value = e.SDIID;
           
            //cmd.Parameters.Add("@SDID", SqlDbType.Int).Value = e.SID;
            
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public IList<Model_SendingJobItem> GetSendingJob(int SDID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            //SqlCommand cmdlock = new SqlCommand(@"UPDATE SendingJobItem SET Lock = 1 WHERE SDIID IN (
            //    SELECT si.SDIID FROM SendingJobItem si
            //    WHERE si.Status=1 AND si.IsSent=0 AND si.Lock = 0 AND si.SDID =@SDID
            //)", cn);

            //cmdlock.Parameters.Add("@SDID", SqlDbType.Int).Value = SDID;
            cn.Open();
           // ExecuteNonQuery(cmdlock);

            SqlCommand cmd = new SqlCommand(@"SELECT si.*,sj.CType,sj.CID,sj.TotalSend FROM SendingJobItem  si
                        INNER JOIN SendingJob sj ON si.SDID = sj.SDID
                        WHERE si.Status=1 AND si.IsSent=0 AND si.SDID =@SDID ORDER BY Que ASC", cn);

            //cmd.Parameters.Add("@SDIID", SqlDbType.Int).Value = e.SDIID;

            cmd.Parameters.Add("@SDID", SqlDbType.Int).Value = SDID;

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }


    public bool UpdateStatus(int SDIID, bool IsSent)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE SendingJobItem SET IsSent=@IsSent WHERE SDIID=@SDIID", cn);
            cmd.Parameters.Add("@IsSent", SqlDbType.Bit).Value = IsSent;
            cmd.Parameters.Add("@SDIID", SqlDbType.Int).Value = SDIID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;

        }
    }
}

