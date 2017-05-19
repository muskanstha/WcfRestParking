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
        private ParkingService1 s = new ParkingService1();
        [TestMethod()]
        public void GetStatusesTest()
        {
            Assert.AreEqual(6,s.GetStatuses().Count);
        }

        [TestMethod()]
        public void CreateStatus()
        {
            Status aStatus= new Status(){Distance = 2,SpotNo = "3A",IsFree = "No"};
            int size = s.GetStatuses().Count;
            s.CreateStatus(aStatus);
            Assert.AreEqual(size+1,s.GetStatuses().Count);

        }
        [TestMethod]
        public void ChangeStatus()
        {
            
            var aStatus = new Status(){SpotNo = "2A", Distance=3};
            Status ups = s.GetStatuses().Last();
            ups.IsFree = "Yes";
            s.ChangeStatus(aStatus);
            Assert.Equals(ups, aStatus);

        }
    }
}