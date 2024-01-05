using NUnit.Framework;
using NUnit.Framework.Legacy;
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
            ClassicAssert.AreEqual(30, result);

        }

        [Test]
        public void IsOddCheaker_InputEvenNumber_ReturnFalse()
        { 
         Calculator calc = new ();
            bool isOdd = calc.IsOddNumber(10);
            Assert.That(isOdd, Is.EqualTo(false));
            ClassicAssert.IsFalse(isOdd);                  //Both ways are same
        }
    }
}
