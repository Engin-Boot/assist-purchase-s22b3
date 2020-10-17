using AssistPurchase.Repositories.Abstractions;
using AssistPurchase.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AssistPurchase.Test.DatabaseTest
{
    public class CustomerDbTest
    {
        private readonly IMonitoringRepository _customerrepo;
        public CustomerDbTest()
        {
            _customerrepo = new CustomerMonitoringRepository();
        }
        [Fact]
        public void TestShowAllC()
        {
            // Thread.Sleep(500);
            var productList = _customerrepo.GetAllAlerts();
            Assert.True(productList.Any());
        }

    }
}
