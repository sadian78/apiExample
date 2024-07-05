using ExampleWebApiCore.Core.DTOs;
using ExampleWebApiCore.Core.DTOs.Request.Customer;
using ExampleWebApiCore.Core.DTOs.Response.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Services.IRepository
{
    public interface ICustomerRepository
    {
        //check phoneNumber before Insert Customer
        Task<ApiResponse<string>> CorrectPhoneNumber(string phoneNumber);

        //insert customer to dataBase
        Task<ApiResponse<AddCustomerResponse>> AddNewCustomerAsync(AddCustomerRequest request);

        Task<ApiResponse> CorrectEmail(string email);

    }
}
