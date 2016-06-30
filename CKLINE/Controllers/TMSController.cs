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

        public ActionResult Drivers()
        {
            return View();
        }

        public ActionResult DriverDetails()
        {
            return View();
        }

        public ActionResult rTest()
        {
            return View();
        }
        public ActionResult NewOrder()
        {
            var dCustomer = (from c in db.Customers
                             select new
                             {
                                 cID = c.ID,
                                 cName = c.Name
                             }
                  ).ToList();

            var dRoute = (from r in db.Routes
                          select new
                          {
                              rID = r.ID,
                              rFrom = r.FromDetail,
                              rTO = r.ToDetail
                          }
                  ).ToList();

            List<ModelList> model = new List<ModelList>();
            List<Customers> lCustomer = new List<Customers>();
            List<Routes> lRoute = new List<Routes>();


            foreach (var bc in dCustomer)
            {
                Customers a = new Customers();
                a.Id = Convert.ToInt32(bc.cID);
                a.Name = bc.cName.ToString();
                lCustomer.Add(a);
            }

            foreach (var br in dRoute)
            {
                Routes r = new Routes();
                r.Id = Convert.ToInt32(br.rID);
                r.From = br.rFrom.ToString();
                r.TO = br.rTO.ToString();
                lRoute.Add(r);
            }

            ModelList ML = new ModelList();
            ML.sCustomer = lCustomer.ToList();
            ML.sRoute = lRoute.ToList();

            model.Add(ML);


            return View(model);
          //  return View();
        }
        public ActionResult JobCommit(FormCollection form)
        {
         //   return RedirectToAction("~/TMS/Jobs?J=2&OID="+ form["OrderID"] +"&OT="+ form["OT"]+"&ODID="+form["ODID"]);
            int DriverID = 0;
            int TID = 0;
            int HID = 0;
            int ODID = 0;
            int SID = 0;
            int SType = 0;

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
            if (form["ODID"] != "")
            {
                ODID = Convert.ToInt32(form["ODID"]);
            }
            if (form["SID"] != "")
            {
                SID = Convert.ToInt32(form["SID"]);
            }
            if (form["SType"] != "")
            {
                SType = Convert.ToInt32(form["SType"]);
            }

            string OrderID = form["OrderID"];
            Job AddJob = new Job();
            AddJob.ContainerNo = form["ContainerNo"];
            AddJob.TruckID = TID;
            AddJob.DriverID = DriverID;
            AddJob.HitchID = HID;
            AddJob.JDate = DateTime.Now.Date;
            AddJob.ODID = ODID;
            AddJob.OrderID = OrderID;
            AddJob.Remark = form["Remark"];
            AddJob.SID = SID;
            AddJob.Status = 1;
            AddJob.SType = SType;

            db.Jobs.Add(AddJob);
            db.SaveChanges();

            Order UpdateO = new Order();

            var Order = (from o in db.Orders
                         where o.OrderID == OrderID
                               select o).SingleOrDefault();

            Order.Status = 2;
            db.SaveChanges();

            OrderDetail UpdateOD = new OrderDetail();

            var OrderDetail = (from od in db.OrderDetails
                               where od.ID == ODID
                               select od).Single();

            OrderDetail.Status = 2;
            db.SaveChanges();


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
         

            return RedirectToAction("Jobs", "TMS", new { J = 1,OID = form["OrderID"],OT=form["OT"]});
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

            dOrder.RoutID = Convert.ToInt32(Request.Form["Route"]);
            dOrder.RoutID2 = Convert.ToInt32(Request.Form["Route2"]);
            dOrder.RoutID3 = Convert.ToInt32(Request.Form["Route3"]);
            dOrder.RoutID4 = Convert.ToInt32(Request.Form["Route4"]);

           

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
                dOrder.IEPackDate = null;
                dOrder.IEReturnDate = null;
                dOrder.IEETDDate = null;
                dOrder.IEETADate = null;
                dOrder.IECLosingDate = null;
              //  dOrder.IEMap = null;

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

            dOrder.IEClosingTime = Request.Form["IEClosingTime"];
            dOrder.IEQuantity = Request.Form["IEQuantity"];

            string nNum = "";
            string nType = "";
            string tNum = "";
            string tType = "";
            string pNum = "";
            string pnNum = "";

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
            AddOrder.IELocationReceive = dOrder.IELocationReceive;
            AddOrder.IEShipping = dOrder.IEShipping;
            AddOrder.IETelephone = dOrder.IETelephone;
            AddOrder.IEBill = dOrder.IEBill;
            AddOrder.IEPortPrice = dOrder.IEPortPrice;
            AddOrder.IELanPrice = dOrder.IELanPrice;
            AddOrder.IELiftPrice = dOrder.IELiftPrice;
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

            if (dOrder.OrderType == 1 || dOrder.OrderType == 3)
            {
                for (var i = 1; i <= dOrder.NumberOrder; i++)
                {
                    ContainerList cl = new ContainerList();

                    nNum = "nNum" + i;
                    nType = "nType" + i;
                    pNum = "pNum" + i;
                    pnNum = "pnNum" + i;

                    cl.Container = Request.Form[nNum];
                    cl.Position = Request.Form[pNum];
                    cl.PackNo = Request.Form[pnNum];
                    cl.ContainerType = Request.Form[nType];

                    OrderDetail AddOrderDetail = new OrderDetail();
                    AddOrderDetail.OrderID = OID;
                    AddOrderDetail.ContainerNo = cl.Container;
                    AddOrderDetail.Position = cl.Position;
                    AddOrderDetail.PackNo = cl.PackNo;
                    AddOrderDetail.ContainerType = cl.ContainerType;
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

                        tNum = "tNum1" + i;
                      //  tType = "tType1" + i;


                        cl.Container = Request.Form[tNum];
                        cl.ContainerType = dOrder.ContainerType1;


                        OrderDetail AddOrderDetail = new OrderDetail();
                        AddOrderDetail.OrderID = OID;
                        AddOrderDetail.ContainerNo = cl.Container;
                        AddOrderDetail.ContainerType = cl.ContainerType;
                        AddOrderDetail.TPackDate = dOrder.TPackDate1;
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

                        tNum = "tNum2" + i;
                     //   tType = "tType2" + i;


                        cl.Container = Request.Form[tNum];
                        cl.ContainerType = dOrder.ContainerType2;


                        OrderDetail AddOrderDetail = new OrderDetail();
                        AddOrderDetail.OrderID = OID;
                        AddOrderDetail.ContainerNo = cl.Container;
                        AddOrderDetail.ContainerType = cl.ContainerType;
                        AddOrderDetail.TPackDate = dOrder.TPackDate2;
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

                        tNum = "tNum3" + i;
                      //  tType = "tType3" + i;


                        cl.Container = Request.Form[tNum];
                        cl.ContainerType = dOrder.ContainerType3;


                        OrderDetail AddOrderDetail = new OrderDetail();
                        AddOrderDetail.OrderID = OID;
                        AddOrderDetail.ContainerNo = cl.Container;
                        AddOrderDetail.ContainerType = cl.ContainerType;
                        AddOrderDetail.TPackDate = dOrder.TPackDate3;
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

                        tNum = "tNum1" + i;
                       // tType = "tType1" + i;


                        cl.Container = Request.Form[tNum];
                        cl.ContainerType = dOrder.ContainerType4;


                        OrderDetail AddOrderDetail = new OrderDetail();
                        AddOrderDetail.OrderID = OID;
                        AddOrderDetail.ContainerNo = cl.Container;
                        AddOrderDetail.ContainerType = cl.ContainerType;
                        AddOrderDetail.TPackDate = dOrder.TPackDate4;
                        AddOrderDetail.Status = 1;

                        db.OrderDetails.Add(AddOrderDetail);
                        db.SaveChanges();

                        ContainerList.Add(cl);
                    }

                }
            }
           

            Session["OrderID"] = OID;
            return RedirectToAction("OrderInfo", "TMS");

          
        }
        public ActionResult OrderInfo()
        {
            string OID = "PA16060001";

            if (Request.QueryString["OID"] != null)
            {
                OID = Request.QueryString["OID"];
            }
            else
            {
                if (Session["OrderID"] != null)
                {
                    OID = Session["OrderID"].ToString();
                }
                else
                {
                    OID = "";
                    return RedirectToAction("Index", "TMS");

                }
               
            }

          
            List<OrderInfo> model = new List<OrderInfo>();
            List<OrderDetailInfo> modelD = new List<OrderDetailInfo>();

          
            if (OID.Substring(0,2) == "PA" || OID.Substring(0,2) == "GL")
            {
                var sOrderInfo = (from o in db.Orders
                                  join c in db.Customers on o.CustomerID equals c.ID
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


                    a.IEFeeder = ol.IEFeeder;
                    a.IELanPrice = Convert.ToDecimal(ol.IELanPrice);
                    a.IELiftPrice = Convert.ToDecimal(ol.IELiftPrice);
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
                                  join r in db.Routes on o.RoutID equals r.ID
                                  join r2 in db.Routes on o.RoutID2 equals r2.ID
                                  join r3 in db.Routes on o.RoutID3 equals r3.ID
                                  join r4 in db.Routes on o.RoutID4 equals r4.ID
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
                                      RToProvince = r.ToProvince,

                                      RFromDetail2 = r2.FromDetail,
                                      RFromProvince2 = r2.FromProvince,
                                      RToDetail2 = r2.ToDetail,
                                      RToProvince2 = r2.ToProvince,

                                      RFromDetail3 = r3.FromDetail,
                                      RFromProvince3 = r3.FromProvince,
                                      RToDetail3 = r3.ToDetail,
                                      RToProvince3 = r3.ToProvince,

                                      RFromDetail4 = r4.FromDetail,
                                      RFromProvince4 = r4.FromProvince,
                                      RToDetail4 = r4.ToDetail,
                                      RToProvince4 = r4.ToProvince
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
                                      Status = od.Status
                                  }
).ToList();

              foreach (var odl in sOrderDetailInfo)
            {
                OrderDetailInfo b = new OrderDetailInfo();

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

                b.Status = Convert.ToInt32(odl.Status);
                modelD.Add(b);

            }
        
              return View(Tuple.Create(model, modelD)); 
        }
        public ActionResult OrderList()
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
        public ActionResult Jobs()
        {
            List<JobList> model = new List<JobList>();
            List<JOrderList> JOrderList = new List<JOrderList>();

            string J = Request.QueryString["J"];
            string OID = Request.QueryString["OID"];
            string ODID = Request.QueryString["ODID"];
            string OT = Request.QueryString["OT"];
            string C = Request.QueryString["C"];
            string T = Request.QueryString["T"];
            string H = Request.QueryString["H"];
            string D = Request.QueryString["D"];
            string TD = Request.QueryString["TD"];
            string HD = Request.QueryString["HD"];
            string S = Request.QueryString["S"];
            string SC = Request.QueryString["SC"];

            var jOrder = (from o in db.Orders
                              join c in db.Customers on o.CustomerID equals c.ID
                              join r in db.Routes on o.RoutID equals r.ID
                              //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                              //  join d in db.LMS_Driver on b.DriverID equals d.ID
                              where o.Status == 1 || o.Status == 2
                              orderby o.ReceiveDate,o.DliveryDate,o.OrderID descending
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
             ).ToList();

            foreach (var ol in jOrder)
            {
                JOrderList jol = new JOrderList();

                jol.OrderID = ol.OrderID;
                jol.BookingNo = ol.BookingNo;
                jol.CustomerID = Convert.ToInt32(ol.CustomerID);
                jol.OrderType = Convert.ToInt32(ol.OrderType);
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

              JOrderList.Add(jol);
                
            }

            List<JOrderDList> JOrderDList = new List<JOrderDList>();
                var jOrderD = (from od in db.OrderDetails               
                               where od.OrderID == OID
                               select new
                               {
                                   ODID = od.ID,
                                   ContainerNo = od.ContainerNo,
                                   ContainerType = od.ContainerType,
                                   TPackDate = od.TPackDate,
                                   Position = od.Position,
                                   PackNo = od.PackNo,
                                   Status = od.Status
                               }
                ).ToList();

                foreach (var odl in jOrderD)
                {
                    JOrderDList jd = new JOrderDList();

                    jd.ID = odl.ODID;
                    jd.ContainerNo = odl.ContainerNo;
                    jd.ContainerType = odl.ContainerType;
                    jd.PackNo = odl.PackNo;
                    jd.Position = odl.Position;
                    jd.TPackDate = Convert.ToDateTime(odl.TPackDate);
                    jd.Status = Convert.ToInt32(odl.Status);

                    JOrderDList.Add(jd);

                }

                List<JTruckList> JTruckList = new List<JTruckList>();
                var jTruck = (from t in db.Trucks
                              join d in db.Drivers on t.ID equals d.TruckID
                               where t.TruckType == "1"
                               select new
                               {
                                   TID = t.ID,
                                   HID = t.HitchID,
                                   DID = d.ID,
                                   License = t.License,
                                   HitchLicense = t.HitchLicense,
                                   DTitle =d.Title,
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
                            join o in db.Orders on j.OrderID equals o.OrderID
                            where j.TruckID == nT && j.HitchID == nH && j.DriverID == nD && j.Status != 4
                          
                            //where
                            select new
                            {
                                JID = j.ID,
                                OrderID  = j.OrderID,
                                ODID = j.ODID,
                                ContainerNo = j.ContainerNo,
                                Status = j.Status,
                                ReceiveDate = o.ReceiveDate,
                                DliveryDate = o.DliveryDate,
                                PPackDate = o.PPackDate,
                                IEPackDate = o.IEPackDate,
                                IEReceiveDate = o.IEReceiveDate,
                                IEReturnDate  = o.IEReturnDate

                            }
                ).ToList();

                foreach (var jl in JJob)
                {
                    JJobList jd = new JJobList();

                    jd.ContainerNo = jl.ContainerNo;
                    jd.DliveryDate = Convert.ToDateTime(jl.DliveryDate).Date;
                    jd.PPackDate = Convert.ToDateTime(jl.PPackDate).Date;
                    jd.IEPackDate = Convert.ToDateTime(jl.IEPackDate).Date;
                    jd.IEReceiveDate = Convert.ToDateTime(jl.IEReceiveDate).Date;
                    jd.IEReturnDate = Convert.ToDateTime(jl.IEReceiveDate).Date;
                    jd.JID = jl.JID;
                    jd.ODID = Convert.ToInt32(jl.ODID);
                    jd.OrderID = jl.OrderID;
                    jd.ReceiveDate = Convert.ToDateTime(jl.ReceiveDate).Date;
                    jd.Status = Convert.ToInt32(jl.Status);

                    JJobList.Add(jd);

                }
            }
            else if (C == "2")
            {
                var JJob = (from j in db.Jobs
                            join o in db.Orders on j.OrderID equals o.OrderID
                            where j.OrderID == OID && j.SID == nS

                            //where
                            select new
                            {
                                JID = j.ID,
                                OrderID = j.OrderID,
                                ODID = j.ODID,
                                ContainerNo = j.ContainerNo,
                                Status = j.Status,
                                ReceiveDate = o.ReceiveDate,
                                DliveryDate = o.DliveryDate
                            }
                ).ToList();

                foreach (var jl in JJob)
                {
                    JJobList jd = new JJobList();

                    jd.ContainerNo = jl.ContainerNo;
                    jd.DliveryDate = Convert.ToDateTime(jl.DliveryDate).Date;
                    jd.JID = jl.JID;
                    jd.ODID = Convert.ToInt32(jl.ODID);
                    jd.OrderID = jl.OrderID;
                    jd.ReceiveDate = Convert.ToDateTime(jl.ReceiveDate).Date;
                    jd.Status = Convert.ToInt32(jl.Status);

                    JJobList.Add(jd);

                }
            }

            int nOD = 0;

            if (ODID != "")
            {
                nOD = Convert.ToInt32(ODID);
            }

            List<JOrderAdd> JOrderAdd = new List<JOrderAdd>();
            var JOA = (from o in db.Orders
                       join od in db.OrderDetails on o.OrderID equals od.OrderID
                       join c in db.Customers on o.CustomerID equals c.ID
                       join r in db.Routes on o.RoutID equals r.ID
                        where o.OrderID == OID && od.ID == nOD

                        //where
                        select new
                        {
   
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
                            rToDetail = r.ToDetail,
                            rFromDetail = r.FromDetail
                        }
                ).ToList();

            foreach (var joal in JOA)
            {
                JOrderAdd joad = new JOrderAdd();

                joad.CustomerID = Convert.ToInt32(joal.CustomerID);
                joad.DliveryDate = Convert.ToDateTime(joal.DliveryDate).Date;
                joad.TPackDate = Convert.ToDateTime(joal.TPackDate).Date;
                joad.PPackDate = Convert.ToDateTime(joal.PPackDate).Date;
                joad.IEPackDate = Convert.ToDateTime(joal.IEPackDate).Date;
                joad.IEReceiveDate = Convert.ToDateTime(joal.IEReceiveDate).Date;
                joad.IEReturnDate = Convert.ToDateTime(joal.IEReturnDate).Date;
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate).Date;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.ContainerNo = joal.ContainerNo;
                joad.ContainerType = joal.ContainerType;
                joad.ODID = joal.ODID;
                joad.PackNo = joal.PackNo;
                joad.Position = joal.Position;
                joad.ToDetail = joal.rToDetail;
                joad.FromDetail = joal.rFromDetail;
                joad.CustomerName = joal.CustomerName;
              
                JOrderAdd.Add(joad);

            }

          
            JobList JL = new JobList();
            JL.JOrder = JOrderList.ToList();
            JL.JOrderD = JOrderDList.ToList();
            JL.JTruck = JTruckList.ToList();
            JL.JSub = JSubList.ToList();
            JL.JJob = JJobList.ToList();
            JL.JOrderA = JOrderAdd.ToList();
          
            model.Add(JL);
            return View(model);
        }
        public ActionResult OpenJob()
        {
            List<OpenJob> model = new List<OpenJob>();
            List<OpenJobT> modelT = new List<OpenJobT>();

            var sJobT = (from j in db.Jobs
                        join o in db.Orders on j.OrderID equals o.OrderID
                        join t in db.Trucks on j.TruckID equals t.ID
                        join d in db.Drivers on j.DriverID equals d.ID
                        join r in db.Routes on o.RoutID equals r.ID
                         where j.Status == 1
                     //   join s in db.SubContacts on j.SID equals s.ID
                           
                              orderby j.ID descending
                              select new
                              {
                                  JID = j.ID,
                                  OrderID = j.OrderID,
                                  ContainerNo = j.ContainerNo,
                                  FromDetail = r.FromDetail,
                                  ToDetail = r.ToDetail,
                                  ReceiveDate = o.ReceiveDate,
                                  DliveryDate = o.DliveryDate,
                                  License = t.License,
                                  HitchLicense = t.HitchLicense,
                                  DTitle = d.Title,
                                  DFirstName = d.FirstName,
                                  DLastName = d.LastName,
                            //      SName = s.Name,
                            //      Stype = j.SType,
                                  JStatus = j.Status

                              }
             ).ToList();

            foreach (var ol in sJobT)
            {
                OpenJobT a = new OpenJobT();

                a.ContainerNo = ol.ContainerNo;
                a.DFirstName = ol.DFirstName;
                a.DLastName = ol.DLastName;

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }

               
                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }

                a.DTitle = ol.DTitle;
                a.FromDetail = ol.FromDetail;
                a.HitchLicense = ol.HitchLicense;
                a.JID = ol.JID;
                a.JStatus = Convert.ToInt32(ol.JStatus);
                a.License = ol.License;
                a.OrderID = ol.OrderID;
                a.ToDetail = ol.ToDetail;
             //   a.SName = ol.SName;
             //   a.SType = Convert.ToInt32(ol.Stype);

                modelT.Add(a);

            }
            List<OpenJobS> modelS = new List<OpenJobS>();


            var sJobS = (from j in db.Jobs
                        join o in db.Orders on j.OrderID equals o.OrderID
                     //   join t in db.Trucks on j.TruckID equals t.ID
                       // join d in db.Drivers on j.DriverID equals d.ID
                        join r in db.Routes on o.RoutID equals r.ID
                          join s in db.SubContacts on j.SID equals s.ID
                          where j.Status == 1
                        orderby j.ID descending
                        select new
                        {
                            JID = j.ID,
                            OrderID = j.OrderID,
                            ContainerNo = j.ContainerNo,
                            FromDetail = r.FromDetail,
                            ToDetail = r.ToDetail,
                            ReceiveDate = o.ReceiveDate,
                            DliveryDate = o.DliveryDate,
                       //     License = t.License,
                         //   HitchLicense = t.HitchLicense,
                           // DTitle = d.Title,
                          //  DFirstName = d.FirstName,
                           // DLastName = d.LastName,
                                  SName = s.Name,
                                  Stype = j.SType,
                            JStatus = j.Status

                        }
             ).ToList();

            foreach (var ol in sJobS)
            {
                OpenJobS a = new OpenJobS();

                a.ContainerNo = ol.ContainerNo;
             //   a.DFirstName = ol.DFirstName;
            //    a.DLastName = ol.DLastName;

                if (ol.DliveryDate == null)
                {
                    a.DliveryDate = DateTime.Now.Date;
                }
                else
                {
                    a.DliveryDate = Convert.ToDateTime(ol.DliveryDate);
                }


                if (ol.ReceiveDate == null)
                {
                    a.ReceiveDate = DateTime.Now.Date;
                }
                else
                {
                    a.ReceiveDate = Convert.ToDateTime(ol.ReceiveDate);
                }

           //     a.DTitle = ol.DTitle;
                a.FromDetail = ol.FromDetail;
            //    a.HitchLicense = ol.HitchLicense;
                a.JID = ol.JID;
                a.JStatus = Convert.ToInt32(ol.JStatus);
            //    a.License = ol.License;
                a.OrderID = ol.OrderID;
                a.ToDetail = ol.ToDetail;
                a.SName = ol.SName;
              a.SType = Convert.ToInt32(ol.Stype);

                modelS.Add(a);

            }

            OpenJob JL = new OpenJob();
            JL.sOpenJobT = modelT.ToList();
            JL.sOpenJobS = modelS.ToList();
           

            model.Add(JL);
            return View(model); 
         
        }
        public ActionResult OpenJobDetail()
        {
            return View();
        }
        public ActionResult CloseJob()
        {
            return View();
        }
        public ActionResult CloseJobDetail()
        {
            return View();
        }
        public ActionResult TrieSwitch()
        {
            return View();
        }
        public ActionResult TrieSwitchDetail()
        {
            return View();
        }
        public ActionResult Repair()
        {
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
                r.Detail = rl.Detail;
                r.Status = Convert.ToInt32(rl.Status);
             
                model.Add(r);
            }

            return View(model);
        }
        public ActionResult RepairDetail()
        {
            var dTruck = (from t in db.Trucks
                        
                             select new
                             {
                                 TID = t.ID,
                                 TLicense = t.License
                             }
                 ).ToList();

            var dDriver = (from d in db.Drivers

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
                    AddRD.RepairNo = OID;
                    AddRD.Detail = form[MyDetail];
                    AddRD.Num = Convert.ToDecimal(form[MyNum]);
                    AddRD.Price = Convert.ToDecimal(form[MyPrice]);
                    AddRD.SumPrice = Convert.ToDecimal(form[MySumPrice]);

                    db.RepairDetails.Add(AddRD);
                    db.SaveChanges();

                }
            }


            Repair AddRepair = new Repair();
            AddRepair.RepairNo = OID;
            AddRepair.TID = TID;
            AddRepair.DriverID = DriverID;
            AddRepair.Mile = Mile;
            AddRepair.InformDate = dInformDate;
            AddRepair.InformTime = form["InformTime"];
            AddRepair.SendDate =  dSendDate;
            AddRepair.SendTime = form["SendTime"];
            AddRepair.FinishDate = dFinishDate;
            AddRepair.FinishTime = form["FinishTime"];
            AddRepair.Detail = form["Detail"];
            AddRepair.optEdit = optEdit;
            AddRepair.optRepair = optRepair;
            AddRepair.Remark = form["Remark"];
            AddRepair.SumNum = SumNum;
            AddRepair.SumPrice = SumPrice;
            AddRepair.GID = GID;
            AddRepair.Operator = form["Operator"];
            AddRepair.Status = Status;
            AddRepair.SaveDate = DateTime.Now.Date;

            db.Repairs.Add(AddRepair);
            db.SaveChanges();

            Session["RepairNo"] = OID;
            return RedirectToAction("RepairInfo", "TMS", new { RepairNo = OID });
        }
        public ActionResult RepairInfo()
        {

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
        public ActionResult Car()
        {
            return View();
        }
        public ActionResult CarDetail()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult CustomerDetail()
        {
            return View();
        }
        public ActionResult Sub()
        {
            return View();
        }
        public ActionResult SubDetail()
        {
            return View();
        }
        public ActionResult Trie()
        {
            return View();
        }
        public ActionResult TrieDetail()
        {
            return View();
        }
        public ActionResult Route()
        {
            return View();
        }
        public ActionResult RouteDetail()
        {
            return View();
        }
        public ActionResult NewRoute()
        {
            return View();
        }
        public ActionResult Gas()
        {
            return View();
        }
        public ActionResult GasDetail()
        {
            return View();
        }
        public ActionResult Garage()
        {
            return View();
        }
        public ActionResult GarageDetail()
        {
            return View();
        }
        public ActionResult WithDraw()
        {
            return View();
        }
        public ActionResult WithDrawDetail()
        {
            return View();
        }
        public ActionResult Stock()
        {
            return View();
        }
        public ActionResult StockDetail()
        {
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

        public ActionResult JobCancel()
        {
            int DriverID = 0;
            int TID = 0;
            int HID = 0;
            int ODID = 0;
            int SID = 0;
            int SType = 0;

            if (Request.QueryString["D"] != "")
            {
                DriverID = Convert.ToInt32(Request.QueryString["D"]);
            }
            if (Request.QueryString["T"] != "")
            {
                TID = Convert.ToInt32(Request.QueryString["T"]);
            }
            if (Request.QueryString["H"] != "")
            {
                HID = Convert.ToInt32(Request.QueryString["H"]);
            }
            if (Request.QueryString["ODID"] != "")
            {
                ODID = Convert.ToInt32(Request.QueryString["ODID"]);
            }
            if (Request.QueryString["S"] != "")
            {
                SID = Convert.ToInt32(Request.QueryString["S"]);
            }


            string OrderID = Request.QueryString["OID"];
            Job AddJob = new Job();
           
            Order UpdateO = new Order();

            var sOrderD = (from o in db.OrderDetails
                         where o.OrderID == OrderID && o.Status == 2
                         select o).Count();

            if (sOrderD <=1)
            {
                var Order = (from o in db.Orders
                             where o.OrderID == OrderID
                             select o).SingleOrDefault();

                Order.Status = 1;
                db.SaveChanges();
            }
         

            OrderDetail UpdateOD = new OrderDetail();

            var OrderDetail = (from od in db.OrderDetails
                               where od.ID == ODID
                               select od).SingleOrDefault();

            OrderDetail.Status = 1;
            db.SaveChanges();

            Job JobC = new Job();

            var JJob = (from j in db.Jobs
                        where j.TruckID == TID && j.HitchID == HID && j.DriverID == DriverID && j.Status != 4

                        //where
                        select j).Count();

            var Job = (from od in db.Jobs
                               where od.ODID == ODID && od.Status != 4
                       select od).SingleOrDefault();

            Job.Status = 4;
            db.SaveChanges();

          
               
            if (JJob <=1)
            {
                if (TID != 0)
                {
                    Truck UpdateT = new Truck();

                    var Truck = (from t in db.Trucks
                                 where t.ID == TID
                                 select t).SingleOrDefault();

                    Truck.Status = 1;
                    db.SaveChanges();

                    var Hitch = (from t in db.Trucks
                                 where t.ID == HID
                                 select t).SingleOrDefault();

                    Hitch.Status = 1;
                    db.SaveChanges();
                }
              
          
            }
               

            return RedirectToAction("Jobs", "TMS", new { J = 1, OID = Request.QueryString["OID"], OT = Request.QueryString["OT"] });
        }
    }
}