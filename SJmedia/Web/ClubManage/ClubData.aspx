<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="ClubData.aspx.cs" Inherits="Web.ClubManage.ClubData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>社团资料</h2>
    <asp:HyperLink ID="a_changeclubinformation" runat="server" NavigateUrl="ChangeClubInformation.aspx">更改社团信息</asp:HyperLink>
    <table>
        <tr>
            <td>
                社团名：
            </td>
            <td rowspan="4">
                <asp:Image ID="img_ClubLogo" runat="server" Width="120px" Height="90px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lab_ClubName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                社长名：
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lab_President" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                社团详情：
            </td>
        </tr>
        </table>
        <div>
            <asp:Label ID="lab_Instruction" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
