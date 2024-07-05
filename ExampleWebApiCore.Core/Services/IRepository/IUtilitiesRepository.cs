using ExampleWebApiCore.Core.DTOs.Request.Customer;
using ExampleWebApiCore.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Services.IRepository
{
    public interface IUtilitiesRepository
    {
        Task<ApiResponse> CheckPasswordAsync(string password,string reapetPassword);

    }
}
