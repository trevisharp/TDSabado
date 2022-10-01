using System;
using System.Collections.Generic;

namespace back.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            FollowFolloweds = new HashSet<Follow>();
            FollowFollowers = new HashSet<Follow>();
            Likes = new HashSet<Like>();
            Posts = new HashSet<Post>();
            Tokens = new HashSet<Token>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string UserId { get; set; } = null!;
        public string Userpass { get; set; } = null!;

        public virtual ICollection<Follow> FollowFolloweds { get; set; }
        public virtual ICollection<Follow> FollowFollowers { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
