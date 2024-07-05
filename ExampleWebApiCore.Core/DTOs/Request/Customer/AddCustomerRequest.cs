using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.DTOs.Request.Customer
{
    public class AddCustomerRequest
    {
        public string Password { get; set; }
        public string ReapetPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
