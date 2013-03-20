using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Commons;
using Entities;

namespace DAL
{
    public class CategoryDAL
    {

        /// <summary>
        ///     Create A Category
        /// </summary>
        /// <param name="cat">Object Category</param>
        public static void CreateCategory(Category cat)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                var cmd = new SqlCommand(@"INSERT INTO [Category] (CatName, CatUrl) VALUES (@p2, @p3)", cnn);


                var p2 = new SqlParameter("p2", SqlDbType.NVarChar);
                p2.Value = cat.CatName;
                var p3 = new SqlParameter("p3", SqlDbType.NVarChar);
                p3.Value = cat.CatURL;

                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                cmd.ExecuteNonQuery();

                cnn.Dispose();
                cmd.Dispose();
            }
        }

        /// <summary>
        ///     Update Category
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <param name="cat">Object Category</param>
        public static void UpdateCategory(int id, Category cat)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"UPDATE [Category] SET CatName=@p1, CatUrl=@p2 WHERE CatID=@p3", cnn))
                {
                    var p1 = new SqlParameter("p1", SqlDbType.NVarChar);
                    p1.Value = cat.CatName;
                    var p2 = new SqlParameter("p2", SqlDbType.NVarChar);
                    p2.Value = cat.CatURL;
                    var p3 = new SqlParameter("p3", SqlDbType.Int);
                    p3.Value = id;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);

                    cmd.ExecuteNonQuery();

                    cnn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        /// <summary>
        ///     Delete A Category
        /// </summary>
        /// <param name="id">Category ID</param>
        public static void DeleteCategory(int id)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"DELETE FROM [Category]
                                                WHERE CatID = @p1", cnn))
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

        /// <summary>
        ///     Get all category in db
        /// </summary>
        /// <returns>List of object categories</returns>
        public static List<Category> ListCategories()
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (var cmd = new SqlCommand("SELECT CatID, CatName, CatUrl FROM [Category] WHERE (CatID IN (SELECT DISTINCT [Category] FROM Post))", cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Category
                                    {
                                        CatId = int.Parse(row["CatID"].ToString()),
                                        CatName = row["CatName"].ToString(),
                                        CatURL = row["CatUrl"].ToString(),
                                    }).ToList();
                    }
                }
            }
        }
        
        /// <summary>
        /// Get all info an category by id
        /// </summary>
        /// <param name="cid">category id</param>
        /// <returns>List has category object</returns>
        public static List<Category> ListCategoryById(int cid)
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM [Category] WHERE CatID=@p1", cnn))
                {
                    using (var data = new SqlDataAdapter())
                    {
                        var dt = new DataTable();
                        var p1 = new SqlParameter("p1", SqlDbType.Int);
                        p1.Value = cid;
                        cmd.Parameters.Add(p1);
                        data.SelectCommand = cmd;
                        data.Fill(dt);

                        return (from DataRow row in dt.Rows
                                select new Category
                                {
                                    CatId = int.Parse(row["CatID"].ToString()),
                                    CatName = row["CatName"].ToString(),
                                    CatURL = row["CatUrl"].ToString(),
                                }).ToList();
                    }
                }
            }
        }
        
        /// <summary>
        /// Count All Category
        /// </summary>
        /// <returns>number category in db</returns>
        public static int CountCategories()
        {
            using (var cnn = new SqlConnection(BlogCommons._connectionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(@"SELECT COUNT(CatID) FROM [Category]", cnn))
                {
                    return cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }
    }
}