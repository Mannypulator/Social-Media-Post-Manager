using Domain.interfaces;

namespace Infrastructure.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IFollowRepository> _followRepository;
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<ILikeRepository> _likeRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _userRepository = new (() => new UserRepository(_context));
            _followRepository = new (() => new FollowRepository(_context));
            _postRepository = new (() => new PostRepository(_context));
            _likeRepository = new (() => new LikeRepository(_context));
        }

        public IUserRepository User => _userRepository.Value;
        public IFollowRepository Follow => _followRepository.Value;
        public IPostRepository Post => _postRepository.Value;
        public ILikeRepository Like => _likeRepository.Value;

        public async Task SaveAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);



    }
}