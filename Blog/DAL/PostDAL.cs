using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Commons;
using Entities;

namespace DAL
{
    public class PostDAL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        public static void CreatePost(Post post)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                var cmd =
                    new SqlCommand(@"INSERT INTO [Post] (AuthorID, Category, Comment, [Content], [Date], SeoUrl, [Thumb], [Title], [View])
                                                VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)", cnn);


                var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = post.AuthorId };
                var p2 = new SqlParameter("p2", SqlDbType.Int) { Value = post.Category };
                var p3 = new SqlParameter("p3", SqlDbType.Int) { Value = post.Comment };
                var p4 = new SqlParameter("p4", SqlDbType.NVarChar) { Value = post.Content };
                var p5 = new SqlParameter("p5", SqlDbType.DateTime) { Value = DateTime.Now };
                var p6 = new SqlParameter("p6", SqlDbType.NVarChar) { Value = post.SeoUrl };
                var p7 = new SqlParameter("p7", SqlDbType.NVarChar)
                    {
                        Value = post.Thumb == "" ? "resources/images/150x150.gif" : post.Thumb
                    };
                var p8 = new SqlParameter("p8", SqlDbType.NVarChar) { Value = post.Title };
                var p9 = new SqlParameter("p9", SqlDbType.Int) { Value = post.ViewTimes };

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);

                cmd.ExecuteNonQuery();

                cnn.Dispose();
                cmd.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        public static void EditPost(int id, Post post)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (
                    var cmd =
                        new SqlCommand(
                            @"UPDATE [Post] SET Category=@p2, [Content]=@p4, SeoUrl=@p6, Thumb=@p7, Title=@p8 WHERE PostID=@p10",
                            cnn))
                {
                    var p2 = new SqlParameter("p2", SqlDbType.Int) { Value = post.Category };
                    var p4 = new SqlParameter("p4", SqlDbType.NVarChar) { Value = post.Content };
                    var p6 = new SqlParameter("p6", SqlDbType.NVarChar) { Value = post.SeoUrl };
                    var p7 = new SqlParameter("p7", SqlDbType.NVarChar) { Value = post.Thumb };
                    var p8 = new SqlParameter("p8", SqlDbType.NVarChar) { Value = post.Title };
                    var p10 = new SqlParameter("p10", SqlDbType.Int) { Value = id };

                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p6);
                    cmd.Parameters.Add(p7);
                    cmd.Parameters.Add(p8);
                    cmd.Parameters.Add(p10);

                    cmd.ExecuteNonQuery();

                    cnn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void DeletePost(int id)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"DELETE FROM [Post]
                                                WHERE PostID = @p1", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = id };
                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();

                    cnn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auid"></param>
        public static void DeletePostByAuthor(int auid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"DELETE FROM [Post]
                                                WHERE AuthorID = @p1", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = auid };
                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();

                    cnn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Post> ListPosts()
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            @"SELECT Category.CatName, [User].Username, Post.PostID, Post.[Content], Post.Date, Post.SeoUrl, Post.Thumb, Post.Title, Category.CatUrl, Post.AuthorID, Post.Category FROM Category INNER JOIN Post ON Category.CatID = Post.Category INNER JOIN [User] ON Post.AuthorID = [User].ID ORDER BY Post.Date DESC",
                            cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Post
                                    {
                                        PostID = int.Parse(row["PostID"].ToString()),
                                        Title = row["Title"].ToString(),
                                        SeoUrl = row["SeoUrl"].ToString(),
                                        Category = int.Parse(row["Category"].ToString()),
                                        Content = row["Content"].ToString(),
                                        AuthorId = int.Parse(row["AuthorId"].ToString()),
                                        Thumb = row["Thumb"].ToString(),
                                        Date = Convert.ToDateTime(row["Date"].ToString()),
                                        CategoryName = row["CatName"].ToString(),
                                        AuthorName = row["Username"].ToString()
                                    }).ToList();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Post> ListPostByID(int id)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            "SELECT [User].Username, Post.AuthorID, Post.Date, Category.CatName, Post.PostID, Post.[Content], Post.SeoUrl, Post.Thumb, Post.Title, Post.Category FROM Category INNER JOIN Post ON Category.CatID = Post.Category INNER JOIN [User] ON Post.AuthorID = [User].ID WHERE (PostID = @p1) ORDER BY Post.Date DESC",
                            cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        var p1 = new SqlParameter("p1", SqlDbType.Int);
                        p1.Value = id;
                        cmd.Parameters.Add(p1);
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Post
                                    {
                                        PostID = int.Parse(row["PostID"].ToString()),
                                        Title = row["Title"].ToString(),
                                        SeoUrl = row["SeoUrl"].ToString(),
                                        Category = int.Parse(row["Category"].ToString()),
                                        Content = row["Content"].ToString(),
                                        Thumb = row["Thumb"].ToString(),
                                        CategoryName = row["CatName"].ToString(),
                                        AuthorName = row["Username"].ToString(),
                                        AuthorId = int.Parse(row["AuthorID"].ToString()),
                                        Date = Convert.ToDateTime(row["Date"].ToString())
                                    }).ToList();
                    }
                }
            }
        }

        /// <summary>
        ///     Display posts from a category
        /// </summary>
        /// <param name="cid">Category ID</param>
        /// <returns>List of posts</returns>
        public static List<Post> ListPostsByCategory(int cid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            "SELECT [User].Username, Post.AuthorID, Post.Date, Category.CatName, Post.PostID, Post.[Content], Post.SeoUrl, Post.Thumb, Post.Title, Post.Category FROM Category INNER JOIN Post ON Category.CatID = Post.Category INNER JOIN [User] ON Post.AuthorID = [User].ID WHERE (Post.Category = @p1) ORDER BY Post.Date DESC",
                            cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = cid };
                        cmd.Parameters.Add(p1);
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Post
                                    {
                                        PostID = int.Parse(row["PostID"].ToString()),
                                        Title = row["Title"].ToString(),
                                        SeoUrl = row["SeoUrl"].ToString(),
                                        Category = int.Parse(row["Category"].ToString()),
                                        Content = row["Content"].ToString(),
                                        Thumb = row["Thumb"].ToString(),
                                        CategoryName = row["CatName"].ToString(),
                                        AuthorName = row["Username"].ToString(),
                                        AuthorId = int.Parse(row["AuthorID"].ToString()),
                                        Date = Convert.ToDateTime(row["Date"].ToString())
                                    }).ToList();
                    }
                }
            }
        }

        /// <summary>
        ///     Display all posts of an user
        /// </summary>
        /// <param name="uid">User ID</param>
        /// <returns>List of posts</returns>
        public static List<Post> ListPostsByUser(int uid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            "SELECT [User].Username, Post.AuthorID, Post.Date, Category.CatName, Post.PostID, Post.[Content], Post.SeoUrl, Post.Thumb, Post.Title, Post.Category FROM Category INNER JOIN Post ON Category.CatID = Post.Category INNER JOIN [User] ON Post.AuthorID = [User].ID WHERE (Post.AuthorID = @p1) ORDER BY Post.Date DESC",
                            cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = uid };
                        cmd.Parameters.Add(p1);
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Post
                                    {
                                        PostID = int.Parse(row["PostID"].ToString()),
                                        Title = row["Title"].ToString(),
                                        SeoUrl = row["SeoUrl"].ToString(),
                                        Category = int.Parse(row["Category"].ToString()),
                                        Content = row["Content"].ToString(),
                                        Thumb = row["Thumb"].ToString(),
                                        CategoryName = row["CatName"].ToString(),
                                        AuthorName = row["Username"].ToString(),
                                        AuthorId = int.Parse(row["AuthorID"].ToString()),
                                        Date = Convert.ToDateTime(row["Date"].ToString())
                                    }).ToList();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int CountPost()
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"SELECT COUNT(PostID) FROM [Post]", cnn))
                {
                    return cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static int CountPostByAuthor(int aid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"SELECT COUNT(PostID) FROM [Post] WHERE AuthorID=@p1", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = aid };
                    cmd.Parameters.Add(p1);
                    return cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static int CountPostByCategory(int cid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"SELECT COUNT(PostID) FROM [Post] WHERE Category=@p1", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = cid };
                    cmd.Parameters.Add(p1);
                    return cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<Post> ListPostsPagination(int start, int end)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (
                    var cmd =
                        new SqlCommand(
                                        @"WITH t AS
                                        (
                                            SELECT ROW_NUMBER() OVER(ORDER BY [Date] DESC) AS num, [User].Username, Post.AuthorID, Post.Date, Category.CatName, Post.PostID, Post.[Content], Post.SeoUrl, Post.Thumb, Post.Title, Post.Category FROM Category INNER JOIN Post ON Category.CatID = Post.Category INNER JOIN [User] ON Post.AuthorID = [User].ID
                                        )
                                        SELECT *
                                        FROM t
                                        WHERE num > @p1 and num <= @p2", cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = start };
                        cmd.Parameters.Add(p1);
                        var p2 = new SqlParameter("p2", SqlDbType.Int) { Value = end };
                        cmd.Parameters.Add(p2);
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Post
                                {
                                    PostID = int.Parse(row["PostID"].ToString()),
                                    Title = row["Title"].ToString(),
                                    SeoUrl = row["SeoUrl"].ToString(),
                                    Category = int.Parse(row["Category"].ToString()),
                                    Content = row["Content"].ToString(),
                                    AuthorId = int.Parse(row["AuthorId"].ToString()),
                                    Thumb = row["Thumb"].ToString(),
                                    Date = Convert.ToDateTime(row["Date"].ToString()),
                                    CategoryName = row["CatName"].ToString(),
                                    AuthorName = row["Username"].ToString()
                                }).ToList();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<Post> ListPostsByCategoryPagination(int cid, int start, int end)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (
                   var cmd =
                       new SqlCommand(
                                       @"WITH t2 AS
                                        (
                                            SELECT ROW_NUMBER() OVER(ORDER BY [Date] DESC) AS num, [User].Username, Post.AuthorID, Post.Date, Category.CatName, Post.PostID, Post.[Content], Post.SeoUrl, Post.Thumb, Post.Title, Post.Category FROM Category INNER JOIN Post ON Category.CatID = Post.Category INNER JOIN [User] ON Post.AuthorID = [User].ID WHERE (Post.Category = @p1)
                                        )
                                        SELECT *
                                        FROM t2
                                        WHERE num > @p2 and num <= @p3", cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();

                        var p1 = new SqlParameter("p1", SqlDbType.Int) { Value = cid };
                        cmd.Parameters.Add(p1);
                        var p2 = new SqlParameter("p2", SqlDbType.Int) { Value = start };
                        cmd.Parameters.Add(p2);
                        var p3 = new SqlParameter("p3", SqlDbType.Int) { Value = end };
                        cmd.Parameters.Add(p3);

                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Post
                                {
                                    PostID = int.Parse(row["PostID"].ToString()),
                                    Title = row["Title"].ToString(),
                                    SeoUrl = row["SeoUrl"].ToString(),
                                    Category = int.Parse(row["Category"].ToString()),
                                    Content = row["Content"].ToString(),
                                    Thumb = row["Thumb"].ToString(),
                                    CategoryName = row["CatName"].ToString(),
                                    AuthorName = row["Username"].ToString(),
                                    AuthorId = int.Parse(row["AuthorID"].ToString()),
                                    Date = Convert.ToDateTime(row["Date"].ToString())
                                }).ToList();
                    }
                }
            }
        }
    }
}