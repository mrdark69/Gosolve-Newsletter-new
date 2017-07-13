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
/// Summary description for Model_Template
/// </summary>
public class Model_Template : BaseModel<Model_Template>
{


    public int TID { get; set; }
    public string EID { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedDate { get; set; } = DatetimeHelper._UTCNow();
    public string CreateBy { get; set; } = HttpContext.Current.User.Identity.GetUserId();
    public string Title { get; set; } =string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Status { get; set; }
    public bool Bin { get; set; }
    public string DemoPath { get; set; }
    public string DemoFileName { get; set; }


    private EModel _el;

    public EModel EL
    {
        get {
            if (_el == null)
            {
                EmailEelements e = new EmailEelements();
             
                _el = (EModel)e.model_GetElementBYID(this.EID).Eelement.JsonToObject(new EModel() );
            }
            return _el;
        }
        set { _el = value; }
    }

  

    public DateTime CreateDateLocal
    {
        get { return this.CreatedDate.ToZone(); }
       
    }

    public bool IsNew
    {
        get { return (new DateTime().Subtract(this.CreatedDate.ToZone()).Days > 3 ? false : true); }
    }


    public string Author
    {
        get
        {
            UserManager manager = new UserManager();
            var user = manager.FindById(this.CreateBy);
            return user.FirstName;
        }
    }

    //public EModel EL { get; set; }


    public Model_Template()
    {
        //
        // TODO: Add constructor logic here
        //
        //this.CreateBy = HttpContext.Current.User.Identity.GetUserId();
        //this.EID = Guid.NewGuid().ToString();
        //this.CreatedDate = DatetimeHelper._UTCNow();
    }

    public  List<Model_Template> model_GetElementList()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Template WHERE Bin =1 AND Status =1", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReader(ExecuteReader(cmd));
           
        }
    }

    public bool model_DeleteTemplate(Model_Template param)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Template WHERE TID=@TID", cn);

            cmd.Parameters.Add("@TID", SqlDbType.Int).Value = param.TID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }


    public Model_Template model_GetElementBYID(int TID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Template WHERE TID=@TID", cn);
            cmd.Parameters.Add("@TID", SqlDbType.Int).Value = TID;


            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReader(reader);
            else
                return null;


        }
    }

    public Model_Template model_InsertEmailEelement(Model_Template el)
    {
        int ret = 0;
        DateTime d = DatetimeHelper._UTCNow();
        string filename = d.ToString("ddmmyyyyhhmmss") + ".jpg";
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Template (EID,CreatedDate,CreateBy,Title,Description,DemoPath,DemoFileName)
                        VALUES(@EID,@CreatedDate,@CreateBy,@Title,@Description,@DemoPath,@DemoFileName) ; SET @TID = SCOPE_IDENTITY(); ", cn);
            cmd.Parameters.Add("@EID", SqlDbType.NVarChar).Value = el.EID;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = el.CreatedDate;
            cmd.Parameters.Add("@CreateBy", SqlDbType.NVarChar).Value = el.CreateBy;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = el.Title;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = el.Description;
            cmd.Parameters.Add("@DemoPath", SqlDbType.NVarChar).Value = AppTools.TemplateMockPath();
            cmd.Parameters.Add("@DemoFileName", SqlDbType.NVarChar).Value = filename;
            cmd.Parameters.Add("@TID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();


            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@TID"].Value;
               // string fullpath = AppTools.TemplateMockPath() + "test.png";
                HtmlToImage.ConvertHtmlToImage(AppTools.TemplateMockPath(), filename, el.EL.html);
            }

            el.DemoPath = AppTools.TemplateMockPath();
            el.DemoFileName = filename;
            el.TID = ret;
        }

        return el;
    }

    

    public Model_Template model_UpdateEmailElement(Model_Template el)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Template SET Title = @Title WHERE  TID=@TID", cn);
            cmd.Parameters.Add("@TID", SqlDbType.Int).Value = el.TID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = el.Title;
            cn.Open();

            if( ExecuteNonQuery(cmd) > 0)
            {
                HtmlToImage.ConvertHtmlToImage(el.DemoPath, el.DemoFileName, el.EL.html);
            }

            
        }

        return el;
    }

    public bool model_RemoveElement(Model_Template el)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM EmailElement WHERE  TID=@TID", cn);
            cmd.Parameters.Add("@TID", SqlDbType.Int).Value = el.TID;

            cn.Open();

            return ExecuteNonQuery(cmd) == 1;

        }
    }
}