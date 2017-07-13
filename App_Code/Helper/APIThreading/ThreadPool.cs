using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Interface_API.Threadings;

namespace Interface_API.Threadings
{
    /// <summary>
    /// Used to create an indepenent Thread Pool
    /// </summary>
    public class API_ThreadPool
    {

        #region Fields and Properties

        // Internal Value for the MinThreads
        private int m_MinThreads = 0;
        /// <summary>
        /// Gets or Sets the MinThreads 
        /// Value for thread free up on CPU ; will be not remove from threadlist after  timeout;
        /// </summary>
        public int MinThreads
        {
            get { return this.m_MinThreads; }
            set { this.m_MinThreads = value; }
        }

        // Internal Value for the MaxThreads
        private int m_MaxThreads = 10;
        /// <summary>
        /// Gets or Sets the MaxThreads 
        /// </summary>
        public int MaxThreads
        {
            get { return this.m_MaxThreads; }
            set { this.m_MaxThreads = value; }
        }

        // Internal Value for the IdleTimeThreshold
        private int m_IdleTimeThreshold = 5;
        /// <summary>
        /// Gets or Sets the IdleTimeThreshold
        /// Time Process per WorkerProcess : default 5 sec/worker
        /// </summary>
        public int IdleTimeThreshold
        {
            get { return this.m_IdleTimeThreshold; }
            set { this.m_IdleTimeThreshold = value; }
        }




        private int _queue_capacity = 0;
        public int Queue_Capacity
        {
            get { return this._queue_capacity; }
            set { this._queue_capacity = value; }
        }
        //Stores the list of Work Queue
        private Queue<API_WorkItem> WorkQueue;

        //Returns the length of the queue
        public int QueueLength
        {
            get
            {
                return WorkQueue.Count();
            }
        }


        //private object[] _parameter = null;
        //public object[] Parameter
        //{
        //    get { return this._parameter; }
        //    set { this._parameter = value; }
        //}

        //Stores the list of Threads
        public List<API_WorkThread> ThreadList;

        // Performs management of the other threads in the thread pool
        private Thread ManagementThread;
        private bool KeepManagementThreadRunning = true;
        #endregion

        #region Constructor and Destructor
        /// <summary>
        /// Constructor
        /// </summary>
        public API_ThreadPool()
        {
            ManagementThread = new Thread(new ThreadStart(ManagementWorker));
            ManagementThread.Start();

            WorkQueue = new Queue<API_WorkItem>();


            ThreadList = new List<API_WorkThread>();
        }

        public API_ThreadPool(int intcapacity)
        {
            ManagementThread = new Thread(new ThreadStart(ManagementWorker));
            ManagementThread.Start();

            this.Queue_Capacity = intcapacity;

            if (this.Queue_Capacity > 0)
                WorkQueue = new Queue<API_WorkItem>(this.Queue_Capacity);
            else
                WorkQueue = new Queue<API_WorkItem>();

            ThreadList = new List<API_WorkThread>();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~API_ThreadPool()
        {
            //Stop the Management thread
            KeepManagementThreadRunning = false;
            if (ManagementThread != null)
            {
                if (ManagementThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    ManagementThread.Interrupt();
                }
                ManagementThread.Join();
            }

            //Stop each of the threads
            foreach (API_WorkThread t in ThreadList)
            {
                t.ShutDown();
            }
            ThreadList.Clear();

            //Empty the Work Queue
            WorkQueue.Clear();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Used to add work to the queue.
        /// </summary>
        /// <param name="WorkObject">The work object.</param>
        /// <param name="Delegate">The delegate.</param>
        public void QueueWork(object WorkObject, WorkDelegate Delegate)
        {
            API_WorkItem wi = new API_WorkItem();

            wi.WorkObject = WorkObject;
            wi.Delegate = Delegate;
            lock (WorkQueue)
            {
                WorkQueue.Enqueue(wi);
            }

            //Now see if there are any threads that are idle
            bool FoundIdleThread = false;
            foreach (API_WorkThread wt in ThreadList)
            {
                if (!wt.Busy)
                {
                    wt.WakeUp();
                    FoundIdleThread = true;
                    break;
                }
            }

            if (!FoundIdleThread)
            {
                //See if we can create a new thread to handle the additional workload
                if (ThreadList.Count < this.MaxThreads)
                {
                    API_WorkThread wt = new API_WorkThread(ref WorkQueue);
                    lock (ThreadList)
                    {
                        ThreadList.Add(wt);
                    }
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                lock (ThreadList)
                {
                    foreach (API_WorkThread wt in ThreadList)
                    {
                        if (wt.Busy)
                        {

                            return true;
                        }
                    }

                    return false;
                }
            }
        }


        /// <summary>
        /// Used to shutdown the thread pool
        /// </summary>
        public void Shutdown()
        {
            //Stop the Management thread
            KeepManagementThreadRunning = false;
            if (ManagementThread != null)
            {
                if (ManagementThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    ManagementThread.Interrupt();
                }
                ManagementThread.Join();
            }
            ManagementThread = null;

            //Stop each of the threads
            foreach (API_WorkThread t in ThreadList)
            {
                t.ShutDown();
            }
            ThreadList.Clear();

            //Empty the Work Queue
            WorkQueue.Clear();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Worker Management Process used to manage the threads in the thread pool
        /// </summary>
        private void ManagementWorker()
        {
            while (KeepManagementThreadRunning)
            {
                try
                {
                    //Check to see if we have idle thread we should free up
                    if (ThreadList.Count > this.MinThreads)
                    {
                        foreach (API_WorkThread wt in ThreadList)
                        {
                            if (DateTime.Now.Subtract(wt.LastOperation).Seconds > m_IdleTimeThreshold)
                            {
                                wt.ShutDown();
                                lock (ThreadList)
                                {
                                    ThreadList.Remove(wt);
                                    break;
                                }
                            }
                        }
                    }
                }
                catch { }

                try
                {
                    Thread.Sleep(1000);
                }
                catch { }
            }
        }

        #endregion
    }
}
