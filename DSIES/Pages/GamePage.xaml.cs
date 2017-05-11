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
using DSIES.Pages;

namespace DSIES.Pages
{
    /// <summary>
    /// GamePage.xaml 的交互逻辑
    /// </summary>
    public partial class GamePage : Page
    {
        Game game = new Game();
        Random rd = new Random();
        int key;

        public GamePage()
        {
            InitializeComponent();
                       
            textBlock_score.DataContext = game.Score;
            textBlock_times.DataContext = game.Times;
            PageList.Main.Regular.Grade=Game_score();
        }

        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            if (game.Times < 60)
            {
                CustomMessageBox.Show("温馨提示：", "请继续游戏！");
            }
            else
            {
                game.Done = true;
                success(game);
                if (PageList.Main.QUESTION.Flagquestion == true)
                    PageList.Main.setPage(PageList.SceneSelect);
                else
                    PageList.Main.setPage(PageList.Questionandgame);
            }
        }

        private void success(Game game)
        {
            PageList.Main.GAME = game;
        }

        private void A_Button_Click(object sender, RoutedEventArgs e)
        {
            if (game.Times < 60)
            {
                key = rd.Next(0, 2);
                if (key == 1)
                {
                    game.Score += 100;
                }
                else
                {
                    game.Score -= rd.Next(35, 151);
                }
                textBlock_score.DataContext = game.Score;
                game.Times += 1;
                game.ATimes += 1;
                textBlock_times.DataContext = game.Times;
            }
            else
            {
                CustomMessageBox.Show("温馨提示：", "游戏已完成，请进行下一步！");
            }
        }

        private void B_Button_Click(object sender, RoutedEventArgs e)
        {
            if (game.Times < 60)
            {
                key = rd.Next(0, 10);
                if (key < 9)
                {
                    game.Score += 100;
                }
                else
                {
                    game.Score -= 1250;
                }
                textBlock_score.DataContext = game.Score;
                game.Times += 1;
                game.BTimes += 1;
                textBlock_times.DataContext = game.Times;
            }
            else
            {
                CustomMessageBox.Show("温馨提示：", "游戏已完成，请进行下一步！");
            }
        }

        private void C_Button_Click(object sender, RoutedEventArgs e)
        {
            if (game.Times < 60)
            {
                key = rd.Next(0, 2);
                if (key == 1)
                {
                    game.Score += 50;
                }
                else
                {
                    game.Score -= rd.Next(25, 76);
                }
                textBlock_score.DataContext = game.Score;
                game.Times += 1;
                game.CTimes += 1;
                textBlock_times.DataContext = game.Times;
            }
            else
            {
                 CustomMessageBox.Show("温馨提示：", "游戏已完成，请进行下一步！");
            }
        }
        private void D_Button_Click(object sender, RoutedEventArgs e)
        {
            if (game.Times < 60)
            {
                key = rd.Next(0, 10);
                if (key < 9)
                {
                    game.Score += 50;
                }
                else
                {
                    game.Score -= 250;
                }
                textBlock_score.DataContext = game.Score;
                game.Times += 1;
                game.DTimes += 1;
                textBlock_times.DataContext = game.Times;


            }
            else
            {
                CustomMessageBox.Show("温馨提示：", "游戏已完成，请进行下一步！");
            }
        }
        private string  Game_score()
        {
            if(game.ATimes+game.BTimes<=game.CTimes+game.DTimes)
            {
                return "非冒险型";
            }
            else
            {
                return "冒险型";
            }
        }
    }
}


