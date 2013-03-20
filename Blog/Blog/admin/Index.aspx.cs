using System;
using System.Globalization;
using System.Web.UI;
using BAL;

namespace Blog.admin
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TotalCategories.Text = CategoryBAL.CountCategory().ToString(CultureInfo.InvariantCulture);
            TotalComments.Text = CommentBAL.CountComment().ToString(CultureInfo.InvariantCulture);
            TotalPosts.Text = PostBAL.CountPost().ToString(CultureInfo.InvariantCulture);
            TotalUsers.Text = UserBAL.CountUser().ToString(CultureInfo.InvariantCulture);
        }
    }
}