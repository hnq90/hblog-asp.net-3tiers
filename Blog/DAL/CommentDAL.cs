using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Commons;
using Entities;

namespace DAL
{
    public class CommentDAL
    {
        
        public static void CreateComment(Comment com)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                var cmd =
                    new SqlCommand(@"INSERT INTO [Comment] (CommentAuthor, CommentAuthorEmail, CommentContent, CommentDate, CommentIP, CommentPostID, CommentStatus)
                                                VALUES (@p2, @p3, @p4, @p5, @p6, @p7, @p8)", cnn);


                var p2 = new SqlParameter("p2", SqlDbType.NVarChar);
                p2.Value = com.CommentAuthor;
                var p3 = new SqlParameter("p3", SqlDbType.NVarChar);
                p3.Value = com.CommentAuthorEmail;
                var p4 = new SqlParameter("p4", SqlDbType.NVarChar);
                p4.Value = com.CommentContent;
                var p5 = new SqlParameter("p5", SqlDbType.DateTime);
                p5.Value = com.CommentDate;
                var p6 = new SqlParameter("p6", SqlDbType.NVarChar);
                p6.Value = com.CommentIP;
                var p7 = new SqlParameter("p7", SqlDbType.Int);
                p7.Value = com.CommentPostID;
                var p8 = new SqlParameter("p8", SqlDbType.Bit);
                p8.Value = com.CommentStatus;

                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);

                cmd.ExecuteNonQuery();

                cnn.Dispose();
                cmd.Dispose();
            }
        }

        public static void UpdateComment(int id, Comment com)
        {
            //No need to edit comment - xoa luon cho nhe no =))
        }

        public static void DeleteComment(int id)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"DELETE FROM [Comment]
                                                WHERE CommentID = @p1", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.Int);
                    p1.Value = id;
                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();

                    cnn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        public static void DeleteCommentByPost(int pid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"DELETE FROM [Comment]
                                                WHERE CommentPostID = @p1", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.Int);
                    p1.Value = pid;
                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();

                    cnn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        public static List<Comment> ListComment()
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            @"SELECT CommentID, CommentAuthor, CommentAuthorEmail, CommentContent, CommentPostID, CommentDate, CommentIP, CommentStatus FROM Comment ORDER BY CommentDate DESC",
                            cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Comment
                                    {
                                        CommentID = int.Parse(row["CommentID"].ToString()),
                                        CommentAuthor = row["CommentAuthor"].ToString(),
                                        CommentAuthorEmail = row["CommentAuthorEmail"].ToString(),
                                        CommentContent = row["CommentContent"].ToString(),
                                        CommentPostID = int.Parse(row["CommentPostID"].ToString()),
                                        CommentDate = Convert.ToDateTime(row["CommentDate"].ToString()),
                                        CommentIP = row["CommentIP"].ToString(),
                                        CommentStatus = bool.Parse(row["CommentStatus"].ToString())
                                    }).ToList();
                    }
                }
            }
        }

        public static List<Comment> ListCommentByPost(int pid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            @"SELECT CommentID, CommentAuthor, CommentAuthorEmail, CommentContent, CommentPostID, CommentDate, CommentIP, CommentStatus FROM Comment WHERE (CommentPostID = @p1 AND CommentStatus = 'true') ORDER BY CommentDate DESC",
                            cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        var p1 = new SqlParameter("p1", SqlDbType.Int);
                        p1.Value = pid;
                        cmd.Parameters.Add(p1);
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Comment
                                {
                                    CommentID = int.Parse(row["CommentID"].ToString()),
                                    CommentAuthor = row["CommentAuthor"].ToString(),
                                    CommentAuthorEmail = row["CommentAuthorEmail"].ToString(),
                                    CommentContent = row["CommentContent"].ToString(),
                                    CommentPostID = int.Parse(row["CommentPostID"].ToString()),
                                    CommentDate = Convert.ToDateTime(row["CommentDate"].ToString()),
                                    CommentIP = row["CommentIP"].ToString(),
                                    CommentStatus = bool.Parse(row["CommentStatus"].ToString())
                                }).ToList();
                    }
                }
            }
        }

        public static int CountComment()
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"SELECT COUNT(CommentID) FROM [Comment]", cnn))
                {
                    return cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }

        public static int CountCommentByPost(int pid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (
                    var cmd =
                        new SqlCommand(
                            @"SELECT COUNT(CommentID) FROM [Comment] WHERE (CommentPostID = @p1 AND CommentStatus = 'true')",
                            cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.Int);
                    p1.Value = pid;
                    cmd.Parameters.Add(p1);
                    return cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }
    }
}