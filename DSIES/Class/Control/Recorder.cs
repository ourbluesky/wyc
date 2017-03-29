using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.UDP;

namespace DSIES.Class.Control
{
    class Recorder
    {
        private Svframe currentFrame ;
        public Svframe CurrentFrame
        {
            get { return currentFrame; }
        }
        public bool Record(Svframe frame)
        {
            currentFrame = frame;
            return true;
        }
        public void Start()
        {
            Init();
        }
        private void Init()
        {
            currentFrame = new Svframe(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
