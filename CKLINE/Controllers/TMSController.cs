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
        public ActionResult OrderCommit(FormCollection form)
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
            //    string d4 = d1 + "/" + d2 + "/" + d3;
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
               // string d4 = d1 + "/" + d2 + "/" + d3;
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
                //string d4 = d1 + "/" + d2 + "/" + d3;
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
                //string d4 = d1 + "/" + d2 + "/" + d3;
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
                //string d4 = d1 + "/" + d2 + "/" + d3;
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
                //string d4 = d1 + "/" + d2 + "/" + d3;
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
                //string d4 = d1 + "/" + d2 + "/" + d3;
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
                //string d4 = d1 + "/" + d2 + "/" + d3;
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
                //string d4 = d1 + "/" + d2 + "/" + d3;
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
            dOrder.IEMap = Request.Form["IEMap"];
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
            if (Session["OrderID"] != null)
            {
                OID = Session["OrderID"].ToString();
            }
            else
            {
                if (Request.QueryString["OID"] != null)
                {
                    OID = Request.QueryString["OID"];
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
            return View();
        }
        public ActionResult OpenJob()
        {
            return View();
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
    }
}