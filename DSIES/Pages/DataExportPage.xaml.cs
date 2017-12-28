using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DSIES.UDP;
using System.Windows.Threading;
using System.Printing;
using DSIES.Class.Model;
using System.Diagnostics;

namespace DSIES.Pages
{
    /// <summary>
    /// DataExportPage.xaml 的交互逻辑
    /// </summary>
    public partial class DataExportPage : Page
    {
        private double Value;
        private double Value2;

        public DataExportPage()
        {
            InitializeComponent();
            datagive();


        }


        public void datagive()
        {

            DateTime dt = DateTime.Now;
            date.Text = dt.ToShortDateString().ToString();//输出日期

            ID.Text = PageList.Login.Regular.Telephone;//编号即电话号

            //Value = double.Parse(PageList.Login.Regular.Totalscore_frist);
            //Value2 = double.Parse(PageList.Login.Regular.Totalscore_final);

            //Value = 75;
            //Value2 = 85;
            point_one.DataContext = Value;
            point_two.DataContext = Value2;
            score1_text.DataContext = Value;
            score2_text.DataContext = Value2;
            //DataContext = this;
            //  name_info.DataContext=
            name_info.Text = PageList.Login.Regular.Name;
            gender_info.Text = PageList.Login.Regular.Gender;
            age_info.Text = PageList.Login.Regular.Age;
            DrivingYears_info.Text = PageList.Login.Regular.DriAge;
            weizhang_info.Text = PageList.Login.Regular.Accident_times;
            job_info.Text = PageList.Login.Regular.Career;
            tele_info.Text = PageList.Login.Regular.Telephone;
            leftsight.Text = PageList.Login.Regular.Sight_left;
            rightsight.Text = PageList.Login.Regular.Sight_right;
            leftdeepsight.Text = PageList.Login.Regular.DeepSight_left;
            rightdeepsight.Text = PageList.Login.Regular.DeepSight_right;
            reaction.Text = PageList.Login.Regular.Reagency;
            shiguleixing_info.DataContext = shigu();
            Angry_info.Text = PageList.Login.Regular.Grade2;
            shiguqingxiang_score.Text = PageList.Login.Regular.Grade1;
            aihehua_score.Text = PageList.Login.Regular.Grade;
            first_qingxiang_grade.DataContext = shigu();
            shiguqingxiang_explain.Text = Sglx_Explain(PageList.Login.Regular.Grade1);
            first_qingxiang_explain.DataContext = shigu_explain();
            Angry_explain.Text = Angre_Explain(PageList.Login.Regular.Grade1);
            jianyi.Text = "从您的驾驶测试中，我们发现您是一个愤怒等级为" + PageList.Login.Regular.Grade1 + "的驾驶员，在驾驶过程中您的事故倾向是" + shigu() + "，故而有一下几点建议给您：" + "\n一：在驾驶过程中请您控制自己的情绪，注意不要发生愤怒等影响车辆驾驶的行为。\n二：在驾驶中请严格保持车距以及不良驾驶习惯，摒弃危险驾驶倾向。\n三：请您不要进行分心驾驶，分心驾驶的范围很广，大致包括开车使用手机或者导航等。\n" + "最后，为了您的生命健康以及出行安全，请严格按照本次驾驶教育进行改正，希望您成为一个优秀的，安全的驾驶员。";


            image_1.DataContext = PageList.Main.image_1;
            image_2.DataContext = PageList.Main.image_2;
            image_3.DataContext = PageList.Main.image_3;
            image_4.DataContext = PageList.Main.image_4;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public String Sglx_Explain(String Key)
        {
            switch(Key)
            {
                case "A": return "您的危险事故倾向相当低。但是在驾驶中也要注意安全，不能掉以轻心。";
                case "B": return "您的危险事故倾向比一般人要大，在不良驾驶环境下请小心驾驶。";
                case "C": return "您在生活中常常有发生事故的倾向，请在驾驶中注意调整心态，注意安全。";
                case "D": return "您常用一种危险方式进行驾驶，对其它人造成了影响，请控制自己的行为，不然不仅会害了别人，也会害了自己。";
                case "E": return "您的事故倾向已经达到顶点，请您在平常驾驶过程中时刻注意自己的操作，因为您的操作时刻可能发生事故，如果您没有意识到这个问题，请把这个问题铭记于心，因为危险离您特别近。";
                default: break;
            }
            return  "";
        }
        public String Angre_Explain(String key)
        {
            switch (key)
            {
                case "A": return "您的愤怒与烦恼的数量相当低。只有很少一部分人在测试中能得这么低的分数。您就属于这一少部分人！";
                case "B": return "您比事实上要比一般人更平静";
                case "C": return "您在生活中的烦恼总报以同等数量的愤怒。";
                case "D": return "您常用一种愤怒的方式来对待生活中所遇到的烦恼。您事实上比一般人更易激怒。";
                case "E": return "您是愤怒冠军，您被经常出现的狂怒反应所折磨，这种反应不能很快消失。在最初的羞辱过去很久之后，您或许还一直有一种消极情感。您或许在您所知道的人当中有鞭炮或莽夫之名。您可能经常会感到紧张头痛，血压也会经常升高。您的愤怒经常失去控制，非常冲动的爆发出敌意来，这种冲动有时会让您陷入麻烦。成人中只有很少一部分人像您这样做出激烈的反应。";
                default: break;
            }
            return "";
        }
        public String shigu( )
        {
            string word = null ;
            if (sceneselectData.education.Speeding == true || sceneselectData.education.Line == true || sceneselectData.education.Overtake == true)
                word += "直觉行为缺失";
            if (sceneselectData.education.Lighting == true)
                word+= "行为不规范";
            if (sceneselectData.education.Distraction == true)
                word+= "态度不端正";
            if (word == null)
                word = "操作完美";
            return word;
        }

        public String shigu_explain()
        {
            string word = null;
            if (sceneselectData.education.Speeding == true || sceneselectData.education.Line == true || sceneselectData.education.Overtake == true)
                word += "您在日常驾驶中对于相关技术操作未能有良好的把控，在紧要时刻不能做出较好的处理。建议您在日常驾驶中多注意与周边车辆保持距离，不要进行过激的操作，在日常中多学习相关技术，增加自己的操作知识，防止发生事故。";
            if (sceneselectData.education.Lighting == true)
                word += "您在日常驾驶中对于相关行为操作未能有良好的把控，对于道路情况以及本身的操作没有规范性认知。建议您在日常驾驶中多注意交通信号以及路边告示的指引，不进行过激的操作，在日常中多学习相关规范，增加自己的驾驶知识，对一些典型违法事故有所了解，防止发生事故。";
            if (sceneselectData.education.Distraction == true)
                word += "您在日常驾驶中对于相关规章未能有良好的了解，容易发生违法行为不自知，建议您在日常驾驶中多注意交通信号以及民警指示，防止发生闯红灯等违法操作，不进行过激的操作。在日常中多学习相关规范，增加自己的驾驶知识，对一些典型违法事故有所了解，且端正态度，尊重生命，防止发生事故";
            if (word == null)
                word = "您在日常驾驶中对于各种操作都有良好的把控与了解，请继续保持现状。";
            return word;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CU.MG_User.RegisterAdd(UserVariable.Grade, PageList.Login.Regular.Grade);
            CU.MG_User.RegisterAdd(UserVariable.Grade1, PageList.Login.Regular.Grade1);
            CU.MG_User.RegisterAdd(UserVariable.Grade2, PageList.Login.Regular.Grade2);
            CU.MG_User.RegisterAdd(UserVariable.Totalscore_frist, PageList.Login.Regular.Totalscore_frist);
            CU.MG_User.RegisterAdd(UserVariable.Totalscore_final, PageList.Login.Regular.Totalscore_final);
            CU.MG_User.RegisterAdd(UserVariable.Credit, PageList.Login.Regular.Credit);

            CU.MG_User.RegisterEnd();
            var pic = RenderVisaulToBitmap(printArea, 1214, 1370);
            PngBitmapEncoder saveEncoder = new PngBitmapEncoder();
            saveEncoder.Frames.Add(BitmapFrame.Create(pic));
            System.IO.FileStream fs = System.IO.File.Open("..//..//..//用户报表//" + PageList.Login.Regular.Telephone + ".jpg", System.IO.FileMode.OpenOrCreate);
            CustomMessageBox.Show("温馨提示：", "save!");
            saveEncoder.Save(fs);
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(printArea, "Print Test");
            }
            print.IsEnabled = false;
        }
        RenderTargetBitmap RenderVisaulToBitmap(Visual vsual, int width, int height)
        {
            var rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            rtb.Render(vsual);
            return rtb;
        }
    }
}
