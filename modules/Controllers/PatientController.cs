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
    public class PatientController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select PatientId,PatientName,DateOfBirth,
            Gender, Age,
            HouseAddress,MobileNo,ConsultedDoctor from Patient";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Patient pat)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Patient (PatientName,DateOfBirth,Gender,Age,HouseAddress,MobileNo,ConsultedDoctor) values
                ('" + pat.PatientName + @"','" + pat.DateOfBirth + @"','" + pat.Gender + @"',
                '" + pat.Age + @"','" + pat.HouseAddress + @"','" + pat.MobileNo + @"','" + pat.ConsultedDoctor + @"')";
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
        public string Put(Patient doc)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Patient set PatientName='" + doc.PatientName + @"',
                            DateOfBirth='" + doc.DateOfBirth + @"',
                            Gender='" + doc.Gender + @"',
                            Age='" + doc.Age + @"',
                            HouseAddress='" + doc.HouseAddress + @"',
                            MobileNo='" + doc.MobileNo + @"',
                            ConsultedDoctor='" + doc.ConsultedDoctor + @"' where PatientId=" + doc.PatientId + @"";
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
                string query = @"delete from Patient where PatientId=" + id;
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
