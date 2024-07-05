using ExampleWebApiCore.Core.DTOs.ETC;
using ExampleWebApiCore.Core.DTOs.Request.Customer;
using ExampleWebApiCore.Core.Services.IRepository;
using ExampleWebApiCore.Core.Utilities.UtilitiServices.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _repository;
        private ISendCodeRepository _sendCodeRepository;
        public CustomerController(ICustomerRepository repository, ISendCodeRepository sendCodeRepository)
        {
            _repository = repository;
            _sendCodeRepository = sendCodeRepository;
        }

        [Route("api/Customer/CheckPhoneNumber")]
        [HttpPost]
        public async Task<IActionResult> CheckPhoneNumber([FromBody] string phoneNumberRequest)
        {
            var response = await _repository.CorrectPhoneNumber(phoneNumberRequest);
            if (response.IsSuccess == true)
                return Ok(response);
            return BadRequest(response);
        }

        [Route("api/Customer/CheckCorrectEmail")]
        [HttpPost]
        public async Task<IActionResult> CheckCorrectEmail([FromBody] string email)
        {
            var apiResponse = await _repository.CorrectEmail(email);
            if (apiResponse.StatusCode == 204)
                return Ok(apiResponse);
            else
                return BadRequest(apiResponse);

        }

        [Route("api/Customer/SendCodeToEmail")]
        [HttpPost]
        public async Task<IActionResult> SendCodeToEmail([FromBody] SendEmailRequest sendEmailRequest)
        {
            var apiResponse = await _repository.CorrectEmail(sendEmailRequest.EmailTo);
            if (apiResponse.StatusCode == 204)
            {
                await _sendCodeRepository.SendEmail(sendEmailRequest.EmailTo, sendEmailRequest.EmailSubject, sendEmailRequest.EmailBody);
                return Ok(apiResponse);
            }
            else
                return BadRequest(apiResponse);

        }

        [Route("api/Customer/AddNewCustomer")]
        [HttpPost]
        public async Task<IActionResult> AddNewCustomer([FromBody] AddCustomerRequest request)
        {
            var response = await _repository.AddNewCustomerAsync(request);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }


    }
}
