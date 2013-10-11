using FundGrid.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundGrid.Tests
{
    [TestFixture]
    public class DevelopmentTool
    {
        [Test]
        public void PayThroughPaypal()
        {
            var paypalRepo = new PaymentRepository();
            var x = paypalRepo.PayUsingPaypal(100.00m);
        }
    }
}
