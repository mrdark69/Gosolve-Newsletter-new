using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for SendgridClass
/// </summary>


    public enum Tracking_email_cat : byte
    {
        Processed = 1,
        Dropped = 2,
        Delivered = 3,
        Deferred = 4,
        Bounce = 5,
        Open = 6,
        Click = 7,
        Spam_report = 8,
        Unsubscribe = 9

    }
    public class MailGunClass : BaseModel<MailGunClass>
    {
        [JsonProperty("MainSite")]
        public byte MainSite { get; set; }
        [JsonProperty("booking_id")]
        public int BookingId { get; set; }
        [JsonProperty("email_sento")]
        public string email_sendto { get; set; }
        [JsonProperty("email_type_id")]
        public string email_type_id { get; set; }
        [JsonProperty("email_type_title")]
        public string email_type_title { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("event")]
        public string EventMethod { get; set; }
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        public MailGunClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertDataTracking(MailGunClass objSendGrid)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_booking_email_tracking (booking_id,tracking_cat_id,email,email_type_id,email_type_title,track_title,date,email_send_real,cus_id) VALUES(@booking_id,@tracking_cat_id,@email,@email_type_id,@email_type_title,@track_title,@date,@email_send_real,@cus_id)", cn);

                int intTypeId = 100 - int.Parse(objSendGrid.email_type_id);

                if (intTypeId >= 21 && intTypeId <= 30)
                {
                    cmd.Parameters.AddWithValue("@booking_id", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cus_id", objSendGrid.BookingId);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@booking_id", objSendGrid.BookingId);
                    cmd.Parameters.AddWithValue("@cus_id", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@tracking_cat_id", Processresult(objSendGrid.EventMethod));
                cmd.Parameters.AddWithValue("@email", objSendGrid.email_sendto);
                cmd.Parameters.AddWithValue("@email_type_id", objSendGrid.email_type_id);
                cmd.Parameters.AddWithValue("@email_type_title", objSendGrid.email_type_title);
                cmd.Parameters.AddWithValue("@track_title", objSendGrid.EventMethod);
                cmd.Parameters.AddWithValue("@date", objSendGrid.TimeStamp.ApiService_TimeStampToDate());
                cmd.Parameters.AddWithValue("@email_send_real", objSendGrid.email);
                cn.Open();

                return ExecuteNonQuery(cmd);
            }


        }


        //timestamp

        public int Processresult(string result)
        {
            int ret = 0;
            switch (result)
            {
                case "accepted":
                    ret = 1;
                    break;
                case "dropped":
                    ret = 2;
                    break;
                case "delivered":
                    ret = 3;
                    break;
                case "failed":
                    ret = 4;
                    break;
                case "bounced":
                    ret = 5;
                    break;
                case "opened":
                    ret = 6;
                    break;
                case "clicked":
                    ret = 7;
                    break;
                case "spam_report":
                    ret = 8;
                    break;
                case "unsubscribed":
                    ret = 9;
                    break;
                case "rejected":
                    ret = 10;
                    break;
                case "complained":
                    ret = 12;
                    break;



            }

            return ret;
        }


    }

