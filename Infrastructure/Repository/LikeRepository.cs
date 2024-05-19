using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class LikeRepository(RepositoryContext repositoryContext) : RepositoryBase<Like>(repositoryContext), ILikeRepository
    {
        public void AddLike(Like like) => Create(like);

        public void DeleteLike(Like like) => Delete(like);

        public async Task<Like> UserLikedPost(int postId, int userId, bool trackChanges) =>
            await FindByCondition(x => x.PostId == postId && x.UserId == userId, trackChanges).FirstOrDefaultAsync();

    }
}