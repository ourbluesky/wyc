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
using DSIES.Pages;
using DSIES.Class.Control;

namespace DSIES.Pages
{
    /// <summary>
    /// EducationSelectPage.xaml 的交互逻辑
    /// </summary>
    public partial class EducationSelectPage : Page
    {

        //EducationClass education = new EducationClass();


        string path1 = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Video\\超速.mp4", path2 = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Video\\变道.mp4", path3 = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Video\\超车.mp4", path4 = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Video\\交叉口.mp4", path5 = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Video\\分心.mp4";


        public EducationSelectPage()
        {
            InitializeComponent();
            //x1.DataContext = sceneselectData.score.Speed_Score1+ sceneselectData.score.Speed_Score2+sceneselectData.score.Speed_Score3+ sceneselectData.score.Speed_Score4+ sceneselectData.score.Speed_Score5;
            //x2.DataContext = sceneselectData.score.Line_Score1+sceneselectData.score.Line_Score2+ sceneselectData.score.Line_Score3+ sceneselectData.score.Line_Score4;
            //x3.DataContext = sceneselectData.score.Overtake_Score1+ sceneselectData.score.Overtake_Score2+ sceneselectData.score.Overtake_Score3;
            //x4.DataContext = sceneselectData.score.Lighting_Score;
            //x5.DataContext = sceneselectData.score.Distrationg_Score;

            
            if (sceneselectData.education.Speeding == true)
            {
                Speeding_button.Visibility = System.Windows.Visibility.Visible;
                Speeding_button_Copy.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                Speeding_button.Visibility = System.Windows.Visibility.Hidden;
                Speeding_button_Copy.Visibility = System.Windows.Visibility.Visible;
            }
            if (sceneselectData.education.Line == true)
            {
                Line_button.Visibility = System.Windows.Visibility.Visible;
                Line_button_Copy.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                Line_button.Visibility = System.Windows.Visibility.Hidden;
                Line_button_Copy.Visibility = System.Windows.Visibility.Visible;
            }
            if (sceneselectData.education.Overtake == true)
            {
                Overtake_button.Visibility = System.Windows.Visibility.Visible;
                Overtake_button_Copy.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                Overtake_button.Visibility = System.Windows.Visibility.Hidden;
                Overtake_button_Copy.Visibility = System.Windows.Visibility.Visible;
            }
            if (sceneselectData.education.Lighting == true)
            {
                Lighting_button.Visibility = System.Windows.Visibility.Visible;
                Lighting_button_Copy.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                Lighting_button.Visibility = System.Windows.Visibility.Hidden;
                Lighting_button_Copy.Visibility = System.Windows.Visibility.Visible;
            }
            if (sceneselectData.education.Distraction == true)
            {
                Distraction_button.Visibility = System.Windows.Visibility.Visible;
                Distraction_button_Copy.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                Distraction_button.Visibility = System.Windows.Visibility.Hidden;
                Distraction_button_Copy.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void scene_one_button_Click(object sender, RoutedEventArgs e)
        {
            sceneselectData.education.path = path1;
            sceneselectData.education.Speeding = false;            
            PageList.Main.setPage(PageList.EducationLoad);
            Speeding_button.Visibility = System.Windows.Visibility.Hidden;
            Speeding_button_Copy.Visibility = System.Windows.Visibility.Visible;
        }

        private void scene_two_button_Click(object sender, RoutedEventArgs e)
        {
            sceneselectData.education.path = path2;
            sceneselectData.education.Line = false;
            PageList.Main.setPage(PageList.EducationLoad);
            Line_button.Visibility = System.Windows.Visibility.Hidden;
            Line_button_Copy.Visibility = System.Windows.Visibility.Visible;
        }

        private void scene_three_button_Click(object sender, RoutedEventArgs e)
        {
            sceneselectData.education.path = path3;
            sceneselectData.education.Overtake = false;
            PageList.Main.setPage(PageList.EducationLoad);
            Overtake_button.Visibility = System.Windows.Visibility.Hidden;
            Overtake_button_Copy.Visibility = System.Windows.Visibility.Visible;
        }

        private void scene_four_button_Click(object sender, RoutedEventArgs e)
        {
            sceneselectData.education.path = path4;
            sceneselectData.education.Lighting = false;
            PageList.Main.setPage(PageList.EducationLoad);
            Lighting_button.Visibility = System.Windows.Visibility.Hidden;
            Lighting_button_Copy.Visibility = System.Windows.Visibility.Visible;
        }

        private void scene_five_button_Click(object sender, RoutedEventArgs e)
        {
            sceneselectData.education.path = path5;
            sceneselectData.education.Distraction = false;
            PageList.Main.setPage(PageList.EducationLoad);
            Distraction_button.Visibility = System.Windows.Visibility.Hidden;
            Distraction_button_Copy.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //如果五个按键都变灰，可以按下一步
            //这里是返回教育
            //var dr = CustomMessageBox.Show("温馨提示：", "驾驶行为教育评测已结束，点击YES查看报表！");//yes or no,设一个参数
            //if (dr == true)
            //{
            //    PageList.Main.setPage(PageList.DataExport);
            // }
            ////else
            //{ 
            //}SceneSelectPage page 
     
            PageList.SceneSelect= new SceneSelectPage();
            sceneselectData.education = new Education();
            PageList.Main.setPage(PageList.SceneSelect);
        }
    }
}


