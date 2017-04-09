using DSIES.Class.Control;
using DSIES.UDP;
using DSIES.Pages;
using System.Collections.Generic;
using System.Threading;

namespace DSIES.Class.Control
{
    /*
     * Implementation of 
     */
    class Player
    {
        public Player()
        {
            recorder = new Recorder();
        }

        Recorder recorder;

        private bool _refreshEnable;

        public delegate void StartAction();
        public delegate void RefreshAction(Svframe recorder);
        public delegate void StopAction();

        public StartAction StartHandler = null;
        public RefreshAction RefreshHandler = null;
        public StopAction StopHandler = null;

        private Thread refreshThread;


        public void Start()
        {
            recorder.Start( );
            DefineRefreshThread();
            StartRefreshThread();
        }

        private void DefineRefreshThread()
        {
            refreshThread = ThreadManager.DefineThread(
                ThreadCluster.PlayerRefresh, Refresh);
        }

        private void StartRefreshThread()
        {
            StartHandler?.Invoke();// StartHandler?.Invoke();//？表示可空

            _refreshEnable = true;
            ThreadManager.StartThread(ThreadCluster.PlayerRefresh);
        }

        private void StopRefreshThread()
        {
            _refreshEnable = false;
        }

        private void Refresh()
        {
            CU.MG_UDP.PrepareReceive();
            
            while (_refreshEnable)
            {
                Svframe frame = CU.MG_UDP.ReceiveFrame();

                if (frame != null)
                {
                    if (recorder.Record(frame))
                        RefreshHandler?.Invoke(frame);//执行触发
                }
                else
                    StopRefreshThread();
            }

            ////CU.MG_UDP.EndReceive();
        }

        //public void End()//没用
        //{
        //    StopRefreshThread();
        //    //Exp exp = recorder.Stop();
        //    //exp.ExpType = type;
        //    //StopHandler?.Invoke(exp);
        //}
    }
}
