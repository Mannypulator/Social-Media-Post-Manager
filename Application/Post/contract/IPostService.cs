using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Post;
using Domain.Shared.Pagination;

namespace Application.Post.contract
{
    public interface IPostService
    {
        Task<GenericResponse<string>> AddPostAsync(PostForCreationDto request, CancellationToken cancellationToken);

        Task<GenericResponse<IEnumerable<PostDto>>> GetRecentPostsByUserFolloweesAndUserAsync(int userId, PostParameters postParameters);

        Task<GenericResponse<string>> LikePostAsync(PostForLikeDto request, CancellationToken cancellationToken);
    }
}