using System.Collections.Generic;
using Commons;
using DAL;
using Entities;

namespace BAL
{
    public class PostBAL
    {
        public static void CreatePost(Post post)
        {
            PostDAL.CreatePost(post);
        }

        public static void UpdatePost(int id, Post post)
        {
            PostDAL.EditPost(id, post);
        }

        public static void DeletePost(int id)
        {
            PostDAL.DeletePost(id);
        }

        public static void DeletePostByAuthor(int auid)
        {
            PostDAL.DeletePostByAuthor(auid);
        }

        public List<Post> ListPosts()
        {
            return PostDAL.ListPosts();
        }

        public List<Post> ListPostsById(int id)
        {
            return PostDAL.ListPostByID(id);
        }

        public List<Post> ListPostsByCategory(int cid)
        {
            return (PostDAL.ListPostsByCategory(cid));
        }

        public static List<Post> ListPostsByUser(int uid)
        {
            return (PostDAL.ListPostsByUser(uid));
        }

        public string StripHTML(string content)
        {
            return HtmlRemoval.StripTagsCharArray(content);
        }

        public static int CountPost()
        {
            return PostDAL.CountPost();
        }

        public static int CountPostByAuthor(int aid)
        {
            return PostDAL.CountPostByAuthor(aid);
        }

        public static int CountPostByCategory(int cid)
        {
            return PostDAL.CountPostByCategory(cid);
        }

        public static List<Post> ListPostPagination(int start, int end)
        {
            return PostDAL.ListPostsPagination(start, end);
        }

        public static List<Post> ListPostsByCategoryPagination(int cid, int start, int end)
        {
            return PostDAL.ListPostsByCategoryPagination(cid, start, end);
        }
    }
}