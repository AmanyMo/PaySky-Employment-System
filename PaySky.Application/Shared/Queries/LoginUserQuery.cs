
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PaySky.Infrastructure.Interfaces;
using PaySky.Infrastructure.Services;

namespace PaySky.Application.Shared.Queries
{
    public class LoginUserQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly Jwt _jwt;
        public LoginUserCommandHandler(IUserRepository userRepository, Jwt jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }
        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null || !PasswordHasher.VerifyPassword(request.Password, user.HashPassword))
            {
                throw new UnauthorizedAccessException("Invalid credentials!!");
            }

            return _jwt.GenerateToken(user);
        }
    }
}
