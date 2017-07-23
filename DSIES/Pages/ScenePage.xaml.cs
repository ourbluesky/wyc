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
using System.Threading;
using DSIES.Pages;
using DSIES.UDP;
using DSIES.Class.Control;
using DSIES.Class.Model;

namespace DSIES.Pages
{
    /// <summary>
    /// ScenePage.xaml 的交互逻辑
    /// </summary>
    public partial class ScenePage : Page
    {
        private float s_s;//距离
        public float S_S
        {
            get { return s_s; }
            set { s_s = value; }
        }
        private float speed_out;//保留
        public float SPEED_OUT
        {
            get { return speed_out; }
            set { speed_out = value; }
        }
        public ScenePage()
        {     
            InitializeComponent();
            ContentGrid.DataContext = this;
            first = true;
        }

        
        public void SetPage(Svframe svframe) //Svframe
        {

            this.Dispatcher.BeginInvoke((System.Action)(delegate()
            {
                UpdateChart(svframe);
            }));
        }

        public void ResetPage()
        {
            ClearValues();
            ChartInit();
        }

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
            Speed_textBlock.DataContext = record.Speed;//
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
            //act.SPEED = f.Speed;
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
            S_S += record.Speed / 360;
            //这两个是场景左边的两个框的内容
            x_x.DataContext = S_S;
            y_y.DataContext=  "";
            switch (sceneselectData.scene)
            {
                case 1:                
                        sceneselectData.education.Speeding = act.speeding_judge(f.Speed);                    
                        sceneselectData.education.Line = act.line_judge(f.Speed,f.Acc,f.Brake);
                        sceneselectData.education.Overtake = act.overtake_judge(f.Speed, f.Acc, f.Brake);

                    
                    break;
                case 2:
                    sceneselectData.education.Lighting = act.lighting_judge(f.Speed);
                    
                    break;
                case 3:
                    sceneselectData.education.Distraction = act.distrationg_judge(f.Speed);
                    
                    break;
                default:break;
            }
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
            CU.MG_UDP.EndReceive();//关闭
            PageList.Main.setPage(PageList.SceneSelect);
        }

        /* For Action Binding. Action Binding Only Once */
        private bool first;
        public bool FirstRun
        {
            get
            {
                bool tmp = first;
                first = false;
                return tmp;
            }

            set
            {
                first = value;
            }
        }


        #region GamePlay
        /* 
         * This runs only once to get GameRealTime Page ready 
         * and binds actions before, during and after game. 
         */


        //public void GameStartAction()
        //{
        //    GameFirstStep();
        //    this.ResetPage();//初始化
        //    PageList.Main.setPage(PageList.Scene);
        //    // CurrentPage = PageCluster.GameRealTime;

        //    /* Start the UDP receiving thread */
        //    CU.Player.Start();
        //}


        //private void SetUDPRefreshAction()
        //{
        //    CU.Player.RefreshHandler += SetPage;//PageList.Main.setPage(PageList.Scene);
        //}

        //private void SetUDPTimeOutAction()
        //{
        //    CU.MG_UDP.ReceiveTimeOutAction += () =>
        //    {
        //        if (current == PageCluster.GameRealTime)
        //        {
        //            Application.Current.Dispatcher.BeginInvoke((System.Action)(delegate()
        //            {
        //                if (!Ending && !Warning)
        //                {
        //                    Warning = true;
        //                    CustomMessageBox.Show("UDP连接超时，请检查网络是否正常连通！");
        //                    Warning = false;
        //                    GameEndAction();
        //                }
        //            }));
        //        }
        //    };
        //}



        //private void SaveExp(Exp exp)
        //{
        //    CU.MG_Exp.AddExp(exp, bool.Parse(CU.MG_Set.App["evaluation"]["after_exp"]));
        //    CU.MG_Exp.ThreadSave(CU.MG_User.User as Regular);
        //}

        //public void GameEndAction()
        //{
        //    //Ending = true;
        //    //ExpType type = ExpTypeBox.Show();
        //    //if (type != ExpType.Cancel)
        //    //{
        //    //    CU.Player.End(type);
        //    CurrentPage = PageCluster.GameSelect;

        //    this.SetPage = PageList.Main.setPage(PageList.SceneSelect);
        //    //}
        //    //Ending = false;
        //}
        #endregion
    }

}
