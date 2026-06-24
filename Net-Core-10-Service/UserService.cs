using Net_Core_10_Domain.IRepository;
using Net_Core_10_Domain.IService;

namespace Net_Core_10_Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<string>> GetAllUsersAsync()
        {
            return await _userRepo.GetAllUsersAsync();
        }
    }
}
