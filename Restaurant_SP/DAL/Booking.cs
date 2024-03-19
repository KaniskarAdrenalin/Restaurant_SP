using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_SP.DAL
{
    public class Booking
    {
        public int BookingID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> RoomID { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }

    }
}