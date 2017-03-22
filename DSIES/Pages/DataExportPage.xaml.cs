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
using DSIES;

namespace DSIES.Pages
{
    /// <summary>
    /// DataExportPage.xaml 的交互逻辑
    /// </summary>
    public partial class DataExportPage : Page
    {
        public DataExportPage()
        {
            InitializeComponent();
            printData();
            
           //  name_info.DataContext=
        }

        public void printData()
        {  
            name_info.DataContext = PageList.Main.LOGINDATA.Name;
            gender_info.DataContext = PageList.Main.LOGINDATA.Sex;
            age_info.DataContext = PageList.Main.LOGINDATA.Age;
            DrivingYears_info.DataContext = PageList.Main.LOGINDATA.Year;
            weizhang_info.DataContext= PageList.Main.LOGINDATA.Times;
            job_info.DataContext =PageList.Main.LOGINDATA.Job;
            tele_info.DataContext= PageList.Main.LOGINDATA.Phone;
            leftsight.DataContext= PageList.Main.LOGINDATA.Left_Sight;
            rightsight.DataContext= PageList.Main.LOGINDATA.Right_Sight;
            leftdeepsight.DataContext =PageList.Main.LOGINDATA.Left_Deep_Sight;
            rightdeepsight.DataContext= PageList.Main.LOGINDATA.Right_Deep_Sight;
            reaction.DataContext= PageList.Main.LOGINDATA.Reation;

        }
    }
}
