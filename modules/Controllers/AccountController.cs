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
    [RoutePrefix("api/Test")]
    public class AccountController : ApiController
    {
        
         SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HosiptalDb"].ConnectionString);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            [HttpPost]
            [Route("Registration")]
            public string Registration(Registration employee)
            {
                string msg = string.Empty;
                try
                {
                    cmd = new SqlCommand("Registration", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", employee.UserName);
                    cmd.Parameters.AddWithValue("@Password", employee.Password);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                    //cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                        msg = "Data Inserted..!";
                    }
                    else
                    {
                        msg = "Error";
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                return msg;
            }
            [HttpPost]
            [Route("Login")]
            public string Login(User employee)
            {
                string msg = string.Empty;
                try
                {
                    da = new SqlDataAdapter("Login", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@UserName", employee.UserName);
                    da.SelectCommand.Parameters.AddWithValue("@Password", employee.Password);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        msg = "User is valid!";
                    }
                    else
                    {
                        msg = "User is Invalid!";
                        //return  RedirectResult("httpsn://localhost:44315/api/Test/Registration");
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;

                }
                return msg;
            }
        [HttpPost]
        [Route("Admin")]
        public string Admin(User employee)
            {
                string msg = string.Empty;
                try
                {
                    da = new SqlDataAdapter("admin", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@UserName", employee.UserName);
                    da.SelectCommand.Parameters.AddWithValue("@Password", employee.Password);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        msg = "Admin is valid!";
                    }
                    else
                    {
                        msg = "Admin is Invalid!";
                    //return  RedirectResult("https://localhost:63451/api/Test/Registration");
                }
            }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    // Response.redirect("https://www.example.com", 302);
                }
                return msg;
            }
        }
    }



  

