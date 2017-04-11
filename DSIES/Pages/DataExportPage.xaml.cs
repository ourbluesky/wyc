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
using DSIES;

namespace DSIES.Pages
{
    /// <summary>
    /// DataExportPage.xaml 的交互逻辑
    /// </summary>
    public partial class DataExportPage : Page
    {
        private double _value;
        private double _value2;
        public DataExportPage()
        {
            
            InitializeComponent();
            printData();
            //Value = PageList.Main.Regular.Score1;
            //Value2 = PageList.Main.Regular.Score2;
            Value = 75;
            Value2 = 85;
            DataContext = this;
            //  name_info.DataContext=
        }

        public void printData()
        {
            name_info.DataContext =  PageList.Main.Regular.Name;
            gender_info.DataContext =  PageList.Main.Regular.Gender;
            age_info.DataContext = PageList.Main.Regular.Age;
            DrivingYears_info.DataContext = PageList.Main.Regular.DriAge;
            weizhang_info.DataContext= PageList.Main.Regular.Accident_times;
            job_info.DataContext =PageList.Main.Regular.Career ;
            tele_info.DataContext= PageList.Main.Regular.Telephone ;
            leftsight.DataContext= PageList.Main.Regular.Sight_left;
            rightsight.DataContext= PageList.Main.Regular.Sight_right ;
            leftdeepsight.DataContext =PageList.Main.Regular.DeepSight_left;
            rightdeepsight.DataContext= PageList.Main.Regular.DeepSight_right;
            reaction.DataContext= PageList.Main.Regular .Reagency;
            score1_text.DataContext = Value;
            score2_text.DataContext =Value2;
            shiguleixing_info.DataContext = "分心驾驶";
            Angry_info.DataContext = PageList.Main.Regular.Grade2;
            shiguqingxiang_score.DataContext = PageList.Main.Regular.Grade1;
            aihehua_score.DataContext = PageList.Main.Regular.Grade;
            first_qingxiang_grade.DataContext = "分心驾驶";
            shiguqingxiang_explain.DataContext = Sglx_Explain(PageList.Main.Regular.Grade1);
            first_qingxiang_explain.DataContext = "驾驶员分心是驾驶员自愿或非自愿的转移驾驶任务（不是由于酒精、药物、疲劳等因素），转移任务是因为驾驶员执行另外的任务而短暂地将注意力集中在与驾驶无关的事件、物体和人上，这种转变降低了驾驶员的环境意识、决策水平和操作技能，您在驾驶过程中分心驾驶倾向严重，请您小心驾驶";
            Angry_explain.DataContext = Angre_Explain(PageList.Main.Regular.Grade1);
            jianyi.DataContext = "从您的驾驶测试中我们发现您是一个愤怒等级一般并且驾驶行为倾向一般的驾驶员，在驾驶过程中您的事故倾向是分心驾驶，故而有一下几点建议给您：\n一：在驾驶过程中请您控制自己的情绪，注意不要发生愤怒等影响车辆驾驶的行为。\n二：在驾驶中请严格保持车距以及不良驾驶习惯，摒弃危险驾驶倾向。\n三：请您不要进行分心驾驶，分心驾驶的范围很广，大致包括开车使用手机或者导航等。\n最后，为了您的生命健康以及出行安全，请严格按照本次驾驶教育进行改正，希望您成为一个优秀的，安全的驾驶员。";
        }
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        public double Value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                OnPropertyChanged("Value2");
            }
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
                case "A": return "您的愤怒与烦恼的数量相当低。只有很少一部分人在测试中能得这么低的分数。你就属于这一少部分人！";
                case "B": return "您比事实上要比一般人更平静";
                case "C": return "您在生活中的烦恼总报以同等数量的愤怒。";
                case "D": return "您常用一种愤怒的方式来对待生活中所遇到的烦恼。你事实上比一般人更易激怒。";
                case "E": return "您是愤怒冠军，你被经常出现的狂怒反应所折磨，这种反应不能很快消失。在最初的羞辱过去很久之后，你或许还一直有一种消极情感。你或许在你所知道的人当中有鞭炮或莽夫之名。你可能经常会感到紧张头痛，血压也会经常升高。你的愤怒经常失去控制，非常冲动的爆发出敌意来，这种冲动有时会让你陷入麻烦。成人中只有很少一部分人像你这样做出激烈的反应。";
                default: break;
            }
            return "";
        }
    }
}
