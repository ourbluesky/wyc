﻿using System;
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
        Telephone,
        Name,
        Password,
        //RegDate,
        //LastDate,
        Gender,//性别
        Age,
        DriAge,//驾龄
        Career,
      //  Group,
        Accident_times,
        Sight_left,
        Sight_right,
        Deepsight_left,
        DeepSight_right,
        Reagency,
        Grade,
        Score1, 
        Grade1,
        Score2,
        Grade2,
        Totalscore_frist,//第一次总得分
        Totalscore_final,//最后一次总得分
        Credit,
        Time
    }

    public abstract class User
    {
        private string name=" ";//初始非空
        private string password="";
        //private DateTime regDate;
        //private DateTime lastDate;
        private string telephone="";
        private string time="";
        private UserGroup group;

        
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public UserGroup Group
        {
            get { return group; }
            set { group = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        //public DateTime RegDate
        //{
        //    get { return regDate; }
        //    set { regDate = value; }
        //}

        //public DateTime LastDate
        //{
        //    get { return lastDate; }
        //    set { lastDate = value; }
        //}

    }
}

