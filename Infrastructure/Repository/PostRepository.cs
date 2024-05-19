using Domain.Entities;
using Domain.interfaces;
using Domain.Shared.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PostRepository(RepositoryContext repositoryContext) : RepositoryBase<Post>(repositoryContext), IPostRepository
    {
        public void AddPost(Post post) => Create(post);

        public async Task<PageList<Post>> GetAllPostsAsync(PostParameters request, bool trackChanges)
        {
            var posts = await FindAll(trackChanges).OrderByDescending(x => x.Likes).ToListAsync();

            return PageList<Post>.ToPageList(posts, request.PageNumber, request.PageSize);
        }


        public async Task<Post> GetPostAsync(int id, bool trackChanges) =>
            await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();


        public async Task<PageList<Post>> GetPostsByUserIdAndFolloweesAsync(PostParameters request, int userId, bool trackChanges)
        {
            var posts = await FindByCondition(x => x.UserId == userId || x.User.Following.Any(f => f.FollowerId == userId), trackChanges)
            .Include(x => x.User)
            .Include(x => x.Likes)
            .OrderByDescending(x => x.Likes.Count)
            .ToListAsync();

            return PageList<Post>.ToPageList(posts, request.PageNumber, request.PageSize);
        }


        public async Task<PageList<Post>> GetPostsByUserIdAsync(PostParameters request, int userId, bool trackChanges)
        {
            var posts = await FindByCondition(x => x.UserId == userId, trackChanges)
              .OrderByDescending(x => x.Likes)
              .ToListAsync();
            return PageList<Post>.ToPageList(posts, request.PageNumber, request.PageSize);
        }


        public void UpdatePost(Post post) => Update(post);
    }
}