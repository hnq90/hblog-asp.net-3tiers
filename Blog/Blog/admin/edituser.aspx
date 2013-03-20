<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true"
         CodeBehind="edituser.aspx.cs" Inherits="Blog.admin.Edituser" %>
<%@ Import Namespace="BAL" %>
<%@ Import Namespace="Commons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Edit User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajaxcph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincph" runat="server">
    <h2>Manage User</h2>
    <form id="form1" runat="server">
        <%
            BlogCommons._usersource = UserBAL.GetUserInfoById(int.Parse(Request.QueryString["id"]));
        %>
        <input type="hidden" value="<%= BlogCommons._usersource[0].ID %>" name="id" />
        <table>
            <tr>
                <td>
                    <strong>Username:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="username" value="<%= BlogCommons._usersource[0].Username %>" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Password:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="password" value="<%= BlogCommons._usersource[0].Password %>" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Email</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="email" value="<%= BlogCommons._usersource[0].Email %>" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Full Name: </strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="fullname" value="<%= BlogCommons._usersource[0].FullName %>" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Is Admin: </strong>
                </td>
                <td>
                </td>
                <td>
                    <select name="isadmin">
                        <option value="false">No</option>
                        <option value="true"<% if (BlogCommons._usersource[0].IsAdmin)
                                               {
                                                   Response.Write(" selected");
                                               } %>>Yes</option>
                    </select>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" CssClass="submit_button"></asp:Button>
    </form>
</asp:Content>