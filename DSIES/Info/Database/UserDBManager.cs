using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.Class.Model;
using System.IO;
using System.Data.SQLite;
using DSIES.UDP;

namespace DSIES.Info.Database
{
    class UserDBManager
    {

        enum LoginState
        {
            NOTEXIST,
            WRONGPASSWORD,
            NEEDPASSWORD,
            SUCCESS
        }

        public UserDBManager()
            {

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
                if (!File.Exists(dbPath)
                    && !CreateDB(dbPath,
                    FileManager.GetPath("database", "create_sql")))
                    return false;

                connection = new SQLiteConnection("Data Source="
                    + dbPath + ";Version=3;");

                return true;
            }
            public bool CreateDB(string dbPath, string sqlPath)
            {
                SQLiteConnection.CreateFile(dbPath);
                connection = new SQLiteConnection("Data Source="
                    + dbPath + ";Version=3;");

                string sql = File.ReadAllText(sqlPath);

                return ExecuteNonQuery(sql);
            }

            public Tuple<LoginState, User> ValidateUser(string telphone,
                string password, UserGroup group)
            {
                LoginState state;
                User user = GetUser(telphone, group);

                if (user == null)
                    state = LoginState.NOTEXIST;
                else if (Encryptor.GetMD5(password).Equals(user.Password))
                {
                    state = LoginState.SUCCESS;
                    UpdateLastDate(telphone, group);
                }
                else
                    state = LoginState.WRONGPASSWORD;

                return new Tuple<LoginState, User>(state, user);
            }

            private bool UpdateLastDate(string telphone, UserGroup group)
            {
                string sql = "update " + group
                    + " set lastDate = (datetime('now','localtime'))"
                    + " where telphone = '" + telphone + "'";

                return ExecuteNonQuery(sql);
            }

            public User GetUser(string telphone, UserGroup group)
            {
                string sql = "select * from " + group
                    + " where telphone = '" + telphone + "'";

                List<User> users = GetUsers(sql, group);

                if (users != null && users.Count != 0)
                    return users[0];
                else
                    return null;
            }

            public List<User> GetAllRegulars()
            {
                string sql = "select * from " + UserGroup.REGULAR;
                List<User> users = GetUsers(sql, UserGroup.REGULAR);

                return users;
            }

            public List<User> GetAllGrantedUsers(string telphone)
            {
                string sql = "select * from " + UserGroup.ADMIN
                    + " where telphone = " + telphone;
                List<User> users = GetUsers(sql, UserGroup.ADMIN);

                return users;
            }

            private List<User> GetUsers(string sql, UserGroup group)
            {
                OpenConnection();
                SQLiteDataReader reader = ExecuteQuery(sql);

                if (reader != null && !reader.HasRows)
                {
                    reader.Close();
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
                            (user as Admin).Telphone = reader[" Telphone"] as string;
                            break;
                        case UserGroup.REGULAR:
                            user = new Regular();
                            Regular regular = user as Regular;
                            regular.Group = UserGroup.REGULAR;
                            regular.Gender = reader["gender"] as string;
                            regular.DeepSight_left = reader["deepSight_left"] as string;
                            regular.DeepSight_right = reader["deepSight_right"] as string;
                            regular.Sight_left = reader["sight_left"] as string;
                            regular.Sight_right = reader["sight_right"] as string;
                            regular.Reagency = reader["reagency"] as string;
                            regular.Age = reader["age"] as string;
                            regular.DriAge = reader["driage"] as string;
                            regular.Career = reader["career"] as string;
                            regular.Score = reader["score"] as string;
                            regular.Score1 = reader["score1"] as string;
                            regular.Score2 = reader["score2"] as string;
                            regular.Grade1 = reader["grade1"] as string;
                            regular.Grade2 = reader["grade2"] as string;
                            regular.Breaktime = reader["breaktime"] as string; ;

                            break;
                        default:
                            user = null;
                            break;
                    }

                    user.Name = reader["name"] as string;
                    user.Password = reader["password"] as string;
                    //  user.RegDate = (DateTime)reader["regDate"];
                    // user.LastDate = (DateTime)reader["lastDate"];

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
                            + " (name, password, telphone) values ('"
                            + admin.Name + "', '"
                            + Encryptor.GetMD5(admin.Password) + "', '"

                            + admin.Password + "') ";
                        break;
                    case UserGroup.REGULAR:
                        Regular regular = user as Regular;
                        sql = "insert into " + regular.Group
                            + " (name, telphone, password, gender, "
                            + "age, driAge, career,deepSight,sight,rengency,breaktime) values ('"
                            + regular.Name + "', '"
                            + regular.Telphone + "', '"
                            + Encryptor.GetMD5(regular.Password) + "', '"
                            + regular.Gender + "',"
                            + regular.Age + ", "
                            + regular.DriAge + ", '"
                            + regular.Career + "', '"
                            + regular.Score + "', '"
                            + regular.Score1 + "', '"
                            + regular.Score2 + "', '"
                            + regular.Sight_left + "', '"
                            + regular.Sight_right + "', '"
                            + regular.DeepSight_right + "', '"
                            + regular.DeepSight_left + "', '"
                            + regular.Reagency + "', '"
                            + regular.Breaktime + "')'"
                            + regular.Grade1 + "', '"
                            + regular.Grade2 + "', '"
                           ;
                        break;
                    default:
                        return false;
                }

                return ExecuteNonQuery(sql);
            }

            public bool UpdateUserInfo(User user)
            {
                string sql;
                switch (user.Group)
                {
                    case UserGroup.ADMIN:
                        Admin admin = user as Admin;
                        sql = "update " + admin.Group + " set "
                            + "name = '" + admin.Name + "' "
                            + "telphone =" + admin.Telphone + "'"
                            + "where name = " + admin.Name;
                        break;
                    case UserGroup.REGULAR:
                        Regular regular = user as Regular;
                        sql = "update " + regular.Group + " set "
                            + "name = " + regular.Name + "', "
                            + "telphone = " + regular.Telphone + "', "
                            + "age = " + regular.Age + ", "
                            + "gender = '" + regular.Gender + "', "
                            + "driAge = " + regular.DriAge + ", "
                            + "career = '" + regular.Career + "',"
                            + "deepsight_right = " + regular.DeepSight_right + ", "
                            + "deepsight_left = " + regular.DeepSight_left + ", "
                            + "sight_right = " + regular.Sight_right + ", "
                            + "sight_left = " + regular.Sight_left + ", "
                            + "score=" + regular.Score + ", "
                            + "score1=" + regular.Score1 + ", "
                            + "score2=" + regular.Score2 + ", "
                            + "grade1=" + regular.Grade1 + ", "
                            + "grade2=" + regular.Grade2 + ", "
                            + "reagency = " + regular.Reagency + "', "
                            + "breaktime = '" + regular.Breaktime + "' "
                            + "where name = " + regular.Name;
                        break;
                    default:
                        return false;
                }

                return ExecuteNonQuery(sql);
            }

            public bool UpdatePassword(string name, string password, UserGroup group)
            {
                string sql = "update " + group
                    + " set password = '" + Encryptor.GetMD5(password)
                    + "' where name = " + name;

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


