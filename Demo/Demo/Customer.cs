using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Customer
    {

        public int Discount = 15;
        public string GreetMessage { get; set; }
        public string GreetAndCombineNames(string FirstName, string LastName)
        {
            GreetMessage = $"Hello, {FirstName} {LastName}";

            Discount = 20;
            return GreetMessage; 
        }
    }
}
