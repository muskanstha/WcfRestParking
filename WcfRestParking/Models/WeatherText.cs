using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestParking.Models
{
    /// <summary>
    /// Class to support getting information from yahoo weather services
    /// By Muskan 
    /// Generated using json2charp.com
    /// </summary>
    public class WeatherText
    {
        public Query query { get; set; }

        public class Condition
        {
            public string text { get; set; }
        }

        public class Item
        {
            public Condition condition { get; set; }
        }

        public class Channel
        {
            public Item item { get; set; }
        }

        public class Results
        {
            public Channel channel { get; set; }
        }

        public class Query
        {
            public int count { get; set; }
            public string created { get; set; }
            public string lang { get; set; }
            public Results results { get; set; }
        }




    }
}