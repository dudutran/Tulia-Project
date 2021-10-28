using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
