using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using modules.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace modules.Controllers
{
    public class DoctorController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select DoctorID,DoctorName,Speciality,
            Visiting_status, MobileNo,Email,
            HouseAddress,Experience_years from Doctor";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
            using(var cmd=new SqlCommand(query,con))
            using (var da=new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK,table);
        }
        public string Post(Doctor doc)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Doctor (DoctorName,Speciality,Visiting_status,MobileNo,Email,HouseAddress,Experience_years)values('"+doc.DoctorName+@"','"+doc.Speciality+ @"','" + doc.Visiting_status + @"','"+doc.MobileNo +@"','"+doc.Email+@"','"+doc.HouseAddress+@"','"+doc.Experience_years+@"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch(Exception ex)
            {
                return "Failed to Add";
            }
        }
        public string Put(Doctor doc)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Doctor set DoctorName='"+doc.DoctorName+@"',
                            Speciality='"+doc.Speciality+@"',
                            Visiting_Status='"+doc.Visiting_status+@"',
                            MobileNo='"+doc.MobileNo+@"',
                            Email='"+doc.Email+@"',
                            HouseAddress='"+doc.HouseAddress+@"',
                            Experience_years='"+doc.Experience_years+@"' where DoctorID="+doc.DoctorID+@"";
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
                string query = @"delete from Doctor where DoctorID=" + id;
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
