using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Control
{
    class Data_DealClass
    {
        private float speed;
        public float SPEED
        {
            get { return speed; }
            set { speed = value; }
        }
        private float speed_out;//保留
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

        public bool speeding_judge()    //超速行为
        {
            speed_change();
            if (speed_out > 5)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }
        public bool line_judge(float x,float y)   //并线行为
        {
            if (y == 3087)
            {
                actline = this.line;              
            }
            if (speed_change() == true && y <= 3287 && y >= 3087)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }
        public bool overtake_judge(float x, float y)  //超车行为
        {
            if (y == 2733)
            {
                actline = this.line;
            }
            if (back == true && y >= 2733 && y <= 3200 && left_distence < 30)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }
        public bool lighting_judge(float x,float y)
        {
            if (y < -390 && y > -457 && this.speed == 0)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }   //闯红灯行为
        public bool distrationg_judge(float x,float y)
        {
            if (x < 2052 && x > 1652 && this.speed == 0)
            {
                if (PageList.Main.i <= 1)
                    PageList.Main.Regular.Score1 -= 1;
                else
                    PageList.Main.Regular.Score2 -= 1;
                return true;
            }
            return false;
        }   //分心行为
        public bool speed_change()
        {
            if (speed_change() == true && this.speed <= 85)           
                return false;
            if (speed_change() == false && this.speed >= 85)
            {
                speed_out += 1;
                return true;
            }
            return speed_change();
        }
        public bool line_change()
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
