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
        //create a new instance of BankAccount
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
        //[TestCase(100, 200)]
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



        //******************************************************************************
        [Test]
        
        public void BankLogDummy_LogMoqString_ReturnTrue()
        {
            var logMoq = new Moq.Mock<iLogBook>();
            string desiredOutput = "hello";
            logMoq.Setup(x => x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str)=>str.ToLower());

            Assert.That(logMoq.Object.MessageWithReturnStr("HELLO"), Is.EqualTo(desiredOutput));
           

            
        }

        //generate a Test Method BankLogDummy_LogMockStringOutputStr_ReturnTrue
        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMoq = new Moq.Mock<iLogBook>();
            string desiredOutput = "Hello World";
            logMoq.Setup(x => x.LogWithOutputReasult(It.IsAny<string>(), out desiredOutput)).Returns(true);

            string outputStr;
            var result = logMoq.Object.LogWithOutputReasult("World", out outputStr);
            Assert.That(result, Is.EqualTo(true));
            Assert.That(outputStr, Is.EqualTo(desiredOutput));
        }

        //create a test method name BankLogDummy_LogMockRefObject_ReturnTrue
        [Test]
        public void BankLogDummy_LogMockRefObject_ReturnTrue()
        {
            var logMoq = new Moq.Mock<iLogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();
            logMoq.Setup(x => x.LogWithRefObject(ref customer)).Returns(true);    

            ClassicAssert.IsTrue(logMoq.Object.LogWithRefObject(ref customer));
            ClassicAssert.IsFalse(logMoq.Object.LogWithRefObject(ref customerNotUsed));

        }

        //create a test method name it "BankLogDummy_SetAndGetLogTypeAndSeveirtyMock_MockTest"
        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeveirtyMock_MockTest()
        {
            
            var logMoq = new Moq.Mock<iLogBook>();
            logMoq.Setup(x => x.LogSeveirty).Returns(10);
            //logMoq.SetupProperty(x => x.LogType).SetReturnsDefault("Warning");

            

            logMoq.Object.LogSeveirty = 100;

            //logMoq.Object.LogType = "Error";
            //logMoq.Object.Seveirty = "High";

            //Assert.That(logMoq.Object.LogType, Is.EqualTo("Warning"));
            Assert.That(logMoq.Object.LogSeveirty, Is.EqualTo(10));
        
            //CallBack

            string logTemp = "Hello, ";
            logMoq.Setup(x => x.LogToDb(It.IsAny<string>())).
                Returns(true).Callback((string str )=> logTemp+=str);

            logMoq.Object.LogToDb("Ayush");

            Assert.That(logTemp, Is.EqualTo("Hello, Ayush"));


            //CallBack

            int counter = 5;
            logMoq.Setup(x => x.LogToDb(It.IsAny<string>())).
                Returns(true).Callback(() =>counter++);

            logMoq.Object.LogToDb("Ayush");

            Assert.That(counter, Is.EqualTo(6));

        }

       

     
    




    }



}
