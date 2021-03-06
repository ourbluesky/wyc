﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.Info.Database;
using DSIES.UDP;
using DSIES.Class.Model;

namespace DSIES.Class.Control
{
    public enum RegisterState
    {
        USEREXIST,
        SUCCESS,
        DBFAILED,//dbfiled
        VALIDATED,//数据校验完成后发生
        TELEPHONEEMPTY,
        PASSWORDEMPTY,
        NAMEEMPTY,
        GENDEREMPTY,
        AGEEMPTY,
        DRIAGEEMPTY,
        CAREEREMPTY,
        ACCIDENTTIMESEMPTY,
        SIGHTLEFTEMPTY,
        SIGHTRIGHTEMPTY,
        DEEPSIGHTLEFTEMPTY,
        DEEPSIGHTRIGHTEMPTY,
        REAGENCYEMPTY,
        GRADEEMPTY,
        GRADE1EMPTY,
        GRADE2EMPTY,
        TOTALSCORE_FIRSTEMPTY,
        TOTALSCORE_FINALEMPTY,
        CREDITEMPTY,
        TIMEMPTY

        //不知道加不加测试得分
    }

    class UserManager
    {
        public UserManager()
        {
            InitDBManger();
        }

        private void InitDBManger()
        {
            dbManger = new UserDBManager();
            dbManger.ConnectDB(FileManager.GetPath("database", "db"));
        }

        private User user;
        private User registerUser;
        private UserDBManager dbManger;
        private RegisterState currentState;

        public User User { get { return user; } }

        public LoginState Login(string telephone, string password, UserGroup group)
        {
            if (group == UserGroup.ADMIN && password.Equals(""))
                return LoginState.NEEDPASSWORD;

            Tuple<LoginState, User> result = dbManger.ValidateUser(telephone, password, group);
            if (result.Item1 == LoginState.SUCCESS)
            {
                user = result.Item2;
            }

            return result.Item1;
        }

        public void RegisterStart(UserGroup group)
        {
            currentState = RegisterState.VALIDATED;
            switch (group)
            {
                case UserGroup.ADMIN:
                    registerUser = new Admin();
                    registerUser.Group = UserGroup.ADMIN;
                    (registerUser as Admin).GrantUserName = user.Name;
                    break;
                case UserGroup.REGULAR:
                    registerUser = new Regular();
                    registerUser.Group = UserGroup.REGULAR;
                    break;
                default:
                    break;
            }
        }

        public RegisterState RegisterAdd(UserVariable variable, string value)      //将信息写入数据库
        {
            switch (variable)
            {
                case UserVariable.Telephone:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.TELEPHONEEMPTY);
                        return RegisterState.TELEPHONEEMPTY;
                    }
                    if (dbManger.GetUser(value, registerUser.Group) != null)
                    {
                        UpdateRegisterState(RegisterState.USEREXIST);
                        return RegisterState.USEREXIST;
                    }
                    registerUser.Telephone = value;
                    break;

                case UserVariable.Password:
                    if (registerUser.Group== UserGroup.ADMIN && value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.PASSWORDEMPTY);
                        return RegisterState.PASSWORDEMPTY;
                    }
                    registerUser.Password = value;
                    break;

                case UserVariable.Name:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.NAMEEMPTY);
                        return RegisterState.NAMEEMPTY;
                    }
                    (registerUser as Regular).Name = value;
                    break;

                case UserVariable.Gender:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.GENDEREMPTY);
                        return RegisterState.GENDEREMPTY;
                    }
                    (registerUser as Regular).Gender = value;
                    break;

                case UserVariable.Age:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.AGEEMPTY);
                        return RegisterState.AGEEMPTY;
                    }
                    (registerUser as Regular).Age = value;
                    break;

                case UserVariable.DriAge:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.DRIAGEEMPTY);
                        return RegisterState.DRIAGEEMPTY;
                    }
                    (registerUser as Regular).DriAge = value;

                    break;
                case UserVariable.Career:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.CAREEREMPTY);
                        return RegisterState.CAREEREMPTY;
                    }
                    (registerUser as Regular).Career = value;
                    break;

                case UserVariable.Accident_times:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.ACCIDENTTIMESEMPTY);
                        return RegisterState.ACCIDENTTIMESEMPTY;
                    }
                    (registerUser as Regular).Accident_times = value;
                    break;

                case UserVariable.Sight_left:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.SIGHTLEFTEMPTY);
                        return RegisterState.SIGHTLEFTEMPTY;
                    }
                    (registerUser as Regular).Sight_left = value;
                    break;

                case UserVariable.Sight_right:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.SIGHTLEFTEMPTY);
                        return RegisterState.SIGHTLEFTEMPTY;
                    }
                    (registerUser as Regular).Sight_right = value;
                    break;

                case UserVariable.Deepsight_left:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.DEEPSIGHTLEFTEMPTY);
                        return RegisterState.DEEPSIGHTLEFTEMPTY;
                    }
                    (registerUser as Regular).DeepSight_left = value;
                    break;

                case UserVariable.DeepSight_right:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.DEEPSIGHTRIGHTEMPTY);
                        return RegisterState.DEEPSIGHTRIGHTEMPTY;
                    }
                    (registerUser as Regular).DeepSight_right = value;
                    break;

                case UserVariable.Reagency:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.REAGENCYEMPTY);
                        return RegisterState.REAGENCYEMPTY;
                    }
                    (registerUser as Regular).Reagency = value;
                    break;

                case UserVariable.Grade:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.GRADEEMPTY);
                        return RegisterState.GRADEEMPTY;
                    }
                    (registerUser as Regular).Grade = value;
                    break;

                case UserVariable.Grade1:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.GRADE1EMPTY);
                        return RegisterState.GRADE1EMPTY;
                    }
                    (registerUser as Regular).Grade1 = value;
                    break;

                case UserVariable.Grade2:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.GRADE2EMPTY);
                        return RegisterState.GRADE2EMPTY;
                    }
                    (registerUser as Regular).Grade2 = value;
                    break;

                case UserVariable.Totalscore_frist:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.TOTALSCORE_FIRSTEMPTY);
                        return RegisterState.TOTALSCORE_FIRSTEMPTY;
                    }
                    (registerUser as Regular).Totalscore_frist = value;
                    break;

                case UserVariable.Totalscore_final:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.TOTALSCORE_FINALEMPTY);
                        return RegisterState.TOTALSCORE_FINALEMPTY;
                    }
                    (registerUser as Regular).Totalscore_final = value;
                    break;

                case UserVariable.Credit:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.CREDITEMPTY);
                        return RegisterState.CREDITEMPTY;
                    }
                    (registerUser as Regular).Credit = value;
                    break;

                case UserVariable.Time:
                    if (value.Equals(""))
                    {
                        UpdateRegisterState(RegisterState.TIMEMPTY);
                        return RegisterState.TIMEMPTY;
                    }
                    registerUser.Time = value;
                    break;
                default:
                    break;
            }
            return RegisterState.VALIDATED;
        }



        private void UpdateRegisterState(RegisterState state)
        {
            if (currentState == RegisterState.VALIDATED)
                currentState = state;
        }

        public RegisterState RegisterEnd()
        {
            if (currentState == RegisterState.VALIDATED)
            {
                if (dbManger.AddUser(registerUser))
                    currentState = RegisterState.SUCCESS;
                else
                    currentState = RegisterState.DBFAILED;
            }
            registerUser = null;
            return currentState;
        }

        public void LogOut()
        {
            user = null;
        }

        //这个有什么用// regularInfo//CU.MG_User.UpdateUser(regular);
        public bool UpdateUser(User user)
        {
            return dbManger.UpdateUserInfo(user);
        }

        public bool UpdatePassword(string oldP, string newP)
        {
            if (Encryptor.GetMD5(oldP) == user.Password)
                return dbManger.UpdatePassword(user.Name, newP, user.Group);
            else
                return false;
        }

    }
}

