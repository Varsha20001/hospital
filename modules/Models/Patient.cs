using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string HouseAddress { get; set; }
        public string MobileNo { get; set; }
        public string ConsultedDoctor { get; set; }
    }
}