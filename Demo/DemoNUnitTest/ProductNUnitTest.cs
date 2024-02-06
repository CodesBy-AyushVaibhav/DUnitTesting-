using NUnit.Framework;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [TestFixture]
    public class ProductNUnitTest
    {
        //create a test method name GetProductPrice_PlatinumCustomer_ReturnsPriceWith20Discount
        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnsPriceWith20Discount()
        {
            Product product = new Product() { Price = 50.0 };
            var result = product.GetPrice(new Customer() { IsPlatinum = true });
            Assert.That(result, Is.EqualTo(40));
        }
       
    }
}
