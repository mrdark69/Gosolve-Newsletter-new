using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Threading.Tasks;

using SendGrid.SmtpApi;
using SendGrid;
using RestSharp;
using SendGrid.Helpers.Mail;
using RestSharp.Authenticators;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Web.Hosting;

/// <summary>
/// Summary description for MAilSender
/// </summary>
public class MailSenderFileAtt
{
    public string Path { get; set; }
    public string FileName { get; set; }
}

public class MailSenderOption
{
 
  
    public Model_Setting MailSetting { get; set; }
    public List<MailSenderFileAtt> Attachment { get; set; }
   // public IDictionary<string, string> idicAttachment { get; set; }
    public string Mailbody { get; set; }
    public string Bcc { get; set; }
    public string Subject { get; set; }
    public string mailTo { get; set; }
    public HttpContext context { get; set; }



}

public static class MAilSender
{
    //private static string _maildisplayBooking = "reservation@booking2hotel.com";


    //byte sendserverType , string maildisplay, string mailNamedisplay, string mailTo, string Subject, string Bcc, string Mailbody, IDictionary<string, string> idicAttachment = null
    public static bool SendMailEngine(MailSenderOption option)
    {
        bool ret = false;
        switch (option.MailSetting.ST)
        {
            case 1:
                ret = SendMailSMTP(option);
               
                break;
            case 2:
                ret = MailGunAPI(option);
                break;
        }

        return ret;
        
    }

    public static bool MailGunAPI(MailSenderOption option)
    {
        bool success = false;
        try
        {
            RestClient client = new RestClient();
            //client.BaseUrl = new Uri("https://api.mailgun.net/v3/sandboxad5faabf13b54f8688be12d563b365cf.mailgun.org");
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            //client.BaseUrl = new Uri("https://api.mailgun.net/v3/ns.gosolve.net");

            client.Authenticator =
                    new HttpBasicAuthenticator("api", option.MailSetting.APIKEY);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", option.MailSetting.Domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "" + option.MailSetting.MailName + " <" + option.MailSetting.MailAddress + ">");
            request.AddParameter("to", "" + option.mailTo + "");
            //request.AddParameter("cc", "baz@example.com");
            if (!string.IsNullOrEmpty(option.Bcc))
                request.AddParameter("bcc", "" + option.Bcc + "");
            request.AddParameter("subject", "" + option.Subject + "");
            //request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.AddParameter("html", "" + option.Mailbody + "");


            if (option.Attachment != null && option.Attachment.Count > 0)
            {
                foreach (MailSenderFileAtt attatch in option.Attachment)
                {
                    string serverpath = HostingEnvironment.MapPath(attatch.Path) + attatch.FileName;
                    request.AddFile("attachment", serverpath);
                    //HttpContext.Current.Server.MapPath(attatch.Path + "/" + attatch.FileName) 
                    //Path.Combine(serverpath, attatch.FileName)
                }
            }

            //string JsonCustom = "{\"MainSite\":\"2\", \"booking_id\": \"" + booking_id + "\", \"email_sento\": \"" + mailTo + "\", \"email_type_id\": \"" + bytEmailTypeId + "\", \"email_type_title\": \"" + strEmailTitle + "\"}";
            //request.AddParameter("v:my-custom-data", JsonCustom);


            //request.AddFile("attachment", Path.Combine("files", "test.jpg"));
            //request.AddFile("attachment", Path.Combine("files", "test.txt"));
            request.Method = Method.POST;


            IRestResponse ret = client.Execute(request);
            success = true;
        }
        catch(Exception ex)
        {
            string ee = ex.Message + ex.StackTrace;
        }
        
        return success;
    }


    public static bool SendMailSMTP(MailSenderOption option)
    {
        bool success = false;
        try
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(option.MailSetting.MailAddress, option.MailSetting.MailName);

            if (!string.IsNullOrEmpty(option.Bcc))
                mail.Bcc.Add(option.Bcc);
            mail.To.Add(option.mailTo);
            mail.Subject = option.Subject.Trim();
            mail.Body = option.Mailbody;
            mail.IsBodyHtml = true;

            //string strCustomVariable = "";
            //foreach (var item in dicCustomVariable)
            //{
            //    strCustomVariable += ",\"" + item.Key + "\":\"" + item.Value + "\"";
            //}
            //strCustomVariable = strCustomVariable.RemoveBeginOrEnd(",");
            //if (strCustomVariable != "") mail.Headers.Add("X-Mailgun-Variables", "{" + strCustomVariable + "}");



            //Extend function by darkman 20-08-2016
            if (option.Attachment != null && option.Attachment.Count > 0)
            {
                foreach (MailSenderFileAtt attatch in option.Attachment)
                {
                    string ss = HostingEnvironment.MapPath(attatch.Path  + attatch.FileName);
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ss);
                    mail.Attachments.Add(attachment);

                }
            }

           

            ///



            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = option.MailSetting.IsSSL;
            smtpClient.Port = option.MailSetting.Port;

            smtpClient.Host =option.MailSetting.MailServer.Trim();
            smtpClient.Credentials = new System.Net.NetworkCredential(option.MailSetting.MailServerUser.Trim(), option.MailSetting.MailServerPass.Trim());//"bluehousetravel","vug,]NFVgm]m^wmpc]ofN"


            smtpClient.Send(mail);

            success = true;
        }
        catch (Exception ex)
        {
            //(Exception ex)
        }

        return success;
    }



    

    /// <summary>
    /// Not use
    /// </summary>
    /// <param name="maildisplay"></param>
    /// <param name="mailNamedisplay"></param>
    /// <param name="mailTo"></param>
    /// <param name="Subject"></param>
    /// <param name="Bcc"></param>
    /// <param name="Mailbody"></param>
    /// <returns></returns>

    public static bool Sendmail(string maildisplay, string mailNamedisplay, string mailTo, string Subject, string Bcc, string Mailbody)
    {
        bool success = false;
        try
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(maildisplay, mailNamedisplay);
            if (mailTo.Split(';').Length > 0)
            {
                string[] arrMail = mailTo.Split(';');
                foreach (string mailitem in arrMail)
                {
                    if (!string.IsNullOrEmpty(mailitem))
                        mail.To.Add(mailitem);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(mailTo))
                    mail.To.Add(mailTo);
            }

            if (!string.IsNullOrEmpty(Bcc))
            {
                if (Bcc.Split(';').Length > 0)
                {
                    string[] arrMail = Bcc.Split(';');
                    foreach (string mailitem in arrMail)
                    {
                        if (!string.IsNullOrEmpty(mailitem))
                            mail.Bcc.Add(mailitem);
                        //mail.To.Add(mailitem);
                    }
                }

            }

            mail.Subject = Subject;
            mail.Body = Mailbody;
            mail.IsBodyHtml = true;



            SmtpClient smtpClient = new SmtpClient();

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Host = "smtp.sendgrid.net";
            //smtpClient.Credentials = new System.Net.NetworkCredential("bluehousetravel", "vug,]NFVgm]m^wmpc]ofN");

            //smtpClient.Host = "mail.hotels2thailand.com";
            //smtpClient.Credentials = new System.Net.NetworkCredential("peerapong@hotels2thailand.com", "F=8fuieji;pq");

            smtpClient.Host = "smtp.mailgun.org";
            smtpClient.Credentials = new System.Net.NetworkCredential("mailgun@booking2hotels.com", "Opt$4412TT");
            //smtpClient.Port = 465;
            //smtpClient.EnableSsl = true;

            smtpClient.Send(mail);
            success = true;
        }
        catch 
        {
            //HttpContext.Current.Response.Write(ex.Message + "--" + ex.StackTrace); Exception ex
            //HttpContext.Current.Response.End();
            //NLogFile objLog = new NLogFile(new System.Diagnostics.StackTrace().GetFrame(0));
            //objLog.WriteLog(EnumCodeLog.InternalServerError, EnumLevelLog.Error, "Sendmail", ex.StackTrace);
            success = false;
        }

        return success;
    }

    public static bool SendmailAttachment(string maildisplay, string mailNamedisplay, string mailTo, string Subject, string Bcc, string Mailbody, string strAttachment)
    {
        bool success = false;
        try
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(maildisplay, mailNamedisplay);
            if (mailTo.Split(';').Length > 0)
            {
                string[] arrMail = mailTo.Split(';');
                foreach (string mailitem in arrMail)
                {
                    mail.To.Add(mailitem);
                }
            }
            else
            {
                mail.To.Add(mailTo);
            }

            if (!string.IsNullOrEmpty(Bcc))
            {
                if (Bcc.Split(';').Length > 0)
                {
                    string[] arrMail = Bcc.Split(';');
                    foreach (string mailitem in arrMail)
                    {
                        mail.Bcc.Add(mailitem);
                        //mail.To.Add(mailitem);
                    }
                }

            }

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(strAttachment);
            mail.Attachments.Add(attachment);
            mail.Subject = Subject;
            mail.Body = Mailbody;
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = "smtp.mailgun.org";
            smtpClient.Credentials = new System.Net.NetworkCredential("mailgun@booking2hotels.com", "Opt$4412TT");

            smtpClient.Send(mail);
            success = true;
        }
        catch
        {
            //HttpContext.Current.Response.Write("Mail Error: " + ex.Message + "<br />" + ex.StackTrace + "<br />");
            //HttpContext.Current.Response.End();
            success = false;
        }

        return success;
    }
    public static bool SendmailNormail(string maildisplay, string mailNamedisplay, string mailTo, string Subject, string Bcc, string Mailbody)
    {
        return Sendmail(maildisplay, mailNamedisplay, mailTo, Subject, Bcc, Mailbody);
    }

    public static bool IsMatchEmail(string input)
    {
        bool IsMatch = false;
        bool condition = true;
        //string emailformat = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

        string emailformat =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
 + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
 + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
 + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
        //string emailformat = "/^[\\w\\-\\.\\+]+\\@[a-zA-Z0-9\\.\\-]+\\.[a-zA-z0-9]{2,4}$/";
        Regex regura = new Regex(emailformat);

        if (regura.IsMatch(input))
        {
            IsMatch = true;

            if (Regex.IsMatch(input, @"[^\u0000-\u007F]"))
            {
                IsMatch = true;

                int length = input.Length;
                char mychar = input[length - 1];


                while (condition == true)
                {
                    if (regura.IsMatch(input))
                    {
                        IsMatch = true;
                    }
                    else
                    {
                        IsMatch = false;
                        break;
                    }

                    if (Convert.ToString(mychar) == ".")
                    {
                        IsMatch = false;
                        break;
                    }
                    else
                    {
                        IsMatch = true;

                    }

                    ArrayList Arrystring = new ArrayList();
                    Arrystring.Add(";");
                    Arrystring.Add("/");
                    Arrystring.Add("\\");
                    Arrystring.Add(":");
                    Arrystring.Add("'");
                    Arrystring.Add("\"");
                    Arrystring.Add("*");
                    Arrystring.Add(",");

                    foreach (string mystr in Arrystring)
                    {
                        char chartofind = Convert.ToChar(mystr);
                        int count = 0;
                        char[] chars = input.ToCharArray();
                        foreach (char c in chars)
                        {
                            if (c == chartofind)
                            {
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            IsMatch = false;
                            break;
                        }
                        else
                        {
                            IsMatch = true;

                        }
                    }
                    condition = false;
                }
            }
        }

        return IsMatch;

    }

}