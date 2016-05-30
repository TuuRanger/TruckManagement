//using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CKLINE.Models;

namespace CKLINE.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TransportingList()
        {
            return View();
        }


        /// <summary>
        /// รายงานการขนส่งประจำวัน
        /// </summary>
        /// <returns></returns>
        public ActionResult Transporting()
        {
            List<Transporting> list = new List<Models.Transporting>();
            //list.Add(new Models.Transporting() { BeginDate = DateTime.Now, Destination = "บ่อเต็ง/ลาว", Distance = 2350, Driver = "นายสมหวัง บรรจง", Head = "62-7340กท", Mobile = "087-079-0879", NumberOfDriver = 1, Source = "กม19", Tail = "78-2431กท", TankNO = "PXT03315004-9", WorkTime = 45 });

          //  ReportClass rptH = new ReportClass();
            //rptH.FileName = Server.MapPath("/Views/Report/Transporting.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }

        /// <summary>
        /// รายงานการเติมแก๊ส
        /// </summary>
        /// <returns></returns>
        public ActionResult GasRefill()
        {
            List<GasRefill> list = new List<GasRefill>();
            //list.Add(new CKLINE.Models.GasRefill() { Bill = 1000, CarRegis = "61-9747 กท.", Date = DateTime.Now, EndMile = 141105, StartMile = 138826, Job = "ลานTCDกม.19-บ่อเตน-บ.แพรกซ์แอร์บางพลี-ลานTCDกม.19", Lite = 704, Total = 2278 });
            //list.Add(new CKLINE.Models.GasRefill() { Bill = 1000, CarRegis = "61-9747 กท.", Date = DateTime.Now, EndMile = 141105, StartMile = 138826, Job = "ลานTCDกม.19-บ่อเตน-บ.แพรกซ์แอร์บางพลี-ลานTCDกม.19", Lite = 704, Total = 2278 });
            //ReportClass rptH = new ReportClass();
            //rptH.FileName = Server.MapPath("/Views/Report/GasRefill.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }

        public ActionResult GasRefillList()
        {
            return View();
        }

        /// <summary>
        /// รายงานการซ่อมบำรุง
        /// </summary>
        /// <returns></returns>
        public ActionResult Maintenance()
        {
            List<CKLINE.Models.Maintenance> list = new List<CKLINE.Models.Maintenance>();
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "บท-8340", Job = "พวงมาลัยไม่ตรง,ยางหลังปลิ", Garage = "สุภณัฐ" });
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "50-2162", Job = "เวลาขับรถขึ้นเขา ความร้อนจะขึ้นสูง ผิดปกติ", Garage = "ธนาศักดิ์" });
            //ReportClass rptH = new ReportClass();
            //rptH.FileName = Server.MapPath("/Views/Report/Maintenance.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }


        public ActionResult MaintenanceList()
        {
            return View();
        }
        /// <summary>
        /// รายการกำไรขาดทุน
        /// </summary>
        /// <returns></returns>
        public ActionResult ProfitAndLoss()
        {
            List<ProfitAndLoss> list = new List<ProfitAndLoss>();
            list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 10000, Income = 200000 });
            list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 15000, Income = 300000 });
            list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 17000, Income = 200000 });
            list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 20000, Income = 100000 });
            list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 25000, Income = 450000 });

            //ReportClass rptH = new ReportClass();
            //rptH.FileName = Server.MapPath("/Views/Report/ProfitAndLoss.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }

        /// <summary>
        /// รายงานการเปลี่ยนยาง
        /// </summary>
        /// <returns></returns>
        public ActionResult TiresChanging()
        {
            List<TiresChanging> list = new List<TiresChanging>();
            list.Add(new TiresChanging() { CarRegis = "61-9747 กท", Date = DateTime.Now, Mile = 36520, Position = 2, PutOnBrand = "Bridgestone", PutOnSerial = "B4L2L5559", PutOnSize = "11R22.5/16PR157", TakeOffBrand = "Bridgestone", TakeOffSerial = "L01589349", TakeOffSize = "11R22.5/16PR157" });
            list.Add(new TiresChanging() { CarRegis = "81 - 6040", Date = DateTime.Now, Mile = 267017, Position = 5, PutOnBrand = "Bridgestone", PutOnSerial = "B4L2L5559", PutOnSize = "11R22.5/16PR157", TakeOffBrand = "Bridgestone", TakeOffSerial = "L01589349", TakeOffSize = "11R22.5/16PR157" });
            list.Add(new TiresChanging() { CarRegis = "50-3719", Date = DateTime.Now, Mile = 267017, Position = 10, PutOnBrand = "Bridgestone", PutOnSerial = "B4L2L5559", PutOnSize = "11R22.5/16PR157", TakeOffBrand = "Bridgestone", TakeOffSerial = "L01589349", TakeOffSize = "11R22.5/16PR157" });

            //ReportClass rptH = new ReportClass();
            //rptH.FileName = Server.MapPath("/Views/Report/TiresChanging.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }

        public ActionResult TiresChangingList()
        {
            return View();
        }

        /// <summary>
        /// รายงานต้นทุนการขนส่ง
        /// </summary>
        /// <returns></returns>
        public ActionResult TransportationCosts()
        {
            List<TransportationCosts> list = new List<TransportationCosts>();
            list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าเชื้อเพลิง", Costs = 48000 });
            list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าซ่อมบำรุง", Costs = 48000 });
            list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าอะไหล่", Costs = 48000 });
            list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าเสือมราคา", Costs = 48000 });
            list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าประกัน", Costs = 48000 });
            list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าเปลี่ยนยาง", Costs = 48000 });

            //ReportClass rptH = new ReportClass();
            //rptH.FileName = Server.MapPath("/Views/Report/TransportationCosts.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }


        public ActionResult TransportationCostsList()
        {
            return View();
        }

        public ActionResult MonthlyAccidentList()
        {
            return View();
        }
        /// <summary>
        /// รายงานสรุปการเกิดอุบัติเหตุรถขนส่งประจำเดือน
        /// </summary>
        /// <returns></returns>
        public ActionResult MonthlyAccident()
        {
            List<MonthlyAccident> list = new List<MonthlyAccident>();
            //ReportClass rptH = new ReportClass(); //C:\inetpub\wwwroot\TMS\Views\Report
            //rptH.FileName = Server.MapPath("/Views/Report/MonthlyAccident.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }


        /// <summary>
        /// รายงานสรุปการขนส่งประจำวัน 
        /// </summary>
        /// <returns></returns>
        public ActionResult DailyTransport()
        {
            return View();
        }

        /// <summary>
        /// รายงานสรุปการจ่ายค่าเที่ยวพนักงานขับรถประจำงวด
        /// </summary>
        /// <returns></returns>
        public ActionResult CarDriversPayPeriod()
        {
            List<CarDriversPayPeriod> list = new List<CarDriversPayPeriod>();
            //ReportClass rptH = new ReportClass();
            //rptH.FileName = Server.MapPath("/Views/Report/CarDriversPayPeriod.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }

        public ActionResult CarDriversPayPeriodList()
        {
            return View();
        }


        public ActionResult MonthlyTransporting()
        {
            List<MonthlyTransporting> list = new List<MonthlyTransporting>();
            //ReportClass rptH = new ReportClass();
            //rptH.FileName = Server.MapPath("/Views/Report/MonthlyTransporting.rpt");
            //rptH.Load();
            //rptH.SetDataSource(list);
            //Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //return File(stream, "application/pdf");
            return View();
        }

        public ActionResult MonthlyTransportingList()
        {
            return View();
        }
    }
}