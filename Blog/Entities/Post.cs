using System;

namespace Entities
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string SeoUrl { get; set; }
        public int Category { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int ViewTimes { get; set; }
        public int Comment { get; set; }
        public string Thumb { get; set; }
        public DateTime Date { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}