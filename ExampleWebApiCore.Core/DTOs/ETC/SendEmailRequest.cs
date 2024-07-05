using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.DTOs.ETC
{
    public class SendEmailRequest
    {
        public string EmailTo { get; set; }
        public string EmailBody { get; set; }
        public string EmailSubject { get; set; }
    }
}
