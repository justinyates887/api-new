using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_new.Models
{
    public class Customer
    {
        public int ClientId { get; set; }

        public string Fullname { get; set; }

        public string Username { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }
    }
}
