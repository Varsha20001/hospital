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
    public class DischargeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select DischargeId,PatientName,AppointmentId,DischargeTime,DischargeSummary,Dischargestatus from Discharge";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Discharge pat)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Discharge (PatientName,AppointmentId,DischargeTime,DischargeSummary,Dischargestatus) values
                ('" + pat.PatientName + @"','" + pat.AppointmentId + @"','" + pat.DischargeTime + @"',
                '" + pat.DischargeSummary + @"','" + pat.Dischargestatus + @"')";
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
        public string Put(Discharge doc)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Discharge set PatientName='" + doc.PatientName + @"',
                            AppointmentId='" + doc.AppointmentId + @"',
                            DischargeTime='" + doc.DischargeTime + @"',
                            DischargeSummary='" + doc.DischargeSummary + @"',
                            Dischargestatus='" + doc.Dischargestatus + @"'
                            where DischargeId=" + doc.DischargeId + @"";
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
                string query = @"delete from Discharge where DischargeId=" + id;
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
