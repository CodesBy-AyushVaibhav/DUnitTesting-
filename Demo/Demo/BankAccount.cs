using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class BankAccount
    {
        // create a property for balance
        public int Balance { get; set; }
        private readonly iLogBook _iLogBook;

        //create a constructor and set the balance to 0
        public BankAccount(iLogBook logBook)
        {
            _iLogBook = logBook;
            Balance = 0;
        }




            // create a method to deposit money takes and int amount as a parameter and returns bool
            public bool Deposit(int amount)
        {
            _iLogBook.Message("Deposit Invoked");           //Retrun true
            _iLogBook.Message("");                      //Return false
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        //create a mathod name GetCurrentBalance that returns the balance
        public int GetCurrentBalance()
        {
            return Balance;
        }


    }
}
