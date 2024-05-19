using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        Task<User> GetUserAsync(int id, bool trackChanges);
        Task<bool> CheckUserNameExistsAsync(string userName, bool trackChanges);

    }
}