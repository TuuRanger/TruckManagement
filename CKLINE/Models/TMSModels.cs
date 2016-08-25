using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class ModelList
    {

        public List<Customers> sCustomer { get; set; }
        public List<Shippers> sShipper { get; set; }
        public List<Routes> sRoute { get; set; }

    }
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderType { get; set; }
    }
    public class Shippers
    {
        public int ShipperID { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }
        public int OrderType { get; set; }

    }
    public class Orders
    {
        public int OrderType { get; set; }
        public string OrderID { get; set; }
        public string BookingNo { get; set; }
        public int CustomerID { get; set; }
        public int ShipperID { get; set; }
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

        public int TRound1 { get; set; }
        public int TRound2 { get; set; }
        public int TRound3 { get; set; }
        public int TRound4 { get; set; }

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
        public string IEReceiveTime { get; set; }
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

        public decimal IESCost { get; set; }
        public decimal IESDistance { get; set; }

        public string IEAgent { get; set; }


        public DateTime IECLosingDate { get; set; }
        public string IEClosingTime { get; set; }

        public string IEMap { get; set; }


        public int Status { get; set; }

    }
    public class Routes
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string TO { get; set; }
        public int ShipperID { get; set; }
    }
    public class ContainerList
    {
        public string Container { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public string ContainerType { get; set; }
        public decimal TareWeight { get; set; }
       
     
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
        public int RouteID { get; set; }
        public string RFromDetail { get; set; }
        public string RFromProvince { get; set; }
        public string RToDetail { get; set; }
        public string RToProvince { get; set; }
        public decimal TareWeight { get; set; }
        public int Status { get; set; }
    }
    public class JobInfo
    {
        public int JID { get; set; }
        public string JobID { get; set; }
        public int JobType { get; set; }
        public string SOID { get; set; }
        public int SNum { get; set; }
        public string ROID { get; set; }
        public int RNum { get; set; }
        public int TruckID { get; set; }
        public int HitchID { get; set; }
        public int DriverID { get; set; }
        public int SID { get; set; }
        public int SType { get; set; }
        public DateTime JDate { get; set; }
        public string JRemark { get;set;}
        public int JStatus { get; set; }

        public string License { get; set; }
        public string HitchLicense { get; set; }
        public string DTitle { get; set; }
        public string DFirstName { get; set; }
        public string DLastName { get; set; }
        public int TStatus { get; set; }

        public string SCCode { get; set; }
        public string SCName { get; set; }

     

        public int OrderType { get; set; }
        public int ROrderType { get; set; }
        public string OrderID { get; set; }
        public string BookingNo { get; set; }

      
        public int ShipperID { get; set; }
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


        public int TRound1 { get; set; }
        public int TRound2 { get; set; }
        public int TRound3 { get; set; }
        public int TRound4 { get; set; }

        public int IEType { get; set; }
        public string IEShipper { get; set; }
        public string IEQuantity { get; set; }
        public string IEFeeder { get; set; }
        public string IEMother { get; set; }
        public string IELoading { get; set; }
        public DateTime IEETADate { get; set; }
        public DateTime IEETDDate { get; set; }
        public DateTime IEReceiveDate { get; set; }
        public string IEReceiveTime { get; set; }
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

        public decimal IESCost { get; set; }
        public decimal IESDistance { get; set; }

        public string IEAgent { get; set; }


        public DateTime IECLosingDate { get; set; }
        public string IEClosingTime { get; set; }

        public string IEMap { get; set; }

        public int Status { get; set; }

        public int CustomerID { get; set; }
        public string CName { get; set; }
        public string CAddress { get; set; }
        public string CProvince { get; set; }
        public string CZipCode { get; set; }
        public string CTelephone { get; set; }

        public string SName { get; set; }
        public string SAddress { get; set; }
        public string SProvince { get; set; }
        public string SZipCode { get; set; }
        public string STelephone { get; set; }

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
    public class JobDetailInfo
    {
        public int JDID { get; set; }
        public string JobID { get; set; }
        public int JobType { get; set; }

        public int OID { get; set; }
        public int ODID { get; set; }

        public int JStatus { get; set; }
        public DateTime JReceiveDate { get; set; }

        public string OrderID { get; set; }

        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public DateTime TPackDate { get; set; }
        public int RouteID { get; set; }
        public string RFromDetail { get; set; }
        public string RFromProvince { get; set; }
        public string RToDetail { get; set; }
        public string RToProvince { get; set; }
        public decimal TareWeight { get; set; }
        public int Status { get; set; }
    }
    public class OrderInfo
    {
        public int OrderType { get; set; }
        public string OrderID { get; set; }
        public string BookingNo { get; set; }
        public int CustomerID { get; set; }
        public int ShipperID { get; set; }
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


        public int TRound1 { get; set; }
        public int TRound2 { get; set; }
        public int TRound3 { get; set; }
        public int TRound4 { get; set; }

        public int IEType { get; set; }
        public string IEShipper { get; set; }
        public string IEQuantity { get; set; }
        public string IEFeeder { get; set; }
        public string IEMother { get; set; }
        public string IELoading { get; set; }
        public DateTime IEETADate { get; set; }
        public DateTime IEETDDate { get; set; }
        public DateTime IEReceiveDate { get; set; }
        public string IEReceiveTime { get; set; }
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

        public decimal IESCost { get; set; }
        public decimal IESDistance { get; set; }

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

        public string SName { get; set; }
        public string SAddress { get; set; }
        public string SProvince { get; set; }
        public string SZipCode { get; set; }
        public string STelephone { get; set; }

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
        public int ODID { get; set; }
        public string OrderID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
        public string Position { get; set; }
        public string PackNo { get; set; }
        public DateTime TPackDate { get; set; }
        public int RouteID { get; set; }
        public string RFromDetail { get; set; }
        public string RFromProvince { get; set; }
        public string RToDetail { get; set; }
        public string RToProvince { get; set; }
        public decimal TareWeight { get; set; }
        public int Status { get; set; }
        public int JStatus { get; set; }
        public DateTime JReceiveDate { get; set; }
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
        public DateTime OrderDate { get; set; }
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

        public string CName { get; set; }
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
        public string SOrderID { get; set; }
        public string ROrderID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime DliveryDate { get; set; }
        public DateTime PPackDate { get; set; }
        public DateTime TPackDate1 { get; set; }
        public DateTime TPackDate2 { get; set; }
        public DateTime TPackDate3 { get; set; }
        public DateTime TPackDate4 { get; set; }
        public int TRound1 { get; set; }
        public int TRound2 { get; set; }
        public int TRound3 { get; set; }
        public int TRound4 { get; set; }
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

       // public string DFirstName { get; set; }
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
        public List<DataRepair> rDataRepair { get; set; }
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
    public class NewJobList
    {
        public List<JOrderList> JOrder { get; set; }
        public List<JTruckList> JTruck { get; set; }
        public List<JSubList> JSub { get; set; }
        public List<JJobList> JJob { get; set; }
        public List<OrderInfo> JOrderS { get; set; }
        public List<OrderDetailInfo> JOrderDS { get; set; }
        public List<OrderInfo> JOrderR { get; set; }
        public List<OrderDetailInfo> JOrderDR { get; set; }
    }
    public class GasStationList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Province { get; set; }
    }
    public class Transferlist
    {
        public List<JobInfo> TJob { get; set; }
        public List<JobDetailInfo> TJobDetail { get; set; }
        public List<OrderInfo> JOrderS { get; set; }
        public List<OrderDetailInfo> JOrderDS { get; set; }
        public List<OrderInfo> JOrderR { get; set; }
        public List<OrderDetailInfo> JOrderDR { get; set; }
        public List<TransferT> TTransfer { get; set; }
        public List<TransferOliDetail> OTransfer { get; set; }
        public List<TransferWayDetail> WTransfer { get; set; }
        public List<TransferOTHDetail> OTHTransfer { get; set; }
        public List<GasStationList> TGasStation { get; set; }
    }
    public class TransferT
    {
        public int TransferID { get; set; }
        public string JobID { get; set; }
        public DateTime OpenJobDate { get; set; }
        public DateTime TransferDate { get; set; }
        public string TransferTime { get; set; }
        public decimal OMile { get; set; }
        public decimal OOli { get; set; }
        public decimal OWay { get; set; }
        public decimal OOther { get; set; }
        public string ORemark { get; set; }

        public DateTime CloseJobDate { get; set; }
        public DateTime ArriveDate { get; set; }
        public string ArriveTime { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnTime { get; set; }
        public decimal ROli {get;set;}
        public decimal RDistance {get;set;}
        public decimal CMile { get; set; }
        public decimal COli { get; set; }
        public decimal CWay { get; set; }
        public decimal COther { get; set; }
        public string CRemark { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal DriverCost { get; set; }
        public decimal SIncome { get; set; }
        public decimal RIncome { get; set; }
        public decimal AllIncome { get; set; }

        public decimal WCarB { get; set; }
        public decimal WGas { get; set; }
        public decimal WCarW { get; set; }
        public int Status { get; set; }
    }
    public class TransferOliDetail
    {
        public int ID { get; set; }
        public string JobID { get; set; }
        public DateTime SaveDate { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime CancelDate { get; set; }
        public string OliDetail { get; set; }
        public decimal OliNum { get; set; }
        public decimal OliPrice { get; set; }
        public decimal OliSumPrice { get; set; }
        public int Status { get; set; }
        public int GasID { get; set; }
        public string GName { get; set; }
        public string GBranch { get; set; }
    }
    public class TransferWayDetail
    {
        public int ID { get; set; }
        public string JobID { get; set; }
        public DateTime SaveDate { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime CancelDate { get; set; }
        public string WayDetail { get; set; }
        public decimal WayNum { get; set; }
        public decimal WayPrice { get; set; }
        public decimal WaySumPrice { get; set; }
        public int Status { get; set; }
    }
    public class TransferOTHDetail
    {
        public int ID { get; set; }
        public string JobID { get; set; }
        public DateTime SaveDate { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime CancelDate { get; set; }
        public string OTHDetail { get; set; }
        public decimal OTHNum { get; set; }
        public decimal OTHPrice { get; set; }
        public decimal OTHSumPrice { get; set; }
        public int Status { get; set; }
    }

    //Data Master
    public class MDriver
    {
        public int ID { get; set; }
        public string EmpID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Mobile { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyTelephone { get; set; }
        public string DriverLicence { get; set; }
        public string Type { get; set; }
        public DateTime DIssueDate { get; set; }
        public DateTime DExpireDate { get; set; }
        public DateTime DOB { get; set; }
        public string Race { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string IDCard { get; set; }
        public DateTime IssuseDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public int MarriageStatusID { get; set; }
        public int MilitaryStatusID { get; set; }
        public string Education { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string FatherFullName { get; set; }
        public DateTime DOBFather { get; set; }
        public string MotherFullName { get; set; }
        public DateTime DOBMother { get; set; }
        public string FDetail { get; set; }
        public string MDetail { get; set; }
        public string WifeFullName { get; set; }
        public string Workplace { get; set; }
        public string WPosition { get; set; }
        public int Child { get; set; }
        public string ImgDriver { get; set; }
        public string FileDriver { get; set; }
        public string FileIDCard { get; set; }
        public string FileRegistration { get; set; }
        public int TruckID { get; set; }
        public string Status { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int EdittBy { get; set; }
        public DateTime EditDate { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteDate { get; set; }

        public string Remark { get; set; }

        public string TruckLicense { get; set; }
    }
}