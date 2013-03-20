using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using BAL;

namespace Blog.admin
{
    public partial class ManageCategories : Page
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
            string name = Request.Form["catname"];
            string url = Regex.Replace(Request.Form["caturl"].ToLower(), " ", "-");
            CategoryBAL.CreateCategory(new Entities.Category {CatName = name, CatURL = url});
            Response.Redirect(Request.RawUrl);
        }
    }
}