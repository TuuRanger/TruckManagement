using TMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace CKLINE.Controllers
{
    public class TMSController : Controller
    {
        // GET: TTMS
        public TMSEntities db = new TMSEntities();

        public ActionResult Index()
        {
            List<OrderInfo> model = new List<OrderInfo>();
        

            var sOrderInfo = (from o in db.Orders
                              join c in db.Customers on o.CustomerID equals c.ID
                              join r in db.Routes on o.RoutID equals r.ID
                              //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                              //  join d in db.LMS_Driver on b.DriverID equals d.ID
                           //   where o.OrderID == OID
                           orderby o.OrderID descending
                              select new
                              {
                                  OrderType = o.OrderType,
                                  OrderID = o.OrderID,
                                  BookingNo = o.BookingNo,
                                  CustomerID = o.CustomerID,
                                  OrderDate = o.OrderDate,
                                  ReceiveDate = o.ReceiveDate,
                                  DliveryDate = o.DliveryDate,
                                  RoutID = o.RoutID,
                                  NumberOrder = o.NumberOrder,
                                  Remark = o.Remark,
                                  PPackDate = o.PPackDate,
                                  TPackDate1 = o.TPackDate1,
                                  TPackDate2 = o.TPackDate2,
                                  TPackDate3 = o.TPackDate3,
                                  TPackDate4 = o.TPackDate4,
                                  TNumberOrder1 = o.TNumberOrder1,
                                  TNumberOrder2 = o.TNumberOrder2,
                                  TNumberOrder3 = o.TNumberOrder3,
                                  TNumberOrder4 = o.TNumberOrder4,
                                  IEType = o.IEType,
                                  IEShipper = o.IEShipper,
                                  IEAgent = o.IEAgent,
                                  IELoading = o.IELoading,
                                  IEShipping = o.IEShipping,
                                  IETelephone = o.IETelephone,
                                  IELocationPack = o.IELocationPack,
                                  IELocationReceive = o.IELocationReceive,
                                  IEMap = o.IEMap,
                               //   IELiner = o.IELiner,
                                  IEReceiveDate = o.IEReceiveDate,
                                  IEPackDate = o.IEPackDate,
                                  IEPacklTime = o.IEPacklTime,
                                  IEFeeder = o.IEFeeder,
                                  IEMother = o.IEMother,
                                //  IECYDate = o.IECYDate,
                                  IEETDDate = o.IEETDDate,
                                  IEContact = o.IEContact,
                                  IEETADate = o.IEETADate,
                                  IEAT = o.IEAT,
                                  IETel = o.IETel,
                                  IEBill = o.IEBill,
                                  IEPortPrice = o.IEPortPrice,
                                  IELanPrice = o.IELanPrice,
                                  IELiftPrice = o.IELiftPrice,
                                  IECLosingDate = o.IECLosingDate,
                                  IEClosingTime = o.IEClosingTime,
                                  IEQuantity = o.IEQuantity,
                                  IEReturnDate = o.IEReturnDate,
                                  Status = o.Status,

                                  CName = c.Name,
                                  CAddress = c.Address,
                                  CProvince = c.Province,
                                  CZipCode = c.ZipCode,
                                  CTelephone = c.Telephone,

                                  RFromDetail = r.FromDetail,
                                  RFromProvince = r.FromProvince,
                                  RToDetail = r.ToDetail,
                                  RToProvince = r.ToProvince
                              }
             ).ToList();

            foreach (var ol in sOrderInfo)
            {
                OrderInfo a = new OrderInfo();

                a.BookingNo = ol.BookingNo;
                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }

                a.IEAgent = ol.IEAgent;
                a.IEQuantity = ol.IEQuantity;
                a.IEAT = ol.IEAT;
                a.IEBill = ol.IEBill;

                if (ol.IECLosingDate == null)
                {
                    a.IECLosingDate = DateTime.Now.Date;
                }
                else
                {
                    a.IECLosingDate = Convert.ToDateTime(ol.IECLosingDate);
                }


                a.IEClosingTime = ol.IEClosingTime;
                a.IEContact = ol.IEContact;

                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                a.IEFeeder = ol.IEFeeder;
                a.IELanPrice = Convert.ToDecimal(ol.IELanPrice);
                a.IELiftPrice = Convert.ToDecimal(ol.IELiftPrice);
              //  a.IELiner = ol.IELiner;
                a.IELoading = ol.IELoading;
                a.IELocationPack = ol.IELocationPack;
                a.IELocationReceive = ol.IELocationReceive;
                a.IEMap = ol.IEMap;
                a.IEMother = ol.IEMother;

                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;
                a.IEPortPrice = Convert.ToDecimal(ol.IEPortPrice);

                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }

                a.IEShipper = ol.IEShipper;
                a.IEShipping = ol.IEShipping;
                a.IETel = ol.IETel;
                a.IETelephone = ol.IETelephone;
                a.IEType = Convert.ToInt32(ol.IEType);
                a.NumberOrder = Convert.ToInt32(ol.NumberOrder);

                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }

                a.OrderID = ol.OrderID;
                a.OrderType = Convert.ToInt32(ol.OrderType);

                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.Remark = ol.Remark;
                a.RoutID = Convert.ToInt32(ol.RoutID);
                a.Status = Convert.ToInt32(ol.Status);

                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }

                if (ol.TPackDate2 == null)
                {
                    a.TPackDate2 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate2 = Convert.ToDateTime(ol.TPackDate2);
                }

                if (ol.TPackDate3 == null)
                {
                    a.TPackDate3 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate3 = Convert.ToDateTime(ol.TPackDate3);
                }

                if (ol.TPackDate4 == null)
                {
                    a.TPackDate4 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate4 = Convert.ToDateTime(ol.TPackDate4);
                }

                a.TNumberOrder1 = Convert.ToInt32(ol.TNumberOrder1);
                a.TNumberOrder2 = Convert.ToInt32(ol.TNumberOrder2);
                a.TNumberOrder3 = Convert.ToInt32(ol.TNumberOrder3);
                a.TNumberOrder4 = Convert.ToInt32(ol.TNumberOrder4);
                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;

                model.Add(a);

            }
           
            return View(model);
        }
        public ActionResult rTest()
        {
            return View();
        }
        public ActionResult NewOrder()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F1";

            var dCustomer = (from c in db.Customers
                             select new
                             {
                                 cID = c.ID,
                                 cName = c.Name,
                                 COrderType = c.OrderType
                             }
                  ).ToList();

            var dShipper = (from s in db.Shippers
                        //    where s.CustomerID == 1
                             select new
                             {
                                 sID = s.ID,
                                 sName = s.Name,
                                 cID = s.CustomerID,
                                 sOrderType = s.OrderType
                             }
                ).ToList();


            var dRoute = (from r in db.Routes
                          where r.ShipperID == 1
                          orderby r.FromDetail 
                          select new
                          {
                              rID = r.ID,
                              rFrom = r.FromDetail,
                              rTO = r.ToDetail,
                              sID = r.ShipperID
                          }
                  ).ToList();

            List<ModelList> model = new List<ModelList>();
            List<Customers> lCustomer = new List<Customers>();
            List<Shippers> lShipper = new List<Shippers>();
            List<Routes> lRoute = new List<Routes>();


            foreach (var bc in dCustomer)
            {
                Customers a = new Customers();
                a.Id = Convert.ToInt32(bc.cID);
                a.Name = bc.cName;
                a.OrderType = Convert.ToInt32(bc.COrderType);
                lCustomer.Add(a);
            }

            foreach (var sr in dShipper)
            {
                Shippers s = new Shippers();
                s.ShipperID = Convert.ToInt32(sr.sID);
                s.Name = sr.sName;
                s.CustomerID = Convert.ToInt32(sr.cID);
                s.OrderType = Convert.ToInt32(sr.sOrderType);
                lShipper.Add(s);

            }

            foreach (var br in dRoute)
            {
                Routes r = new Routes();
                r.Id = Convert.ToInt32(br.rID);
                r.From = br.rFrom.ToString();
                r.TO = br.rTO.ToString();
                r.ShipperID = Convert.ToInt32(br.sID);
                lRoute.Add(r);
            }

            ModelList ML = new ModelList();
            ML.sCustomer = lCustomer.ToList();
            ML.sRoute = lRoute.ToList();
            ML.sShipper = lShipper.ToList();

            model.Add(ML);


            return View(model);
          //  return View();
        }
    
        public ActionResult OrderCommit(FormCollection form, HttpPostedFileBase file)
        {
            string ReceiveDate = form["ReceiveDate"];
              //  Request.Form["ReceiveDate"];
            string DliveryDate = Request.Form["DliveryDate"];

            string PPackDate = Request.Form["PPackDate"];

            string TPackDate1 = Request.Form["TPackDate1"];
            string TPackDate2 = Request.Form["TPackDate2"];
            string TPackDate3 = Request.Form["TPackDate3"];
            string TPackDate4 = Request.Form["TPackDate4"];

            string IEReceiveDate = Request.Form["IEReceiveDate"];
            string IEPackDate = Request.Form["IEPackDate"];
            string IEReturnDate = Request.Form["IEReturnDate"];
            string IEETDDate = Request.Form["IEETDDate"];
            string IEETADate = Request.Form["IEETADate"];
            string IECLosingDate = Request.Form["IECLosingDate"];

           
            Order dOrder = new Order();
            dOrder.BookingNo = Request.Form["BookingNo"];
            dOrder.OrderID = Request.Form["OrderID"];
            dOrder.OrderType = Convert.ToInt32(Request.Form["OrderType"]);
            dOrder.CustomerID = Convert.ToInt32(Request.Form["Customer"]);
            dOrder.OrderDate = DateTime.Now.Date;

          
            dOrder.Status = 1;
            dOrder.Remark = Request.Form["Remark"];


            if (ReceiveDate == null || ReceiveDate == "")
            {
                dOrder.ReceiveDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = ReceiveDate.Substring(0, 2);
                string d2 = ReceiveDate.Substring(3, 2);
                string d3 = ReceiveDate.Substring(6, 4);
               // string d4 = d1 + "/" + d2 + "/" + d3;
         string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.ReceiveDate = DateTime.Parse(d4);

               // dOrder.ReceiveDate = DateTime.Parse(ReceiveDate);
             
            }

            if (DliveryDate == null || DliveryDate == "")
            {
                dOrder.DliveryDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = DliveryDate.Substring(0, 2);
                string d2 = DliveryDate.Substring(3, 2);
                string d3 = DliveryDate.Substring(6, 4);
               // string d4 = d1 + "/" + d2 + "/" + d3;
                  string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.DliveryDate = DateTime.Parse(d4);
             //   dOrder.DliveryDate = DateTime.Parse(DliveryDate);
               // dOrder.DliveryDate = Convert.ToDateTime(Request.Form["DliveryDate"]).Date;
            }

            if (PPackDate == null || PPackDate == "")
            {
                dOrder.PPackDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = PPackDate.Substring(0, 2);
                string d2 = PPackDate.Substring(3, 2);
                string d3 = PPackDate.Substring(6, 4);
              //  string d4 = d1 + "/" + d2 + "/" + d3;
                   string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.PPackDate = DateTime.Parse(d4);
             //   dOrder.PPackDate = DateTime.Parse(PPackDate);
             //   dOrder.PPackDate = Convert.ToDateTime(Request.Form["PPackDate"]).Date;
            }

            if (TPackDate1 == null || TPackDate1 == "")
            {
                dOrder.TPackDate1 = DateTime.Now.Date;
            }
            else
            {
                string d1 = TPackDate1.Substring(0, 2);
                string d2 = TPackDate1.Substring(3, 2);
                string d3 = TPackDate1.Substring(6, 4);
              //  string d4 = d1 + "/" + d2 + "/" + d3;
                    string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.TPackDate1 = DateTime.Parse(d4);
               // dOrder.TPackDate = DateTime.Parse(TPackDate);
              //  dOrder.TPackDate = Convert.ToDateTime(Request.Form["TPackDate"]).Date;
            }
            if (TPackDate2 == null || TPackDate2 == "")
            {
                dOrder.TPackDate2 = DateTime.Now.Date;
            }
            else
            {
                string d1 = TPackDate2.Substring(0, 2);
                string d2 = TPackDate2.Substring(3, 2);
                string d3 = TPackDate2.Substring(6, 4);
                //  string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.TPackDate2 = DateTime.Parse(d4);
                // dOrder.TPackDate = DateTime.Parse(TPackDate);
                //  dOrder.TPackDate = Convert.ToDateTime(Request.Form["TPackDate"]).Date;
            }

            if (TPackDate3 == null || TPackDate3 == "")
            {
                dOrder.TPackDate3 = DateTime.Now.Date;
            }
            else
            {
                string d1 = TPackDate3.Substring(0, 2);
                string d2 = TPackDate3.Substring(3, 2);
                string d3 = TPackDate3.Substring(6, 4);
                //  string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.TPackDate3 = DateTime.Parse(d4);
                // dOrder.TPackDate = DateTime.Parse(TPackDate);
                //  dOrder.TPackDate = Convert.ToDateTime(Request.Form["TPackDate"]).Date;
            }

            if (TPackDate4 == null || TPackDate4 == "")
            {
                dOrder.TPackDate4 = DateTime.Now.Date;
            }
            else
            {
                string d1 = TPackDate4.Substring(0, 2);
                string d2 = TPackDate4.Substring(3, 2);
                string d3 = TPackDate4.Substring(6, 4);
                //  string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.TPackDate4 = DateTime.Parse(d4);
                // dOrder.TPackDate = DateTime.Parse(TPackDate);
                //  dOrder.TPackDate = Convert.ToDateTime(Request.Form["TPackDate"]).Date;
            }

            if (IEReceiveDate == null || IEReceiveDate == "")
            {
                dOrder.IEReceiveDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = IEReceiveDate.Substring(0, 2);
                string d2 = IEReceiveDate.Substring(3, 2);
                string d3 = IEReceiveDate.Substring(6, 4);
               // string d4 = d1 + "/" + d2 + "/" + d3;
                    string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.IEReceiveDate = DateTime.Parse(d4);
              //  dOrder.IEReceiveDate = DateTime.Parse(IEReceiveDate);
               // dOrder.IEReceiveDate = Convert.ToDateTime(Request.Form["IEReceiveDate"]).Date;
            }

            if (IEPackDate == null || IEPackDate == "")
            {
                dOrder.IEPackDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = IEPackDate.Substring(0, 2);
                string d2 = IEPackDate.Substring(3, 2);
                string d3 = IEPackDate.Substring(6, 4);
              //  string d4 = d1 + "/" + d2 + "/" + d3;
                   string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.IEPackDate = DateTime.Parse(d4);
              //  dOrder.IEPackDate = DateTime.Parse(IEPackDate);
             //   dOrder.IEPackDate = Convert.ToDateTime(Request.Form["IEPackDate"]).Date;
            }

            if (IEReturnDate == null || IEReturnDate == "")
            {
                dOrder.IEReturnDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = IEReturnDate.Substring(0, 2);
                string d2 = IEReturnDate.Substring(3, 2);
                string d3 = IEReturnDate.Substring(6, 4);
           //     string d4 = d1 + "/" + d2 + "/" + d3;
                    string d4 = d2 + "/" + d1 + "/" + d3;
                    dOrder.IEReturnDate = DateTime.Parse(d4);
             //   dOrder.IECYDate = DateTime.Parse(IECYDate);
              //  dOrder.IECYDate = Convert.ToDateTime(Request.Form["IECYDate"]).Date;
            }

            if (IEETDDate == null || IEETDDate == "")
            {
                dOrder.IEETDDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = IEETDDate.Substring(0, 2);
                string d2 = IEETDDate.Substring(3, 2);
                string d3 = IEETDDate.Substring(6, 4);
             //   string d4 = d1 + "/" + d2 + "/" + d3;
                    string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.IEETDDate = DateTime.Parse(d4);
             //   dOrder.IEETDDate = DateTime.Parse(IEETDDate);
              //  dOrder.IEETDDate = Convert.ToDateTime(Request.Form["IEETDDate"]).Date;
            }

            if (IEETADate == null || IEETADate == "")
            {
                dOrder.IEETADate = DateTime.Now.Date;
            }
            else
            {
                string d1 = IEETADate.Substring(0, 2);
                string d2 = IEETADate.Substring(3, 2);
                string d3 = IEETADate.Substring(6, 4);
             //   string d4 = d1 + "/" + d2 + "/" + d3;
                    string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.IEETADate = DateTime.Parse(d4);
              //  dOrder.IEETADate = DateTime.Parse(IEETADate);
               // dOrder.IEETADate = Convert.ToDateTime(Request.Form["IEETADate"]).Date;
            }

            if (IECLosingDate == null || IECLosingDate == "")
            {
                dOrder.IECLosingDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = IECLosingDate.Substring(0, 2);
                string d2 = IECLosingDate.Substring(3, 2);
                string d3 = IECLosingDate.Substring(6, 4);
               // string d4 = d1 + "/" + d2 + "/" + d3;
                   string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.IECLosingDate = DateTime.Parse(d4);
              //  dOrder.IECLosingDate = DateTime.Parse(IECLosingDate);
             //   dOrder.IECLosingDate = Convert.ToDateTime(Request.Form["IECLosingDate"]).Date;
            }

            string nOID = "";
            if (dOrder.OrderType == 1)
            {
                dOrder.NumberOrder = Convert.ToInt32(Request.Form["Num"]);
                nOID = "PA";

                dOrder.TPackDate1 = null;
                dOrder.TPackDate2 = null;
                dOrder.TPackDate3 = null;
                dOrder.TPackDate4 = null;

                dOrder.TNumberOrder1 = 0;
                dOrder.TNumberOrder2 = 0;
                dOrder.TNumberOrder3 = 0;
                dOrder.TNumberOrder4 = 0;

                
                dOrder.ContainerType1 = null;
                dOrder.ContainerType2 = null;
                dOrder.ContainerType3 = null;
                dOrder.ContainerType4 = null;

                dOrder.IEReceiveDate = null;
                dOrder.IEReceiveTime = null; 
                dOrder.IEPackDate = null;
                dOrder.IEReturnDate = null;
                dOrder.IEETDDate = null;
                dOrder.IEETADate = null;
                dOrder.IECLosingDate = null;
              //  dOrder.IEMap = null;

                dOrder.CustomerID = Convert.ToInt32(Request.Form["Customer1"]);
                dOrder.ShipperID = Convert.ToInt32(Request.Form["Shipper1"]);

                dOrder.RoutID = Convert.ToInt32(Request.Form["Route1"]);

            }
            else if (dOrder.OrderType == 2)
            {
                dOrder.TNumberOrder1 = Convert.ToInt32(Request.Form["Num21"]);
                dOrder.TNumberOrder2 = Convert.ToInt32(Request.Form["Num22"]);
                dOrder.TNumberOrder3 = Convert.ToInt32(Request.Form["Num23"]);
                dOrder.TNumberOrder4 = Convert.ToInt32(Request.Form["Num24"]);

                dOrder.ContainerType1 = Request.Form["CType1"];
                dOrder.ContainerType2 = Request.Form["CType2"];
                dOrder.ContainerType3 = Request.Form["CType3"];
                dOrder.ContainerType4 = Request.Form["CType4"];

                dOrder.CustomerID = Convert.ToInt32(Request.Form["Customer2"]);
                dOrder.ShipperID = Convert.ToInt32(Request.Form["Customer2"]);

                dOrder.RoutID = Convert.ToInt32(Request.Form["Route21"]);
                dOrder.RoutID2 = Convert.ToInt32(Request.Form["Route22"]);
                dOrder.RoutID3 = Convert.ToInt32(Request.Form["Route23"]);
                dOrder.RoutID4 = Convert.ToInt32(Request.Form["Route24"]);

                int TRound1 = 0;
                int TRound2 = 0;
                int TRound3 = 0;
                int TRound4 = 0;

                if (Request.Form["nRound1"] != "")
                {
                    TRound1 = Convert.ToInt32(Request.Form["nRound1"]);
                }
                if (Request.Form["nRound2"] != "")
                {
                    TRound2 = Convert.ToInt32(Request.Form["nRound2"]);
                }
                if (Request.Form["nRound3"] != "")
                {
                    TRound3 = Convert.ToInt32(Request.Form["nRound3"]);
                }
                if (Request.Form["nRound4"] != "")
                {
                    TRound4 = Convert.ToInt32(Request.Form["nRound4"]);
                }


                dOrder.TRound1 = TRound1;
                dOrder.TRound2 = TRound2;
                dOrder.TRound3 = TRound3;
                dOrder.TRound4 = TRound4;


                dOrder.NumberOrder = dOrder.TNumberOrder1 + dOrder.TNumberOrder2 + dOrder.TNumberOrder3 + dOrder.TNumberOrder4;

                if (dOrder.TNumberOrder2 == 0)
                {
                    dOrder.TPackDate2 = null;
                 
                }
                if (dOrder.TNumberOrder3 == 0)
                {
                    dOrder.TPackDate3 = null;

                }
                if (dOrder.TNumberOrder4 == 0)
                {
                    dOrder.TPackDate4 = null;

                }
                nOID = "CK";

                dOrder.PPackDate = null;

                dOrder.IEReceiveDate = null;
                dOrder.IEReceiveTime = null; 
                dOrder.IEPackDate = null;
                dOrder.IEReturnDate = null;
                dOrder.IEETDDate = null;
                dOrder.IEETADate = null;
                dOrder.IECLosingDate = null;
              //  dOrder.IEMap = null;
            }
            else if (dOrder.OrderType == 3)
            {
                dOrder.NumberOrder = Convert.ToInt32(Request.Form["Num3"]);
                nOID = "GL";
                dOrder.PPackDate = null;

                dOrder.TPackDate1 = null;
                dOrder.TPackDate2 = null;
                dOrder.TPackDate3 = null;
                dOrder.TPackDate4 = null;

                dOrder.ContainerType1 = null;
                dOrder.ContainerType2 = null;
                dOrder.ContainerType3 = null;
                dOrder.ContainerType4 = null;

                dOrder.TNumberOrder1 = 0;
                dOrder.TNumberOrder2 = 0;
                dOrder.TNumberOrder3 = 0;
                dOrder.TNumberOrder4 = 0;

                dOrder.CustomerID = Convert.ToInt32(Request.Form["Customer3"]);
                dOrder.ShipperID = Convert.ToInt32(Request.Form["Shipper3"]);

                dOrder.RoutID = Convert.ToInt32(Request.Form["Route3"]);
            
            }

            dOrder.IEType = Convert.ToInt32(Request.Form["IEType"]);
            dOrder.IEShipper = Request.Form["IEShipper"];
            dOrder.IEAgent = Request.Form["IEAgent"];
            dOrder.IELoading = Request.Form["IELoading"];
            dOrder.IEShipping = Request.Form["IEShipping"];
            dOrder.IETelephone = Request.Form["IETelephone"];
            dOrder.IELocationPack = Request.Form["IELocationPack"];
            dOrder.IELocationReceive = Request.Form["IELocationReceive"];
            if (file == null)
            {
                dOrder.IEMap = null;
            }
            else
            {
                dOrder.IEMap = file.FileName;
            }
          //  dOrder.IELiner = Request.Form["IELiner"];
            dOrder.IEPacklTime = Request.Form["IEPacklTime"];
            dOrder.IEFeeder = Request.Form["IEFeeder"];
            dOrder.IEMother = Request.Form["IEMother"];
            dOrder.IEContact = Request.Form["IEContact"];
            dOrder.IEAT = Request.Form["IEAT"];
            dOrder.IETel = Request.Form["IETel"];
            dOrder.IEBill = Request.Form["IEBill"];

            if (Request.Form["IEPortPrice"] == null || Request.Form["IEPortPrice"] == "")
            {
                dOrder.IEPortPrice = 0;

            }
            else
            {
                dOrder.IEPortPrice = Convert.ToDecimal(Request.Form["IEPortPrice"]);
            }

            if (Request.Form["IELanPrice"] == null || Request.Form["IELanPrice"] == "")
            {
                dOrder.IELanPrice = 0;

            }
            else
            {
                dOrder.IELanPrice = Convert.ToDecimal(Request.Form["IELanPrice"]);
            }

            if (Request.Form["IELiftPrice"] == null || Request.Form["IELiftPrice"] == "")
            {
                dOrder.IELiftPrice = 0;

            }
            else
            {
                dOrder.IELiftPrice = Convert.ToDecimal(Request.Form["IELiftPrice"]);
            }

            if (Request.Form["IESCost"] == null || Request.Form["IESCost"] == "")
            {
                dOrder.IESCost = 0;

            }
            else
            {
                dOrder.IESCost = Convert.ToDecimal(Request.Form["IESCost"]);
            }


            if (Request.Form["IESDistance"] == null || Request.Form["IESDistance"] == "")
            {
                dOrder.IESDistance = 0;

            }
            else
            {
                dOrder.IESDistance = Convert.ToDecimal(Request.Form["IESDistance"]);
            }

            dOrder.IEClosingTime = Request.Form["IEClosingTime"];
            dOrder.IEQuantity = Request.Form["IEQuantity"];
            dOrder.IEReceiveTime = Request.Form["IEReceiveTime"];

            string nNum = "";
            string nType = "";
            string tNum = "";
            string tType = "";
            string pNum = "";
            string pnNum = "";
            string tWeight = "";

            string bYM = DateTime.Today.Year.ToString().Substring(2, 2) + DateTime.Today.Month.ToString("00");


            var OrderID = (from o in db.Orders
                             where o.OrderID.Substring(0, 6) == nOID + bYM
                             orderby o.OrderID descending
                             select o.OrderID
                  ).FirstOrDefault();

            string OID = "";
            string ROID = "";
            if (OrderID == null)
            {
                OID = nOID + bYM + "0001";
            }
            else
            {
                ROID = OrderID.Substring(6, 4);
                OID = nOID + bYM + (Convert.ToInt32(ROID) + 1).ToString("0000");
            }

            
            Order AddOrder = new Order();

            AddOrder.OrderType = dOrder.OrderType;
            AddOrder.OrderID = OID;
            AddOrder.BookingNo = dOrder.BookingNo;
            AddOrder.CustomerID = dOrder.CustomerID;
            AddOrder.ShipperID = dOrder.ShipperID;
            AddOrder.OrderDate = dOrder.OrderDate;
            AddOrder.ReceiveDate = dOrder.ReceiveDate;
            AddOrder.DliveryDate = dOrder.DliveryDate;
            AddOrder.RoutID = dOrder.RoutID;
            AddOrder.RoutID2 = dOrder.RoutID2;
            AddOrder.RoutID3 = dOrder.RoutID3;
            AddOrder.RoutID4 = dOrder.RoutID4;
            AddOrder.NumberOrder = dOrder.NumberOrder;
            AddOrder.Remark = dOrder.Remark;
            AddOrder.PPackDate = dOrder.PPackDate;
            AddOrder.TPackDate1 = dOrder.TPackDate1;
            AddOrder.TNumberOrder1 = dOrder.TNumberOrder1;
            AddOrder.ContainerType1 = dOrder.ContainerType1;
            AddOrder.TPackDate2 = dOrder.TPackDate2;
            AddOrder.TNumberOrder2 = dOrder.TNumberOrder2;
            AddOrder.ContainerType2 = dOrder.ContainerType2;
            AddOrder.TPackDate3 = dOrder.TPackDate3;
            AddOrder.TNumberOrder3 = dOrder.TNumberOrder3;
            AddOrder.ContainerType3 = dOrder.ContainerType3;
            AddOrder.TPackDate4 = dOrder.TPackDate4;
            AddOrder.TNumberOrder4 = dOrder.TNumberOrder4;
            AddOrder.ContainerType4 = dOrder.ContainerType4;
            AddOrder.TRound1 = dOrder.TRound1;
            AddOrder.TRound2 = dOrder.TRound2;
            AddOrder.TRound3 = dOrder.TRound3;
            AddOrder.TRound4 = dOrder.TRound4;
            AddOrder.IEType = dOrder.IEType;
            AddOrder.IEShipper = dOrder.IEShipper;
            AddOrder.IEQuantity = dOrder.IEQuantity;
            AddOrder.IEFeeder = dOrder.IEFeeder;
            AddOrder.IEMother = dOrder.IEMother;
            AddOrder.IELoading = dOrder.IELoading;
            AddOrder.IEETADate = dOrder.IEETADate;
            AddOrder.IEETDDate = dOrder.IEETDDate;
            AddOrder.IEReceiveDate = dOrder.IEReceiveDate;
            AddOrder.IEAT = dOrder.IEAT;
            AddOrder.IEContact = dOrder.IEContact;
            AddOrder.IETel = dOrder.IETel;
            AddOrder.IEPackDate = dOrder.IEPackDate;
            AddOrder.IEPacklTime = dOrder.IEPacklTime;
            AddOrder.IELocationPack = dOrder.IELocationPack;
            AddOrder.IEReturnDate = dOrder.IEReturnDate;
            AddOrder.IEReceiveTime = dOrder.IEReceiveTime;
            AddOrder.IELocationReceive = dOrder.IELocationReceive;
            AddOrder.IEShipping = dOrder.IEShipping;
            AddOrder.IETelephone = dOrder.IETelephone;
            AddOrder.IEBill = dOrder.IEBill;
            AddOrder.IEPortPrice = dOrder.IEPortPrice;
            AddOrder.IELanPrice = dOrder.IELanPrice;
            AddOrder.IELiftPrice = dOrder.IELiftPrice;
            AddOrder.IESCost = dOrder.IESCost;
            AddOrder.IESDistance = dOrder.IESDistance;
            AddOrder.IEAgent = dOrder.IEAgent;
            AddOrder.IECLosingDate = dOrder.IECLosingDate;
            AddOrder.IEClosingTime = dOrder.IEClosingTime;
            AddOrder.IEMap = dOrder.IEMap;
            AddOrder.Status = 1;

            db.Orders.Add(AddOrder);
            db.SaveChanges();


            //string path = Path.Combine(Server.MapPath("~/MapFile"), Path.GetFileName(IEMap.FileName));
            //IEMap.SaveAs(path);

            //foreach (string file in Request.Files)
            //{
            //    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
            //    if (hpf.ContentLength == 0)
            //        continue;
            //    string savedFileName = Path.Combine(
            //       AppDomain.CurrentDomain.BaseDirectory,
            //       Path.GetFileName(hpf.FileName));
            //    hpf.SaveAs(savedFileName);

            //}
            if (dOrder.IEMap != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/MapFile"), fileName);
                file.SaveAs(path);
            }
            List<ContainerList> ContainerList = new List<ContainerList>();

            if (dOrder.OrderType == 1)
            {
                for (var i = 1; i <= dOrder.NumberOrder; i++)
                {
                    ContainerList cl = new ContainerList();

                    nNum = "s1nNum" + i;
                    nType = "s1nType" + i;
                    pNum = "s1pNum" + i;
                    pnNum = "s3pnNum" + i;
                    tWeight = "s3tWeight" + i;

                    decimal TareWeight = 0;
                    if (Request.Form[tWeight] != "")
                    {
                        TareWeight = Convert.ToDecimal(Request.Form[tWeight]);
                    }

                    cl.Container = Request.Form[nNum];
                    cl.Position = Request.Form[pNum];
                    cl.PackNo = Request.Form[pnNum];
                    cl.ContainerType = Request.Form[nType];
                    cl.TareWeight = TareWeight;

                    OrderDetail AddOrderDetail = new OrderDetail();
                    AddOrderDetail.OrderID = OID;
                    AddOrderDetail.ContainerNo = cl.Container;
                    AddOrderDetail.Position = cl.Position;
                    AddOrderDetail.PackNo = cl.PackNo;
                    AddOrderDetail.ContainerType = cl.ContainerType;
                    AddOrderDetail.TareWeight = cl.TareWeight;
                    AddOrderDetail.Status = 1;

                    db.OrderDetails.Add(AddOrderDetail);
                    db.SaveChanges();

                    ContainerList.Add(cl);
                }

            }
            else if (dOrder.OrderType == 3)
            {
                for (var i = 1; i <= dOrder.NumberOrder; i++)
                {
                    ContainerList cl = new ContainerList();

                    nNum = "s3nNum" + i;
                    nType = "s3nType" + i;
                    pNum = "s3pNum" + i;
                    pnNum = "s3pnNum" + i;
                    tWeight = "s3tWeight" + i;

                    decimal TareWeight = 0;
                    if (Request.Form[tWeight] != "")
                    {
                        TareWeight = Convert.ToDecimal(Request.Form[tWeight]);
                    }

                    cl.Container = Request.Form[nNum];
                    cl.Position = Request.Form[pNum];
                    cl.PackNo = Request.Form[pnNum];
                    cl.ContainerType = Request.Form[nType];
                    cl.TareWeight = TareWeight;

                    OrderDetail AddOrderDetail = new OrderDetail();
                    AddOrderDetail.OrderID = OID;
                    AddOrderDetail.ContainerNo = cl.Container;
                    AddOrderDetail.Position = cl.Position;
                    AddOrderDetail.PackNo = cl.PackNo;
                    AddOrderDetail.ContainerType = cl.ContainerType;
                    AddOrderDetail.TareWeight = cl.TareWeight;
                    AddOrderDetail.Status = 1;

                    db.OrderDetails.Add(AddOrderDetail);
                    db.SaveChanges();

                    ContainerList.Add(cl);
                }

            }
            else if (dOrder.OrderType == 2)
            {
                if(dOrder.TNumberOrder1 > 0)
                {
                    for (var i = 1; i <= dOrder.TNumberOrder1; i++)
                    {
                        ContainerList cl = new ContainerList();

                        tNum = "s21tNum" + i;
                      //  tType = "tType1" + i;


                        cl.Container = Request.Form[tNum];
                        cl.ContainerType = dOrder.ContainerType1;


                        OrderDetail AddOrderDetail = new OrderDetail();
                        AddOrderDetail.OrderID = OID;
                        AddOrderDetail.ContainerNo = cl.Container;
                        AddOrderDetail.ContainerType = cl.ContainerType;
                        AddOrderDetail.TPackDate = dOrder.TPackDate1;
                        AddOrderDetail.RoutID = dOrder.RoutID;
                        AddOrderDetail.Status = 1;

                        db.OrderDetails.Add(AddOrderDetail);
                        db.SaveChanges();

                        ContainerList.Add(cl);
                    }

                }

                if (dOrder.TNumberOrder2 > 0)
                {
                    for (var i = 1; i <= dOrder.TNumberOrder2; i++)
                    {
                        ContainerList cl = new ContainerList();

                        tNum = "s22tNum" + i;
                     //   tType = "tType2" + i;


                        cl.Container = Request.Form[tNum];
                        cl.ContainerType = dOrder.ContainerType2;


                        OrderDetail AddOrderDetail = new OrderDetail();
                        AddOrderDetail.OrderID = OID;
                        AddOrderDetail.ContainerNo = cl.Container;
                        AddOrderDetail.ContainerType = cl.ContainerType;
                        AddOrderDetail.TPackDate = dOrder.TPackDate2;
                        AddOrderDetail.RoutID = dOrder.RoutID2;
                        AddOrderDetail.Status = 1;

                        db.OrderDetails.Add(AddOrderDetail);
                        db.SaveChanges();

                        ContainerList.Add(cl);
                    }

                }

                if (dOrder.TNumberOrder3 > 0)
                {
                    for (var i = 1; i <= dOrder.TNumberOrder3; i++)
                    {
                        ContainerList cl = new ContainerList();

                        tNum = "s23tNum" + i;
                      //  tType = "tType3" + i;


                        cl.Container = Request.Form[tNum];
                        cl.ContainerType = dOrder.ContainerType3;


                        OrderDetail AddOrderDetail = new OrderDetail();
                        AddOrderDetail.OrderID = OID;
                        AddOrderDetail.ContainerNo = cl.Container;
                        AddOrderDetail.ContainerType = cl.ContainerType;
                        AddOrderDetail.TPackDate = dOrder.TPackDate3;
                        AddOrderDetail.RoutID = dOrder.RoutID3;
                        AddOrderDetail.Status = 1;

                        db.OrderDetails.Add(AddOrderDetail);
                        db.SaveChanges();

                        ContainerList.Add(cl);
                    }

                }
                if (dOrder.TNumberOrder4 > 0)
                {
                    for (var i = 1; i <= dOrder.TNumberOrder4; i++)
                    {
                        ContainerList cl = new ContainerList();

                        tNum = "s24tNum" + i;
                       // tType = "tType1" + i;


                        cl.Container = Request.Form[tNum];
                        cl.ContainerType = dOrder.ContainerType4;


                        OrderDetail AddOrderDetail = new OrderDetail();
                        AddOrderDetail.OrderID = OID;
                        AddOrderDetail.ContainerNo = cl.Container;
                        AddOrderDetail.ContainerType = cl.ContainerType;
                        AddOrderDetail.TPackDate = dOrder.TPackDate4;
                        AddOrderDetail.RoutID = dOrder.RoutID4;
                        AddOrderDetail.Status = 1;

                        db.OrderDetails.Add(AddOrderDetail);
                        db.SaveChanges();

                        ContainerList.Add(cl);
                    }

                }
            }
           

       //     Session["OrderID"] = OID;
        //    return RedirectToAction("OrderInfo", "TMS");
            return RedirectToAction("OrderInfo", "TMS", new { OID = OID });

          
        }
        public ActionResult OrderInfo()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F1";
            string OID = "PA16060001";
            OID = Request.QueryString["OID"];
         
          
            List<OrderInfo> model = new List<OrderInfo>();
            List<OrderDetailInfo> modelD = new List<OrderDetailInfo>();

          
            if (OID.Substring(0,2) == "PA" || OID.Substring(0,2) == "GL")
            {
                var sOrderInfo = (from o in db.Orders
                                  join c in db.Customers on o.CustomerID equals c.ID
                                  join s in db.Shippers on o.ShipperID equals s.ID
                                  join r in db.Routes on o.RoutID equals r.ID
                                  //join r2 in db.Routes on o.RoutID2 equals r2.ID
                                  //join r3 in db.Routes on o.RoutID3 equals r3.ID
                                  //join r4 in db.Routes on o.RoutID4 equals r4.ID
                                  //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                                  //  join d in db.LMS_Driver on b.DriverID equals d.ID
                                  where o.OrderID == OID
                                  select new
                                  {
                                      OrderType = o.OrderType,
                                      OrderID = o.OrderID,
                                      BookingNo = o.BookingNo,
                                      CustomerID = o.CustomerID,
                                      OrderDate = o.OrderDate,
                                      ReceiveDate = o.ReceiveDate,
                                      DliveryDate = o.DliveryDate,
                                      RoutID = o.RoutID,
                                      RoutID2 = o.RoutID2,
                                      RoutID3 = o.RoutID3,
                                      RoutID4 = o.RoutID4,
                                      NumberOrder = o.NumberOrder,
                                      Remark = o.Remark,
                                      PPackDate = o.PPackDate,
                                      TPackDate1 = o.TPackDate1,
                                      TPackDate2 = o.TPackDate2,
                                      TPackDate3 = o.TPackDate3,
                                      TPackDate4 = o.TPackDate4,
                                      TNumberOrder1 = o.TNumberOrder1,
                                      TNumberOrder2 = o.TNumberOrder2,
                                      TNumberOrder3 = o.TNumberOrder3,
                                      TNumberOrder4 = o.TNumberOrder4,
                                      ContainerType1 = o.ContainerType1,
                                      ContainerType2 = o.ContainerType2,
                                      ContainerType3 = o.ContainerType3,
                                      ContainerType4 = o.ContainerType4,

                                      IEType = o.IEType,
                                      IEShipper = o.IEShipper,
                                      IEAgent = o.IEAgent,
                                      IELoading = o.IELoading,
                                      IEShipping = o.IEShipping,
                                      IETelephone = o.IETelephone,
                                      IELocationPack = o.IELocationPack,
                                      IELocationReceive = o.IELocationReceive,
                                      IEMap = o.IEMap,
                                      //  IELiner = o.IELiner,
                                      IEReceiveDate = o.IEReceiveDate,
                                     IEReceiveTime = o.IEReceiveTime,
                                      IEPackDate = o.IEPackDate,
                                      IEPacklTime = o.IEPacklTime,
                                      IEFeeder = o.IEFeeder,
                                      IEMother = o.IEMother,
                                      IEReturnDate = o.IEReturnDate,
                                      IEETDDate = o.IEETDDate,
                                      IEContact = o.IEContact,
                                      IEETADate = o.IEETADate,
                                      IEAT = o.IEAT,
                                      IETel = o.IETel,
                                      IEBill = o.IEBill,
                                      IEPortPrice = o.IEPortPrice,
                                      IELanPrice = o.IELanPrice,
                                      IELiftPrice = o.IELiftPrice,
                                      IESDistance = o.IESDistance,
                                      IESCost = o.IESCost,
                                      IECLosingDate = o.IECLosingDate,
                                      IEClosingTime = o.IEClosingTime,
                                      IEQuantity = o.IEQuantity,
                                      Status = o.Status,

                                      CName = c.Name,
                                      CAddress = c.Address,
                                      CProvince = c.Province,
                                      CZipCode = c.ZipCode,
                                      CTelephone = c.Telephone,

                                      ShipperID = s.ID,
                                      SName = s.Name,
                                      SAddress = s.Address,
                                      SProvince = s.Province,
                                      SZipCode = s.ZipCode,
                                      STelephone = s.Telephone,
                                      TRound1 = o.TRound1,
                                      TRound2 = o.TRound2,
                                      TRound3 = o.TRound3,
                                      TRound4 = o.TRound4,

                                      RFromDetail = r.FromDetail,
                                      RFromProvince = r.FromProvince,
                                      RToDetail = r.ToDetail,
                                      RToProvince = r.ToProvince

                                      //RFromDetail2 = r2.FromDetail,
                                      //RFromProvince2 = r2.FromProvince,
                                      //RToDetail2 = r2.ToDetail,
                                      //RToProvince2 = r2.ToProvince,

                                      //RFromDetail3 = r3.FromDetail,
                                      //RFromProvince3 = r3.FromProvince,
                                      //RToDetail3 = r3.ToDetail,
                                      //RToProvince3 = r3.ToProvince,

                                      //RFromDetail4 = r4.FromDetail,
                                      //RFromProvince4 = r4.FromProvince,
                                      //RToDetail4 = r4.ToDetail,
                                      //RToProvince4 = r4.ToProvince
                                  }
                ).ToList();
                foreach (var ol in sOrderInfo)
                {
                    OrderInfo a = new OrderInfo();

                    a.BookingNo = ol.BookingNo;
                    a.CustomerID = Convert.ToInt32(ol.CustomerID);

                    if (ol.DliveryDate == null)
                    {
                        a.DliveryDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                    }

                    a.IEAgent = ol.IEAgent;
                    a.IEQuantity = ol.IEQuantity;
                    a.IEAT = ol.IEAT;
                    a.IEBill = ol.IEBill;

                    if (ol.IECLosingDate == null)
                    {
                        a.IECLosingDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IECLosingDate = Convert.ToDateTime(ol.IECLosingDate);
                    }


                    a.IEClosingTime = ol.IEClosingTime;
                    a.IEContact = ol.IEContact;

                    if (ol.IEReturnDate == null)
                    {
                        a.IEReturnDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                    }



                    if (ol.IEETADate == null)
                    {
                        a.IEETADate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                    }


                    if (ol.IEETDDate == null)
                    {
                        a.IEETDDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                    }

                    a.IEReceiveTime = ol.IEReceiveTime;
                    a.IEFeeder = ol.IEFeeder;
                    a.IELanPrice = Convert.ToDecimal(ol.IELanPrice);
                    a.IELiftPrice = Convert.ToDecimal(ol.IELiftPrice);
                    a.IESCost = Convert.ToDecimal(ol.IESCost);
                    a.IESDistance = Convert.ToDecimal(ol.IESDistance);
                    //    a.IELiner = ol.IELiner;
                    a.IELoading = ol.IELoading;
                    a.IELocationPack = ol.IELocationPack;
                    a.IELocationReceive = ol.IELocationReceive;
                    a.IEMap = ol.IEMap;
                    a.IEMother = ol.IEMother;

                    if (ol.IEPackDate == null)
                    {
                        a.IEPackDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                    }

                    a.IEPacklTime = ol.IEPacklTime;
                    a.IEPortPrice = Convert.ToDecimal(ol.IEPortPrice);

                    if (ol.IEReceiveDate == null)
                    {
                        a.IEReceiveDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                    }

                    a.IEShipper = ol.IEShipper;
                    a.IEShipping = ol.IEShipping;
                    a.IETel = ol.IETel;
                    a.IETelephone = ol.IETelephone;
                    a.IEType = Convert.ToInt32(ol.IEType);
                    a.NumberOrder = Convert.ToInt32(ol.NumberOrder);

                    if (ol.OrderDate == null)
                    {
                        a.OrderDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                    }

                    a.OrderID = ol.OrderID;
                    a.OrderType = Convert.ToInt32(ol.OrderType);

                    if (ol.PPackDate == null)
                    {
                        a.PPackDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                    }

                    if (ol.ReceiveDate == null)
                    {
                        a.ReceiveDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                    }


                    a.Remark = ol.Remark;
                    a.RoutID = Convert.ToInt32(ol.RoutID);
                    a.RoutID2 = Convert.ToInt32(ol.RoutID2);
                    a.RoutID3 = Convert.ToInt32(ol.RoutID3);
                    a.RoutID4 = Convert.ToInt32(ol.RoutID4);
                    a.Status = Convert.ToInt32(ol.Status);

                    if (ol.TPackDate1 == null)
                    {
                        a.TPackDate1 = DateTime.Now.Date;
                    }
                    else
                    {
                        a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                    }
                    if (ol.TPackDate2 == null)
                    {
                        a.TPackDate2 = DateTime.Now.Date;
                    }
                    else
                    {
                        a.TPackDate2 = Convert.ToDateTime(ol.TPackDate2);
                    }

                    if (ol.TPackDate3 == null)
                    {
                        a.TPackDate3 = DateTime.Now.Date;
                    }
                    else
                    {
                        a.TPackDate3 = Convert.ToDateTime(ol.TPackDate3);
                    }

                    if (ol.TPackDate4 == null)
                    {
                        a.TPackDate4 = DateTime.Now.Date;
                    }
                    else
                    {
                        a.TPackDate4 = Convert.ToDateTime(ol.TPackDate4);
                    }

                    a.TNumberOrder1 = Convert.ToInt32(ol.TNumberOrder1);
                    a.TNumberOrder2 = Convert.ToInt32(ol.TNumberOrder2);
                    a.TNumberOrder3 = Convert.ToInt32(ol.TNumberOrder3);
                    a.TNumberOrder4 = Convert.ToInt32(ol.TNumberOrder4);
                    a.ContainerType1 = ol.ContainerType1;
                    a.ContainerType2 = ol.ContainerType2;
                    a.ContainerType3 = ol.ContainerType3;
                    a.ContainerType4 = ol.ContainerType4;
                    a.CAddress = ol.CAddress;
                    a.CProvince = ol.CProvince;
                    a.CName = ol.CName;
                    a.CTelephone = ol.CTelephone;
                    a.CZipCode = ol.CZipCode;
                    a.SAddress = ol.SAddress;
                    a.SProvince = ol.SProvince;
                    a.SName = ol.SName;
                    a.STelephone = ol.STelephone;
                    a.SZipCode = ol.SZipCode;
                    a.ShipperID = ol.ShipperID;
                    a.TRound1 = Convert.ToInt32(ol.TRound1);
                    a.TRound2 = Convert.ToInt32(ol.TRound2);
                    a.TRound3 = Convert.ToInt32(ol.TRound3);
                    a.TRound4 = Convert.ToInt32(ol.TRound4);

                    a.RFromDetail = ol.RFromDetail;
                    a.RFromProvince = ol.RFromProvince;
                    a.RToDetail = ol.RToDetail;
                    a.RToProvince = ol.RToProvince;

                    //a.RFromDetail2 = ol.RFromDetail2;
                    //a.RFromProvince2 = ol.RFromProvince2;
                    //a.RToDetail2 = ol.RToDetail2;
                    //a.RToProvince2 = ol.RToProvince2;

                    //a.RFromDetail3 = ol.RFromDetail3;
                    //a.RFromProvince3 = ol.RFromProvince3;
                    //a.RToDetail3 = ol.RToDetail3;
                    //a.RToProvince3 = ol.RToProvince3;

                    //a.RFromDetail4 = ol.RFromDetail4;
                    //a.RFromProvince4 = ol.RFromProvince4;
                    //a.RToDetail4 = ol.RToDetail4;
                    //a.RToProvince4 = ol.RToProvince4;
                    model.Add(a);

                }
            }
            else
            {
                var sOrderInfo = (from o in db.Orders
                                  join c in db.Customers on o.CustomerID equals c.ID
                                  join r in db.Routes on o.RoutID equals r.ID into RouteG1 
                                  from rg1 in RouteG1.DefaultIfEmpty()
                                  join r2 in db.Routes on o.RoutID2 equals r2.ID into RouteG2
                                  from rg2 in RouteG2.DefaultIfEmpty()
                                  join r3 in db.Routes on o.RoutID3 equals r3.ID into RouteG3
                                  from rg3 in RouteG3.DefaultIfEmpty()
                                  join r4 in db.Routes on o.RoutID4 equals r4.ID into RouteG4
                                  from rg4 in RouteG4.DefaultIfEmpty()
                                  //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                                  //  join d in db.LMS_Driver on b.DriverID equals d.ID
                                  where o.OrderID == OID
                                  select new
                                  {
                                      
                                      OrderType = o.OrderType,
                                      OrderID = o.OrderID,
                                      BookingNo = o.BookingNo,
                                      CustomerID = o.CustomerID,
                                      OrderDate = o.OrderDate,
                                      ReceiveDate = o.ReceiveDate,
                                      DliveryDate = o.DliveryDate,
                                      RoutID = o.RoutID,
                                      RoutID2 = o.RoutID2,
                                      RoutID3 = o.RoutID3,
                                      RoutID4 = o.RoutID4,
                                      NumberOrder = o.NumberOrder,
                                      Remark = o.Remark,
                                      PPackDate = o.PPackDate,
                                      TPackDate1 = o.TPackDate1,
                                      TPackDate2 = o.TPackDate2,
                                      TPackDate3 = o.TPackDate3,
                                      TPackDate4 = o.TPackDate4,
                                      TNumberOrder1 = o.TNumberOrder1,
                                      TNumberOrder2 = o.TNumberOrder2,
                                      TNumberOrder3 = o.TNumberOrder3,
                                      TNumberOrder4 = o.TNumberOrder4,
                                      ContainerType1 = o.ContainerType1,
                                      ContainerType2 = o.ContainerType2,
                                      ContainerType3 = o.ContainerType3,
                                      ContainerType4 = o.ContainerType4,

                                      IEType = o.IEType,
                                      IEShipper = o.IEShipper,
                                      IEAgent = o.IEAgent,
                                      IELoading = o.IELoading,
                                      IEShipping = o.IEShipping,
                                      IETelephone = o.IETelephone,
                                      IELocationPack = o.IELocationPack,
                                      IELocationReceive = o.IELocationReceive,
                                      IEMap = o.IEMap,
                                      //  IELiner = o.IELiner,
                                      IEReceiveDate = o.IEReceiveDate,
                                      IEReceiveTime = o.IEReceiveTime,
                                      IEPackDate = o.IEPackDate,
                                      IEPacklTime = o.IEPacklTime,
                                      IEFeeder = o.IEFeeder,
                                      IEMother = o.IEMother,
                                      IEReturnDate = o.IEReturnDate,
                                      IEETDDate = o.IEETDDate,
                                      IEContact = o.IEContact,
                                      IEETADate = o.IEETADate,
                                      IEAT = o.IEAT,
                                      IETel = o.IETel,
                                      IEBill = o.IEBill,
                                      IEPortPrice = o.IEPortPrice,
                                      IELanPrice = o.IELanPrice,
                                      IELiftPrice = o.IELiftPrice,
                                      IESDistance = o.IESDistance,
                                      IESCost = o.IESCost,
                                      IECLosingDate = o.IECLosingDate,
                                      IEClosingTime = o.IEClosingTime,
                                      IEQuantity = o.IEQuantity,
                                      Status = o.Status,

                                      CName = c.Name,
                                      CAddress = c.Address,
                                      CProvince = c.Province,
                                      CZipCode = c.ZipCode,
                                      CTelephone = c.Telephone,

                                      //ShipperID = s.ID,
                                      //SName = s.Name,
                                      //SAddress = s.Address,
                                      //SProvince = s.Province,
                                      //SZipCode = s.ZipCode,
                                      //STelephone = s.Telephone,
                                      TRound1 = o.TRound1,
                                      TRound2 = o.TRound2,
                                      TRound3 = o.TRound3,
                                      TRound4 = o.TRound4,

                                      RFromDetail = rg1.FromDetail,
                                      RFromProvince = rg1.FromProvince,
                                      RToDetail = rg1.ToDetail,
                                      RToProvince = rg1.ToProvince,

                                      RFromDetail2 = rg2.FromDetail,
                                      RFromProvince2 = rg2.FromProvince,
                                      RToDetail2 = rg2.ToDetail,
                                      RToProvince2 = rg2.ToProvince,

                                      RFromDetail3 = rg3.FromDetail,
                                      RFromProvince3 = rg3.FromProvince,
                                      RToDetail3 = rg3.ToDetail,
                                      RToProvince3 = rg3.ToProvince,

                                      RFromDetail4 = rg4.FromDetail,
                                      RFromProvince4 = rg4.FromProvince,
                                      RToDetail4 = rg4.ToDetail,
                                      RToProvince4 = rg4.ToProvince
                                  }
              ).ToList();
                foreach (var ol in sOrderInfo)
                {
                    OrderInfo a = new OrderInfo();

                    a.BookingNo = ol.BookingNo;
                    a.CustomerID = Convert.ToInt32(ol.CustomerID);

                    if (ol.DliveryDate == null)
                    {
                        a.DliveryDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                    }

                    a.IEAgent = ol.IEAgent;
                    a.IEQuantity = ol.IEQuantity;
                    a.IEAT = ol.IEAT;
                    a.IEBill = ol.IEBill;

                    if (ol.IECLosingDate == null)
                    {
                        a.IECLosingDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IECLosingDate = Convert.ToDateTime(ol.IECLosingDate);
                    }


                    a.IEClosingTime = ol.IEClosingTime;
                    a.IEContact = ol.IEContact;

                    if (ol.IEReturnDate == null)
                    {
                        a.IEReturnDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                    }



                    if (ol.IEETADate == null)
                    {
                        a.IEETADate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                    }


                    if (ol.IEETDDate == null)
                    {
                        a.IEETDDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                    }

                    a.IEReceiveTime = ol.IEReceiveTime;
                    a.IEFeeder = ol.IEFeeder;
                    a.IELanPrice = Convert.ToDecimal(ol.IELanPrice);
                    a.IELiftPrice = Convert.ToDecimal(ol.IELiftPrice);
                    a.IESCost = Convert.ToDecimal(ol.IESCost);
                    a.IESDistance = Convert.ToDecimal(ol.IESDistance);
                    //    a.IELiner = ol.IELiner;
                    a.IELoading = ol.IELoading;
                    a.IELocationPack = ol.IELocationPack;
                    a.IELocationReceive = ol.IELocationReceive;
                    a.IEMap = ol.IEMap;
                    a.IEMother = ol.IEMother;

                    if (ol.IEPackDate == null)
                    {
                        a.IEPackDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                    }

                    a.IEPacklTime = ol.IEPacklTime;
                    a.IEPortPrice = Convert.ToDecimal(ol.IEPortPrice);

                    if (ol.IEReceiveDate == null)
                    {
                        a.IEReceiveDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                    }

                    a.IEShipper = ol.IEShipper;
                    a.IEShipping = ol.IEShipping;
                    a.IETel = ol.IETel;
                    a.IETelephone = ol.IETelephone;
                    a.IEType = Convert.ToInt32(ol.IEType);
                    a.NumberOrder = Convert.ToInt32(ol.NumberOrder);

                    if (ol.OrderDate == null)
                    {
                        a.OrderDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                    }

                    a.OrderID = ol.OrderID;
                    a.OrderType = Convert.ToInt32(ol.OrderType);

                    if (ol.PPackDate == null)
                    {
                        a.PPackDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                    }

                    if (ol.ReceiveDate == null)
                    {
                        a.ReceiveDate = DateTime.Now.Date;
                    }
                    else
                    {
                        a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                    }


                    a.Remark = ol.Remark;
                    a.RoutID = Convert.ToInt32(ol.RoutID);
                    a.RoutID2 = Convert.ToInt32(ol.RoutID2);
                    a.RoutID3 = Convert.ToInt32(ol.RoutID3);
                    a.RoutID4 = Convert.ToInt32(ol.RoutID4);
                    a.Status = Convert.ToInt32(ol.Status);

                    if (ol.TPackDate1 == null)
                    {
                        a.TPackDate1 = DateTime.Now.Date;
                    }
                    else
                    {
                        a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                    }
                    if (ol.TPackDate2 == null)
                    {
                        a.TPackDate2 = DateTime.Now.Date;
                    }
                    else
                    {
                        a.TPackDate2 = Convert.ToDateTime(ol.TPackDate2);
                    }

                    if (ol.TPackDate3 == null)
                    {
                        a.TPackDate3 = DateTime.Now.Date;
                    }
                    else
                    {
                        a.TPackDate3 = Convert.ToDateTime(ol.TPackDate3);
                    }

                    if (ol.TPackDate4 == null)
                    {
                        a.TPackDate4 = DateTime.Now.Date;
                    }
                    else
                    {
                        a.TPackDate4 = Convert.ToDateTime(ol.TPackDate4);
                    }

                    a.TNumberOrder1 = Convert.ToInt32(ol.TNumberOrder1);
                    a.TNumberOrder2 = Convert.ToInt32(ol.TNumberOrder2);
                    a.TNumberOrder3 = Convert.ToInt32(ol.TNumberOrder3);
                    a.TNumberOrder4 = Convert.ToInt32(ol.TNumberOrder4);
                    a.ContainerType1 = ol.ContainerType1;
                    a.ContainerType2 = ol.ContainerType2;
                    a.ContainerType3 = ol.ContainerType3;
                    a.ContainerType4 = ol.ContainerType4;
                    a.CAddress = ol.CAddress;
                    a.CProvince = ol.CProvince;
                    a.CName = ol.CName;
                    a.CTelephone = ol.CTelephone;
                    a.CZipCode = ol.CZipCode;

                    //a.SAddress = ol.SAddress;
                    //a.SProvince = ol.SProvince;
                    //a.SName = ol.SName;
                    //a.STelephone = ol.STelephone;
                    //a.SZipCode = ol.SZipCode;
                    //a.ShipperID = ol.ShipperID;
                    a.TRound1 = Convert.ToInt32(ol.TRound1);
                    a.TRound2 = Convert.ToInt32(ol.TRound2);
                    a.TRound3 = Convert.ToInt32(ol.TRound3);
                    a.TRound4 = Convert.ToInt32(ol.TRound4);
                    a.RFromDetail = ol.RFromDetail;
                    a.RFromProvince = ol.RFromProvince;
                    a.RToDetail = ol.RToDetail;
                    a.RToProvince = ol.RToProvince;

                    a.RFromDetail2 = ol.RFromDetail2;
                    a.RFromProvince2 = ol.RFromProvince2;
                    a.RToDetail2 = ol.RToDetail2;
                    a.RToProvince2 = ol.RToProvince2;

                    a.RFromDetail3 = ol.RFromDetail3;
                    a.RFromProvince3 = ol.RFromProvince3;
                    a.RToDetail3 = ol.RToDetail3;
                    a.RToProvince3 = ol.RToProvince3;

                    a.RFromDetail4 = ol.RFromDetail4;
                    a.RFromProvince4 = ol.RFromProvince4;
                    a.RToDetail4 = ol.RToDetail4;
                    a.RToProvince4 = ol.RToProvince4;
                    model.Add(a);

                }
            }
               

             
                var sOrderDetailInfo = (from od in db.OrderDetails
                                  //join c in db.Customers on o.CustomerID equals c.ID
                                  //join r in db.Routes on o.RoutID equals r.ID
                                  //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                                  //  join d in db.LMS_Driver on b.DriverID equals d.ID
                                  where od.OrderID == OID
                                  select new
                                  {
                                      ContainerNo = od.ContainerNo,
                                      ContainerType = od.ContainerType,
                                      Position = od.Position,
                                      PackNo = od.PackNo,
                                      TPackDate = od.TPackDate,
                                      RouteID = od.RoutID,
                                      TareWeight = od.TareWeight,
                                      Status = od.Status
                                  }
).ToList();

              foreach (var odl in sOrderDetailInfo)
            {
                OrderDetailInfo b = new OrderDetailInfo();
                  int RouteID = 0;
                  decimal TareWeight = 0;

                  if (odl.RouteID != null)
                  {
                      RouteID = Convert.ToInt32(odl.RouteID);
                  }

                  if (odl.TareWeight != null)
                  {
                      TareWeight = Convert.ToDecimal(odl.TareWeight);
                  }

                b.ContainerNo = odl.ContainerNo;
                b.ContainerType = odl.ContainerType;
                b.PackNo = odl.PackNo;
                b.Position = odl.Position;
              

                if (odl.TPackDate == null)
                {
                    b.TPackDate = DateTime.Now.Date;
                }
                else
                {
                    b.TPackDate = Convert.ToDateTime(odl.TPackDate);
                }
                b.RouteID = RouteID;
                b.TareWeight = TareWeight;
                b.Status = Convert.ToInt32(odl.Status);
                modelD.Add(b);

            }
        
              return View(Tuple.Create(model, modelD)); 
        }
        public ActionResult OrderList()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F1";
            List<OrderInfo> model = new List<OrderInfo>();


            var sOrderInfo = (from o in db.Orders
                              join c in db.Customers on o.CustomerID equals c.ID
                              join r in db.Routes on o.RoutID equals r.ID
                              //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                              //  join d in db.LMS_Driver on b.DriverID equals d.ID
                              //   where o.OrderID == OID
                              orderby o.OrderID descending
                              select new
                              {
                                  OrderType = o.OrderType,
                                  OrderID = o.OrderID,
                                  BookingNo = o.BookingNo,
                                  CustomerID = o.CustomerID,
                                  OrderDate = o.OrderDate,
                                  ReceiveDate = o.ReceiveDate,
                                  DliveryDate = o.DliveryDate,
                                  RoutID = o.RoutID,
                                  NumberOrder = o.NumberOrder,
                                  Remark = o.Remark,
                                  PPackDate = o.PPackDate,
                                  TPackDate1 = o.TPackDate1,
                                  TPackDate2 = o.TPackDate2,
                                  TPackDate3 = o.TPackDate3,
                                  TPackDate4 = o.TPackDate4,
                                  TNumberOrder1 = o.TNumberOrder1,
                                  TNumberOrder2 = o.TNumberOrder2,
                                  TNumberOrder3 = o.TNumberOrder3,
                                  TNumberOrder4 = o.TNumberOrder4,
                                  IEType = o.IEType,
                                  IEShipper = o.IEShipper,
                                  IEAgent = o.IEAgent,
                                  IELoading = o.IELoading,
                                  IEShipping = o.IEShipping,
                                  IETelephone = o.IETelephone,
                                  IELocationPack = o.IELocationPack,
                                  IELocationReceive = o.IELocationReceive,
                                  IEMap = o.IEMap,
                                //  IELiner = o.IELiner,
                                  IEReceiveDate = o.IEReceiveDate,
                                  IEPackDate = o.IEPackDate,
                                  IEPacklTime = o.IEPacklTime,
                                  IEFeeder = o.IEFeeder,
                                  IEMother = o.IEMother,
                                  IEReturnDate = o.IEReturnDate,
                                  IEETDDate = o.IEETDDate,
                                  IEContact = o.IEContact,
                                  IEETADate = o.IEETADate,
                                  IEAT = o.IEAT,
                                  IETel = o.IETel,
                                  IEBill = o.IEBill,
                                  IEPortPrice = o.IEPortPrice,
                                  IELanPrice = o.IELanPrice,
                                  IELiftPrice = o.IELiftPrice,
                                  IECLosingDate = o.IECLosingDate,
                                  IEClosingTime = o.IEClosingTime,
                                  IEQuantity = o.IEQuantity,
                                  Status = o.Status,

                                  CName = c.Name,
                                  CAddress = c.Address,
                                  CProvince = c.Province,
                                  CZipCode = c.ZipCode,
                                  CTelephone = c.Telephone,

                                  RFromDetail = r.FromDetail,
                                  RFromProvince = r.FromProvince,
                                  RToDetail = r.ToDetail,
                                  RToProvince = r.ToProvince
                              }
             ).ToList();

            foreach (var ol in sOrderInfo)
            {
                OrderInfo a = new OrderInfo();

                a.BookingNo = ol.BookingNo;
                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }

                a.IEAgent = ol.IEAgent;
                a.IEQuantity = ol.IEQuantity;
                a.IEAT = ol.IEAT;
                a.IEBill = ol.IEBill;

                if (ol.IECLosingDate == null)
                {
                    a.IECLosingDate = DateTime.Now.Date;
                }
                else
                {
                    a.IECLosingDate = Convert.ToDateTime(ol.IECLosingDate);
                }


                a.IEClosingTime = ol.IEClosingTime;
                a.IEContact = ol.IEContact;

                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                a.IEFeeder = ol.IEFeeder;
                a.IELanPrice = Convert.ToDecimal(ol.IELanPrice);
                a.IELiftPrice = Convert.ToDecimal(ol.IELiftPrice);
              //  a.IELiner = ol.IELiner;
                a.IELoading = ol.IELoading;
                a.IELocationPack = ol.IELocationPack;
                a.IELocationReceive = ol.IELocationReceive;
                a.IEMap = ol.IEMap;
                a.IEMother = ol.IEMother;

                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;
                a.IEPortPrice = Convert.ToDecimal(ol.IEPortPrice);

                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }

                a.IEShipper = ol.IEShipper;
                a.IEShipping = ol.IEShipping;
                a.IETel = ol.IETel;
                a.IETelephone = ol.IETelephone;
                a.IEType = Convert.ToInt32(ol.IEType);
                a.NumberOrder = Convert.ToInt32(ol.NumberOrder);

                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }

                a.OrderID = ol.OrderID;
                a.OrderType = Convert.ToInt32(ol.OrderType);

                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.Remark = ol.Remark;
                a.RoutID = Convert.ToInt32(ol.RoutID);
                a.Status = Convert.ToInt32(ol.Status);

                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }


                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;

                model.Add(a);

            }

            return View(model);

        }
        //public ActionResult Jobs()
        //{
        //    List<JobList> model = new List<JobList>();
        //    List<JOrderList> JOrderList = new List<JOrderList>();

        //    string J = Request.QueryString["J"];
        //    string OID = Request.QueryString["OID"];
        //    string ODID = Request.QueryString["ODID"];
        //    string OT = Request.QueryString["OT"];
        //    string C = Request.QueryString["C"];
        //    string T = Request.QueryString["T"];
        //    string H = Request.QueryString["H"];
        //    string D = Request.QueryString["D"];
        //    string TD = Request.QueryString["TD"];
        //    string HD = Request.QueryString["HD"];
        //    string S = Request.QueryString["S"];
        //    string SC = Request.QueryString["SC"];

        //    var jOrder = (from o in db.Orders
        //                      join c in db.Customers on o.CustomerID equals c.ID
        //                      join r in db.Routes on o.RoutID equals r.ID
        //                      //join a in db.LMS_SubAgent on b.AgentID equals a.ID
        //                      //  join d in db.LMS_Driver on b.DriverID equals d.ID
        //                      where o.Status == 1 || o.Status == 2
        //                      orderby o.ReceiveDate,o.DliveryDate,o.OrderID descending
        //                      select new
        //                      {
        //                          OrderType = o.OrderType,
        //                          OrderID = o.OrderID,
        //                          BookingNo = o.BookingNo,
        //                          CustomerID = o.CustomerID,
        //                          OrderDate = o.OrderDate,
        //                          ReceiveDate = o.ReceiveDate,
        //                          DliveryDate = o.DliveryDate,
        //                          RoutID = o.RoutID,
        //                          NumberOrder = o.NumberOrder,
        //                          Remark = o.Remark,
        //                          PPackDate = o.PPackDate,
        //                          TPackDate1 = o.TPackDate1,
        //                          TPackDate2 = o.TPackDate2,
        //                          TPackDate3 = o.TPackDate3,
        //                          TPackDate4 = o.TPackDate4,
        //                          TNumberOrder1 = o.TNumberOrder1,
        //                          TNumberOrder2 = o.TNumberOrder2,
        //                          TNumberOrder3 = o.TNumberOrder3,
        //                          TNumberOrder4 = o.TNumberOrder4,
        //                          IEType = o.IEType,
        //                          IEShipper = o.IEShipper,
        //                          IEAgent = o.IEAgent,
        //                          IELoading = o.IELoading,
        //                          IEShipping = o.IEShipping,
        //                          IETelephone = o.IETelephone,
        //                          IELocationPack = o.IELocationPack,
        //                          IELocationReceive = o.IELocationReceive,
        //                          IEMap = o.IEMap,
        //                        //  IELiner = o.IELiner,
        //                          IEReceiveDate = o.IEReceiveDate,
        //                          IEPackDate = o.IEPackDate,
        //                          IEPacklTime = o.IEPacklTime,
        //                          IEFeeder = o.IEFeeder,
        //                          IEMother = o.IEMother,
        //                       //   IECYDate = o.IECYDate,
        //                          IEETDDate = o.IEETDDate,
        //                          IEContact = o.IEContact,
        //                          IEETADate = o.IEETADate,
        //                          IEAT = o.IEAT,
        //                          IETel = o.IETel,
        //                          IEBill = o.IEBill,
        //                          IEPortPrice = o.IEPortPrice,
        //                          IELanPrice = o.IELanPrice,
        //                          IELiftPrice = o.IELiftPrice,
        //                          IECLosingDate = o.IECLosingDate,
        //                          IEClosingTime = o.IEClosingTime,
        //                          IEQuantity = o.IEQuantity,
        //                          IEReturnDate = o.IEReturnDate,
        //                          Status = o.Status,

        //                          CName = c.Name,
        //                          CAddress = c.Address,
        //                          CProvince = c.Province,
        //                          CZipCode = c.ZipCode,
        //                          CTelephone = c.Telephone,

        //                          RFromDetail = r.FromDetail,
        //                          RFromProvince = r.FromProvince,
        //                          RToDetail = r.ToDetail,
        //                          RToProvince = r.ToProvince
        //                      }
        //     ).ToList();

        //    foreach (var ol in jOrder)
        //    {
        //        JOrderList jol = new JOrderList();

        //        jol.OrderID = ol.OrderID;
        //        jol.BookingNo = ol.BookingNo;
        //        jol.CustomerID = Convert.ToInt32(ol.CustomerID);
        //        jol.OrderType = Convert.ToInt32(ol.OrderType);
        //        if (ol.DliveryDate == null)
        //        {
        //            jol.DliveryDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            jol.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
        //        }



        //        jol.NumberOrder = Convert.ToInt32(ol.NumberOrder);

               

        //        if (ol.ReceiveDate == null)
        //        {
        //            jol.ReceiveDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            jol.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
        //        }

        //        if (ol.TPackDate1 == null)
        //        {
        //            jol.TPackDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            jol.TPackDate = Convert.ToDateTime(ol.TPackDate1);
        //        }

        //        if (ol.IEReceiveDate == null)
        //        {
        //            jol.IEReceiveDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            jol.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
        //        }

        //        jol.RoutID = Convert.ToInt32(ol.RoutID);
        //        jol.Status = Convert.ToInt32(ol.Status);

        //      JOrderList.Add(jol);
                
        //    }

        //    List<JOrderDList> JOrderDList = new List<JOrderDList>();
        //        var jOrderD = (from od in db.OrderDetails               
        //                       where od.OrderID == OID
        //                       select new
        //                       {
        //                           ODID = od.ID,
        //                           ContainerNo = od.ContainerNo,
        //                           ContainerType = od.ContainerType,
        //                           TPackDate = od.TPackDate,
        //                           Position = od.Position,
        //                           PackNo = od.PackNo,
        //                           Status = od.Status
        //                       }
        //        ).ToList();

        //        foreach (var odl in jOrderD)
        //        {
        //            JOrderDList jd = new JOrderDList();

        //            jd.ID = odl.ODID;
        //            jd.ContainerNo = odl.ContainerNo;
        //            jd.ContainerType = odl.ContainerType;
        //            jd.PackNo = odl.PackNo;
        //            jd.Position = odl.Position;
        //            jd.TPackDate = Convert.ToDateTime(odl.TPackDate);
        //            jd.Status = Convert.ToInt32(odl.Status);

        //            JOrderDList.Add(jd);

        //        }

        //        List<JTruckList> JTruckList = new List<JTruckList>();
        //        var jTruck = (from t in db.Trucks
        //                      join d in db.Drivers on t.ID equals d.TruckID
        //                       where t.TruckType == "1"
        //                       select new
        //                       {
        //                           TID = t.ID,
        //                           HID = t.HitchID,
        //                           DID = d.ID,
        //                           License = t.License,
        //                           HitchLicense = t.HitchLicense,
        //                           DTitle =d.Title,
        //                           DFirstName = d.FirstName,
        //                           DLastName = d.LastName,
        //                           TStatus = t.Status
        //                       }
        //        ).ToList();

        //        foreach (var tl in jTruck)
        //        {
        //            JTruckList td = new JTruckList();

        //            td.DFirstName = tl.DFirstName;
        //            td.DID = Convert.ToInt32(tl.DID);
        //            td.DLastName = tl.DLastName;
        //            td.DTitle = tl.DTitle;
        //            td.HID = Convert.ToInt32(tl.HID);
        //            td.HitchLicense = tl.HitchLicense;
        //            td.License = tl.License;
        //            td.TID = Convert.ToInt32(tl.TID);
        //            td.TStatus = Convert.ToInt32(tl.TStatus);


        //            JTruckList.Add(td);

        //        }

        //        List<JSubList> JSubList = new List<JSubList>();
        //        var JSub = (from s in db.SubContacts
        //                   //   join d in db.Drivers on t.ID equals d.TruckID
        //                      //where
        //                      select new
        //                      {
        //                          SID = s.ID,
        //                          SCode = s.Code,
        //                          SName = s.Name
                                 
        //                      }
        //        ).ToList();

        //        foreach (var sl in JSub)
        //        {
        //            JSubList sd = new JSubList();

        //            sd.SCode = sl.SCode;
        //            sd.SID = sl.SID;
        //            sd.SName = sl.SName;


        //            JSubList.Add(sd);

        //        }

        //        int nT = 0;
        //        int nD = 0;
        //        int nH = 0;
        //        int nS = 0;

        //        if (T != "")
        //        {
        //            nT = Convert.ToInt32(T);
        //        }
        //        if (D != "")
        //        {
        //            nD = Convert.ToInt32(D);
        //        }
        //        if (H != "")
        //        {
        //            nH = Convert.ToInt32(H);
        //        }
        //        if (S != "")
        //        {
        //            nS = Convert.ToInt32(S);
        //        }
        //        List<JJobList> JJobList = new List<JJobList>();
        //    if (C == "1")
        //    {
        //        var JJob = (from j in db.Jobs
        //                    join o in db.Orders on j.OrderID equals o.OrderID
        //                    where j.TruckID == nT && j.HitchID == nH && j.DriverID == nD && j.Status != 4
                          
        //                    //where
        //                    select new
        //                    {
        //                        JID = j.ID,
        //                        OrderID  = j.OrderID,
        //                        ODID = j.ODID,
        //                        ContainerNo = j.ContainerNo,
        //                        Status = j.Status,
        //                        ReceiveDate = o.ReceiveDate,
        //                        DliveryDate = o.DliveryDate,
        //                        PPackDate = o.PPackDate,
        //                        IEPackDate = o.IEPackDate,
        //                        IEReceiveDate = o.IEReceiveDate,
        //                        IEReturnDate  = o.IEReturnDate

        //                    }
        //        ).ToList();

        //        foreach (var jl in JJob)
        //        {
        //            JJobList jd = new JJobList();

        //            jd.ContainerNo = jl.ContainerNo;
        //            jd.DliveryDate = Convert.ToDateTime(jl.DliveryDate).Date;
        //            jd.PPackDate = Convert.ToDateTime(jl.PPackDate).Date;
        //            jd.IEPackDate = Convert.ToDateTime(jl.IEPackDate).Date;
        //            jd.IEReceiveDate = Convert.ToDateTime(jl.IEReceiveDate).Date;
        //            jd.IEReturnDate = Convert.ToDateTime(jl.IEReceiveDate).Date;
        //            jd.JID = jl.JID;
        //            jd.ODID = Convert.ToInt32(jl.ODID);
        //            jd.OrderID = jl.OrderID;
        //            jd.ReceiveDate = Convert.ToDateTime(jl.ReceiveDate).Date;
        //            jd.Status = Convert.ToInt32(jl.Status);

        //            JJobList.Add(jd);

        //        }
        //    }
        //    else if (C == "2")
        //    {
        //        var JJob = (from j in db.Jobs
        //                    join o in db.Orders on j.OrderID equals o.OrderID
        //                    where j.OrderID == OID && j.SID == nS

        //                    //where
        //                    select new
        //                    {
        //                        JID = j.ID,
        //                        OrderID = j.OrderID,
        //                        ODID = j.ODID,
        //                        ContainerNo = j.ContainerNo,
        //                        Status = j.Status,
        //                        ReceiveDate = o.ReceiveDate,
        //                        DliveryDate = o.DliveryDate
        //                    }
        //        ).ToList();

        //        foreach (var jl in JJob)
        //        {
        //            JJobList jd = new JJobList();

        //            jd.ContainerNo = jl.ContainerNo;
        //            jd.DliveryDate = Convert.ToDateTime(jl.DliveryDate).Date;
        //            jd.JID = jl.JID;
        //            jd.ODID = Convert.ToInt32(jl.ODID);
        //            jd.OrderID = jl.OrderID;
        //            jd.ReceiveDate = Convert.ToDateTime(jl.ReceiveDate).Date;
        //            jd.Status = Convert.ToInt32(jl.Status);

        //            JJobList.Add(jd);

        //        }
        //    }

        //    int nOD = 0;

        //    if (ODID != "")
        //    {
        //        nOD = Convert.ToInt32(ODID);
        //    }

        //    List<JOrderAdd> JOrderAdd = new List<JOrderAdd>();
        //    var JOA = (from o in db.Orders
        //               join od in db.OrderDetails on o.OrderID equals od.OrderID
        //               join c in db.Customers on o.CustomerID equals c.ID
        //               join r in db.Routes on o.RoutID equals r.ID
        //                where o.OrderID == OID && od.ID == nOD

        //                //where
        //                select new
        //                {
   
        //                    OrderID = o.OrderID,
        //                    ReceiveDate = o.ReceiveDate,
        //                    DliveryDate = o.DliveryDate,
        //                    OrderType = o.OrderType,
        //                   CustomerID = o.CustomerID,
        //                    RouteID = o.RoutID,

        //                      ODID = od.ID,
        //                   ContainerNo = od.ContainerNo,
        //                   ContainerType = od.ContainerType,
        //                   TPackDate = od.TPackDate,
        //                    PPackDate = o.PPackDate,
        //                   IEReceiveDate = o.IEReceiveDate,
        //                   IEPackDate = o.IEPackDate,
        //                   IEReturnDate = o.IEReturnDate,
        //                   Position = od.Position,
        //                   PackNo = od.PackNo,
        //                    CustomerName = c.Name,
        //                    rToDetail = r.ToDetail,
        //                    rFromDetail = r.FromDetail
        //                }
        //        ).ToList();

        //    foreach (var joal in JOA)
        //    {
        //        JOrderAdd joad = new JOrderAdd();

        //        joad.CustomerID = Convert.ToInt32(joal.CustomerID);
        //        joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate).Date;
        //        joad.TPackDate = Convert.ToDateTime(joal.TPackDate).Date;
        //        joad.PPackDate = Convert.ToDateTime(joal.PPackDate).Date;
        //        joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate).Date;
        //        joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate).Date;
        //        joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate).Date;
        //        joad.OrderID = joal.OrderID;
        //        joad.OrderType = Convert.ToInt32(joal.OrderType);
        //        joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate).Date;
        //        joad.RouteID = Convert.ToInt32(joal.RouteID);
        //        joad.ContainerNo = joal.ContainerNo;
        //        joad.ContainerType = joal.ContainerType;
        //        joad.ODID = joal.ODID;
        //        joad.PackNo = joal.PackNo;
        //        joad.Position = joal.Position;
        //        joad.ToDetail = joal.rToDetail;
        //        joad.FromDetail = joal.rFromDetail;
        //        joad.CustomerName = joal.CustomerName;
              
        //        JOrderAdd.Add(joad);

        //    }

          
        //    JobList JL = new JobList();
        //    JL.JOrder = JOrderList.ToList();
        //    JL.JOrderD = JOrderDList.ToList();
        //    JL.JTruck = JTruckList.ToList();
        //    JL.JSub = JSubList.ToList();
        //    JL.JJob = JJobList.ToList();
        //    JL.JOrderA = JOrderAdd.ToList();
          
        //    model.Add(JL);
        //    return View(model);
        //}
        //public ActionResult OpenJob()
        //{
        //    List<OpenJob> model = new List<OpenJob>();
        //    List<OpenJobT> modelT = new List<OpenJobT>();

        //    var sJobT = (from j in db.Jobs
        //              //  join o in db.Orders on j.OrderID equals o.OrderID
        //                join t in db.Trucks on j.TruckID equals t.ID
        //                join d in db.Drivers on j.DriverID equals d.ID
        //              //  join r in db.Routes on o.RoutID equals r.ID
        //                 where j.Status == 1
        //             //   join s in db.SubContacts on j.SID equals s.ID
                           
        //                      orderby j.ID descending
        //                      select new
        //                      {
        //                          JID = j.ID,
        //                          OrderID = j.OrderID,
        //                          ContainerNo = j.ContainerNo,
        //                          FromDetail = r.FromDetail,
        //                          ToDetail = r.ToDetail,
        //                          ReceiveDate = o.ReceiveDate,
        //                          DliveryDate = o.DliveryDate,
        //                          License = t.License,
        //                          HitchLicense = t.HitchLicense,
        //                          DTitle = d.Title,
        //                          DFirstName = d.FirstName,
        //                          DLastName = d.LastName,
        //                    //      SName = s.Name,
        //                    //      Stype = j.SType,
        //                          JStatus = j.Status

        //                      }
        //     ).ToList();

        //    foreach (var ol in sJobT)
        //    {
        //        OpenJobT a = new OpenJobT();

        //        a.ContainerNo = ol.ContainerNo;
        //        a.DFirstName = ol.DFirstName;
        //        a.DLastName = ol.DLastName;

        //        if (ol.DliveryDate == null)
        //        {
        //            a.DliveryDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
        //        }

               
        //        if (ol.ReceiveDate == null)
        //        {
        //            a.ReceiveDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
        //        }

        //        a.DTitle = ol.DTitle;
        //        a.FromDetail = ol.FromDetail;
        //        a.HitchLicense = ol.HitchLicense;
        //        a.JID = ol.JID;
        //        a.JStatus = Convert.ToInt32(ol.JStatus);
        //        a.License = ol.License;
        //        a.OrderID = ol.OrderID;
        //        a.ToDetail = ol.ToDetail;
        //     //   a.SName = ol.SName;
        //     //   a.SType = Convert.ToInt32(ol.Stype);

        //        modelT.Add(a);

        //    }
        //    List<OpenJobS> modelS = new List<OpenJobS>();


        //    var sJobS = (from j in db.Jobs
        //                join o in db.Orders on j.OrderID equals o.OrderID
        //             //   join t in db.Trucks on j.TruckID equals t.ID
        //               // join d in db.Drivers on j.DriverID equals d.ID
        //                join r in db.Routes on o.RoutID equals r.ID
        //                  join s in db.SubContacts on j.SID equals s.ID
        //                  where j.Status == 1
        //                orderby j.ID descending
        //                select new
        //                {
        //                    JID = j.ID,
        //                    OrderID = j.OrderID,
        //                    ContainerNo = j.ContainerNo,
        //                    FromDetail = r.FromDetail,
        //                    ToDetail = r.ToDetail,
        //                    ReceiveDate = o.ReceiveDate,
        //                    DliveryDate = o.DliveryDate,
        //               //     License = t.License,
        //                 //   HitchLicense = t.HitchLicense,
        //                   // DTitle = d.Title,
        //                  //  DFirstName = d.FirstName,
        //                   // DLastName = d.LastName,
        //                          SName = s.Name,
        //                          Stype = j.SType,
        //                    JStatus = j.Status

        //                }
        //     ).ToList();

        //    foreach (var ol in sJobS)
        //    {
        //        OpenJobS a = new OpenJobS();

        //        a.ContainerNo = ol.ContainerNo;
        //     //   a.DFirstName = ol.DFirstName;
        //    //    a.DLastName = ol.DLastName;

        //        if (ol.DliveryDate == null)
        //        {
        //            a.DliveryDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
        //        }


        //        if (ol.ReceiveDate == null)
        //        {
        //            a.ReceiveDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
        //        }

        //   //     a.DTitle = ol.DTitle;
        //        a.FromDetail = ol.FromDetail;
        //    //    a.HitchLicense = ol.HitchLicense;
        //        a.JID = ol.JID;
        //        a.JStatus = Convert.ToInt32(ol.JStatus);
        //    //    a.License = ol.License;
        //        a.OrderID = ol.OrderID;
        //        a.ToDetail = ol.ToDetail;
        //        a.SName = ol.SName;
        //      a.SType = Convert.ToInt32(ol.Stype);

        //        modelS.Add(a);

        //    }

        //    OpenJob JL = new OpenJob();
        //    JL.sOpenJobT = modelT.ToList();
        //    JL.sOpenJobS = modelS.ToList();
           

        //    model.Add(JL);
        //    return View(model); 
         
        //}
        //public ActionResult OpenJobDetail()
        //{
        //    return View();
        //}
        public ActionResult CloseJob()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F4";
            return View();
        }
      
        public ActionResult TrieSwitch()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F6";
            return View();
        }
        public ActionResult TrieSwitchDetail()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F6";
            return View();
        }
        public ActionResult Repair()
        {

            Session["FMenu"] = "F";
            Session["Menu"] = "F7";

            List<DataRepair> model = new List<DataRepair>();
        

            var sRepairInfo = (from r in db.Repairs
                               join t in db.Trucks on r.TID equals t.ID
                           orderby r.RepairNo descending
                              select new
                              {
                                  RepairNo = r.RepairNo,
                                  License = t.License,
                                  TruckType = t.TruckType,
                                  InformDate = r.InformDate,
                                  SendDate = r.SendDate,
                                  FinishDate = r.FinishDate,
                                  FinishTime = r.FinishTime,
                                  Detail = r.Detail,
                                  Status = r.Status
                              }
             ).ToList();

            foreach (var rl in sRepairInfo)
            {
                DataRepair r = new DataRepair();

                r.RepairNo = rl.RepairNo;
                r.License = rl.License;
                r.TruckType = Convert.ToInt32(rl.TruckType);

                if (r.TruckType == 1)
                {
                    r.STType = "หัวลาก";
                }
                else if (r.TruckType == 2)
                {
                    r.STType = "หางลาก";
                }

                r.InformDate = Convert.ToDateTime(rl.InformDate);
                r.SendDate = Convert.ToDateTime(rl.SendDate);
                r.FinishDate = Convert.ToDateTime(rl.FinishDate);
                r.FinishTime = rl.FinishTime;
                r.Detail = rl.Detail;
                r.Status = Convert.ToInt32(rl.Status);
             
                model.Add(r);
            }

            return View(model);
        }
        public ActionResult RepairDetail()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F7";

            var dTruck = (from t in db.Trucks
                        
                             select new
                             {
                                 TID = t.ID,
                                 TLicense = t.License
                             }
                 ).ToList();

            var dDriver = (from d in db.Drivers
                           where d.Status == "y"
                          select new
                          {
                              DriverID = d.ID,
                              Title = d.Title,
                              FirstName = d.FirstName,
                              LastName = d.LastName
                             
                          }
               ).ToList();

            var dGarage = (from g in db.Garages

                           select new
                           {
                               GID = g.ID,
                               GName = g.Name
                              
                           }
              ).ToList();

        

            List<RepairList> model = new List<RepairList>();
            List<DriverList> lDriver = new List<DriverList>();
            List<TruckList> lTruck = new List<TruckList>();
            List<GarageList> lGarage = new List<GarageList>();

            foreach (var tr in dTruck)
            {
                TruckList t = new TruckList();
                t.TID = tr.TID;
                t.License = tr.TLicense;
                lTruck.Add(t);
               
            }

            foreach (var dr in dDriver)
            {
                DriverList d = new DriverList();
                d.DriverID = dr.DriverID;
                d.Title = dr.Title;
                d.FirstName = dr.FirstName;
                d.LastName = dr.LastName;
              
                 lDriver.Add(d);

            }

            foreach (var gr in dGarage)
            {
                GarageList g = new GarageList();
                g.GID = gr.GID;
                g.Name = gr.GName;

                lGarage.Add(g);

            }

            RepairList RL = new RepairList();
            RL.rTruck = lTruck.ToList();
            RL.rDriver = lDriver.ToList();
            RL.rGarage = lGarage.ToList();
           
            model.Add(RL);


            return View(model);
        }
        public ActionResult CRepairDetail()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F7";

            string RepairNo = Request.QueryString["RepairNo"];

            List<RepairList> model = new List<RepairList>();
            List<DriverList> lDriver = new List<DriverList>();
            List<TruckList> lTruck = new List<TruckList>();
            List<GarageList> lGarage = new List<GarageList>();
            List<DataRepair> lDataRepair = new List<DataRepair>();
            
                              List<OldRepair> lOldRepair = new List<OldRepair>();

            var dRepair = (from r in db.Repairs
                           where r.RepairNo == RepairNo
                          select new
                          {
                              RepairNo = r.RepairNo,
                              TID = r.TID,
                              DriverID = r.DriverID,
                              Mile = r.Mile,
                              InformDate = r.InformDate,
                              InformTime = r.InformTime,
                              SendDate = r.SendDate,
                              SendTime = r.SendTime,
                              Detail = r.Detail,
                              optEdit = r.optEdit,
                              optRepair = r.optRepair,
                              Remark = r.Remark,
                              GID = r.GID,
                              Operator = r.Operator,
                              Status = r.Status
                          }
                ).ToList();


            foreach (var dr in dRepair)
            {
                DataRepair r = new DataRepair();
                r.RepairNo = dr.RepairNo;
                r.TID = Convert.ToInt32(dr.TID);
                r.DriverID = Convert.ToInt32(dr.DriverID);
                              r.Mile = Convert.ToInt32(dr.Mile);
                              r.InformDate = Convert.ToDateTime(dr.InformDate);
                              r.InformTime = dr.InformTime;
                              r.SendDate = Convert.ToDateTime(dr.SendDate);
                              r.SendTime = dr.SendTime;
                              r.Detail = dr.Detail;
                              r.optEdit = Convert.ToInt32(dr.optEdit);
                              r.optRepair = Convert.ToInt32(dr.optRepair);
                              r.Remark = dr.Remark;
                              r.GID =  Convert.ToInt32(dr.GID);
                              r.Operator = dr.Operator;
                              r.Status = Convert.ToInt32(dr.Status);
                              lDataRepair.Add(r);

                              var dTruck = (from t in db.Trucks
                                            where t.ID == dr.TID
                                            select new
                                            {
                                                TID = t.ID,
                                                TLicense = t.License,
                                                Brand = t.Brand,
                                                RegisterDate = t.RegisterDate,
                                                TruckType = t.TruckType
                                            }
                          ).ToList();

                              var dDriver = (from d in db.Drivers
                                             where d.ID == dr.DriverID
                                             select new
                                             {
                                                 DriverID = d.ID,
                                                 Title = d.Title,
                                                 FirstName = d.FirstName,
                                                 LastName = d.LastName

                                             }
                                 ).ToList();

                              var dGarage = (from g in db.Garages
                                             where g.ID == dr.GID
                                             select new
                                             {
                                                 GID = g.ID,
                                                 GName = g.Name

                                             }
                                ).ToList();


                              foreach (var tr in dTruck)
                              {
                                  TruckList t = new TruckList();
                                  t.TID = tr.TID;
                                  t.License = tr.TLicense;
                                  t.Brand = tr.Brand;
                                  t.RegisterDate = Convert.ToDateTime(tr.RegisterDate).ToString("dd/MM/yyyy");
                                  t.TruckType = Convert.ToInt32(tr.TruckType);

                                  if (t.TruckType == 1)
                                  {
                                      t.STType = "หัวลาก";
                                  }
                                  else if (t.TruckType == 2)
                                  {
                                      t.STType = "หางลาก";
                                  }
                                  lTruck.Add(t);

                              }

                              foreach (var dd in dDriver)
                              {
                                  DriverList d = new DriverList();
                                  d.DriverID = dd.DriverID;
                                  d.Title = dd.Title;
                                  d.FirstName = dd.FirstName;
                                  d.LastName = dd.LastName;

                                  lDriver.Add(d);

                              }

                              foreach (var gr in dGarage)
                              {
                                  GarageList g = new GarageList();
                                  g.GID = gr.GID;
                                  g.Name = gr.GName;
                                  lGarage.Add(g);

                              }

                              var OldRepair = (from o in db.Repairs
                                               join g in db.Garages on o.GID equals g.ID
                                               where o.RepairNo != dr.RepairNo && o.TID == dr.TID
                                               orderby r.RepairNo descending
                                               select new
                                               {
                                                   RepairNo = o.RepairNo,
                                                   InformDate = o.InformDate,
                                                   GID = o.GID,
                                                   GName = g.Name,
                                                   Mile = o.Mile,
                                                   SumPrice = o.SumPrice

                                               }
                              ).FirstOrDefault();


                              OldRepair b = new OldRepair();

                              if (OldRepair != null)
                              {
                                  if (OldRepair.GID == null)
                                  {
                                      b.GID = 0;
                                  }
                                  else
                                  {
                                      b.GID = Convert.ToInt32(OldRepair.GID);
                                  }

                                  b.GName = OldRepair.GName;
                                  b.InformDate = Convert.ToDateTime(OldRepair.InformDate).ToString("dd/MM/yyyy");
                                  b.Mile = Convert.ToDecimal(OldRepair.Mile);
                                  b.SumPrice = Convert.ToDecimal(OldRepair.SumPrice);

                              }

                              lOldRepair.Add(b);
            }



            RepairList RL = new RepairList();
            RL.rTruck = lTruck.ToList();
            RL.rDriver = lDriver.ToList();
            RL.rGarage = lGarage.ToList();
            RL.rDataRepair = lDataRepair.ToList();
            RL.rOldRepair = lOldRepair.ToList();
            model.Add(RL);


            return View(model);
        }
        public ActionResult RepairCommit(FormCollection form)
        {
            int TID = 0;
            int DriverID = 0;
            int optEdit = 0;
            int optRepair = 0;
            int GID = 0;
            int Status = 1;

            if (form["Truck"] != "")
            {
                TID = Convert.ToInt32(form["Truck"]);
            }

            if (form["Driver"] != "")
            {
                DriverID = Convert.ToInt32(form["Driver"]);
            }

            if (form["optEdit"] != "")
            {
                optEdit = Convert.ToInt32(form["optEdit"]);
            }

            if (form["optRepair"] != "")
            {
                optRepair = Convert.ToInt32(form["optRepair"]);
            }

            if (form["Garage"] != "")
            {
                GID = Convert.ToInt32(form["Garage"]);
            }

             string InformDate = form["InformDate"];
             string SendDate = form["SendDate"];
             string FinishDate = form["FinishDate"];

            DateTime dInformDate = DateTime.Now.Date;
            DateTime dSendDate = DateTime.Now.Date;
            DateTime dFinishDate = DateTime.Now.Date;
         
            if (InformDate == null || InformDate == "")
            {
                dInformDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = InformDate.Substring(0, 2);
                string d2 = InformDate.Substring(3, 2);
                string d3 = InformDate.Substring(6, 4);
               // string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                dInformDate = DateTime.Parse(d4);
            }

            if (SendDate == null || SendDate == "")
            {
                dSendDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = SendDate.Substring(0, 2);
                string d2 = SendDate.Substring(3, 2);
                string d3 = SendDate.Substring(6, 4);
               // string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                dSendDate = DateTime.Parse(d4);
            }

            // if (FinishDate == null || FinishDate == "")
            //{
            //    dFinishDate = DateTime.Now.Date;
            //}
            //else
            //{
            //    string d1 = FinishDate.Substring(0, 2);
            //    string d2 = FinishDate.Substring(3, 2);
            //    string d3 = FinishDate.Substring(6, 4);
            //   // string d4 = d1 + "/" + d2 + "/" + d3;
            //    string d4 = d2 + "/" + d1 + "/" + d3;
            //    dFinishDate = DateTime.Parse(d4);
            //}


             string bYM = DateTime.Today.Year.ToString().Substring(2, 2) + DateTime.Today.Month.ToString("00");


            var RepairNo = (from r in db.Repairs
                             where r.RepairNo.Substring(0, 4) == bYM
                             orderby r.RepairNo descending
                             select r.RepairNo
                  ).FirstOrDefault();

            string OID = "";
            string ROID = "";
            if (RepairNo == null)
            {
                OID = bYM + "0001";
            }
            else
            {
                ROID = RepairNo.Substring(4, 4);
                OID =  bYM + (Convert.ToInt32(ROID) + 1).ToString("0000");
            }

            decimal Mile = 0;
            if (form["Mile"] != "")
            {
                Mile = Convert.ToDecimal(form["Mile"]);
            }

            decimal SumNum = 0;
            if (form["SumNum"] != "")
            {
                SumNum = Convert.ToDecimal(form["SumNum"]);
            }

            decimal SumPrice = 0;
            if (form["SumPrice"] != "")
            {
                SumPrice = Convert.ToDecimal(form["SumPrice"]);
            }

            int Counter = 0;
            Counter = Convert.ToInt32(form["Counter"]);

            //if (Counter > 0)
            //{
               

            //    for (var i = 1; i <= Counter; i++)
            //    {
            //        string MyDetail = "MyDetail" + i;
            //        string MyNum = "MyNum" + i;
            //        string MyPrice = "MyPrice" + i;
            //        string MySumPrice = "MySumPrice" + i;

            //        SumNum += Convert.ToDecimal(form[MyNum]);
            //        SumPrice += Convert.ToDecimal(form[MySumPrice]);

            //        RepairDetail AddRD = new RepairDetail();
            //        AddRD.RepairNo = OID;
            //        AddRD.Detail = form[MyDetail];
            //        AddRD.Num = Convert.ToDecimal(form[MyNum]);
            //        AddRD.Price = Convert.ToDecimal(form[MyPrice]);
            //        AddRD.SumPrice = Convert.ToDecimal(form[MySumPrice]);

            //        db.RepairDetails.Add(AddRD);
            //        db.SaveChanges();

            //    }
            //}


            Repair AddRepair = new Repair();
            AddRepair.RepairNo = OID;
            AddRepair.TID = TID;
            AddRepair.DriverID = DriverID;
            AddRepair.Mile = Mile;
            AddRepair.InformDate = dInformDate;
            AddRepair.InformTime = form["InformTime"];
            AddRepair.SendDate =  dSendDate;
            AddRepair.SendTime = form["SendTime"];
         //   AddRepair.FinishDate = dFinishDate;
         //   AddRepair.FinishTime = form["FinishTime"];
            AddRepair.Detail = form["Detail"];
            AddRepair.optEdit = optEdit;
            AddRepair.optRepair = optRepair;
            AddRepair.Remark = form["Remark"];
           // AddRepair.SumNum = SumNum;
          //  AddRepair.SumPrice = SumPrice;
            AddRepair.GID = GID;
            AddRepair.Operator = form["Operator"];
            AddRepair.Status = Status;
            AddRepair.SaveDate = DateTime.Now.Date;

            db.Repairs.Add(AddRepair);
            db.SaveChanges();

            Session["RepairNo"] = OID;
            return RedirectToAction("RepairInfo", "TMS", new { RepairNo = OID });
        }
        public ActionResult CRepairCommit(FormCollection form)
        {
            
          
            string FinishDate = form["FinishDate"];

        
            DateTime dFinishDate = DateTime.Now.Date;

            if (FinishDate == null || FinishDate == "")
            {
                dFinishDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = FinishDate.Substring(0, 2);
                string d2 = FinishDate.Substring(3, 2);
                string d3 = FinishDate.Substring(6, 4);
                // string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                dFinishDate = DateTime.Parse(d4);
            }


            string RepairNo = form["RepairNo"];


         
            decimal SumNum = 0;
            if (form["SumNum"] != "")
            {
                SumNum = Convert.ToDecimal(form["SumNum"]);
            }

            decimal SumPrice = 0;
            if (form["SumPrice"] != "")
            {
                SumNum = Convert.ToDecimal(form["SumPrice"]);
            }

            int Counter = 0;
            Counter = Convert.ToInt32(form["Counter"]);

            if (Counter > 0)
            {


                for (var i = 1; i <= Counter; i++)
                {
                    string MyDetail = "MyDetail" + i;
                    string MyNum = "MyNum" + i;
                    string MyPrice = "MyPrice" + i;
                    string MySumPrice = "MySumPrice" + i;

                    SumNum += Convert.ToDecimal(form[MyNum]);
                    SumPrice += Convert.ToDecimal(form[MySumPrice]);

                    RepairDetail AddRD = new RepairDetail();
                    AddRD.RepairNo = RepairNo;
                    AddRD.Detail = form[MyDetail];
                    AddRD.Num = Convert.ToDecimal(form[MyNum]);
                    AddRD.Price = Convert.ToDecimal(form[MyPrice]);
                    AddRD.SumPrice = Convert.ToDecimal(form[MySumPrice]);

                    db.RepairDetails.Add(AddRD);
                    db.SaveChanges();

                }
            }

            var UpdateRepair = (from r in db.Repairs
                                where r.RepairNo == RepairNo
                         select r).Single();

            UpdateRepair.FinishDate = dFinishDate;
            UpdateRepair.FinishTime = form["FinishTime"];
            UpdateRepair.SumNum = SumNum;
            UpdateRepair.SumPrice = SumPrice;
            UpdateRepair.SaveDate = DateTime.Now.Date;
            UpdateRepair.Status = 2;
            db.SaveChanges();

            Session["RepairNo"] = RepairNo;
            return RedirectToAction("RepairInfo", "TMS", new { RepairNo = RepairNo });
        }
        public ActionResult RepairInfo()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F7";

            string RepairNo = "16060001";

            if (Request.QueryString["RepairNo"] != null)
            {
                RepairNo = Request.QueryString["RepairNo"];
            }
            else
            {
                if (Session["RepairNo"] != null)
                {
                    RepairNo = Session["RepairNo"].ToString();
                }
                else
                {
                    RepairNo = "";
                    return RedirectToAction("Repair", "TMS");

                }
            }

            List<DataRepair> model = new List<DataRepair>();
            List<DataRepairDetail> modelD = new List<DataRepairDetail>();

            var sRepairInfo = (from r in db.Repairs
                               join t in db.Trucks on r.TID equals t.ID
                               join d in db.Drivers on r.DriverID equals d.ID
                               join g in db.Garages on r.GID equals g.ID
                               where r.RepairNo == RepairNo
                               orderby r.RepairNo descending
                               select new
                               {
                                   RepairNo = r.RepairNo,
                                   License = t.License,
                                   TruckType = t.TruckType,
                                   Brand = t.Brand,
                                   RegisterDate = t.RegisterDate,
                                   DriverID = d.ID,
                                   Title = d.Title,
                                   FirstName = d.FirstName,
                                   LastName = d.LastName,
                                   Mile = r.Mile,
                                   InformDate = r.InformDate,
                                   InformTime = r.InformTime,
                                   SendDate = r.SendDate,
                                   SendTime = r.SendTime,
                                   FinishDate = r.FinishDate,
                                   FinishTime = r.FinishTime,
                                   Detail = r.Detail,
                                   optEdit = r.optEdit,
                                   optRepair = r.optRepair,
                                   Remark = r.Remark,
                                   SumNum = r.SumNum,
                                   SumPrice = r.SumPrice,
                                   GID = r.GID,
                                   GName = g.Name,
                                   Operator = r.Operator,
                                   SaveDate = r.SaveDate,
                                   Status = r.Status
                               }
       ).ToList();

            foreach (var rl in sRepairInfo)
            {
                DataRepair r = new DataRepair();

                r.RepairNo = rl.RepairNo;
                r.License = rl.License;
                r.TruckType = Convert.ToInt32(rl.TruckType);

                if (r.TruckType == 1)
                {
                    r.STType = "หัวลาก";
                }
                else if (r.TruckType == 2)
                {
                    r.STType = "หางลาก";
                }
                r.Brand = rl.Brand;
                r.RegisterDate = Convert.ToDateTime(rl.RegisterDate);
                r.DriverID = rl.DriverID;
                r.Title = rl.Title;
                r.FirstName = rl.FirstName;
                r.LastName = rl.LastName;
                r.Mile = Convert.ToDecimal(rl.Mile);
                r.InformDate = Convert.ToDateTime(rl.InformDate);
                r.InformTime = rl.InformTime;
                r.SendDate = Convert.ToDateTime(rl.SendDate);
                r.SendTime = rl.SendTime;
                r.FinishDate = Convert.ToDateTime(rl.FinishDate);
                r.FinishTime = rl.FinishTime;
                r.Detail = rl.Detail;
                r.optEdit = Convert.ToInt32(rl.optEdit);

                if (r.optEdit == 1)
                {
                    r.SEdit = "ซื้ออะไหล่เปลี่ยนเอง";
                }
                else if (r.optEdit == 2)
                {
                    r.SEdit = "ส่งซ่อมอู่ภายนอก";
                }

                r.optRepair = Convert.ToInt32(rl.optRepair);

                if (r.optRepair == 1)
                {
                    r.SRepair = "BD ในสถานที่";
                }
                else if (r.optRepair == 2)
                {
                    r.SRepair = "BD นอกสถานที่";
                }
                else if (r.optRepair == 3)
                {
                    r.SRepair = "PM ระยะ";
                }
                r.Remark = rl.Remark;
                r.SumNum = Convert.ToDecimal(rl.SumNum);
                r.SumPrice = Convert.ToDecimal(rl.SumPrice);
                r.GID = Convert.ToInt32(rl.GID);
                r.GName = rl.GName;
                r.Operator = rl.Operator;
                r.SaveDate = Convert.ToDateTime(rl.SaveDate);
                r.Status = Convert.ToInt32(rl.Status);

                model.Add(r);
            }

            var sRepairD = (from rd in db.RepairDetails
                            where rd.RepairNo == RepairNo
                            orderby rd.RepairNo descending
                            select new
                            {
                                ID = rd.ID,
                                RepairNo = rd.RepairNo,
                                Detail = rd.Detail,
                                Num = rd.Num,
                                Price = rd.Price,
                                SumPrice = rd.SumPrice
                            }
      ).ToList();

            foreach (var rl in sRepairD)
            {
                DataRepairDetail r = new DataRepairDetail();

                r.ID = rl.ID;
                r.RepairNo = rl.RepairNo;
                r.Detail = rl.Detail;
                r.Num = Convert.ToDecimal(rl.Num);
                r.Price = Convert.ToDecimal(rl.Price);
                r.SumPrice = Convert.ToDecimal(rl.SumPrice);

                modelD.Add(r);
            }

            return View(Tuple.Create(model, modelD));


        }
        public ActionResult RepairPrint()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F7";

            string RepairNo = "16060001";

            if (Request.QueryString["RepairNo"] != null)
            {
                RepairNo = Request.QueryString["RepairNo"];
            }
            else
            {
                if (Session["RepairNo"] != null)
                {
                    RepairNo = Session["RepairNo"].ToString();
                }
                else
                {
                    RepairNo = "";
                    return RedirectToAction("Repair", "TMS");

                }
            }

            List<DataRepair> model = new List<DataRepair>();
            List<DataRepairDetail> modelD = new List<DataRepairDetail>();

            var sRepairInfo = (from r in db.Repairs
                               join t in db.Trucks on r.TID equals t.ID
                               join d in db.Drivers on r.DriverID equals d.ID
                               join g in db.Garages on r.GID equals g.ID
                               where r.RepairNo == RepairNo
                               orderby r.RepairNo descending
                               select new
                               {
                                   RepairNo = r.RepairNo,
                                   License = t.License,
                                   TruckType = t.TruckType,
                                   Brand = t.Brand,
                                   RegisterDate = t.RegisterDate,
                                   DriverID = d.ID,
                                   Title = d.Title,
                                   FirstName = d.FirstName,
                                   LastName = d.LastName,
                                   Mile = r.Mile,
                                   InformDate = r.InformDate,
                                   InformTime = r.InformTime,
                                   SendDate = r.SendDate,
                                   SendTime = r.SendTime,
                                   FinishDate = r.FinishDate,
                                   FinishTime = r.FinishTime,
                                   Detail = r.Detail,
                                   optEdit = r.optEdit,
                                   optRepair = r.optRepair,
                                   Remark = r.Remark,
                                   SumNum = r.SumNum,
                                   SumPrice = r.SumPrice,
                                   GID = r.GID,
                                   GName = g.Name,
                                   Operator = r.Operator,
                                   SaveDate = r.SaveDate,
                                   Status = r.Status
                               }
       ).ToList();

            foreach (var rl in sRepairInfo)
            {
                DataRepair r = new DataRepair();

                r.RepairNo = rl.RepairNo;
                r.License = rl.License;
                r.TruckType = Convert.ToInt32(rl.TruckType);

                if (r.TruckType == 1)
                {
                    r.STType = "หัวลาก";
                }
                else if (r.TruckType == 2)
                {
                    r.STType = "หางลาก";
                }
                r.Brand = rl.Brand;
                r.RegisterDate = Convert.ToDateTime(rl.RegisterDate);
                r.DriverID = rl.DriverID;
                r.Title = rl.Title;
                r.FirstName = rl.FirstName;
                r.LastName = rl.LastName;
                r.Mile = Convert.ToDecimal(rl.Mile);
                r.InformDate = Convert.ToDateTime(rl.InformDate);
                r.InformTime = rl.InformTime;
                r.SendDate = Convert.ToDateTime(rl.SendDate);
                r.SendTime = rl.SendTime;
                r.FinishDate = Convert.ToDateTime(rl.FinishDate);
                r.FinishTime = rl.FinishTime;
                r.Detail = rl.Detail;
                r.optEdit = Convert.ToInt32(rl.optEdit);

                if (r.optEdit == 1)
                {
                    r.SEdit = "ซื้ออะไหล่เปลี่ยนเอง";
                }
                else if (r.optEdit == 2)
                {
                    r.SEdit = "ส่งซ่อมอู่ภายนอก";
                }

                r.optRepair = Convert.ToInt32(rl.optRepair);

                if (r.optRepair == 1)
                {
                    r.SRepair = "BD ในสถานที่";
                }
                else if (r.optRepair == 2)
                {
                    r.SRepair = "BD นอกสถานที่";
                }
                else if (r.optRepair == 3)
                {
                    r.SRepair = "PM ระยะ";
                }
                r.Remark = rl.Remark;
                r.SumNum = Convert.ToDecimal(rl.SumNum);
                r.SumPrice = Convert.ToDecimal(rl.SumPrice);
                r.GID = Convert.ToInt32(rl.GID);
                r.GName = rl.GName;
                r.Operator = rl.Operator;
                r.SaveDate = Convert.ToDateTime(rl.SaveDate);
                r.Status = Convert.ToInt32(rl.Status);

                model.Add(r);
            }

            var sRepairD = (from rd in db.RepairDetails
                            where rd.RepairNo == RepairNo
                            orderby rd.RepairNo descending
                            select new
                            {
                                ID = rd.ID,
                                RepairNo = rd.RepairNo,
                                Detail = rd.Detail,
                                Num = rd.Num,
                                Price = rd.Price,
                                SumPrice = rd.SumPrice
                            }
      ).ToList();

            foreach (var rl in sRepairD)
            {
                DataRepairDetail r = new DataRepairDetail();

                r.ID = rl.ID;
                r.RepairNo = rl.RepairNo;
                r.Detail = rl.Detail;
                r.Num = Convert.ToDecimal(rl.Num);
                r.Price = Convert.ToDecimal(rl.Price);
                r.SumPrice = Convert.ToDecimal(rl.SumPrice);

                modelD.Add(r);
            }

            return View(Tuple.Create(model, modelD));


        }
        
        public ActionResult Car()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D1";
            return View();
        }
        public ActionResult CarDetail()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D1";
            return View();
        }
        public ActionResult Customer()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D5";
            return View();
        }
        public ActionResult CustomerDetail()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D5";
            return View();
        }
        public ActionResult Sub()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D6";
            return View();
        }
        public ActionResult SubDetail()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D6";
            return View();
        }
        public ActionResult Trie()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D3";
            return View();
        }
        public ActionResult TrieDetail()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D3";
            return View();
        }
        public ActionResult Route()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D4";
            return View();
        }
        public ActionResult RouteDetail()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D4";
            return View();
        }
        public ActionResult NewRoute()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D4";
            return View();
        }
        public ActionResult Gas()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D7";
            return View();
        }
        public ActionResult GasDetail()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D7";
            return View();
        }
        public ActionResult Garage()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D8";
            return View();
        }
        public ActionResult GarageDetail()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D8";
            return View();
        }
        public ActionResult WithDraw()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F5";
            return View();
        }
        public ActionResult WithDrawDetail()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F5";
            return View();
        }
        public ActionResult Stock()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D9";
            return View();
        }
        public ActionResult StockDetail()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D9";
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult test2()
        {
            return View();
        }

        //public ActionResult JobCancel()
        //{
        //    int DriverID = 0;
        //    int TID = 0;
        //    int HID = 0;
        //    int ODID = 0;
        //    int SID = 0;
        //    int SType = 0;

        //    if (Request.QueryString["D"] != "")
        //    {
        //        DriverID = Convert.ToInt32(Request.QueryString["D"]);
        //    }
        //    if (Request.QueryString["T"] != "")
        //    {
        //        TID = Convert.ToInt32(Request.QueryString["T"]);
        //    }
        //    if (Request.QueryString["H"] != "")
        //    {
        //        HID = Convert.ToInt32(Request.QueryString["H"]);
        //    }
        //    if (Request.QueryString["ODID"] != "")
        //    {
        //        ODID = Convert.ToInt32(Request.QueryString["ODID"]);
        //    }
        //    if (Request.QueryString["S"] != "")
        //    {
        //        SID = Convert.ToInt32(Request.QueryString["S"]);
        //    }


        //    string OrderID = Request.QueryString["OID"];
        //    Job AddJob = new Job();
           
        //    Order UpdateO = new Order();

        //    var sOrderD = (from o in db.OrderDetails
        //                 where o.OrderID == OrderID && o.Status == 2
        //                 select o).Count();

        //    if (sOrderD <=1)
        //    {
        //        var Order = (from o in db.Orders
        //                     where o.OrderID == OrderID
        //                     select o).SingleOrDefault();

        //        Order.Status = 1;
        //        db.SaveChanges();
        //    }
         

        //    OrderDetail UpdateOD = new OrderDetail();

        //    var OrderDetail = (from od in db.OrderDetails
        //                       where od.ID == ODID
        //                       select od).SingleOrDefault();

        //    OrderDetail.Status = 1;
        //    db.SaveChanges();

        //    Job JobC = new Job();

        //    var JJob = (from j in db.Jobs
        //                where j.TruckID == TID && j.HitchID == HID && j.DriverID == DriverID && j.Status != 4

        //                //where
        //                select j).Count();

        //    var Job = (from od in db.Jobs
        //                       where od.ODID == ODID && od.Status != 4
        //               select od).SingleOrDefault();

        //    Job.Status = 4;
        //    db.SaveChanges();

          
               
        //    if (JJob <=1)
        //    {
        //        if (TID != 0)
        //        {
        //            Truck UpdateT = new Truck();

        //            var Truck = (from t in db.Trucks
        //                         where t.ID == TID
        //                         select t).SingleOrDefault();

        //            Truck.Status = 1;
        //            db.SaveChanges();

        //            var Hitch = (from t in db.Trucks
        //                         where t.ID == HID
        //                         select t).SingleOrDefault();

        //            Hitch.Status = 1;
        //            db.SaveChanges();
        //        }
              
          
        //    }
               

        //    return RedirectToAction("Jobs", "TMS", new { J = 1, OID = Request.QueryString["OID"], OT = Request.QueryString["OT"] });
        //}

        public ActionResult NewJob()
        {

            Session["FMenu"] = "F";
            Session["Menu"] = "F2";

            List<NewJobList> model = new List<NewJobList>();

            List<JTruckList> JTruckList = new List<JTruckList>();
            string J = Request.QueryString["J"];
         
            string OT = Request.QueryString["OT"];
            string C = Request.QueryString["C"];
            string T = Request.QueryString["T"];
            string H = Request.QueryString["H"];
            string D = Request.QueryString["D"];
            string TD = Request.QueryString["TD"];
            string HD = Request.QueryString["HD"];
            string S = Request.QueryString["S"];
            string SC = Request.QueryString["SC"];

            string SOID = Request.QueryString["SOID"];
            string ROID = Request.QueryString["ROID"];
            string ST = Request.QueryString["ST"];
  
            var jTruck = (from t in db.Trucks
                          join d in db.Drivers on t.ID equals d.TruckID
                          where t.TruckType == 1
                          select new
                          {
                              TID = t.ID,
                              HID = t.HitchID,
                              DID = d.ID,
                              License = t.License,
                              HitchLicense = t.HitchLicense,
                              DTitle = d.Title,
                              DFirstName = d.FirstName,
                              DLastName = d.LastName,
                              TStatus = t.Status
                          }
            ).ToList();

            foreach (var tl in jTruck)
            {
                JTruckList td = new JTruckList();

                td.DFirstName = tl.DFirstName;
                td.DID = Convert.ToInt32(tl.DID);
                td.DLastName = tl.DLastName;
                td.DTitle = tl.DTitle;
                td.HID = Convert.ToInt32(tl.HID);
                td.HitchLicense = tl.HitchLicense;
                td.License = tl.License;
                td.TID = Convert.ToInt32(tl.TID);
                td.TStatus = Convert.ToInt32(tl.TStatus);


                JTruckList.Add(td);

            }

            List<JSubList> JSubList = new List<JSubList>();
            var JSub = (from s in db.SubContacts
                        //   join d in db.Drivers on t.ID equals d.TruckID
                        //where
                        select new
                        {
                            SID = s.ID,
                            SCode = s.Code,
                            SName = s.Name

                        }
            ).ToList();

            foreach (var sl in JSub)
            {
                JSubList sd = new JSubList();

                sd.SCode = sl.SCode;
                sd.SID = sl.SID;
                sd.SName = sl.SName;


                JSubList.Add(sd);

            }
            int nT = 0;
            int nD = 0;
            int nH = 0;
            int nS = 0;

            if (T != "")
            {
                nT = Convert.ToInt32(T);
            }
            if (D != "")
            {
                nD = Convert.ToInt32(D);
            }
            if (H != "")
            {
                nH = Convert.ToInt32(H);
            }
            if (S != "")
            {
                nS = Convert.ToInt32(S);
            }
            List<JJobList> JJobList = new List<JJobList>();
            if (C == "1")
            {
                var JJob = (from j in db.Jobs
                            join o in db.Orders on j.SOID equals o.OrderID
                            where j.TruckID == nT && j.HitchID == nH && j.DriverID == nD && j.Status != 4

                            //where
                            select new
                            {
                                JID = j.ID,
                                SOrderID = j.SOID,
                                ROrderID = j.ROID,
                              //  ODID = j.ODID,
                               // ContainerNo = j.ContainerNo,
                                Status = j.Status,
                                ReceiveDate = o.ReceiveDate,
                                DliveryDate = o.DliveryDate,
                                PPackDate = o.PPackDate,
                                IEPackDate = o.IEPackDate,
                                IEReceiveDate = o.IEReceiveDate,
                                IEReturnDate = o.IEReturnDate

                            }
                ).ToList();

                foreach (var jl in JJob)
                {
                    JJobList jd = new JJobList();

                  //  jd.ContainerNo = jl.ContainerNo;
                    jd.DliveryDate = Convert.ToDateTime(jl.DliveryDate).Date;
                    jd.PPackDate = Convert.ToDateTime(jl.PPackDate).Date;
                    jd.IEPackDate = Convert.ToDateTime(jl.IEPackDate).Date;
                    jd.IEReceiveDate = Convert.ToDateTime(jl.IEReceiveDate).Date;
                    jd.IEReturnDate = Convert.ToDateTime(jl.IEReceiveDate).Date;
                    jd.JID = jl.JID;
                //    jd.ODID = Convert.ToInt32(jl.ODID);
                    jd.SOrderID = jl.SOrderID;
                    jd.ROrderID = jl.ROrderID;
                    jd.ReceiveDate = Convert.ToDateTime(jl.ReceiveDate).Date;
                    jd.Status = Convert.ToInt32(jl.Status);

                    JJobList.Add(jd);

                }
            }
            else if (C == "2")
            {
                var JJob = (from j in db.Jobs
                            join o in db.Orders on j.SOID equals o.OrderID
                            where  j.SID == nS

                            //where
                            select new
                            {
                                JID = j.ID,
                                SOrderID = j.SOID,
                                ROrderID = j.ROID,
                              //  ODID = j.ODID,
                              //  ContainerNo = j.ContainerNo,
                                Status = j.Status,
                                ReceiveDate = o.ReceiveDate,
                                DliveryDate = o.DliveryDate
                            }
                ).ToList();

                foreach (var jl in JJob)
                {
                    JJobList jd = new JJobList();

                   // jd.ContainerNo = jl.ContainerNo;
                    jd.DliveryDate = Convert.ToDateTime(jl.DliveryDate).Date;
                    jd.JID = jl.JID;
                  //  jd.ODID = Convert.ToInt32(jl.ODID);
                    jd.SOrderID = jl.SOrderID;
                    jd.ROrderID = jl.ROrderID;
                    jd.ReceiveDate = Convert.ToDateTime(jl.ReceiveDate).Date;
                    jd.Status = Convert.ToInt32(jl.Status);

                    JJobList.Add(jd);

                }
            }

            List<JOrderList> JOrderList = new List<JOrderList>();

            var jOrder = (from o in db.Orders
                          join od in db.OrderDetails on o.OrderID equals od.OrderID into odd
                          from orr in odd.DefaultIfEmpty()
                          join c in db.Customers on o.CustomerID equals c.ID
                          join s in db.Shippers on o.ShipperID equals s.ID
                          join r in db.Routes on o.RoutID equals r.ID
                          //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                          //  join d in db.LMS_Driver on b.DriverID equals d.ID
                         // where o.Status == 1 || (o.Status == 2 && o.NumberOrder > 1)
                         where orr.Status == 1
                          orderby o.OrderDate
                          select new
                          {
                              OrderType = o.OrderType,
                              OrderID = o.OrderID,
                              BookingNo = o.BookingNo,
                              CustomerID = o.CustomerID,
                              OrderDate = o.OrderDate,
                              ReceiveDate = o.ReceiveDate,
                              DliveryDate = o.DliveryDate,
                              RoutID = o.RoutID,
                              NumberOrder = o.NumberOrder,
                              Remark = o.Remark,
                              PPackDate = o.PPackDate,
                              TPackDate1 = o.TPackDate1,
                              TPackDate2 = o.TPackDate2,
                              TPackDate3 = o.TPackDate3,
                              TPackDate4 = o.TPackDate4,
                              TNumberOrder1 = o.TNumberOrder1,
                              TNumberOrder2 = o.TNumberOrder2,
                              TNumberOrder3 = o.TNumberOrder3,
                              TNumberOrder4 = o.TNumberOrder4,
                              IEType = o.IEType,
                              IEShipper = o.IEShipper,
                              IEAgent = o.IEAgent,
                              IELoading = o.IELoading,
                              IEShipping = o.IEShipping,
                              IETelephone = o.IETelephone,
                              IELocationPack = o.IELocationPack,
                              IELocationReceive = o.IELocationReceive,
                              IEMap = o.IEMap,
                              //  IELiner = o.IELiner,
                              IEReceiveDate = o.IEReceiveDate,
                              IEPackDate = o.IEPackDate,
                              IEPacklTime = o.IEPacklTime,
                              IEFeeder = o.IEFeeder,
                              IEMother = o.IEMother,
                              //   IECYDate = o.IECYDate,
                              IEETDDate = o.IEETDDate,
                              IEContact = o.IEContact,
                              IEETADate = o.IEETADate,
                              IEAT = o.IEAT,
                              IETel = o.IETel,
                              IEBill = o.IEBill,
                              IEPortPrice = o.IEPortPrice,
                              IELanPrice = o.IELanPrice,
                              IELiftPrice = o.IELiftPrice,
                              IECLosingDate = o.IECLosingDate,
                              IEClosingTime = o.IEClosingTime,
                              IEQuantity = o.IEQuantity,
                              IEReturnDate = o.IEReturnDate,
                              Status = o.Status,

                              CName = c.Name,
                              CAddress = c.Address,
                              CProvince = c.Province,
                              CZipCode = c.ZipCode,
                              CTelephone = c.Telephone,

                              RFromDetail = r.FromDetail,
                              RFromProvince = r.FromProvince,
                              RToDetail = r.ToDetail,
                              RToProvince = r.ToProvince
                          }
            ).Distinct().ToList();

            foreach (var ol in jOrder)
            {
                JOrderList jol = new JOrderList();

                jol.OrderID = ol.OrderID;
                jol.BookingNo = ol.BookingNo;
                jol.CustomerID = Convert.ToInt32(ol.CustomerID);
                jol.OrderType = Convert.ToInt32(ol.OrderType);
                if (ol.OrderDate == null)
                {
                    jol.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    jol.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }

                if (ol.DliveryDate == null)
                {
                    jol.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    jol.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }

                jol.NumberOrder = Convert.ToInt32(ol.NumberOrder);



                if (ol.ReceiveDate == null)
                {
                    jol.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    jol.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }

                if (ol.TPackDate1 == null)
                {
                    jol.TPackDate = DateTime.Now.Date;
                }
                else
                {
                    jol.TPackDate = Convert.ToDateTime(ol.TPackDate1);
                }

                if (ol.IEReceiveDate == null)
                {
                    jol.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    jol.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }

                jol.RoutID = Convert.ToInt32(ol.RoutID);
                jol.Status = Convert.ToInt32(ol.Status);
                jol.CName = ol.CName;  
                JOrderList.Add(jol);

            }

            List<OrderInfo> JOrderS = new List<OrderInfo>();

            var jS = (from o in db.Orders
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == SOID

                       //where
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           CustomerName = c.Name,
                           rToDetail = r.ToDetail,
                           rFromDetail = r.FromDetail,
                           Status = o.Status,
                           BookingNO = o.BookingNo,
                           TPackDate1 = o.TPackDate1,
                             TPackDate2 = o.TPackDate2,
                              TPackDate3 = o.TPackDate3,
                               TPackDate4 = o.TPackDate4,
                               ShipperID =  s.ID,
                               SName = s.Name
                       }
                 ).ToList();

            foreach (var joal in jS)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;
             
                JOrderS.Add(joad);

            }

            List<OrderDetailInfo> JOrderDS = new List<OrderDetailInfo>();

            var joS = (from o in db.Orders
                       join od in db.OrderDetails on o.OrderID equals od.OrderID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals  s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       //join r in db.Routes on o.RoutID equals r.ID into RouteG1
                       //from rg1 in RouteG1.DefaultIfEmpty()
                       //join r2 in db.Routes on o.RoutID2 equals r2.ID into RouteG2
                       //from rg2 in RouteG2.DefaultIfEmpty()
                       //join r3 in db.Routes on o.RoutID3 equals r3.ID into RouteG3
                       //from rg3 in RouteG3.DefaultIfEmpty()
                       //join r4 in db.Routes on o.RoutID4 equals r4.ID into RouteG4
                       //from rg4 in RouteG4.DefaultIfEmpty()
                       where o.OrderID == SOID 
                       orderby od.Status,od.ID
                       //where
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           //RouteID1 = rg1.ID,
                           //ToDetail1 = rg1.ToDetail,
                           //FromDetail1 = rg1.FromDetail,
                           //RouteID2 = rg2.ID,
                           //ToDetail2 = rg2.ToDetail,
                           //FromDetail2 = rg2.FromDetail,
                           //RouteID3 = rg3.ID,
                           //ToDetail3 = rg3.ToDetail,
                           //FromDetail3 = rg3.FromDetail,
                           //RouteID4 = rg4.ID,
                           //ToDetail4 = rg4.ToDetail,
                           //FromDetail4 = rg4.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight
                       }
                 ).ToList();

            foreach (var joal in joS)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);
               
                JOrderDS.Add(joad);

            }

            //เที่ยวกลับ

            List<OrderInfo> JOrderR = new List<OrderInfo>();

            var jR = (from o in db.Orders
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == ROID

                      //where
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jR)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderR.Add(joad);

            }

            List<OrderDetailInfo> JOrderDR = new List<OrderDetailInfo>();

            var joR = (from o in db.Orders
                       join od in db.OrderDetails on o.OrderID equals od.OrderID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       //join r in db.Routes on o.RoutID equals r.ID into RouteG1
                       //from rg1 in RouteG1.DefaultIfEmpty()
                       //join r2 in db.Routes on o.RoutID2 equals r2.ID into RouteG2
                       //from rg2 in RouteG2.DefaultIfEmpty()
                       //join r3 in db.Routes on o.RoutID3 equals r3.ID into RouteG3
                       //from rg3 in RouteG3.DefaultIfEmpty()
                       //join r4 in db.Routes on o.RoutID4 equals r4.ID into RouteG4
                       //from rg4 in RouteG4.DefaultIfEmpty()
                       where o.OrderID == ROID
                       orderby od.Status, od.ID
                       //where
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           //RouteID1 = rg1.ID,
                           //ToDetail1 = rg1.ToDetail,
                           //FromDetail1 = rg1.FromDetail,
                           //RouteID2 = rg2.ID,
                           //ToDetail2 = rg2.ToDetail,
                           //FromDetail2 = rg2.FromDetail,
                           //RouteID3 = rg3.ID,
                           //ToDetail3 = rg3.ToDetail,
                           //FromDetail3 = rg3.FromDetail,
                           //RouteID4 = rg4.ID,
                           //ToDetail4 = rg4.ToDetail,
                           //FromDetail4 = rg4.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight
                       }
                 ).ToList();

            foreach (var joal in joR)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);

                JOrderDR.Add(joad);

            }


            NewJobList JL = new NewJobList();
            JL.JTruck = JTruckList.ToList();
            JL.JSub = JSubList.ToList();
            JL.JJob = JJobList.ToList();
            JL.JOrder = JOrderList.ToList();
            JL.JOrderS = JOrderS.ToList();
            JL.JOrderDS = JOrderDS.ToList();
            JL.JOrderR = JOrderR.ToList();
            JL.JOrderDR = JOrderDR.ToList();
            model.Add(JL);
            return View(model);
        }
        public ActionResult JobCommit(FormCollection form)
        {
            //   return RedirectToAction("~/TMS/Jobs?J=2&OID="+ form["OrderID"] +"&OT="+ form["OT"]+"&ODID="+form["ODID"]);
            int DriverID = 0;
            int TID = 0;
            int HID = 0;
            int SID = 0;
            int SType = 0;
            int ST = 0;
            int SNum = 0;
            int RNum = 0;
            int Status = 1;

        

            if (form["DID"] != "")
            {
                DriverID = Convert.ToInt32(form["DID"]);
            }
            if (form["TID"] != "")
            {
                TID = Convert.ToInt32(form["TID"]);
            }
            if (form["HID"] != "")
            {
                HID = Convert.ToInt32(form["HID"]);
            }

            if (form["SID"] != "")
            {
                SID = Convert.ToInt32(form["SID"]);
            }
            if (form["C"] != "")
            {
                SType = Convert.ToInt32(form["C"]);
            }
            if (form["ST"] != "")
            {
                ST = Convert.ToInt32(form["ST"]);
            }

            if (SType == 1)
            {
                Status = 1;
            }
            else if (SType == 2)
            {
                Status = 3;
            }

            string bYM = DateTime.Today.Year.ToString().Substring(2, 2) + DateTime.Today.Month.ToString("00");


            var JobNo = (from j in db.Jobs
                         where j.JobID.Substring(0, 4) == bYM
                         orderby j.JobID descending
                         select j.JobID
                  ).FirstOrDefault();

            string JobID = "";
            string ROID = "";
            if (JobNo == null)
            {
                JobID = bYM + "0001";
            }
            else
            {
                ROID = JobNo.Substring(4, 4);
                JobID = bYM + (Convert.ToInt32(ROID) + 1).ToString("0000");
            }

            string SOrderID = form["SOID"];
            string ROrderID = form["ROID"];

            int iRow = 0;
            string siRow = "";
            int diRow = 0;
            int xRow = 0;
            string sxRow = "";
            int dxRow = 0;

            if (form["sRow"] != "")
            {
                iRow = Convert.ToInt32(form["sRow"]) - 1;

            }
            if (form["rRow"] != "")
            {
                xRow = Convert.ToInt32(form["rRow"]) - 1;

            }

            for (var i = 0; i <= iRow; i++)
            {
                siRow = "SID" + i;

                if (form[siRow] != null)
                {
                    diRow = Convert.ToInt32(form[siRow]);
                }


                if (diRow != 0)
                {
                    JobDetail AddJobDetail = new JobDetail();
                    AddJobDetail.JobID = JobID;
                    AddJobDetail.JobType = 1;
                    AddJobDetail.OID = SOrderID;
                    AddJobDetail.ODID = diRow;
                    AddJobDetail.Status = Status;
                    db.JobDetails.Add(AddJobDetail);
                    db.SaveChanges();

                    OrderDetail UpdateOD = new OrderDetail();

                    var ODUpdate = (from od in db.OrderDetails
                                    where od.ID == diRow
                                    select od).Single();

                    if (SType == 2)
                    {
                        ODUpdate.Status = 3;
                    }
                    else
                    {
                        ODUpdate.Status = 2;
                    }
                   
                    db.SaveChanges();

                    SNum += 1;
                    diRow = 0;
                }

            }

            if (ST == 2)
            {
                for (var x = 0; x <= xRow; x++)
                {
                    sxRow = "RID" + x;

                    if (Request.Form[sxRow] != null)
                    {
                        dxRow = Convert.ToInt32(Request.Form[sxRow]);
                    }


                    if (dxRow != 0)
                    {
                        JobDetail AddJobDetail = new JobDetail();
                        AddJobDetail.JobID = JobID;
                        AddJobDetail.JobType = 2;
                        AddJobDetail.OID = ROrderID;
                        AddJobDetail.ODID = dxRow;
                        AddJobDetail.Status = Status;
                        db.JobDetails.Add(AddJobDetail);
                        db.SaveChanges();

                        OrderDetail UpdateOD = new OrderDetail();

                        var ODUpdate = (from od in db.OrderDetails
                                        where od.ID == dxRow
                                        select od).Single();

                        if (SType == 2)
                        {
                            ODUpdate.Status = 3;
                        }
                        else
                        {
                            ODUpdate.Status = 2;
                        }
                   
                        db.SaveChanges();

                        RNum += 1;
                        dxRow = 0;
                    }

                }

            }

            Job AddJob = new Job();
            AddJob.JobID = JobID;
            AddJob.JobType = ST;
            AddJob.SOID = SOrderID;
            AddJob.SNum = SNum;
            AddJob.ROID = ROrderID;
            AddJob.RNum = RNum;
            AddJob.TruckID = TID;
            AddJob.HitchID = HID;
            AddJob.DriverID = DriverID;
            AddJob.SID = SID;
            AddJob.SType = SType;
            AddJob.JDate = DateTime.Now.Date;
            AddJob.Remark = form["Remark"];
            AddJob.Status = Status;
            db.Jobs.Add(AddJob);
            db.SaveChanges();


            Order SUpdateO = new Order();

            var SOrder = (from o in db.Orders
                          where o.OrderID == SOrderID
                          select o).SingleOrDefault();

            if (SType == 2)
            {

                SOrder.Status = 3;
            }
            else
            {

                SOrder.Status = 2;
            }
            db.SaveChanges();

            if (ST == 2)
            {
                Order RUpdateO = new Order();

                var ROrder = (from o in db.Orders
                              where o.OrderID == ROrderID
                              select o).SingleOrDefault();

                if (SType == 2)
                {

                    ROrder.Status = 3;
                }
                else
                {

                    ROrder.Status = 2;
                }
                db.SaveChanges();
            }

            if (SType == 1)
            {
                Truck UpdateT = new Truck();

                var Truck = (from t in db.Trucks
                             where t.ID == TID
                             select t).Single();

                Truck.Status = 2;
                db.SaveChanges();

                var Hitch = (from t in db.Trucks
                             where t.ID == HID
                             select t).Single();

                Hitch.Status = 2;
                db.SaveChanges();
            }

            //string STransferDate = form["TransferDate"];
            //DateTime TransferDate = DateTime.Now.Date;

            //if (STransferDate == null || STransferDate == "")
            //{
            //    TransferDate = DateTime.Now.Date;
            //}
            //else
            //{
            //    string d1 = STransferDate.Substring(0, 2);
            //    string d2 = STransferDate.Substring(3, 2);
            //    string d3 = STransferDate.Substring(6, 4);
            //    // string d4 = d1 + "/" + d2 + "/" + d3;
            //    string d4 = d2 + "/" + d1 + "/" + d3;
            //    TransferDate = DateTime.Parse(d4);
            //}

            if (SType == 2)
            {
                Transfer AddTransfer = new Transfer();
                AddTransfer.JobID = JobID;
                AddTransfer.OpenJobDate = DateTime.Now.Date;
                //AddTransfer.TransferDate = TransferDate;
                //AddTransfer.TransferTime = form["TransferTime"];
                AddTransfer.OMile = 0;
                AddTransfer.OOli = 0;
                AddTransfer.OWay = 0;
                AddTransfer.OOther = 0;
             //   AddTransfer.ORemark = form["ORemark"];
                AddTransfer.Status = 1;

                db.Transfers.Add(AddTransfer);
                db.SaveChanges();
            }


            return RedirectToAction("JobInfo", "TMS", new { JobID = JobID });
        }
     
        public ActionResult JobList()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F2";
            List<JobInfo> model = new List<JobInfo>();


            var sJobInfo = (from j in db.Jobs
                            join o in db.Orders on j.SOID equals o.OrderID
                            join c in db.Customers on o.CustomerID equals c.ID
                            join r in db.Routes on o.RoutID equals r.ID
                            join d in db.Drivers on j.DriverID equals d.ID into dDriver
                            from dr in dDriver.DefaultIfEmpty()
                            join t in db.Trucks on j.TruckID equals t.ID into tTruck
                            from tr in tTruck.DefaultIfEmpty()
                            join h in db.Trucks on j.HitchID equals h.ID into hTruck
                            from hr in hTruck.DefaultIfEmpty()
                            join s in db.SubContacts on j.SID equals s.ID into sSub
                            from sr in sSub.DefaultIfEmpty()
                            orderby j.JobID descending
                            select new
                            {
                                JobID = j.JobID,
                                JobType = j.JobType,
                                SOID = j.SOID,
                                SNum = j.SNum,
                                ROID = j.ROID,
                                RNum = j.RNum,
                                TruckID = j.TruckID,
                                License = tr.License,
                                HitchID = j.HitchID,
                                HitchLicense = hr.License,
                                DriverID = j.DriverID,
                                DTitle = dr.Title,
                                DFirstName = dr.FirstName,
                                DLastName = dr.LastName,
                                SID = j.SID,
                                SCCode = sr.Code,
                                SCName = sr.Name,
                                SType = j.SType,
                                JDate = j.JDate,
                                JRemark = j.Remark,
                                JStatus = j.Status,

                                CustomerID = o.CustomerID,
                                OrderDate = o.OrderDate,
                                ReceiveDate = o.ReceiveDate,
                                DliveryDate = o.DliveryDate,
                                RoutID = o.RoutID,

                                PPackDate = o.PPackDate,
                                TPackDate1 = o.TPackDate1,
                                TPackDate2 = o.TPackDate2,
                                TPackDate3 = o.TPackDate3,
                                TPackDate4 = o.TPackDate4,
                                TNumberOrder1 = o.TNumberOrder1,
                                TNumberOrder2 = o.TNumberOrder2,
                                TNumberOrder3 = o.TNumberOrder3,
                                TNumberOrder4 = o.TNumberOrder4,

                                IEReceiveDate = o.IEReceiveDate,
                                IEPackDate = o.IEPackDate,
                                IEPacklTime = o.IEPacklTime,

                                IEReturnDate = o.IEReturnDate,
                                IEETDDate = o.IEETDDate,

                                IEETADate = o.IEETADate,


                                CName = c.Name,
                                CAddress = c.Address,
                                CProvince = c.Province,
                                CZipCode = c.ZipCode,
                                CTelephone = c.Telephone,

                                RFromDetail = r.FromDetail,
                                RFromProvince = r.FromProvince,
                                RToDetail = r.ToDetail,
                                RToProvince = r.ToProvince,
                                OrderType = o.OrderType
                            }
             ).ToList();

            foreach (var ol in sJobInfo)
            {
                JobInfo a = new JobInfo();

                a.JobID = ol.JobID;
                a.JobType = Convert.ToInt32(ol.JobType);
                a.SOID = ol.SOID;
                a.SNum = Convert.ToInt32(ol.SNum);
                a.ROID = ol.ROID;
                a.RNum = Convert.ToInt32(ol.RNum);
                a.TruckID = Convert.ToInt32(ol.TruckID);
                a.License = ol.License;
                a.HitchID = Convert.ToInt32(ol.HitchID);
                a.HitchLicense = ol.HitchLicense;
                a.DriverID = Convert.ToInt32(ol.DriverID);
                a.DTitle = ol.DTitle;
                a.DFirstName = ol.DFirstName;
                a.DLastName = ol.DLastName;
                a.SID = Convert.ToInt32(ol.SID);
                a.SCCode = ol.SCCode;
                a.SCName = ol.SCName;
                a.SType = Convert.ToInt32(ol.SType);
                a.JDate = Convert.ToDateTime(ol.JDate);
                a.JRemark = ol.JRemark;
                a.JStatus = Convert.ToInt32(ol.JStatus);
                a.OrderType = Convert.ToInt32(ol.OrderType);

                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }


                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;


                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }



                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }



                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.RoutID = Convert.ToInt32(ol.RoutID);


                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }


                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;

                model.Add(a);

            }

            return View(model);

        }
        public ActionResult OpenJobList()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F3";
            List<JobInfo> model = new List<JobInfo>();


            var sJobInfo = (from j in db.Jobs
                            join o in db.Orders on j.SOID equals o.OrderID
                            join c in db.Customers on o.CustomerID equals c.ID
                            join r in db.Routes on o.RoutID equals r.ID
                            join d in db.Drivers on j.DriverID equals d.ID into dDriver
                            from dr in dDriver.DefaultIfEmpty()
                            join t in db.Trucks on j.TruckID equals t.ID into tTruck
                            from tr in tTruck.DefaultIfEmpty()
                            join h in db.Trucks on j.HitchID equals h.ID into hTruck
                            from hr in hTruck.DefaultIfEmpty()
                            join s in db.SubContacts on j.SID equals s.ID into sSub
                            from sr in sSub.DefaultIfEmpty()
                            where j.Status == 1
                            orderby j.JobID descending
                            select new
                            {
                                JobID = j.JobID,
                                JobType = j.JobType,
                                SOID = j.SOID,
                                SNum = j.SNum,
                                ROID = j.ROID,
                                RNum = j.RNum,
                                TruckID = j.TruckID,
                                License = tr.License,
                                HitchID = j.HitchID,
                                HitchLicense = hr.License,
                                DriverID = j.DriverID,
                                DTitle = dr.Title,
                                DFirstName = dr.FirstName,
                                DLastName = dr.LastName,
                                SID = j.SID,
                                SCCode = sr.Code,
                                SCName = sr.Name,
                                SType = j.SType,
                                JDate = j.JDate,
                                JRemark = j.Remark,
                                JStatus = j.Status,

                                CustomerID = o.CustomerID,
                                OrderDate = o.OrderDate,
                                ReceiveDate = o.ReceiveDate,
                                DliveryDate = o.DliveryDate,
                                RoutID = o.RoutID,

                                PPackDate = o.PPackDate,
                                TPackDate1 = o.TPackDate1,
                                TPackDate2 = o.TPackDate2,
                                TPackDate3 = o.TPackDate3,
                                TPackDate4 = o.TPackDate4,
                                TNumberOrder1 = o.TNumberOrder1,
                                TNumberOrder2 = o.TNumberOrder2,
                                TNumberOrder3 = o.TNumberOrder3,
                                TNumberOrder4 = o.TNumberOrder4,

                                IEReceiveDate = o.IEReceiveDate,
                                IEPackDate = o.IEPackDate,
                                IEPacklTime = o.IEPacklTime,

                                IEReturnDate = o.IEReturnDate,
                                IEETDDate = o.IEETDDate,

                                IEETADate = o.IEETADate,


                                CName = c.Name,
                                CAddress = c.Address,
                                CProvince = c.Province,
                                CZipCode = c.ZipCode,
                                CTelephone = c.Telephone,

                                RFromDetail = r.FromDetail,
                                RFromProvince = r.FromProvince,
                                RToDetail = r.ToDetail,
                                RToProvince = r.ToProvince,
                                OrderType = o.OrderType
                            }
             ).ToList();

            foreach (var ol in sJobInfo)
            {
                JobInfo a = new JobInfo();

                a.JobID = ol.JobID;
                a.JobType = Convert.ToInt32(ol.JobType);
                a.SOID = ol.SOID;
                a.SNum = Convert.ToInt32(ol.SNum);
                a.ROID = ol.ROID;
                a.RNum = Convert.ToInt32(ol.RNum);
                a.TruckID = Convert.ToInt32(ol.TruckID);
                a.License = ol.License;
                a.HitchID = Convert.ToInt32(ol.HitchID);
                a.HitchLicense = ol.HitchLicense;
                a.DriverID = Convert.ToInt32(ol.DriverID);
                a.DTitle = ol.DTitle;
                a.DFirstName = ol.DFirstName;
                a.DLastName = ol.DLastName;
                a.SID = Convert.ToInt32(ol.SID);
                a.SCCode = ol.SCCode;
                a.SCName = ol.SCName;
                a.SType = Convert.ToInt32(ol.SType);
                a.JDate = Convert.ToDateTime(ol.JDate);
                a.JRemark = ol.JRemark;
                a.JStatus = Convert.ToInt32(ol.JStatus);


                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }


                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;


                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }



                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }



                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.RoutID = Convert.ToInt32(ol.RoutID);


                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }


                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;
                a.OrderType = Convert.ToInt32(ol.OrderType);

                model.Add(a);

            }

            return View(model);

        }
        public ActionResult CloseJobList()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "FF";
            List<JobInfo> model = new List<JobInfo>();


            var sJobInfo = (from j in db.Jobs
                            join o in db.Orders on j.SOID equals o.OrderID
                            join c in db.Customers on o.CustomerID equals c.ID
                            join r in db.Routes on o.RoutID equals r.ID
                            join d in db.Drivers on j.DriverID equals d.ID into dDriver
                            from dr in dDriver.DefaultIfEmpty()
                            join t in db.Trucks on j.TruckID equals t.ID into tTruck
                            from tr in tTruck.DefaultIfEmpty()
                            join h in db.Trucks on j.HitchID equals h.ID into hTruck
                            from hr in hTruck.DefaultIfEmpty()
                            join s in db.SubContacts on j.SID equals s.ID into sSub
                            from sr in sSub.DefaultIfEmpty()
                            where j.Status == 3
                            orderby j.JobID descending
                            select new
                            {
                                JobID = j.JobID,
                                JobType = j.JobType,
                                SOID = j.SOID,
                                SNum = j.SNum,
                                ROID = j.ROID,
                                RNum = j.RNum,
                                TruckID = j.TruckID,
                                License = tr.License,
                                HitchID = j.HitchID,
                                HitchLicense = hr.License,
                                DriverID = j.DriverID,
                                DTitle = dr.Title,
                                DFirstName = dr.FirstName,
                                DLastName = dr.LastName,
                                SID = j.SID,
                                SCCode = sr.Code,
                                SCName = sr.Name,
                                SType = j.SType,
                                JDate = j.JDate,
                                JRemark = j.Remark,
                                JStatus = j.Status,

                                CustomerID = o.CustomerID,
                                OrderDate = o.OrderDate,
                                ReceiveDate = o.ReceiveDate,
                                DliveryDate = o.DliveryDate,
                                RoutID = o.RoutID,

                                PPackDate = o.PPackDate,
                                TPackDate1 = o.TPackDate1,
                                TPackDate2 = o.TPackDate2,
                                TPackDate3 = o.TPackDate3,
                                TPackDate4 = o.TPackDate4,
                                TNumberOrder1 = o.TNumberOrder1,
                                TNumberOrder2 = o.TNumberOrder2,
                                TNumberOrder3 = o.TNumberOrder3,
                                TNumberOrder4 = o.TNumberOrder4,

                                IEReceiveDate = o.IEReceiveDate,
                                IEPackDate = o.IEPackDate,
                                IEPacklTime = o.IEPacklTime,

                                IEReturnDate = o.IEReturnDate,
                                IEETDDate = o.IEETDDate,

                                IEETADate = o.IEETADate,


                                CName = c.Name,
                                CAddress = c.Address,
                                CProvince = c.Province,
                                CZipCode = c.ZipCode,
                                CTelephone = c.Telephone,

                                RFromDetail = r.FromDetail,
                                RFromProvince = r.FromProvince,
                                RToDetail = r.ToDetail,
                                RToProvince = r.ToProvince,
                                OrderType = o.OrderType
                            }
             ).ToList();

            foreach (var ol in sJobInfo)
            {
                JobInfo a = new JobInfo();

                a.JobID = ol.JobID;
                a.JobType = Convert.ToInt32(ol.JobType);
                a.SOID = ol.SOID;
                a.SNum = Convert.ToInt32(ol.SNum);
                a.ROID = ol.ROID;
                a.RNum = Convert.ToInt32(ol.RNum);
                a.TruckID = Convert.ToInt32(ol.TruckID);
                a.License = ol.License;
                a.HitchID = Convert.ToInt32(ol.HitchID);
                a.HitchLicense = ol.HitchLicense;
                a.DriverID = Convert.ToInt32(ol.DriverID);
                a.DTitle = ol.DTitle;
                a.DFirstName = ol.DFirstName;
                a.DLastName = ol.DLastName;
                a.SID = Convert.ToInt32(ol.SID);
                a.SCCode = ol.SCCode;
                a.SCName = ol.SCName;
                a.SType = Convert.ToInt32(ol.SType);
                a.JDate = Convert.ToDateTime(ol.JDate);
                a.JRemark = ol.JRemark;
                a.JStatus = Convert.ToInt32(ol.JStatus);


                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }


                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;


                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }



                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }



                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.RoutID = Convert.ToInt32(ol.RoutID);


                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }


                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;
                a.OrderType = Convert.ToInt32(ol.OrderType);

                model.Add(a);

            }

            return View(model);

        }
        public ActionResult JobInfo()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F2";
            string JobID = "";
            JobID = Request.QueryString["JobID"];

            string SOID = "";
            string ROID = "";

            if (JobID == "" || JobID == null)
            {
                return RedirectToAction("CloseJobList", "TMS");
            }

            List<Transferlist> model = new List<Transferlist>();
            List<JobInfo> JInfo = new List<JobInfo>();
            List<JobDetailInfo> JDInfo = new List<JobDetailInfo>();

            var sJobInfo = (from j in db.Jobs
                            join so in db.Orders on j.SOID equals so.OrderID into SJob
                            from sj in SJob.DefaultIfEmpty()
                            join ro in db.Orders on j.ROID equals ro.OrderID into RJob
                            from rj in RJob.DefaultIfEmpty()
                            join c in db.Customers on sj.CustomerID equals c.ID
                            join sh in db.Shippers on sj.ShipperID equals sh.ID 
                            join r in db.Routes on sj.RoutID equals r.ID
                            join d in db.Drivers on j.DriverID equals d.ID into dDriver
                            from dr in dDriver.DefaultIfEmpty()
                            join t in db.Trucks on j.TruckID equals t.ID into tTruck
                            from tr in tTruck.DefaultIfEmpty()
                            join h in db.Trucks on j.HitchID equals h.ID into hTruck
                            from hr in hTruck.DefaultIfEmpty()
                            join s in db.SubContacts on j.SID equals s.ID into sSub
                            from sr in sSub.DefaultIfEmpty()
                            where j.JobID == JobID
                            orderby j.JobID descending
                            select new
                            {
                                JobID = j.JobID,
                                JobType = j.JobType,
                                SOID = j.SOID,
                                SNum = j.SNum,
                                ROID = j.ROID,
                                RNum = j.RNum,
                                TruckID = j.TruckID,
                                License = tr.License,
                                HitchID = j.HitchID,
                                HitchLicense = hr.License,
                                DriverID = j.DriverID,
                                DTitle = dr.Title,
                                DFirstName = dr.FirstName,
                                DLastName = dr.LastName,
                                SID = j.SID,
                                SCCode = sr.Code,
                                SCName = sr.Name,
                                SType = j.SType,
                                JDate = j.JDate,
                                JRemark = j.Remark,
                                JStatus = j.Status,

                                CustomerID = sj.CustomerID,
                                OrderDate = sj.OrderDate,
                                ReceiveDate = sj.ReceiveDate,
                                DliveryDate = sj.DliveryDate,
                                RoutID = sj.RoutID,

                                PPackDate = sj.PPackDate,
                                TPackDate1 = sj.TPackDate1,
                                TPackDate2 = sj.TPackDate2,
                                TPackDate3 = sj.TPackDate3,
                                TPackDate4 = sj.TPackDate4,
                                TNumberOrder1 = sj.TNumberOrder1,
                                TNumberOrder2 = sj.TNumberOrder2,
                                TNumberOrder3 = sj.TNumberOrder3,
                                TNumberOrder4 = sj.TNumberOrder4,
                                OrderType = sj.OrderType,

                                IEReceiveDate = sj.IEReceiveDate,
                                IEPackDate = sj.IEPackDate,
                                IEPacklTime = sj.IEPacklTime,

                                IEReturnDate = sj.IEReturnDate,
                                IEETDDate = sj.IEETDDate,

                                IEETADate = sj.IEETADate,
                                ROrderType = rj.OrderType,

                                CName = c.Name,
                                CAddress = c.Address,
                                CProvince = c.Province,
                                CZipCode = c.ZipCode,
                                CTelephone = c.Telephone,

                                RFromDetail = r.FromDetail,
                                RFromProvince = r.FromProvince,
                                RToDetail = r.ToDetail,
                                RToProvince = r.ToProvince,

                                SName = sh.Name,
                                SAddress = sh.Address,
                                SProvince = sh.Province,
                                SZipCode = sh.ZipCode,
                                STelephone = sh.Telephone

                            }
                       ).ToList();

            foreach (var ol in sJobInfo)
            {
                JobInfo a = new JobInfo();

                SOID = ol.SOID;
                ROID = ol.ROID;

                a.JobID = ol.JobID;
                a.JobType = Convert.ToInt32(ol.JobType);
                a.SOID = ol.SOID;
                a.SNum = Convert.ToInt32(ol.SNum);
                a.ROID = ol.ROID;
                a.RNum = Convert.ToInt32(ol.RNum);
                a.TruckID = Convert.ToInt32(ol.TruckID);
                a.License = ol.License;
                a.HitchID = Convert.ToInt32(ol.HitchID);
                a.HitchLicense = ol.HitchLicense;
                a.DriverID = Convert.ToInt32(ol.DriverID);
                a.DTitle = ol.DTitle;
                a.DFirstName = ol.DFirstName;
                a.DLastName = ol.DLastName;
                a.SID = Convert.ToInt32(ol.SID);
                a.SCCode = ol.SCCode;
                a.SCName = ol.SCName;
                a.SType = Convert.ToInt32(ol.SType);
                a.JDate = Convert.ToDateTime(ol.JDate);
                a.JRemark = ol.JRemark;
                a.JStatus = Convert.ToInt32(ol.JStatus);
                a.OrderType = Convert.ToInt32(ol.OrderType);
                a.ROrderType = Convert.ToInt32(ol.ROrderType);
                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }


                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;


                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }



                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }



                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.RoutID = Convert.ToInt32(ol.RoutID);


                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }


                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;
                a.SName = ol.SName;
                a.SAddress = ol.SAddress;
                a.SProvince = ol.SProvince;
                a.SZipCode = ol.SZipCode;
                a.STelephone = ol.STelephone;

                JInfo.Add(a);

            }

            var sJobDetailInfo = (from jd in db.JobDetails
                                  join od in db.OrderDetails on jd.ODID equals od.ID
                                  //join c in db.Customers on o.CustomerID equals c.ID
                                  //join r in db.Routes on o.RoutID equals r.ID
                                  //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                                  //  join d in db.LMS_Driver on b.DriverID equals d.ID
                                  where jd.JobID == JobID
                                  select new
                                  {
                                      JDID = jd.ID,
                                      JobID = jd.JobID,
                                      JobType = jd.JobType,
                                      OrderID = jd.OID,
                                      ODID = jd.ODID,
                                      ContainerNo = od.ContainerNo,
                                      ContainerType = od.ContainerType,
                                      Position = od.Position,
                                      PackNo = od.PackNo,
                                      TPackDate = od.TPackDate,
                                      RouteID = od.RoutID,
                                      TareWeight = od.TareWeight,
                                      Status = od.Status
                                  }
).ToList();

            foreach (var odl in sJobDetailInfo)
            {
                JobDetailInfo b = new JobDetailInfo();
                int RouteID = 0;
                decimal TareWeight = 0;

                if (odl.RouteID != null)
                {
                    RouteID = Convert.ToInt32(odl.RouteID);
                }

                if (odl.TareWeight != null)
                {
                    TareWeight = Convert.ToDecimal(odl.TareWeight);
                }

                b.ContainerNo = odl.ContainerNo;
                b.ContainerType = odl.ContainerType;
                b.PackNo = odl.PackNo;
                b.Position = odl.Position;


                if (odl.TPackDate == null)
                {
                    b.TPackDate = DateTime.Now.Date;
                }
                else
                {
                    b.TPackDate = Convert.ToDateTime(odl.TPackDate);
                }
                b.RouteID = RouteID;
                b.TareWeight = TareWeight;
                b.Status = Convert.ToInt32(odl.Status);

                b.JDID = odl.JDID;
                b.JobID = odl.JobID;
                b.JobType = Convert.ToInt32(odl.JobType);
                b.ODID = Convert.ToInt32(odl.ODID);
                b.OrderID = odl.OrderID;
                JDInfo.Add(b);

            }

            List<OrderInfo> JOrderS = new List<OrderInfo>();

            var jS = (from j in db.Jobs
                      join o in db.Orders on j.SOID equals o.OrderID
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == SOID && j.JobID == JobID
                   
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jS)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderS.Add(joad);

            }

            List<OrderDetailInfo> JOrderDS = new List<OrderDetailInfo>();

            var joS = (from j in db.JobDetails
                       join o in db.Orders on j.OID equals o.OrderID
                       join od in db.OrderDetails on j.ODID equals od.ID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == SOID && j.JobID == JobID
                       orderby od.Status, od.ID
                       //where
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight,
                           JReveiveDate = j.ReceiveDate,
                           JStatus = j.Status
                       }
                 ).ToList();

            foreach (var joal in joS)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);
                joad.JStatus = Convert.ToInt32(joal.JStatus);
                joad.JReceiveDate = Convert.ToDateTime(joal.JReveiveDate);
                JOrderDS.Add(joad);

            }

            //เที่ยวกลับ

            List<OrderInfo> JOrderR = new List<OrderInfo>();

            var jR = (from j in db.Jobs
                      join o in db.Orders on j.ROID equals o.OrderID
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == ROID && j.JobID == JobID

                      //where
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jR)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderR.Add(joad);

            }

            List<OrderDetailInfo> JOrderDR = new List<OrderDetailInfo>();

            var joR = (from j in db.JobDetails
                       join o in db.Orders on j.OID equals o.OrderID
                       join od in db.OrderDetails on j.ODID equals od.ID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == ROID && j.JobID == JobID
                       orderby od.Status, od.ID

                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight
                       }
                 ).ToList();

            foreach (var joal in joR)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);

                JOrderDR.Add(joad);

            }
            List<TransferT> JTransfer = new List<TransferT>();

            var jT = (from t in db.Transfers
                      where t.JobID == JobID

                      select new
                      {
                          TransferID = t.ID,
                          JobID = t.JobID,
                          OpenJobDate = t.OpenJobDate,
                          TransferDate = t.TransferDate,
                          TransferTime = t.TransferTime,
                          OMile = t.OMile,
                          OOli = t.OOli,
                          OWay = t.OWay,
                          OOther = t.OOther,
                          ORemark = t.ORemark,
                          CloseJobDate = t.CloseJobDate,
                          ArriveDate = t.ArriveDate,
                          ArriveTime = t.ArriveTime,
                          //ReturnDate = t.ReturnDate,
                          //ReturnTime = t.ReturnTime,
                          ROli = t.ROli,
                          RDistance = t.RDistance,
                          CMile = t.CMile,
                          COli = t.COli,
                          CWay = t.CWay,
                          COther = t.COther,
                          CRemark = t.CRemark,
                          DeliveryCost = t.DeliveryCost,
                          DriverCost = t.DriverCost,
                          SIncome = t.SIncome,
                          RIncome = t.RIncome,
                          AllIncome = t.AllIncome,
                          WCarB = t.WcarB,
                          WGas = t.WGas,
                          WCarW = t.WcarW,
                          Status = t.Status
                      }
               ).ToList();

            foreach (var tj in jT)
            {
                TransferT tt = new TransferT();

                tt.AllIncome = Convert.ToDecimal(tj.AllIncome);
                tt.ArriveDate = Convert.ToDateTime(tj.ArriveDate);
                tt.ArriveTime = tj.ArriveTime;
                tt.CloseJobDate = Convert.ToDateTime(tj.CloseJobDate);
                tt.CMile = Convert.ToDecimal(tj.CMile);
                tt.COli = Convert.ToDecimal(tj.COli);
                tt.COther = Convert.ToDecimal(tj.COther);
                tt.CRemark = tj.CRemark;
                tt.CWay = Convert.ToDecimal(tj.CWay);
                tt.DeliveryCost = Convert.ToDecimal(tj.DeliveryCost);
                tt.DriverCost = Convert.ToDecimal(tj.DriverCost);
                tt.JobID = tj.JobID;
                tt.OMile = Convert.ToDecimal(tj.OMile);
                tt.OOli = Convert.ToDecimal(tj.OOli);
                tt.OOther = Convert.ToDecimal(tj.OOther);
                tt.OpenJobDate = Convert.ToDateTime(tj.OpenJobDate);
                tt.ORemark = tj.ORemark;
                tt.OWay = Convert.ToDecimal(tj.OWay);
                tt.RDistance = Convert.ToDecimal(tj.RDistance);
                //tt.ReturnDate = Convert.ToDateTime(tj.ReturnDate);
                //tt.ReturnTime = tj.ReturnTime;
                tt.RIncome = Convert.ToDecimal(tj.RIncome);
                tt.ROli = Convert.ToDecimal(tj.ROli);
                tt.SIncome = Convert.ToDecimal(tj.SIncome);
                tt.Status = Convert.ToInt32(tj.Status);
                tt.TransferID = tj.TransferID;
                tt.TransferDate = Convert.ToDateTime(tj.TransferDate);
                tt.TransferTime = tj.TransferTime;
                tt.WCarB = Convert.ToDecimal(tj.WCarB);
                tt.WGas = Convert.ToDecimal(tj.WGas);
                tt.WCarW = Convert.ToDecimal(tj.WCarW);

                JTransfer.Add(tt);

            }

            List<TransferOliDetail> OTransfer = new List<TransferOliDetail>();

            var oT = (from t in db.TransferOlis
                      join g in db.GasStations on t.GasID equals g.ID
                      where t.JobID == JobID

                      select new
                      {
                         OliID = t.ID,
                         JobID = t.JobID,
                         SaveDate = t.SaveDate,
                         EditDate = t.EditDate,
                         CancelDate = t.CancelDate,
                         OliDetail = t.OliDetail,
                         OliNum = t.OliNum,
                         OliPrice = t.OliPrice,
                         OliSumPrice = t.OliSumPrice,
                         Status = t.Status,
                         GasID = t.GasID,
                         GName = g.Name,
                         GBranch = g.Branch
                      }
               ).ToList();

            foreach (var o in oT)
            {
                TransferOliDetail OliT = new TransferOliDetail();

                OliT.ID = Convert.ToInt32(o.OliID);
                OliT.JobID = o.JobID;
                OliT.SaveDate = Convert.ToDateTime(o.SaveDate);
                OliT.EditDate = Convert.ToDateTime(o.EditDate);
                OliT.CancelDate = Convert.ToDateTime(o.CancelDate);
                OliT.OliDetail = o.OliDetail;
                OliT.OliNum = Convert.ToDecimal(o.OliNum);
                OliT.OliPrice = Convert.ToDecimal(o.OliPrice);
                OliT.OliSumPrice = Convert.ToDecimal(o.OliSumPrice);
                OliT.Status = Convert.ToInt32(o.Status);
                OliT.GasID = Convert.ToInt32(o.GasID);
                OliT.GName = o.GName;
                OliT.GBranch = o.GBranch;
                OTransfer.Add(OliT);
             

            }

            List<TransferWayDetail> WTransfer = new List<TransferWayDetail>();

            var wT = (from t in db.TransferWays
                      where t.JobID == JobID

                      select new
                      {
                          WayID = t.ID,
                          JobID = t.JobID,
                          SaveDate = t.SaveDate,
                          EditDate = t.EditDate,
                          CancelDate = t.CancelDate,
                          WayDetail = t.WayDetail,
                          WayNum = t.WayNum,
                          WayPrice = t.WayPrice,
                          WaySumPrice = t.WaySumPrice,
                          Status = t.Status
                      }
               ).ToList();

            foreach (var w in wT)
            {
                TransferWayDetail WayT = new TransferWayDetail();

                WayT.ID = Convert.ToInt32(w.WayID);
                WayT.JobID = w.JobID;
                WayT.SaveDate = Convert.ToDateTime(w.SaveDate);
                WayT.EditDate = Convert.ToDateTime(w.EditDate);
                WayT.CancelDate = Convert.ToDateTime(w.CancelDate);
                WayT.WayDetail = w.WayDetail;
                WayT.WayNum = Convert.ToDecimal(w.WayNum);
                WayT.WayPrice = Convert.ToDecimal(w.WayPrice);
                WayT.WaySumPrice = Convert.ToDecimal(w.WaySumPrice);
                WayT.Status = Convert.ToInt32(w.Status);
                WTransfer.Add(WayT);


            }

            List<TransferOTHDetail> OTHTransfer = new List<TransferOTHDetail>();

            var othT = (from t in db.TransferOTHs
                      where t.JobID == JobID

                      select new
                      {
                          OTHID = t.ID,
                          JobID = t.JobID,
                          SaveDate = t.SaveDate,
                          EditDate = t.EditDate,
                          CancelDate = t.CancelDate,
                          OTHDetail = t.OTHDetail,
                          OTHNum = t.OTHNum,
                          OTHPrice = t.OTHPrice,
                          OTHSumPrice = t.OTHSumPrice,
                          Status = t.Status
                      }
               ).ToList();

            foreach (var oth in othT)
            {
                TransferOTHDetail OTHT = new TransferOTHDetail();

                OTHT.ID = Convert.ToInt32(oth.OTHID);
                OTHT.JobID = oth.JobID;
                OTHT.SaveDate = Convert.ToDateTime(oth.SaveDate);
                OTHT.EditDate = Convert.ToDateTime(oth.EditDate);
                OTHT.CancelDate = Convert.ToDateTime(oth.CancelDate);
                OTHT.OTHDetail = oth.OTHDetail;
                OTHT.OTHNum = Convert.ToDecimal(oth.OTHNum);
                OTHT.OTHPrice = Convert.ToDecimal(oth.OTHPrice);
                OTHT.OTHSumPrice = Convert.ToDecimal(oth.OTHSumPrice);
                OTHT.Status = Convert.ToInt32(oth.Status);
                OTHTransfer.Add(OTHT);


            }


            Transferlist TL = new Transferlist();
            TL.TJob = JInfo.ToList();
            TL.TJobDetail = JDInfo.ToList();
            TL.JOrderS = JOrderS.ToList();
            TL.JOrderDS = JOrderDS.ToList();
            TL.JOrderR = JOrderR.ToList();
            TL.JOrderDR = JOrderDR.ToList();
            TL.TTransfer = JTransfer.ToList();
            TL.OTransfer = OTransfer.ToList();
            TL.WTransfer = WTransfer.ToList();
            TL.OTHTransfer = OTHTransfer.ToList();

            model.Add(TL);

            return View(model);
        }

        public ActionResult OpenJobDetail()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F3";
            string JobID = "";
            JobID = Request.QueryString["JobID"];

            string SOID = "";
            string ROID = "";

            if (JobID == "" || JobID == null)
            {
                return RedirectToAction("OpenJobList", "TMS");
            }

            List<Transferlist> model = new List<Transferlist>();
            List<JobInfo> JInfo = new List<JobInfo>();
            List<JobDetailInfo> JDInfo = new List<JobDetailInfo>();

            var sJobInfo = (from j in db.Jobs
                            join so in db.Orders on j.SOID equals so.OrderID into SJob
                            from sj in SJob.DefaultIfEmpty()
                            join ro in db.Orders on j.ROID equals ro.OrderID into RJob
                            from rj in RJob.DefaultIfEmpty()
                            join c in db.Customers on sj.CustomerID equals c.ID
                            join sh in db.Shippers on sj.ShipperID equals sh.ID
                            join r in db.Routes on sj.RoutID equals r.ID
                            join d in db.Drivers on j.DriverID equals d.ID into dDriver
                            from dr in dDriver.DefaultIfEmpty()
                            join t in db.Trucks on j.TruckID equals t.ID into tTruck
                            from tr in tTruck.DefaultIfEmpty()
                            join h in db.Trucks on j.HitchID equals h.ID into hTruck
                            from hr in hTruck.DefaultIfEmpty()
                            join s in db.SubContacts on j.SID equals s.ID into sSub
                            from sr in sSub.DefaultIfEmpty()
                            where j.JobID == JobID
                            orderby j.JobID descending
                            select new
                            {
                                JobID = j.JobID,
                                JobType = j.JobType,
                                SOID = j.SOID,
                                SNum = j.SNum,
                                ROID = j.ROID,
                                RNum = j.RNum,
                                TruckID = j.TruckID,
                                License = tr.License,
                                HitchID = j.HitchID,
                                HitchLicense = hr.License,
                                DriverID = j.DriverID,
                                DTitle = dr.Title,
                                DFirstName = dr.FirstName,
                                DLastName = dr.LastName,
                                SID = j.SID,
                                SCCode = sr.Code,
                                SCName = sr.Name,
                                SType = j.SType,
                                JDate = j.JDate,
                                JRemark = j.Remark,
                                JStatus = j.Status,

                                CustomerID = sj.CustomerID,
                                OrderDate = sj.OrderDate,
                                ReceiveDate = sj.ReceiveDate,
                                DliveryDate = sj.DliveryDate,
                                RoutID = sj.RoutID,

                                PPackDate = sj.PPackDate,
                                TPackDate1 = sj.TPackDate1,
                                TPackDate2 = sj.TPackDate2,
                                TPackDate3 = sj.TPackDate3,
                                TPackDate4 = sj.TPackDate4,
                                TNumberOrder1 = sj.TNumberOrder1,
                                TNumberOrder2 = sj.TNumberOrder2,
                                TNumberOrder3 = sj.TNumberOrder3,
                                TNumberOrder4 = sj.TNumberOrder4,
                                OrderType = sj.OrderType,

                                IEReceiveDate = sj.IEReceiveDate,
                                IEPackDate = sj.IEPackDate,
                                IEPacklTime = sj.IEPacklTime,

                                IEReturnDate = sj.IEReturnDate,
                                IEETDDate = sj.IEETDDate,

                                IEETADate = sj.IEETADate,
                                ROrderType = rj.OrderType,

                                CName = c.Name,
                                CAddress = c.Address,
                                CProvince = c.Province,
                                CZipCode = c.ZipCode,
                                CTelephone = c.Telephone,

                                RFromDetail = r.FromDetail,
                                RFromProvince = r.FromProvince,
                                RToDetail = r.ToDetail,
                                RToProvince = r.ToProvince
                            }
                       ).ToList();

            foreach (var ol in sJobInfo)
            {
                JobInfo a = new JobInfo();

                SOID = ol.SOID;
                ROID = ol.ROID;

                a.JobID = ol.JobID;
                a.JobType = Convert.ToInt32(ol.JobType);
                a.SOID = ol.SOID;
                a.SNum = Convert.ToInt32(ol.SNum);
                a.ROID = ol.ROID;
                a.RNum = Convert.ToInt32(ol.RNum);
                a.TruckID = Convert.ToInt32(ol.TruckID);
                a.License = ol.License;
                a.HitchID = Convert.ToInt32(ol.HitchID);
                a.HitchLicense = ol.HitchLicense;
                a.DriverID = Convert.ToInt32(ol.DriverID);
                a.DTitle = ol.DTitle;
                a.DFirstName = ol.DFirstName;
                a.DLastName = ol.DLastName;
                a.SID = Convert.ToInt32(ol.SID);
                a.SCCode = ol.SCCode;
                a.SCName = ol.SCName;
                a.SType = Convert.ToInt32(ol.SType);
                a.JDate = Convert.ToDateTime(ol.JDate);
                a.JRemark = ol.JRemark;
                a.JStatus = Convert.ToInt32(ol.JStatus);
                a.OrderType = Convert.ToInt32(ol.OrderType);
                a.ROrderType = Convert.ToInt32(ol.ROrderType);
                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }


                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;


                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }



                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }



                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.RoutID = Convert.ToInt32(ol.RoutID);


                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }


                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;

                JInfo.Add(a);

            }

            var sJobDetailInfo = (from jd in db.JobDetails
                                  join od in db.OrderDetails on jd.ODID equals od.ID
                                  //join c in db.Customers on o.CustomerID equals c.ID
                                  //join r in db.Routes on o.RoutID equals r.ID
                                  //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                                  //  join d in db.LMS_Driver on b.DriverID equals d.ID
                                  where jd.JobID == JobID
                                  select new
                                  {
                                      JDID = jd.ID,
                                      JobID = jd.JobID,
                                      JobType = jd.JobType,
                                      OrderID = jd.OID,
                                      ODID = jd.ODID,
                                      ContainerNo = od.ContainerNo,
                                      ContainerType = od.ContainerType,
                                      Position = od.Position,
                                      PackNo = od.PackNo,
                                      TPackDate = od.TPackDate,
                                      RouteID = od.RoutID,
                                      TareWeight = od.TareWeight,
                                      Status = od.Status
                                  }
).ToList();

            foreach (var odl in sJobDetailInfo)
            {
                JobDetailInfo b = new JobDetailInfo();
                int RouteID = 0;
                decimal TareWeight = 0;

                if (odl.RouteID != null)
                {
                    RouteID = Convert.ToInt32(odl.RouteID);
                }

                if (odl.TareWeight != null)
                {
                    TareWeight = Convert.ToDecimal(odl.TareWeight);
                }

                b.ContainerNo = odl.ContainerNo;
                b.ContainerType = odl.ContainerType;
                b.PackNo = odl.PackNo;
                b.Position = odl.Position;


                if (odl.TPackDate == null)
                {
                    b.TPackDate = DateTime.Now.Date;
                }
                else
                {
                    b.TPackDate = Convert.ToDateTime(odl.TPackDate);
                }
                b.RouteID = RouteID;
                b.TareWeight = TareWeight;
                b.Status = Convert.ToInt32(odl.Status);

                b.JDID = odl.JDID;
                b.JobID = odl.JobID;
                b.JobType = Convert.ToInt32(odl.JobType);
                b.ODID = Convert.ToInt32(odl.ODID);
                b.OrderID = odl.OrderID;
                JDInfo.Add(b);

            }

            List<OrderInfo> JOrderS = new List<OrderInfo>();

            var jS = (from j in db.Jobs 
                      join o in db.Orders on j.SOID equals o.OrderID
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == SOID && j.JobID == JobID

                      //where
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jS)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderS.Add(joad);

            }

            List<OrderDetailInfo> JOrderDS = new List<OrderDetailInfo>();

            var joS = (from j in db.JobDetails 
                       join o in db.Orders on j.OID equals o.OrderID
                       join od in db.OrderDetails on j.ODID equals od.ID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == SOID && j.JobID == JobID
                       orderby od.Status, od.ID
                       //where
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight
                       }
                 ).ToList();

            foreach (var joal in joS)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);

                JOrderDS.Add(joad);

            }

            //เที่ยวกลับ

            List<OrderInfo> JOrderR = new List<OrderInfo>();

            var jR = (from j in db.Jobs 
                      join o in db.Orders on j.ROID equals o.OrderID
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == ROID && j.JobID == JobID

                      //where
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jR)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderR.Add(joad);

            }

            List<OrderDetailInfo> JOrderDR = new List<OrderDetailInfo>();

            var joR = (from j in db.JobDetails 
                       join o in db.Orders on j.OID equals o.OrderID
                       join od in db.OrderDetails on j.ODID equals od.ID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == ROID && j.JobID == JobID
                       orderby od.Status, od.ID
                       //where
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight
                       }
                 ).ToList();

            foreach (var joal in joR)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);

                JOrderDR.Add(joad);

            }

            Transferlist TL = new Transferlist();
            TL.TJob = JInfo.ToList();
            TL.TJobDetail = JDInfo.ToList();
            TL.JOrderS = JOrderS.ToList();
            TL.JOrderDS = JOrderDS.ToList();
            TL.JOrderR = JOrderR.ToList();
            TL.JOrderDR = JOrderDR.ToList();
          
            model.Add(TL);

            return View(model);
        }
        public ActionResult OpenJobCommit(FormCollection form)
        {
           
            string SOrderID = form["SOID"];
            string ROrderID = form["ROID"];
            string JobID = form["JobID"];
                int SID = 0;
                int TID = 0;
                int HID = 0;

            string STransferDate = form["TransferDate"];
            DateTime TransferDate = DateTime.Now.Date;


            decimal OMile = 0;
              decimal OOli = 0;
              decimal OWay = 0;
              decimal OOther = 0;

             if (form["SID"] != null || form["SID"] != "")
            {
                SID = Convert.ToInt32(form["SID"]);
            }
             if (form["TID"] != null || form["TID"] != "")
            {
                TID = Convert.ToInt32(form["TID"]);
            }
             if (form["HID"] != null || form["HID"] != "")
            {
                HID = Convert.ToInt32(form["HID"]);
            }

             if (form["OMile"] != "")
            {
                OMile = Convert.ToDecimal(form["OMile"]);
            }
            if (form["OOli"] != "")
            {
                OOli = Convert.ToDecimal(form["OOli"]);
            }
            if (form["OWay"] != "")
            {
                OWay = Convert.ToDecimal(form["OWay"]);
            }
            if (form["OOther"] != "")
            {
                OOther = Convert.ToDecimal(form["OOther"]);
            }


            if (STransferDate == null || STransferDate == "")
            {
                TransferDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = STransferDate.Substring(0, 2);
                string d2 = STransferDate.Substring(3, 2);
                string d3 = STransferDate.Substring(6, 4);
                // string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                TransferDate = DateTime.Parse(d4);
            }
            
            Transfer AddTransfer = new Transfer();
            AddTransfer.JobID = JobID;
            AddTransfer.OpenJobDate = DateTime.Now.Date;
            AddTransfer.TransferDate = TransferDate;
            AddTransfer.TransferTime = form["TransferTime"];
            AddTransfer.OMile = OMile;
                 AddTransfer.OOli = OOli;
                 AddTransfer.OWay = OWay;
                 AddTransfer.OOther = OOther;
                 AddTransfer.ORemark = form["ORemark"];
                AddTransfer.Status = 1;

            db.Transfers.Add(AddTransfer);
            db.SaveChanges();

            Job UpdateJ = new Job();
            var SJob = (from j in db.Jobs
                          where j.JobID == JobID
                          select j).SingleOrDefault();
            SJob.Status = 3;
            db.SaveChanges();

            Order SUpdateO = new Order();

            var SOrder = (from o in db.Orders
                          where o.OrderID == SOrderID
                          select o).SingleOrDefault();

            SOrder.Status = 3;
            db.SaveChanges();

            JobDetail SJobDetail = new JobDetail();

            var SDJob = (from jd in db.JobDetails
                             where jd.JobID == JobID
                             select jd).ToList();

            foreach (var jl in SDJob)
            {

                OrderDetail SUpdateOD = new OrderDetail();

                var SODUpdate = (from od in db.OrderDetails
                                 where od.ID == jl.ODID
                                 select od).ToList();

                foreach (var ol in SODUpdate)
                {
                    ol.Status = 3;
                    db.SaveChanges();
                }
            }

           

            if (ROrderID != "")
            {

            
                Order RUpdateO = new Order();

                var ROrder = (from o in db.Orders
                              where o.OrderID == ROrderID
                              select o).SingleOrDefault();

                ROrder.Status = 3;
                db.SaveChanges();



                //OrderDetail RUpdateOD = new OrderDetail();

                //var RODUpdate = (from od in db.OrderDetails
                //                 where od.OrderID == ROrderID
                //                 select od).ToList();

                //foreach (var ol in RODUpdate)
                //{
                //    ol.Status = 3;
                //    db.SaveChanges();
                //}
            
            }

            if (TID != 0 )
            {
                Truck UpdateT = new Truck();

                var Truck = (from t in db.Trucks
                             where t.ID == TID
                             select t).Single();

                Truck.Status = 3;
                db.SaveChanges();

                var Hitch = (from t in db.Trucks
                             where t.ID == HID
                             select t).Single();

                Hitch.Status = 3;
                db.SaveChanges();
            }


            return RedirectToAction("JobInfo", "TMS", new { JobID = JobID });
        }
        public ActionResult CloseJobDetail()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F4";
            string JobID = "";
            JobID = Request.QueryString["JobID"];

            string SOID = "";
            string ROID = "";

            if (JobID == "" || JobID == null)
            {
                return RedirectToAction("CloseJobList", "TMS");
            }

            List<Transferlist> model = new List<Transferlist>();
            List<JobInfo> JInfo = new List<JobInfo>();
            List<JobDetailInfo> JDInfo = new List<JobDetailInfo>();

            var sJobInfo = (from j in db.Jobs
                            join so in db.Orders on j.SOID equals so.OrderID into SJob
                            from sj in SJob.DefaultIfEmpty()
                            join ro in db.Orders on j.ROID equals ro.OrderID into RJob
                            from rj in RJob.DefaultIfEmpty()
                            join c in db.Customers on sj.CustomerID equals c.ID
                            join sh in db.Shippers on sj.ShipperID equals sh.ID
                            join r in db.Routes on sj.RoutID equals r.ID
                            join d in db.Drivers on j.DriverID equals d.ID into dDriver
                            from dr in dDriver.DefaultIfEmpty()
                            join t in db.Trucks on j.TruckID equals t.ID into tTruck
                            from tr in tTruck.DefaultIfEmpty()
                            join h in db.Trucks on j.HitchID equals h.ID into hTruck
                            from hr in hTruck.DefaultIfEmpty()
                            join s in db.SubContacts on j.SID equals s.ID into sSub
                            from sr in sSub.DefaultIfEmpty()
                            where j.JobID == JobID
                            orderby j.JobID descending
                            select new
                            {
                                JobID = j.JobID,
                                JobType = j.JobType,
                                SOID = j.SOID,
                                SNum = j.SNum,
                                ROID = j.ROID,
                                RNum = j.RNum,
                                TruckID = j.TruckID,
                                License = tr.License,
                                HitchID = j.HitchID,
                                HitchLicense = hr.License,
                                DriverID = j.DriverID,
                                DTitle = dr.Title,
                                DFirstName = dr.FirstName,
                                DLastName = dr.LastName,
                                SID = j.SID,
                                SCCode = sr.Code,
                                SCName = sr.Name,
                                SType = j.SType,
                                JDate = j.JDate,
                                JRemark = j.Remark,
                                JStatus = j.Status,

                                CustomerID = sj.CustomerID,
                                OrderDate = sj.OrderDate,
                                ReceiveDate = sj.ReceiveDate,
                                DliveryDate = sj.DliveryDate,
                                RoutID = sj.RoutID,

                                PPackDate = sj.PPackDate,
                                TPackDate1 = sj.TPackDate1,
                                TPackDate2 = sj.TPackDate2,
                                TPackDate3 = sj.TPackDate3,
                                TPackDate4 = sj.TPackDate4,
                                TNumberOrder1 = sj.TNumberOrder1,
                                TNumberOrder2 = sj.TNumberOrder2,
                                TNumberOrder3 = sj.TNumberOrder3,
                                TNumberOrder4 = sj.TNumberOrder4,
                                OrderType = sj.OrderType,

                                IEReceiveDate = sj.IEReceiveDate,
                                IEPackDate = sj.IEPackDate,
                                IEPacklTime = sj.IEPacklTime,

                                IEReturnDate = sj.IEReturnDate,
                                IEETDDate = sj.IEETDDate,

                                IEETADate = sj.IEETADate,
                                ROrderType = rj.OrderType,

                                CName = c.Name,
                                CAddress = c.Address,
                                CProvince = c.Province,
                                CZipCode = c.ZipCode,
                                CTelephone = c.Telephone,

                                RFromDetail = r.FromDetail,
                                RFromProvince = r.FromProvince,
                                RToDetail = r.ToDetail,
                                RToProvince = r.ToProvince
                            }
                       ).ToList();

            foreach (var ol in sJobInfo)
            {
                JobInfo a = new JobInfo();

                SOID = ol.SOID;
                ROID = ol.ROID;

                a.JobID = ol.JobID;
                a.JobType = Convert.ToInt32(ol.JobType);
                a.SOID = ol.SOID;
                a.SNum = Convert.ToInt32(ol.SNum);
                a.ROID = ol.ROID;
                a.RNum = Convert.ToInt32(ol.RNum);
                a.TruckID = Convert.ToInt32(ol.TruckID);
                a.License = ol.License;
                a.HitchID = Convert.ToInt32(ol.HitchID);
                a.HitchLicense = ol.HitchLicense;
                a.DriverID = Convert.ToInt32(ol.DriverID);
                a.DTitle = ol.DTitle;
                a.DFirstName = ol.DFirstName;
                a.DLastName = ol.DLastName;
                a.SID = Convert.ToInt32(ol.SID);
                a.SCCode = ol.SCCode;
                a.SCName = ol.SCName;
                a.SType = Convert.ToInt32(ol.SType);
                a.JDate = Convert.ToDateTime(ol.JDate);
                a.JRemark = ol.JRemark;
                a.JStatus = Convert.ToInt32(ol.JStatus);
                a.OrderType = Convert.ToInt32(ol.OrderType);
                a.ROrderType = Convert.ToInt32(ol.ROrderType);
                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }


                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;


                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }



                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }



                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.RoutID = Convert.ToInt32(ol.RoutID);


                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }


                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;

                JInfo.Add(a);

            }

            var sJobDetailInfo = (from jd in db.JobDetails
                                  join od in db.OrderDetails on jd.ODID equals od.ID
                                  //join c in db.Customers on o.CustomerID equals c.ID
                                  //join r in db.Routes on o.RoutID equals r.ID
                                  //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                                  //  join d in db.LMS_Driver on b.DriverID equals d.ID
                                  where jd.JobID == JobID
                                  select new
                                  {
                                      JDID = jd.ID,
                                      JobID = jd.JobID,
                                      JobType = jd.JobType,
                                      OrderID = jd.OID,
                                      ODID = jd.ODID,
                                      ContainerNo = od.ContainerNo,
                                      ContainerType = od.ContainerType,
                                      Position = od.Position,
                                      PackNo = od.PackNo,
                                      TPackDate = od.TPackDate,
                                      RouteID = od.RoutID,
                                      TareWeight = od.TareWeight,
                                      Status = od.Status
                                  }
).ToList();

            foreach (var odl in sJobDetailInfo)
            {
                JobDetailInfo b = new JobDetailInfo();
                int RouteID = 0;
                decimal TareWeight = 0;

                if (odl.RouteID != null)
                {
                    RouteID = Convert.ToInt32(odl.RouteID);
                }

                if (odl.TareWeight != null)
                {
                    TareWeight = Convert.ToDecimal(odl.TareWeight);
                }

                b.ContainerNo = odl.ContainerNo;
                b.ContainerType = odl.ContainerType;
                b.PackNo = odl.PackNo;
                b.Position = odl.Position;


                if (odl.TPackDate == null)
                {
                    b.TPackDate = DateTime.Now.Date;
                }
                else
                {
                    b.TPackDate = Convert.ToDateTime(odl.TPackDate);
                }
                b.RouteID = RouteID;
                b.TareWeight = TareWeight;
                b.Status = Convert.ToInt32(odl.Status);

                b.JDID = odl.JDID;
                b.JobID = odl.JobID;
                b.JobType = Convert.ToInt32(odl.JobType);
                b.ODID = Convert.ToInt32(odl.ODID);
                b.OrderID = odl.OrderID;
                JDInfo.Add(b);

            }

            List<OrderInfo> JOrderS = new List<OrderInfo>();

            var jS = (from j in db.Jobs
                      join o in db.Orders on j.SOID equals o.OrderID
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == SOID && j.JobID == JobID

                      //where
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jS)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderS.Add(joad);

            }

            List<OrderDetailInfo> JOrderDS = new List<OrderDetailInfo>();

            var joS = (from j in db.JobDetails
                       join o in db.Orders on j.OID equals o.OrderID
                       join od in db.OrderDetails on j.ODID equals od.ID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == SOID && j.JobID == JobID
                       orderby od.Status, od.ID
                       //where
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight
                       }
                 ).ToList();

            foreach (var joal in joS)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);

                JOrderDS.Add(joad);

            }

            //เที่ยวกลับ

            List<OrderInfo> JOrderR = new List<OrderInfo>();

            var jR = (from j in db.Jobs
                      join o in db.Orders on j.ROID equals o.OrderID
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == ROID && j.JobID == JobID

                      //where
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jR)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderR.Add(joad);

            }

            List<OrderDetailInfo> JOrderDR = new List<OrderDetailInfo>();

            var joR = (from j in db.JobDetails
                       join o in db.Orders on j.OID equals o.OrderID
                       join od in db.OrderDetails on j.ODID equals od.ID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == ROID && j.JobID == JobID
                       orderby od.Status, od.ID
                     
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight
                       }
                 ).ToList();

            foreach (var joal in joR)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);

                JOrderDR.Add(joad);

            }
            List<TransferT> JTransfer = new List<TransferT>();

            var jT = (from t in db.Transfers
                       where t.JobID  == JobID
        
                       select new
                       {
                           TransferID = t.ID,
                           JobID = t.JobID,
                           OpenJobDate = t.OpenJobDate,
                           TransferDate = t.TransferDate,
                           TransferTime = t.TransferTime,
                           OMile = t.OMile,
                           OOli = t.OOli,
                           OWay = t.OWay,
                           OOther = t.OOther,
                           ORemark = t.ORemark,
                           CloseJobDate = t.CloseJobDate,
                           ArriveDate = t.ArriveDate,
                           ArriveTime = t.ArriveTime,
                           ReturnDate = t.ReturnDate,
                           ReturnTime = t.ReturnTime,
                           ROli = t.ROli,
                           RDistance = t.RDistance,
                           CMile = t.CMile,
                           COli = t.COli,
                           CWay = t.CWay,
                           COther = t.COther,
                           CRemark = t.CRemark,
                           DeliveryCost = t.DeliveryCost,
                           DriverCost = t.DriverCost,
                           SIncome = t.SIncome,
                           RIncome = t.RIncome,
                           AllIncome = t.AllIncome,
                           Status = t.Status
                       }
               ).ToList();

            foreach (var tj in jT)
            {
                TransferT tt = new TransferT();

                tt.AllIncome = Convert.ToDecimal(tj.AllIncome);
                tt.ArriveDate = Convert.ToDateTime(tj.ArriveDate);
                tt.ArriveTime = tj.ArriveTime;
                tt.CloseJobDate = Convert.ToDateTime(tj.CloseJobDate);
                tt.CMile = Convert.ToDecimal(tj.CMile);
                tt.COli = Convert.ToDecimal(tj.COli);
                tt.COther = Convert.ToDecimal(tj.COther);
                tt.CRemark = tj.CRemark;
                tt.CWay = Convert.ToDecimal(tj.CWay);
                tt.DeliveryCost = Convert.ToDecimal(tj.DeliveryCost);
                tt.DriverCost = Convert.ToDecimal(tj.DriverCost);
                tt.JobID = tj.JobID;
                tt.OMile = Convert.ToDecimal(tj.OMile);
                tt.OOli = Convert.ToDecimal(tj.OOli);
                tt.OOther = Convert.ToDecimal(tj.OOther);
                tt.OpenJobDate = Convert.ToDateTime(tj.OpenJobDate);
                tt.ORemark = tj.ORemark;
                tt.OWay = Convert.ToDecimal(tj.OWay);
                tt.RDistance = Convert.ToDecimal(tj.RDistance);
                tt.ReturnDate = Convert.ToDateTime(tj.ReturnDate);
                tt.ReturnTime = tj.ReturnTime;
                tt.RIncome = Convert.ToDecimal(tj.RIncome);
                tt.ROli = Convert.ToDecimal(tj.ROli);
                tt.SIncome = Convert.ToDecimal(tj.SIncome);
                tt.Status = Convert.ToInt32(tj.Status);
                tt.TransferID = tj.TransferID;
                tt.TransferDate = Convert.ToDateTime(tj.TransferDate);
                tt.TransferTime = tj.TransferTime;

                JTransfer.Add(tt);

            }

            List<GasStationList> GS = new List<GasStationList>();

            var gsd = (from t in db.GasStations
                  
                      select new
                      {
                          ID = t.ID,
                          Name = t.Name,
                          Branch = t.Branch,
                          Province = t.Province
             
                      }
               ).ToList();

            foreach (var dgs in gsd)
            {
                GasStationList gt = new GasStationList();
                gt.ID = dgs.ID;
                gt.Branch = dgs.Branch;
                gt.Name = dgs.Name;
                gt.Province = dgs.Province;
                GS.Add(gt);
           
            }

            Transferlist TL = new Transferlist();
            TL.TJob = JInfo.ToList();
            TL.TJobDetail = JDInfo.ToList();
            TL.JOrderS = JOrderS.ToList();
            TL.JOrderDS = JOrderDS.ToList();
            TL.JOrderR = JOrderR.ToList();
            TL.JOrderDR = JOrderDR.ToList();
            TL.TTransfer = JTransfer.ToList();
            TL.TGasStation = GS.ToList();

            model.Add(TL);

            return View(model);
        }
        public ActionResult CloseJobCommit(FormCollection form)
        {

            int SRouteID = 0;
            int RRouteID = 0;


            string SOrderID = form["SOID"];
            string ROrderID = form["ROID"];
            string JobID = form["JobID"];
            int SID = 0;
            int TID = 0;
            int HID = 0;

            if (form["SRouteID"] != null || form["SRouteID"] != "")
            {
                SRouteID = Convert.ToInt32(form["SRouteID"]);
            }
            if (form["RRouteID"] != null || form["RRouteID"] != "")
            {
                RRouteID = Convert.ToInt32(form["RRouteID"]);
            }

            string STransferDate = form["TransferDate"];
            DateTime TransferDate = DateTime.Now.Date;
            string SArriveDate = form["ArriveDate"];
            DateTime ArriveDate = DateTime.Now.Date;
            //string SReturnDate = form["ReturnDate"];
            //DateTime ReturnDate = DateTime.Now.Date;


            decimal OMile = 0;
            decimal OOli = 0;
            decimal OWay = 0;
            decimal OOther = 0;

            decimal RDistance = 0;
            //decimal ROli = 0;

            decimal CMile = 0;
            decimal COli = 0;
            decimal CWay = 0;
            decimal COther = 0;

            decimal WCarB = 0;
            decimal WGas = 0;
            decimal WCarW = 0;

            decimal SDeliveryCost = 0;
            decimal RDeliveryCost = 0;
            decimal DeliveryCost = 0;

            decimal SDriverCost = 0;
            decimal RDriverCost = 0;
            decimal xDriverCost = 0;
            decimal DriverCost = 0;

            decimal SIncome = 0;
            decimal RIncome = 0;
            decimal AllIncome = 0;


            if (form["OMile"] != "")
            {
                OMile = Convert.ToDecimal(form["OMile"]);
            }
            if (form["OOli"] != "")
            {
                OOli = Convert.ToDecimal(form["OOli"]);
            }
            if (form["OWay"] != "")
            {
                OWay = Convert.ToDecimal(form["OWay"]);
            }
            if (form["OOther"] != "")
            {
                OOther = Convert.ToDecimal(form["OOther"]);
            }

            if (form["RDistance"] != "")
            {
                RDistance = Convert.ToDecimal(form["RDistance"]);
            }

            if (form["WCarB"] != "")
            {
                WCarB = Convert.ToDecimal(form["WCarB"]);
            }

            if (form["WGas"] != "")
            {
                WGas = Convert.ToDecimal(form["WGas"]);
            }

            if (form["WCarW"] != "")
            {
                WCarW = Convert.ToDecimal(form["WCarW"]);
            }
            //if (form["ROli"] != "")
            //{
            //    ROli = Convert.ToDecimal(form["ROli"]);
            //}

            if (form["CMile"] != "")
            {
                CMile = Convert.ToDecimal(form["CMile"]);
            }
          


            if (STransferDate == null || STransferDate == "")
            {
                TransferDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = STransferDate.Substring(0, 2);
                string d2 = STransferDate.Substring(3, 2);
                string d3 = STransferDate.Substring(6, 4);
                // string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                TransferDate = DateTime.Parse(d4);
            }

            if (SArriveDate == null || SArriveDate == "")
            {
                ArriveDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = SArriveDate.Substring(0, 2);
                string d2 = SArriveDate.Substring(3, 2);
                string d3 = SArriveDate.Substring(6, 4);
                // string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                ArriveDate = DateTime.Parse(d4);
            }

            //if (SReturnDate == null || SReturnDate == "")
            //{
            //    ReturnDate = DateTime.Now.Date;
            //}
            //else
            //{
            //    string d1 = SReturnDate.Substring(0, 2);
            //    string d2 = SReturnDate.Substring(3, 2);
            //    string d3 = SReturnDate.Substring(6, 4);
            //    // string d4 = d1 + "/" + d2 + "/" + d3;
            //    string d4 = d2 + "/" + d1 + "/" + d3;
            //    ReturnDate = DateTime.Parse(d4);
            //}

            var SRoute = (from o in db.Routes
                          where o.ID == SRouteID
                          select o).SingleOrDefault();

            SDeliveryCost = Convert.ToDecimal(SRoute.DeliveryCost);
            SDriverCost = Convert.ToDecimal(SRoute.DriverCost);

            decimal SumCOli = 0;
            decimal SumCWay = 0;
            decimal SumCOTH = 0;

            int Olicounter = 0;
            Olicounter = Convert.ToInt32(form["Olicounter"]);

            if (Olicounter > 0)
            {


                for (var i = 1; i <= Olicounter; i++)
                {
                    //string OliDetail = "OliDetail" + i;
                    string GasID = "GasID" + i;
                    string OliNum = "OliNum" + i;
                    string OliPrice = "OliPrice" + i;
                    string OliSumPrice = "OliSumPrice" + i;

                    decimal dNum = 0;
                    decimal dPrice = 0;
                    decimal dSumPrice = 0;

                    if (form[OliNum] != "")
                    {
                        dNum = Convert.ToDecimal(form[OliNum]);
                    }
                    if (form[OliPrice] != "")
                    {
                        dPrice = Convert.ToDecimal(form[OliPrice]);
                    }
                    if (form[OliSumPrice] != "")
                    {
                        dSumPrice = Convert.ToDecimal(form[OliSumPrice]);
                    }
                    else
                    {
                        dSumPrice = dPrice * dNum;
                    }

                    TransferOli AddO = new TransferOli();
                    AddO.JobID = JobID;
                    AddO.SaveDate = DateTime.Now.Date;
                    AddO.EditDate = DateTime.Now.Date;
                    AddO.CancelDate = DateTime.Now.Date;
                    AddO.GasID = Convert.ToInt32(form[GasID]);
                    //  AddO.OliDetail = form[OliDetail];
                    AddO.OliNum = dNum;
                    AddO.OliPrice = dPrice;
                    AddO.OliSumPrice = dSumPrice;
                    AddO.Status = 1;
                    db.TransferOlis.Add(AddO);
                    db.SaveChanges();

                    SumCOli = SumCOli + dSumPrice;
                }
            }

            int Waycounter = 0;
            Waycounter = Convert.ToInt32(form["Waycounter"]);
            decimal dWaySumPrice = 0;

            if (Waycounter > 0)
            {


                for (var i = 1; i <= Waycounter; i++)
                {
                    string WayDetail = "WayDetail" + i;
                    //string WayNum = "WayNum" + i;
                    //string WayPrice = "WayPrice" + i;
                    string WaySumPrice = "WaySumPrice" + i;

                    if(form[WaySumPrice] != "")
                    {
                        dWaySumPrice = Convert.ToDecimal(form[WaySumPrice]);
                    }

                    TransferWay AddW = new TransferWay();
                    AddW.JobID = JobID;
                    AddW.SaveDate = DateTime.Now.Date;
                    AddW.EditDate = DateTime.Now.Date;
                    AddW.CancelDate = DateTime.Now.Date;
                    AddW.WayDetail = form[WayDetail];
                    //AddW.WayNum = Convert.ToDecimal(form[WayNum]);
                    //AddW.WayPrice = Convert.ToDecimal(form[WayPrice]);
                    AddW.WaySumPrice = dWaySumPrice;
                    AddW.Status = 1;
                    db.TransferWays.Add(AddW);
                    db.SaveChanges();

                    SumCWay = SumCWay + dWaySumPrice;


                }
            }

            int OTHcounter = 0;
            OTHcounter = Convert.ToInt32(form["OTHcounter"]);
            decimal dOTHSumPrice = 0;

            if (OTHcounter > 0)
            {


                for (var i = 1; i <= OTHcounter; i++)
                {
                    string OTHDetail = "OTHDetail" + i;
                    //string OTHNum = "OTHNum" + i;
                    //string OTHPrice = "OTHPrice" + i;
                    string OTHSumPrice = "OTHSumPrice" + i;

                    if (form[OTHSumPrice] != "")
                    {
                        dOTHSumPrice = Convert.ToDecimal(form[OTHSumPrice]);
                    }

                    TransferOTH AddOTH = new TransferOTH();
                    AddOTH.JobID = JobID;
                    AddOTH.SaveDate = DateTime.Now.Date;
                    AddOTH.EditDate = DateTime.Now.Date;
                    AddOTH.CancelDate = DateTime.Now.Date;
                    AddOTH.OTHDetail = form[OTHDetail];
                    //AddOTH.OTHNum = Convert.ToDecimal(form[OTHNum]);
                    //AddOTH.OTHPrice = Convert.ToDecimal(form[OTHPrice]);
                    AddOTH.OTHSumPrice = dOTHSumPrice;
                    AddOTH.Status = 1;
                    db.TransferOTHs.Add(AddOTH);
                    db.SaveChanges();

                    SumCOTH = SumCOTH + dOTHSumPrice;
                }
            }

            COli = OOli - SumCOli;
            CWay = OWay - SumCWay;
            COther = OOther - SumCOTH;

            //if (form["COli"] != "")
            //{
            //    COli = Convert.ToDecimal(form["COli"]);
            //}
            //else
            //{
            //    COli = OOli - SumCOli;
            //}

            //if (form["CWay"] != "")
            //{
            //    CWay = Convert.ToDecimal(form["CWay"]);
            //}
            //else
            //{
            //    CWay = OWay = SumCWay;
            //}

            //if (form["COther"] != "")
            //{
            //    COther = Convert.ToDecimal(form["COther"]);
            //}
            //else
            //{
            //    COther = OOther - SumCOTH;
            //}

            if (ROrderID != "")
            {
                var RRoute = (from o in db.Routes
                              where o.ID == RRouteID
                              select o).SingleOrDefault();

                RDeliveryCost = Convert.ToDecimal(RRoute.DeliveryCost);
                RDriverCost = Convert.ToDecimal(RRoute.DriverCost);
            }

            
            DeliveryCost = SDeliveryCost;
            xDriverCost = RDriverCost * (60 / 100);
            DriverCost = SDriverCost + (RDriverCost - xDriverCost);
            SIncome = SDeliveryCost;
            RIncome = RDeliveryCost;
            AllIncome = SIncome + RIncome;

            RDistance = CMile - OMile;

            Transfer UpdateTransfer = new Transfer();
            var UTransfer = (from t in db.Transfers
                        where t.JobID == JobID
                        select t).SingleOrDefault();

            UTransfer.TransferDate = TransferDate;
            UTransfer.TransferTime = form["TransferTime"];
            UTransfer.OMile = OMile;
            UTransfer.OOli = OOli;
            UTransfer.OWay = OWay;
            UTransfer.OOther = OOther;
            UTransfer.ORemark = form["ORemark"];
            UTransfer.CloseJobDate = DateTime.Now.Date;
            UTransfer.ArriveDate = ArriveDate;
            UTransfer.ArriveTime = form["ArriveTime"];
            //UTransfer.ReturnDate = ReturnDate;
            //UTransfer.ReturnTime = form["ReturnTime"];
            //UTransfer.ROli = ROli;
            UTransfer.RDistance = RDistance;
            UTransfer.CMile = CMile;
            UTransfer.COli = COli;
            UTransfer.CWay = CWay;
            UTransfer.COther = COther;
            UTransfer.CRemark = form["CRemark"];
            UTransfer.DeliveryCost = DeliveryCost;
            UTransfer.DriverCost = DriverCost;
            UTransfer.SIncome = SIncome;
            UTransfer.RIncome = RIncome;
            UTransfer.AllIncome = AllIncome;
            UTransfer.WcarB = WCarB;
            UTransfer.WGas = WGas;
            UTransfer.WcarW = WCarW;
            UTransfer.Status = 2;
            db.SaveChanges();

           
            Job UpdateJ = new Job();
            var SJob = (from j in db.Jobs
                        where j.JobID == JobID
                        select j).SingleOrDefault();
            SJob.Status = 4;
            db.SaveChanges();

            Order SUpdateO = new Order();

            var SOrder = (from o in db.Orders
                          where o.OrderID == SOrderID
                          select o).SingleOrDefault();

            SOrder.Status = 4;
            db.SaveChanges();

            JobDetail SJobDetail = new JobDetail();

            var SDJob = (from jd in db.JobDetails
                         where jd.JobID == JobID
                         select jd).ToList();

            foreach (var jl in SDJob)
            {

                OrderDetail SUpdateOD = new OrderDetail();

                var SODUpdate = (from od in db.OrderDetails
                                 where od.ID == jl.ODID
                                 select od).ToList();

                foreach (var ol in SODUpdate)
                {
                    ol.Status = 4;
                    db.SaveChanges();
                }
            }



            if (ROrderID != "")
            {


                Order RUpdateO = new Order();

                var ROrder = (from o in db.Orders
                              where o.OrderID == ROrderID
                              select o).SingleOrDefault();

                ROrder.Status = 4;
                db.SaveChanges();


            }

            if (TID != 0)
            {
                Truck UpdateT = new Truck();

                var Truck = (from t in db.Trucks
                             where t.ID == TID
                             select t).Single();

                Truck.Status = 4;
                db.SaveChanges();

                var Hitch = (from t in db.Trucks
                             where t.ID == HID
                             select t).Single();

                Hitch.Status = 4;
                db.SaveChanges();
            }


            return RedirectToAction("JobInfo", "TMS", new { JobID = JobID });
        }
        public ActionResult SCloseJobDetail()
        {
            Session["FMenu"] = "F";
            Session["Menu"] = "F4";
            string JobID = "";
            JobID = Request.QueryString["JobID"];

            string SOID = "";
            string ROID = "";

            if (JobID == "" || JobID == null)
            {
                return RedirectToAction("CloseJobList", "TMS");
            }

            List<Transferlist> model = new List<Transferlist>();
            List<JobInfo> JInfo = new List<JobInfo>();
            List<JobDetailInfo> JDInfo = new List<JobDetailInfo>();

            var sJobInfo = (from j in db.Jobs
                            join so in db.Orders on j.SOID equals so.OrderID into SJob
                            from sj in SJob.DefaultIfEmpty()
                            join ro in db.Orders on j.ROID equals ro.OrderID into RJob
                            from rj in RJob.DefaultIfEmpty()
                            join c in db.Customers on sj.CustomerID equals c.ID
                            join sh in db.Shippers on sj.ShipperID equals sh.ID
                            join r in db.Routes on sj.RoutID equals r.ID
                            join d in db.Drivers on j.DriverID equals d.ID into dDriver
                            from dr in dDriver.DefaultIfEmpty()
                            join t in db.Trucks on j.TruckID equals t.ID into tTruck
                            from tr in tTruck.DefaultIfEmpty()
                            join h in db.Trucks on j.HitchID equals h.ID into hTruck
                            from hr in hTruck.DefaultIfEmpty()
                            join s in db.SubContacts on j.SID equals s.ID into sSub
                            from sr in sSub.DefaultIfEmpty()
                            where j.JobID == JobID
                            orderby j.JobID descending
                            select new
                            {
                                JobID = j.JobID,
                                JobType = j.JobType,
                                SOID = j.SOID,
                                SNum = j.SNum,
                                ROID = j.ROID,
                                RNum = j.RNum,
                                TruckID = j.TruckID,
                                License = tr.License,
                                HitchID = j.HitchID,
                                HitchLicense = hr.License,
                                DriverID = j.DriverID,
                                DTitle = dr.Title,
                                DFirstName = dr.FirstName,
                                DLastName = dr.LastName,
                                SID = j.SID,
                                SCCode = sr.Code,
                                SCName = sr.Name,
                                SType = j.SType,
                                JDate = j.JDate,
                                JRemark = j.Remark,
                                JStatus = j.Status,

                                CustomerID = sj.CustomerID,
                                OrderDate = sj.OrderDate,
                                ReceiveDate = sj.ReceiveDate,
                                DliveryDate = sj.DliveryDate,
                                RoutID = sj.RoutID,

                                PPackDate = sj.PPackDate,
                                TPackDate1 = sj.TPackDate1,
                                TPackDate2 = sj.TPackDate2,
                                TPackDate3 = sj.TPackDate3,
                                TPackDate4 = sj.TPackDate4,
                                TNumberOrder1 = sj.TNumberOrder1,
                                TNumberOrder2 = sj.TNumberOrder2,
                                TNumberOrder3 = sj.TNumberOrder3,
                                TNumberOrder4 = sj.TNumberOrder4,
                                OrderType = sj.OrderType,

                                IEReceiveDate = sj.IEReceiveDate,
                                IEPackDate = sj.IEPackDate,
                                IEPacklTime = sj.IEPacklTime,

                                IEReturnDate = sj.IEReturnDate,
                                IEETDDate = sj.IEETDDate,

                                IEETADate = sj.IEETADate,
                                ROrderType = rj.OrderType,

                                CName = c.Name,
                                CAddress = c.Address,
                                CProvince = c.Province,
                                CZipCode = c.ZipCode,
                                CTelephone = c.Telephone,

                                RFromDetail = r.FromDetail,
                                RFromProvince = r.FromProvince,
                                RToDetail = r.ToDetail,
                                RToProvince = r.ToProvince
                               
                            }
                       ).ToList();

            foreach (var ol in sJobInfo)
            {
                JobInfo a = new JobInfo();

                SOID = ol.SOID;
                ROID = ol.ROID;

                a.JobID = ol.JobID;
                a.JobType = Convert.ToInt32(ol.JobType);
                a.SOID = ol.SOID;
                a.SNum = Convert.ToInt32(ol.SNum);
                a.ROID = ol.ROID;
                a.RNum = Convert.ToInt32(ol.RNum);
                a.TruckID = Convert.ToInt32(ol.TruckID);
                a.License = ol.License;
                a.HitchID = Convert.ToInt32(ol.HitchID);
                a.HitchLicense = ol.HitchLicense;
                a.DriverID = Convert.ToInt32(ol.DriverID);
                a.DTitle = ol.DTitle;
                a.DFirstName = ol.DFirstName;
                a.DLastName = ol.DLastName;
                a.SID = Convert.ToInt32(ol.SID);
                a.SCCode = ol.SCCode;
                a.SCName = ol.SCName;
                a.SType = Convert.ToInt32(ol.SType);
                a.JDate = Convert.ToDateTime(ol.JDate);
                a.JRemark = ol.JRemark;
                a.JStatus = Convert.ToInt32(ol.JStatus);
                a.OrderType = Convert.ToInt32(ol.OrderType);
                a.ROrderType = Convert.ToInt32(ol.ROrderType);
                a.CustomerID = Convert.ToInt32(ol.CustomerID);

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }


                if (ol.IEReturnDate == null)
                {
                    a.IEReturnDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReturnDate = Convert.ToDateTime(ol.IEReturnDate);
                }



                if (ol.IEETADate == null)
                {
                    a.IEETADate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETADate = Convert.ToDateTime(ol.IEETADate);
                }


                if (ol.IEETDDate == null)
                {
                    a.IEETDDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEETDDate = Convert.ToDateTime(ol.IEETDDate);
                }


                if (ol.IEPackDate == null)
                {
                    a.IEPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEPackDate = Convert.ToDateTime(ol.IEPackDate);
                }

                a.IEPacklTime = ol.IEPacklTime;


                if (ol.IEReceiveDate == null)
                {
                    a.IEReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.IEReceiveDate = Convert.ToDateTime(ol.IEReceiveDate);
                }



                if (ol.OrderDate == null)
                {
                    a.OrderDate = DateTime.Now.Date;
                }
                else
                {
                    a.OrderDate = Convert.ToDateTime(ol.OrderDate);
                }



                if (ol.PPackDate == null)
                {
                    a.PPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.PPackDate = Convert.ToDateTime(ol.PPackDate);
                }

                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }


                a.RoutID = Convert.ToInt32(ol.RoutID);


                if (ol.TPackDate1 == null)
                {
                    a.TPackDate1 = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate1 = Convert.ToDateTime(ol.TPackDate1);
                }


                a.CAddress = ol.CAddress;
                a.CProvince = ol.CProvince;
                a.CName = ol.CName;
                a.CTelephone = ol.CTelephone;
                a.CZipCode = ol.CZipCode;

                a.RFromDetail = ol.RFromDetail;
                a.RFromProvince = ol.RFromProvince;
                a.RToDetail = ol.RToDetail;
                a.RToProvince = ol.RToProvince;

                JInfo.Add(a);

            }

            var sJobDetailInfo = (from jd in db.JobDetails
                                  join od in db.OrderDetails on jd.ODID equals od.ID
                                  //join c in db.Customers on o.CustomerID equals c.ID
                                  //join r in db.Routes on o.RoutID equals r.ID
                                  //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                                  //  join d in db.LMS_Driver on b.DriverID equals d.ID
                                  where jd.JobID == JobID
                                  select new
                                  {
                                      JDID = jd.ID,
                                      JobID = jd.JobID,
                                      JobType = jd.JobType,
                                      OrderID = jd.OID,
                                      ODID = jd.ODID,
                                      ContainerNo = od.ContainerNo,
                                      ContainerType = od.ContainerType,
                                      Position = od.Position,
                                      PackNo = od.PackNo,
                                      TPackDate = od.TPackDate,
                                      RouteID = od.RoutID,
                                      TareWeight = od.TareWeight,
                                      Status = od.Status,
                                       JStatus = jd.Status
                                  }
).ToList();

            foreach (var odl in sJobDetailInfo)
            {
                JobDetailInfo b = new JobDetailInfo();
                int RouteID = 0;
                decimal TareWeight = 0;

                if (odl.RouteID != null)
                {
                    RouteID = Convert.ToInt32(odl.RouteID);
                }

                if (odl.TareWeight != null)
                {
                    TareWeight = Convert.ToDecimal(odl.TareWeight);
                }

                b.ContainerNo = odl.ContainerNo;
                b.ContainerType = odl.ContainerType;
                b.PackNo = odl.PackNo;
                b.Position = odl.Position;


                if (odl.TPackDate == null)
                {
                    b.TPackDate = DateTime.Now.Date;
                }
                else
                {
                    b.TPackDate = Convert.ToDateTime(odl.TPackDate);
                }
                b.RouteID = RouteID;
                b.TareWeight = TareWeight;
                b.Status = Convert.ToInt32(odl.Status);

                b.JDID = odl.JDID;
                b.JobID = odl.JobID;
                b.JobType = Convert.ToInt32(odl.JobType);
                b.ODID = Convert.ToInt32(odl.ODID);
                b.OrderID = odl.OrderID;
                b.JStatus = Convert.ToInt32(odl.JStatus);
                JDInfo.Add(b);

            }

            List<OrderInfo> JOrderS = new List<OrderInfo>();

            var jS = (from j in db.Jobs
                      join o in db.Orders on j.SOID equals o.OrderID
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == SOID && j.JobID == JobID

                      //where
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jS)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderS.Add(joad);

            }

            List<OrderDetailInfo> JOrderDS = new List<OrderDetailInfo>();

            var joS = (from j in db.JobDetails
                       join o in db.Orders on j.OID equals o.OrderID
                       join od in db.OrderDetails on j.ODID equals od.ID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == SOID && j.JobID == JobID
                       orderby od.Status, od.ID
                       //where
                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight,
                           JReveiveDate = j.ReceiveDate,
                           JStatus = j.Status
                       }
                 ).ToList();

            foreach (var joal in joS)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);
                joad.JStatus = Convert.ToInt32(joal.JStatus);
                joad.JReceiveDate = Convert.ToDateTime(joal.JReveiveDate);
                JOrderDS.Add(joad);

            }

            //เที่ยวกลับ

            List<OrderInfo> JOrderR = new List<OrderInfo>();

            var jR = (from j in db.Jobs
                      join o in db.Orders on j.ROID equals o.OrderID
                      join c in db.Customers on o.CustomerID equals c.ID
                      join s in db.Shippers on o.ShipperID equals s.ID
                      join r in db.Routes on o.RoutID equals r.ID
                      where o.OrderID == ROID && j.JobID == JobID

                      //where
                      select new
                      {
                          OID = o.ID,
                          OrderID = o.OrderID,
                          ReceiveDate = o.ReceiveDate,
                          DliveryDate = o.DliveryDate,
                          OrderType = o.OrderType,
                          CustomerID = o.CustomerID,
                          RouteID = o.RoutID,
                          PPackDate = o.PPackDate,
                          IEReceiveDate = o.IEReceiveDate,
                          IEPackDate = o.IEPackDate,
                          IEReturnDate = o.IEReturnDate,
                          CustomerName = c.Name,
                          rToDetail = r.ToDetail,
                          rFromDetail = r.FromDetail,
                          Status = o.Status,
                          BookingNO = o.BookingNo,
                          TPackDate1 = o.TPackDate1,
                          TPackDate2 = o.TPackDate2,
                          TPackDate3 = o.TPackDate3,
                          TPackDate4 = o.TPackDate4,
                          ShipperID = s.ID,
                          SName = s.Name
                      }
                 ).ToList();

            foreach (var joal in jR)
            {
                OrderInfo joad = new OrderInfo();

                joad.BookingNo = joal.BookingNO;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.CName = joal.CustomerName;
                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.RoutID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.rToDetail;
                joad.RFromDetail = joal.rFromDetail;
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate);
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate);
                joad.TPackDate1 = Convert.ToDateTime(joal.TPackDate1);
                joad.TPackDate2 = Convert.ToDateTime(joal.TPackDate2);
                joad.TPackDate3 = Convert.ToDateTime(joal.TPackDate3);
                joad.TPackDate4 = Convert.ToDateTime(joal.TPackDate4);
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate);
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate);
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate);
                joad.ShipperID = Convert.ToInt32(joal.ShipperID);
                joad.SName = joal.SName;

                JOrderR.Add(joad);

            }

            List<OrderDetailInfo> JOrderDR = new List<OrderDetailInfo>();

            var joR = (from j in db.JobDetails
                       join o in db.Orders on j.OID equals o.OrderID
                       join od in db.OrderDetails on j.ODID equals od.ID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join s in db.Shippers on o.ShipperID equals s.ID
                       join r in db.Routes on o.RoutID equals r.ID
                       where o.OrderID == ROID && j.JobID == JobID
                       orderby od.Status, od.ID

                       select new
                       {
                           OID = o.ID,
                           OrderID = o.OrderID,
                           ReceiveDate = o.ReceiveDate,
                           DliveryDate = o.DliveryDate,
                           OrderType = o.OrderType,
                           CustomerID = o.CustomerID,
                           RouteID = o.RoutID,
                           ODID = od.ID,
                           ContainerNo = od.ContainerNo,
                           ContainerType = od.ContainerType,
                           TPackDate = od.TPackDate,
                           PPackDate = o.PPackDate,
                           IEReceiveDate = o.IEReceiveDate,
                           IEPackDate = o.IEPackDate,
                           IEReturnDate = o.IEReturnDate,
                           Position = od.Position,
                           PackNo = od.PackNo,
                           CustomerName = c.Name,
                           ToDetail = r.ToDetail,
                           FromDetail = r.FromDetail,
                           Status = od.Status,
                           TareWeight = od.TareWeight
                       }
                 ).ToList();

            foreach (var joal in joR)
            {
                OrderDetailInfo joad = new OrderDetailInfo();

                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.OID = joal.OID;
                joad.OrderID = joal.OrderID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.RFromDetail = joal.FromDetail;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.RToDetail = joal.ToDetail;
                joad.Status = Convert.ToInt32(joal.Status);
                joad.TareWeight = Convert.ToDecimal(joal.TareWeight);
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate);

                JOrderDR.Add(joad);

            }
            List<TransferT> JTransfer = new List<TransferT>();

            var jT = (from t in db.Transfers
                      where t.JobID == JobID

                      select new
                      {
                          TransferID = t.ID,
                          JobID = t.JobID,
                          OpenJobDate = t.OpenJobDate,
                          TransferDate = t.TransferDate,
                          TransferTime = t.TransferTime,
                          OMile = t.OMile,
                          OOli = t.OOli,
                          OWay = t.OWay,
                          OOther = t.OOther,
                          ORemark = t.ORemark,
                          CloseJobDate = t.CloseJobDate,
                          ArriveDate = t.ArriveDate,
                          ArriveTime = t.ArriveTime,
                          ReturnDate = t.ReturnDate,
                          ReturnTime = t.ReturnTime,
                          ROli = t.ROli,
                          RDistance = t.RDistance,
                          CMile = t.CMile,
                          COli = t.COli,
                          CWay = t.CWay,
                          COther = t.COther,
                          CRemark = t.CRemark,
                          DeliveryCost = t.DeliveryCost,
                          DriverCost = t.DriverCost,
                          SIncome = t.SIncome,
                          RIncome = t.RIncome,
                          AllIncome = t.AllIncome,
                          Status = t.Status
                      }
               ).ToList();

            foreach (var tj in jT)
            {
                TransferT tt = new TransferT();

                tt.AllIncome = Convert.ToDecimal(tj.AllIncome);
                tt.ArriveDate = Convert.ToDateTime(tj.ArriveDate);
                tt.ArriveTime = tj.ArriveTime;
                tt.CloseJobDate = Convert.ToDateTime(tj.CloseJobDate);
                tt.CMile = Convert.ToDecimal(tj.CMile);
                tt.COli = Convert.ToDecimal(tj.COli);
                tt.COther = Convert.ToDecimal(tj.COther);
                tt.CRemark = tj.CRemark;
                tt.CWay = Convert.ToDecimal(tj.CWay);
                tt.DeliveryCost = Convert.ToDecimal(tj.DeliveryCost);
                tt.DriverCost = Convert.ToDecimal(tj.DriverCost);
                tt.JobID = tj.JobID;
                tt.OMile = Convert.ToDecimal(tj.OMile);
                tt.OOli = Convert.ToDecimal(tj.OOli);
                tt.OOther = Convert.ToDecimal(tj.OOther);
                tt.OpenJobDate = Convert.ToDateTime(tj.OpenJobDate);
                tt.ORemark = tj.ORemark;
                tt.OWay = Convert.ToDecimal(tj.OWay);
                tt.RDistance = Convert.ToDecimal(tj.RDistance);
                tt.ReturnDate = Convert.ToDateTime(tj.ReturnDate);
                tt.ReturnTime = tj.ReturnTime;
                tt.RIncome = Convert.ToDecimal(tj.RIncome);
                tt.ROli = Convert.ToDecimal(tj.ROli);
                tt.SIncome = Convert.ToDecimal(tj.SIncome);
                tt.Status = Convert.ToInt32(tj.Status);
                tt.TransferID = tj.TransferID;
                tt.TransferDate = Convert.ToDateTime(tj.TransferDate);
                tt.TransferTime = tj.TransferTime;

                JTransfer.Add(tt);

            }

            List<GasStationList> GS = new List<GasStationList>();

            var gsd = (from t in db.GasStations

                       select new
                       {
                           ID = t.ID,
                           Name = t.Name,
                           Branch = t.Branch,
                           Province = t.Province

                       }
               ).ToList();

            foreach (var dgs in gsd)
            {
                GasStationList gt = new GasStationList();
                gt.ID = dgs.ID;
                gt.Branch = dgs.Branch;
                gt.Name = dgs.Name;
                gt.Province = dgs.Province;
                GS.Add(gt);

            }

            Transferlist TL = new Transferlist();
            TL.TJob = JInfo.ToList();
            TL.TJobDetail = JDInfo.ToList();
            TL.JOrderS = JOrderS.ToList();
            TL.JOrderDS = JOrderDS.ToList();
            TL.JOrderR = JOrderR.ToList();
            TL.JOrderDR = JOrderDR.ToList();
            TL.TTransfer = JTransfer.ToList();
            TL.TGasStation = GS.ToList();

            model.Add(TL);

            return View(model);
        }
        public ActionResult SCloseJobCommit(FormCollection form)
        {

            int SRouteID = 0;
            int RRouteID = 0;


            string SOrderID = form["SOID"];
            string ROrderID = form["ROID"];
            string JobID = form["JobID"];
            int SID = 0;
            int TID = 0;
            int HID = 0;

            if (form["SRouteID"] != null || form["SRouteID"] != "")
            {
                SRouteID = Convert.ToInt32(form["SRouteID"]);
            }
            if (form["RRouteID"] != null || form["RRouteID"] != "")
            {
                RRouteID = Convert.ToInt32(form["RRouteID"]);
            }

            //string STransferDate = form["TransferDate"];
            //DateTime TransferDate = DateTime.Now.Date;
            string SArriveDate = form["ArriveDate"];
            DateTime ArriveDate = DateTime.Now.Date;
            //string SReturnDate = form["ReturnDate"];
            //DateTime ReturnDate = DateTime.Now.Date;


            decimal OMile = 0;
            decimal OOli = 0;
            decimal OWay = 0;
            decimal OOther = 0;

            decimal RDistance = 0;
            //decimal ROli = 0;

            decimal CMile = 0;
            decimal COli = 0;
            decimal CWay = 0;
            decimal COther = 0;

            decimal WCarB = 0;
            decimal WGas = 0;
            decimal WCarW = 0;

            decimal SDeliveryCost = 0;
            decimal RDeliveryCost = 0;
            decimal DeliveryCost = 0;

            decimal SDriverCost = 0;
            decimal RDriverCost = 0;
            decimal xDriverCost = 0;
            decimal DriverCost = 0;

            decimal SIncome = 0;
            decimal RIncome = 0;
            decimal AllIncome = 0;



            //if (STransferDate == null || STransferDate == "")
            //{
            //    TransferDate = DateTime.Now.Date;
            //}
            //else
            //{
            //    string d1 = STransferDate.Substring(0, 2);
            //    string d2 = STransferDate.Substring(3, 2);
            //    string d3 = STransferDate.Substring(6, 4);
            //    // string d4 = d1 + "/" + d2 + "/" + d3;
            //    string d4 = d2 + "/" + d1 + "/" + d3;
            //    TransferDate = DateTime.Parse(d4);
            //}

            if (SArriveDate == null || SArriveDate == "")
            {
                ArriveDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = SArriveDate.Substring(0, 2);
                string d2 = SArriveDate.Substring(3, 2);
                string d3 = SArriveDate.Substring(6, 4);
                // string d4 = d1 + "/" + d2 + "/" + d3;
                string d4 = d2 + "/" + d1 + "/" + d3;
                ArriveDate = DateTime.Parse(d4);
            }


            string sRow = "";
            int iRow = 0;

            if (form["sRow"] != "")
            {
                iRow = Convert.ToInt32(form["sRow"]);

            }
         
            for (var i = 0; i <= iRow; i++)
            {
                sRow = "J" + i;

                if (form[sRow] != null)
                {
                    iRow = Convert.ToInt32(form[sRow]);
                }


                if (iRow != 0)
                {


                    JobDetail AddJobDetail = new JobDetail();

                    var JDUpdate = (from jd in db.JobDetails
                                    where jd.ODID == iRow
                                    select jd).Single();
                    JDUpdate.Status = 4;
                    JDUpdate.ReceiveDate = ArriveDate;
                    db.SaveChanges();

                    OrderDetail SUpdateOD = new OrderDetail();

                    var SODUpdate = (from od in db.OrderDetails
                                     where od.ID == iRow
                                     select od).Single();

                    SODUpdate.Status = 4;
                    db.SaveChanges();
                }

            }

            var CJD = (from jd in db.JobDetails
                       where jd.JobID == JobID && jd.Status == 3
                       select jd).ToList();

         

            Transfer UpdateTransfer = new Transfer();
            var UTransfer = (from t in db.Transfers
                             where t.JobID == JobID
                             select t).SingleOrDefault();

            //UTransfer.TransferDate = TransferDate;
            //UTransfer.TransferTime = form["TransferTime"];
            UTransfer.OMile = OMile;
            UTransfer.OOli = OOli;
            UTransfer.OWay = OWay;
            UTransfer.OOther = OOther;
            UTransfer.ORemark = form["ORemark"];
            UTransfer.CloseJobDate = DateTime.Now.Date;
            UTransfer.ArriveDate = ArriveDate;
            //UTransfer.ArriveTime = form["ArriveTime"];
            UTransfer.RDistance = RDistance;
            UTransfer.CMile = CMile;
            UTransfer.COli = COli;
            UTransfer.CWay = CWay;
            UTransfer.COther = COther;
            UTransfer.CRemark = form["CRemark"];
            UTransfer.DeliveryCost = DeliveryCost;
            UTransfer.DriverCost = DriverCost;
            UTransfer.SIncome = SIncome;
            UTransfer.RIncome = RIncome;
            UTransfer.AllIncome = AllIncome;
            UTransfer.WcarB = WCarB;
            UTransfer.WGas = WGas;
            UTransfer.WcarW = WCarW;
            if (CJD.Count == 0)
            {
                UTransfer.Status = 2;
            }
            db.SaveChanges();

            if (CJD.Count == 0)
            {
                Job UpdateJ = new Job();
                var SJob = (from j in db.Jobs
                            where j.JobID == JobID
                            select j).SingleOrDefault();
                SJob.Status = 4;
                db.SaveChanges();

                Order SUpdateO = new Order();

                var SOrder = (from o in db.Orders
                              where o.OrderID == SOrderID
                              select o).SingleOrDefault();

                SOrder.Status = 4;
                db.SaveChanges();

              
            }
           
         
            return RedirectToAction("JobInfo", "TMS", new { JobID = JobID });
        }
        public JsonResult serachShipper(string dCustomer)
        {
            int dS = 1;
            dS = Convert.ToInt32(dCustomer);
            var dShipper = (from s in db.Shippers
                          where s.CustomerID == dS
                          select new
                          {
                              sID = s.ID,
                              sName = s.Name,
                              cID = s.CustomerID,
                              sOrderType = s.OrderType
                             
                          }
                 ).ToList();
            List<Shippers> data = new List<Shippers>();
            foreach (var bt in dShipper)
            {
                Shippers b = new Shippers();
                b.ShipperID = bt.sID;
                b.Name = bt.sName;
                b.CustomerID = Convert.ToInt32(bt.cID);
                b.OrderType = Convert.ToInt32(bt.sOrderType);
                
                data.Add(b);
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult serachRoute(string dShipper)
        {
            int dS = 1;
            dS = Convert.ToInt32(dShipper);
            var dRoute = (from r in db.Routes
                            where r.ShipperID == dS
                          orderby r.FromDetail 
                            select new
                            {
                                rID = r.ID,
                                rFrom = r.FromDetail,
                                rTO = r.ToDetail,
                                sID = r.ShipperID
                            }
                 ).ToList();
            List<Routes> data = new List<Routes>();
            foreach (var bt in dRoute)
            {
                Routes b = new Routes();
                b.Id = Convert.ToInt32(bt.rID);
                b.From = bt.rFrom;
                b.TO = bt.rTO;
                b.ShipperID = Convert.ToInt32(bt.sID);

                data.Add(b);
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult searchTruck(string dFrom)
        {
            int dS = 1;
            dS = Convert.ToInt32(dFrom);
            var dTruck = (from t in db.Trucks
                          where t.ID == dS
                          select new
                          {
                              Brand = t.Brand,
                              RegisterDate = t.RegisterDate,
                              TruckType = t.TruckType
                          }
                 ).ToList();
            List<TruckList> data = new List<TruckList>();
            foreach (var bt in dTruck)
            {
                TruckList b = new TruckList();
                b.Brand = bt.Brand;
                b.RegisterDate = Convert.ToDateTime(bt.RegisterDate).ToString("dd/MM/yyyy");
                b.TruckType = Convert.ToInt32(bt.TruckType);

                if (b.TruckType == 1)
                {
                    b.STType = "หัวลาก";
                }
                else if (b.TruckType == 2)
                {
                    b.STType = "หางลาก";
                }

                data.Add(b);
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult searchOldRepair(string dFrom)
        {
            int dS = 1;
            dS = Convert.ToInt32(dFrom);
            var OldRepair = (from r in db.Repairs
                             join g in db.Garages on r.GID equals g.ID
                             where r.TID == dS
                             orderby r.RepairNo descending
                             select new
                             {
                                 InformDate = r.InformDate,
                                 GID = r.GID,
                                 GName = g.Name,
                                 Mile = r.Mile,
                                 SumPrice = r.SumPrice

                             }
                 ).FirstOrDefault();

            List<OldRepair> data = new List<OldRepair>();

            OldRepair b = new OldRepair();

            if (OldRepair != null)
            {
                if (OldRepair.GID == null)
                {
                    b.GID = 0;
                }
                else
                {
                    b.GID = Convert.ToInt32(OldRepair.GID);
                }

                b.GName = OldRepair.GName;
                b.InformDate = Convert.ToDateTime(OldRepair.InformDate).ToString("dd/MM/yyyy");
                b.Mile = Convert.ToDecimal(OldRepair.Mile);
                b.SumPrice = Convert.ToDecimal(OldRepair.SumPrice);

            }

            data.Add(b);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Drivers()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D2";

            List<MDriver> model = new List<MDriver>();
           

            var DriverList = (from d in db.Drivers
                              orderby d.ID
                            select new
                            {
                                ID = d.ID,
                                EmpID = d.EmpID,
                                Title = d.Title,
                                FirstName = d.FirstName,
                                LastName = d.LastName,
                                NickName = d.NickName,
                                Mobile = d.Mobile,
                                DOB = d.DOB,
                                DriverLicence = d.DriverLicence,
                                Type = d.Type,
                                Status = d.Status
                            }
             ).ToList();

            foreach (var dl in DriverList)
            {
                MDriver a = new MDriver();
                a.ID = dl.ID;
                 a.EmpID = dl.EmpID;
                                a.Title = dl.Title;
                                a.FirstName = dl.FirstName;
                                a.LastName = dl.LastName;
                                a.NickName = dl.NickName;
                                a.Mobile = dl.Mobile;
                                a.DOB = Convert.ToDateTime(dl.DOB);
                                a.DriverLicence = dl.DriverLicence;
                                a.Type = dl.Type;
                                a.Status = dl.Status;
                model.Add(a);

            }

            return View(model);
        }

        public ActionResult DriverDetails()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D2";

            string EmpID = "";

            EmpID = Request.QueryString["EmpID"];

            List<MDriver> model = new List<MDriver>();


            var DriverList = (from d in db.Drivers
                              join t in db.Trucks on d.TruckID equals t.ID into Trucks1
                              from t1 in Trucks1.DefaultIfEmpty()
                              where d.EmpID == EmpID
                              orderby d.ID
                              select new
                              {
                                  ID = d.ID,
                                  EmpID = d.EmpID,
                                  Title = d.Title,
                                  FirstName = d.FirstName,
                                  LastName = d.LastName,
                                  NickName = d.NickName,
                                  Mobile = d.Mobile,
                                  EmergencyTelephone = d.EmergencyTelephone,
                                  EmergencyContact = d.EmergencyContact,
                                  DOB = d.DOB,
                                  DriverLicence = d.DriverLicence,
                                  Type = d.Type,
                                  DIssueDate = d.DIssueDate,
                                  DExpireDate = d.DExpireDate,
                                  Race = d.Race,
                                  Nationality = d.Nationality,
                                  Religion = d.Religion,
                                  IDCard = d.IDCard,
                                  IssuseDate = d.IssuseDate,
                                  ExpireDate = d.ExpireDate,
                                  Weight = d.Weight,
                                  Height = d.Height,
                                  MarriageStatusID = d.MarriageStatusID,
                                  MilitaryStatusID = d.MilitaryStatusID,
                                  Education = d.Education,
                                  Address = d.Address,
                                  Province = d.Province,
                                  ZipCode = d.ZipCode,
                                  FatherFullName = d.FatherFullName,
                                  DOBFather = d.DOBFather,
                                  MotherFullName = d.MotherFullName,
                                  DOBMother = d.DOBMother,
                                  WifeFullName = d.WifeFullName,
                                  Workplace = d.Workplace,
                                  WPosition = d.WPosition,
                                  Child = d.Child,
                                  ImgDriver = d.ImgDriver,
                                  FileDriver = d.FileDriver,
                                  FileIDCard = d.FileIDCard,
                                  FileRegistration = d.FileRegistration,
                                  TruckID = d.TruckID,
                                  Status = d.Status,
                                  InsertBy = d.InsertBy,
                                  InsertDate = d.InsertDate,
                                  EdittBy = d.EdittBy,
                                  EditDate = d.EditDate,
                                  DeleteBy = d.DeleteBy,
                                  DeleteDate = d.DeleteDate,
                                  TruckLicense = t1.License,
                                  FDetail = d.FDetail,
                                  MDetail = d.MDetail,
                                  Remark = d.Remark

                              }
             ).ToList();

            foreach (var dl in DriverList)
            {
                MDriver a = new MDriver();
                a.ID = dl.ID;
                a.EmpID = dl.EmpID;
                a.Title = dl.Title;
                a.FirstName = dl.FirstName;
                a.LastName = dl.LastName;
                a.NickName = dl.NickName;
                a.Mobile = dl.Mobile;
                a.DOB = Convert.ToDateTime(dl.DOB);
                a.DriverLicence = dl.DriverLicence;
                a.Type = dl.Type;
                a.DIssueDate = Convert.ToDateTime(dl.DIssueDate);
                                  a.DExpireDate = Convert.ToDateTime(dl.DExpireDate);
                                  a.Race = dl.Race;
                                  a.Nationality = dl.Nationality;
                                  a.Religion = dl.Religion;
                                  a.IDCard = dl.IDCard;
                                  a.IssuseDate = Convert.ToDateTime(dl.IssuseDate);
                                  a.ExpireDate = Convert.ToDateTime(dl.ExpireDate);
                                  a.Weight = Convert.ToDecimal(dl.Weight);
                                  a.Height = Convert.ToDecimal(dl.Height);
                                  a.MarriageStatusID = Convert.ToInt32(dl.MarriageStatusID);
                                  a.MilitaryStatusID = Convert.ToInt32(dl.MilitaryStatusID);
                                  a.Education = dl.Education;
                                  a.Address = dl.Address;
                                  a.Province = dl.Province;
                                  a.ZipCode = dl.ZipCode;
                                  a.FatherFullName = dl.FatherFullName;
                                  a.DOBFather = Convert.ToDateTime(dl.DOBFather);
                                  a.MotherFullName = dl.MotherFullName;
                                  a.DOBMother = Convert.ToDateTime(dl.DOBMother);
                                  a.WifeFullName = dl.WifeFullName;
                                  a.Workplace = dl.Workplace;
                                  a.WPosition = dl.WPosition;
                                  a.Child = Convert.ToInt32(dl.Child);
                                  a.ImgDriver = dl.ImgDriver;
                                  a.FileDriver = dl.FileDriver;
                                  a.FileIDCard = dl.FileIDCard;
                                  a.FileRegistration = dl.FileRegistration;
                                  a.TruckID = Convert.ToInt32(dl.TruckID);
                                  a.Status = dl.Status;
                                  a.InsertBy = Convert.ToInt32(dl.InsertBy);
                                  a.InsertDate = Convert.ToDateTime(dl.InsertDate);
                                  a.EdittBy = Convert.ToInt32(dl.EdittBy);
                                  a.EditDate = Convert.ToDateTime(dl.EditDate);
                                  a.DeleteBy = Convert.ToInt32(dl.DeleteBy);
                                  a.DeleteDate = Convert.ToDateTime(dl.DeleteDate);
                                  a.TruckLicense = dl.TruckLicense;
                                  a.FDetail = dl.FDetail;
                                  a.MDetail = dl.MDetail;
                                  a.EmergencyContact = dl.EmergencyContact;
                                  a.EmergencyTelephone = dl.EmergencyTelephone;
                                  a.Remark = dl.Remark;
                model.Add(a);

            }

            return View(model);
        }
        public ActionResult DriverNew()
        {
            Session["FMenu"] = "D";
            Session["Menu"] = "D2";

            var dTruck = (from t in db.Trucks
                          join d in db.Drivers on t.ID equals d.TruckID into Dr
                          from dd in Dr.DefaultIfEmpty()
                          //join d in db.Drivers on  t.ID equals d.TruckID into Trucks1
                          //from t1 in Trucks1.DefaultIfEmpty()
                          where t.TruckType == 1
                          select new
                          {
                              TID = t.ID,
                              TLicense = t.License,
                              Brand = t.Brand,
                              DFirstName = dd.FirstName
                          }
               ).ToList();

            List<TruckList> model = new List<TruckList>();
         

            foreach (var tr in dTruck)
            {
                TruckList t = new TruckList();
                t.TID = tr.TID;
                t.License = tr.TLicense;
                t.Brand = tr.Brand;
                t.DFirstName = tr.DFirstName;
                model.Add(t);

            }
            return View(model);


        }

        public ActionResult DriverNewCommit(FormCollection form, HttpPostedFileBase ImgDriver, HttpPostedFileBase FileDriver, HttpPostedFileBase FileIDCard, HttpPostedFileBase FileRegistration)
        {

            var DNo = (from d in db.Drivers
                         orderby d.EmpID descending
                         select d.EmpID
                  ).FirstOrDefault();

            string EmpID = "";

            if (DNo == null)
            {
                EmpID = "0000001";
            }
            else
            {
              
                EmpID =(Convert.ToInt32(DNo) + 1).ToString("0000000");
            }

            string DIssueDate = Request.Form["DIssueDate"];
            DateTime DDIssueDate = DateTime.Now.Date;
            if (DIssueDate == null || DIssueDate == "")
            {
                DDIssueDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = DIssueDate.Substring(0, 2);
                string d2 = DIssueDate.Substring(3, 2);
                string d3 = DIssueDate.Substring(6, 4);
                string d4 = d2 + "/" + d1 + "/" + d3;
                DDIssueDate = DateTime.Parse(d4);  
            }

            string DExpireDate = Request.Form["DExpireDate"];
            DateTime DDExpireDate = DateTime.Now.Date;
            if (DExpireDate == null || DExpireDate == "")
            {
                DDExpireDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = DExpireDate.Substring(0, 2);
                string d2 = DExpireDate.Substring(3, 2);
                string d3 = DExpireDate.Substring(6, 4);
                string d4 = d2 + "/" + d1 + "/" + d3;
                DDExpireDate = DateTime.Parse(d4);
            }

            string DOB = Request.Form["DOB"];
            DateTime DDOB = DateTime.Now.Date;
            if (DOB == null || DOB == "")
            {
                DDOB = DateTime.Now.Date;
            }
            else
            {
                string d1 = DOB.Substring(0, 2);
                string d2 = DOB.Substring(3, 2);
                string d3 = DOB.Substring(6, 4);
                string d4 = d2 + "/" + d1 + "/" + d3;
                DDOB = DateTime.Parse(d4);
            }

            string IssuseDate = Request.Form["IssuseDate"];
            DateTime DIssuseDate = DateTime.Now.Date;
            if (IssuseDate == null || IssuseDate == "")
            {
                DIssuseDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = IssuseDate.Substring(0, 2);
                string d2 = IssuseDate.Substring(3, 2);
                string d3 = IssuseDate.Substring(6, 4);
                string d4 = d2 + "/" + d1 + "/" + d3;
                DIssuseDate = DateTime.Parse(d4);
            }

            string ExpireDate = Request.Form["ExpireDate"];
            DateTime IDExpireDate = DateTime.Now.Date;
            if (ExpireDate == null || ExpireDate == "")
            {
                IDExpireDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = ExpireDate.Substring(0, 2);
                string d2 = ExpireDate.Substring(3, 2);
                string d3 = ExpireDate.Substring(6, 4);
                string d4 = d2 + "/" + d1 + "/" + d3;
                IDExpireDate = DateTime.Parse(d4);
            }

            decimal Weight = 0;
            if (Request.Form["Weight"] == null || Request.Form["Weight"] == "")
            {
               Weight = 0;

            }
            else
            {
                Weight = Convert.ToDecimal(Request.Form["Weight"]);
            }

            decimal Height = 0;
            if (Request.Form["Height"] == null || Request.Form["Height"] == "")
            {
                Height = 0;

            }
            else
            {
                Height = Convert.ToDecimal(Request.Form["Height"]);
            }

            int Child = 0;
            if (Request.Form["Child"] == null || Request.Form["Child"] == "")
            {
                Child = 0;

            }
            else
            {
                Child = Convert.ToInt32(Request.Form["Child"]);
            }

            string SImgDriver = "";
            if (ImgDriver == null)
            {
                SImgDriver = null;
            }
            else
            {
                SImgDriver = ImgDriver.FileName;
                var fileName = Path.GetFileName(ImgDriver.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Driver"), fileName);
                ImgDriver.SaveAs(path);
            }

            string SFileDriver = "";
            if (FileDriver == null)
            {
                SFileDriver = null;
            }
            else
            {
                SFileDriver = FileDriver.FileName;
                var fileName = Path.GetFileName(FileDriver.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Driver"), fileName);
                FileDriver.SaveAs(path);
            }

            string SFileIDCard = "";
            if (FileIDCard == null)
            {
                SFileIDCard = null;
            }
            else
            {
                SFileIDCard = FileIDCard.FileName;
                var fileName = Path.GetFileName(FileIDCard.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Driver"), fileName);
                FileIDCard.SaveAs(path);
            }

            string SFileRegistration = "";
            if (FileRegistration == null)
            {
                SFileRegistration = null;
            }
            else
            {
                SFileRegistration = FileRegistration.FileName;
                var fileName = Path.GetFileName(FileRegistration.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Driver"), fileName);
                FileRegistration.SaveAs(path);
            }

            Driver AddDriver = new Driver();
            AddDriver.Address = Request.Form["Address"];
            AddDriver.Child = Child;
            AddDriver.DExpireDate = DDExpireDate;
            AddDriver.DIssueDate = DDIssueDate;
            AddDriver.DOB = DDOB;
            AddDriver.DriverLicence = Request.Form["DriverLicence"];
            AddDriver.Education = Request.Form["Education"];
            AddDriver.EmergencyTelephone = Request.Form["EmergencyTelephone"];
            AddDriver.EmpID = EmpID;
            AddDriver.ExpireDate = IDExpireDate;
            AddDriver.FatherFullName = Request.Form["FatherFullName"];
            AddDriver.FDetail = Request.Form["FDetail"];
            AddDriver.FileDriver = SFileDriver;
            AddDriver.FileIDCard = SFileIDCard;
            AddDriver.FileRegistration = SFileRegistration;
            AddDriver.FirstName = Request.Form["FirstName"];
            AddDriver.Height = Height;
            AddDriver.IDCard = Request.Form["IDCard"];
            AddDriver.ImgDriver = SImgDriver;
            AddDriver.InsertBy = 1;
            AddDriver.InsertDate = DateTime.Now.Date;
            AddDriver.IssuseDate = DIssuseDate;
            AddDriver.LastName = Request.Form["LastName"];
            AddDriver.MarriageStatusID = Convert.ToInt32(Request.Form["MarriageStatusID"]);
            AddDriver.MDetail = Request.Form["MDetail"];
            AddDriver.MilitaryStatusID = Convert.ToInt32(Request.Form["MilitaryStatusID"]);
            AddDriver.Mobile = Request.Form["Mobile"];
            AddDriver.MotherFullName = Request.Form["MotherFullName"];
            AddDriver.Nationality = Request.Form["Nationality"];
            AddDriver.NickName = Request.Form["NickName"];
         //   AddDriver.Province = Request.Form["Province"];
            AddDriver.Race = Request.Form["Race"];
            AddDriver.Religion = Request.Form["Religion"];
            AddDriver.Status = "y";
            AddDriver.Title = Request.Form["Title"];
            AddDriver.TruckID = Convert.ToInt32(Request.Form["Truck"]);
            AddDriver.Type = Request.Form["Type"];
            AddDriver.Weight = Weight;
            AddDriver.WifeFullName = Request.Form["WifeFullName"];
            AddDriver.Workplace = Request.Form["Workplace"];
            AddDriver.WPosition = Request.Form["WPosition"];
         ///   AddDriver.ZipCode = Request.Form["ZipCode"];

            db.Drivers.Add(AddDriver);
            db.SaveChanges();

            return RedirectToAction("DriverDetails", "TMS", new { EmpID = EmpID });
        }
    }

}