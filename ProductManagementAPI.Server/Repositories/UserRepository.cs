using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Server.Data;
using ProductManagementAPI.Server.Models;

namespace ProductManagementAPI.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> AddUserAsync(User user)
        {
            
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username);

            if (existingUser != null)
            {
                return false; 
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true; 
        }
        
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
