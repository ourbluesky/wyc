using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.UDP;

namespace DSIES.Class.Model
{
    public class Reaction : Action
    {
        public float ReactionTimeNow(Svframe frame)
        {
            return ReactionTimeNow(frame.Time);
        }

        public float ReactionTimeNow(float Time)
        {
            if (End != null)
                return Time - Start.Time;
            else
                return Time;
        }

        public float EndAct(Svframe frame)
        {
            this.End = frame;
            return ReactionTimeNow(frame);

        }
    }
}
