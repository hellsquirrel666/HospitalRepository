using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHospital.LogicEntities
{
    public class EventModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string @class { get; set; }
        public string start { get; set; }//Milliseconds
        public string end { get; set; } // Milliseconds


    }
}