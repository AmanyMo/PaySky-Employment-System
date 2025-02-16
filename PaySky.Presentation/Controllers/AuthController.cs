using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
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
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _globalOption;

        public AuthController(IMediator mediator , IMemoryCache memoryCache, MemoryCacheEntryOptions globalOption)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
            _globalOption = globalOption;
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
            var cashKey = $"Token-{query.Email}";
            //var cacheOptions = new MemoryCacheEntryOptions
            //{
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) 
            //};
            //searcha bout token from cashe the from db
            if (_memoryCache.TryGetValue(cashKey,out string cachedToken))
            {
                return Ok(cachedToken);
            }

            var token = await _mediator.Send(query);

            //save token the return it back
            //_memoryCache.Set(cashKey, token, cacheOptions);

            _memoryCache.Set(cashKey, token, _globalOption);
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
