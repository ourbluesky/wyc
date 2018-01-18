﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DSIES.Class.Control
{
    public enum ThreadCluster
    {
        PlayerRefresh,
        UDPTest,
      
    }

    /*
     * ThreadManager manages all new threads.
     */
    static class ThreadManager
    {
        static ThreadManager()
        {
            threads = new Dictionary<ThreadCluster, Thread>();
        }

        private static Dictionary<ThreadCluster, Thread> threads;

        public static Thread DefineThread(ThreadCluster name,
            ThreadStart func)
        {
            Thread thread = new Thread(func);
            thread.Name = name.ToString();

            if (threads.ContainsKey(name))
                threads[name].Abort();

            threads[name] = thread;

            return thread;
        }

        public static bool StartThread(ThreadCluster name)
        {
            if (!threads.ContainsKey(name))
                return false;

            threads[name].Start();

            return true; ;
        }


        public static void KillAll()
        {
            foreach (var thread in threads.Values)
                thread.Abort();
        }

        public static void Hit() { }
    }
}
