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
    public class ReportController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select ReportId,ReportName,ReportType,PatientId,PatientName,Diagnosis,Disease,Doctor_name from dbo.Report";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Report rpt)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Report(ReportName,ReportType,PatientId,PatientName,Disease,Diagnosis,Doctor_name)values('" + rpt.ReportName + @"','" + rpt.ReportType + @"','" + rpt.PatientId + @"','" + rpt.PatientName + @"','" + rpt.Disease + @"','" + rpt.Diagnosis + @"','" + rpt.Doctor_name + @"')";
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
        public string Put(Report rpt)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Report set ReportName = '" + rpt.ReportName + @" ',ReportType = '" + rpt.ReportType + @" ',PatientId = '" + rpt.PatientId + @" ',PatientName = '" + rpt.PatientName + @"',Disease ='" + rpt.Disease + @" ',Diagnosis = '" + rpt.Diagnosis + @" ',Doctor_name = '" + rpt.Doctor_name + @" ' where ReportId = " + rpt.ReportId + @" ";
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
                string query = @"delete from Report where ReportId =" + id;
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
