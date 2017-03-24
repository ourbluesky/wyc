using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Control
{
    class AdminLoginData
    {
        private string grantusername;
        public string grantUsername
        {
            get { return grantusername; }
            set { grantusername = value; }
        }
        private string grantpassword;
        public string grantPassword
        {
            get { return grantpassword; }
            set { grantpassword = value; }
        }
    }
}
