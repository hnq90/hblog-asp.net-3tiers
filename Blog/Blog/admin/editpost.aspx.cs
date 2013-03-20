using System;
using System.Web;
using System.Web.UI;
using BAL;
using Entities;

namespace Blog.admin
{
    public partial class Edit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ManagePosts.aspx");
            }
            if (Session["admin"] == null)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(HttpUtility.HtmlEncode(Request.Form["id"]));
            string content = Request.Form["editor1"];
            string title = HttpUtility.HtmlEncode(Request.Form["title"]);
            string seourl = HttpUtility.HtmlEncode(Request.Form["seourl"]);
            string category = HttpUtility.HtmlEncode(Request.Form["category"]);
            string thumb = HttpUtility.HtmlEncode(Request.Form["thumb"]);

            PostBAL.UpdatePost(id,
                               new Post
                                   {
                                       Category = Convert.ToInt32(category),
                                       Content = content,
                                       SeoUrl = seourl,
                                       Thumb = thumb,
                                       Title = title
                                   });
            Response.Redirect("ManagePosts.aspx");
        }
    }
}