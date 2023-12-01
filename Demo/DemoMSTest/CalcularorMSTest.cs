using Demo;

namespace DemoMSTest
{
    [TestClass]
    public class CalcularorMSTest
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act

            int result = calculator.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);

        }
    }
}