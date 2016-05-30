using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class Maintenance
    {
        private List<string> _spareParts = new List<string>();
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public TimeSpan TimeTotal { get { return EndDate - BeginDate; } }

        /// <summary>
        /// อาการเสีย
        /// </summary>
        public string Job { get; set; }
        
        /// <summary>
        /// ทะเบียนรถ
        /// </summary>
        public string CarRegis { get; set; }

        /// <summary>
        /// ค่าซ่อม
        /// </summary>
        public Decimal Cost { get; set; }
        /// <summary>
        /// อู่่ซ่อม
        /// </summary>
        public string Garage { get; set; }
       
    }

    
}