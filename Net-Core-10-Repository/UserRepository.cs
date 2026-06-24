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
    }
}
