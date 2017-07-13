using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface_API.Threadings;

namespace Interface_API.Threadings
{
    /// <summary>
    /// Common Delegate used to perform work
    /// </summary>
    /// <param name="WorkItem"></param>
    public delegate void WorkDelegate(object WorkObject);

    /// <summary>
    /// Defines a Work Item used in the Thread Pool
    /// </summary>
    public class API_WorkItem
    {
        public object WorkObject;
        public WorkDelegate Delegate;
    }
}
