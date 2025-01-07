using ProductManagementAPI.Server.Models;

namespace ProductManagementAPI.Server.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
