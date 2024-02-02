using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [TestFixture]
    public class GreadingCalculatorNUnitTests
    {
        //create GreadingCalculator object
        private GreadingCalculator greadingCalculator;

        [SetUp]
        public void setup() 
        {
        greadingCalculator = new GreadingCalculator();

        }

        [Test]
        public void GetGrade_WhenScoreIsGreaterThan90AndAttendencePercentageIsGreaterThan80_ReturnA()
        {
            //Arrange
            greadingCalculator.Score = 91;
            greadingCalculator.AttendencePercentage = 81;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("A"));
        }

        // Test case for Score is greater than 80 and AttendencePercentage is greater than 70
        [Test]
        public void GetGrade_WhenScoreIsGreaterThan80AndAttendencePercentageIsGreaterThan70_ReturnB()
        {
            //Arrange
            greadingCalculator.Score = 81;
            greadingCalculator.AttendencePercentage = 71;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        // Test case for Score is greater than 70 and AttendencePercentage is greater than 60
        [Test]
        public void GetGrade_WhenScoreIsGreaterThan70AndAttendencePercentageIsGreaterThan60_ReturnC()
        {
            //Arrange
            greadingCalculator.Score = 71;
            greadingCalculator.AttendencePercentage = 61;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("C"));
        }

        // Test case for Score is greater than 60 and AttendencePercentage is greater than 50
        [Test]
        public void GetGrade_WhenScoreIsGreaterThan60AndAttendencePercentageIsGreaterThan50_ReturnD()
        {
            //Arrange
            greadingCalculator.Score = 61;
            greadingCalculator.AttendencePercentage = 51;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("D"));
        }

        // Test case for Score is greater than 50 and AttendencePercentage is greater than 40
        [Test]
        public void GetGrade_WhenScoreIsGreaterThan50AndAttendencePercentageIsGreaterThan40_ReturnE()
        {
            //Arrange
            greadingCalculator.Score = 51;
            greadingCalculator.AttendencePercentage = 41;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("E"));
        }
       
        
        [Test]
        public void GetGrade_WhenScoreIsLessThan50AndAttendencePercentageIsLessThan40_ReturnF()
        {
            //Arrange
            greadingCalculator.Score = 49;
            greadingCalculator.AttendencePercentage = 39;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("F"));
        }
        // Test case for Score 95 Attendece 65 return B grade
        [Test]
        public void GradeCalculator_WhenScoreIs95Attendence65_ReturnB()
        {
            //Arrange
            greadingCalculator.Score = 95;
            greadingCalculator.AttendencePercentage = 65;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        //Create multiple Testcase scenarios for GetGrade method with different input values (95,55) (65,55) (50,90) parameter score and attendence for F grade
        [Test]
        [TestCase(15, 5)]
        [TestCase(45, 35)]
        [TestCase(30, 20)]
        public void GradeCalculator_WhenScoreIs95Attendence65_ReturnF(int score, int attendence)
        {
            //Arrange
            greadingCalculator.Score = score;
            greadingCalculator.AttendencePercentage = attendence;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("F"));
        }

        //create a Test with multiple test cases for GetGrade for all Grade Logical Scenarios
        [Test]
        [TestCase(95, 65, "B")]
        [TestCase(85, 75, "B")]
        [TestCase(75, 65, "C")]
        [TestCase(65, 55, "D")]
        [TestCase(55, 45, "E")]
        [TestCase(45, 35, "F")]
        public void GradeCalculator_WhenScoreIs95Attendence65_ReturnF(int score, int attendence, string expectedGrade)
        {
            //Arrange
            greadingCalculator.Score = score;
            greadingCalculator.AttendencePercentage = attendence;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo(expectedGrade));
        }

        //create a Test with multiple test cases for GetGrade for all Grade Logical Scenarios
        [Test]
        [TestCase(95, 65, "B")]
        [TestCase(85, 75, "B")]
        [TestCase(75, 65, "C")]
        [TestCase(65, 55, "D")]
        [TestCase(55, 45, "E")]
        [TestCase(45, 35, "F")]
        public void GradeCalculator_WhenScoreIs95Attendence65_ReturnF1(int score, int attendence, string expectedGrade)
        {
            //Arrange
            greadingCalculator.Score = score;
            greadingCalculator.AttendencePercentage = attendence;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo(expectedGrade));
        }

        //create a Test method with multiple testcases AllGradeLogicalScenarios 
        [Test]
        [TestCase(95, 85, ExpectedResult = "A")]
        [TestCase(95, 65,ExpectedResult = "C")]
        [TestCase(85, 75,ExpectedResult = "B")]
        [TestCase(75, 65,ExpectedResult = "C")]
        [TestCase(65, 55,ExpectedResult = "D")]
        [TestCase(55, 45,ExpectedResult = "E")]
        [TestCase(45, 35,ExpectedResult = "F")]
        public string GradeCalculator_AllGradeScenarios_ReturnF2(int score, int attendence)
        {
            //Arrange
            greadingCalculator.Score = score;
            greadingCalculator.AttendencePercentage = attendence;

            //Act
            string result = greadingCalculator.GetGrade();

            //Assert
            return result;
        }


    }
}
