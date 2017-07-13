using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Interface_API.Threadings;
using Newtonsoft.Json.Linq;
using System.Threading;

/// <summary>
/// Summary description for SubScriberController
/// </summary>
public class SubScriberImportController
{
    public static ReaderWriterLock Lock = new ReaderWriterLock();
    public static int TotalCompleted { get; set; }

    public static bool Onprocess { get; set; }

    public static decimal PercentCompleted { get; set; }


    public SubScriberImportController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static int ImportNow(Model_SubscriberParamImport param)
    {
        int ret = 0;
        Model_SubscriberImportTemp import = new Model_SubscriberImportTemp();
       
        import = import.GetImportTemp();
        DataTable data = null; 
        
        if(import != null)
        {
            try
            {
                FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(import.Path + import.FileName));

                if (file.Exists)
                {

                    string extension = file.Extension;

                    switch (extension)
                    {
                        case ".csv":
                            data = new GsCsvReader(import.Path, import.FileName).ResultDataTable;
                            break;
                        default:
                            data = new ExcelReader(import.Path, import.FileName).GetDataSetCreatecolumn().Tables[0];
                            break;
                    }


                    if (data.Rows.Count > 0)
                    {

                        Lock.AcquireWriterLock(Timeout.Infinite);
                        SubScriberImportController.TotalCompleted = 0;
                        SubScriberImportController.PercentCompleted = 0.0M;
                        SubScriberImportController.Onprocess = true;
                        Lock.ReleaseWriterLock();

                        API_ThreadPool cpool = new API_ThreadPool();
                        object[] parameters = new object[] { data , param };
                        cpool.QueueWork(parameters, ImportSubscriber);
                    }

                }
                ret = 1;
            }
            catch { }
           
            

           
        }

        


        return ret;
    }


    public static void ImportSubscriber(object param)
    {
        //Model_Subscriber cSub = new Model_Subscriber();
        object[] parameters = (object[])param;
        DataTable data = (DataTable)parameters[0];
        Model_SubscriberParamImport p = (Model_SubscriberParamImport)parameters[1];
        foreach (DataRow row in data.Rows)
        {
            Model_Subscriber cSub = new Model_Subscriber
            {
                Email = (row.Table.Columns.Contains("Email") ? (row["Email"] == DBNull.Value ? "" : (string)row["Email"] ) : "" ),
                FirstName = (row.Table.Columns.Contains("FirstName") ? (row["FirstName"] == DBNull.Value ? "" : (string)row["FirstName"] ) : "" ),
                LastName = (row.Table.Columns.Contains("LastName") ? (row["LastName"] == DBNull.Value ? "" : (string)row["LastName"] ) : ""),
                Sbin = true,
                SGID = int.Parse(p.Group)

                 
            };
            cSub.model_InsertSubscriber(cSub);

            Lock.AcquireWriterLock(Timeout.Infinite);
            SubScriberImportController.TotalCompleted += 1;
            SubScriberImportController.PercentCompleted =
                 (decimal)SubScriberImportController.TotalCompleted * 100 / int.Parse(p.Total);
            Lock.ReleaseWriterLock();
        }
        Lock.AcquireWriterLock(Timeout.Infinite);
        SubScriberImportController.Onprocess = false;
        Lock.ReleaseWriterLock();

    }

    public static int ImportTemp(Model_SubscriberImportTemp param)
    {
        Model_SubscriberImportTemp import = new Model_SubscriberImportTemp();

        return import.InsertDataImport(param);
    }


    public static Model_SubscriberImportTemp GetTempImprt()
    {
        Model_SubscriberImportTemp import = new Model_SubscriberImportTemp();
        return import.GetImportTemp();
    }


}