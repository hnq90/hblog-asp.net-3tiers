<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true"
    CodeBehind="editcategory.aspx.cs" Inherits="Blog.admin.Editcategory" %>
<%@ Import Namespace="BAL" %>
<%@ Import Namespace="Commons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajaxcph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincph" runat="server">
    <form id="Form1" runat="server">
    <h2>
        Edit Category</h2>
        <%
            var cb = new CategoryBAL();
            try
            {
                BlogCommons._currentcat = cb.ListCategoryById(int.Parse(Request.QueryString["id"]));
            }
            catch (FormatException)
            {
                Response.Redirect("ManageCategories.aspx");
            }
        %>
        <input type="hidden" value="<%=BlogCommons._currentcat[0].CatId %>" name="catid"/>
    <table>
        <tr>
            <td>
                <strong>Category Name:</strong>
            </td>
            <td>
            </td>
            <td>
                <input type="text" name="catname" value="<%=BlogCommons._currentcat[0].CatName %>" />
            </td>
        </tr>
        <tr>
            <td>
                <strong>Category URL:</strong>
            </td>
            <td>
            </td>
            <td>
                <input type="text" name="caturl" value="<%=BlogCommons._currentcat[0].CatURL %>"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Update" class="submit_button" OnClick="Button1_Click" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</asp:Content>
