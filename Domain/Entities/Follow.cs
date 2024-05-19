using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Follow
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public User Follower { get; set; }
        public int FolloweeId { get; set; }
        public User Followee { get; set; }
    }
}