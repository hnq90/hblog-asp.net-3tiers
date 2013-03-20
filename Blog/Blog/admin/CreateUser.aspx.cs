using System;
using System.Web.UI;
using BAL;
using Commons;
using Entities;

namespace Blog.admin
{
    public partial class CreateUser : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = Request.Form["user"];
            string pass = Request.Form["pass"];
            string repass = Request.Form["repass"];
            string email = Request.Form["email"];
            string fullname = Request.Form["fullname"];
            //var admin = HttpUtility.HtmlEncode(Request.Form["admin"]);

            if (pass.Equals(repass))
            {
                UserBAL.CreateUser(new User
                    {
                        Email = email,
                        Username = user,
                        FullName = fullname,
                        Password = BlogCommons.MD5(pass),
                        IsAdmin = false
                    });
                Response.Redirect("ManageUsers.aspx");
            }
            else
                Label1.Text = "<span style=\"color:red\">Check your password</span>";
        }
    }
}