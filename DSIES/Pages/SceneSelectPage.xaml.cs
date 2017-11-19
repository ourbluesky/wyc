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
using DSIES.UDP;

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
            CU.Player.Start();
            PageList.Scene = new Pages.ScenePage();
            CU.MG_Page.GameStartAction();
            scene_one_button.Visibility = System.Windows.Visibility.Hidden;
            scene_one_button_copy.Visibility = System.Windows.Visibility.Visible;
            sceneselectData.scene = 1;
        }

        private void scenen_two_button_Click(object sender, RoutedEventArgs e)
        {         
            PageList.Scene = new Pages.ScenePage();
            CU.Player.Start();
            CU.MG_Page.GameStartAction();
            scene_two_button.Visibility = System.Windows.Visibility.Hidden;
            scene_two_button_copy.Visibility = System.Windows.Visibility.Visible;
            sceneselectData.scene = 2;
        }

        private void scene_three_button_Click(object sender, RoutedEventArgs e)
        {
            CU.Player.Start();
            PageList.Scene = new Pages.ScenePage(); 
            CU.MG_Page.GameStartAction();
            scene_three_button.Visibility = System.Windows.Visibility.Hidden;
            scene_three_button_copy.Visibility = System.Windows.Visibility.Visible;
            sceneselectData.scene = 3;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (scene_one_button_copy.Visibility != System.Windows.Visibility.Visible||scene_two_button_copy.Visibility != System.Windows.Visibility.Visible || scene_three_button_copy.Visibility != System.Windows.Visibility.Visible)
              {
                    CustomMessageBox.Show("温馨提示：", "您还有场景尚未完成！\n请继续完成测试！");
               }    
            else
            {
                if (PageList.Main.i >=2 || (sceneselectData.education.Speeding == false && sceneselectData.education.Overtake == false && sceneselectData.education.Lighting == false && sceneselectData.education.Distraction == false))
               {
                    if (PageList.Main.i == 0)
                       PageList.Login.Regular.Totalscore_frist = sceneselectData.score.add_all(sceneselectData.score.Speed_Score1, sceneselectData.score.Speed_Score2, sceneselectData.score.Speed_Score3, sceneselectData.score.Speed_Score4, sceneselectData.score.Speed_Score5, sceneselectData.score.Line_Score1, sceneselectData.score.Line_Score2, sceneselectData.score.Line_Score3, sceneselectData.score.Line_Score4, sceneselectData.score.Overtake_Score1, sceneselectData.score.Overtake_Score2, sceneselectData.score.Overtake_Score3, sceneselectData.score.Lighting_Score, sceneselectData.score.Distrationg_Score).ToString();
                    if (PageList.Main.i == 1)
                        PageList.Login.Regular.Totalscore_final = sceneselectData.score.add_all(sceneselectData.score.Speed_Score1, sceneselectData.score.Speed_Score2, sceneselectData.score.Speed_Score3, sceneselectData.score.Speed_Score4, sceneselectData.score.Speed_Score5, sceneselectData.score.Line_Score1, sceneselectData.score.Line_Score2, sceneselectData.score.Line_Score3, sceneselectData.score.Line_Score4, sceneselectData.score.Overtake_Score1, sceneselectData.score.Overtake_Score2, sceneselectData.score.Overtake_Score3, sceneselectData.score.Lighting_Score, sceneselectData.score.Distrationg_Score).ToString();
                    if (PageList.Main.i == 2)
                    {
                        PageList.Login.Regular.Credit = "B";
                        PageList.Login.Regular.Totalscore_final = sceneselectData.score.add_all(sceneselectData.score.Speed_Score1, sceneselectData.score.Speed_Score2, sceneselectData.score.Speed_Score3, sceneselectData.score.Speed_Score4, sceneselectData.score.Speed_Score5, sceneselectData.score.Line_Score1, sceneselectData.score.Line_Score2, sceneselectData.score.Line_Score3, sceneselectData.score.Line_Score4, sceneselectData.score.Overtake_Score1, sceneselectData.score.Overtake_Score2, sceneselectData.score.Overtake_Score3, sceneselectData.score.Lighting_Score, sceneselectData.score.Distrationg_Score).ToString();
                    }    
                    CustomMessageBox.Show("温馨提示：", "此次教育测试已结束！");//yes or no,设一个参数  
                    DataExportPage page = new DataExportPage();
                    PageList.Main.setPage(page);
                    //PageList.Main.setPage(PageList.DataExport);//报告
                }
               else
              {
                   PageList.Login.Regular.Totalscore_frist = sceneselectData.score.add_all(sceneselectData.score.Speed_Score1, sceneselectData.score.Speed_Score2, sceneselectData.score.Speed_Score3, sceneselectData.score.Speed_Score4, sceneselectData.score.Speed_Score5, sceneselectData.score.Line_Score1, sceneselectData.score.Line_Score2, sceneselectData.score.Line_Score3, sceneselectData.score.Line_Score4, sceneselectData.score.Overtake_Score1, sceneselectData.score.Overtake_Score2, sceneselectData.score.Overtake_Score3, sceneselectData.score.Lighting_Score, sceneselectData.score.Distrationg_Score).ToString();
                    sceneselectData.scene = 0;
                    EducationSelectPage page = new EducationSelectPage();
                    PageList.Main.setPage(page);
                  PageList.Main.i++;
              }
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
        public static ScoreClass score = new ScoreClass();
     }

}
