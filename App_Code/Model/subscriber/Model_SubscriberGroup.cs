using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;

/// <summary>
/// Summary description for Model_SubscriberGroup
/// </summary>
public class Model_SubscriberGroup: BaseModel<Model_SubscriberGroup>
{

    public int SGID { get; set; }
    public string SGName { get; set; }
    public string SGDetail { get; set; }
    public bool Sstatus { get; set; }
    public bool Sbin { get; set; }
    public int TotelRows { get; set; }
    public int RowNum { get; set; }

    public Model_SubscriberGroup()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Model_SubscriberGroup getSubscriberGroupById(byte bytID)
    {
        return null;
    }

    public int model_InsertSubscriberGroup(Model_SubscriberGroup obj)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO SubscriberGroup 
            (SGName,SGDetail) VALUES
            (@SGName,@SGDetail) 
           ; SET @SGID = SCOPE_IDENTITY();", cn);
            cmd.Parameters.Add("@SGName", SqlDbType.NVarChar).Value = obj.SGName;
            cmd.Parameters.Add("@SGDetail", SqlDbType.NVarChar).Value = obj.SGDetail;
            cmd.Parameters.Add("@SGID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();

            int ret = 0;
            if (ExecuteNonQuery(cmd) > 0)
                ret = (int)cmd.Parameters["@SGID"].Value;

            return ret;
        }
    }

    public bool modeol_UpdateSubcriberGroup(List<Model_SubscriberGroup> obj)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            
            foreach(Model_SubscriberGroup i in obj)
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE SubscriberGroup SET SGName=@SGName, SGDetail=@SGDetail WHERE SGID=@SGID", cn);
                cmd.Parameters.Add("@SGName", SqlDbType.NVarChar).Value = i.SGName;
                cmd.Parameters.Add("@SGDetail", SqlDbType.NVarChar).Value = i.SGDetail;
                cmd.Parameters.Add("@SGID", SqlDbType.Int).Value = i.SGID;
                ret = ExecuteNonQuery(cmd);
            }
        }
        return (ret == 1);
    }

    public int model_DeleteSubscriberGroup(List<Model_SubscriberGroup> obj)
    {
        StringBuilder pr = new StringBuilder();

       // string.Join(",", obj.Select(p => p.SGID).ToArray());
       
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            int i = 0;
            foreach (Model_SubscriberGroup m in obj)
            {
                if(i < (obj.Count()- 1))
                    pr.Append("@SGID" + i + ",");
                else
                    pr.Append("@SGID" + i );

                cmd.Parameters.AddWithValue("@SGID" + i.ToString(), m.SGID);
                i++;
            }
            string query = @"UPDATE SubscriberGroup SET Sbin = 0 WHERE SGID IN ("+ pr.ToString() + ")";

            cmd.CommandText = query;
            cmd.Connection = cn;



            cn.Open();
            return ExecuteNonQuery(cmd);
        }
          

      
       
    }

    public IList<Model_SubscriberGroup> getSubscriberAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM SubscriberGroup WHERE Sbin =1 AND Sstatus =1", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReader(ExecuteReader(cmd));
        }
    }

    public object getSubscriberGroupAll_DataTable(DTParameters param)
    {

        string search = param.Search.Value;
        string sortOrder = param.SortOrder;
        int start = param.Start;
        int length = param.Length;
        List<string> columnFilters = DataTablesJS<Model_SubscriberGroup>.getcolumnSearch(param);

        

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {


            string[] filerName = {"","", "SGName", "SGDetail" };
            StringBuilder strfilter = new StringBuilder();

           

            for (int i = 0; i < columnFilters.Count; i++)
            {
                if (!string.IsNullOrEmpty(columnFilters[i]))
                {
                    strfilter.Append(" AND LOWER("+ filerName[i]+ ") LIKE @filer_" + i);
                   
                }
               
            }

            string strcmd = @"
                ;WITH SubscriberGroup_cte AS (
                SELECT *
                FROM dbo.SubscriberGroup
	            WHERE Sbin = 1 " +
                (string.IsNullOrEmpty(search) ? "" : "AND  (LOWER(SGName) LIKE @search  OR SGDetail LIKE @search) ") +
                (columnFilters.Count > 0 ? strfilter.ToString() : "")
                + @"
            )

            SELECT 
                db.*,
                tCountOrders.CountOrders AS TotalRows
            FROM SubscriberGroup_cte db
                CROSS JOIN (SELECT Count(*) AS CountOrders FROM SubscriberGroup_cte) AS tCountOrders
            ORDER BY " + sortOrder + @"
            OFFSET @Start ROWS
            FETCH NEXT @Size ROWS ONLY;
            ";
            SqlCommand cmd = new SqlCommand(strcmd, cn);

            cmd.Parameters.Add("@Start", SqlDbType.Int).Value = start;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = length;

            if (!string.IsNullOrEmpty(search))
            {
                string searchTerm = string.Format("%{0}%", search);
                cmd.Parameters.Add(new SqlParameter("@search", searchTerm));
                //cmd.Parameters.Add("@search", SqlDbType.NVarChar).Value = searchTerm;
            }

            if(columnFilters.Count > 0)
            {
                if (!string.IsNullOrEmpty(columnFilters[2]))
                {
                    string searchTerm = string.Format("%{0}%", columnFilters[2]);
                    cmd.Parameters.Add(new SqlParameter("@filer_2", searchTerm));
                }
                if (!string.IsNullOrEmpty(columnFilters[3]))
                {
                    string searchTerm = string.Format("%{0}%", columnFilters[3]);
                    cmd.Parameters.Add(new SqlParameter("@filer_3", searchTerm));
                }


            }
            cn.Open();


            IDataReader reader = ExecuteReader(cmd);

            IList<Model_SubscriberGroup> result = MappingObjectCollectionFromDataReader(reader);

            int countTotal = (result.Count()> 0? result[0].TotelRows : 0);

            return DataTablesJS<Model_SubscriberGroup>.ResponeDataTable(param, result, countTotal);
        }

    }
}