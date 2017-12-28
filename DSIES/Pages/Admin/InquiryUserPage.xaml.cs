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
            List<Regular> user= new List<Regular>();
            if (name.Text != "")
            {
                user = dbManger.GetAllGrantedUsers("name", name.Text);
            }
            else if (telphone.Text != "")
            {
                user = dbManger.GetAllGrantedUsers("telephone", telphone.Text);
            }
            else if (sex.Text != "")
            {
                user = dbManger.GetAllGrantedUsers("gender", sex.Text);
            }
            else if (career.Text != "")
            {
                user = dbManger.GetAllGrantedUsers("career", career.Text);
            }



            if (user == null)
            {
                MessageBox.Show("wrong message!");//错误信息提示
            }
            else
            {//信息显示
                for (int i = 0 ; i < user.Count;i++)
                text.Text = "'" + user[i].Telephone + "', '"
                                + user[i].Name + "', '"
                                + user[i].Gender + "','"
                                + user[i].Age + "', '"
                                + user[i].DriAge + "', '"
                                + user[i].Career + "', '"
                                + user[i].Accident_times + "', '"
                                + user[i].Sight_left + "', '"
                                + user[i].Sight_right + "', '"
                                + user[i].DeepSight_left + "', '"
                                + user[i].DeepSight_right + "', '"
                                + user[i].Reagency + "','"
                                + user[i].Grade + "', '"
                                + user[i].Grade1 + "', '"
                                + user[i].Grade2 + "', '"
                                + user[i].Totalscore_frist + "', '"
                                + user[i].Totalscore_final + "', '"
                                + user[i].Credit + "'"
                                ;
            }

        }
    }
}
