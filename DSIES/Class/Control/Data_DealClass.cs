﻿using DSIES.Pages;
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
                if (PageList.Scene.SPEED_OUT < 10/*5s*/)
                    sceneselectData.score.Speed_Score1 = 0;
                    
                if (PageList.Scene.SPEED_OUT < 20/*10s*/)
                    sceneselectData.score.Speed_Score2 = 0;
                if (PageList.Scene.SPEED_OUT < 30/*15s*/)
                    sceneselectData.score.Speed_Score3 = 0;
                if (PageList.Scene.SPEED_OUT < 40/*20s*/)
                    sceneselectData.score.Speed_Score4 = 0;
                if (PageList.Scene.SPEED_OUT < 50/*25s*/)
                    sceneselectData.score.Speed_Score5 = 0;
                return true;
            }
            return false;
        } //超速行为...5...false代表没有触发不合规行为
        public bool line_judge(float speed ,float acc,float Break)   
        {
            if ((PageList.Scene.S_S >622 * 300 / 7 && PageList.Scene.S_S < 1010 * 300 / 7)  &&  (speed> 70||acc>0.46||Break>0.1)/*这个是阈值*/)
            {
                sceneselectData.score.Line_Score1 = 4;
                return true;
            }
            if ((PageList.Scene.S_S > 2547 * 300 / 7 && PageList.Scene.S_S < 3687 * 300 / 7)  && (speed > 70 || acc > 0.46 || Break > 0.1)/*这个是阈值*/)
            {
                sceneselectData.score.Line_Score2 = 4;
                return true;
            }
            if ((PageList.Scene.S_S > 5976 * 300 / 7 && PageList.Scene.S_S < 6969 * 300 / 7)  && (speed > 70 || acc > 0.46 || Break > 0.1)/*这个是阈值*/)
            {
                sceneselectData.score.Line_Score3 = 4;
                return true;
            }
            if ((PageList.Scene.S_S > 7554 * 300 / 7 && PageList.Scene.S_S < 7900 * 300 / 7) && (speed > 70 || acc > 0.46 || Break > 0.1)/*这个是阈值*/)
            {
                sceneselectData.score.Line_Score4 = 4;
                return true;
            }
            return false;
        }//并线行为...4...false代表没有触发不合规行为
        public bool overtake_judge(float speed, float acc, float Break) 
        {
            if ((PageList.Scene.S_S >1010 * 300 / 7 && PageList.Scene.S_S < 1547 * 300 / 7)  && (speed > 80 || acc > 0.46 || Break > 0.1)/*这个是阈值*/)
            {
                sceneselectData.score.Overtake_Score1 = 0;
                return true;
            }
            if ((PageList.Scene.S_S > 5382 * 300 / 7 && PageList.Scene.S_S < 5976 * 300 / 7)  && (speed > 80 || acc > 0.46 || Break > 0.1)/*这个是阈值*/)
            {
                sceneselectData.score.Overtake_Score2 = 0;
                return true;
            }
            if ( (PageList.Scene.S_S > 6969 * 300 / 7 && PageList.Scene.S_S < 7554 * 300 / 7) && (speed > 80 || acc > 0.46 || Break > 0.1)/*这个是阈值*/)
            {
                sceneselectData.score.Overtake_Score3 = 0;
                return true;
            }
            return false;
        } //超车行为...3...false代表没有触发不合规行为
        public bool lighting_judge(float speed)
        {
            if (PageList.Scene.S_S>320*300/7 && PageList.Scene.S_S <340*300/7 && speed <= 0)
            {
                sceneselectData.score.Lighting_Score = 15;
                return false;
            } 
            return true;
        }   //闯红灯行为...1...false代表没有触发不合规行为
        public bool distrationg_judge(float speed)
        {
            if (PageList.Scene.S_S>1336 * 300 / 7 && PageList.Scene.S_S <1736 * 300 / 7 && speed<= 0)
            {
                sceneselectData.score.Lighting_Score = 15;
                return false;
            }
 
            return true;
        }   //分心行为...1
    }
}
