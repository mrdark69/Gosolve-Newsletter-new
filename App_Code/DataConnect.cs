using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Web.Caching;


/// <summary>
/// Summary description for DataConnect
/// </summary>
public class DataConnect
{
    public DataConnect()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    //====== DARKMAN VERSION ===

    
    private string _connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected string ConnectionString
    {
        get { return _connectionString; }
    }



    protected DataTable dtDatatable(SqlCommand cmd)
    {
        using (SqlConnection conn = new SqlConnection(this.ConnectionString))
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            conn.Open();
            cmd.Connection = conn;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
    }

    protected DataSet dsDataset(SqlCommand cmd)
    {
        using (SqlConnection conn = new SqlConnection(this.ConnectionString))
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            conn.Open();
            cmd.Connection = conn;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }
    }

    protected int ExecuteNonQuery(DbCommand cmd)
    {
        return cmd.ExecuteNonQuery();
    }

    protected IDataReader ExecuteReader(DbCommand cmd)
    {
        return ExecuteReader(cmd, CommandBehavior.Default);
    }

    protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
    {
        return cmd.ExecuteReader(behavior);
    }

    protected object ExecuteScalar(DbCommand cmd)
    {
        return cmd.ExecuteScalar();
    }

}