using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.interfaces
{
    public interface IFollowRepository
    {
        void AddFollow(Follow follow);
        Task<IEnumerable<Follow>> GetUserFollowersAsync(int userId, bool trackChanges);
    }
}