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
    
    public partial class TransferOli
    {
        public int ID { get; set; }
        public string JobID { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<System.DateTime> CancelDate { get; set; }
        public string OliDetail { get; set; }
        public Nullable<decimal> OliNum { get; set; }
        public Nullable<decimal> OliPrice { get; set; }
        public Nullable<decimal> OliSumPrice { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> GasID { get; set; }
    }
}
