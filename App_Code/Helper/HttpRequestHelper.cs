using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Security.Cryptography;

/// <summary>
/// Summary description for HttpRequestHelper
/// </summary>
/// 
namespace Interface_API
{
    public class HttpRequestHelper
    {
        public HttpRequestHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        
        public static string PostData(string Url, string postData = "", string method = "POST", string contenttype = "application/x-www-form-urlencoded", IDictionary<string, string> Header = null)
        {
            string responseData = string.Empty;


            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.Method = method;
            webRequest.ContentType = contenttype;
            webRequest.Accept = "application/json";
            if (Header != null)
            {
                foreach (KeyValuePair<string, string> headers in Header)
                {
                    webRequest.Headers.Add(headers.Key, headers.Value);
                }
            }
            webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            if (method == "POST" && !string.IsNullOrEmpty(postData))
            {
                webRequest.ContentLength = postData.Length;
                // POST the data
                using (StreamWriter requestWriter2 = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter2.Write(postData);
                }
            }



            try
            {
                using (HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse())
                {
                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                        {
                            // dumps the HTML from the response into a string variable
                            responseData = responseReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        responseData = text;
                    }
                }
            }

            

            //  Now, find the index of some word on the page that would be 
            //     displayed if the login was successful
            int index = responseData.IndexOf("Measuring");


            return responseData;
        }

        

        public static string GETdata(string urls ,string method, string contentType,IDictionary<string,string> Header = null)
        {

            // create the POST request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urls);
            webRequest.Method = method;
            //webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentType = contentType;

            //HttpRequestHeader.
            if(Header != null)
            {
                foreach(KeyValuePair<string,string> headers in Header)
                {
                    webRequest.Headers.Add(headers.Key, headers.Value);
                }
            }
            

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();

            string responseData = string.Empty;


            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                // dumps the HTML from the response into a string variable
                responseData = responseReader.ReadToEnd();
            }

            //  Now, find the index of some word on the page that would be 
            //     displayed if the login was successful
            int index = responseData.IndexOf("Measuring");

            //if (index > -1)
            //    ListBox1.Items.Add("SUCCESS");

            return responseData;


        }


        private string postXMLData(string destinationUrl, string requestXml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }

        public string Postman(string url, string Jsondata)
        {
            var baseAddress = url;

            var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            // << PUT HERE YOUR JSON PARSED CONTENT >>;
            string parsedContent = Jsondata;
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();


            return content;
        }

        public void B2bSubmit(string url, string postData)
        {
           
            // creates the post data for the POST request
            // string postData = ("successcode=" + successcode + "&Ref=" + refCode);

            // create the POST request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = postData.Length;


            // POST the data
            using (StreamWriter requestWriter2 = new StreamWriter(webRequest.GetRequestStream()))
            {
                requestWriter2.Write(postData);
            }

            //  This actually does the request and gets the response back
            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();

            string responseData = string.Empty;

            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                // dumps the HTML from the response into a string variable
                responseData = responseReader.ReadToEnd();
            }

            //  Now, find the index of some word on the page that would be 
            //     displayed if the login was successful
            int index = responseData.IndexOf("Measuring");

            //if (index > -1)
            //    ListBox1.Items.Add("SUCCESS");
        }

        public static string Submit()
        {

            const string apiKey = "zbwhrysjg39skka8sa6vgy4f";
            const string sharedSecret = "h3xucDMJtC ";

            //const string endpoint = "https://api.test.hotelbeds.com/hotel-api/1.0/status";

            const string endpoint = "http://testapi.hotelbeds.com/hotel-api/1.0/status";

            // Compute the signature to be used in the API call (combined key + secret + timestamp in seconds)
            string signature;
            using (var sha = SHA256.Create())
            {
                long ts = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
                Console.WriteLine("Timestamp: " + ts);
                var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(apiKey + sharedSecret + ts));
                signature = BitConverter.ToString(computedHash).Replace("-", "");
            }

            Console.WriteLine("Signature: " + signature);

            using (var client = new WebClient())
            {
                // Request configuration            
                client.Headers.Add("X-Signature", signature);
                client.Headers.Add("Api-Key", apiKey);
                client.Headers.Add("Accept", "application/xml");



                // Request execution
                string response = client.DownloadString(endpoint);
                return response;
                //Debug.WriteLine(response);
            }

        }
    }
}
