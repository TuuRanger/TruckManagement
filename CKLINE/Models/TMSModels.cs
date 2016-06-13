﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class ModelList
    {

        public List<Customers> sCustomer { get; set; }
        public List<Routes> sRoute { get; set; }

    }
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
  
    public class Routes
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string TO { get; set; }
    }

    public class Order
    {
        public int OrderType { get; set; }
        public string OrderID { get; set; }
        public string BookingNo { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public int RoutID { get; set; }
        public int NumberOrder { get; set; }
        public string Remark { get; set; }

        public DateTime PPackDate { get; set; }

        public DateTime TPackDate { get; set; }

        public int IEType { get; set; }
        public string IEShipper { get; set; }
        public string IEAgent { get; set; }
        public string IELoading { get; set; }
        public string IEShipping { get; set; }
        public string IETelephone { get; set; }
        public string IELocationPack { get; set; }
        public string IELocationReceive { get; set; }
        public string IEMap { get; set; }
        public string IELiner { get; set; }
        public DateTime IEReceiveDate { get; set; }
        public DateTime IEPackDate { get; set; }
        public string IEPacklTime { get; set; }
        public string IEFeeder { get; set; }
        public string IEMother { get; set; }
        public DateTime IECYDate { get; set; }
        public DateTime IEETDDate { get; set; }
        public string IEContact { get; set; }
        public DateTime IEETADate { get; set; }
        public string IEAT { get; set; }
        public string IETel { get; set; }
        public string IEBill { get; set; }
        public decimal IEPortPrice { get; set; }
        public decimal IELanPrice { get; set; }
        public decimal IELiftPrice { get; set; }
        public DateTime IECLosingDate { get; set; }
        public string IEClosingTime { get; set; }
        public string IEAgent2 { get; set; }

        public int Status { get; set; }

        //public List<ContainerList> lContainer { get; set; }
        //public List<PositionList> lPosition { get; set; }
        //public List<PackNoList> lPackNo { get; set; }
   

    }

    public class ContainerList
    {
        public string Container { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
     
    }
  

    public class OrderDetail
    {
        public int OID { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public int Status { get; set; }
    }
    public class OrderInfo
    {
        public int OrderType { get; set; }
        public string OrderID { get; set; }
        public string BookingNo { get; set; }
        public int CustomerID { get; set; }
      
        public DateTime OrderDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public int RoutID { get; set; }
        public int NumberOrder { get; set; }
        public string Remark { get; set; }

        public DateTime PPackDate { get; set; }

        public DateTime TPackDate { get; set; }

        public int IEType { get; set; }
        public string IEShipper { get; set; }
        public string IEAgent { get; set; }
        public string IELoading { get; set; }
        public string IEShipping { get; set; }
        public string IETelephone { get; set; }
        public string IELocationPack { get; set; }
        public string IELocationReceive { get; set; }
        public string IEMap { get; set; }
        public string IELiner { get; set; }
        public DateTime IEReceiveDate { get; set; }
        public DateTime IEPackDate { get; set; }
        public string IEPacklTime { get; set; }
        public string IEFeeder { get; set; }
        public string IEMother { get; set; }
        public DateTime IECYDate { get; set; }
        public DateTime IEETDDate { get; set; }
        public string IEContact { get; set; }
        public DateTime IEETADate { get; set; }
        public string IEAT { get; set; }
        public string IETel { get; set; }
        public string IEBill { get; set; }
        public decimal IEPortPrice { get; set; }
        public decimal IELanPrice { get; set; }
        public decimal IELiftPrice { get; set; }
        public DateTime IECLosingDate { get; set; }
        public string IEClosingTime { get; set; }
        public string IEAgent2 { get; set; }

        public int Status { get; set; }

        public string CName { get; set; }
        public string CAddress { get; set; }
        public string CProvince { get; set; }
        public string CZipCode { get; set; }
        public string CTelephone { get; set; }

        public string RFromDetail { get; set; }
        public string RFromProvince { get; set; }
        public string RToDetail { get; set; }
        public string RToProvince { get; set; }
      

    }
    public class OrderDetailInfo
    {
        public int OID { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public int Status { get; set; }
    }

    public class JobList
    {
        public List<JOrderList> JOrder { get; set; }
        public List<JOrderDList> JOrderD { get; set; }
        public List<JTruckList> JTruck { get; set; }
        public List<JSubList> JSub { get; set; }
        public List<JJobList> JJob { get; set; }
        public List<JOrderAdd> JOrderA { get; set; }
     
    }
    public class JOrderList
    {
        public int OID { get; set; }
        public string OrderID { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public int RoutID { get; set; }
        public int CustomerID { get; set; }
        public int NumberOrder { get; set; }
        public string BookingNo { get; set; }
        public int Status { get; set; }
        public int OrderType { get; set; }
    }
    public class JOrderDList
    {
        public int ID { get; set; }
        public int OID { get; set; }
     
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public int Status { get; set; }
    }

    public class JTruckList
    {
        public int TID { get; set; }
        public int HID { get; set; }
        public int DID { get; set; }

        public string License { get; set; }
        public string HitchLicense { get; set; }
        public string DTitle { get; set; }
        public string DFirstName { get; set; }
        public string DLastName { get; set; }
        public int TStatus { get; set; }
    }

    public class JSubList
    {
        public int SID { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
    }

    public class JJobList
    {
        public int JID { get; set; }
        public int ODID { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public int Status { get; set; }
    }

    public class JOrderAdd
    {
 
        public string OrderID { get; set; } 
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public int OrderType { get; set; }
        public int CustomerID { get; set; }
        public int RouteID { get; set; }
        public int ODID { get; set; }
        public string ContainerNo { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public string CustomerName { get; set; }
        public string FromDetail { get; set; }
        public string ToDetail { get; set; }
    }

  

}