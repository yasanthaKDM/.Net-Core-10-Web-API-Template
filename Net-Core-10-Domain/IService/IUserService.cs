using Net_Core_10_Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Net_Core_10_Domain.IService
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> CreateUserAsync(User user);
        public Task<User> UpdateUserAsync(User user);
        public Task<bool> DeleteUserAsync(int id);
    }
}
