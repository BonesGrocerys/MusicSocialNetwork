using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Auth;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<OperationResult<AuthResponse>>> Authenticate(AuthRequest request)
        {
            var response = await _authService.AuthenticateAsync(request);

            if (response.Success) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("registration")]
        public async Task<ActionResult<OperationResult<AuthResponse>>> Registration(RegistrationRequest request)
        {
            var response = await _authService.RegistrationAsync(request);

            if (response.Success) return Ok(response);

            return BadRequest(response);
        }
    }
}
