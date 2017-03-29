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
        public LoginPage()
        {
            
            InitializeComponent();
           
        }
        private void Read_Login_Data()
        {
            PageList.Main.Regular.Name = textBlock_name.Text;
            PageList.Main.Regular.Gender = textBlock_gender.Text;
            PageList.Main.Regular.Age = textBlock_age.Text;
            PageList.Main.Regular.DriAge = textBlock_driage.Text;
            PageList.Main.Regular.Accident_times= textBlock_accident_times.Text;
            PageList.Main.Regular.Career= textBlock_career.Text;
            PageList.Main.Regular.Telphone = textBlock_telphone.Text;
            PageList.Main.Regular.Sight_left =textBlock_Left_Sight.Text;
            PageList.Main.Regular.Sight_right = textBlock_Right_Sight.Text;
            PageList.Main.Regular.DeepSight_left =textBlock_Left_DeepSight.Text;
            PageList.Main.Regular.DeepSight_right= textBlock_Right_DeepSight.Text;
            PageList.Main.Regular.Reagency =textBlock_React.Text;
            PageList.Main.Regular.Password = textBlock_password_set.Text;
        }
        private void ToIn_Click(object sender, RoutedEventArgs e)
        {
            welcome.Visibility = System.Windows.Visibility.Hidden;
            In.Visibility = System.Windows.Visibility.Visible;
        }
        private void In_back_Button_Click(object sender, RoutedEventArgs e)
        {
            welcome.Visibility = System.Windows.Visibility.Visible;
            In.Visibility = System.Windows.Visibility.Hidden;
        }
        private void In_Button_Click(object sender, RoutedEventArgs e)
        {
            //App.Current.Shutdown();//change
            PageList.Main.setPage(PageList.Questionandgame);
        }
        private void ToLogin_Click(object sender, RoutedEventArgs e)
        {
            Login.Visibility = System.Windows.Visibility.Visible;
            welcome.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Login_back_Button_Click(object sender, RoutedEventArgs e)
        {
            Login.Visibility = System.Windows.Visibility.Hidden;
            welcome.Visibility = System.Windows.Visibility.Visible;
        }
        private void login_in_Button_Click(object sender, RoutedEventArgs e)
        {
            //  App.Current.Shutdown(); //改
            Read_Login_Data();
            PageList.Main.setPage(PageList.SceneSelect);//qestionandgame别忘改
        }
    }
}
