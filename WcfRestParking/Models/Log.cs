using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace WcfRestParking.Models
{
    public class Log
    {
        /// <summary>
        /// CLass for the log table in database  with matching data type
        /// marcus
        /// </summary>
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SpotNo { get; set; }
        public string Action { get; set; }
        /// <summary>
        /// default constructor
        /// </summary>
        public Log()
        {

        }
        /// <summary>
        /// Constructor for reading data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="spotNo"></param>
        /// <param name="action"></param>

        public Log(int id, DateTime date, string spotNo, string action)
        {
            Id = id;
            Date = date;
            SpotNo = spotNo;
            Action = action;
        }
        /// <summary>
        /// constructor for posting data. Id is auto incremental and identity. Not required to provide.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="spotNo"></param>
        /// <param name="action"></param>
        public Log(DateTime date, string spotNo, string action)
        {
            Date = date;
            SpotNo = spotNo;
            Action = action;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date}, SpotNo: {SpotNo}, Action: {Action}";
        }

    }
}