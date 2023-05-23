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
    public class RoomshiftingController : ApiController
    {

        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select ShiftingId,PatientName,PatientId,Previous_room,NoOfdays,Current_room,NoOfDays2 from Roomshifting";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Roomshifting pat)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Roomshifting (PatientId,PatientName,Previous_room,Noofdays,Current_room,NoOfDays2) values
                ('" + pat.PatientId + @"','" + pat.PatientName + @"','" + pat.Previous_room + @"','" + pat.NoOfdays + @"',
                '" + pat.Current_room + @"','" + pat.NoOfDays2 + @"')";
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
        public string Put(Roomshifting doc)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Roomshifting set PatientId='" + doc.PatientId + @"',
                            PatientName='" + doc.PatientName + @"',
                            Previous_room='" + doc.Previous_room + @"',
                            NoOfdays='" + doc.NoOfdays + @"',
                            Current_room='" + doc.Current_room + @"',
                            NoOfDays2='" + doc.NoOfDays2 + @"'
                            where ShiftingId=" + doc.ShiftingId + @"";
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
                string query = @"delete from Roomshifting where ShiftingId=" + id;
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
