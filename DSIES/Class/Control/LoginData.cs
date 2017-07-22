/*用户注册时候的各种信息属性，姓名，性别，年龄，驾龄，违章次数，工作，电话号码，左右眼视力，左右眼深视力，反应力，密码*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.Class.Control
{
    class LoginData
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string age;
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        private string year;
        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private string times;
        public string Times
        {
            get { return times; }
            set { times = value; }
        }
        private string job;
        public string Job
        {
            get { return job; }
            set { job = value; }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string left_sight;
        public string Left_Sight
        {
            get { return left_sight; }
            set { left_sight = value; }
        }
        private string right_sight;
        public string Right_Sight
        {
            get { return right_sight; }
            set { right_sight = value; }
        }
        private string left_deep_sight;
        public string Left_Deep_Sight
        {
            get { return left_deep_sight; }
            set { left_deep_sight = value; }
        }
        private string right_deep_sight;
        public string Right_Deep_Sight
        {
            get { return right_deep_sight; }
            set { right_deep_sight = value; }
        }
        private string reation;
        public string Reation
        {
            get { return reation; }
            set { reation = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }


}
