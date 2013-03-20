using System;
using System.Web.UI;
using BAL;
using Commons;
using Entities;

namespace Blog.admin
{
    public partial class EditProfile : Page
    {
        private readonly ValidateBAL _vb = new ValidateBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.Form["id"]);
            string user = Request.Form["user"];
            string oldpass = BlogCommons.MD5(Request.Form["oldpassword"]);
            string newpass = Request.Form["pass"];
            string renewpass = Request.Form["repass"];
            string email = Request.Form["email"];
            string fullname = Request.Form["fullname"];
            int validlogin = _vb.ValidLogin(user, oldpass);
            bool validpass = _vb.ValidNewPass(newpass, renewpass);

            if (validlogin != 0)
            {
                if (validpass)
                {
                    UserBAL.EditUser(id,
                                     new User
                                         {
                                             Password = BlogCommons.MD5(newpass),
                                             Email = email,
                                             FullName = fullname
                                         });
                    Response.Redirect("LogOut.aspx");
                }
                else
                {
                    UserBAL.EditUser(id,
                                     new User
                                         {
                                             Password = oldpass,
                                             Email = email,
                                             FullName = fullname
                                         });
                    //Label2.Text = "Your password is not changed";
                    Response.Redirect("LogOut.aspx");
                }
            }
            else
            {
                Label1.Text = "Old password is incorrect.";
            }
        }
    }
}