using Ecommerce.Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Core.ServiceContracts;
namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest
            registerRequest)
        {
            // Check for invalid registerRequest
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data");
            }

            // Call the UsersService to handle registration
            AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);
            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);

        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginRequest 
            loginrequest)
        {

            // check for invalid loginRequest
            if (loginrequest == null) 
            {
                return BadRequest("Invalid Login data");
            }
            // Call the UsersService to handle login
            AuthenticationResponse? authenticationResponse = await _usersService.Login(loginrequest); 
            if(authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
    }
}
