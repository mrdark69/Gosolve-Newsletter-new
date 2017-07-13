using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;

/// <summary>
/// Summary description for MediaTax
/// </summary>
public class MediaTax :BaseModel<MediaTax>
{

    public int TaxID { get; set; }
    public int MID { get; set; }

    public string Title { get; set; }

    public MediaTax()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int model_InsertTax(MediaTax param)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"IF NOT EXISTS 
        (   SELECT  1
            FROM    MediaTax 
            WHERE   TaxID = @TaxID 
            AND     MID = @MID
        )
        BEGIN
            INSERT INTO MediaTax (TaxID,MID) VALUES(@TaxID,@MID)
        END; ", cn);
            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = param.TaxID;
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = param.MID;

            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }


    public List<MediaTax> model_getTaxByMid(int MID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT mt.*,mty.Title FROM MediaTax mt
                INNER JOIN MediaTaxonomy mty ON mty.TaxID = mt.TaxID 
                WHERE mt.MID = @MID", cn);

            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = MID;

            cn.Open();
            return MappingObjectCollectionFromDataReader(ExecuteReader(cmd));
        }
    }


    public bool model_DeleteMediaTaxAllbyMID(int MID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM MediaTax WHERE MID = @MID", cn);

            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = MID;

            cn.Open();
            return (ExecuteNonQuery(cmd) == 1);
        }
    }

 }