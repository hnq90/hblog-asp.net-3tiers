using System;
using System.Web.UI;
using BAL;

namespace Blog.admin
{
    public partial class Deleteuser : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                int postbyauthor = PostBAL.CountPostByAuthor(id);
                //Code delete all post by user
                if (postbyauthor != 0)
                {
                    PostBAL.DeletePostByAuthor(id);
                }
                UserBAL.DeleteUser(id);
                //Code delete user

                Response.Redirect("ManageUsers.aspx");
            }
            catch (FormatException)
            {
                Response.Redirect("ManageUsers.aspx");
            }
        }
    }
}