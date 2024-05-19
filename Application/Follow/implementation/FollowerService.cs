using Application.DTOs;
using Application.DTOs.Follow;
using Application.Follow.contract;
using Domain.interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Follow.implementation
{
    public class FollowerService(IRepositoryManager repositoryManager, ILogger<FollowerService> logger) : IFollowService
    {
        public async Task<GenericResponse<string>> AddFollowerAsync(AddFollowerDto request, CancellationToken cancellationToken)
        {
            LoggerMessages.LogMethodName(logger, nameof(AddFollowerAsync));

            var followee = await GetUserByIdAsync(request.FolloweeId);

            LoggerMessages.LogObjectGotten(logger, "Followee retrieved:", followee);

            if (followee is null)
            {
                return GenericResponse<string>.Failure("44", "User not found", "");
            }



            var follow = new Domain.Entities.Follow
            {
                FollowerId = request.FollowerId,
                FolloweeId = request.FolloweeId
            };


            repositoryManager.Follow.AddFollow(follow);

            await repositoryManager.SaveAsync(cancellationToken);

            return GenericResponse<string>.Success($"Successfully followed : {followee.UserName}", "");
        }

        public async Task<GenericResponse<IEnumerable<FollowDto>>> GetUserFollowersAsync(int userId)
        {
            LoggerMessages.LogMethodName(logger, nameof(GetUserFollowersAsync));

            var followee = await GetUserByIdAsync(userId);

            LoggerMessages.LogObjectGotten(logger,"Followee retrieved:", followee);

            if (followee is null)
            {
                return GenericResponse<IEnumerable<FollowDto>>.Failure("44", "User not found", []);
            }

            var followers = await repositoryManager.Follow.GetUserFollowersAsync(userId, false);

            LoggerMessages.LogObjectGotten(logger, "Followers retrieved:", followers);

            if (!followers.Any()) return GenericResponse<IEnumerable<FollowDto>>.Success("No followers found", []);

            var followersDto = followers.Select(f => new FollowDto(f.Id, f.Follower.UserName));

            return GenericResponse<IEnumerable<FollowDto>>.Success("Successfully retrieved followers", followersDto);
        }

        private Task<Domain.Entities.User> GetUserByIdAsync(int userId)
        {
            LoggerMessages.LogMethodName(logger, nameof(GetUserByIdAsync));

            return repositoryManager.User.GetUserAsync(userId, false);
        }
    }
}