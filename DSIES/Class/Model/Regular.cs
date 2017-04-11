using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIES.Class.Model;

namespace DSIES.Class.Model
{
   public class Regular:User
    {       
       public Regular() { }

       public Regular
           (
           string name,
           string password,
           string telephone,
           string age,
           string driAge,
           string carrer,
           string gender,
           string deepSight_left,
           string deepSight_right,
           string sight_left,
           string sight_right,
           string reagency,
           string accident_times,
           string grade,    //true代表AB点击次数大于CD点击次数   ,false代表相反
           int score1,
           string grade1,
           int score2,
           string grade2,
           string totalscore_frist,
           string totalscore_final,
           string credit
           
           )
       {
           this.Name = name;
           this.Telephone = telephone;
           this.Password = password;
           this.gender = gender;
           this.age = age;
           this.driAge = driAge;
           this.carrer = carrer;       
           this.deepSight_left = deepSight_left;
           this.deepSight_right = deepSight_right;
           this.sight_right = sight_right;
           this.sight_left = sight_left;
           this.reagency = reagency;
           this.accident_times = accident_times; 
           this.score1 = score1;
           this.score2 = score2;
           this.grade1 = grade1;
           this.grade2 = grade2;
           this.totalscore_frist=totalscore_frist;
           this.totalscore_final=totalscore_final;
           this.credit = credit;
       }

     //  private string name;
     //  private string password;
     //  private string telephone;
       private string gender="";
       private string age="";
       private string driAge = "";
       private string carrer = "";
       private string accident_times = "";     
       private string sight_left = "";
       private string sight_right = ""; 
       private string deepSight_left = "";
       private string deepSight_right = "";
       private string reagency = "";     
       private string grade = "";
       private string   grade1 = "";
       private string grade2 = "";
       private int score1=100;
       private int score2=100;
       private string totalscore_frist = "";
       private string totalscore_final = "";
       private string credit = "";
   

       public string Gender
       {
           get { return gender; }
           set { gender = value; }
       }
       public string Age
       {
           get { return age; }
           set { age = value; }
       }
       public string DriAge
       {
           get { return driAge; }
           set { driAge = value; }
       }
       public string Career
       {
           get { return carrer; }
           set { carrer = value; }
       }
       public string Accident_times
       {
           get { return accident_times; }
           set { accident_times = value; }
       }    
       public string Sight_left
       {
           get { return sight_left; }
           set { sight_left = value; }
       }
       public string Sight_right
       {
           get { return sight_right; }
           set { sight_right = value; }
       }
       public string DeepSight_left
       {
           get { return deepSight_left; }
           set { deepSight_left = value; }
       }
       public string DeepSight_right
       {
           get { return deepSight_right; }
           set { deepSight_right = value; }
       }
       public string Reagency
       {
           get { return reagency; }
           set { reagency = value; }     
       }  
       public string Grade
       {
           get { return grade; }
           set { grade = value; }
       }
       public int Score1
       {
           get { return score1; }
           set { score1 = value; }
       }
       public int Score2
       {
           get { return score2; }
           set { score2 = value; }
       }
       public string Grade1
       {
           get { return grade1; }
           set { grade1 = value; }
       }
       public string Grade2
       {
           get { return grade2; }
           set { grade2 = value; }
       }
       public string Totalscore_frist
       {
           get { return totalscore_frist; }
           set { totalscore_frist = value; }
       } 
       public string Totalscore_final
      {
          get { return totalscore_final; }
          set { totalscore_final = value; }
      }
      public string Credit
      {
          get { return credit; }
          set { credit = value; }
      }
    }
}
