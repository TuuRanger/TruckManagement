using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class TransportQueue
    {
        public DateTime Date { get; set; }
        public string Driver { get; set; }
        public string Head { get; set; }
        public string Tail { get; set; }
        public string TankNumber { get; set; }
        public string Tel { get; set; }
        public string Remark { get; set; }

    }
}