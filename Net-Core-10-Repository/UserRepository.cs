using Microsoft.EntityFrameworkCore;
using Net_Core_10_Data;
using Net_Core_10_Domain.Data;
using Net_Core_10_Domain.IRepository;

namespace Net_Core_10_Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync<User>();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            user.LastUpdatedAt = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existing = await _context.Users.FindAsync(user.Id);
            if (existing == null) return null;
            existing.Name = user.Name;
            existing.Email = user.Email;
            existing.Password = user.Password;
            existing.LastUpdatedAt = DateTime.UtcNow;
            _context.Users.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existing = await _context.Users.FindAsync(id);
            if (existing == null) return false;
            _context.Users.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
