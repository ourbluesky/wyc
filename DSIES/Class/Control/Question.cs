using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Control
{
    class Question
    {
        private int score1;
        public int Score1
        {
            get { return score1; }
            set { score1 = value; }
        }

        private int score2;
        public int Score2
        {
            get { return score2; }
            set { score2 = value; }
        }

        private string grade1;
        public string Grade1
        {
            get { return grade1; }
            set { grade1 = value; }
        }

        private string grade2;
        public string Grade2
        {
            get { return grade2; }
            set { grade2 = value; }
        }

        private bool flagquestion;
        public bool Flagquestion
        {
            get { return flagquestion; }
            set { flagquestion = value; }
        }
    }
}
