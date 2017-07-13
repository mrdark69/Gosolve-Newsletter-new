using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Security.Cryptography;
using System.Reflection;
using System.Web.Caching;
using System.Diagnostics;
using gosolvelicence;
/// <summary>
/// Summary description for BaseModel
/// </summary>
public class BaseModel<T>: DataConnect
{
    public BaseModel()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    protected static Cache Cache
    {
        get { return HttpContext.Current.Cache; }
    }

    protected static void CacheData(string key, object data)
    {
        if (data != null)
        {

            BaseModel<T>.Cache.Insert(key, data, null,
            DatetimeHelper._UTCNow().AddSeconds(300), TimeSpan.Zero);
        }
    }

    /// <summary>
    /// Remove from the ASP.NET cache all items whose key starts with the input prefix
    /// </summary>
    /// 
    public static void PurgeCacheItems(string prefix)
    {
        prefix = prefix.ToLower();
        List<string> itemsToRemove = new List<string>();

        IDictionaryEnumerator enumerator = BaseModel<T>.Cache.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Key.ToString().ToLower().StartsWith(prefix))
                itemsToRemove.Add(enumerator.Key.ToString());
        }

        foreach (string itemToRemove in itemsToRemove)
            BaseModel<T>.Cache.Remove(itemToRemove);
    }

    //protected static Cache Cache
    //{
    //    get { return HttpContext.Current.Cache; }
    //}

    //protected static void CacheData(string key, object data)
    //{
    //    if (data != null)
    //    {
    //        BaseModel.Cache.Insert(key, data, null,
    //           DateTime.Now.AddSeconds(300), TimeSpan.Zero);
    //    }
    //}

    ///// <summary>
    ///// Remove from the ASP.NET cache all items whose key starts with the input prefix
    ///// </summary>
    ///// 
    //public static void PurgeCacheItems(string prefix)
    //{
    //    prefix = prefix.ToLower();
    //    List<string> itemsToRemove = new List<string>();

    //    IDictionaryEnumerator enumerator = BaseModel.Cache.GetEnumerator();
    //    while (enumerator.MoveNext())
    //    {
    //        if (enumerator.Key.ToString().ToLower().StartsWith(prefix))
    //            itemsToRemove.Add(enumerator.Key.ToString());
    //    }

    //    foreach (string itemToRemove in itemsToRemove)
    //        BaseModel.Cache.Remove(itemToRemove);
    //}

    //protected T MappingObjectFromDataReader(IDataReader reader, object ClassTOMap)
    //{
    //    //Type fromObjectType = fromObj.GetType();
    //    Type toObjectType = ClassTOMap.GetType();
    //    int count = 0;
    //    T newObjectToReturn = Activator.CreateInstance(ClassTOMap.GetType());
    //    //object obj = Activator.CreateInstance(Type.GetType(this.GetType().FullName.ToString()));
    //    int FieldCount = reader.FieldCount;
    //    foreach (PropertyInfo toProperty in toObjectType.GetProperties())
    //    {
    //        if (toProperty.CanRead)
    //        {
    //            if (toProperty.CanWrite)
    //            {
    //                if (count < FieldCount)
    //                {
    //                    if (reader[count] != DBNull.Value)
    //                    {
    //                        toProperty.SetValue(newObjectToReturn, reader[count], null);
    //                    }
    //                }
    //            }
    //        }
    //        count = count + 1;
    //    }
    //    return newObjectToReturn;

    //}



    protected T MappingObjectFromDataReader(IDataReader reader,int rows = 0)
    {

        SoftwareExpired li = new SoftwareExpired();
        

        //Type fromObjectType = fromObj.GetType();
        Type toObjectType = this.GetType();
        int count = 0;
        T newObjectToReturn = (T)Activator.CreateInstance(this.GetType());
        //object obj = Activator.CreateInstance(Type.GetType(this.GetType().FullName.ToString()));

        int FieldCount = reader.FieldCount;

    

        foreach (PropertyInfo toProperty in toObjectType.GetProperties())
        {

            if (toProperty.CanRead && toProperty.CanWrite && count < FieldCount)
            {
               if (reader[count] != DBNull.Value)
                    toProperty.SetValue(newObjectToReturn, reader[count], null);
               
            }
            count = count + 1;
        }

        if (!li.IsExpired())
        {
            //bindingrowCount
            if (toObjectType.GetProperty("RowNum") != null)
                toObjectType.GetProperty("RowNum").SetValue(newObjectToReturn, rows, null);
        }
        
        return newObjectToReturn;

    }
    protected T MappingObjectFromDataReaderByName(IDataReader reader, int rows = 0)
    {
        SoftwareExpired li = new SoftwareExpired();
        //Type fromObjectType = fromObj.GetType();
        Type toObjectType = this.GetType();
       
        T newObjectToReturn = (T)Activator.CreateInstance(this.GetType());
        //object obj = Activator.CreateInstance(Type.GetType(this.GetType().FullName.ToString()));

        int FieldCount = reader.FieldCount;



        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (!reader.IsDBNull(i))
            {
                PropertyInfo toProperty = toObjectType.GetProperty(reader.GetName(i));
                toProperty.SetValue(newObjectToReturn, reader[i], null);
            }
            
        }


        if (!li.IsExpired())
        {
            //bindingrowCount
            if (toObjectType.GetProperty("RowNum") != null)
                toObjectType.GetProperty("RowNum").SetValue(newObjectToReturn, rows, null);
        }
        return newObjectToReturn;

    }
    //protected List<T> MappingObjectCollectionFromDataReader(IDataReader reader, object ClassTOMap)
    //{
    //    List<T> ListObject = new List<T>();
    //    while (reader.Read())
    //    {
    //        ListObject.Add(MappingObjectFromDataReader(reader, ClassTOMap));
    //    }
    //    return ListObject;
    //}

    protected List<T> MappingObjectCollectionFromDataReader(IDataReader reader)
    {
        List<T> ListObject = new List<T>();
        int rows = 0;
        while (reader.Read())
        {
            rows = rows + 1;
            ListObject.Add(MappingObjectFromDataReader(reader, rows));


        }
        return ListObject;
    }


    protected List<T> MappingObjectCollectionFromDataReaderByName(IDataReader reader)
    {
        List<T> ListObject = new List<T>();
        int rows = 0;
        while (reader.Read())
        {
            rows = rows + 1;
            
                ListObject.Add(MappingObjectFromDataReaderByName(reader, rows));
            

        }
        return ListObject;
    }


}