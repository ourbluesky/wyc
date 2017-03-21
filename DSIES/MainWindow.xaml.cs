using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DSIES.Pages;
using DSIES.Class.Control;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//using DSIES.UDP;
//using DSIES.Class.Model;
//using DSIES.Control.Operation;
//using DSIES.Control.User;
using System.Windows.Input;
//using DSIES.Widget;
//using DSIES.Info.Database;


namespace DSIES
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //   UDPController udpControl;
        //    UserSelections selection;
        //  User user;
        //     Player player;
        Question question = new Question();
        internal Question QUESTION
        {
            get { return question; }
            set { question = value; }
        }

        Game game = new Game();
        internal Game GAME
        {
            get { return game; }
            set { game = value; }
        }

        Education education = new Education();
        internal Education EDUCATION
        {
            get { return education; }
            set { education = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            //init();
            setPage(PageList.Login);

        }


        /*   internal Player Player
        {
            get { return player; }
            set { player = value; }
        }*/

        //User user = new User();
        // internal User User
        // {
        //     get { return user; }
        //     set
        //     {
        //         user = value;
        //         if (user != null)
        //         {
        //             LogOutButtonVisiable();
        //         }
        //         else
        //         {
        //             LogOutButtonInvisiable();
        //         }
        //     }
        // }

        /*internal UserSelections Selection
        //{
        //    get { return selection; }
        //    set { selection = value; }
        //}

        //internal UDPController UdpControl
        //{
        //    get { return udpControl; }
        //    set { udpControl = value; }
        //}*/

        /*void init() {
        //    udpControl = new UDPController();
        //    selection = new UserSelections();
        //    player = new Player();
        //    User = null;

        //    LogOutButtonInvisiable();
        //}*/

        /* public bool testConnection()
        {
            UDPTest test = new UDPTest(udpControl.Port);
            Thread thread = new Thread(test.test);
            thread.Start();
            if (thread.Join(TimeSpan.FromSeconds(2)))
            {
                thread.Abort();
            }
            test.close();
            return test.Connected;
        }*/

        public void setPage(Page page)
        {
            //if (page.Equals(PageList.SceneSelect) || page.Equals(PageList.Experience))
            //{
            //    PageList.CurrentExperience = page;
            //}//不明白

            MainFrame.Content = page;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) //关闭界面
        {
            shutdownApp();
        }

        private bool isSceneing()
        {
            if (MainFrame.Content.Equals(PageList.Scene))//
            { return true; }
            else
            { return false; }
        }

        private void shutdownApp() //关闭
        {
            if (isSceneing())
            {
                CustomMessageBox.Show("Warning", "Can't quit before the end of experience!");
                return;
            }

            if (CustomMessageBox.Show("Confirmation", "Do you want to close this window?")
                == true)
            {
                this.Close();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) //关闭界面
        {
            Environment.Exit(0);
            base.OnClosing(e);
        }

        //private void click()
        //{
        //    exp.Chosen = true;
        //}

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)//自定义窗口
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)  //登录
        {
            if (isSceneing())
            {
                CustomMessageBox.Show("Warning", "Can't logout before the end of experience!");
                return;
            }
            this.setPage(PageList.Login);
            //    this.init();//init上边有定义
        }

        public void LogOutButtonVisiable() //重新登录
        {
            LogOutBtn.Visibility = System.Windows.Visibility.Visible;
        }

        public void LogOutButtonInvisiable() //重新登录
        {
            LogOutBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (isSceneing())
            {
                CustomMessageBox.Show("Warning", "Can't log in as an administrator before the end of user's experience!");
                return;
            }
           // this.setPage(PageList.AdminLogin);
            //    this.init();//init上边有定义
        }

        public void AdminButtonVisiable() //重新登录
        {
            AdminBtn.Visibility = System.Windows.Visibility.Visible;
        }

        public void AdminButtonInvisiable() //重新登录
        {
            AdminBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
                MaxmumBtn.Visibility = System.Windows.Visibility.Hidden;
                ResizeBtn.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
                ResizeBtn.Visibility = System.Windows.Visibility.Hidden;
                MaxmumBtn.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void WindowStateChange(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                ResizeBtn.Content = "Resize";
                ResizeBtn.ToolTip = "Resize the window";
            }
            else
            {
                ResizeBtn.Content = "Full Screen";
                ResizeBtn.ToolTip = "Maximum the window";
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

    }


    public static class PageList                 //每个页面
    {
        static MainWindow main = (MainWindow)Application.Current.MainWindow;
        static LoginPage login;
        static QuesGameSeclectPage questionandgame;
        static GamePage game;
        static QuestionPage1 question1;
        static QuestionPage2 question2;
        //   static AboutPage about;
        static SceneSelectPage sceneSelect;
        static ScenePage scene;
        static EducationPage education;
        static EducationLoadPage educationLoad;
        static Education_educatePage education_educate;
        static EducationSelectPage educationSelect;

        //   static Page currentExperience;
        //    static Page currentEvaluation;
        //     static Page currentAbout;
        //     static EvaluationPage evaluation;
        static DataExportPage dataExport;

        public static MainWindow Main //主页面
        {
            get { return main; }
        }

        public static LoginPage Login
        {
            get
            {
                if (login == null)
                {
                    login = new LoginPage();
                }
                //     login.ToDefault();
                return login;
            }
        }

        public static QuesGameSeclectPage Questionandgame //问卷和游戏选择
        {
            get
            {
                if (questionandgame == null)
                {
                    questionandgame = new QuesGameSeclectPage();
                }
                // questionandgame.ToDefault();
                return questionandgame;
            }
        }

        public static GamePage Game //游戏界面
        {
            get
            {
                if (game == null)
                {
                    game = new GamePage();
                }
                return game;
            }
        }

        public static QuestionPage1 Question1  //问卷一
        {
            get
            {
                if (question1 == null)
                {
                    question1 = new QuestionPage1();
                }
                // question1.ToDefault();
                return question1;
            }
        }

        public static QuestionPage2 Question2  //问卷二
        {
            get
            {
                if (question2 == null)
                {
                    question2 = new QuestionPage2();
                }
                // question2.ToDefault();
                return question2;
            }
        }

        public static SceneSelectPage SceneSelect  //场景选择
        {
            get
            {
                if (sceneSelect == null)
                {
                    sceneSelect = new SceneSelectPage();
                }
                return sceneSelect;
            }
        }

        public static ScenePage Scene  //场景
        {
            get
            {
                if (scene == null)
                {
                    scene = new ScenePage();
                }
                return scene;
            }
        }

        public static EducationPage Education
        {
            get
            {
                if (education == null)
                {
                    education = new EducationPage();
                }
                return education;
            }
        }

        public static EducationLoadPage EducationLoad
        {
            get
            {
                if (educationLoad == null)
                {
                    educationLoad = new EducationLoadPage();
                }
                return educationLoad;
            }
        }

        public static Education_educatePage Education_educate
        {
            get
            {
                if (education_educate == null)
                {
                    education_educate = new Education_educatePage();
                }
                return education_educate;
            }
        }

        public static EducationSelectPage EducationSelect
        {
            get
            {
                if (educationSelect == null)
                {
                    educationSelect = new EducationSelectPage();
                }
                return educationSelect;
            }
        }


        public static DataExportPage DataExport
        {
            get
            {
                if (dataExport == null)
                {
                    dataExport = new DataExportPage();
                }
                return dataExport;
            }
        }


        //   public bool testConnection()
        //   {
        //       UDPTest test = new UDPTest(udpControl.Port);
        //       Thread thread = new Thread(test.test);
        //       thread.Start();
        //       if (thread.Join(TimeSpan.FromSeconds(2)))
        //       {
        //           thread.Abort();
        //       }
        //       test.close();
        //       return test.Connected;
        //   }//udp

    }
}


