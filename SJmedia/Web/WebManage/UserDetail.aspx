<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true"
    CodeBehind="UserDetail.aspx.cs" Inherits="Web.WebManage.UserDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2">
                <a href="">修改信息</a>
            </td>
        </tr>
        <tr>
            <td>
                昵称：
            </td>
            <td>
                <asp:Label ID="lab_Name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                账号：
            </td>
            <td>
                <asp:Label ID="lab_Account" runat="server"></asp:Label>
            </td>
            <td>
                密码：
            </td>
            <td>
                <asp:Label ID="lab_password" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                身份：
            </td>
            <td>
                <asp:Label ID="lab_StatusName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                性别：
            </td>
            <td>
                <asp:Label ID="lab_Sex" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                所属社团：
            </td>
            <td>
                <asp:Label ID="lab_ClubName" runat="server" Text='<%#Eval("ClubName")==null?"暂无社团":Eval("ClubName") %>'></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                生日：
            </td>
            <td>
                <asp:Label ID="lab_Birthday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                兴趣爱好：
            </td>
            <td>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                个人说明：
            </td>
            <td>
                <asp:Label ID="lab_Introducation" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                *下面三条信息是判断是否为江汉大学校内学生的重要信息
            </td>
        </tr>
        <tr>
            <td>
                学号：
            </td>
            <td>
                <asp:Label ID="lab_Number" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                姓名：
            </td>
            <td>
                <asp:Label ID="lab_TrueName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                学院：
            </td>
            <td>
                <asp:Label ID="lab_Academy" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
