﻿using System;
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
        /// <summary>
        /// By: bipin . prevent null value
        /// </summary>
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


        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="spotNo"></param>
        /// <param name="isFree"></param>
        /// <param name="distance"></param>
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