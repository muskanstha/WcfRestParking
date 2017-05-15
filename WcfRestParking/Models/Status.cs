using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestParking.Models
{
    public class Status
    {
        public string SpotNo { get; set; }
        public string IsFree { get; set; }
        public decimal Distance { get; set; }

        public Status(string spotNo, string isFree, decimal distance)
        {
            SpotNo = spotNo;
            IsFree = isFree;
            Distance = distance;
        }

        public Status()
        {
            
        }

    }
}