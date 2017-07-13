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
/// Summary description for SendingJob
/// </summary>
public class Model_SendingJob:BaseModel<Model_SendingJob>
{

    public int SDID { get; set; }
    public byte CType { get; set; }
    public int CID { get; set; }
    public bool Isdone { get; set; }
    public int TotalSend { get; set; }
    public byte StatusID { get; set; }
    public int TotalSent { get; set; }



    public Model_SendingJob()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public Model_SendingJob AddJob(Model_SendingJob e)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO SendingJob (CType,CID,Isdone,TotalSend,StatusID) 
            VALUES(@CType,@CID,@Isdone,@TotalSend,@StatusID);SET @SDID = SCOPE_IDENTITY()", cn);

            cmd.Parameters.Add("@CType", SqlDbType.TinyInt).Value = e.CType;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = e.CID;
            cmd.Parameters.Add("@Isdone", SqlDbType.Bit).Value = e.Isdone;
            cmd.Parameters.Add("@TotalSend", SqlDbType.Int).Value = e.TotalSend;
            cmd.Parameters.Add("@StatusID", SqlDbType.TinyInt).Value = e.StatusID;
            cmd.Parameters.Add("@SDID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                e.SDID = (int)cmd.Parameters["@SDID"].Value;
                
            }

            return e;
        }
    }

    public void UpdateJobStatus(int JobID, byte bytStatusID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE SendingJob SET StatusID =@StatusID WHERE SDID=@SDID", cn);

            cmd.Parameters.Add("@SDID", SqlDbType.Int).Value = JobID;
            cmd.Parameters.Add("@StatusID", SqlDbType.TinyInt).Value = bytStatusID;
            cn.Open();
            ExecuteNonQuery(cmd);
        }
    }


    public void UpdateStatusMailProcess()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE Mailbox SET CSID = 4 WHERE CSID=3 AND CID IN (SELECT CID FROM SendingJob WHERE CType =2 AND Isdone = 1 AND TotalSent >= TotalSend  );
UPDATE Campaign SET CSID = 4 WHERE  CSID=3 AND CID IN (SELECT CID FROM SendingJob WHERE CType =1 AND Isdone = 1 AND TotalSent >= TotalSend  )", cn);

            cn.Open();
            ExecuteNonQuery(cmd);
        }
    }



    public void UpdateTotalSentAndISDone(int SDID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE SendingJob SET TotalSent = (SELECT COUNT(*) FROM SendingJobItem WHERE SDID=@SDID AND IsSent=1 ) WHERE SDID=@SDID;
                        UPDATE SendingJob SET Isdone = 1 ,StatusID = 3 WHERE TotalSent >= TotalSend", cn);

            cmd.Parameters.Add("@SDID", SqlDbType.Int).Value = SDID;
            
            //cmd.Parameters.Add("@TotalSent", SqlDbType.Int).Value = count;
            cn.Open();
            ExecuteNonQuery(cmd);
        }
    }


    public IList<Model_SendingJob> GetSendingJob()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM SendingJob WHERE Isdone=0 AND StatusID=1", cn);

            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
}

//INSERT INTO SendingJobStatus(StatusID, Title) VALUES(1,'Sending')
//INSERT INTO SendingJobStatus(StatusID, Title) VALUES(2,'Paused')
//INSERT INTO SendingJobStatus(StatusID, Title) VALUES(3,'Done')
//INSERT INTO SendingJobStatus(StatusID, Title) VALUES(4,'Error') 
//INSERT INTO SendingJobStatus (StatusID,Title) VALUES(5,'Waiting') 