using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Speciality { get; set; }
        public string Visiting_status { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string HouseAddress { get; set; }
        public int Experience_years { get; set; }
    }
}
