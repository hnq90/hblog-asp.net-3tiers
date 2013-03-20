using System.Collections.Generic;
using Commons;
using DAL;
using Entities;

namespace BAL
{
    public class CommentBAL
    {
        public static void CreateComment(Comment com)
        {
            CommentDAL.CreateComment(com);
        }

        public static void UpdateComment(int id, Comment com)
        {
            CommentDAL.UpdateComment(id, com);
        }

        public static void DeleteComment(int id)
        {
            CommentDAL.DeleteComment(id);
        }

        public static void DeleteCommentByPost(int pid)
        {
            CommentDAL.DeleteCommentByPost(pid);
        }

        public static List<Comment> ListComment()
        {
            return (CommentDAL.ListComment());
        }

        public static List<Comment> ListCommentByPost(int pid)
        {
            return (CommentDAL.ListCommentByPost(pid));
        }

        public string StripHTML(string content)
        {
            return HtmlRemoval.StripTagsCharArray(content);
        }

        public static int CountComment()
        {
            return (CommentDAL.CountComment());
        }

        public static int CountCommentByPost(int pid)
        {
            return (CommentDAL.CountCommentByPost(pid));
        }
    }
}