using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace WcfRestParking.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public  string SpotNo { get; set; }
        public string Action { get; set; }

        public Log()
        {
            
        }

        public Log(int id, DateTime date, string spotNo, string action)
        {
            Id = id;
            Date = date;
            SpotNo = spotNo;
            Action = action;
        }
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