using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfRestParking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfRestParking.Models;

namespace WcfRestParking.Tests
{
    [TestClass()]
    public class ParkingService1Tests
    {
        private IParkingService1 service;
        private Status status;
        [TestInitialize]
        public void TestStart()
        {
            service = new ParkingService1();
            status = new Status();
        }
        [TestMethod()]
        public void GetStatusesTest()
        {
            IList<Status> rows = service.GetStatuses();
            Assert.AreEqual(6, rows.Count);
        }
        [TestMethod]
        public void NullTest()
        {
            try
            {
                status.spotNO = null;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Value cannot be null", ex.Message);
            }
        }

    }
}