using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class Driver
    {
        public string EmpCode { get; set; }
        public string NationalID { get; set; }
        public DateTime NIssueDate { get; set; }
        public DateTime NExpire { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Status { get; set; }
        public string MilitaryStatus { get; set; }
        public string DriverCarID { get; set; }
        public string DriverCarIDType { get; set; }
        public DateTime DIssueDate { get; set; }
        public DateTime DExpireDate { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public string PhotoPath { get; set; }
        public string Nationality { get; set; }
        public string Extraction { get; set; }
        public string Religion { get; set; }
        public string FartherName { get; set; }
        public int FAge { get; set; }
        public string FCareer { get; set; }
        public string MotherName { get; set; }
        public int MAge { get; set; }
        public string MCareer { get; set; }
        public string WifeName { get; set; }
        public int WAge { get; set; }

    }
}