using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.DTOs.Response.Account
{
    public class AuthenticationResponse
    {
        public string PhoneNumber { get; set; }
        public string? Family { get; set; }
        public string? Name { get; set; }

    }
}
