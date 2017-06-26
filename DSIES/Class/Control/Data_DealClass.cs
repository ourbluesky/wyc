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
        private bool back;//保留
        
        public bool speeding_judge(float speed)    //超速行为
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
        }
        public bool line_judge()   //并线行为；缺少车道数
        {
            if (PageList.Scene.S_S == 3087)
            {
                actline = this.line;              
            }
            if (PageList.Scene.S_S >= 3087)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }
        public bool overtake_judge()  //超车行为；缺少车道数
        {
            if (PageList.Scene.S_S == 2733)
            {
                actline = this.line;
            }
            if (back == true && PageList.Scene.S_S <= 3200 && left_distence < 30)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }
        public bool lighting_judge(float speed)
        {
            if (PageList.Scene.S_S>500 && speed == 0)
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
            if (PageList.Scene.S_S>700 && speed == 0)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return false;
            }
            return true;
        }   //分心行为


        public bool line_change()  //判断是否变道；缺少车道数
        {
            if (line_change() == true && this.line == actline)
            {
                back = true;
                return false;
            }
            if (line_change() == false && this.line!=actline)    
                return true;
            return line_change();
        }
    }
}
