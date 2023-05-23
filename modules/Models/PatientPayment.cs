using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class PatientPayment
    {
        public int PaymentId { get; set; }
        public string PatientId { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentAmount { get; set; }
    }
}