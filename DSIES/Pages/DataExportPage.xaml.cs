﻿using System;
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
            name_info.DataContext =  PageList.Main.Regular.Name;
            gender_info.DataContext =  PageList.Main.Regular.Gender;
            age_info.DataContext = PageList.Main.Regular.Age;
            DrivingYears_info.DataContext = PageList.Main.Regular.DriAge;
            weizhang_info.DataContext= PageList.Main.Regular.Accident_times;
            job_info.DataContext =PageList.Main.Regular.Career ;
            tele_info.DataContext= PageList.Main.Regular .Telphone ;
            leftsight.DataContext= PageList.Main.Regular .Sight_left;
            rightsight.DataContext= PageList.Main.Regular .Sight_right ;
            leftdeepsight.DataContext =PageList.Main.Regular .DeepSight_left;
            rightdeepsight.DataContext= PageList.Main.Regular .DeepSight_right;
            reaction.DataContext= PageList.Main.Regular .Reagency;

        }
    }
}
