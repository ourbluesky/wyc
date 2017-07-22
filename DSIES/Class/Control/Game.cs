
/*和游戏有关的属性，是否进行过游戏，总点击次数，得分情况，abcd四个按钮被点击的次数*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Control
{

    class Game
    {
        private bool done;


        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        private int times;
        public int Times
        {
            get { return times; }
            set { times = value; }
        }
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private int Atimes;
        public int ATimes
        {
            get { return Atimes; }
            set { Atimes = value; }
        }
        private int Btimes;
        public int BTimes
        {
            get { return Btimes; }
            set { Btimes = value; }
        }
        private int Ctimes;
        public int CTimes
        {
            get { return Ctimes; }
            set { Ctimes = value; }
        }
        private int Dtimes;
        public int DTimes
        {
            get { return Dtimes; }
            set { Dtimes = value; }
        }
    }
}

