using System;
using System.Web.UI;
using BAL;
using Entities;

namespace Blog.admin
{
    public partial class Edituser : Page
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
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string email = Request.Form["email"];
            string fullname = Request.Form["fullname"];
            bool isadmin = bool.Parse(Request.Form["isadmin"]);
            int id = int.Parse(Request.Form["id"]);

            UserBAL.EditUser(id,
                             new User
                                 {
                                     Email = email,
                                     FullName = fullname,
                                     Username = username,
                                     Password = password,
                                     IsAdmin = isadmin
                                 });
        }
    }
}