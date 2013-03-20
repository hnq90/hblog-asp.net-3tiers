using System;
using System.Web.UI;
using BAL;
using Commons;

namespace Blog
{
    public partial class LogIn : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateBAL vb = new ValidateBAL();
            string user = Request.Form["username"];
            string pass = Request.Form["password"];
            int id = vb.ValidLogin(user, BlogCommons.MD5(pass));
            if (id != 0)
            {
                Session["logged"] = true;
                BlogCommons._currentuser = UserBAL.GetUserInfoById(id);
                if (BlogCommons._currentuser[0].IsAdmin == true)
                {
                    Session["admin"] = true;
                }
                Response.Redirect("admin/Index.aspx");
            }
            else
            {
                //Response.Redirect("Index.aspx");
                Response.Write("Wrong username or Password<br />Click <a href='index.aspx'>here</a> to go to homepage");
            }
        }
    }
}