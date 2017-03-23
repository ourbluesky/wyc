using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Model
{
    public class Admin : User
    {
        public Admin() { }

        public Admin(
             string telphone,
             string password,
             string name,
             string grantUserName)
        {            
            this.Telphone = telphone;          
            this.Password = password;
            this.Name = name;
            this.grantUserName = grantUserName;
        }

        string grantUserName;

        public string GrantUserName
        {
            get { return grantUserName; }
            set { grantUserName = value; }
        }
    }
}

