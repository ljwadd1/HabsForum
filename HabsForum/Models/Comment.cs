﻿namespace HabsForum.Models
{
    public class Comment
    {
        // primary key
        public int CommentId { get; set; } 

        public string Content { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        // foreign key
        public int DiscussionId { get; set; }

        // navigation property
        public Discussion? Discussion { get; set; }
    }
}
