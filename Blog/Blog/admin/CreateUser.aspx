<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true"
         CodeBehind="CreateUser.aspx.cs" Inherits="Blog.admin.CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Create An User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <h1>
        Create An User</h1>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <strong>Username:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type=text name="user" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <strong>Password:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type=password name="pass" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <strong>Re-Password:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type=password name="repass" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <strong>Email:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type=text name="email" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <strong>Full Name:</strong>
                </td>
                <td>
                </td>
                <td>
                    <input type=text name="fullname" />
                </td>
                <td></td>
            </tr>
            <!--<tr>
                    <td>
                        <strong>Admin:</strong>
                    </td>
                    <td>
                    </td>
                    <td>
                        <input type=checkbox name="admin" value="1" />
                    </td>
                    <td></td>
                </tr>-->
            <tr>
                <td><asp:Button ID="Button1" runat="server" Text="Create" class="submit_button" 
                                onclick="Button1_Click"/></td>
                <td></td><td></td><td></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ajaxcph" runat="server">
    <!--Hello-->
</asp:Content>