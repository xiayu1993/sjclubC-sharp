<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Web.IndividualCenter.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>修改密码</h2>
    <table>
        <tr>
            <td>
                原密码：
            </td>
            <td>
                <asp:TextBox ID="tb_oldPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                新密码：
            </td>
            <td>
                <asp:TextBox ID="tb_newPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                确认新密码：
            </td>
            <td>
                <asp:TextBox ID="tb_newPassword2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:LinkButton ID="lbtn1" runat="Server" OnClick="lbtn1_OnClick" Text="更改密码"></asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
