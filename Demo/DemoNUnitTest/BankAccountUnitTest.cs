using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    /* [TestFixture]
     public class BankAccountUnitTest
     {
        private BankAccount bankAccount;
         //reating a new instance of BankAccount
         [SetUp]
         public void Setup()
         {
             bankAccount = new BankAccount(new LogFaker());      //passing a fake logbook

         }
         //generate test method name BankDeposit_Add100_ReturnTrue
         [Test]
         public void BankDeposit_Add100_ReturnTrue()
         {
             //Act
             var result = bankAccount.Deposit(100);
             //Assert
             ClassicAssert.IsTrue(result);
             Assert.That(bankAccount.GetCurrentBalance, Is.EqualTo(100));
         }

     }
    */
    //****************************Uning MoQ Framework*****************************************************

    [TestFixture]
    public class BankAccountUnitTest
    {
        private BankAccount account;
        //reating a new instance of BankAccount
        [SetUp]
        public void Setup()
        {
            

        }
        //generate test method name BankDeposit_Add100_ReturnTrue
        [Test]
        public void BankDepositLogFaker_Add100_ReturnTrue()
        {
            //Act
            BankAccount bankAccount = new(new LogFaker());      //passing a fake logbook
            var result = bankAccount.Deposit(100);
            //Assert
            ClassicAssert.IsTrue(result);
            Assert.That(bankAccount.GetCurrentBalance, Is.EqualTo(100));
        }




        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {

            var logMock = new Moq.Mock<iLogBook>();
            logMock.Setup(x => x.Message("Deposit Invoked"));



            //Act
            BankAccount bankAccount = new(logMock.Object);      //passing a fake logbook
            var result = bankAccount.Deposit(100);
            //Assert
            ClassicAssert.IsTrue(result);
            Assert.That(bankAccount.GetCurrentBalance, Is.EqualTo(100));
        }

    }



}
