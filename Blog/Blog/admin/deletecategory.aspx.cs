using System;
using System.Web.UI;
using BAL;
namespace Blog.admin
{
    public partial class Deletecategory : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PostBAL pb = new PostBAL();
            try
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);

                if (PostBAL.CountPostByCategory(id) != 0)
                {
                    //list ra tat ca cac post cua category nay
                    var ltpost = pb.ListPostsByCategory(id);
                    //lap de lay id cua cac post
                    foreach (var post in ltpost)
                    {
                        //neu trong cac post nay co comment
                        if (CommentBAL.CountCommentByPost(post.PostID) != 0)
                        {
                            //thi xoa comment truoc
                            CommentBAL.DeleteCommentByPost(post.PostID);
                        } //Sau do den xoa post
                        PostBAL.DeletePost(post.PostID);
                    }
                    //Cuoi cung xoa category
                    CategoryBAL.DeleteCategory(id);
                }
                else
                {   //neu so post cua category = 0 thi xoa luon
                    CategoryBAL.DeleteCategory(id);
                }
                Response.Redirect("ManageCategories.aspx");
            }
            catch (FormatException)
            {
                Response.Redirect("ManagePosts.aspx");
            }
        }
    }
}