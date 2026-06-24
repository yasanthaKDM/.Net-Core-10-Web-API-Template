using Net_Core_10_Domain.Data;
using Net_Core_10_Domain.IRepository;
using Net_Core_10_Domain.IService;
using Net_Core_10_ServiceContract;

namespace Net_Core_10_Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllUsersAsync();

            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            if (userDto == null) return null;
            var entity = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };

            var created = await _userRepo.CreateUserAsync(entity);
            if (created == null) return null;
            return new UserDTO { Name = created.Name, Email = created.Email };
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO userDto)
        {
            if (userDto == null) return null;
            // Find existing by email/name is not reliable; assume client supplies Id via other means in future
            // For now attempt to map by name/email which may not update correct record.
            // Better: include Id in UserDTO in ServiceContract if you need updates by id.
            var entity = new User
            {
                Id = userDto.Id, // Assuming Id is included in UserDTO for update purposes
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                LastUpdatedAt = DateTime.UtcNow
            };

            var updated = await _userRepo.UpdateUserAsync(entity);
            if (updated == null) return null;
            return new UserDTO { Name = updated.Name, Email = updated.Email };
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepo.DeleteUserAsync(id);
        }
    }
}
