using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    //Add TestFixture attribute
    [TestFixture]
    public class FiboNUnitTest
    {
        //Generate a UnitTest for GetFiboSeries method
        [Test]
        public void FiboCheaker_Input1_ReturnFiboSeries()
        {
            List<int> expectedRange = new () { 0 };
            Febo febo = new();
            febo.Range = 1;

            List<int> result = febo.GetFiboSeries();

            //Assert.That(result, Is.EqualTo(expectedRange));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Not.Empty);


        }
    }
}
