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
    
    public partial class Job
    {
        public int ID { get; set; }
        public string BookingID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> DriverID { get; set; }
        public string TruckID { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Status { get; set; }
    }
}