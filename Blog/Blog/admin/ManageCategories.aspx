<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="Blog.admin.ManageCategories" %>
<%@ Import Namespace="BAL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Manage Categories
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <form id="form1" runat="server">
        <h2>Manage Category</h2>
        <h4>Click category name to edit</h4>
         <table class="table_posts">
        <tr class="tbheader">
            <td>
                <strong>ID</strong>
            </td>
            <td>
                <strong>Name</strong>
            </td>
            <td>
                <strong>Seo URL</strong>
            </td>
            <td>
                <strong>Delete</strong>
            </td>
        </tr>
        <tr>
            <%
                CategoryBAL cb = new CategoryBAL();
                var ltc = cb.ListCategories();
                foreach (var c in ltc)
                {
                    %>
                    <tr>
                    <td><%=c.CatId %></td>
                    <td><a href="editcategory.aspx?id=<%=c.CatId %>"><%=c.CatName %></a></td>
                    <td><%=c.CatURL %></td>
                    <td><a href="deletecategory.aspx?id=<%=c.CatId %>">Delete</a></td>
                    </tr>
                    <%
                }
            %>
        </tr>
        </table>
        <h2>Create New Category</h2>
        <table>
            <tr>
                <td>
                    <strong>Category Name:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type=text name="catname" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Category URL:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type=text name="caturl" />
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="Button1" runat="server" Text="Create" class="submit_button" 
                                onclick="Button1_Click"/></td>
                <td></td><td></td>
            </tr>
        </table>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ajaxcph" runat="server">
    <!--Hello-->
</asp:Content>