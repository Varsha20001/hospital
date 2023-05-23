using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
    }
}