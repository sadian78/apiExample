using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.DTOs.Request.Account
{
    public class AthenticationRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
