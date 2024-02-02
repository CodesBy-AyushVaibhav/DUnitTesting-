using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class GreadingCalculator
    {
        // Generate two int properties one score and AttendencePercentage
        public int Score { get; set; }
        public int AttendencePercentage { get; set; }

        //create string return type Method GetGrade
        public string GetGrade()
        {
            //if score is greater than 90 and AttendencePercentage is greater than 80
            if (Score > 90 && AttendencePercentage > 80)
            {
                //return A
                return "A";
            }
            //if score is greater than 80 and AttendencePercentage is greater than 70
            else if (Score > 80 && AttendencePercentage > 70)
            {
                //return B
                return "B";
            }
            //if score is greater than 70 and AttendencePercentage is greater than 60
            else if (Score > 70 && AttendencePercentage > 60)
            {
                //return C
                return "C";
            }
            //if score is greater than 60 and AttendencePercentage is greater than 50
            else if (Score > 60 && AttendencePercentage > 50)
            {
                //return D
                return "D";
            }
            //if score is greater than 50 and AttendencePercentage is greater than 40
            else if (Score > 50 && AttendencePercentage > 40)
            {
                //return E
                return "E";
            }
            //if score is less than 50 and AttendencePercentage is less than 40
            else
            {
                //return F
                return "F";
            }
        }
    }
}
