using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductManagementAPI.Server.Commands;
using ProductManagementAPI.Server.Models;
using ProductManagementAPI.Server.Repositories;

namespace ProductManagementAPI.Server.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = _passwordHasher.HashPassword(null, request.Password)
            };

            return await _userRepository.AddUserAsync(user);
        }
    }
}
