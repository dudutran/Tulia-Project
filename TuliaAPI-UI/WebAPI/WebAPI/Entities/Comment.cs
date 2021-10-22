﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
