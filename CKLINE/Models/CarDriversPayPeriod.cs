using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class CarDriversPayPeriod
    {
        public DateTime Date { get; set; }
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public int WorkType { get; set; }
        public string WorkdDes { get; set; }
        public int RoutID { get; set; }
        public string RoutDescripion { get; set; }
        public decimal Amount { get; set; }
    }
}