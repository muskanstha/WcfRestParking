using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestParking.Models
{
    /// <summary>
    /// jesper
    /// CLass for the log table in database with matching data type
    /// </summary>
    public class Status
    {
        public string SpotNo { get; set; }
        public string IsFree { get; set; }
        public decimal Distance { get; set; }
        /// <summary>
        /// By: bipin . prevent null value
        /// </summary>
        public string spotNO
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
        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="spotNo"></param>
        /// <param name="isFree"></param>
        /// <param name="distance"></param>
        public string IsFree { get; set; }
        public decimal Distance { get; set; }


        public Status(string spotNo, string isFree, decimal distance)
        {
            SpotNo = spotNo;
            IsFree = isFree;
            Distance = distance;
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public Status()
        {

        }

    }
}