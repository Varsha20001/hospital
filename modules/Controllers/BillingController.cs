using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using modules.Models;

namespace modules.Controllers
{
    public class BillingController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select BillingID,PatientId,AppointmentID,BillingDate,PaymentMethod,PaymentDate,Amount,PaymentStatus from Billing";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Billing pat)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Billing(PatientId,AppointmentID,BillingDate,PaymentMethod,PaymentDate,Amount,PaymentStatus) values
                ('" + pat.PatientId + @"','" + pat.AppointmentID + @"','" + pat.BillingDate + @"',
                '" + pat.PaymentMethod + @"','" + pat.PaymentDate + @"','" + pat.Amount + @"','" + pat.PaymentStatus + @"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                return "Failed to Add";
            }
        }
        public string Put(Billing doc)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Billing set PatientId='" + doc.PatientId + @"',
                            AppointmentID='" + doc.AppointmentID + @"',
                            BillingDate='" + doc.BillingDate + @"',
                            PaymentMethod='" + doc.PaymentMethod + @"',
                            PaymentDate='" + doc.PaymentDate + @"',
                            Amount='" + doc.Amount + @"',
                            PaymentStatus='" + doc.PaymentStatus + @"'
                            where BillingID=" + doc.BillingID + @"";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return "Failed to Update";
            }
        }
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from Billing where BillingID=" + id;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return "Failed to Delete";
            }
        }
    }
}
