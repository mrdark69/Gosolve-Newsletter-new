using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BaseWebMethodAJax
/// </summary>
/// 
public class BaseSendingProcess
{
    public int CID { get; set; }
    public int TotalSend { get; set; }
    public int TotalSent { get; set; }
    public double PercentCompleted { get; set; }
    public byte Ctype { get; set; }
}

public class BaseWebMethodAJax 
{

    public bool success { get; set; }
    public string msg { get; set; }

    public string Totalrecord { get; set; }
    public string KeyID { get; set; }


    public string PerCentCompleted { get; set; }
    public bool IsOnprocess { get; set; }


    public IList<Model_SendingJob> Sendprocess { get; set; }

    public BaseWebMethodAJax()
    {
        //
        // TODO: Add constructor logic here
        //
    }

   

    
}