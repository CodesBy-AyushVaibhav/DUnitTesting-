using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface iLogBook
    {
        public int LogSeveirty { get; set; }
        public string LogType { get; set; }
        void Message(string message);

        //create a new interface method named LogToDb takes string as a perimeter and return type bool
        bool LogToDb(string message);

        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);

        string MessageWithReturnStr(string message);

        bool LogWithOutputReasult(string str, out string outputstr);

        bool LogWithRefObject(ref Customer customer);

    }
    public class LogBook : iLogBook
    {
        //public int LogSeverity 
        //{ get ; set ; }
        public string LogType { get; set ; }
        public int LogSeveirty { get; set; }

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

        public bool LogWithOutputReasult(string str, out string outputstr)
        {
            //throw new NotImplementedException();
            outputstr = "Hello " + str;
            return true;
        }

        public bool LogWithRefObject(ref Customer customer)
        {
            //throw new NotImplementedException();
            return true;



        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnStr(string message)
        {
            //throw new NotImplementedException();
            Console.WriteLine(message);
            return message.ToLower();
        }
    }
    //public class LogFaker : iLogBook
    //{
    //    public void Message(string message)
    //    {
           
    //    }
    //}

}
