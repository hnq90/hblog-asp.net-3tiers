using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BAL;
using Commons;
using Entities;

namespace Blog.admin
{
    public partial class CreatePost : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<User> lt = BlogCommons._currentuser;
            string content = Request.Form["editor1"];
            string title = HttpUtility.HtmlEncode(Request.Form["title"]);
            string seourl = HttpUtility.HtmlEncode(Request.Form["seourl"]);
            string category = Request.Form["category"];
            string thumb = Request.Form["thumb"];
            int authorid = lt[0].ID;

            PostBAL.CreatePost(new Post
                {
                    AuthorId = authorid,
                    Category = Convert.ToInt32(category),
                    Comment = 0,
                    Content = content,
                    Date = DateTime.Now,
                    SeoUrl = seourl,
                    Thumb = thumb,
                    Title = title,
                    ViewTimes = 0
                });
            Response.Redirect("ManagePosts.aspx");
        }
    }
}