using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class VariableProfitCost
    {
        public DateTime Date { get; set; }

        public string Head { get; set; }
        public string Tail { get; set; }

        public string Type { get; set; }

        public decimal TranCost { get; set; }
        public decimal GasCost { get; set; }
        public decimal DiverCost { get; set; }
        public decimal PassCost { get; set; }

        public decimal ProfitLoss { get; set; }
    }
}