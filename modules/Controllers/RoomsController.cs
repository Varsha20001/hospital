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
    public class RoomsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select Room_id,Room_number,Room_type,
            Room_condition,Room_price from rooms";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Rooms pat)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into rooms (Room_number,Room_type,Room_condition,Room_price) values
                ('" + pat.Room_number + @"','" + pat.Room_type + @"','" + pat.Room_condition + @"',
                '" + pat.Room_price + @"')";
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
        public string Put(Rooms doc)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update rooms set Room_number='" + doc.Room_number + @"',
                            Room_type='" + doc.Room_type + @"',
                            Room_condition='" + doc.Room_condition + @"',
                            Room_price='" + doc.Room_price + @"'
                            where Room_id=" + doc.Room_id + @"";
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
                string query = @"delete from rooms where Room_id=" + id;
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
