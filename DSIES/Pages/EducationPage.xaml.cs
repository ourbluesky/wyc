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
using DSIES.Pages;

namespace DSIES.Pages
{
    /// <summary>
    /// EducationPage.xaml 的交互逻辑
    /// </summary>
    public partial class EducationPage : Page
    {
        public EducationPage()
        {
            InitializeComponent();
            mediaElement.Source = new Uri(sceneselectData.education.Path, UriKind.Relative);
            mediaElement.Play();
        }
        private void play_Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            play_Button.Visibility = System.Windows.Visibility.Hidden;
            pause_Button.Visibility = System.Windows.Visibility.Visible;
        }

        private void pause_Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            pause_Button.Visibility = System.Windows.Visibility.Hidden;
            play_Button.Visibility = System.Windows.Visibility.Visible;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            PageList.Main.setPage(PageList.Education_educate);
            
        }
    }



    }