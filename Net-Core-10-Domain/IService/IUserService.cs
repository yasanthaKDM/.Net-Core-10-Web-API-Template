using Net_Core_10_Domain.Data;
using Net_Core_10_ServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Net_Core_10_Domain.IService
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllUsersAsync();
        public Task<UserDTO> CreateUserAsync(UserDTO user);
        public Task<UserDTO> UpdateUserAsync(UserDTO user);
        public Task<bool> DeleteUserAsync(int id);
    }
}
