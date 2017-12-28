using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Printing;
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

namespace DSIES.Pages.Admin
{
    /// <summary>
    /// PrintReportPage.xaml 的交互逻辑
    /// </summary>
    public partial class PrintReportPage : Page
    {
        public PrintReportPage()
        {
            InitializeComponent();
        }
        private void inquiry_user_Button_Click(object sender, RoutedEventArgs e)
        {
            InquiryUserPage page = new InquiryUserPage();
            PageList.Main.setPage(PageList.InquiryUser);
      }

        private void update_user_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateUserPage page = new UpdateUserPage();
            PageList.Main.setPage(PageList.UpdateUser);
      }
        private void print_report_Button_Click(object sender, RoutedEventArgs e)
        {
            PrintReportPage page = new PrintReportPage();
            PageList.Main.setPage(PageList.PrintReport);
       }
 
        private void quit_admin_Button_Click(object sender, RoutedEventArgs e)
        {
            quit_admin_Button.Visibility = System.Windows.Visibility.Hidden;
            quit_admin_Button_copy.Visibility = System.Windows.Visibility.Visible;
            var dr = CustomMessageBox.Show("温馨提示：", "您确定要退出管理员系统吗？");
            if (dr == true)
            {
                PageList.Main.setPage(PageList.Login);
            }
            else
            {
                quit_admin_Button_copy.Visibility = System.Windows.Visibility.Hidden;
                quit_admin_Button.Visibility = System.Windows.Visibility.Visible;
          
            }
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            string path = "../../../用户报表/" + telephonename.Text.ToString() + ".jpg";
            if (File.Exists(@path))
            {
                image.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/...//...//...//用户报表/" + telephonename.Text.ToString() + ".jpg", UriKind.Absolute));


                image.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                CustomMessageBox.Show("温馨提示：", "The User Does Not Exist !");
            }
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(printArea, "Print Test");
            }
        }
    }
}
