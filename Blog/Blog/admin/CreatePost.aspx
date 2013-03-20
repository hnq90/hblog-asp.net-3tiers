<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true"
         CodeBehind="CreatePost.aspx.cs" Inherits="Blog.admin.CreatePost" %>
<%@ Import Namespace="BAL" %>
<%@ Import Namespace="Entities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Create A New Post
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <h1>
        Create New Posts</h1>
    <form id="form1" runat="server">
        <input type="hidden" value="" name="id"/>
        <table>
            <tr>
                <td>
                    <strong>Title:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="title" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>SEO url:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="seourl" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Thumbnail Image:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="thumb" />
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
                            <option value="<%= s.CatId %>">
                                <% Response.Write(s.CatName); %></option>
                        <% } %>
                    </select>
                </td>
            </tr>
        </table>
        <p>
            <textarea class="ckeditor" name="editor1"></textarea></p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Submit" class="submit_button" 
                        onclick="Button1_Click" />
        </p>
    </form>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ajaxcph" runat="server">
    <!--Hello-->
</asp:Content>