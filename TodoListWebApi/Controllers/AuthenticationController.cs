using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListWebApi.Data;
using TodoListWebApi.Implementations;
using TodoListWebApi.Models;

namespace TodoListWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationController(JwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = MockDb.Users.Values
                .FirstOrDefault(x=> x.Username == loginModel.Username && x.Password == loginModel.Password);

            if (user == null) return BadRequest("Incorrect credentials");

            var token = _jwtTokenGenerator.GenerateToken(user);
            return Ok(token);
        }
    }
}
