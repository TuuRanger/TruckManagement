using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CKLINE.Models;
using System.ComponentModel;
using CrystalDecisions.Shared;

namespace CKLINE.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        //การขนส่ง

        #region กาขนส่งประจำวัน
        public ActionResult TransportingList()
        {
            Session["FMenu"] = "R1M";
            Session["Menu"] = "R1T1";

            var model = new TransportingModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult TransportingList(TransportingModel model)
        {
            var infos = new List<Transporting>();
            infos.Add(new Models.Transporting() { });
            infos.Add(new Models.Transporting() { });

            model.TransportItems = infos;

            return View("TransportingList", model);
        }


        /// <summary>
        /// รายงานการขนส่งประจำวัน
        /// </summary>
        /// <returns></returns>
        public ActionResult Transporting()
        {
            List<Transporting> list = new List<Models.Transporting>();
            //list.Add(new Models.Transporting() { BeginDate = DateTime.Now, Destination = "บ่อเต็ง/ลาว", Distance = 2350, Driver = "นายสมหวัง บรรจง", Head = "62-7340กท", Mobile = "087-079-0879", NumberOfDriver = 1, Source = "กม19", Tail = "78-2431กท", TankNO = "PXT03315004-9", WorkTime = 45 });

            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/Transporting.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");

        }
        public void ExportTransportingToExcel()
        {
            var data = new[]{
                               new{ Name="Ram", Email="ram@techbrij.com", Phone="111-222-3333" },
                               new{ Name="Shyam", Email="shyam@techbrij.com", Phone="159-222-1596" },
                               new{ Name="Mohan", Email="mohan@techbrij.com", Phone="456-222-4569" },
                               new{ Name="Sohan", Email="sohan@techbrij.com", Phone="789-456-3333" },
                               new{ Name="Karan", Email="karan@techbrij.com", Phone="111-222-1234" },
                               new{ Name="Brij", Email="brij@techbrij.com", Phone="111-222-3333" }
                      };

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Transporting.xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            WriteTsv(data, Response.Output);
            Response.End();
        }

        #endregion

        #region การขนส่งประจำเดือน
        public ActionResult TransportationCostsList()
        {
            return View();
        }

        public ActionResult MonthlyTransporting()
        {
            List<MonthlyTransporting> list = new List<MonthlyTransporting>();
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/MonthlyTransporting.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult MonthlyTransportingList()
        {
            Session["FMenu"] = "R1M";
            Session["Menu"] = "R1T2";
            return View();
        }
        #endregion

        #region รายได้/ค่าใช้จ่ายแปรผันประจำเดือน
        public ActionResult VariableProfitCost()
        {
            Session["FMenu"] = "R1M";
            Session["Menu"] = "R1T3";
            return View();
        }

        public ActionResult ViewVariableProfitCost()
        {
            List<VariableProfitCost> list = new List<VariableProfitCost>();
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/VariableProfitCost.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            rptH.SetParameterValue("Date", "มิถุนายน 2559");
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public void ExportVariableCostToExcel()
        {
            var data = new[]{
                               new{ Date="", Head="", Tail="",Type="",TranCost="",GasCost="",DriverCost="",PassCost="",ProfitLoss="" },
                               new{ Date="", Head="", Tail="",Type="",TranCost="",GasCost="",DriverCost="",PassCost="",ProfitLoss="" }
                      };

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=VariableProfitCost.xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            WriteTsv(data, Response.Output);
            Response.End();
        }

        #endregion


        //รถบรรทุก
        #region การเติมน้ำมัน
        /// <summary>
        /// รายงานการเติมแก๊ส
        /// </summary>
        /// <returns></returns>
        public ActionResult GasRefill()
        {
            List<GasRefill> list = new List<GasRefill>();
            //list.Add(new CKLINE.Models.GasRefill() { Bill = 1000, CarRegis = "61-9747 กท.", Date = DateTime.Now, EndMile = 141105, StartMile = 138826, Job = "ลานTCDกม.19-บ่อเตน-บ.แพรกซ์แอร์บางพลี-ลานTCDกม.19", Lite = 704, Total = 2278 });
            //list.Add(new CKLINE.Models.GasRefill() { Bill = 1000, CarRegis = "61-9747 กท.", Date = DateTime.Now, EndMile = 141105, StartMile = 138826, Job = "ลานTCDกม.19-บ่อเตน-บ.แพรกซ์แอร์บางพลี-ลานTCDกม.19", Lite = 704, Total = 2278 });
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/GasRefill.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult GasRefillList()
        {

            Session["FMenu"] = "R2M";
            Session["Menu"] = "R2T1";

            return View();
        }
        #endregion

        #region การเปลี่ยนยาง
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

            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/TiresChanging.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult TiresChangingList()
        {
            Session["FMenu"] = "R2M";
            Session["Menu"] = "R2T2";
            return View();
        }
        #endregion

        #region การซ่อมบำรุง
        /// <summary>
        /// รายงานการซ่อมบำรุง
        /// </summary>
        /// <returns></returns>
        public ActionResult Maintenance()
        {
            List<CKLINE.Models.Maintenance> list = new List<CKLINE.Models.Maintenance>();
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "บท-8340", Job = "พวงมาลัยไม่ตรง,ยางหลังปลิ", Garage = "สุภณัฐ" });
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "50-2162", Job = "เวลาขับรถขึ้นเขา ความร้อนจะขึ้นสูง ผิดปกติ", Garage = "ธนาศักดิ์" });
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("~/Views/Report/Maintenance.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");

        }


        public ActionResult MaintenanceList()
        {
            Session["FMenu"] = "R2M";
            Session["Menu"] = "R2T3";
            return View();
        }
        #endregion

        #region อุบัติเหตุประจำเดือน
        public ActionResult MonthlyAccidentList()
        {
            Session["FMenu"] = "R2M";
            Session["Menu"] = "R2T4";
            return View();
        }
        /// <summary>
        /// รายงานสรุปการเกิดอุบัติเหตุรถขนส่งประจำเดือน
        /// </summary>
        /// <returns></returns>
        public ActionResult MonthlyAccident()
        {
            List<MonthlyAccident> list = new List<MonthlyAccident>();
            ReportClass rptH = new ReportClass(); //C:\inetpub\wwwroot\TMS\Views\Report
            rptH.FileName = Server.MapPath("~/Views/Report/MonthlyAccident.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }
        #endregion

        #region ตารางเดินรถ
        public ActionResult TransportQueue()
        {
            Session["FMenu"] = "R2M";
            Session["Menu"] = "R2T5";
            return View();
        }

        public ActionResult ViewTransportQueue()
        {
            List<Models.TransportQueue> list = new List<Models.TransportQueue>();
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/TransportQueue.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public void ExportTransportQueueToExcel()
        {
            var data = new[]{
                               new{ Date="", Head="", Tail="",Type="",TranCost="",GasCost="",DriverCost="",PassCost="",ProfitLoss="" },
                               new{ Date="", Head="", Tail="",Type="",TranCost="",GasCost="",DriverCost="",PassCost="",ProfitLoss="" }
                      };

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=TransportQueue.xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            WriteTsv(data, Response.Output);
            Response.End();
        }

        #endregion

        #region งานลากตู้คอนเทรนเนอร์
        public ActionResult Container()
        {
            Session["FMenu"] = "R2M";
            Session["Menu"] = "R2T6";
            return View();
        }

        public ActionResult ViewContainer()
        {
            List<Models.Container> list = new List<Models.Container>();
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/Container.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public void ExportContainerToExcel()
        {
            var data = new[]{
                               new{ Date="", Head="", Tail="",Type="",TranCost="",GasCost="",DriverCost="",PassCost="",ProfitLoss="" },
                               new{ Date="", Head="", Tail="",Type="",TranCost="",GasCost="",DriverCost="",PassCost="",ProfitLoss="" }
                      };

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Container.xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            WriteTsv(data, Response.Output);
            Response.End();
        }


        #endregion

        //Gasstation
        public ActionResult GPSStationReport()
        {
            List<CKLINE.Models.Maintenance> list = new List<CKLINE.Models.Maintenance>();
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "บท-8340", Job = "พวงมาลัยไม่ตรง,ยางหลังปลิ", Garage = "สุภณัฐ" });
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "50-2162", Job = "เวลาขับรถขึ้นเขา ความร้อนจะขึ้นสูง ผิดปกติ", Garage = "ธนาศักดิ์" });
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("~/Views/Report/GPSStation.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            rptH.SetParameterValue("BeginDate", "มิถุนายน 2559");
            rptH.SetParameterValue("EndDate", "กรกฏาคม 2559");
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");

        }
        public ActionResult GPSStation()
        {
            Session["FMenu"] = "R3M";
            Session["Menu"] = "R3T1";
            return View();
        }

        //GPS
        public ActionResult GPSBehaviorReport()
        {
            List<CKLINE.Models.Maintenance> list = new List<CKLINE.Models.Maintenance>();
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "บท-8340", Job = "พวงมาลัยไม่ตรง,ยางหลังปลิ", Garage = "สุภณัฐ" });
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "50-2162", Job = "เวลาขับรถขึ้นเขา ความร้อนจะขึ้นสูง ผิดปกติ", Garage = "ธนาศักดิ์" });
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("~/Views/Report/GPSBehavior.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            rptH.SetParameterValue("BeginDate", "มิถุนายน 2559");
            rptH.SetParameterValue("EndDate", "กรกฏาคม 2559");
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");

        }
        public ActionResult GPSBehavior()
        {
            Session["FMenu"] = "R3M";
            Session["Menu"] = "R3T2";
            return View();
        }


        //พนักงานขับรถ

        #region พนักงานขับรถ - ข้อมุลส่วนตัว
        public ActionResult DriverProfileReport()
        {
            List<CKLINE.Models.Maintenance> list = new List<CKLINE.Models.Maintenance>();
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "บท-8340", Job = "พวงมาลัยไม่ตรง,ยางหลังปลิ", Garage = "สุภณัฐ" });
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "50-2162", Job = "เวลาขับรถขึ้นเขา ความร้อนจะขึ้นสูง ผิดปกติ", Garage = "ธนาศักดิ์" });
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("~/Views/Report/Driver.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            //rptH.SetParameterValue("BeginDate", "มิถุนายน 2559");
            //rptH.SetParameterValue("EndDate", "กรกฏาคม 2559");
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");

        }
        public ActionResult DriverProfile()
        {
            Session["FMenu"] = "R4M";
            Session["Menu"] = "R4T1";
            return View();
        }

        public ActionResult DriverHistoryReport(string reportName)
        {
            reportName = ViewBag.PageTitle;
            List<CKLINE.Models.Maintenance> list = new List<CKLINE.Models.Maintenance>();
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "บท-8340", Job = "พวงมาลัยไม่ตรง,ยางหลังปลิ", Garage = "สุภณัฐ" });
            //list.Add(new Maintenance() { BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CarRegis = "50-2162", Job = "เวลาขับรถขึ้นเขา ความร้อนจะขึ้นสูง ผิดปกติ", Garage = "ธนาศักดิ์" });
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("~/Views/Report/DriverHistory.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            //rptH.SetParameterValue("BeginDate", "มิถุนายน 2559");
            //rptH.SetParameterValue("EndDate", "กรกฏาคม 2559");
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");

        }
        public ActionResult DriverHistory(int reportType)
        {

           

            if (reportType == 1)
            {
                Session["FMenu"] = "R4M";
                Session["Menu"] = "R4T2";

                ViewData["ReprotName"] = "การฝึกอบรม";

            }
            else if (reportType == 2)
            {
                Session["FMenu"] = "R4M";
                Session["Menu"] = "R4T3";

                ViewData["ReprotName"] = "การทำความผิด";
            }
            else
            {
                ViewData["ReprotName"] = "Unkonw";
            }

            return View();
        }

        #endregion

        #region การฝึกอบรม

        #endregion

        #region การทำความผิด

        #endregion

        #region เบี้ยพิเศษประจำเดือน

        #endregion

        #region ค่าเที่ยว
        /// <summary>
        /// รายงานสรุปการจ่ายค่าเที่ยวพนักงานขับรถประจำงวด
        /// </summary>
        /// <returns></returns>
        public ActionResult CarDriversPayPeriod()
        {
            List<CarDriversPayPeriod> list = new List<CarDriversPayPeriod>();
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/CarDriversPayPeriod.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult CarDriversPayPeriodList()
        {
            Session["FMenu"] = "R4M";
            Session["Menu"] = "R4T6";
            return View();
        }
        #endregion

        #region เวลาเข้าออกพนักงาน

        public ActionResult TimeAttendanceReport()
        {
            Session["FMenu"] = "R4M";
            Session["Menu"] = "R4T4";

            List<TimeAttendance> list = new List<TimeAttendance>();
            ReportClass rptH = new ReportClass();
            rptH.FileName = Server.MapPath("/Views/Report/TimeAttendance.rpt");
            rptH.Load();
            rptH.SetDataSource(list);
            rptH.SetParameterValue("BeginDate", "มิถุนายน 2559");
            rptH.SetParameterValue("EndDate", "กรกฏาคม 2559");
            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult TimeAttendance()
        {
            return View();
        }
        #endregion

        public void WriteTsv<T>(IEnumerable<T> data, TextWriter output)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.DisplayName); // header
                output.Write("\t");
            }
            output.WriteLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Write(prop.Converter.ConvertToString(
                         prop.GetValue(item)));
                    output.Write("\t");
                }
                output.WriteLine();
            }
        }



        ///// <summary>
        ///// รายการกำไรขาดทุน
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult ProfitAndLoss()
        //{
        //    List<ProfitAndLoss> list = new List<ProfitAndLoss>();
        //    list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 10000, Income = 200000 });
        //    list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 15000, Income = 300000 });
        //    list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 17000, Income = 200000 });
        //    list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 20000, Income = 100000 });
        //    list.Add(new Models.ProfitAndLoss() { BeginDate = DateTime.Now, EndDate = DateTime.Now, Expensess = 25000, Income = 450000 });

        //    ReportClass rptH = new ReportClass();
        //    rptH.FileName = Server.MapPath("/Views/Report/ProfitAndLoss.rpt");
        //    rptH.Load();
        //    rptH.SetDataSource(list);
        //    Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    return File(stream, "application/pdf");

        //}



        ///// <summary>
        ///// รายงานต้นทุนการขนส่ง
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult TransportationCosts()
        //{
        //    List<TransportationCosts> list = new List<TransportationCosts>();
        //    list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าเชื้อเพลิง", Costs = 48000 });
        //    list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าซ่อมบำรุง", Costs = 48000 });
        //    list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าอะไหล่", Costs = 48000 });
        //    list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าเสือมราคา", Costs = 48000 });
        //    list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าประกัน", Costs = 48000 });
        //    list.Add(new Models.TransportationCosts() { Date = DateTime.Now, Item = "ค่าเปลี่ยนยาง", Costs = 48000 });

        //    ReportClass rptH = new ReportClass();
        //    rptH.FileName = Server.MapPath("/Views/Report/TransportationCosts.rpt");
        //    rptH.Load();
        //    rptH.SetDataSource(list);
        //    Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    return File(stream, "application/pdf");
        //}





        ///// <summary>
        ///// รายงานสรุปการขนส่งประจำวัน 
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult DailyTransport()
        //{
        //    return View();
        //}


    }

    public class TransportingModel
    {
        public string Keyword { get; set; }
        public string Type { get; set; }
        public string DateRange { get; set; }
        public List<Transporting> TransportItems { get; set; }
    }


}