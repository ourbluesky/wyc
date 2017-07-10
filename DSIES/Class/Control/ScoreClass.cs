using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Control
{
    class ScoreClass
    {
        private int speed_score1 = 3;
        private int speed_score2 = 3;
        private int speed_score3 = 3;
        private int speed_score4 = 3;
        private int speed_score5 = 3;
        private int line_score1 = 4;
        private int line_score2 = 4;
        private int line_score3 = 4;
        private int line_score4 = 3;
        private int overtake_score1 = 5;
        private int overtake_score2 = 5;
        private int overtake_score3 = 5;
        private int lighting_score = 0;
        private int distrationg_score = 0;



        public int Speed_Score1
        {
            get { return speed_score1; }
            set { speed_score1 = value; }
        }
        public int Speed_Score2
        {
            get { return speed_score2; }
            set { speed_score2 = value; }
        }
        public int Speed_Score3
        {
            get { return speed_score3; }
            set { speed_score3 = value; }
        }
        public int Speed_Score4
        {
            get { return speed_score4; }
            set { speed_score4 = value; }
        }
        public int Speed_Score5
        {
            get { return speed_score5; }
            set { speed_score5 = value; }
        }
        public int Line_Score1
        {
            get { return line_score1; }
            set { line_score1 = value; }
        }
        public int Line_Score2
        {
            get { return line_score2; }
            set { line_score2 = value; }
        }
        public int Line_Score3
        {
            get { return line_score3; }
            set { line_score3 = value; }
        }
        public int Line_Score4
        {
            get { return line_score4; }
            set { line_score4 = value; }
        }

        public int Overtake_Score1
        {
            get { return overtake_score1; }
            set { overtake_score1 = value; }
        }
        public int Overtake_Score2
        {
            get { return overtake_score2; }
            set { overtake_score2 = value; }
        }
        public int Overtake_Score3
        {
            get { return overtake_score3; }
            set { overtake_score3 = value; }
        }
        public int Lighting_Score
        {
            get { return lighting_score; }
            set { lighting_score = value; }
        }
        public int Distrationg_Score
        {
            get { return distrationg_score; }
            set { distrationg_score = value; }
        }

         public int add_all(int x1, int x2, int x3, int x4, int x5, int y1, int y2, int y3, int y4, int z1, int z2, int z3, int m, int n)
        {
            return 25+x1 + x2 + x3 + x4 + x5 + y1 + y2 + y3 + y4 + z1 + z2 + z3 + m + n;
        }

    }
}
