using System;
using System.Web.UI;
using BAL;

namespace Blog.admin
{
    public partial class Editcategory : Page
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
            var catname = Request.Form["catname"];
            var caturl = Request.Form["caturl"];
            var catid = int.Parse(Request.Form["catid"]);

            CategoryBAL.UpdateCategory(catid, new Entities.Category { CatName = catname, CatURL = caturl });
            Response.Redirect("ManageCategories.aspx");
        }
    }
}