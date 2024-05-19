using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Follow;

namespace Application.Follow.contract
{
    public interface IFollowService
    {
        Task<GenericResponse<string>> AddFollowerAsync(AddFollowerDto request, CancellationToken cancellationToken);
        Task<GenericResponse<IEnumerable<FollowDto>>> GetUserFollowersAsync(int userId);
    }
}