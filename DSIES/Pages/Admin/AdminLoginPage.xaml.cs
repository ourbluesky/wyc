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
using System.Windows.Shapes;

namespace DSIES.Pages.Admin
{
    /// <summary>
    /// AdminLoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class AdminLoginPage : Page
    {
        public AdminLoginPage()
        {
            InitializeComponent();
            Read_AdminLogin_Data();
        }
        private void Read_AdminLogin_Data()
        {
            PageList.Main.ADMINLOGINDATA.grantUsername = textBlock_grantusername.Text;
            PageList.Main.ADMINLOGINDATA.grantPassword = textBlock_grantpassword.Text;
        }
        private void In_Button_Click(object sender, RoutedEventArgs e)
        {
          //  if （textBlock_grantusername="dsiesadmin"&&textBlock_grantpassword="dsies"）
        //｛ PageList.Main.setPage(PageList.);｝
          // else{CustomMessageBox.Show （"温馨提示","管理员用户名或密码错误！");}
        }

    }
}


