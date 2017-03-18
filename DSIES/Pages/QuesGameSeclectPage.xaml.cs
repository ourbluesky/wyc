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
    /// QuesGameSeclectPage.xaml 的交互逻辑
    /// </summary>
    public partial class QuesGameSeclectPage : Page
    {  
        Question question = new Question();

        public QuesGameSeclectPage()
        {
            InitializeComponent();
      
        }
   


         private void Game_Button_Click(object sender, RoutedEventArgs e)
        {
            if (PageList.Main.GAME.Done == false)//没完成
            { 
                PageList.Main.setPage(PageList.Game);
                GameButton.Visibility = System.Windows.Visibility.Hidden;
                GameButton_copy.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                if (question.Flagquestion == false)
                {
                    CustomMessageBox.Show( "温馨提示：","请完成问卷！");
                }

             //   else { }//测试主界面
            }
        }


        private void Question_Button_Click(object sender, RoutedEventArgs e)
        {
            if (question.Flagquestion == false)//没完成
            {
                PageList.Main.setPage(PageList.Question1);
                QuestionButton.Visibility = System.Windows.Visibility.Hidden;
                QuestionButton_copy.Visibility = System.Windows.Visibility.Visible;
            }
            else 
            {
                if (PageList.Main.GAME.Done == false)
                { 
                CustomMessageBox.Show("温馨提示：","请完成游戏！");
                }

           //     else 
           //     { 
                  
           //     }//测试主界面
            }
        }

    }

}


