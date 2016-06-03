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
            return View();
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
            //var dCustomer = (from c in db.Customers
            //             select new
            //             {
            //                 cID = c.ID,
            //                 cName = c.Name
            //             }
            //      ).ToList();

            //var dRoute = (from r in db.Routes
            //                 select new
            //                 {
            //                     rID = r.ID,
            //                     rFrom = r.From,
            //                     rTO = r.TO
            //                 }
            //      ).ToList();

            //List<ModelList> model = new List<ModelList>();
            //List<Customers> lCustomer = new List<Customers>();
            //List<Routes> lRoute = new List<Routes>();
            
      
            //foreach (var bc in dCustomer)
            //{
            //    Customers a = new Customers();
            //    a.Id = Convert.ToInt32(bc.cID);
            //    a.Name = bc.cName.ToString();
            //    lCustomer.Add(a);
            //}

            //foreach (var br in dRoute)
            //{
            //    Routes r = new Routes();
            //    r.Id = Convert.ToInt32(br.rID);
            //    r.From = br.rFrom.ToString();
            //    r.TO = br.rTO.ToString();
            //    lRoute.Add(r);
            //}

            //ModelList ML = new ModelList();
            //ML.sCustomer = lCustomer.ToList();
            //ML.sRoute = lRoute.ToList();

            //model.Add(ML);
          

            //return View(model);
            return View();
        }
        public ActionResult OrderList()
        {
            return View();
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
    }
}