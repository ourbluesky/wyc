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
             string telephone,
             string password,
             string name,
             string grantUserName,
             string grantpassword)
        {            
            this.Telephone = telephone;          
            this.Password = password;
            this.Name = name;
            this.grantUserName = grantUserName;
            this.grantpassword = grantpassword;
        }

        string grantUserName;

        public string GrantUserName
        {
            get { return grantUserName; }
            set { grantUserName = value; }
        }

        string grantpassword;

        public string GrantPassword
        {
            get { return grantpassword; }
            set { grantpassword = value; }
        }
    }
}

