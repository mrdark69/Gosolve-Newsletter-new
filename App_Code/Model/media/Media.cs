using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;

/// <summary>
/// Summary description for Media
/// </summary>
public class MediaModel: BaseModel<MediaModel>
{


    public int MID { get; set; }
    public string Title { get; set; }
    public string Alt { get; set; }
    public string Slug { get; set; }
    public string Path { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public string Extension { get; set; }
    public int Priority { get; set; }
    public bool Status { get; set; }
    public DateTime DateUpload { get; set; }
    public string FileSize { get; set; }
    public string Dimensions { get; set; }


    //public List<MediaTax> MediaTax { get; set; }
    private MediaTax[] _mediaTax;
    public MediaTax[] MediaTax
    {
        get
        {
            if(_mediaTax == null)
            {
                MediaTax m = new MediaTax();
                _mediaTax = m.model_getTaxByMid(this.MID).ToArray();
               
            }
            return  _mediaTax;
        }
        set
        {
            _mediaTax = value;
        }
    }

    public string FileSizeFormat
    {
        get
        {
            return Base64BinarySrtingToFile.SizeSuffix(long.Parse(this.FileSize));
        }
       
    }

    

    





    public MediaModel()
    {
        //
        // TODO: Add constructor logic here
        //

        this.DateUpload = DatetimeHelper._UTCNow();
    }


    public int model_INsertMedia(MediaModel cmedia)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Media (Title,Alt,Slug,Path,FileName,FileType,Extension,Priority,DateUpload,FileSize,Dimensions) 
                    VALUES (@Title,@Alt,@Slug,@Path,@FileName,@FileType,@Extension,@Priority,@DateUpload,@FileSize,@Dimensions); SET @MID = SCOPE_IDENTITY();", cn);
            cn.Open();
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = cmedia.Title;
            cmd.Parameters.Add("@Alt", SqlDbType.NVarChar).Value = cmedia.Alt;
            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = cmedia.Slug;
            cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = cmedia.Path;
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = cmedia.FileName;
            cmd.Parameters.Add("@FileType", SqlDbType.NVarChar).Value = cmedia.FileType;
            cmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = cmedia.Extension;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = cmedia.Priority;

            cmd.Parameters.Add("@DateUpload", SqlDbType.SmallDateTime).Value = cmedia.DateUpload;
            cmd.Parameters.Add("@FileSize", SqlDbType.NVarChar).Value = cmedia.FileSize;
            cmd.Parameters.Add("@Dimensions", SqlDbType.NVarChar).Value = cmedia.Dimensions;


            cmd.Parameters.Add("@MID", SqlDbType.Int).Direction = ParameterDirection.Output;



            if (ExecuteNonQuery(cmd) > 0)
                ret = (int)cmd.Parameters["@MID"].Value;
        }

        return ret;
    }


    public bool model_Update(MediaModel cmedia)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Media SET Title = @Title WHERE MID=@MID",cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = cmedia.Title;
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = cmedia.MID;
            cn.Open();
            return (ExecuteNonQuery(cmd) == 1);

        }
    }

    public IList<MediaModel> model_GetMediaAll(int Tax ,string Type)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT m.* FROM Media m ");
            if (Tax > 0)
            {
                query.Append(" INNER JOIN MediaTax mt ON mt.MID = m.MID");
                query.Append(" WHERE mt.TaxID = @TaxID");
                cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = Tax;
            }

    
           
                

            if (!string.IsNullOrEmpty(Type))
            {
                query.Append(  (Tax>0?"AND": "WHERE") + "  m.FileType  "+(Type == "other"? " NOT LIKE '%image%'" : " LIKE '%' + @FileType +'%'"));
                cmd.Parameters.Add("@FileType", SqlDbType.NVarChar).Value = Type;
            }

            cmd.CommandText = query.ToString();
            cmd.Connection = cn;


            cn.Open();

            return MappingObjectCollectionFromDataReader(ExecuteReader(cmd));
        }

    }

    public bool model_DeleteMedia(MediaModel param)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Media WHERE MID= @MID; DELETE FROM MediaTax WHERE MID= @MID", cn);
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = param.MID;
            cn.Open();
            return (ExecuteNonQuery(cmd) == 1);
        }
    }
}