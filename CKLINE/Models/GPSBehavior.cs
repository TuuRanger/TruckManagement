using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CKLINE.Models
{
    public class GPSBehavior
    {
        /// <summary>
        /// เลขข้างรถ
        /// </summary>
        public string NumberOfTruck { get; set; }

        public DateTime Date { get; set; }
        /// <summary>
        /// ระยะทาง
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// จำนวนครั้งที่ลงทะเบียน
        /// </summary>
        public int NumberOfRegistor   { get; set; }

        /// <summary>
        /// จำนวนความเร็วเกิน
        /// </summary>
        public int NumberOfSpeedUp { get; set; }
        /// <summary>
        /// จำนวนความเดินเบา
        /// </summary>
        public int NumberOfSpeedDown { get; set; }

        /// <summary>
        /// จำนวนครั้งในการจอดรถ
        /// </summary>
        public int NumberOfPark { get; set; }

        /// <summary>
        /// เข้าสถานี
        /// </summary>
        public int NumberOfStation { get; set; }

        /// <summary>
        /// พื้นที่ห้ามเข้า
        /// </summary>
        public int NumberOfNoEntry { get; set; }

        public float Gas { get; set; }

        public int NumberOfStart  { get; set; }

        public int NumberOfResetBox { get; set; }



    }
}