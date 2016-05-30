using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class ProfitAndLoss
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Expensess { get; set; }
        public decimal Income { get; set; }
        public decimal Total { get { return Income - Expensess; } }
    }
}