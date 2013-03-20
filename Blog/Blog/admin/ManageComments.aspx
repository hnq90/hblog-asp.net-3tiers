<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="ManageComments.aspx.cs" Inherits="Blog.admin.ManageComments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    Manage Comments
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <form id="form1" runat="server">
        <h2>Manage Comments</h2>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" 
            BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataKeyNames="CommentID" 
            DataSourceID="CommentDS" EnableModelValidation="True" GridLines="Horizontal">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="CommentAuthor" HeaderText="Author" 
                    SortExpression="CommentAuthor" />
                <asp:BoundField DataField="CommentAuthorEmail" HeaderText="Email" 
                    SortExpression="CommentAuthorEmail" />
                <asp:BoundField DataField="CommentDate" HeaderText="Date" 
                    SortExpression="CommentDate" />
                <asp:BoundField DataField="CommentContent" HeaderText="Content" 
                    SortExpression="CommentContent" />
                <asp:CheckBoxField DataField="CommentStatus" HeaderText="Status" 
                    SortExpression="CommentStatus">
                <ControlStyle Width="25px" />
                <FooterStyle Width="25px" />
                <HeaderStyle Width="25px" />
                <ItemStyle Width="25px" />
                </asp:CheckBoxField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="CommentDS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:blogConnectionString %>" 
            DeleteCommand="DELETE FROM [Comment] WHERE [CommentID] = @CommentID" 
            InsertCommand="INSERT INTO [Comment] ([CommentAuthor], [CommentAuthorEmail], [CommentDate], [CommentContent], [CommentIP], [CommentPostID], [CommentStatus]) VALUES (@CommentAuthor, @CommentAuthorEmail, @CommentDate, @CommentContent, @CommentIP, @CommentPostID, @CommentStatus)" 
            SelectCommand="SELECT [CommentID], [CommentAuthor], [CommentAuthorEmail], [CommentDate], [CommentContent], [CommentIP], [CommentPostID], [CommentStatus] FROM [Comment] ORDER BY [CommentDate] DESC" 
            UpdateCommand="UPDATE [Comment] SET [CommentAuthor] = @CommentAuthor, [CommentAuthorEmail] = @CommentAuthorEmail, [CommentDate] = @CommentDate, [CommentContent] = @CommentContent, [CommentStatus] = @CommentStatus WHERE [CommentID] = @CommentID">
            <DeleteParameters>
                <asp:Parameter Name="CommentID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CommentAuthor" Type="String" />
                <asp:Parameter Name="CommentAuthorEmail" Type="String" />
                <asp:Parameter Name="CommentDate" Type="DateTime" />
                <asp:Parameter Name="CommentContent" Type="String" />
                <asp:Parameter Name="CommentIP" Type="String" />
                <asp:Parameter Name="CommentPostID" Type="Int32" />
                <asp:Parameter Name="CommentStatus" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="CommentAuthor" Type="String" />
                <asp:Parameter Name="CommentAuthorEmail" Type="String" />
                <asp:Parameter Name="CommentDate" Type="DateTime" />
                <asp:Parameter Name="CommentContent" Type="String" />
                <asp:Parameter Name="CommentIP" Type="String" />
                <asp:Parameter Name="CommentPostID" Type="Int32" />
                <asp:Parameter Name="CommentStatus" Type="Boolean" />
                <asp:Parameter Name="CommentID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ajaxcph" runat="server">
    <!--Hello-->
</asp:Content>