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
    
    public partial class Order
    {
        public int ID { get; set; }
        public Nullable<int> OrderTypeID { get; set; }
        public Nullable<int> BookingID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string OrderDate { get; set; }
        public string DliveryDate { get; set; }
        public Nullable<int> RoutID { get; set; }
        public Nullable<int> C20DC { get; set; }
        public Nullable<int> C40DC { get; set; }
        public Nullable<int> C40HC { get; set; }
    }
}