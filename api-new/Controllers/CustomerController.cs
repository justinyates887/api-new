using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using api_new.Models;

namespace api_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Get all data from table
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select * from
                            dbo.Customers
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerDbCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                //Fill data into reader
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Customer cust)
        {
            string query = @"
                            insert into dbo.Customers
                            values (@ClientId, @Fullname, @Username, @MobileNumber, @Email, @Address, @Password)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerDbCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                //Fill data into reader
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ClientId", cust.ClientId);
                    myCommand.Parameters.AddWithValue("@Fullname", cust.Fullname);
                    myCommand.Parameters.AddWithValue("@Username", cust.Username);
                    myCommand.Parameters.AddWithValue("@MobileNumber", cust.MobileNumber);
                    myCommand.Parameters.AddWithValue("@Email", cust.Email);
                    myCommand.Parameters.AddWithValue("@Address", cust.Address);
                    myCommand.Parameters.AddWithValue("@Password", cust.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPut]
        public JsonResult Put(Customer cust)
        {
            string query = @"
                            update dbo.Customers
                            set (Fullname= @Fullname, Username= @Username, MobileNumber= @MobileNumber, Email= @Email, Address= @Address, Password= @Password)
                            where ClientId= @ClientId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerDbCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                //Fill data into reader
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Fullname", cust.Fullname);
                    myCommand.Parameters.AddWithValue("@Username", cust.Username);
                    myCommand.Parameters.AddWithValue("@MobileNumber", cust.MobileNumber);
                    myCommand.Parameters.AddWithValue("@Email", cust.Email);
                    myCommand.Parameters.AddWithValue("@Address", cust.Address);
                    myCommand.Parameters.AddWithValue("@Password", cust.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added!");

        }

        //Doesn;t work.......
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                            delete from dbo.Customers
                            where ClientId= @ClientId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerDbCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                //Fill data into reader
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ClientId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added!");

        }
    }
}
