using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class MonthlyTransporting
    {
        public string Month { get; set; }

        public int TotalDate { get; set; }

        public string Head { get; set; }

        public string Tail { get; set; }

        public float DistanceS { get; set; }

        public float DistanceA { get; set; }

        public float DiffDistance { get; set; }

        public float GasA { get; set; }

        public float GasS { get; set; }

        public float DiffGas { get; set; }

        public decimal PayPeriodCost { get; set; }

        public decimal GasCost { get; set; }

        public decimal Recap { get; set; }

        public decimal Other { get; set; }

        public decimal TransportCost { get; set; }

        public decimal ProfitLoss { get; set; }
    }
}