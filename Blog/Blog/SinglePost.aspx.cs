using System;
using System.Globalization;
using System.Web.UI;
using BAL;
using Commons;
using Entities;

namespace Blog
{
    public partial class SinglePost : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString(CultureInfo.InvariantCulture));
                if (CommentBAL.CountCommentByPost(id) > 0)
                {
                    CountComment.Text = CommentBAL.CountCommentByPost(id) + " comment(s)";
                    string sx = "";
                    foreach (Comment s in CommentBAL.ListCommentByPost(id))
                    {
                        sx += "<li>";
                        sx +=
                            "<div class=\"comment_box\"><div class=\"avatar\"><img src=\"http://www.gravatar.com/avatar/" +
                            BlogCommons.MD5(s.CommentAuthorEmail) + "?size=80\" class=\"avatar\" /></div><br />";
                        sx += "<div class=\"meta\"><strong>" + s.CommentAuthor + "</strong> - " + s.CommentDate +
                              "</div>";
                        sx += "<div class=\"comment_content\">" + s.CommentContent + "</div></div>";
                        sx += "</li>";
                        sx += "<div class=\"clear\"></div>";
                    }
                    CommentsDisplay.Text = sx;
                }
                else
                {
                    CountComment.Text += "Be the first comment in this post :D";
                }
            }
            catch (FormatException)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString(CultureInfo.InvariantCulture));
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string content = Request.Form["comment_content"];

            if (content.Length == 0 || email.Length == 0 || name.Length == 0)
            {
                Label1.Text = "<p>Please fill all field</p>";
            }
            else
            {
                CommentBAL.CreateComment(new Comment
                    {
                        CommentAuthor = name,
                        CommentAuthorEmail = email,
                        CommentContent = content,
                        CommentDate = DateTime.Now,
                        CommentIP = "127.0.0.1",
                        CommentPostID = id,
                        CommentStatus = false
                    });
                Label1.Text = "<p>Your comment will be appeared after accepted.</p>";
            }

            //Response.Redirect(Request.RawUrl);
        }
    }
}