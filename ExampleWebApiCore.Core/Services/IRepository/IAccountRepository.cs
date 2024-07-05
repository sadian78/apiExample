using ExampleWebApiCore.Core.DTOs.Request.Account;
using ExampleWebApiCore.Core.DTOs.Response.Account;
using ExampleWebApiCore.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Services.IRepository
{
    public interface IAccountRepository
    {
        Task<ApiResponse<AuthenticationResponse>> GetAthentication(AthenticationRequest request);
    }
}
