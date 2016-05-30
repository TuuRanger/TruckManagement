using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class GasRefill
    {
        public string CarRegis { get; set; }
        public DateTime Date { get; set; }
        public string Job { get; set; }
        public decimal StartMile { get; set; }
        public decimal EndMile { get; set; }
        public decimal Total { get; set; }
        public decimal Bill { get; set; }
        public decimal Lite { get; set; }
        public string Remark{ get; set; }
    }
}