<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMP.Master" AutoEventWireup="true"
         CodeBehind="SinglePost.aspx.cs" Inherits="Blog.SinglePost" %>
<%@ Import Namespace="BAL" %>
<%@ Import Namespace="Commons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlecph" runat="server">
    <% var pb = new PostBAL();
       try
       {
           BlogCommons._currentpost = pb.ListPostsById(int.Parse(Request.QueryString["id"]));
       }
       catch (FormatException)
       {
           Response.Redirect("404.aspx");
       }
    %>
    <%= BlogCommons._currentpost[0].Title + " | HuyNQ's Blog" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincph" runat="server">
    <form id="form1" runat="server">
        <article class="singlepost">
            <h2 class="title">
                <%= BlogCommons._currentpost[0].Title %>
            </h2>
            <p class="post_details">
                Posted Friday, March 08, 2013 - 13:03 by <a href="#">Admin</a>
            </p>
            <%= HttpUtility.HtmlDecode(BlogCommons._currentpost[0].Content) %>
            <p class="post_info">
                <strong>Category:</strong> <a href="#Music">Music</a> | <strong>Views:</strong>
                {
                <%= BlogCommons._currentpost[0].ViewTimes %>
                } views. | <strong>Comments:</strong> <a href="#comment">{
                                                          <%= CommentBAL.CountCommentByPost(int.Parse(Request.QueryString["id"])) %>
                                                          }</a> comments.
            </p>
        </article>
        <div class="comment">
            <div class="comment_title">
                <h3>
                    <asp:Label ID="CountComment" runat="server" Text=""></asp:Label></h3>
            </div>
            <ol class="comment_list">
                <asp:Label ID="CommentsDisplay" runat="server" Text=""></asp:Label>
            </ol>
            <h3>
                Comment Here</h3>
            <% if (Session["logged"] == null)
               {
            %>
                <input type="text" placeholder="Your name (required)" name="name" />
                <input type="text" placeholder="Your email (required)" name="email" />
                <p class="clear">
                </p>
            <% }
               else
               { %>
                <p>
                    You are logged in as
                    <%= BlogCommons._currentuser[0].Username %></p>
                <input type="hidden" name="name" value="<%= BlogCommons._currentuser[0].Username %>" />
                <input type="hidden" name="email" value="<%= BlogCommons._currentuser[0].Email %>" />
            <% } %>
            <textarea name="comment_content" rows="6" cols="70" placeholder="Content..."></textarea>
            <p style="position: relative; top: 20px">
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" class="submit_button" /></p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="" CssClass="submit_button"></asp:Label></p>
        </div>
    </form>
</asp:Content>