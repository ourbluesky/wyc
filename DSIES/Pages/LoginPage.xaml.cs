using DSIES.Class.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DSIES.UDP;
using DSIES.Info.Database;

namespace DSIES.Pages
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : Page
    {
        private UserDBManager dbManger;
        Regular regular = new Regular();
        internal Regular Regular
        {
            get { return regular; }
            set { regular = value; }
        }
        public LoginPage()
        {
            InitializeComponent();
            dbManger = new UserDBManager();
            dbManger.ConnectDB(FileManager.GetPath("database", "db"));

       }
        private void Read_Register_Data()//注册信息，注册直接进入
        {
            regular.Name = textBlock_name.Text;
            regular.Gender = textBlock_gender.Text;
            regular.Age = textBlock_age.Text;
            regular.DriAge = textBlock_driage.Text;
            regular.Accident_times = textBlock_accident_times.Text;
            regular.Career = textBlock_career.Text;
            regular.Telephone = textBlock_telephone.Text;
            regular.Sight_left = textBlock_Left_Sight.Text;
            regular.Sight_right = textBlock_Right_Sight.Text;
            regular.DeepSight_left = textBlock_Left_DeepSight.Text;
            regular.DeepSight_right = textBlock_Right_DeepSight.Text;
            regular.Reagency = textBlock_React.Text;
            regular.Password = textBlock_password_set.Text;
        }

        private void dbRegister()
        {
            CU.MG_User.RegisterStart(UserGroup.REGULAR);
            CU.MG_User.RegisterAdd(UserVariable.Name,textBlock_name.Text);
            CU.MG_User.RegisterAdd(UserVariable.Gender ,textBlock_gender.Text);
            CU.MG_User.RegisterAdd(UserVariable.Age , textBlock_age.Text);
            CU.MG_User.RegisterAdd(UserVariable.DriAge , textBlock_driage.Text);
            CU.MG_User.RegisterAdd(UserVariable.Accident_times , textBlock_accident_times.Text);
            CU.MG_User.RegisterAdd(UserVariable.Career , textBlock_career.Text);
            CU.MG_User.RegisterAdd(UserVariable.Telephone , textBlock_telephone.Text);
            CU.MG_User.RegisterAdd(UserVariable.Sight_left , textBlock_Left_Sight.Text);
            CU.MG_User.RegisterAdd(UserVariable.Sight_right , textBlock_Right_Sight.Text);
            CU.MG_User.RegisterAdd(UserVariable.Deepsight_left , textBlock_Left_DeepSight.Text);
            CU.MG_User.RegisterAdd(UserVariable.DeepSight_right , textBlock_Right_DeepSight.Text);
            CU.MG_User.RegisterAdd(UserVariable.Reagency , textBlock_React.Text);
            CU.MG_User.RegisterAdd(UserVariable.Password , textBlock_password_set.Text);          
        }
        private void Login_Button_Click(object sender, RoutedEventArgs e)//进入登陆界面
        {
            welcome.Visibility = System.Windows.Visibility.Hidden;
            Login.Visibility = System.Windows.Visibility.Visible;
        }
        private void Login_back_Button_Click(object sender, RoutedEventArgs e) //从登陆界面返回欢迎界面
        {
            welcome.Visibility = System.Windows.Visibility.Visible;
            Login.Visibility = System.Windows.Visibility.Hidden;
            textBlock_phone.Text = "";
            textBlock_password.Password = "";
        }
        private void Login_in_Button_Click(object sender, RoutedEventArgs e)//登录信息写完点下一步
        {
            Regular user = (Regular)dbManger.GetUser(textBlock_phone.Text, UserGroup.REGULAR);
            //如果用户名手机号已经存在，说明该用户已存在，可直接登录
            if (user != null)
            {
                if (Encryptor.GetMD5(textBlock_password.Password) == user.Password)
                    PageList.Main.setPage(PageList.Questionandgame);
                else
                    CustomMessageBox.Show("温馨提示：", "Password Error!"); 
            }
            else//用户手机号不存在，提示请先注册
            {
                CustomMessageBox.Show("温馨提示：", "Please Sign In !");
                Login.Visibility = System.Windows.Visibility.Hidden;
                Register.Visibility = System.Windows.Visibility.Visible;
                textBlock_phone.Text = "";
                textBlock_password.Password = "";
            }
        }
        private void Register_Button_Click(object sender, RoutedEventArgs e)//进入注册界面
        {
            Register.Visibility = System.Windows.Visibility.Visible;
            welcome.Visibility = System.Windows.Visibility.Hidden;
        }
        private void Register_back_Button_Click(object sender, RoutedEventArgs e)//从注册界面返回欢迎界面
        {
            Register.Visibility = System.Windows.Visibility.Hidden;
            welcome.Visibility = System.Windows.Visibility.Visible;
            textBlock_name.Text="";
            textBlock_gender.Text="";
            textBlock_age.Text="";
            textBlock_driage.Text="";
            textBlock_accident_times.Text = "";
            textBlock_career.Text = "";
            textBlock_telephone.Text = "";
            textBlock_Left_Sight.Text = "";
            textBlock_Right_Sight.Text = "";
            textBlock_Left_DeepSight.Text = "";
            textBlock_Right_DeepSight.Text = "";
            textBlock_React.Text = "";
            textBlock_password_set.Text = "";
        }
        private void Register_in_Button_Click(object sender, RoutedEventArgs e) //从注册界面进行到下一步
        {
            Read_Register_Data();
            dbRegister();
            PageList.SceneSelect = new SceneSelectPage();
            PageList.Main.setPage(PageList.Questionandgame);//.SceneSelect);//
        }
    }
}
