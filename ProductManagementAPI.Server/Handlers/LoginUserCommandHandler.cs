using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductManagementAPI.Server.Commands;
using ProductManagementAPI.Server.Models;
using ProductManagementAPI.Server.Repositories;
using ProductManagementAPI.Server.Services;

namespace ProductManagementAPI.Server.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
           
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);

          
            if (user == null ||
                _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) != PasswordVerificationResult.Success)
            {
                return string.Empty; 
            }

          
            return _tokenService.GenerateToken(user);
        }
    }
}
