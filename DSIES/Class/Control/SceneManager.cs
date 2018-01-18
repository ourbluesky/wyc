using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.Class.Control;
using DSIES.UDP;

namespace DSIES.Class.Control
{
    class SceneManager
    {
        public void GameFirstStep()   //绑定的事件
        {
            if (PageList.Scene.FirstRun)
            {
                SetUDPRefreshAction();
                //SetUDPTimeOutAction();
                SetEndAction();
            }
        }

        public void GameStartAction()
        {
            GameFirstStep();
            PageList.Scene.ResetPage();//初始化
            PageList.Main.setPage(PageList.Scene);
            // CurrentPage = PageCluster.GameRealTime;

            /* Start the UDP receiving thread */
            CU.Player.Start();
        }


        private void SetUDPRefreshAction()
        {
            CU.Player.RefreshHandler += PageList.Scene.SetPage;//PageList.Main.setPage(PageList.Scene);
        }
        private void SetEndAction()//我觉得没什么用
        {
           // CU.Player.RefreshHandler == ;//我觉得应该在这里写一些什么，但是不会
        }
    }
}
