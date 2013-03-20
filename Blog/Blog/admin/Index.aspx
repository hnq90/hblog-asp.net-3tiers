<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Blog.admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Blog Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <form id="form1" runat="server">
        <h1>Blog Dashboard.</h1>
        <p>Total Comments: <asp:Label ID="TotalComments" runat="server" Text=""></asp:Label></p>
        <p>Total Posts: <asp:Label ID="TotalPosts" runat="server" Text=""></asp:Label></p>
        <p>Total Categories: <asp:Label ID="TotalCategories" runat="server" Text=""></asp:Label></p>
        <p>Total Users: <asp:Label ID="TotalUsers" runat="server" Text=""></asp:Label></p>
    </form>
</asp:Content>