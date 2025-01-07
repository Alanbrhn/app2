using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Server.Commands
{
    public class LoginUserCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password cannot be longer than 100 characters.")]
        public string Password { get; set; }
    }
}
