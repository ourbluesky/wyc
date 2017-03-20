using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.Class.Control;

namespace DSIES.UDP
{
    static class CU
    {
        /* 
         * This static Class is the center of the System.
         * It holds all Resources except Thread and File.
         */
        static CU()
        {
            MG_Set = new SettingManager();



            MG_UDP = new UDPManager(MG_Set.UDP);

        }

        public static SettingManager MG_Set;


        public static UDPManager MG_UDP;


        public static void Hit() { }
    }
}
