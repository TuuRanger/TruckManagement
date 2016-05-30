using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class TiresChanging
    {
        public DateTime Date { get; set; }
        public string CarRegis { get; set; }
        public int Mile { get; set; }
        public int Position { get; set; }
        public string TakeOffSerial { get; set; }
        public string TakeOffBrand { get; set; }
        public string TakeOffSize { get; set; }
        public string PutOnSerial { get; set; }
        public string PutOnBrand { get; set; }
        public string PutOnSize { get; set; }
    }
}