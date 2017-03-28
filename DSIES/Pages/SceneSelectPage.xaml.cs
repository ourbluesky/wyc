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
using DSIES.Class.Control;

namespace DSIES.Pages
{
    /// <summary>
    /// SceneSelectPage.xaml 的交互逻辑
    /// </summary>
    public partial class SceneSelectPage : Page
    {

        public SceneSelectPage()
        {
            InitializeComponent();
        }

        private void scene_one_button_Click(object sender, RoutedEventArgs e)
        {
            ScenePage page = new ScenePage();
            PageList.Main.setPage(page);
            scene_one_button.Visibility = System.Windows.Visibility.Hidden;
            scene_one_button_copy.Visibility = System.Windows.Visibility.Visible;
            sceneselectData.scene = 1;
        }

        private void scenen_two_button_Click(object sender, RoutedEventArgs e)
        {
            ScenePage page = new ScenePage();
            PageList.Main.setPage(page);
            scene_two_button.Visibility = System.Windows.Visibility.Hidden;
            scene_two_button_copy.Visibility = System.Windows.Visibility.Visible;
            sceneselectData.scene = 2;
        }

        private void scene_three_button_Click(object sender, RoutedEventArgs e)
        {
            ScenePage page = new ScenePage();
            PageList.Main.setPage(page);
            scene_three_button.Visibility = System.Windows.Visibility.Hidden;
            scene_three_button_copy.Visibility = System.Windows.Visibility.Visible;
            sceneselectData.scene = 3;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (PageList.Main.i >= 3 || (sceneselectData.education.Speeding == true && sceneselectData.education.Overtake == true && sceneselectData.education.Lighting == true && sceneselectData.education.Distraction == true))
            {
                if (PageList.Main.i == 3)
                    PageList.Main.Regular.Credit = "B";
                PageList.Main.setPage(PageList.DataExport);//报告
            }
            else
            {
                sceneselectData.scene = 0;
                EducationSelectPage page = new EducationSelectPage();
                PageList.Main.setPage(page);
                PageList.Main.i++;
            }
        }


    }
     static class sceneselectData                 
    {
        static sceneselectData()
        {
            education = new Education();
        }
        public static Education education;
        public static int scene;
    }

}
