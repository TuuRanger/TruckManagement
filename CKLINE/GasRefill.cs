//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CKLINE
{
    using System;
    using System.Collections.Generic;
    
    public partial class GasRefill
    {
        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<double> StartMile { get; set; }
        public Nullable<double> EndMile { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<double> Lite { get; set; }
        public string Remark { get; set; }
    }
}