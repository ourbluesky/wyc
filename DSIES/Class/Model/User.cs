using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Model
{
    public enum UserGroup      // 数据库表名应与此保持一致（小写）
    {
        ADMIN,
        REGULAR
    }
    public enum UserVariable
    {
        Name,
        Password,
   //     RegDate,
    //    LastDate,
        Gender,//性别
        Age,
        DriAge,//驾龄
        Career,
        Telphone,
        Group,
        DeepSight_right,
        Deepsight_left,
        Reagency,
        Sight_right,
        Sight_left,
        Breaktime,
        Score,
        Grade1,
        Grade2,
        Score1,
        Score2
    }

    public abstract class User
    {
        private string name;
        private string password;
        private DateTime regDate;
        private DateTime lastDate;
        private string telphone;
        private UserGroup group;


        public UserGroup Group
        {
            get { return group; }
            set { group = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }

        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }

        public string Telphone
        {
            get { return telphone; }
            set { telphone = value; }
        }

    }
}

