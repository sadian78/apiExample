using ExampleWebApiCore.Core.DTOs.Request.Customer;
using ExampleWebApiCore.Core.DTOs;
using ExampleWebApiCore.Core.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Services.Repository
{
    public class UtilitiesRepository : IUtilitiesRepository
    {
        public async Task<ApiResponse> CheckPasswordAsync(string password, string reapetPassword)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                if (password == reapetPassword)
                {
                    if (password.Length >= 8 && password.Length <= 12)
                    {
                        bool hasUpper = false, hasLower = false, hasNumber = false;
                        char[] charsPassword = password.ToCharArray();
                        for (int i = 0; i < charsPassword.Length; i++)
                        {
                            if (char.IsUpper(charsPassword[i]))
                            {
                                hasUpper = true;
                            }
                            else if (char.IsLower(charsPassword[i]))
                            {
                                hasLower = true;
                            }
                            else if (char.IsDigit(charsPassword[i]))
                            {
                                hasNumber = true;
                            }
                        }
                        if (hasUpper == true && hasLower == true && hasNumber == true)
                        {
                            response.Message = "password and Reapeat Password are correct";
                            response.IsSuccess = true;
                            response.StatusCode = 204;
                            return response;
                        }
                        else
                        {
                            response.Message = "password should have number & upper charecter & lower charecter";
                        }

                    }
                    else
                    {
                        response.Message = "password isn't strong (your password is lowe and your passwod should has 8 charecters or heighter)";
                    }
                }
                else
                {
                    response.Message = "password and Repeat password don't same";
                }
                response.IsSuccess = false;
                response.StatusCode = 406;
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
