<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="ClubMember.aspx.cs" Inherits="Web.ClubManage.ClubMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>社团成员</h2>
    <asp:Repeater ID="rpt1" runat="server">
        <HeaderTemplate>
            <table cellspacing="0" border="1" style="border-collapse:collapse;border:1px solid Gray;">
                <tr>
                    <th align="center">姓名</th>
                    <th align="center">昵称</th>
                    <th align="center">学院</th>
                    <th align="center">身份</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><asp:Label ID="Label1" runat="server" Text='<%#Eval("TrueName") %>'></asp:Label></td>
                <td align="center"><asp:Label ID="Label2" runat="server" Text='<%#Eval("Name") %>'></asp:Label></td>
                <td align="center"><asp:Label ID="Label3" runat="server" Text='<%#Eval("Academy") %>'></asp:Label></td>
                <td align="center"><asp:Label ID="Label4" runat="server" Text='<%#Eval("StatusName") %>'></asp:Label></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
