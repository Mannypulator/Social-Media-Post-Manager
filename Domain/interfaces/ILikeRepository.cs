using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.interfaces
{
    public interface ILikeRepository
    {
        void AddLike(Like like);
        Task<Like> UserLikedPost(int postId, int userId, bool trackChanges);

        void DeleteLike(Like like);
    }
}