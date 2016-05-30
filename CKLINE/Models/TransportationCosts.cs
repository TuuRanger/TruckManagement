using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class TransportationCosts
    {
        public DateTime Date { get; set; }
        public string Item { get; set; }
        public decimal Costs { get; set; }
    }
}