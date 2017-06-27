using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSIES.Class.Control
{
    class Data_DealClass
    {
        private float left_distence;
        public float LEFT_distence
        {
            get { return left_distence; }
            set { left_distence = value; }
        }
        
        public bool speeding_judge(float speed)   
        {
            if (speed >= 85.0)
            {
                PageList.Scene.SPEED_OUT += 1;
                
            }
            if (PageList.Scene.SPEED_OUT > 5)
            {
                if (PageList.Main.i <= 1)
                    PageList.Login.Regular.Score1 -= 1;
                else
                    PageList.Login.Regular.Score2 -= 1;
                return true;
            }
            return false;
        } //超速行为
        public bool line_judge(float speed ,float acc,float Break)   
        {
            if (((PageList.Scene.S_S >622 * 300 / 7 && PageList.Scene.S_S < 1010 * 300 / 7) || (PageList.Scene.S_S > 2547 * 300 / 7 && PageList.Scene.S_S < 3687 * 300 / 7) || (PageList.Scene.S_S > 5976 * 300 / 7 && PageList.Scene.S_S < 6969 * 300 / 7) ||(PageList.Scene.S_S > 7554 * 300 / 7 && PageList.Scene.S_S <7900 * 300 / 7)) &&  (speed> 70||acc>0.46||Break>0.1)/*这个是阈值*/)
            {
                if (PageList.Main.i <= 1)
                    PageList.Login.Regular.Score1 -= 1;
                else
                    PageList.Login.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }//并线行为
        public bool overtake_judge(float speed, float acc, float Break) 
        {
            if (((PageList.Scene.S_S >1010 * 300 / 7 && PageList.Scene.S_S < 1547 * 300 / 7) || (PageList.Scene.S_S >5382 * 300 / 7 && PageList.Scene.S_S < 5976 * 300 / 7) || (PageList.Scene.S_S >6969 * 300 / 7 && PageList.Scene.S_S < 7554 * 300 / 7) ) && (speed > 80 || acc > 0.46 || Break > 0.1)/*这个是阈值*/)
            {
                if (PageList.Main.i <= 1)
                    PageList.Login.Regular.Score1 -= 1;
                else
                    PageList.Login.Regular.Score2 -= 1;
                return true;
            }
            return false;
        } //超车行为
        public bool lighting_judge(float speed)
        {
            if (PageList.Scene.S_S>320*300/7 && PageList.Scene.S_S <340*300/7 && speed <= 0)
            {
                //if (PageList.Main.i <= 1)
                //    PageList.Main.Regular.Score1 -= 1;
                //else
                //    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }   //闯红灯行为
        public bool distrationg_judge(float speed)
        {
            if (PageList.Scene.S_S>1336 * 300 / 7 && PageList.Scene.S_S <1736 * 300 / 7 && speed<= 0)
            {
                //if (PageList.Main.i <= 1)
                //    PageList.Main.Regular.Score1 -= 1;
                //else
                //    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }   //分心行为
    }
}
