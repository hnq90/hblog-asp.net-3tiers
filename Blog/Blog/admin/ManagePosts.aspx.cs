using System;
using System.Web.UI;

namespace Blog.admin
{
    public partial class ManagePosts : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Index.aspx");
            }
        }
    }
}