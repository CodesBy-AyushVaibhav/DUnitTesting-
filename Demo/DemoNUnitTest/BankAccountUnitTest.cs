using Moq;
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
        //[Test]
        //public void BankDepositLogFaker_Add100_ReturnTrue()
        //{
        //    //Act
        //    BankAccount bankAccount = new(new LogFaker());      //passing a fake logbook
        //    var result = bankAccount.Deposit(100);
        //    //Assert
        //    ClassicAssert.IsTrue(result);
        //    Assert.That(bankAccount.GetCurrentBalance, Is.EqualTo(100));
        //}




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

        [Test]
        [TestCase(100, 200)]
        [TestCase(200,150)]
        public void BankWithdraw_Withdraw100With200_ReturnTrue(int balance , int withdraw) 
        {
            var logMoq = new Moq.Mock<iLogBook>();
            //logMoq.Setup(x => x.LogToDb("Withdrawl Amount,100")).Returns(true);
            logMoq.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMoq.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);

            //Act
            BankAccount bankAccount =new(logMoq.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);
            //Assert

            ClassicAssert.IsTrue(result);
        }

        //Create a test method name BankWithdraw_Withdraw300With200_ReturnFalse
        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200_ReturnFalse(int balance , int withdraw) 
        {
            var logMoq = new Moq.Mock<iLogBook>();
            //logMoq.Setup(x => x.LogToDb("Withdrawl Amount,100")).Returns(true);
            //logMoq.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMoq.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            //logMoq.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMoq.Setup(x => x.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1 ,Moq.Range.Inclusive))).Returns(false);


            //Act
            BankAccount bankAccount = new(logMoq.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);
            //Assert

            ClassicAssert.IsFalse(result);
        }

    }



}
