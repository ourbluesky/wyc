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
using DSIES.Class.Control;

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
            //SetChart();
            ContentGrid.DataContext = this;     // 这个是必要的，绑定数据，否则画不出来
            //


            CU.MG_UDP.PrepareReceive();
            Svframe frame = CU.MG_UDP.ReceiveFrame();
            float time;
            float speed;
            float brake;
            float accelerograph;
            float acc;
            if (frame != null)
            {
                time = frame.Time;
                speed = frame.Speed;
                brake = frame.Brake;
                accelerograph = frame.Accelerograph;
                acc = frame.Acc;
                SetPage(frame);
            }
            else
                CustomMessageBox.Show("", "Error!");
            
            CU.MG_UDP.EndReceive();//关闭
        }


        public void SetPage(Svframe record)
        {
            this.Dispatcher.BeginInvoke((System.Action)(delegate ()
            {
                UpdateChart(record);
            }));
        }

        public void ResetPage()
        {
            ClearValues();
            ChartInit();
        }

        //public ChartValues<Point> PointsM { get; set; }
        //public ChartValues<Point> PointsN { get; set; }

        //private void SetChart()
        //{
        //    // Mapper 决定如何把Point对象映射到图上，x轴对应Point.x，y轴对应Point.y
        //    var mapper = Mappers.Xy<Point>()
        //        .X(point => point.X)
        //        .Y(point => point.Y);
        //    Charting.For<Point>(mapper);

        //    // 可以一个个加到图中，适用于点比较少，但希望一个个更新到图上
        //    PointsM = new ChartValues<Point>();
        //    PointsM.Add(new Point(1, 7));
        //    PointsM.Add(new Point(2, 6));
        //    PointsM.Add(new Point(3, 4));
        //    PointsM.Add(new Point(4, 9));
        //    PointsM.Add(new Point(5, 6));
        //    PointsM.Add(new Point(6, 1));
        //    PointsM.Add(new Point(7, 2));

        //    // 可以一次添加多个点到图中，适用于点比较多，可以一次性添加完成（比较建议的方法）
        //    // 在实际应用中，如果点更新的非常快，不推荐每更新一个点就实时加到图中，可以先存到一个临时的ChartValues<Point>()里面，然后一起更新到图上
        //    // 比如数据更新速度是 10个/s。可以每存十个数据更新一次，也就是1s更新一次图，而不是0.1s更新一次。
        //    // 可以参考 /View/Pages/GameRealTime.xaml.cs中Cache的部分，就是基于这样的考虑
        //    PointsN = new ChartValues<Point>();
        //    var CachePoints = new ChartValues<Point>();
        //    CachePoints.Add(new Point(1, 1));
        //    CachePoints.Add(new Point(2, 2));
        //    CachePoints.Add(new Point(3, 2));
        //    CachePoints.Add(new Point(4, 7));
        //    CachePoints.Add(new Point(5, 4));
        //    CachePoints.Add(new Point(6, 1));
        //    CachePoints.Add(new Point(7, 10));
        //    PointsN.AddRange(CachePoints);
        //    Speed_textBlock.DataContext = 1;
        //    Acceleration_textBlock.DataContext = 2;
        //    Break_textBlock.DataContext = 3;
        //    Accelerator_textBlock.DataContext = 4;
        //}

        /* Points. T for Time, D for Distance */
        private ChartValues<Point> TSpeed;
        private ChartValues<Point> TAcc;
        private ChartValues<Point> TOffset;
        private ChartValues<Point> TSTWAngle;
        private ChartValues<Point> TFarToFront;
        private ChartValues<Point> DSpeed;
        private ChartValues<Point> DAcc;
        private ChartValues<Point> DOffset;
        private ChartValues<Point> DSTWAngle;
        private ChartValues<Point> DFarToFront;
        private ChartValues<Point> TAccelerograph;
        private ChartValues<Point> TBreak;
        private ChartValues<Point> DAccelerograph;
        private ChartValues<Point> DBreak;

        /* Cache Points */
        private ChartValues<Point> CacheTSpeed;
        private ChartValues<Point> CacheTAcc;
        private ChartValues<Point> CacheTOffset;
        private ChartValues<Point> CacheTSTWAngle;
        private ChartValues<Point> CacheTFarToFront;
        private ChartValues<Point> CacheDSpeed;
        private ChartValues<Point> CacheDAcc;
        private ChartValues<Point> CacheDOffset;
        private ChartValues<Point> CacheDSTWAngle;
        private ChartValues<Point> CacheDFarToFront;
        private ChartValues<Point> CacheDAccelerograph;
        private ChartValues<Point> CacheTAccelerograph;
        private ChartValues<Point> CacheTBreak;
        private ChartValues<Point> CacheDBreak;

        private const int CacheSize = 10;
        private int CacheCount;

        /* ChartValues */
        public ChartValues<Point> CenterChart { get; set; }
        public ChartValues<Point> SpeedChart { get; set; }
        public ChartValues<Point> AccelerographChart { get; set; }
        public ChartValues<Point> AccChart { get; set; }
        public ChartValues<Point> OffsetChart { get; set; }
        public ChartValues<Point> STWAngleChart { get; set; }
        public ChartValues<Point> FarToFrontChart { get; set; }
        public ChartValues<Point> BreakChart { get; set; }



        private void ClearValues()
        {
            TSpeed = new ChartValues<Point>();
            TAcc = new ChartValues<Point>();
            TAccelerograph = new ChartValues<Point>();
            TOffset = new ChartValues<Point>();
            TSTWAngle = new ChartValues<Point>();
            TFarToFront = new ChartValues<Point>();
            TBreak = new ChartValues<Point>();
            DSpeed = new ChartValues<Point>();
            DAcc = new ChartValues<Point>();
            DAccelerograph = new ChartValues<Point>();
            DOffset = new ChartValues<Point>();
            DSTWAngle = new ChartValues<Point>();
            DFarToFront = new ChartValues<Point>();
            DBreak = new ChartValues<Point>();
        }
        private void ChartInit()
        {
            SetMapper();
            BindTime();
            CacheCount = 0;
        }
        private void BindTime()
        {
            CenterChart = TSpeed;
            SpeedChart = TSpeed;
            AccChart = TAcc;
            AccelerographChart = TAccelerograph;
            BreakChart = TBreak;
            OffsetChart = TOffset;
            STWAngleChart = TSTWAngle;
            FarToFrontChart = TFarToFront;
        }

        private void BindDistance()
        {
            CenterChart = DSpeed;
            SpeedChart = DSpeed;
            AccChart = DAcc;
            AccelerographChart = DAccelerograph;
            BreakChart = DBreak;
            OffsetChart = DOffset;
            STWAngleChart = DSTWAngle;
            FarToFrontChart = DFarToFront;
        }

        private void SetMapper()
        {
            var mapper = Mappers.Xy<Point>()
                .X(point => point.X)
                .Y(point => point.Y);
            Charting.For<Point>(mapper);
        }

        private void UpdateChart(Svframe record)
        {
            if (CacheCount >= CacheSize)
                FlushCache();
            if (CacheCount == 0)
                ClearCache();
            Speed_textBlock.DataContext = record.Speed;
            Acc_textBlock.DataContext = record.Acc;
            Break_textBlock.DataContext = record.Brake;
            Accelerator_textBlock.DataContext = record.Accelerograph;

            Cache(record);
        }

        private void ClearCache()
        {
            CacheTSpeed = new ChartValues<Point>();
            CacheTAccelerograph = new ChartValues<Point>();
            CacheTAcc = new ChartValues<Point>();
            CacheTOffset = new ChartValues<Point>();
            CacheTSTWAngle = new ChartValues<Point>();
            CacheTFarToFront = new ChartValues<Point>();
            CacheTBreak = new ChartValues<Point>();
            CacheDSpeed = new ChartValues<Point>();
            CacheDAccelerograph = new ChartValues<Point>();
            CacheDAcc = new ChartValues<Point>();
            CacheDOffset = new ChartValues<Point>();
            CacheDSTWAngle = new ChartValues<Point>();
            CacheDFarToFront = new ChartValues<Point>();
            CacheDBreak = new ChartValues<Point>();
        }

        private void Cache(Svframe record)
        {
            Svframe f = record;
            Data_DealClass act = new Data_DealClass();
            act.SPEED = f.Speed;
            act.LINE = f.Lane;
            act.LEFT_distence = f.Distance;
            float t = f.Time;
            float d = f.Distance;

            CacheTSpeed.Add(new Point(t, f.Speed));
            CacheTAccelerograph.Add(new Point(t, f.Accelerograph));
            CacheTAcc.Add(new Point(t, f.Acc));
            CacheTOffset.Add(new Point(t, f.Offset));
            CacheTSTWAngle.Add(new Point(t, f.StwAngle));
            CacheTFarToFront.Add(new Point(t, f.FarToFront));
            CacheTBreak.Add(new Point(t, f.Brake));
            CacheDSpeed.Add(new Point(d, f.Speed));
            CacheDAcc.Add(new Point(d, f.Acc));
            CacheDAccelerograph.Add(new Point(d, f.Accelerograph));
            CacheDOffset.Add(new Point(d, f.Offset));
            CacheDSTWAngle.Add(new Point(d, f.StwAngle));
            CacheDFarToFront.Add(new Point(d, f.FarToFront));
            CacheDBreak.Add(new Point(t, f.Brake));
            PageList.Main.EDUCATION.Speeding = act.speeding_judge();
            PageList.Main.EDUCATION.Line = act.line_judge(f.X, f.Y);
            PageList.Main.EDUCATION.Overtake = act.overtake_judge(f.X, f.Y);
            PageList.Main.EDUCATION.Lighting = act.lighting_judge(f.X, f.Y);
            PageList.Main.EDUCATION.Distraction = act.distrationg_judge(f.X, f.Y);
            CacheCount++;
        }
        private void FlushCache()
        {
            TSpeed.AddRange(CacheTSpeed);
            TAcc.AddRange(CacheTAcc);
            TAccelerograph.AddRange(CacheTAccelerograph);
            TOffset.AddRange(CacheTOffset);
            TSTWAngle.AddRange(CacheTSTWAngle);
            TFarToFront.AddRange(CacheTFarToFront);
            TBreak.AddRange(CacheTBreak);
            DSpeed.AddRange(CacheDSpeed);
            DAcc.AddRange(CacheDAcc);
            DAccelerograph.AddRange(CacheDAccelerograph);
            DOffset.AddRange(CacheDOffset);
            DSTWAngle.AddRange(CacheDSTWAngle);
            DFarToFront.AddRange(CacheDFarToFront);
            DBreak.AddRange(CacheDBreak);
            CacheCount = 0;
        }
        //    // Point类，表示折线图上的一个坐标点
        //    public class Point
        //{
        //    public Point(float x, float y)
        //    {
        //        this.X = x;
        //        this.Y = y;
        //    }
        //    public float X { get; set; }
        //    public float Y { get; set; }
        //}

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
