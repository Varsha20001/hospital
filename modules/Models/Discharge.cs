using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Discharge
    {
        public int DischargeId { get; set; }
        public string PatientName { get; set; }
        public string AppointmentId { get; set; }
        public string DischargeTime { get; set; }
        public string DischargeSummary { get; set; }
        public string Dischargestatus { get; set; }
    }
}