using System;
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
        public int RoutID2 { get; set; }
        public int RoutID3 { get; set; }
        public int RoutID4 { get; set; }
        public int NumberOrder { get; set; }
        public string Remark { get; set; }

        public DateTime PPackDate { get; set; }

        public DateTime TPackDate1 { get; set; }
        public int TNumberOrder1 { get; set; }
        public DateTime TPackDate2 { get; set; }
        public int TNumberOrder2 { get; set; }
        public DateTime TPackDate3 { get; set; }
        public int TNumberOrder3 { get; set; }
        public DateTime TPackDate4 { get; set; }
        public int TNumberOrder4 { get; set; }

        public string ContainerType1 { get; set; }
        public string ContainerType2 { get; set; }
        public string ContainerType3 { get; set; }
        public string ContainerType4 { get; set; }

        public int IEType { get; set; }
        public string IEShipper { get; set; }
        public string IEQuantity { get; set; }
        public string IEFeeder { get; set; }
        public string IEMother { get; set; }
        public string IELoading { get; set; }
        public DateTime IEETADate { get; set; }
        public DateTime IEETDDate { get; set; }
        public DateTime IEReceiveDate { get; set; }
        public string IEAT { get; set; }
        public string IEContact { get; set; }
        public string IETel { get; set; }
        public DateTime IEPackDate { get; set; }
        public string IEPacklTime { get; set; }
        public string IELocationPack { get; set; }
        public DateTime IEReturnDate { get; set; }
        public string IELocationReceive { get; set; }
        public string IEShipping { get; set; }
        public string IETelephone { get; set; }
        public string IEBill { get; set; }
        public decimal IEPortPrice { get; set; }
        public decimal IELanPrice { get; set; }
        public decimal IELiftPrice { get; set; }

        public string IEAgent { get; set; }


        public DateTime IECLosingDate { get; set; }
        public string IEClosingTime { get; set; }
       
        public string IEMap { get; set; }
  
      
        public int Status { get; set; }

    }

    public class ContainerList
    {
        public string Container { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public string ContainerType { get; set; }
       
     
    }
  

    public class OrderDetail
    {
        public int OID { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public DateTime TPackDate { get; set; }
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
        public int RoutID2 { get; set; }
        public int RoutID3 { get; set; }
        public int RoutID4 { get; set; }
        public int NumberOrder { get; set; }
        public string Remark { get; set; }

        public DateTime PPackDate { get; set; }

        public DateTime TPackDate1 { get; set; }
        public int TNumberOrder1 { get; set; }
        public string ContainerType1 { get; set; }
        public DateTime TPackDate2 { get; set; }
        public int TNumberOrder2 { get; set; }
        public string ContainerType2 { get; set; }
        public DateTime TPackDate3 { get; set; }
        public int TNumberOrder3 { get; set; }
        public string ContainerType3 { get; set; }
        public DateTime TPackDate4 { get; set; }
        public int TNumberOrder4 { get; set; }
        public string ContainerType4 { get; set; }

        public int IEType { get; set; }
        public string IEShipper { get; set; }
        public string IEQuantity { get; set; }
        public string IEFeeder { get; set; }
        public string IEMother { get; set; }
        public string IELoading { get; set; }
        public DateTime IEETADate { get; set; }
        public DateTime IEETDDate { get; set; }
        public DateTime IEReceiveDate { get; set; }
        public string IEAT { get; set; }
        public string IEContact { get; set; }
        public string IETel { get; set; }
        public DateTime IEPackDate { get; set; }
        public string IEPacklTime { get; set; }
        public string IELocationPack { get; set; }
        public DateTime IEReturnDate { get; set; }
        public string IELocationReceive { get; set; }
        public string IEShipping { get; set; }
        public string IETelephone { get; set; }
        public string IEBill { get; set; }
        public decimal IEPortPrice { get; set; }
        public decimal IELanPrice { get; set; }
        public decimal IELiftPrice { get; set; }

        public string IEAgent { get; set; }


        public DateTime IECLosingDate { get; set; }
        public string IEClosingTime { get; set; }

        public string IEMap { get; set; }

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

        public string RFromDetail2 { get; set; }
        public string RFromProvince2 { get; set; }
        public string RToDetail2 { get; set; }
        public string RToProvince2 { get; set; }

        public string RFromDetail3 { get; set; }
        public string RFromProvince3 { get; set; }
        public string RToDetail3 { get; set; }
        public string RToProvince3 { get; set; }

        public string RFromDetail4 { get; set; }
        public string RFromProvince4 { get; set; }
        public string RToDetail4 { get; set; }
        public string RToProvince4 { get; set; }
      

    }
    public class OrderDetailInfo
    {
        public int OID { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public DateTime TPackDate { get; set; }
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
        public DateTime TPackDate { get; set; }
       
        public DateTime IEReceiveDate { get; set; }
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
        public DateTime TPackDate { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
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
        public string ContainerType { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public DateTime PPackDate { get; set; }
        public DateTime TPackDate1 { get; set; }
        public DateTime TPackDate2 { get; set; }
        public DateTime TPackDate3 { get; set; }
        public DateTime TPackDate4 { get; set; }
        public DateTime IEReceiveDate { get; set; }
        public DateTime IEPackDate { get; set; }
        public DateTime IEReturnDate { get; set; }
        public int Status { get; set; }
    }

    public class JOrderAdd
    {
 
        public string OrderID { get; set; } 
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public DateTime TPackDate { get; set; }
        public DateTime PPackDate { get; set; }
      
        public DateTime IEReceiveDate { get; set; }
        public DateTime IEPackDate { get; set; }
        public DateTime IEReturnDate { get; set; }
        public int OrderType { get; set; }
        public int CustomerID { get; set; }
        public int RouteID { get; set; }
        public int ODID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public string CustomerName { get; set; }
        public string FromDetail { get; set; }
        public string ToDetail { get; set; }
    }

    public class OpenJob
    {
        public List<OpenJobT> sOpenJobT { get; set; }
        public List<OpenJobS> sOpenJobS { get; set; }
    }
    public class OpenJobT
    {
        public int JID { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
        public string FromDetail { get; set; }
        public string ToDetail { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public string License { get; set; }
        public string HitchLicense { get; set; }
        public string DTitle { get; set; }
        public string DFirstName { get; set; }
        public string DLastName { get; set; }
        public int JStatus { get; set; }
        public int SType { get; set; }
        public string SName { get; set; }
    }
    public class OpenJobS
    {
        public int JID { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
        public string FromDetail { get; set; }
        public string ToDetail { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public string License { get; set; }
        public string HitchLicense { get; set; }
        public string DTitle { get; set; }
        public string DFirstName { get; set; }
        public string DLastName { get; set; }
        public int JStatus { get; set; }
        public int SType { get; set; }
        public string SName { get; set; }
    }

    public class TruckList
    {
        public int TID { get; set; }
        public int HID { get; set; }
        public int TruckType { get; set; }
        public string STType { get; set; }
        public string Brand { get; set; }
        public string License { get; set; }
        public string RegisterDate { get; set; }
        public string HitchLicense { get; set; }
        public string DTitle { get; set; }
        public string DFirstName { get; set; }
        public string DLastName { get; set; }
        public int TStatus { get; set; }
    }

    public class DriverList
    {
        public int DriverID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    public class GarageList
    {
        public int GID { get; set; }
        public string Name { get; set; }
    }

    public class RepairList
    {

        public List<TruckList> rTruck { get; set; }
        public List<DriverList> rDriver { get; set; }
        public List<GarageList> rGarage { get; set; }
        public List<RepairDetail> rRepair { get; set; }
        public List<OldRepair> rOldRepair { get; set; }
    }

    public class OldRepair
    {
        public string InformDate { get; set; }
        public int GID { get; set; }
        public string GName { get; set; }
        public decimal Mile { get; set; }
        public decimal SumPrice { get; set; }
    }

    public class RepairDetail
    {
        public string Detail { get; set; }
        public string Num { get; set; }
        public string Price { get; set; }
    }

    public class DataRepair
    {
        public string RepairNo { get; set; }
        public int TID { get; set; }
        public decimal Mile { get; set; }
        public DateTime InformDate { get; set; }
        public string InformTime { get; set; }
        public DateTime SendDate { get; set; }
        public string SendTime { get; set; }
        public DateTime FinishDate { get; set; }
        public string FinishTime { get; set; }
        public string Detail { get; set; }
        public int optEdit { get; set; }
        public int optRepair { get; set; }
        public string Remark { get; set; }
        public decimal SumNum { get; set; }
        public decimal SumPrice { get; set; }
        public int GID { get; set; }
        public string Operator { get; set; }
        public int Status { get; set; }
        public DateTime SaveDate { get; set; }

        public int TruckType { get; set; }
        public string STType { get; set; }
        public string License { get; set; }
        public string Brand { get; set; }
        public DateTime RegisterDate { get; set; }

        public int DriverID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GName { get; set; }

        public string SEdit { get; set; }
        public string SRepair { get; set; }

    }

    public class DataRepairDetail
    {
        public int ID { get; set; }
        public string RepairNo { get; set; }
        public string Detail { get; set; }
        public decimal Num { get; set; }
        public decimal Price { get; set; }
        public decimal SumPrice { get; set; }
    }
}