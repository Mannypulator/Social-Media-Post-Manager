using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class FollowRepository(RepositoryContext repositoryContext) : RepositoryBase<Follow>(repositoryContext), IFollowRepository
    {
        public void AddFollow(Follow follow) => Create(follow);

        public async Task<IEnumerable<Follow>> GetUserFollowersAsync(int userId, bool trackChanges) =>
            await FindByCondition(x => x.FolloweeId == userId, trackChanges)
            .Include(x => x.Follower)
            .AsSplitQuery()
            .ToListAsync();

    }
}