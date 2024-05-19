using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Post;
using Application.Post.contract;
using Domain.Entities;
using Domain.interfaces;
using Domain.Shared.Pagination;
using Microsoft.Extensions.Logging;

namespace Application.Post.implementation
{
    public class PostService(IRepositoryManager repositoryManager, ILogger<PostService> logger) : IPostService
    {
        public async Task<GenericResponse<string>> AddPostAsync(PostForCreationDto request, CancellationToken cancellationToken)
        {
            LoggerMessages.LogMethodName(logger, nameof(AddPostAsync));

            var user = await repositoryManager.User.GetUserAsync(request.UserId, false);

            LoggerMessages.LogObjectGotten(logger, "User retrieved:", user);

            if (user == null)
            {
                return GenericResponse<string>.Failure("44", "User not found", "");
            }

            var post = new Domain.Entities.Post
            {
                Text = request.Text,
                UserId = request.UserId,
                DateCreated = DateTime.Now,
            };

            repositoryManager.Post.AddPost(post);

            await repositoryManager.SaveAsync(cancellationToken);

            return GenericResponse<string>.Success($"Successfully created post", "");
        }

        public async Task<GenericResponse<IEnumerable<PostDto>>> GetRecentPostsByUserFolloweesAndUserAsync(int userId, PostParameters postParameters)
        {
            LoggerMessages.LogMethodName(logger, nameof(GetRecentPostsByUserFolloweesAndUserAsync));

            var user = await repositoryManager.User.GetUserAsync(userId, false);

            LoggerMessages.LogObjectGotten(logger, "User retrieved:", user);

            if (user is null)
            {
                return GenericResponse<IEnumerable<PostDto>>.Failure("44", "User not found", []);
            }

            var posts = await repositoryManager.Post.GetPostsByUserIdAndFolloweesAsync(postParameters, user.Id, false);

            LoggerMessages.LogObjectGotten(logger, "Posts retrieved:", posts);

            if (!posts.Any()) return GenericResponse<IEnumerable<PostDto>>.Success("No posts found", []);

            var postsDto = posts.Select(p => new PostDto(p.Id, p.UserId, p.Text, p.Likes.Count, p.DateCreated.ToString("dd-MM-yyyy"), p.DateUpdated.ToString("dd-MM-yyyy")));

            return GenericResponse<IEnumerable<PostDto>>.Success("Successfully retrieved posts", postsDto);
        }

        public async Task<GenericResponse<string>> LikePostAsync(PostForLikeDto request, CancellationToken cancellationToken)
        {
            LoggerMessages.LogMethodName(logger, nameof(LikePostAsync));

            var post = await repositoryManager.Post.GetPostAsync(request.PostId, false);

            LoggerMessages.LogObjectGotten(logger, "Post retrieved:", post);

            if (post is null)
            {
                return GenericResponse<string>.Failure("44", "Post not found", "");
            }

            var user = await repositoryManager.User.GetUserAsync(request.UserId, false);

            LoggerMessages.LogObjectGotten(logger, "User retrieved:", user);

            if (user is null)
            {
                return GenericResponse<string>.Failure("44", "User not found", "");
            }

            var userLikedPost = await repositoryManager.Like.UserLikedPost(request.PostId, request.UserId, false);

            LoggerMessages.LogObjectGotten(logger, "User has liked post:", userLikedPost);

            if (userLikedPost is not null)
            {
                repositoryManager.Like.DeleteLike(userLikedPost);
                await repositoryManager.SaveAsync(cancellationToken);
                return GenericResponse<string>.Success($"Successfully unliked post", "");
            }

            var like = new Like
            {
                UserId = request.UserId,
                PostId = request.PostId
            };

            repositoryManager.Like.AddLike(like);

            await repositoryManager.SaveAsync(cancellationToken);

            return GenericResponse<string>.Success($"Successfully liked post", "");
        }
    }
}