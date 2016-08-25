using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class GPSStation
    {
        public DateTime Date { get; set; }

        public string Head { get; set; }

        public string From { get; set; }

        public string TO { get; set; }

        public DateTime BeginDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public decimal Distance { get; set; }

        public TimeSpan TotalTime { get; set; }

        public TimeSpan TotalPark { get; set; }


        public TimeSpan TotalSpeedDown { get; set; }

        public TimeSpan TotalDriveway { get; set; }
    }
}