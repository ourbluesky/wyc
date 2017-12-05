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
using DSIES.Class.Model;
using DSIES.UDP;


namespace DSIES.Pages.Admin
{
    /// <summary>
    /// UpdateUserPage.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateUserPage : Page
    {
        public UpdateUserPage()
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

        private void InfoEditButton_Click(object sender, RoutedEventArgs e)
        {
            InfoEditButton.Visibility = System.Windows.Visibility.Hidden;
            InfoSaveButton.Visibility = System.Windows.Visibility.Visible;
            SetEditable();
        }

        private void InfoSaveButton_Click(object sender, RoutedEventArgs e)
        {
            InfoEditButton.Visibility = System.Windows.Visibility.Visible;
            InfoSaveButton.Visibility = System.Windows.Visibility.Hidden;
            SetUneditable();
            UpdateInfo();
        }

        public void SetPage(Regular regular)
        {
            iName.Text = regular.Name;
            iTelephone.Text = regular.Telephone;
            iMale.IsChecked = regular.Gender == "Male" ? true : false;
            iAge.Text = regular.Age;
            iDriAge.Text = regular.DriAge;
            iCareer.Text = regular.Career;
            iAccident_times.Text = regular.Accident_times;
            iSight_left.Text = regular.Sight_left;
            iSight_right.Text = regular.Sight_right;
            iDeepsight_left.Text = regular.DeepSight_left;
            iDeepsight_right.Text = regular.DeepSight_right;
            iReaction.Text = regular.Reagency;

            SetUneditable();
        }

        private void SetEditable()
        {
            iTelephone.IsEnabled = true;
            iName.IsEnabled = true;
            iMale.IsEnabled = true;
            iFemale.IsEnabled = true;
            iAge.IsEnabled = true;
            iDriAge.IsEnabled = true;
            iCareer.IsEnabled = true;
            iAccident_times.IsEnabled = true;
            iSight_left.IsEnabled = true;
            iSight_right.IsEnabled = true;
            iDeepsight_left.IsEnabled = true;
            iDeepsight_right.IsEnabled = true;
            iReaction.IsEnabled = true;
        }

        private void SetUneditable()
        {
            iTelephone.IsEnabled = false;
            iName.IsEnabled = false;
            iMale.IsEnabled = false;
            iFemale.IsEnabled = false;
            iAge.IsEnabled = false;
            iDriAge.IsEnabled = false;
            iCareer.IsEnabled = false;
            iAccident_times.IsEnabled = false;
            iSight_left.IsEnabled = false;
            iSight_right.IsEnabled = false;
            iDeepsight_left.IsEnabled = false;
            iDeepsight_right.IsEnabled = false;
            iReaction.IsEnabled = false;
        }

        private void UpdateInfo()
        {
            Regular regular = new Regular();
            //TODO
            CU.MG_User.UpdateUser(regular);//更新信息，一开始没用到
        }

        private void ChangePassword()
        {
            CU.MG_User.UpdatePassword(OldPassword.Password, NewPassword.Password);
        }

        private void SavePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (OldPassword.Password != null && NewPassword.Password != null)
            { ChangePassword(); }
            return;
        }
    }
}
