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
    public class PatientPaymentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select PaymentId,PatientId,PaymentDate,PaymentStatus,PaymentAmount from PatientPayment";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(PatientPayment pat)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into  PatientPayment(PatientId,PaymentDate,PaymentStatus,PaymentAmount) values
                ('" + pat.PatientId + @"','" + pat.PaymentDate + @"','" + pat.PaymentStatus + @"',
                '" + pat.PaymentAmount + @"')";
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
        public string Put(PatientPayment doc)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update PatientPayment set PatientId='" + doc.PatientId + @"',
                            PaymentDate='" + doc.PaymentDate + @"',
                            PaymentStatus='" + doc.PaymentStatus + @"',
                            PaymentAmount='" + doc.PaymentAmount + @"'
                            where PaymentId=" + doc.PaymentId + @"";
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
                string query = @"delete from  PatientPayment where PaymentId=" + id;
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
