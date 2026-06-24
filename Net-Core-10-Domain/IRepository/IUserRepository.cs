using Net_Core_10_Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Net_Core_10_Domain.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
    }
}
