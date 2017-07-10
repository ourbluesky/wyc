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

namespace DSIES.Pages
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : Page
    {

        Regular regular = new Regular();
        internal Regular Regular
        {
            get { return regular; }
            set { regular = value; }
        }
        public LoginPage()
        {
            InitializeComponent();


        }
        private void Read_Register_Data()//注册信息，注册直接进入
        {

            Regular.Name = textBlock_name.Text;
            Regular.Gender = textBlock_gender.Text;
            Regular.Age = textBlock_age.Text;
            Regular.DriAge = textBlock_driage.Text;
            Regular.Accident_times= textBlock_accident_times.Text;
            Regular.Career= textBlock_career.Text;
            Regular.Telephone = textBlock_telephone.Text;
            Regular.Sight_left =textBlock_Left_Sight.Text;
            Regular.Sight_right = textBlock_Right_Sight.Text;
            Regular.DeepSight_left =textBlock_Left_DeepSight.Text;
            Regular.DeepSight_right= textBlock_Right_DeepSight.Text;
            Regular.Reagency =textBlock_React.Text;
            Regular.Password = textBlock_password_set.Text;
        }
        private void Login_Button_Click(object sender, RoutedEventArgs e)//进入注册界面
        {
            welcome.Visibility = System.Windows.Visibility.Hidden;
            Login.Visibility = System.Windows.Visibility.Visible;
        }
        private void Login_back_Button_Click(object sender, RoutedEventArgs e) //从注册界面返回欢迎界面
        {
            welcome.Visibility = System.Windows.Visibility.Visible;
            Login.Visibility = System.Windows.Visibility.Hidden;
        }
        private void Login_in_Button_Click(object sender, RoutedEventArgs e)//登录信息写完点下一步
        {
            //如果用户名手机号已经存在，说明该用户已存在，可直接登录
            PageList.Main.setPage(PageList.Questionandgame);
            //用户手机号不存在，提示请先注册
        }
        private void Register_Button_Click(object sender, RoutedEventArgs e)//返回欢迎界面
        {
            Register.Visibility = System.Windows.Visibility.Visible;
            welcome.Visibility = System.Windows.Visibility.Hidden;
        }
        private void Register_back_Button_Click(object sender, RoutedEventArgs e)//从注册界面返回欢迎界面
        {
            Register.Visibility = System.Windows.Visibility.Hidden;
            welcome.Visibility = System.Windows.Visibility.Visible;
        }
        private void Register_in_Button_Click(object sender, RoutedEventArgs e) //从注册界面进行到下一步
        {
            Read_Register_Data();
            PageList.SceneSelect = new SceneSelectPage();
            PageList.Main.setPage(PageList.SceneSelect);//.Questionandgame);//
        }
    }
}
