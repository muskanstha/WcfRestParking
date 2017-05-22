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
        private string _SpotNo;
        public string SpotNo
        {
            get { return _SpotNo; }
            set
            {
                if (value == null) throw new Exception("Value cannot be null");
                _SpotNo = value;
            }
        }
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