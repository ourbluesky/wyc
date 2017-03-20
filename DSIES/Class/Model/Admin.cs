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
        public Admin(string name, string password, string telphone)
        {
            this.Name = name;
            this.Password = password;
            this.Telphone = telphone;
        }

        string telphone;

        public string Telphone
        {
            get { return telphone; }
            set { Telphone = value; }
        }
    }
}
