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
            //Customer customer = new Customer();           //Initialize Globally
            string fullName = customer.GreetAndCombineNames("Ayush", "Vaibhav");
            Assert.That(fullName, Is.EqualTo("Hello, Ayush Vaibhav"));
            
            ClassicAssert.AreEqual(fullName,("Hello, Ayush Vaibhav"));
            
            Assert.That(fullName, Does.Contain("ayush vaibhav").IgnoreCase);

            Assert.That(fullName, Does.StartWith("Hello,"));

            Assert.That(fullName, Does.EndWith("Vaibhav"));

            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
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
    }
}
