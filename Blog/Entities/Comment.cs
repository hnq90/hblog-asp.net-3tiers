using System;

namespace Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int CommentPostID { get; set; }
        public string CommentContent { get; set; }
        public string CommentAuthor { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentAuthorEmail { get; set; }
        public string CommentIP { get; set; }
        public bool CommentStatus { get; set; }
    }
}