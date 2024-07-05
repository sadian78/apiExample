using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Utilities.UtilitiServices.IRepository
{
    public interface ISendCodeRepository
    {
        Task SendEmail(string to, string subject, string body);
        Task SendSms(string to, string subject, string body);
    }
}
