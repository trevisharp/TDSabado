using System;
using System.Collections.Generic;

namespace back.Model
{
    public partial class Follow
    {
        public int Id { get; set; }
        public int? FollowedId { get; set; }
        public int? FollowerId { get; set; }

        public virtual Usuario? Followed { get; set; }
        public virtual Usuario? Follower { get; set; }
    }
}
