using Business.Abstract;
using Business.Constans;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO register)
        {
            var result = _authManager.Register(register);
            if (result.Success)
            {
                return Ok(new { status = 200, message = Message.UserRegistered });
            }
            return BadRequest(new { status = 400, message = Message.ErrorOnRegister });

        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var result = _authManager.Login(loginDTO);
            if (result.Success)
            {
                return Ok(new { status = 200, token = result.Message });
            }
            return BadRequest(new { message = result.Message });
        }
    }
}
