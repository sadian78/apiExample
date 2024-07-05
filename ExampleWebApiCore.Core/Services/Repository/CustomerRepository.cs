using ExampleWebApiCore.Core.DTOs;
using ExampleWebApiCore.Core.DTOs.Request.Customer;
using ExampleWebApiCore.Core.DTOs.Response.Customer;
using ExampleWebApiCore.Core.Security;
using ExampleWebApiCore.Core.Services.IRepository;
using ExampleWebApiCore.Core.Utilities;
using ExampleWebApiCore.DataLayer.Context;
using ExampleWebApiCore.DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExampleWebApiCore.Core.Services.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private ExampleWebApiContext _context;
        public CustomerRepository(ExampleWebApiContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<AddCustomerResponse>> AddNewCustomerAsync(AddCustomerRequest request)
        {
            ApiResponse<AddCustomerResponse> response = new ApiResponse<AddCustomerResponse>();
            try
            {
                var password = IrreversibleEncryption.sha256(request.Password);
                Customer customer = new Customer()
                {
                    CreateAccount = DateTime.Now,
                    Password = password,
                    PhoneNumber = request.PhoneNumber,
                    ValidationCode = CreateSpeciallyString.CreateUniqCode(),
                    TypeOfActivityCustomer = TypeOfActivityCustomer.NotActive,
                    Email = request.Email.Trim().ToUpper()
                };
                _context.Customers.Add(customer);
                _context.SaveChanges();
                AddCustomerResponse addCustomerResponse = new AddCustomerResponse()
                {
                    CustomerId = customer.Id,
                    PhoneNumber = customer.PhoneNumber,
                    ValidationCode = customer.ValidationCode
                };
                response.StatusCode = 201;
                response.Message = "successFully event to create customer";
                response.IsSuccess = true;
                response.Result = addCustomerResponse;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ApiResponse> CorrectEmail(string email)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var addr = new MailAddress(email);
                var upperAddress = email.Trim().ToUpper();
                bool isExistEmail = _context.Customers.Any(c => c.Email == upperAddress);
                if (isExistEmail == false)
                {
                    response.IsSuccess = true;
                    response.Message = "email isn't exist";
                    response.StatusCode = 204;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "email is exist";
                    response.StatusCode = 406;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<ApiResponse<string>> CorrectPhoneNumber(string phoneNumber)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                string phoneNumberCorrect = phoneNumber.Trim();
                if (phoneNumberCorrect.Length == 11 && StringInfo.GetNextTextElement(phoneNumberCorrect, 0) == "0")
                    phoneNumberCorrect = phoneNumberCorrect.Remove(0, 1);
                if (phoneNumberCorrect.Length == 10)
                {
                    if (Validator.IsPhoneNumberValidation(phoneNumberCorrect) == true)
                    {
                        bool notExistPhoneNumber = _context.Customers.Any(c => c.PhoneNumber == phoneNumberCorrect);
                        if (notExistPhoneNumber == false)
                        {
                            response.Message = "this phoneNumber is correct";
                            response.IsSuccess = true;
                            response.StatusCode = 200;
                            response.Result = phoneNumberCorrect;
                            return response;
                        }
                        else
                            response.Message = "this phoneNumber is exist";

                    }
                    else
                        response.Message = "this phoneNumber is not valid";
                }
                else
                    response.Message = "this phoneNumber is not correct length";
                response.StatusCode = 406;
                response.IsSuccess = false;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                response.StatusCode = 500;
            }
            return response;
        }


    }
}
