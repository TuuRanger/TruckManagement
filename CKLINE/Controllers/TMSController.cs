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
                                  TPackDate = o.TPackDate,
                                  IEType = o.IEType,
                                  IEShipper = o.IEShipper,
                                  IEAgent = o.IEAgent,
                                  IELoading = o.IELoading,
                                  IEShipping = o.IEShipping,
                                  IETelephone = o.IETelephone,
                                  IELocationPack = o.IELocationPack,
                                  IELocationReceive = o.IELocationReceive,
                                  IEMap = o.IEMap,
                                  IELiner = o.IELiner,
                                  IEReceiveDate = o.IEReceiveDate,
                                  IEPackDate = o.IEPackDate,
                                  IEPacklTime = o.IEPacklTime,
                                  IEFeeder = o.IEFeeder,
                                  IEMother = o.IEMother,
                                  IECYDate = o.IECYDate,
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
                                  IEAgent2 = o.IEAgent2,
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
                a.IEAgent2 = ol.IEAgent2;
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

                if (ol.IECYDate == null)
                {
                    a.IECYDate = DateTime.Now.Date;
                }
                else
                {
                    a.IECYDate = Convert.ToDateTime(ol.IECYDate);
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
                a.IELiner = ol.IELiner;
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

                if (ol.TPackDate == null)
                {
                    a.TPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate = Convert.ToDateTime(ol.TPackDate);
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

            string TPackDate = Request.Form["TPackDate"];

            string IEReceiveDate = Request.Form["IEReceiveDate"];
            string IEPackDate = Request.Form["IEPackDate"];
            string IECYDate = Request.Form["IECYDate"];
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

            if (TPackDate == null || TPackDate == "")
            {
                dOrder.TPackDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = TPackDate.Substring(0, 2);
                string d2 = TPackDate.Substring(3, 2);
                string d3 = TPackDate.Substring(6, 4);
              //  string d4 = d1 + "/" + d2 + "/" + d3;
                    string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.TPackDate = DateTime.Parse(d4);
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

            if (IECYDate == null || IECYDate == "")
            {
                dOrder.IECYDate = DateTime.Now.Date;
            }
            else
            {
                string d1 = IECYDate.Substring(0, 2);
                string d2 = IECYDate.Substring(3, 2);
                string d3 = IECYDate.Substring(6, 4);
           //     string d4 = d1 + "/" + d2 + "/" + d3;
                    string d4 = d2 + "/" + d1 + "/" + d3;
                dOrder.IECYDate = DateTime.Parse(d4);
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
                dOrder.TPackDate = null;

                dOrder.IEReceiveDate = null;
                dOrder.IEPackDate = null;
                dOrder.IECYDate = null;
                dOrder.IEETDDate = null;
                dOrder.IEETADate = null;
                dOrder.IECLosingDate = null;
              //  dOrder.IEMap = null;

            }
            else if (dOrder.OrderType == 2)
            {
                dOrder.NumberOrder = Convert.ToInt32(Request.Form["Num2"]);
                nOID = "CK";
                dOrder.PPackDate = null;

                dOrder.IEReceiveDate = null;
                dOrder.IEPackDate = null;
                dOrder.IECYDate = null;
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

                dOrder.TPackDate = null;
              
            
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
            dOrder.IELiner = Request.Form["IELiner"];
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
            dOrder.IEAgent2 = Request.Form["IEAgent2"];

            string nNum = "";
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
            AddOrder.NumberOrder = dOrder.NumberOrder;
            AddOrder.Remark = dOrder.Remark;
            AddOrder.PPackDate = dOrder.PPackDate;
            AddOrder.TPackDate = dOrder.TPackDate;
            AddOrder.IEType = dOrder.IEType;
            AddOrder.IEShipper = dOrder.IEShipper;
            AddOrder.IEAgent = dOrder.IEAgent;
            AddOrder.IELoading = dOrder.IELoading;
            AddOrder.IEShipping = dOrder.IEShipping;
            AddOrder.IETelephone = dOrder.IETelephone;
            AddOrder.IELocationPack = dOrder.IELocationPack;
            AddOrder.IELocationReceive = dOrder.IELocationReceive;
            AddOrder.IEMap = dOrder.IEMap;
            AddOrder.IELiner = dOrder.IELiner;
            AddOrder.IEReceiveDate = dOrder.IEReceiveDate;
            AddOrder.IEPackDate = dOrder.IEPackDate;
            AddOrder.IEPacklTime = dOrder.IEPacklTime;
            AddOrder.IEFeeder = dOrder.IEFeeder;
            AddOrder.IEMother = dOrder.IEMother;
            AddOrder.IECYDate = dOrder.IECYDate;
            AddOrder.IEETDDate = dOrder.IEETDDate;
            AddOrder.IEContact = dOrder.IEContact;
            AddOrder.IEETADate = dOrder.IEETADate;
            AddOrder.IEAT = dOrder.IEAT;
            AddOrder.IETel = dOrder.IETel;
            AddOrder.IEBill = dOrder.IEBill;
            AddOrder.IEPortPrice = dOrder.IEPortPrice;
            AddOrder.IELanPrice = dOrder.IELanPrice;
            AddOrder.IELiftPrice = dOrder.IELiftPrice;
            AddOrder.IECLosingDate = dOrder.IECLosingDate;
            AddOrder.IEClosingTime = dOrder.IEClosingTime;
            AddOrder.IEAgent2 = dOrder.IEAgent2;
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


            for (var i = 1; i <= dOrder.NumberOrder; i++)
            {
                ContainerList cl = new ContainerList();

                 nNum = "nNum" + i;
                 pNum = "pNum" + i;
                 pnNum = "pnNum" + i;

                 cl.Container = Request.Form[nNum];
                 cl.Position = Request.Form[pNum];
                 cl.PackNo = Request.Form[pnNum];

                 OrderDetail AddOrderDetail = new OrderDetail();
                 AddOrderDetail.OrderID = OID;
                 AddOrderDetail.ContainerNo = cl.Container;
                 AddOrderDetail.Position = cl.Position;
                 AddOrderDetail.PackNo = cl.PackNo;
                 AddOrderDetail.Status = 1;

                 db.OrderDetails.Add(AddOrderDetail);
                 db.SaveChanges();

                 ContainerList.Add(cl);
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

                var sOrderInfo = (from o in db.Orders
                                   join c in db.Customers on o.CustomerID equals c.ID
                                   join r in db.Routes on o.RoutID equals r.ID
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
           NumberOrder = o.NumberOrder,
            Remark = o.Remark,
           PPackDate = o.PPackDate,
           TPackDate = o.TPackDate,
           IEType = o.IEType,
          IEShipper = o.IEShipper,
           IEAgent = o.IEAgent,
           IELoading = o.IELoading,
           IEShipping = o.IEShipping,
           IETelephone = o.IETelephone,
           IELocationPack = o.IELocationPack,
        IELocationReceive = o.IELocationReceive,
          IEMap = o.IEMap,
           IELiner = o.IELiner,
           IEReceiveDate = o.IEReceiveDate,
           IEPackDate = o.IEPackDate,
       IEPacklTime = o.IEPacklTime,
            IEFeeder = o.IEFeeder,
          IEMother = o.IEMother,
           IECYDate = o.IECYDate,
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
            IEAgent2 = o.IEAgent2,
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
                a.IEAgent2 = ol.IEAgent2;
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

                if (ol.IECYDate == null)
                {
                    a.IECYDate = DateTime.Now.Date;
                }
                else
                {
                    a.IECYDate = Convert.ToDateTime(ol.IECYDate);
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
                a.IELiner = ol.IELiner;
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

                  if (ol.TPackDate == null)
                  {
                      a.TPackDate = DateTime.Now.Date;
                  }
                  else
                  {
                      a.TPackDate = Convert.ToDateTime(ol.TPackDate);
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
                var sOrderDetailInfo = (from od in db.OrderDetails
                                  //join c in db.Customers on o.CustomerID equals c.ID
                                  //join r in db.Routes on o.RoutID equals r.ID
                                  //join a in db.LMS_SubAgent on b.AgentID equals a.ID
                                  //  join d in db.LMS_Driver on b.DriverID equals d.ID
                                  where od.OrderID == OID
                                  select new
                                  {
                                      ContainerNo = od.ContainerNo,
                                      Position = od.Position,
                                      PackNo = od.PackNo,
                                      Status = od.Status
                                  }
).ToList();

              foreach (var odl in sOrderDetailInfo)
            {
                OrderDetailInfo b = new OrderDetailInfo();

                b.ContainerNo = odl.ContainerNo;
                b.PackNo = odl.PackNo;
                b.Position = odl.Position;
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
                                  TPackDate = o.TPackDate,
                                  IEType = o.IEType,
                                  IEShipper = o.IEShipper,
                                  IEAgent = o.IEAgent,
                                  IELoading = o.IELoading,
                                  IEShipping = o.IEShipping,
                                  IETelephone = o.IETelephone,
                                  IELocationPack = o.IELocationPack,
                                  IELocationReceive = o.IELocationReceive,
                                  IEMap = o.IEMap,
                                  IELiner = o.IELiner,
                                  IEReceiveDate = o.IEReceiveDate,
                                  IEPackDate = o.IEPackDate,
                                  IEPacklTime = o.IEPacklTime,
                                  IEFeeder = o.IEFeeder,
                                  IEMother = o.IEMother,
                                  IECYDate = o.IECYDate,
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
                                  IEAgent2 = o.IEAgent2,
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
                a.IEAgent2 = ol.IEAgent2;
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

                if (ol.IECYDate == null)
                {
                    a.IECYDate = DateTime.Now.Date;
                }
                else
                {
                    a.IECYDate = Convert.ToDateTime(ol.IECYDate);
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
                a.IELiner = ol.IELiner;
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

                if (ol.TPackDate == null)
                {
                    a.TPackDate = DateTime.Now.Date;
                }
                else
                {
                    a.TPackDate = Convert.ToDateTime(ol.TPackDate);
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
                                  TPackDate = o.TPackDate,
                                  IEType = o.IEType,
                                  IEShipper = o.IEShipper,
                                  IEAgent = o.IEAgent,
                                  IELoading = o.IELoading,
                                  IEShipping = o.IEShipping,
                                  IETelephone = o.IETelephone,
                                  IELocationPack = o.IELocationPack,
                                  IELocationReceive = o.IELocationReceive,
                                  IEMap = o.IEMap,
                                  IELiner = o.IELiner,
                                  IEReceiveDate = o.IEReceiveDate,
                                  IEPackDate = o.IEPackDate,
                                  IEPacklTime = o.IEPacklTime,
                                  IEFeeder = o.IEFeeder,
                                  IEMother = o.IEMother,
                                  IECYDate = o.IECYDate,
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
                                  IEAgent2 = o.IEAgent2,
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
                    jd.PackNo = odl.PackNo;
                    jd.Position = odl.Position;
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
                joad.OrderID = joal.OrderID;
                joad.OrderType = Convert.ToInt32(joal.OrderType);
                joad.ReceiveDate = Convert.ToDateTime(joal.ReceiveDate).Date;
                joad.RouteID = Convert.ToInt32(joal.RouteID);
                joad.ContainerNo = joal.ContainerNo;
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
            return View();
        }
        public ActionResult RepairDetail()
        {
            return View();
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