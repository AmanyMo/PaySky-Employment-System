using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaySky.Application.Shared.Commands;
using PaySky.Application.Shared.Queries;
using PaySky.Infrastructure.Services;
using System.Text;

namespace PaySky.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            //send pass  as hashed first
            command.HashPassword = PasswordHasher.HashPassword(command.HashPassword);
            var added = await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }



        ////hashing password
        //string GenerateHashPassword(string pass)
        //{
        //    byte[] passwordBytes = Encoding.UTF8.GetBytes(pass);
        //    byte[] hashBytes = SHA256.Create().ComputeHash(passwordBytes);
        //    return Convert.ToBase64String(hashBytes);
        //}
    }
}
