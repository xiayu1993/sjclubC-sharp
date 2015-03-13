<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="CheckReciviedMessage.aspx.cs" Inherits="Web.MessageCenter.CheckReciviedMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="1px">
        <tr>
            <td>发件人</td>
            <td><asp:Label ID="lab_sendAccount" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>主题</td>
            <td><asp:Label ID="lab_sendHead" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>正文</td>
            <td>
                <asp:Label ID="lab_content" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <a href="SendMessage.aspx?mailId=<%=Request.QueryString["mailId"].ToString()%>">回复</a>
                <a href="ReciviedMessageList.aspx">返回</a>
            </td>
        </tr>
    </table>
</asp:Content>
