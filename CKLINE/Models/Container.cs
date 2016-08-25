using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class Container
    {
        public DateTime Date { get; set; }
        public int TurnNumber { get; set; }
        public string Head { get; set; }
        public string Tail { get; set; }
        public string RouteGo { get; set; }
        public string Customer { get; set; }
        public string RouteBack { get; set; }
        public string CustomerBack { get; set; }

    }
}