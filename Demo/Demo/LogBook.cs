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
    }
    public class LogBook : iLogBook
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class LogFaker : iLogBook
    {
        public void Message(string message)
        {
           
        }
    }

}
