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
using LiveCharts;
using LiveCharts.Configurations;
using DSIES.Pages;
using DSIES.UDP;

namespace DSIES.Pages
{
    /// <summary>
    /// ScenePage.xaml 的交互逻辑
    /// </summary>
    public partial class ScenePage : Page
    {
        public ScenePage()
        {
            InitializeComponent();
            SetChart();
            ContentGrid.DataContext = this;     // 这个是必要的，绑定数据，否则画不出来
            //


            CU.MG_UDP.PrepareReceive();
            Svframe frame = CU.MG_UDP.ReceiveFrame();
            if (frame != null)
                Console.WriteLine(frame.Time);
            float time;
            float speed;
            float brake;
            float acc;
            time = frame.Time;
            


            speed = frame.Speed;
            CU.MG_UDP.EndReceive();
        }


        public ChartValues<Point> PointsM { get; set; }
        public ChartValues<Point> PointsN { get; set; }

        private void SetChart()
        {
            // Mapper 决定如何把Point对象映射到图上，x轴对应Point.x，y轴对应Point.y
            var mapper = Mappers.Xy<Point>()
                .X(point => point.X)
                .Y(point => point.Y);
            Charting.For<Point>(mapper);

            // 可以一个个加到图中，适用于点比较少，但希望一个个更新到图上
            PointsM = new ChartValues<Point>();
            PointsM.Add(new Point(1, 7));
            PointsM.Add(new Point(2, 6));
            PointsM.Add(new Point(3, 4));
            PointsM.Add(new Point(4, 9));
            PointsM.Add(new Point(5, 6));
            PointsM.Add(new Point(6, 1));
            PointsM.Add(new Point(7, 2));

            // 可以一次添加多个点到图中，适用于点比较多，可以一次性添加完成（比较建议的方法）
            // 在实际应用中，如果点更新的非常快，不推荐每更新一个点就实时加到图中，可以先存到一个临时的ChartValues<Point>()里面，然后一起更新到图上
            // 比如数据更新速度是 10个/s。可以每存十个数据更新一次，也就是1s更新一次图，而不是0.1s更新一次。
            // 可以参考 /View/Pages/GameRealTime.xaml.cs中Cache的部分，就是基于这样的考虑
            PointsN = new ChartValues<Point>();
            var CachePoints = new ChartValues<Point>();
            CachePoints.Add(new Point(1, 1));
            CachePoints.Add(new Point(2, 2));
            CachePoints.Add(new Point(3, 2));
            CachePoints.Add(new Point(4, 7));
            CachePoints.Add(new Point(5, 4));
            CachePoints.Add(new Point(6, 1));
            CachePoints.Add(new Point(7, 10));
            PointsN.AddRange(CachePoints);
            Speed_textBlock.DataContext = 1;
            Acceleration_textBlock.DataContext = 2;
            Break_textBlock.DataContext = 3;
            Accelerator_textBlock.DataContext = 4;
        }
    // Point类，表示折线图上的一个坐标点
        public class Point
    {
        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public float X { get; set; }
        public float Y { get; set; }
    }

        private void Speed_Button_Click(object sender, RoutedEventArgs e)
        {
            Speed.Visibility = System.Windows.Visibility.Visible;
            Acceleration.Visibility = System.Windows.Visibility.Hidden;
            Break.Visibility = System.Windows.Visibility.Hidden;
            Accelerator.Visibility = System.Windows.Visibility.Hidden;

        }

        private void Acceleration_button_Click(object sender, RoutedEventArgs e)
        {
            Speed.Visibility = System.Windows.Visibility.Hidden;
            Acceleration.Visibility = System.Windows.Visibility.Visible;
            Break.Visibility = System.Windows.Visibility.Hidden;
            Accelerator.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Break_Button_Click(object sender, RoutedEventArgs e)
        {
            Speed.Visibility = System.Windows.Visibility.Hidden;
            Acceleration.Visibility = System.Windows.Visibility.Hidden;
            Break.Visibility = System.Windows.Visibility.Visible;
            Accelerator.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Accelerator_Button_Click(object sender, RoutedEventArgs e)
        {
            Speed.Visibility = System.Windows.Visibility.Hidden;
            Acceleration.Visibility = System.Windows.Visibility.Hidden;
            Break.Visibility = System.Windows.Visibility.Hidden;
            Accelerator.Visibility = System.Windows.Visibility.Visible;
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            PageList.Main.setPage(PageList.SceneSelect);
        }
    }
}
