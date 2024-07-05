using ExampleWebApiCore.Core.Services.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private IUtilitiesRepository _repository;
        public UtilitiesController(IUtilitiesRepository repository)
        {
            _repository = repository;
        }

        [Route("api/Utilities/CheckCorrectPassword")]
        [HttpPost]
        public async Task<IActionResult> CheckCorrectPassword(string password, string reapetPassword)
        {
            var apiResponse = await _repository.CheckPasswordAsync(password, reapetPassword);
            if (apiResponse.StatusCode == 204)
                return Ok(apiResponse);
            else
                return BadRequest(apiResponse);

        }
    }
}
