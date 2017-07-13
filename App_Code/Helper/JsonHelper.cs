using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for JsonHelper
/// </summary>
/// 


    public static class JsonHelper
    {

        public static object JsonToObjectList(this string strJson, object ObjClass)
        {

            Type toObjectType = ObjClass.GetType();
            // Object newObjectToReturn = Activator.CreateInstance(ObjClass.GetType());

            var IListRef = typeof(List<>);
            Type[] IListParam = { toObjectType };

            Object Result = Activator.CreateInstance(IListRef.MakeGenericType(IListParam));

            return JsonConvert.DeserializeObject(strJson, Result.GetType());

        }


        

        public static object JsonToObject(this string strJson, object ObjClass)
        {
            //Type toObjectType = ObjClass.GetType();
            // Object newObjectToReturn = Activator.CreateInstance(ObjClass.GetType());

            //var IListRef = typeof(List<>);
            // Type[] IListParam = { toObjectType };

            Object Result = Activator.CreateInstance(Type.GetType(ObjClass.GetType().FullName.ToString()));
            //Object Result = Activator.CreateInstance(IListRef.MakeGenericType(IListParam));

            return JsonConvert.DeserializeObject(strJson, Result.GetType());
        }

        public static string ObjectToJSON(this object obj)
        {
            
            string body = JsonConvert.SerializeObject(obj, Formatting.Indented,  new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return body;
        }

        public static string ObjectToJSON(this object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }

        public static dynamic JsonTODynamic(string strJson)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //serializer.MaxJsonLength = Int64.MaxValue;
            return serializer.Deserialize<dynamic>(strJson);
        }


        public static string RegMiniJson(this string myJSON)
        {
            return Regex.Replace(myJSON, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
        }

}
