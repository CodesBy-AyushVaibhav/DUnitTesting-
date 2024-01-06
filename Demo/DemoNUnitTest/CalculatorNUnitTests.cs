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
            Calculator calculator = new();

            //Act

            int result = calculator.AddNumbers(10, 20);

            //Assert
            ClassicAssert.AreEqual(30, result);

        }

        [Test]
        public void IsOddCheaker_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new();
            bool isOdd = calc.IsOddNumber(10);
            Assert.That(isOdd, Is.EqualTo(false));
            ClassicAssert.IsFalse(isOdd);                  //Both ways are same
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddCheaker_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calc = new();
            bool isOdd = calc.IsOddNumber(10);
            Assert.That(isOdd, Is.EqualTo(false));
        }

        //Combining Multiple Unit Test

        [Test]
        [TestCase(10,ExpectedResult = false)]
        [TestCase(13,ExpectedResult = true)]

        public bool IsOddCheaker_InputNumber_RetrunTrueIfOdd(int a)
        {
            Calculator calc = new();
            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(4.5,10.5)]   //15.9
        [TestCase(5.43,10.53)]   //15.93
        [TestCase(5.49,10.59)]   //16.08

        public static void AddNumbers_InputTwoDouble_GetCorrectAddition(double a,double b)
        {
            //Arrange
            Calculator calculator = new();

            //Act

            double result = calculator.AddNumbersDouble(a, b);

            //Assert
            ClassicAssert.AreEqual(15.9, result,1);          // 1 is used as delta double reasult with range [-1,+1]

        }

    }

}

