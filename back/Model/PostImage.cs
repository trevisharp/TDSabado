using System;
using System.Collections.Generic;

namespace back.Model
{
    public partial class PostImage
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public byte[] Bytes { get; set; } = null!;

        public virtual Post? Post { get; set; }
    }
}
