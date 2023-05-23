using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Rooms
    {
        public int Room_id { get; set; }
        public string Room_number { get; set; }
        public string Room_type { get; set; }
        public string Room_condition { get; set; }
        public decimal Room_price { get; set; }
    }
}