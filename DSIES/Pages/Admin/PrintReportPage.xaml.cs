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
            inquiry_user_Button.Visibility = System.Windows.Visibility.Hidden;
            inquiry_user_Button_copy.Visibility = System.Windows.Visibility.Visible;
        }

        private void update_user_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateUserPage page = new UpdateUserPage();
            PageList.Main.setPage(PageList.UpdateUser);
            update_user_Button.Visibility = System.Windows.Visibility.Hidden;
            update_user_Button_copy.Visibility = System.Windows.Visibility.Visible;
        }
        private void print_report_Button_Click(object sender, RoutedEventArgs e)
        {
            PrintReportPage page = new PrintReportPage();
            PageList.Main.setPage(PageList.PrintReport);
            print_report_Button.Visibility = System.Windows.Visibility.Hidden;
            print_report_Button_copy.Visibility = System.Windows.Visibility.Visible;
        }
        private void update_admin_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateAdminPage page = new UpdateAdminPage();
            PageList.Main.setPage(PageList.UpdateAdmin);
            update_admin_Button.Visibility = System.Windows.Visibility.Hidden;
            update_admin_Button_copy.Visibility = System.Windows.Visibility.Visible;
        }
        private void quit_admin_Button_Click(object sender, RoutedEventArgs e)
        {    
            var  dr=CustomMessageBox.Show("温馨提示：", "您确定要退出管理员系统吗？");
            if (dr == true)
            {
                PageList.Main.setPage(PageList.Login);
            }
            else
            { 
            }
        }


    }
}
