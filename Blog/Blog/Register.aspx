<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMP.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Blog.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Register Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <article><h2>
                 Create An User</h2>
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
                <tr>
                    <td><asp:Button ID="Button1" runat="server" Text="Create" class="submit_button" 
                                    onclick="Button1_Click"/></td>
                    <td></td><td></td><td></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
    
        </form></article>
</asp:Content>