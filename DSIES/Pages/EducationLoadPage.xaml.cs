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
using System.Windows.Forms;
using DSIES.Pages;
using DSIES.Class.Control;
using System.Windows.Threading;

namespace DSIES.Pages
{
    /// <summary>
    /// EducationLoadPage.xaml 的交互逻辑
    /// </summary>
    public partial class EducationLoadPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public EducationLoadPage()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            textBlock.DataContext = string.Concat(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            EducationPage page = new EducationPage();
            PageList.Main.setPage(page);
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            GIFCtrl.StartAnimate();
        }
    }

}

