<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="ClubActiveDetail.aspx.cs" Inherits="Web.ClubManage.ClubActiveDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="1px">
        <tr>
            <td width="100px">活动名称</td>
            <td><asp:Label ID="lab_ActiveHead" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td width="100px">活动海报</td>
            <td>
                <asp:Image ID="img_Poster" runat="server" /></td>
        </tr>
        <tr>
            <td width="100px">活动截止时间</td>
            <td><asp:Label ID="lab_ActiveEndTime" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td width="100px">活动内容</td>
            <td>
                <asp:Label ID="lab_ActiveContent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100px">
                <a href="ClubActivities.aspx">返回</a>
            </td>
        </tr>
    </table>
</asp:Content>
