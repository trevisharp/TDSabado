using System;
using System.Collections.Generic;

namespace back.Model
{
    public partial class Like
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }

        public virtual Post? Post { get; set; }
        public virtual Usuario? User { get; set; }
    }
}
