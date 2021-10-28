using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Like
    {
        public int Id { get; set; }
        public int? SourceUserId { get; set; }
        public int? LikedPostId { get; set; }

        public virtual Post LikedPost { get; set; }
        public virtual User SourceUser { get; set; }
    }
}
