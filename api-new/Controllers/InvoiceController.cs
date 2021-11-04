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
    public class InvoiceController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public InvoiceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Get all data from table
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select * from
                            dbo.Invoices
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
        public JsonResult Post(Invoices inv)
        {
            string query = @"
                            insert into dbo.Invoices
                            values (@InvoiceId, @CustomerNumber, @InvoiceDate, @InvoiceAmount, @PaymentAmount, @PaidInFull, @InvoiceFilePath, @DateDue)
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
                    myCommand.Parameters.AddWithValue("@InvoiceId", inv.InvoiceId);
                    myCommand.Parameters.AddWithValue("@CustomerNumber", inv.CustomerNumber);
                    myCommand.Parameters.AddWithValue("@InvoiceDate", inv.InvoiceDate);
                    myCommand.Parameters.AddWithValue("@InvoiceAmount", inv.InvoiceAmount);
                    myCommand.Parameters.AddWithValue("@PaymentAmount", inv.PaymentAmount);
                    myCommand.Parameters.AddWithValue("@PaidInFull", inv.PaidInFull);
                    myCommand.Parameters.AddWithValue("@InvoiceFilePath", inv.InvoiceFilePath);
                    myCommand.Parameters.AddWithValue("@DateDue", inv.DateDue);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPut]
        public JsonResult Put(Invoices inv)
        {
            string query = @"
                            update dbo.Invoices
                            set (CustomerNumber=@CustomerNumber, 
                                   InvoiceDate=@InvoiceDate, InvoiceAmount=@InvoiceAmount, PaymentAmount=@PaymentAmount, 
                                   PaidInFull=@PaidInFull, InvoiceFilePath=@InvoiceFilePath, DateDue=@DateDue)
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
                    myCommand.Parameters.AddWithValue("@CustomerNumber", inv.CustomerNumber);
                    myCommand.Parameters.AddWithValue("@InvoiceDate", inv.InvoiceDate);
                    myCommand.Parameters.AddWithValue("@InvoiceAmount", inv.InvoiceAmount);
                    myCommand.Parameters.AddWithValue("@PaymentAmount", inv.PaymentAmount);
                    myCommand.Parameters.AddWithValue("@PaidInFull", inv.PaidInFull);
                    myCommand.Parameters.AddWithValue("@InvoiceFilePath", inv.InvoiceFilePath);
                    myCommand.Parameters.AddWithValue("@DateDue", inv.DateDue);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        //Doesn;t work.......
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                            delete from dbo.Customers
                            where id= @InvoiceId
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
                    myCommand.Parameters.AddWithValue("@InvoiceId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted!");

        }
    }
}
