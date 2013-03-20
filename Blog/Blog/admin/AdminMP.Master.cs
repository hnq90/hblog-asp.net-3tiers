using System;
using System.Web.UI;

namespace Blog.admin
{
    public partial class AdminMP : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logged"] == null)
            {
                Response.Redirect("../Index.aspx");
            }
        }
    }
}