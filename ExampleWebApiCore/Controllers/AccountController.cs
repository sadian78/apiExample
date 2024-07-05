using ExampleWebApiCore.Core.DTOs.Request.Account;
using ExampleWebApiCore.Core.Services.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExampleWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAccountRepository _repository;
        public AccountController(IConfiguration configuration,
            IAccountRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AthenticationRequest athenticationRequest)
        {
            var result = await _repository.GetAthentication(athenticationRequest);
            if (result.Result != null)
            {
                var securiteKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
                var signigCredentials = new SigningCredentials(securiteKey, SecurityAlgorithms.HmacSha256);
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("FirstName", "Sadian"));
                var jwtSecurityToken = new JwtSecurityToken(_configuration["Authentication:Issuer"],
                 _configuration["Authentication:Audience"],
                 claimsForToken,
                 DateTime.UtcNow,
                 DateTime.UtcNow.AddHours(1),
                 signigCredentials);
                var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
