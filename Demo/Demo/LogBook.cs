using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface iLogBook
    {
        void Message(string message);

        //create a new interface method named LogToDb takes string as a perimeter and return type bool
        bool LogToDb(string message);

        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);


    }
    public class LogBook : iLogBook
    {
        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            //throw new NotImplementedException();
            if (balanceAfterWithdrawal>=0)
            {
                Console.WriteLine("Success");
                return true;

            }
            else
            {        
                Console.WriteLine("Failed");
                return false;
            }
        }

        public bool LogToDb(string message)
        {
            //throw new NotImplementedException();
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
    //public class LogFaker : iLogBook
    //{
    //    public void Message(string message)
    //    {
           
    //    }
    //}

}
