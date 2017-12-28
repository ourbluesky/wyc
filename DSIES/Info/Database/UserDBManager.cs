using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.Class.Model;
using System.IO;
using System.Data.SQLite;
using DSIES.UDP;
using DSIES.Info;

namespace DSIES.Info.Database
{
      public enum LoginState
       {
            NOTEXIST,
            WRONGPASSWORD,
            NEEDPASSWORD,
            SUCCESS
        }

      class UserDBManager
       {
            public UserDBManager()
            {
            //?
            }

            private SQLiteConnection connection;

            private void OpenConnection()
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Open();
                }
            }

            public bool ConnectDB(string dbPath)
            {
                if (!File.Exists(dbPath)&& !CreateDB(dbPath,FileManager.GetPath("database", "create_sql")))
                return false;

                connection = new SQLiteConnection("Data Source="+ dbPath + ";Version=3;");
                return true;
            }

            public bool CreateDB(string dbPath, string sqlPath)
            {
                SQLiteConnection.CreateFile(dbPath);
                connection = new SQLiteConnection("Data Source="+ dbPath + ";Version=3;");

                string sql = File.ReadAllText(sqlPath);

                return ExecuteNonQuery(sql);//执行命令对象的SQL语句，返回一个int 类型的变量，返回数据库操作之后影响的行数。用来验证对数据库进行增删改。
            }

            public Tuple<LoginState, User> ValidateUser(string telephone,
                string password, UserGroup group)//判断登陆是否成功
            {
                LoginState state;
                User user = GetUser(telephone, group);

                if (user == null)
                    state = LoginState.NOTEXIST;
                else if (Encryptor.GetMD5(password).Equals(user.Password))
                {
                    state = LoginState.SUCCESS;
              //      UpdateLastDate(telephone, group);
                }
                else
                    state = LoginState.WRONGPASSWORD;

                return new Tuple<LoginState, User>(state, user);
            }

            //private bool UpdateLastDate(string telephone, UserGroup group)
            //{
            //    string sql = "update " + group
            //        + " set lastDate = (datetime('now','localtime'))"
            //        + " where telephone = '" + telephone + "'";

            //    return ExecuteNonQuery(sql);
            //}

            public User GetUser(string telephone, UserGroup group)
            {
                string sql = "select * from " + group
                    + " where telephone = '" + telephone + "'";

                List<User> users = GetUsers(sql, group);

                if (users != null && users.Count != 0)
                    return users[0];
                else
                    return null;
            }

        //public List<User> GetAllRegulars()
        //{
        //    string sql = "select * from " + UserGroup.REGULAR;
        //    List<User> users = GetUsers(sql, UserGroup.REGULAR);

        //    return users;
        //}

        public List<Regular> GetAllGrantedUsers(string type,string telephone)//根据type查询，得到所有的用户信息
        {
            string sql = "select * from " + UserGroup.REGULAR
                + " where "+type+" = '" + telephone+"'";
            List<User> users = GetUsers(sql, UserGroup.REGULAR);

            if (users != null && users.Count != 0)
            {
                List<Regular> regulars = users.ConvertAll<Regular>(i => (Regular)i);            //将List<User>强制转换为List<Regular>
                return regulars;
            }
            else
                return null;
        }

        private List<User> GetUsers(string sql, UserGroup group)//从数据库里读出的数据，判断有没有这个人的信息，然后再做相应的查询
            {
                OpenConnection();
                SQLiteDataReader reader = ExecuteQuery(sql);

                if (reader != null && !reader.HasRows)//判断数据流中是否存在数据，进而执行数据的输出操作
            {
                    reader.Close();//关闭reader对象
                    connection.Close();
                    return null;
                }

                List<User> users = new List<User>();
                while (reader.Read())
                {
                    User user;
                    switch (group)
                    {
                        case UserGroup.ADMIN:
                            user = new Admin();
                            (user as Admin).Group = UserGroup.ADMIN;
                            (user as Admin).Telephone = reader[" Telephone"] as string;
                            break;
                        case UserGroup.REGULAR:
                            user = new Regular();
                            Regular regular = user as Regular;
                            regular.Group = UserGroup.REGULAR;
                            regular.Name = reader["name"] as string;
                            regular.Gender = reader["gender"] as string;
                            regular.Age = reader["age"] as string;
                            regular.DriAge = reader["driage"] as string;
                            regular.Career = reader["career"] as string;
                            regular.Accident_times = reader["accident_times"] as string; 
                            regular.Sight_left= reader["sight_left"] as string;
                            regular.Sight_right=reader["sight_right"] as string;           
                            regular.DeepSight_left=reader["deep_sight_left"] as string;
                            regular.DeepSight_right = reader["deep_sight_right"] as string;
                            regular.Reagency = reader["reagency"] as string;  
                            regular.Grade = reader["grade"] as string;                               
                            regular.Grade1 = reader["grade1"] as string;
                            regular.Grade2 = reader["grade2"] as string;
                            regular.Totalscore_frist = reader["totalscore_frist"] as string;
                            regular.Totalscore_final = reader["totalscore_final"] as string;
                            regular.Credit = reader["credit"] as string;
                      
                            break;
                        default:
                            user = null;
                            break;
                    }

                    user.Telephone = reader["telephone"] as string;
                    user.Password = reader["password"] as string;
                    user.Name = reader["name"] as string;
                    //user.RegDate = (DateTime)reader["regDate"];
                    //user.LastDate = (DateTime)reader["lastDate"];
                    users.Add(user);
                }

                reader.Close();
                connection.Close();

                return users;
            }



            public bool AddUser(User user)
            {
                string sql;
                switch (user.Group)
                {
                    case UserGroup.ADMIN:
                        Admin admin = user as Admin;
                        sql = "insert into " + admin.Group
                            + " ( telephone,name, password,grantUserName) values ('"
                            + admin.Telephone + "', '"                            
                            + admin.Name + "', '"
                            + Encryptor.GetMD5(admin.Password) + "', '"
                            + admin.GrantUserName + "') ";
                        break;
                    case UserGroup.REGULAR:
                        Regular regular = user as Regular;
                        sql = "insert into " + regular.Group
                            + " (telephone,name,password,gender,age,driAge,career,accident_times,sight_left,sight_right,deep_sight_left,deep_sight_right,reagency,grade,grade1,grade2,totalscore_frist,totalscore_final,credit) values('"                          

                            + regular.Telephone + "', '"
                            + regular.Name + "', '"
                            + Encryptor.GetMD5(regular.Password) + "', '"
                            + regular.Gender + "',"
                            + regular.Age + ", "
                            + regular.DriAge + ", '"
                            + regular.Career + "', '"
                            + regular.Accident_times + "', '"
                            + regular.Sight_left + "', '"
                            + regular.Sight_right + "', '"            
                            + regular.DeepSight_left + "', '"
                            + regular.DeepSight_right + "', '"
                            + regular.Reagency + "','"

                            + regular.Grade + "', '"
                            + regular.Grade1 + "', '"
                            + regular.Grade2 + "', '"
                            + regular.Totalscore_frist + "', '"
                            + regular.Totalscore_final + "', '"
                            + regular.Credit + "') "
                            ;
                    break;
                    default:
                        return false;
                }

                return ExecuteNonQuery(sql);
            }

            public bool UpdateUserInfo(User user)//修改表中的数据
            {
                string sql;
                switch (user.Group)
                {
                    case UserGroup.ADMIN://修改管理员的信息
                        Admin admin = user as Admin;
                        sql = "update " + admin.Group + " set "
                            + "name = '" + admin.Name + "' "
                            + "where telephone = " + admin.Telephone;
                        break;
                    case UserGroup.REGULAR://修改用户信息
                        Regular regular = user as Regular;
                        sql = "update " + regular.Group + " set "
                            + "name = " + regular.Name + "', "
                            + "telephone = " + regular.Telephone + "', "                           
                            + "gender = '" + regular.Gender + "', "
                            + "age = " + regular.Age + ", "
                            + "driAge = " + regular.DriAge + ", "
                            + "career = '" + regular.Career + "',"
                            + "accident_times = '" + regular.Accident_times + "' "                          
                            + "deepsight_left = " + regular.DeepSight_left + ", "
                            + "deepsight_right = " + regular.DeepSight_right + ", "                            
                            + "sight_left = " + regular.Sight_left + ", "
                            + "sight_right = " + regular.Sight_right + ", "
                            + "reagency = " + regular.Reagency + "', "
                            //+ "grade=" + regular.Grade + ", "
                            //+ "score1=" + regular.Score1 + ", "
                            //+ "grade1=" + regular.Grade1 + ", "
                            //+ "score2=" + regular.Score2 + ", "                         
                            //+ "grade2=" + regular.Grade2 + ", "
                            //+ "totalscore_frist"+regular.Totalscore_frist + "', '"
                            //+ "totalscore_final"+regular.Totalscore_final + "', '"
                            //+ "credit"+regular.Credit + "', '"                          
                            + "where telephone = " + regular.Telephone;
                        break;
                    default:
                        return false;
                }

                return ExecuteNonQuery(sql);//返回修改的行数
            }

            public bool UpdatePassword(string telephone, string password, UserGroup group)
            {
                string sql = "update " + group
                    + " set password = '" + Encryptor.GetMD5(password)
                    + "' where telephone = " + telephone;

                return ExecuteNonQuery(sql);
            }

            private SQLiteDataReader ExecuteQuery(string sql)
            {
                SQLiteDataReader reader;
                try
                {
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    reader = command.ExecuteReader();
                }
                catch (Exception)
                {
                    return null;
                }

                return reader;
            }

            private bool ExecuteNonQuery(string sql)
            {
                try
                {
                    OpenConnection();
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            private float GetFloat(object value)
            {
                return (float)(double)value;
            }

            private int GetInt(object value)
            {
                return (int)(long)value;
            }
        }
    }


