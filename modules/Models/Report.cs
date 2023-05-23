using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }

        public string ReportType { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }



        public string Diagnosis { get; set; }



        public string Disease { get; set; }



        public string Doctor_name { get; set; }
    }
}