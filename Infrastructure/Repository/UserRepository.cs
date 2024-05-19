using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository(RepositoryContext repositoryContext) : RepositoryBase<User>(repositoryContext), IUserRepository
    {
        public async Task<bool> CheckUserNameExistsAsync(string userName, bool trackChanges) =>
        await FindByCondition(x => x.UserName.ToLower().Trim() == userName.ToLower().Trim(), trackChanges).AnyAsync();

        public void CreateUser(User user) => Create(user);

        public async Task<User> GetUserAsync(int id, bool trackChanges) => 
            await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();

        public void UpdateUser(User user) => Update(user);
    }
}