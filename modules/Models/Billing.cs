using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Billing
    {
        public int BillingID { get; set; }
        public string PatientId { get; set; }
        public string AppointmentID { get; set; }
        public string BillingDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentDate { get; set; }
        public string Amount { get; set; }
        public string PaymentStatus { get; set; }
    }
}