<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMP.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Blog.Category" %>
<%@ Import Namespace="BAL" %>
<%@ Import Namespace="Entities" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <%
        /*
         * Start Pagination
         */
        var catid = 0;
        try
        {
            catid = int.Parse(Request.QueryString["id"]);
        }
        catch (FormatException)
        {
            Response.Redirect("404.aspx");
        }

        float totalpost = PostBAL.CountPostByCategory(catid);
        const float perpage = 6;
        var totalpage = Math.Ceiling(totalpost / perpage);
        float start = 0;
        float end = 0;
        var currentpage = 0;

        if (Request.QueryString["page"] != null)
        {
            try
            {
                currentpage = int.Parse(Request.QueryString["page"]);
            }
            catch (FormatException)
            {
                Response.Redirect("404.aspx");
            }
        }
        else
        {
            currentpage = 1;
        }

        start = (currentpage - 1) * perpage;
        if (start + perpage <= totalpost)
            end = start + perpage;
        else
            end = totalpost;
        if (totalpage < currentpage)
        {
            Response.Redirect("404.aspx");
        }

        //Response.Write(totalpage + " " + currentpage + " " + start + " " + end);  
        /*
         * End Pagination
         */
        var pb = new PostBAL();
        var i = 0;
        var lt2 = PostBAL.ListPostsByCategoryPagination(catid, (int)start, (int)end);
        //var lt2 = pb.ListPostsByCategory(catid);
        if (lt2.Count == 0)
        {
    %>
        <article>
            Not found :(
        </article>
    <%
        }
        foreach (var s in lt2)
        {
            i++;
    %>
        <article class="grid float">
            <h2 class="title"><a href="SinglePost.aspx?id=<%= s.PostID %>"><%= s.Title %></a></h2>
            <p class="post_details">Posted at <%= s.Date %> by <a href="User.aspx?id=<%= s.AuthorId %>"><%= s.AuthorName %></a> </p>
            <a href="SinglePost.aspx?id=<%= s.PostID %>"><img src="<%= s.Thumb %>" class="place_image" alt="" width="150px" height="150px" /></a>
            <%
                var content = pb.StripHTML(HttpUtility.HtmlDecode(s.Content));
                if (content.Length > 400)
                {
                    Response.Write(content.Substring(0, 400) + "...");
                }
                else
                {
                    Response.Write(content + "...");
                }
            %>
            <p class="clear"></p>
            <p class="post_info">
                <strong>Category:</strong> <a href="Categeory.aspx?id=<%= s.Category %>"> <%= s.CategoryName %> </a> | <strong>Comments:</strong> <a href="#comment">{ <%= CommentBAL.CountCommentByPost(s.PostID) %> }</a> comments.
            </p>
        </article>
    <%
        if (i%2 == 0)
        {
            Response.Write("<div class=\"clear\"></div>");
        }
        }
    %>
    <div class="clear">
    </div>
    <ul id="pagination">
        <% 
            int page;
            for (page = 1; page <= totalpage; page++)
            {
        %>
        <%if (page == currentpage)
          {
        %>
        <li class="active"><a href="Category.aspx?id=<%=catid %>&page=<%=page %>">
            <%=page %></a></li>
        <%   
            }
          else
          {
        %>
        <li><a href="Category.aspx?id=<%=catid %>&age=<%=page %>">
            <%=page %></a></li>
        <% } %>
        <%
}    
        %>
    </ul>
</asp:Content>