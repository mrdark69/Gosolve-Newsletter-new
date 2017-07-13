using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;
using Microsoft.AspNet.Identity;
using System.Security.Principal;


/// <summary>
/// Summary description for Model_Subscriber
/// </summary>
public class Model_SubscriberImportTemp : BaseModel<Model_SubscriberImportTemp>
{

    public string UserID { get; set; }
    public string Path { get; set; }
    public string FileName { get; set; }
    public int TotalRecord { get; set; }

    public Model_SubscriberImportTemp()
    {
        //
        // TODO: Add constructor logic here
        //
        this.UserID = HttpContext.Current.User.Identity.GetUserId();
    }



    public int InsertDataImport(Model_SubscriberImportTemp obj)
    {
        int ret = 0;
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE SubscriberImportTemp SET Path=@Path,FileName=@FileName,TotalRecord=@TotalRecord WHERE UserID=@UserID", cn);
            cmd.Parameters.Add("@Path", SqlDbType.NVarChar).Value = obj.Path;
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = obj.FileName;
            cmd.Parameters.Add("@TotalRecord", SqlDbType.NVarChar).Value = obj.TotalRecord;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = obj.UserID;
            cn.Open();

            if (ExecuteNonQuery(cmd) == 0)
            {
                SqlCommand cmdinsert = new SqlCommand(@"INSERT INTO SubscriberImportTemp 
                (Path,FileName,TotalRecord,UserID)
                VALUES(@Path,@FileName,@TotalRecord,@UserID)", cn);

                cmdinsert.Parameters.Add("@Path", SqlDbType.NVarChar).Value = obj.Path;
                cmdinsert.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = obj.FileName;
                cmdinsert.Parameters.Add("@TotalRecord", SqlDbType.NVarChar).Value = obj.TotalRecord;
                cmdinsert.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = obj.UserID;

                ret = ExecuteNonQuery(cmdinsert);
            }
            else
                ret = 1;
        }

        return ret;
    }
    public Model_SubscriberImportTemp GetImportTemp()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM SubscriberImportTemp WHERE UserID=@UserID", cn);
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = this.UserID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReader(reader);
            else
                return null;

        }
    }



}