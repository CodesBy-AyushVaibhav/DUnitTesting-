using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public static void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator = new ();

            //Act

            int result = calculator.AddNumbers(10, 20);

            //Assert
            Assert.Equals(30, result);

        }
    }
}
