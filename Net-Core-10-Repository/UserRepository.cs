using Net_Core_10_Domain.IRepository;

namespace Net_Core_10_Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<string>> GetAllUsersAsync()
        {
            return new List<string> { "Alice", "Bob", "Charlie" };
        }
    }
}
