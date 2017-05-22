using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestParking.Models
{
    /// <summary>
    /// CLass for the log table in database with matching data type
    /// </summary>
    public class Status
    {
        public string SpotNo { get; set; }
        public string IsFree { get; set; }
        public decimal Distance { get; set; }
        public string spotNO
        {
            get { return SpotNo; }
            set
            {
                if (value == null) throw new Exception("Value cannot be null");
                SpotNo = value;
            }
        }

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