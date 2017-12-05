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
using System.Windows.Input;
//using DSIES.UDP;
using DSIES.Class.Model;
using DSIES.Pages.Admin;
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
        public int i = 0;
        public RenderTargetBitmap image_1;
        public RenderTargetBitmap image_2;
        public RenderTargetBitmap image_3;
        public RenderTargetBitmap image_4;
        Question question = new Question();
        internal Question QUESTION
        {
            get { return question; }
            set { question = value; }
        }

        //LoginData logindata = new LoginData();
        //internal LoginData LOGINDATA
        //{
        //    get { return logindata; }
        //    set { logindata = value; }
        //}

        AdminLoginData adminlogindata = new AdminLoginData();
        internal AdminLoginData ADMINLOGINDATA
        {
            get { return adminlogindata; }
            set { adminlogindata = value; }
        }

        Game game = new Game();
        internal Game GAME
        {
            get { return game; }
            set { game = value; }
        }

        //Education education = new Education();
        //internal Education EDUCATION
        //{
        //    get { return education; }
        //    set { education = value; }
        //}

        public MainWindow()
        {
            InitializeComponent();
         
            setPage(PageList.Login);
        }


        /*   internal Player Player
        {
            get { return player; }
            set { player = value; }
        }*/

        //User user = new User();
        //internal User User
        //{
        //    get { return user; }
        //    set
        //    {
        //        user = value;
        //        if (user != null)
        //        {
        //            LogOutButtonVisiable();
        //        }
        //        else
        //        {
        //            LogOutButtonInvisiable();
        //        }
        //    }
        //}

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

        void init()
        {
            PageList.PageInit();
            game = new Game();
            adminlogindata = new AdminLoginData();
            question = new Question();

            i = 0;
        }



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
            init();//init上边有定义
            this.setPage(PageList.Login);
            
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
            this.setPage(PageList.AdminLogin);
            //this.init();//init上边有定义
        }

        public void AdminButtonVisiable() //管理员登录
        {
            AdminBtn.Visibility = System.Windows.Visibility.Visible;
        }

        public void AdminButtonInvisiable() //管理员登录
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }


    public static class PageList                 //每个页面
    {
        static MainWindow main = (MainWindow)Application.Current.MainWindow;
        static LoginPage login;
        static AdminLoginPage adminlogin;
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
        //static DataExportPage dataExport;

        static AdminMainPage adminmain;
        static InquiryUserPage inquiryuser;
        static UpdateUserPage updateuser;
        static PrintReportPage printreport;


        public static AdminMainPage AdminMain
        {
            get
            {
                if (adminmain == null)
                {
                    adminmain = new AdminMainPage();
                }
                //     login.ToDefault();
                return adminmain;
            }
            set { adminmain = value; }
        }

        public static InquiryUserPage InquiryUser
        {
            get
            {
                if (inquiryuser == null)
                {
                    inquiryuser = new InquiryUserPage();
                }
                //     login.ToDefault();
                return inquiryuser;
            }
            set { inquiryuser = value; }
        }

        public static UpdateUserPage UpdateUser
        {
            get
            {
                if (updateuser == null)
                {
                    updateuser = new UpdateUserPage();
                }
                //     login.ToDefault();
                return updateuser;
            }
            set { updateuser = value; }
        }

        public static PrintReportPage PrintReport
        {
            get
            {
                if (printreport == null)
                {
                    printreport = new PrintReportPage();
                }
                //     login.ToDefault();
                return printreport;
            }
            set { printreport = value; }
        }


        public static MainWindow Main //主页面
        {
            get { return main; }
            set { main = value; }
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
            set { login = value; }
        }

        public static AdminLoginPage AdminLogin
        {
            get
            {
                if (adminlogin == null)
                {
                    adminlogin = new AdminLoginPage();
                }
                //     login.ToDefault();
                return adminlogin;
            }
            set { adminlogin = value; }
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
            set { questionandgame = value; }
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
            set { game = value; }
        }

        public static QuestionPage1 Question1  //问卷一
        {
            get
            {
                if (question1 == null)
                {
                    question1 = new QuestionPage1();
                }
                return question1;
            }
            set { question1 = value; }
        }

        public static QuestionPage2 Question2  //问卷二
        {
            get
            {
                if (question2 == null)
                {
                    question2 = new QuestionPage2();
                }
                return question2;
            }
            set { question2 = value; }
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
            set { sceneSelect = value; }
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
            set { scene = value; }
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
            set { education = value; }
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
            set { educationLoad = value; }
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
            set { education_educate = value; }
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
            set { educationSelect = value; }
        }

        //public static DataExportPage DataExport
        //{
        //    get
        //    {
        //        if (dataExport == null)
        //        {
        //            dataExport = new DataExportPage();
        //        }
        //        return dataExport;
        //    }
        //    set { dataExport = value; }
        //}


        public static void PageInit()
        {
            
            AdminMain = new AdminMainPage();
            InquiryUser = new InquiryUserPage();
            UpdateUser = new UpdateUserPage();
            PrintReport = new PrintReportPage();
            UpdateUser = new UpdateUserPage();
            AdminLogin = new AdminLoginPage();

            Login = new LoginPage();

            Questionandgame = new QuesGameSeclectPage();
            Game = new GamePage();
            Question1 = new QuestionPage1();
            Question2 = new QuestionPage2();
            //DataExport = new DataExportPage();
        }
    }
}


