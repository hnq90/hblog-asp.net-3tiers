<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true"
         CodeBehind="EditProfile.aspx.cs" Inherits="Blog.admin.EditProfile" %>
<%@ Import Namespace="Commons" %>
<%@ Import Namespace="Entities" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Edit My Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <h1>
        Edit My User</h1>
    <form id="form1" runat="server">
        <%
            List<User> lt2 = BlogCommons._currentuser;
        %>
        <input type="hidden" name="id" value="<%= lt2[0].ID %>" />
        <input type="hidden" name="user" value="<%= lt2[0].Username %>" />
        <table>
            <tr>
                <td>
                    <strong>Old Password:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="password" name="oldpassword" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>New Password:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="password" name="pass" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Re-Enter New Password:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="password" name="repass" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Email:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="email" value="<%= lt2[0].Email %>" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Full Name:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type="text" name="fullname" value="<%= lt2[0].FullName %>" />
                </td>
                <td>
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
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ajaxcph" runat="server">
    <!--Hello-->
</asp:Content>