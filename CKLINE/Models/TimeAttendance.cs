using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class TimeAttendance
    {
        public DateTime Date { get; set; }
        public string MachineNumber { get; set; }
        public string EmpID { get; set; }
        public string EmpFullName { get; set; }
        public TimeSpan In { get; set; }
        public TimeSpan Out { get; set; }
        public TimeSpan Total { get; set; }

        public string Department { get; set; }
    }
}