using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Control
{
    class Education
    {
        private bool speeding=false;//超速
        public bool Speeding
        {
            get { return speeding; }
            set { speeding = value; }
        }
        private bool line=false;//
        public bool Line
        {
            get { return line; }
            set { line = value; }
        }
        private bool overtake=false;
        public bool Overtake
        {
            get { return overtake; }
            set { overtake = value; }
        }
        private bool lighting=false;
        public bool Lighting
        {
            get { return lighting; }
            set { lighting = value; }
        }
        private bool distraction=false;
        public bool Distraction
        {
            get { return distraction; }
            set { distraction = value; }
        }
        public string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

    }
}
