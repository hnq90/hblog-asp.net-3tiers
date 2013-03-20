<%@ Page Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Blog.admin.WebForm1" %>
<%@ Import Namespace="BAL" %>
<%@ Import Namespace="Entities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Manage Users
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <h2>Manage User</h2>
    <h3>Click username to edit</h3>
    <table class="table_posts">
        <tr class="tbheader">
            <td>
                <strong>ID</strong>
            </td>
            <td>
                <strong>Username</strong>
            </td>
            <td>
                <strong>Email</strong>
            </td>
            <td>
                <strong>FullName</strong>
            </td>
            <td>
                <strong>Admin</strong>
            </td>
            <td>
                <strong>Delete</strong>
            </td>
        </tr>
        <%
            foreach (User s in UserBAL.ListUsers())
            {
        %>
            <tr>
                <td><%= s.ID %></td>
                <td><a href="edituser.aspx?id=<%= s.ID %>"><%= s.Username %></a></td>
                <td><%= s.Email %></td>
                <td><%= s.FullName %></td>
                <td>
                    <%
                        if (s.IsAdmin)
                        {
                    %>
                        <input type="checkbox" name="isadmin" checked="checked" disabled="disabled"/>
                    <%
                        }
                        else
                        {
                    %>
                        <input type="checkbox" name="isadmin" disabled="disabled"/>
                    <%
                        }
                    %>
                </td>
                <td><a href="deleteuser.aspx?id=<%= s.ID %>">Delete</a></td>
            </tr>
        <%
            }
        %>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ajaxcph" runat="server">
    <!--Hello-->
</asp:Content>