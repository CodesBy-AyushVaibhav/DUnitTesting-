﻿using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        private Customer customer;     //Global Initilization
        [SetUp]
        public void Setup() 
        { 
            customer = new Customer();
        }

        [Test]
        public void CombineNames_InputFirstAndLastName_ReturnFullName() 
        { 
            //Multiple Assert
            //Customer customer = new Customer();           //Initialize Globally
            string fullName = customer.GreetAndCombineNames("Ayush", "Vaibhav");

            Assert.Multiple(() =>
            {
                Assert.That(fullName, Is.EqualTo("Hello, Ayush Vaibhav"));

                ClassicAssert.AreEqual(fullName, ("Hello, Ayush Vaibhav"));

                Assert.That(fullName, Does.Contain("ayush vaibhav").IgnoreCase);

                Assert.That(fullName, Does.StartWith("Hello,"));

                Assert.That(fullName, Does.EndWith("Vaibhav"));

                Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
            
           
        }
        [Test]
        public void GreetMessage_NotGreated_Return_Null()
        {
            //arrange
            //var customer = new Customer();    //Initialize Globally

            //act

            //Assert
            ClassicAssert.IsNull(customer.GreetMessage);

        }

        [Test]
        public void DiscountCheck_DiscountCustomer_DiscountRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));

        }

        [Test]
        public void GreetMessage_GreetWithoutLastName_ReturnNotNull()
        {
            customer.GreetAndCombineNames("Ayush", "");
            ClassicAssert.IsNotNull(customer.GreetMessage);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }
        [Test]
        public void GreetCheaker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => 
            customer.GreetAndCombineNames("", "Vaibhav"));

            ClassicAssert.AreEqual("Empty First Name", exceptionDetails.Message);
           
            //Same function with Assert.That Method.

            Assert.That(()=>customer.GreetAndCombineNames("","Vaibhav"), 
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            //************************************************************************

            //Only check the Argument Exception 

            Assert.Throws<ArgumentException>(() =>
           customer.GreetAndCombineNames("", "Vaibhav"));

                   
            Assert.That(() => customer.GreetAndCombineNames("", "Vaibhav"),
                Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

       
        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 100;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomers>());
        }
    }
}
