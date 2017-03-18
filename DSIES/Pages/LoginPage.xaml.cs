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
            PageList.Main.setPage(PageList.Questionandgame);
        }
    }
}
