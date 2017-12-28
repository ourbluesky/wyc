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
using DSIES.Info.Database;
using DSIES.UDP;

namespace DSIES.Pages.Admin
{
    /// <summary>
    /// InquiryUserPage.xaml 的交互逻辑
    /// </summary>
    /// 

   
    public partial class InquiryUserPage : Page
    {
        private UserDBManager dbManger;
        public InquiryUserPage()
        {
            InitializeComponent();
            InitDBManger();

        }
        private void InitDBManger()
        {
            dbManger = new UserDBManager();
            dbManger.ConnectDB(FileManager.GetPath("database", "db"));
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

        private void select_Click(object sender, RoutedEventArgs e)
        {

            Regular user = (Regular)dbManger.GetUser(telphone.Text, UserGroup.REGULAR);
            if (user == null)
            {
                CustomMessageBox.Show("温馨提示：", "Wrong Message!"); //错误信息提示
            }
            else
            {//信息显示
                text.Text = user.Telephone + "', '"
                                + user.Name + "', '"
                                + user.Gender + "','"
                                + user.Age + "', '"
                                + user.DriAge + "', '"
                                + user.Career + "', '"
                                + user.Accident_times + "', '"
                                + user.Sight_left + "', '"
                                + user.Sight_right + "', '"
                                + user.DeepSight_left + "', '"
                                + user.DeepSight_right + "', '"
                                + user.Reagency + "','"
                                + user.Grade + "', '"
                                + user.Grade1 + "', '"
                                + user.Grade2 + "', '"
                                + user.Totalscore_frist + "', '"
                                + user.Totalscore_final + "', '"
                                + user.Credit + "') "
                                ;
            }

        }
    }
}
