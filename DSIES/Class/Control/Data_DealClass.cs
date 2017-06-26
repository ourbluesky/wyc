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
        private float line;
        public float LINE
        {
            get { return line; }
            set { line = value; }
        }
        private float actline;//保留
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
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        } //超速行为
        public bool line_judge(float speed ,float acc,float Break)   
        {
            if (((PageList.Scene.S_S >622 && PageList.Scene.S_S < 1010) || (PageList.Scene.S_S > 2547 && PageList.Scene.S_S < 3687) || (PageList.Scene.S_S > 5976 && PageList.Scene.S_S < 6969)||(PageList.Scene.S_S > 7554 && PageList.Scene.S_S <7900)) &&  (speed> 70||acc>0.46||Break>0.1)/*这个是阈值*/)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }//并线行为
        public bool overtake_judge(float speed, float acc, float Break) 
        {
            if (((PageList.Scene.S_S >1010 && PageList.Scene.S_S < 1547) || (PageList.Scene.S_S >5382 && PageList.Scene.S_S < 5976) || (PageList.Scene.S_S >6969 && PageList.Scene.S_S < 7554) ) && (speed > 80 || acc > 0.46 || Break > 0.1)/*这个是阈值*/)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        } //超车行为
        public bool lighting_judge(float speed)
        {
            if (PageList.Scene.S_S>320 && PageList.Scene.S_S <340 && speed >= 0)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return false;
            }
            return true;
        }   //闯红灯行为
        public bool distrationg_judge(float speed)
        {
            if (PageList.Scene.S_S>1336 && PageList.Scene.S_S <1736 && speed >= 0)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return false;
            }
            return true;
        }   //分心行为
    }
}
