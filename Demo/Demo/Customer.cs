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

        public int OrderTotal { get; set; }

        public bool IsPlatinum { get; set; }
        public Customer()
        {
            IsPlatinum = false;
        }

        public string GreetAndCombineNames(string FirstName, string LastName)
        {
            if (String.IsNullOrEmpty(FirstName))
            {
                throw new ArgumentException("Empty First Name");
            }

            GreetMessage = $"Hello, {FirstName} {LastName}";

            Discount = 20;
            return GreetMessage; 
        }

        public CustomerType GetCustomerDetails()
        {
            if(OrderTotal<100)
            {
                return new BasicCustomer();
            }
            return new PlatinumCustomers();
        }
    }

    public class CustomerType
    {

    }

    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomers : CustomerType { }
}
