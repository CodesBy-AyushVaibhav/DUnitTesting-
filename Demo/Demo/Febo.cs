using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Febo
    {
        //create constructor and initilize the range = 5
        public Febo()
        {
            Range = 5;
        }   
        public int Range { get; set; }
        //create a method name GetFiboSeries with List Return type
        public List<int> GetFiboSeries()
        {
            //create a list of int type
            List<int> feboSeries = new List<int>();
            //create two int variables
            int firstNumber = 0;
            int secondNumber = 1;
            //add firstNumber to list
            feboSeries.Add(firstNumber);
            //add secondNumber to list
            feboSeries.Add(secondNumber);
            //create a for loop
            for (int i = 2; i < Range; i++)
            {
                //create a int variable
                int nextNumber = firstNumber + secondNumber;
                //add nextNumber to list
                feboSeries.Add(nextNumber);
                //assign secondNumber to firstNumber
                firstNumber = secondNumber;
                //assign nextNumber to secondNumber
                secondNumber = nextNumber;
            }
            //return feboSeries
            return feboSeries;
        }

     
    }
}
