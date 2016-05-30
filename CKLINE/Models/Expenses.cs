using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class Expenses
    {
        public DateTime Date { get; set; }
        public string CarRegis { get; set; }
        public string Driver { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal ServiceNet { get { return Math.Round(ServicePrice * (Discount / 100), 2); } }
        public decimal GasRefill { get; set; }
        public decimal TotalNet { get { return ServiceNet - GasRefill; } }
        public string Remark { get; set; }
    }
}