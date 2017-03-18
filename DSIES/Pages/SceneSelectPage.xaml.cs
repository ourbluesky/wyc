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

namespace DSIES.Pages
{
    /// <summary>
    /// SceneSelectPage.xaml 的交互逻辑
    /// </summary>
    public partial class SceneSelectPage : Page
    {
        int i = 0;
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
        }

        private void scenen_two_button_Click(object sender, RoutedEventArgs e)
        {
            ScenePage page = new ScenePage();
            PageList.Main.setPage(page);
            scene_two_button.Visibility = System.Windows.Visibility.Hidden;
            scene_two_button_copy.Visibility = System.Windows.Visibility.Visible;
        }

        private void scene_three_button_Click(object sender, RoutedEventArgs e)
        {
            ScenePage page = new ScenePage();
            PageList.Main.setPage(page);
            scene_three_button.Visibility = System.Windows.Visibility.Hidden;
            scene_three_button_copy.Visibility = System.Windows.Visibility.Visible;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //if (i >= 3 || (Speeding == true && Line == true && Overtake == true && Lighting == true && Distraction == true))
            //{
            //    PageList.Main.setPage(DataExportPage);//报告
            //}
            //else
            //{
                EducationSelectPage page = new EducationSelectPage();
                PageList.Main.setPage(page);
                i++;
            //}
        }

      
    }
}
