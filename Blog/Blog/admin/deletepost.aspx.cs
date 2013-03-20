using System;
using System.Web.UI;
using BAL;

namespace Blog.admin
{
    public partial class Deletepost : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (CommentBAL.CountCommentByPost(id) != 0)
                {
                    CommentBAL.DeleteCommentByPost(id);
                }
                PostBAL.DeletePost(id);
                Response.Redirect("ManagePosts.aspx");
            }
            catch (FormatException)
            {
                Response.Redirect("ManagePosts.aspx");
            }
        }
    }
}