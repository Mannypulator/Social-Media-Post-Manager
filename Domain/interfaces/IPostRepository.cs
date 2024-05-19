using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Shared.Pagination;

namespace Domain.interfaces
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        void UpdatePost(Post post);
        Task<Post> GetPostAsync(int id, bool trackChanges);

        Task<PageList<Post>> GetAllPostsAsync(PostParameters request ,bool trackChanges);

        Task<PageList<Post>> GetPostsByUserIdAsync(PostParameters request, int userId, bool trackChanges);

        // get all by the user and the people the user is following
        Task<PageList<Post>> GetPostsByUserIdAndFolloweesAsync(PostParameters request, int userId, bool trackChanges);
    }
}