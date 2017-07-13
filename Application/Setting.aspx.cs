using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            
            Model_Setting c = new Model_Setting();

            c = c.GetSetting();


            if (c != null)
            {
                ST.SelectedValue = c.ST.ToString();
                APIKEY.Text = c.APIKEY.ToString();
                Domain.Text = c.Domain;
                IsSSL.SelectedValue =  c.IsSSL.ToString();
                MailAddress.Text = c.MailAddress;
                MailName.Text = c.MailName;
                MailServer.Text = c.MailServer;
                MailServerPass.Text = c.MailServerPass;
                MailServerUser.Text = c.MailServerUser;
                Port.Text = c.Port.ToString();


                switch (c.ST.ToString())
                {
                    case "1":
                        option_1.Visible = false;
                        option_2.Visible = false;
                        option_3.Visible = true;
                        option_4.Visible = true;
                        option_5.Visible = true;

                        break;
                    case "2":
                        option_1.Visible = true;
                        option_2.Visible = true;
                        option_3.Visible = false;
                        option_4.Visible = false;
                        option_5.Visible = false;
                        break;

                }
            }
            
           
        }
    }

    protected void ST_SelectedIndexChanged(object sender, EventArgs e)
    {
        string v = ST.SelectedValue;
        switch (v)
        {
            case "1":
                option_1.Visible = false;
                option_2.Visible = false;
                option_3.Visible = true;
                option_4.Visible = true;
                option_5.Visible = true;
               
                break;
            case "2":
                option_1.Visible = true;
                option_2.Visible = true;
                option_3.Visible = false;
                option_4.Visible = false;
                option_5.Visible = false;
                break;

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Model_Setting c = new Model_Setting
        {
            ST = byte.Parse(ST.SelectedValue),
            APIKEY = APIKEY.Text,
            Domain = Domain.Text,
            IsSSL = bool.Parse(IsSSL.SelectedValue),
            MailAddress = MailAddress.Text,
            MailName = MailName.Text,
            MailServer = MailServer.Text,
            MailServerPass = MailServerPass.Text,
            MailServerUser = MailServerUser.Text,
            Port = int.Parse(Port.Text)


        };
        c.SettingData(c);
    }
}