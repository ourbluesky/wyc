using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.Class.Control;
using DSIES.UDP;

namespace DSIES.UDP
{
    static class CU
    {
        /* 
         * This static Class is the center of the System.
         * It holds all Resources except Thread and File.
         */

        //加
        static CU()
        {
            SET_UDP = new UDPSetting();
            MG_UDP = new UDPManager(SET_UDP);
            MG_User = new UserManager();

        }

        public static UDPManager MG_UDP;
        public static UDPSetting SET_UDP;
        public static UserManager MG_User;


        public static void Hit() { }
    }
}
