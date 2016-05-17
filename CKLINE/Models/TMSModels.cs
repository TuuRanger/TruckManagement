using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class ModelList
    {

        public List<Customers> sCustomer { get; set; }
        public List<Routes> sRoute { get; set; }

    }
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
  
    public class Routes
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string TO { get; set; }
    }
}