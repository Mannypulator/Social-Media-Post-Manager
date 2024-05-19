using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Follow
{
    public record AddFollowerDto(int FollowerId, int FolloweeId);
}