using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Interface_API.Threadings;


namespace Interface_API.Threadings
{
    /// <summary>
    /// Defines the Worker Thread used for the Thread Pool
    /// </summary>
    public class API_WorkThread
    {
        #region Fields and Properties
        /// <summary>
        /// Variable storing the actual worker thread
        /// </summary>
        public Thread m_WorkProcess = null;

        /// <summary>
        /// Boolean variable used to determine if the thread should continue running
        /// </summary>
        private bool m_KeepRunning = true;

        /// <summary>
        /// Used to provide notification of the current status of the thread process
        /// </summary>
        private bool m_Busy = false;
        public bool Busy
        {
            get
            {
                return m_Busy;
            }
        }

        /// <summary>
        /// Used to determine the last operation performed by this thread
        /// </summary>
        DateTime m_LastOperation = DateTime.Now;
        public DateTime LastOperation
        {
            get
            {
                return m_LastOperation;
            }
        }

        /// <summary>
        /// Copy of the overall Work Queue
        /// </summary>
        private Queue<API_WorkItem> m_WorkQueue;

        public object m_WorkObject;

        #endregion

        #region Constructor and Destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkThread"/> class.
        /// </summary>
        public API_WorkThread(ref Queue<API_WorkItem> WorkQueue)
        {
            m_WorkQueue = WorkQueue;
            m_WorkProcess = new Thread(new ThreadStart(Worker));


            m_WorkProcess.Name = "DArkThread_" + DateTime.Now;


            //m_WorkProcess = new Thread(new ParameterizedThreadStart(Worker));

            m_WorkProcess.Start();
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="WorkThread"/> is reclaimed by garbage collection.
        /// </summary>
        ~API_WorkThread()
        {
            if (m_WorkProcess != null)
            {
                m_Busy = false;
                m_KeepRunning = false;
                if (m_WorkProcess.ThreadState == ThreadState.WaitSleepJoin)
                {
                    m_WorkProcess.Interrupt();
                }
                m_WorkProcess.Join();
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Instructs the thread to perform work on the Work Item.
        /// </summary>
        public void WakeUp()
        {
            if (m_WorkProcess.ThreadState == ThreadState.WaitSleepJoin)
            {
                m_WorkProcess.Interrupt();
            }
            m_Busy = true;
        }

        /// <summary>
        /// Used to Shutdown the worker thread
        /// </summary>
        public void ShutDown()
        {
            m_KeepRunning = false;
            if (m_WorkProcess.ThreadState == ThreadState.WaitSleepJoin)
            {
                m_WorkProcess.Interrupt();
            }

            m_WorkProcess.Join();
            m_WorkProcess = null;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Actual Worker process thread
        /// </summary>
        private void Worker()
        {
            API_WorkItem wi;

            while (m_KeepRunning)
            {
                try
                {
                    while (m_WorkQueue.Count > 0)
                    {
                        wi = null;

                        lock (m_WorkQueue)
                        {
                            wi = m_WorkQueue.Dequeue();
                        }

                        if (wi != null)
                        {
                            m_LastOperation = DateTime.Now;
                            m_Busy = true;
                            m_WorkObject = wi.WorkObject;
                            wi.Delegate.Invoke(wi.WorkObject);
                        }
                    }

                }// (Exception ex)
                catch (Exception ex) {
                    string dd = ex.Message + ex.StackTrace;
                }
                

                try
                {
                    m_Busy = false;

                    Thread.Sleep(1000);
                }
                catch { }
            }
        }

        #endregion
    }
}
