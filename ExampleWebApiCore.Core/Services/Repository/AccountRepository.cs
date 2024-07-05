using ExampleWebApiCore.Core.DTOs;
using ExampleWebApiCore.Core.DTOs.Request.Account;
using ExampleWebApiCore.Core.DTOs.Response.Account;
using ExampleWebApiCore.Core.Security;
using ExampleWebApiCore.Core.Services.IRepository;
using ExampleWebApiCore.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Services.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private ExampleWebApiContext _context;
        public AccountRepository(ExampleWebApiContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<AuthenticationResponse>> GetAthentication(AthenticationRequest request)
        {
            ApiResponse<AuthenticationResponse> apiResponse = new ApiResponse<AuthenticationResponse>();
            try
            {
                var password = IrreversibleEncryption.sha256(request.Password);
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Password == password && c.Email == request.Email.Trim().ToUpper());
                if (customer != null)
                {
                    AuthenticationResponse authenticationResponse = new AuthenticationResponse()
                    {
                        Family=customer.Family,
                        Name=customer.Name,
                        PhoneNumber=customer.PhoneNumber
                    };
                    apiResponse.IsSuccess = true;
                    apiResponse.Result = authenticationResponse;
                    apiResponse.StatusCode = 202;
                    apiResponse.Message = "کاربر موجود بود";
                }
                else
                {
                    apiResponse.IsSuccess = true;
                    apiResponse.Result = null;
                    apiResponse.StatusCode = 404;
                    apiResponse.Message = "کاربر موجود نبود";
                }
            }
            catch (Exception ex)
            {
                apiResponse.IsSuccess = false;
                apiResponse.Result = null;
                apiResponse.StatusCode = 500;
                apiResponse.Message = ex.Message;
            }
            return apiResponse;
        }
    }
}
