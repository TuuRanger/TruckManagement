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
        public Nullable<int> OrderType { get; set; }
        public string OrderID { get; set; }
        public string BookingNo { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public Nullable<System.DateTime> DliveryDate { get; set; }
        public Nullable<int> RoutID { get; set; }
        public Nullable<int> NumberOrder { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> PPackDate { get; set; }
        public Nullable<System.DateTime> TPackDate { get; set; }
        public Nullable<int> IEType { get; set; }
        public string IEShipper { get; set; }
        public string IEAgent { get; set; }
        public string IELoading { get; set; }
        public string IEShipping { get; set; }
        public string IETelephone { get; set; }
        public string IELocationPack { get; set; }
        public string IELocationReceive { get; set; }
        public string IEMap { get; set; }
        public string IELiner { get; set; }
        public Nullable<System.DateTime> IEReceiveDate { get; set; }
        public Nullable<System.DateTime> IEPackDate { get; set; }
        public string IEPacklTime { get; set; }
        public string IEFeeder { get; set; }
        public string IEMother { get; set; }
        public Nullable<System.DateTime> IECYDate { get; set; }
        public Nullable<System.DateTime> IEETDDate { get; set; }
        public string IEContact { get; set; }
        public Nullable<System.DateTime> IEETADate { get; set; }
        public string IEAT { get; set; }
        public string IETel { get; set; }
        public string IEBill { get; set; }
        public Nullable<decimal> IEPortPrice { get; set; }
        public Nullable<decimal> IELanPrice { get; set; }
        public Nullable<decimal> IELiftPrice { get; set; }
        public Nullable<System.DateTime> IECLosingDate { get; set; }
        public string IEClosingTime { get; set; }
        public string IEAgent2 { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
