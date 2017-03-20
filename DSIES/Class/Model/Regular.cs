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
       private string name;
       private string password;
       private string telphone; 
       private string age;
       private string driAge;
       private string carrer;
       private string gender;
       private string deepSight_left;
       private string deepSight_right;
       private string sight_left;
       private string sight_right;
       private string reagency;
       private string breaktime;
       private string score;
       private string grade1;
       private string grade2;
       private string score1;
       private string score2;
       
       public Regular() { }
       public Regular
           (
           string name,
           string password,
           string telphone,
           string age,
           string driAge,
           string carrer,
           string gender,
           string deepSight_left,
           string deepSight_right,
           string sight_left,
           string sight_right,
           string reagency,
           string breaktime,
           string score,
           string grade1,
           string grade2,
           string score1,
           string score2
           )
       {
           this.Name = name;
           this.Telphone = telphone;
           this.Password = password;
           this.age = age;
           this.driAge = driAge;
           this.carrer = carrer;
           this.gender = gender;
           this.deepSight_left = deepSight_left;
           this.deepSight_right = deepSight_right;
           this.sight_right = sight_right;
           this.sight_left = sight_left;
           this.reagency = reagency;
           this.breaktime = breaktime;
           this.score = score;
           this.score1 = score1;
           this.score2 = score2;
           this.grade1 = grade1;
           this.grade2 = grade2;
       }
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
       
       public string Breaktime
        {
            get { return breaktime; }
            set { breaktime = value; }
        }
       public string Score
       {
           get { return score; }
           set { score = value; }
       }
       public string Score1
       {
           get { return score1; }
           set { score1 = value; }
       }
       public string Score2
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
    }
}
