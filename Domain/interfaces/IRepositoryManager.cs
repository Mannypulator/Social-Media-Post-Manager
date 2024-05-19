using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IFollowRepository Follow { get; }
        IPostRepository Post { get; }
        ILikeRepository Like { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}