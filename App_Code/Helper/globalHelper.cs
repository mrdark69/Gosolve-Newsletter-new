using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for globalHelper
/// </summary>
/// 
namespace Interface_API
{
    public class globalHelper
    {

        public globalHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string sha256HexSignature(string apiKey, string sharedSecret)
        {

            string signature;
            using (var sha = SHA256.Create())
            {
                long ts = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
                //Console.WriteLine("Timestamp: " + ts);
                var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(apiKey + sharedSecret + ts));
                signature = BitConverter.ToString(computedHash).Replace("-", "");
            }


            return signature;
           

        }


        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }




    }
}
