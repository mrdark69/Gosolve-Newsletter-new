using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;

/// <summary>
/// Summary description for EmailEelements
/// </summary>
public class EmailEelements : BaseModel<EmailEelements>
{

    public string EID { get; set; }
    public string Eelement { get; set; }
    public EmailEelements()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int model_InsertEmailEelement(EmailEelements el)
    {
        int ret = 0;
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {


            SqlCommand cupdate = new SqlCommand("UPDATE EmailElement SET Element=@Element WHERE EID=@EID", cn);
            cupdate.Parameters.Add("@EID", SqlDbType.NVarChar).Value = el.EID;
            cupdate.Parameters.Add("@Element", SqlDbType.NVarChar).Value = el.Eelement.RegMiniJson();
            cn.Open();
            //.RegMiniJson();
            ret = ExecuteNonQuery(cupdate);
            if (ret == 0)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO EmailElement (EID,Element) VALUES(@EID,@Element) ", cn);
                cmd.Parameters.Add("@EID", SqlDbType.NVarChar).Value = el.EID;
                cmd.Parameters.Add("@Element", SqlDbType.NVarChar).Value = el.Eelement.RegMiniJson();
                ret =  ExecuteNonQuery(cmd);
                //.RegMiniJson();
            }


            return ret;

        }
    }

    public EmailEelements model_GetElementBYID(string Eid)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM EmailElement WHERE EID=@EID", cn);
            cmd.Parameters.Add("@EID", SqlDbType.NVarChar).Value = Eid;


            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReader(reader);
            else
                return null;
           

        }
    }

    public bool model_UpdateEmailElement(EmailEelements el)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE EmailElement SET Element = @Element WHERE  EID=@EID", cn);
            cmd.Parameters.Add("@EID", SqlDbType.NVarChar).Value = el.EID;
            cmd.Parameters.Add("@Element", SqlDbType.NVarChar).Value = el.Eelement;
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;

        }
    }

    public bool model_RemoveElement(string EID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM EmailElement WHERE  EID=@EID", cn);
            cmd.Parameters.Add("@EID", SqlDbType.NVarChar).Value = EID;
         
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;

        }
    }


}