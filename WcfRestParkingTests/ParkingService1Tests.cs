using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfRestParking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfRestParking.Tests
{
    [TestClass()]
    public class ParkingService1Tests
    {
        private ParkingService1 s = new ParkingService1();
        [TestMethod()]
        public void GetStatusesTest()
        {
            Assert.AreEqual(6,s.GetStatuses().Count);
        }
    }
}