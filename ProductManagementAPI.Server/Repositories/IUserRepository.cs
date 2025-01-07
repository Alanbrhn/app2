using ProductManagementAPI.Server.Models;

namespace ProductManagementAPI.Server.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(User user);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}
