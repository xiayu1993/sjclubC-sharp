<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="CheckMessage.aspx.cs" Inherits="Web.MessageCenter.CheckMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="1px">
        <tr>
            <td>收件人</td>
            <td><asp:Label ID="lab_recivierAccount" runat="server"></asp:Label></td>
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
                <a href="SendedMessageList.aspx">返回</a>
            </td>
        </tr>
    </table>
</asp:Content>
