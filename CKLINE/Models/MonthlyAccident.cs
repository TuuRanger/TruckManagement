using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class MonthlyAccident
    {
        public DateTime DateTime { get; set; }
        public string Place { get; set; }
        public string Head { get; set; }
        public string Tail { get; set; }
        public int DriverID { get; set; }
        public string DriverFullName { get; set; }
        public string Status { get; set; }
        public string PartiesName { get; set; }
        public string Damage { get; set; }
        public string Result { get; set; }
        public float DaysToRepair { get; set; }
        public string Garage { get; set; }

    }
}