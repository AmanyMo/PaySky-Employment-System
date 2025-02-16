
using MediatR;
using PaySky.Domain.Abstract;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;
using PaySky.Infrastructure.Services;

namespace PaySky.Application.Shared.Commands
{
 
    public class RegisterUserCommand : AbstractUser, IRequest<int>
    {

    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,int>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository  userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            int added = 0;
            //check if email exist or not then add
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                User user1 = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    HashPassword = request.HashPassword,
                    CreatedAt = DateTime.UtcNow,
                    RoleId = request.RoleId
                };
                 await _userRepository.AddAsync(user1);
                await _userRepository.SaveAsync();
                added = 1;
            }
            return added;
        }
    }
}
