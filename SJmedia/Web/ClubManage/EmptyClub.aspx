<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="EmptyClub.aspx.cs" Inherits="Web.ClubManage.EmptyClub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>亲，你还没有加入社团哦！<a target="main" href="<%=ConfigurationManager.AppSettings["PageList"].ToString() %>">去社团列表吧</a></p>
</asp:Content>
