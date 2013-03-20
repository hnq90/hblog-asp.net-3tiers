using System;
using System.Web.UI;

namespace Blog.admin
{
    public partial class LogOut : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Index.aspx");
        }
    }
}