<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="editpost.aspx.cs" Inherits="Blog.admin.Edit" %>
<%@ Import Namespace="BAL" %>
<%@ Import Namespace="Commons" %>
<%@ Import Namespace="Entities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Edit Post
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">

    <h1>Edit Post</h1>
    <form id="form1" runat="server">
        <%
            var pb = new PostBAL();
            BlogCommons._postsource = pb.ListPostsById(int.Parse(Request.QueryString["id"]));
        %>
        <input type="hidden" value="<%= BlogCommons._postsource[0].PostID %>" name="id"/>
        <table>
            <tr>
                <td>
                    <strong>Title:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="title" value="<%= BlogCommons._postsource[0].Title %>"/>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>SEO url:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="seourl" value="<%= BlogCommons._postsource[0].SeoUrl %>"/>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Thumbnail Image:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="thumb" value="<%= BlogCommons._postsource[0].Thumb %>" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Category: </strong>
                </td>
                <td>
                </td>
                <td>
                    <select name="category">
                        <%
                            var cb = new CategoryBAL();
                            foreach (Category s in cb.ListCategories())
                            {
                        %>
                            <option value="<%= s.CatId %>"<% if (BlogCommons._postsource[0].Category == s.CatId) Response.Write("selected"); %>>
                                <% Response.Write(s.CatName); %></option>
                        <% } %>
                    </select>
                </td>
            </tr>
        </table>
        <p>
            <textarea class="ckeditor" name="editor1"><%= BlogCommons._postsource[0].Content %></textarea></p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Update" class="submit_button" 
                        onclick="Button1_Click"/>
        </p>
    </form>
</asp:Content>