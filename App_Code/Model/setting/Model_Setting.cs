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
/// Summary description for Model_Setting
/// </summary>
public class Model_Setting: BaseModel<Model_Setting>
{

    public byte ST { get; set; }
    public string APIKEY { get; set; }
    public string Domain { get; set; }
    public string MailName { get; set; }
    public string MailAddress { get; set; }
    public string MailServer { get; set; }
    public string MailServerUser { get; set; }
    public string MailServerPass { get; set; }
    public int Port { get; set; }
    public bool IsSSL { get; set; }


    public Model_Setting()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    

    public Model_Setting GetSetting()
    {
        //BaseModel<Model_Setting>.PurgeCacheItems("mail_setting");
        Model_Setting r = null;
        string key = "mail_setting";

        if(BaseModel<Model_Setting>.Cache[key] != null)
        {
            r = (Model_Setting)BaseModel<Model_Setting>.Cache[key];
        }
        else
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Setting", cn);
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                  r=   MappingObjectFromDataReaderByName(reader);
                
            }
            BaseModel<Model_Setting>.CacheData(key, r);
        }



        return r;
    }

    public void SettingData(Model_Setting e)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE Setting SET ST=@ST,APIKEY=@APIKEY,Domain=@Domain,MailName=@MailName,
MailAddress=@MailAddress,MailServer=@MailServer,MailServerUser=@MailServerUser,MailServerPass=@MailServerPass,Port=@Port,IsSSL=@IsSSL", cn);
            cmd.Parameters.Add("@ST", SqlDbType.TinyInt).Value = e.ST;
            cmd.Parameters.Add("@APIKEY", SqlDbType.VarChar).Value = e.APIKEY;
            cmd.Parameters.Add("@Domain", SqlDbType.VarChar).Value = e.Domain;
            cmd.Parameters.Add("@MailName", SqlDbType.VarChar).Value = e.MailName;
            cmd.Parameters.Add("@MailAddress", SqlDbType.VarChar).Value = e.MailAddress;
            cmd.Parameters.Add("@MailServer", SqlDbType.VarChar).Value = e.MailServer;
            cmd.Parameters.Add("@MailServerUser", SqlDbType.VarChar).Value = e.MailServerUser;
            cmd.Parameters.Add("@MailServerPass", SqlDbType.VarChar).Value = e.MailServerPass;
            cmd.Parameters.Add("@Port", SqlDbType.Int).Value = e.Port;
            cmd.Parameters.Add("@IsSSL", SqlDbType.Bit).Value = e.IsSSL;

            cn.Open();
            if(ExecuteNonQuery(cmd) == 0)
            {

                SqlCommand cmdi = new SqlCommand(@"INSERT INTO Setting  (ST,APIKEY,Domain,MailName,MailAddress,MailServer,MailServerUser,MailServerPass,Port,IsSSL) 
VALUES(@ST,@APIKEY,@Domain,@MailName,@MailAddress,@MailServer,@MailServerUser,@MailServerPass,@Port,@IsSSL)", cn);

                cmdi.Parameters.Add("@ST", SqlDbType.TinyInt).Value = e.ST;
                cmdi.Parameters.Add("@APIKEY", SqlDbType.VarChar).Value = e.APIKEY;
                cmdi.Parameters.Add("@Domain", SqlDbType.VarChar).Value = e.Domain;
                cmdi.Parameters.Add("@MailName", SqlDbType.VarChar).Value = e.MailName;
                cmdi.Parameters.Add("@MailAddress", SqlDbType.VarChar).Value = e.MailAddress;
                cmdi.Parameters.Add("@MailServer", SqlDbType.VarChar).Value = e.MailServer;
                cmdi.Parameters.Add("@MailServerUser", SqlDbType.VarChar).Value = e.MailServerUser;
                cmdi.Parameters.Add("@MailServerPass", SqlDbType.VarChar).Value = e.MailServerPass;
                cmdi.Parameters.Add("@Port", SqlDbType.Int).Value = e.Port;
                cmdi.Parameters.Add("@IsSSL", SqlDbType.Bit).Value = e.IsSSL;

                ExecuteNonQuery(cmdi);

            }
        }

        PurgeCacheItems("mail_setting");
    }
    


}