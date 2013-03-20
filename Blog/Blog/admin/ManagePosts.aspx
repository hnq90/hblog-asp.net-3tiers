<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true"
         CodeBehind="ManagePosts.aspx.cs" Inherits="Blog.admin.ManagePosts" %>
<%@ Import Namespace="BAL" %>
<%@ Import Namespace="Entities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Manage Posts
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <h2>Manage Posts</h2>
    <h3>Click title to edit</h3>
    <table class="table_posts">
        <tr class="tbheader">
            <td>
                <strong>Title</strong>
            </td>
            <td>
                <strong>Category</strong>
            </td>
            <td>
                <strong>Excerpt</strong>
            </td>
            <td>
                <strong>AuthorId</strong>
            </td>
            <td>
                <strong>View</strong>
            </td>
            <td>
                <strong>Delete</strong>
            </td>
        </tr>
        <%
            var pb = new PostBAL();
            foreach (Post s in pb.ListPosts())
            {
        %>
            <tr>
                <td><a href="editpost.aspx?id=<%= s.PostID %>"><%= s.Title %></a></td>
                <td><%= s.CategoryName %></td>
                <td><%
                        string content = pb.StripHTML(HttpUtility.HtmlDecode(s.Content));
                        if (content.Length > 50)
                        {
                            Response.Write(content.Substring(0, 50) + "...");
                        }
                        else
                        {
                            Response.Write(content + "...");
                        }
                    %>
                </td>
                <td><%= s.AuthorName %></td>
                <td><%= s.ViewTimes %></td>
                <td><a href="deletepost.aspx?id=<%= s.PostID %>">Delete</a></td>
            </tr>
        <%
            }
        %>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ajaxcph" runat="server">
    <!--Hello-->
</asp:Content>