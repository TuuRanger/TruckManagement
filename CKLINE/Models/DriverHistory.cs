using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class DriverHistory
    {
        public string EmpID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }

    }
}