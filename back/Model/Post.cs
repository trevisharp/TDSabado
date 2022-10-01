using System;
using System.Collections.Generic;

namespace back.Model
{
    public partial class Post
    {
        public Post()
        {
            Likes = new HashSet<Like>();
            PostImages = new HashSet<PostImage>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime Moment { get; set; }
        public string Content { get; set; } = null!;

        public virtual Usuario? User { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
