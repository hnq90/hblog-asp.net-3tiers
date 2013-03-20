using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Commons;
using Entities;

namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// Create An New User
        /// </summary>
        /// <param name="user">New User Object</param>
        public static void CreateUser(User user)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"INSERT INTO [User] (Username, Password, Email, FullName, IsAdmin)
                                                VALUES (@p1, @p2, @p3, @p4,@p5)", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.NVarChar);
                    p1.Value = user.Username;
                    var p2 = new SqlParameter("p2", SqlDbType.NVarChar);
                    p2.Value = user.Password;
                    var p3 = new SqlParameter("p3", SqlDbType.NVarChar);
                    p3.Value = user.Email;
                    var p4 = new SqlParameter("p4", SqlDbType.NVarChar);
                    p4.Value = user.FullName;
                    var p5 = new SqlParameter("p5", SqlDbType.Bit);
                    p5.Value = user.IsAdmin;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);

                    cmd.ExecuteNonQuery();

                    cnn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        public static void EditUser(int id, User user)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (
                    var cmd = new SqlCommand(@"UPDATE [User] SET Password=@p2, Email=@p3, FullName=@p4 WHERE ID=@p6",
                                             cnn))
                {
                    //SqlParameter p1 = new SqlParameter("p1", SqlDbType.NVarChar);
                    //p1.Value = user.Username;
                    var p2 = new SqlParameter("p2", SqlDbType.NVarChar);
                    p2.Value = user.Password;
                    var p3 = new SqlParameter("p3", SqlDbType.NVarChar);
                    p3.Value = user.Email;
                    var p4 = new SqlParameter("p4", SqlDbType.NVarChar);
                    p4.Value = user.FullName;
                    //SqlParameter p5 = new SqlParameter("p5", SqlDbType.Bit);
                    //p5.Value = user.IsAdmin;
                    var p6 = new SqlParameter("p6", SqlDbType.Int);
                    p6.Value = id;

                    //cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    //cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);

                    cmd.ExecuteNonQuery();

                    cnn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        public static void DeleteUser(int id)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"DELETE FROM [User]
                                                WHERE ID = @p1", cnn))
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

        public static int ValidUser(string user, string password)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand("SELECT ID FROM [User] WHERE (Username = @p1 AND Password = @p2)", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.NVarChar);
                    p1.Value = user;
                    var p2 = new SqlParameter("p2", SqlDbType.NVarChar);
                    p2.Value = password;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);

                    if (cmd.ExecuteScalar() == null)
                        return 0;
                    return Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }

        public static List<User> ListUsers()
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM [User]", cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new User
                                    {
                                        ID = int.Parse(row["ID"].ToString()),
                                        Username = row["Username"].ToString(),
                                        Password = row["Password"].ToString(),
                                        Email = row["Email"].ToString(),
                                        FullName = row["FullName"].ToString(),
                                        IsAdmin = bool.Parse(row["IsAdmin"].ToString())
                                    }).ToList();
                    }
                }
            }
        }

        public static List<User> _get_user_info_by_id(int id)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM [User] WHERE ID = @p1", cnn))
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
                                select new User
                                    {
                                        ID = int.Parse(row["ID"].ToString()),
                                        Username = row["Username"].ToString(),
                                        Password = row["Password"].ToString(),
                                        Email = row["Email"].ToString(),
                                        FullName = row["FullName"].ToString(),
                                        IsAdmin = bool.Parse(row["IsAdmin"].ToString())
                                    }).ToList();
                    }
                }
            }
        }

        public static int CountUser()
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"SELECT COUNT(ID) FROM [User]", cnn))
                {
                    return cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }
    }
}