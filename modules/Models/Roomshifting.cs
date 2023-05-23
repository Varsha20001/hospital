using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Roomshifting
    {
        public int ShiftingId { get; set; }

        public string PatientName { get; set; }

        public int PatientId { get; set; }

        public string Previous_room { get; set; }

        public int NoOfdays { get; set; }

        public string Current_room { get; set; }

        public int NoOfDays2 { get; set; }
    }
}