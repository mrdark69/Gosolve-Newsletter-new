using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EASendMail;

using System.Net.Http;

public class APIResult
{
    public int status { get; set; }
    public String info { get; set; }
    public String details { get; set; }
}
public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {


        //const String APIURL = "https://api.email-validator.net/api/verify";
        //HttpClient client = new HttpClient();
        //String Email = txtemail.Text.Trim();
        //String APIKey = "ev-29d4b62536481db3907f7b39bdae7d5f";

        //var postData = new List<KeyValuePair<string, string>>();
        //postData.Add(new KeyValuePair<string, string>("EmailAddress", Email));
        //postData.Add(new KeyValuePair<string, string>("APIKey", APIKey));

        //HttpContent content = new FormUrlEncodedContent(postData);

        //HttpResponseMessage result = client.PostAsync(APIURL, content).Result;
        //string resultContent = result.Content.ReadAsStringAsync().Result;

        //APIResult res = new System.Web.Script.Serialization.JavaScriptSerializer().
        //                    Deserialize<APIResult>(resultContent);
        //string ret = string.Empty;
        //switch (res.status)
        //{
        //    // valid addresses have a {200, 207, 215} result code
        //    // result codes 114 and 118 need a retry
        //    case 200:
        //    case 207:
        //    case 215:
        //        ret = "address is valid";
        //        break;
        //    case 114:
        //        ret = "greylisting, wait 5min and retry";
        //        break;
        //    case 118:
        //        ret = "api rate limit, wait 5min and retry";
        //        break;
        //    default:
        //        ret = "address is invalid" + res.info + res.details;
        //        // res.info
        //        // res.details
        //        break;
        //}

        //lblret.Text = ret;

        Codicode.EmailValidator Ev = new Codicode.EmailValidator();
        //We create our Mail Validator Object
        //Codicode.Emailvalidator Ev = new Codicode.Emailvalidator();
        //  Sender email (for smtp identification)
        Ev.Mail_From = "info@gosolve.net";

        //  Sender email (for smtp identification)
        //bool Valid_Email = Ev.Check_MailBox(txtemail.Text.Trim());


        string err = Ev.Check_MailBox_Error(txtemail.Text);
        string ret = "";
        if (err == "")
        {
            ret = "mail ok";
        }
        else
        {
            ret = err;
        }
        //lblret.Text = Valid_Email.ToString() + Ev.Check_MailBox_Error(txtemail.Text);
        lblret.Text = ret;
        Ev.Dispose();



        //string ret = string.Empty;

        //SmtpMail oMail = new SmtpMail("ss");
        //SmtpClient oSmtp = new SmtpClient();

        //// Set sender email address, please change it to yours
        //oMail.From = "mrdark6996@gmail.com";

        //// Set recipient email address, please change it to yours
        //oMail.To = txtemail.Text.Trim();

        //// Do not set SMTP server address
        //SmtpServer oServer = new SmtpServer("");

        //try
        //{
        //   // Console.WriteLine("start to test email address ...");
        //    oSmtp.TestRecipients(oServer, oMail);
        //   // Console.WriteLine("email address was verified!");
        //    ret = "email address was verified!";
        //}
        //catch (Exception ep)
        //{
        //    //Console.WriteLine("failed to test email with the following error:");
        //    //Console.WriteLine(ep.Message);
        //    ret = "failed to test email with the following error:" + ep.Message;
        //}
    }

    protected void btnMX_Click(object sender, EventArgs e)
    {
        //  We create our Mail Validator Object
        Codicode.EmailValidator Ev = new Codicode.EmailValidator();
        //  Sender email (for smtp identification)
        string[] Mx_Records = Ev.FindMXRecords(txtemail.Text.Trim());
        lblret.Text = String.Join(",", Mx_Records);
    }
}